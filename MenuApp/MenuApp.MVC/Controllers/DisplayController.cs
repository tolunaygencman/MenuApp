using AutoMapper;
using MenuApp.Business.Abstracts;
using MenuApp.MVC.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Controllers
{
    public class DisplayController : Controller
    {
        private readonly IDisplayService _displayManager;
        private readonly IMapper _mapper;

        public DisplayController(IDisplayService displayManager, IMapper mapper)
        {
            _displayManager = displayManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Categories(Guid Id)
        {
            var model = await _displayManager.GetDisplayCategories(Id);
            return View(_mapper.Map<DisplayCategoriesVM>(model.Data));
        }
        public async Task<IActionResult> Foods(Guid Id)
        {
            var model = await _displayManager.GetDisplayFoods(Id);
            return View(_mapper.Map<DisplayFoodsVM>(model.Data));
        }
       
    }
}
