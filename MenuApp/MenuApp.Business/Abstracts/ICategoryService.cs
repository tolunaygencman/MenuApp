using MenuApp.Business.DTOs.Categories;
using MenuApp.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuApp.Business.Abstracts
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> AddAsync(CategoryCreateDto entity);
        Task<IDataResult<List<CategoryListDto>>> GetAllAsync(Guid id);
        Task<IDataResult<CategoryDto>> GetByIdAsync(Guid id);
    }
}
