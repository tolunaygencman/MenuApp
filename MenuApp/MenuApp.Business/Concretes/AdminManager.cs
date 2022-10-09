using AutoMapper;
using MenuApp.Business.Abstracts;
using MenuApp.Business.Constants;
using MenuApp.Business.DTOs.Admins;
using MenuApp.Core.Utilities.Results;
using MenuApp.Core.Utilities.Results.Concrete;
using MenuApp.DataAccess.Abstracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace MenuApp.Business.Concretes
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public AdminManager(IAdminRepository adminRepository, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IDataResult<AdminDto>> GetByIdentityId(string identityId)
        {
            var admin =await _adminRepository.GetAsync(x => x.IdentityId == identityId);
            if (admin is null)
            {
                return new ErrorDataResult<AdminDto>(Messages.UserNotFound);
            }
            return new SuccessDataResult<AdminDto>(_mapper.Map<AdminDto>(admin), Messages.ListedSuccess);
        }
    }
}
