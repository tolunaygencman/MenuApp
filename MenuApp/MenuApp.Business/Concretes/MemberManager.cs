using AutoMapper;
using MenuApp.Business.Abstracts;
using MenuApp.Business.Constants;
using MenuApp.Business.DTOs.Members;
using MenuApp.Core.Enums;
using MenuApp.Core.Utilities.Results;
using MenuApp.Core.Utilities.Results.Concrete;
using MenuApp.DataAccess.Abstracts;
using MenuApp.Entity.Concretes;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MenuApp.Business.Concretes
{
    public class MemberManager : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public MemberManager(IMemberRepository memberRepository, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IDataResult<MemberDto>> AddAsync(MemberCreateDto entity)
        {
            IdentityUser identityUser = new IdentityUser()
            {
                Email = entity.Email,
                EmailConfirmed = true,
                UserName = entity.Email
            };
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    //StringGenerator.GenerateRandomPassword(); Mail entegrasyonundan sonra kullanıcıya bu şifre gönderilecek.
                    var memberCreateResult = await _userManager.CreateAsync(identityUser, entity.Password);

                    if (!memberCreateResult.Succeeded)
                    {
                        scope.Dispose();

                        var errorMessage = ConcatErrors(memberCreateResult);

                        return new ErrorDataResult<MemberDto>(errorMessage);
                    }

                    var addRoleToMemberResult = await _userManager.AddToRoleAsync(identityUser, Roles.Member.ToString());

                    if (!addRoleToMemberResult.Succeeded)
                    {
                        scope.Dispose();

                        var errorMessage = ConcatErrors(addRoleToMemberResult);

                        return new ErrorDataResult<MemberDto>(errorMessage);
                    }

                    entity.IdentityId = identityUser.Id;

                    var member = await _memberRepository.AddAsync(_mapper.Map<Member>(entity));
                    if (member == null)
                    {
                        scope.Dispose();

                        return new ErrorDataResult<MemberDto>(Messages.MemberAddFail);
                    }
                    scope.Complete();

                    return new SuccessDataResult<MemberDto>(_mapper.Map<MemberDto>(member), Messages.MemberAddSuccess);

                }
                catch (System.Exception)
                {
                    scope.Dispose();
                    throw;
                }              
            }


        }
        public async Task<IDataResult<MemberDto>> GetByIdentityId(string identityId)
        {
            var member = await _memberRepository.GetAsync(x => x.IdentityId == identityId);
            if (member is null)
            {
                return new ErrorDataResult<MemberDto>(Messages.UserNotFound);
            }
            return new SuccessDataResult<MemberDto>(_mapper.Map<MemberDto>(member), Messages.ListedSuccess);
        }

        private string ConcatErrors(IdentityResult identityResult)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var error in identityResult.Errors)
            {
                stringBuilder.Append("**");
                stringBuilder.Append(error.Code);
                stringBuilder.Append(" - ");
                stringBuilder.Append(error.Description);
            }

            return stringBuilder.ToString();
        }
    }
}
