using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using MenuApp.Business.Abstracts;
using MenuApp.Business.DTOs.Foods;
using MenuApp.MVC.Areas.Member.Models.FoodVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Areas.Member.Controllers.Food
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class FoodController : Controller
    {
        private readonly IFoodService _foodManager;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;
        private readonly IStringLocalizer<FoodController> _localizer;

        public FoodController(IFoodService foodManager, IMapper mapper, INotyfService notyf, IStringLocalizer<FoodController> localizer)
        {
            _foodManager = foodManager;
            _mapper = mapper;
            _notyf = notyf;
            _localizer = localizer;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            var foods = await _foodManager.GetAllAsync(id);
            TempData["CategoryId"] = id;
            return View(_mapper.Map<IList<FoodListVM>>(foods.Data));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FoodCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                TempData["CategoryId"] = model.CategoryId;
                return View(model);
            }
            var food = _mapper.Map<FoodCreateDto>(model);
            var foodResult = await _foodManager.AddAsync(food);
            if (foodResult.IsSuccess)
            {
                _notyf.Success(_localizer["Create_Food_Success"]);
                return RedirectToAction("Index", "Food", new { id = model.CategoryId });
            }
            _notyf.Warning(_localizer["Create_Food_Fail"] + " - " + foodResult.Message);
            TempData["CategoryId"] = model.CategoryId;
            return View(model);
        }
        public async Task<IActionResult> Update(Guid id)
        {
            var food = await _foodManager.GetByIdAsync(id);
            TempData["CategoryId"] = food.Data.CategoryId;
            if (string.IsNullOrEmpty(id.ToString()))
                return NotFound();
            if (food is null)
            {
                return NotFound();
            }
            var mappedFood = _mapper.Map<FoodUpdateVM>(food.Data);
            return View(mappedFood);
        }
        [HttpPost]
        public async Task<IActionResult> Update(FoodUpdateVM model)
        {
            //Todo:Price input doesn't add true values everytime
            //Todo :Only use 1 method with or witout image change
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.Image is null)
            {
                var food = _mapper.Map<FoodUpdateWithoutImgDto>(model);
                var foodResult = await _foodManager.UpdateWithoutImgAsync(food);
                if (foodResult.IsSuccess)
                {
                    _notyf.Success(_localizer["Update_Food_Success"]);
                    return RedirectToAction("Index", "Food", new { id = model.CategoryId });
                }
                _notyf.Warning(_localizer["Update_Food_Fail"] + " - " + foodResult.Message);
                return View(model);
            }
            else
            {
                var food = _mapper.Map<FoodUpdateDto>(model);
                var foodResult = await _foodManager.UpdateAsync(food);
                if (foodResult.IsSuccess)
                {
                    _notyf.Success(_localizer["Update_Food_Success"]);
                    return RedirectToAction("Index", "Food", new { id = model.CategoryId });
                }
                _notyf.Warning(_localizer["Update_Food_Fail"] + " - " + foodResult.Message);
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
                return NotFound();

            var deletedFood = await _foodManager.GetByIdAsync(id);
            var indexId = deletedFood.Data.CategoryId;

            if (deletedFood == null)
                return NotFound();

            await _foodManager.DeleteAsync(deletedFood.Data);
            _notyf.Error(_localizer["Delete_Success"]);
            return RedirectToAction("Index", "Food", new { id = indexId });
        }
    }
}
