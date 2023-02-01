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

        public async Task<IDataResult<MenuDto>> AddAsync(MenuCreateDto entity)
        {
            entity.UserId = GetMemberId();
            var menuCreate = await _menuRepository.AddAsync(_mapper.Map<Menu>(entity));       
            if (menuCreate is null)
            {
                return new ErrorDataResult<MenuDto>(Messages.MenuAddFail);
            }
            return new SuccessDataResult<MenuDto>(_mapper.Map<MenuDto>(menuCreate), Messages.MenuAddSuccess);
        }

        public async Task<IDataResult<List<MenuListDto>>> GetAllAsync()
        {
            var menus = await _menuRepository.GetAllAsync(x => x.UserId == GetMemberId());
            return new SuccessDataResult<List<MenuListDto>>(_mapper.Map<List<MenuListDto>>(menus), Messages.ListedSuccess);
        }

        public async Task<IDataResult<MenuDto>> GetByIdAsync(Guid Id)
        {
            var menu = await _menuRepository.GetByIdAsync(Id);
            if (menu is null)
            {
                return new ErrorDataResult<MenuDto>(Messages.MenuDoesntExist);
            }
            return new SuccessDataResult<MenuDto>(_mapper.Map<MenuDto>(menu), Messages.FoundSuccess);

        }

        public async Task<IDataResult<MenuDto>> UpdateAsync(MenuUpdateDto entity)
        {
            var menuTobeUpdated =  await _menuRepository.GetByIdAsync(entity.Id);
            var mappedMenu = _mapper.Map(entity,menuTobeUpdated);
            var updatedMenu = await _menuRepository.UpdateAsync(mappedMenu);

            if (updatedMenu is null)
            {
                return new ErrorDataResult<MenuDto>(_mapper.Map<MenuDto>(updatedMenu), Messages.MenuUpdateFail);
            }
            return new SuccessDataResult<MenuDto>(_mapper.Map<MenuDto>(updatedMenu), Messages.MenuUpdateSuccess);
        }

        public async Task<IDataResult<MenuDto>> UpdateWithoutImgAsync(MenuUpdateWithoutImgDto entity)
        {
            var menuTobeUpdated = await _menuRepository.GetByIdAsync(entity.Id);
            var mappedMenu = _mapper.Map(entity, menuTobeUpdated);
            var updatedMenu = await _menuRepository.UpdateAsync(mappedMenu);

            if (updatedMenu is null)
            {
                return new ErrorDataResult<MenuDto>(_mapper.Map<MenuDto>(updatedMenu), Messages.MenuUpdateFail);
            }
            return new SuccessDataResult<MenuDto>(_mapper.Map<MenuDto>(updatedMenu), Messages.MenuUpdateSuccess); 
        }

        private Guid GetMemberId()
        {
            var currentMember = _memberManager.GetByIdentityId(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)).GetAwaiter().GetResult();
            return currentMember.Data.Id;
        }
    }
}
