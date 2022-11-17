using AutoMapper;
using MenuApp.Business.Abstracts;
using MenuApp.Business.Constants;
using MenuApp.Business.DTOs.Members;
using MenuApp.Core.Utilities.Results;
using MenuApp.Core.Utilities.Results.Concrete;
using MenuApp.DataAccess.Abstracts;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MenuApp.Business.Concretes
{
    public class MemberManager:IMemberService
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

        public async Task<IDataResult<MemberDto>> GetByIdentityId(string identityId)
        {
            var member = await _memberRepository.GetAsync(x => x.IdentityId == identityId);
            if (member is null)
            {
                return new ErrorDataResult<MemberDto>(Messages.UserNotFound);
            }
            return new SuccessDataResult<MemberDto>(_mapper.Map<MemberDto>(member), Messages.ListedSuccess);
        }
    }
}
