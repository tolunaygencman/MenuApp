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
        Task<IDataResult<List<MenuListDTO>>> GetAllAsync();
        Task<IDataResult<MenuDTO>> AddAsync(MenuCreateDTO entity);
        Task<IDataResult<MenuDTO>> GetByIdAsync(Guid Id);

    }
}
