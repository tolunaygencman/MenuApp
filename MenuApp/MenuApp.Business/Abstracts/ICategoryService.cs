using MenuApp.Business.DTOs.Categories;
using MenuApp.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuApp.Business.Abstracts
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDTO>> AddAsync(CategoryCreateDTO entity);
        Task<IDataResult<List<CategoryListDTO>>> GetAllAsync(Guid id);
    }
}
