using MenuApp.Business.Abstracts;
using MenuApp.Business.Constants;
using MenuApp.Business.DTOs.Display;
using MenuApp.Core.Utilities.Results;
using MenuApp.Core.Utilities.Results.Concrete;
using MenuApp.DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.Business.Concretes
{
    public class DisplayManager : IDisplayService
    {
        private readonly MenuManager _menuService;
        private readonly CategoryManager _categoryService;
        private readonly FoodManager _foodService;


        public DisplayManager(MenuManager menuService, CategoryManager categoryService, FoodManager foodService)
        {
            _menuService = menuService;
            _categoryService = categoryService;
            _foodService = foodService;
        }

        public async Task<IDataResult<DisplayCategoriesDto>> GetDisplayCategories(Guid Id)
        {
            var menuPart = await _menuService.GetByIdAsync(Id);
            var categoryPart = await _categoryService.GetAllAsync(menuPart.Data.Id);
            DisplayCategoriesDto display = new DisplayCategoriesDto()
            {
                Id = menuPart.Data.Id,
                MenuName = menuPart.Data.Name,
                BackgroundImage = menuPart.Data.BackgroundImage,
                ButtonColor = menuPart.Data.ButtonColor,
                TextColor = menuPart.Data.TextColor,
                Categories = categoryPart.Data

            };
            if (display is null)
            {
                return new ErrorDataResult<DisplayCategoriesDto>(Messages.ListNotReceived);
            }
            return new SuccessDataResult<DisplayCategoriesDto>(display, Messages.ListedSuccess);
        }

        public async Task<IDataResult<DisplayFoodsDto>> GetDisplayFoods(Guid Id)
        {

            var categoryPart = await _categoryService.GetByIdAsync(Id);
            var menuPart = await _menuService.GetByIdAsync(categoryPart.Data.MenuId);
            var foodPart = await _foodService.GetAllAsync(categoryPart.Data.Id);
            DisplayFoodsDto display = new DisplayFoodsDto()
            {
                Id = categoryPart.Data.Id,
                Description = categoryPart.Data.Description,
                CategoryName = categoryPart.Data.Name,
                BackgroundImage = menuPart.Data.BackgroundImage,
                ButtonColor = menuPart.Data.ButtonColor,
                TextColor = menuPart.Data.TextColor,
                Foods = foodPart.Data

            };
            if (display is null)
            {
                return new ErrorDataResult<DisplayFoodsDto>(Messages.ListNotReceived);
            }
            return new SuccessDataResult<DisplayFoodsDto>(display, Messages.ListedSuccess);
        }

    }
}
