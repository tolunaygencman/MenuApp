using MenuApp.Business.DTOs.Menus;
using MenuApp.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.Business.Abstracts
{
    public interface IMenuService
    {
        Task<IDataResult<List<MenuListDto>>> GetAllAsync();
        Task<IDataResult<MenuDto>> AddAsync(MenuCreateDto entity);
        Task<IDataResult<MenuDto>> GetByIdAsync(Guid Id);
        Task<IDataResult<MenuDto>> UpdateAsync(MenuUpdateDto entity);
        Task<IDataResult<MenuDto>> UpdateWithoutImgAsync(MenuUpdateWithoutImgDto entity);

    }
}
