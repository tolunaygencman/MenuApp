using MenuApp.Business.DTOs.Display;
using MenuApp.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.Business.Abstracts
{
    public interface IDisplayService
    {
        Task<IDataResult<DisplayCategoriesDto>> GetDisplayCategories(Guid Id);
        Task<IDataResult<DisplayFoodsDto>> GetDisplayFoods(Guid Id);
    }
}
