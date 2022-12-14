using AutoMapper;
using MenuApp.Business.Abstracts;
using MenuApp.Business.Constants;
using MenuApp.Business.DTOs.Menus;
using MenuApp.Core.Utilities.Results;
using MenuApp.Core.Utilities.Results.Concrete;
using MenuApp.DataAccess.Abstracts;
using MenuApp.Entity.Concretes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.Business.Concretes
{
    public class MenuManager : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;
        private readonly IMemberService _memberManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MenuManager(IMenuRepository menuRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IMemberService memberManager)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _memberManager = memberManager;
        }

        public async Task<IDataResult<MenuDTO>> AddAsync(MenuCreateDTO entity)
        {
            entity.UserId = GetUserId();
            var menuCreate = await _menuRepository.AddAsync(_mapper.Map<Menu>(entity));       
            if (menuCreate is null)
            {
                return new ErrorDataResult<MenuDTO>(Messages.MenuAddFail);
            }
            return new SuccessDataResult<MenuDTO>(_mapper.Map<MenuDTO>(menuCreate), Messages.MenuAddSuccess);
        }

        public async Task<IDataResult<List<MenuListDTO>>> GetAllAsync()
        {
            var menus = await _menuRepository.GetAllAsync(x => x.UserId == GetUserId());
            return new SuccessDataResult<List<MenuListDTO>>(_mapper.Map<List<MenuListDTO>>(menus), Messages.ListedSuccess);
        }

        public async Task<IDataResult<MenuDTO>> GetByIdAsync(Guid Id)
        {
            var menu = await _menuRepository.GetAsync(x => x.Id == Id);
            if (menu is null)
            {
                return new ErrorDataResult<MenuDTO>(Messages.MenuDoesntExist);
            }
            return new SuccessDataResult<MenuDTO>(_mapper.Map<MenuDTO>(menu), Messages.FoundSuccess);

        }

        private Guid GetUserId()
        {
            var currentMember = _memberManager.GetByIdentityId(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)).GetAwaiter().GetResult();
            return currentMember.Data.Id;
        }
    }
}
