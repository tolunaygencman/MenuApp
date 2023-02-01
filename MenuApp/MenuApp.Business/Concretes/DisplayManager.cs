using AutoMapper;
using MenuApp.Business.Abstracts;
using MenuApp.Business.Constants;
using MenuApp.Business.DTOs.Categories;
using MenuApp.Business.DTOs.Display;
using MenuApp.Business.DTOs.Foods;
using MenuApp.Core.Utilities.Results;
using MenuApp.Core.Utilities.Results.Concrete;
using MenuApp.DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuApp.Business.Concretes
{
    public class DisplayManager : IDisplayService
    { 
        private readonly IMenuRepository _menuRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;



        public DisplayManager(IMenuRepository menuRepository, ICategoryRepository categoryRepository, IFoodRepository foodRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _categoryRepository = categoryRepository;
            _foodRepository = foodRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<DisplayCategoriesDto>> GetDisplayCategories(Guid Id)
        {
            var menuPart = await _menuRepository.GetByIdAsync(Id);
            var categoryPart = await _categoryRepository.GetAllAsync(x => x.MenuId == menuPart.Id);
            var mappedCategories = _mapper.Map<List<CategoryListDto>>(categoryPart);
            DisplayCategoriesDto display = new DisplayCategoriesDto()
            {
                Id = menuPart.Id,
                MenuName = menuPart.Name,
                BackgroundImage = menuPart.BackgroundImage,
                ButtonColor = menuPart.ButtonColor,
                TextColor = menuPart.TextColor,
                Categories = mappedCategories

            };
            if (display is null)
            {
                return new ErrorDataResult<DisplayCategoriesDto>(Messages.ListNotReceived);
            }
            return new SuccessDataResult<DisplayCategoriesDto>(display, Messages.ListedSuccess);
        }

        public async Task<IDataResult<DisplayFoodsDto>> GetDisplayFoods(Guid Id)
        {

            var categoryPart = await _categoryRepository.GetByIdAsync(Id);
            var menuPart = await _menuRepository.GetByIdAsync(categoryPart.MenuId);
            var foodPart = await _foodRepository.GetAllAsync(x => x.CategoryId == categoryPart.Id);
            var mappedFoods = _mapper.Map<List<FoodListDto>>(foodPart);
            DisplayFoodsDto display = new DisplayFoodsDto()
            {
                Id = categoryPart.Id,
                Description = categoryPart.Description,
                CategoryName = categoryPart.Name,
                BackgroundImage = menuPart.BackgroundImage,
                ButtonColor = menuPart.ButtonColor,
                TextColor = menuPart.TextColor,
                Foods = mappedFoods

            };
            if (display is null)
            {
                return new ErrorDataResult<DisplayFoodsDto>(Messages.ListNotReceived);
            }
            return new SuccessDataResult<DisplayFoodsDto>(display, Messages.ListedSuccess);
        }

    }
}
