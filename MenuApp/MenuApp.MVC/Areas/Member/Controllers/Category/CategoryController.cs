using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using MenuApp.Business.Abstracts;
using MenuApp.Business.DTOs.Categories;
using MenuApp.MVC.Areas.Member.Models.CategoryVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Areas.Member.Controllers.Category
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryManager;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;
        private readonly IStringLocalizer<CategoryController> _localizer;

        public CategoryController(ICategoryService categoryManager, IMapper mapper, INotyfService notyf, IStringLocalizer<CategoryController> localizer)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
            _notyf = notyf;
            _localizer = localizer;
        }
        //TODO : url de menü adı gösterme bul guid yerine

        [HttpGet]
        public async Task<IActionResult> Index(Guid id)
        {
            var categories = await _categoryManager.GetAllAsync(id);
            TempData["MenuId"] = id;
            return View(_mapper.Map<IList<CategoryListVM>>(categories.Data));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                TempData["MenuId"] = model.MenuId;
                return View(model);
            }
            var category = _mapper.Map<CategoryCreateDto>(model);
            var categoryResult = await _categoryManager.AddAsync(category);
            if (categoryResult.IsSuccess)
            {
                _notyf.Success(_localizer["Create_Category_Success"]);
                return RedirectToAction("Index", "Category", new { id = model.MenuId });
            }
            _notyf.Warning(_localizer["Create_Category_Fail"] + " - " + categoryResult.Message);
            TempData["MenuId"] = model.MenuId;
            return View(model);
        }
    }
}
