using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using MenuApp.Business.Abstracts;
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
    }
}
