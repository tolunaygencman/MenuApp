using MenuApp.Business.DTOs.Foods;
using MenuApp.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.Business.Abstracts
{
    public interface IFoodService
    {
        Task<IDataResult<FoodDto>> AddAsync(FoodCreateDto entity);
        Task<IDataResult<List<FoodListDto>>> GetAllAsync(Guid id);
        Task<IDataResult<FoodDto>> GetByIdAsync(Guid id);
        Task<bool> DeleteAsync(FoodDto entity);
    }
}
