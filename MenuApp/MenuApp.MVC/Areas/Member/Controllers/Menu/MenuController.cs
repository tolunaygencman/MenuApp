using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using MenuApp.Business.Abstracts;
using MenuApp.Business.DTOs.Menus;
using MenuApp.MVC.Areas.Member.Models.MenuVMs;
using MenuApp.MVC.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Areas.Member.Controllers.Menu
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuManager;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;
        private readonly IStringLocalizer<MenuController> _localizer;

        public MenuController(IMenuService menuManager, IMapper mapper, INotyfService notyf, IStringLocalizer<MenuController> localizer)
        {
            _menuManager = menuManager;
            _mapper = mapper;
            _notyf = notyf;
            _localizer = localizer;
        }

        public async Task<IActionResult> Index()
        {
            var menus = await _menuManager.GetAllAsync();
            return View(_mapper.Map<IList<MenuListVM>>(menus.Data));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MenuCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var menu = _mapper.Map<MenuCreateDTO>(model);
            var menuResult = await _menuManager.AddAsync(menu);
            if (menuResult.IsSuccess)
            {
                _notyf.Success(_localizer["Create_Menu_Success"]);
                 return RedirectToAction("Index", "Menu");
            }
            _notyf.Warning(_localizer["Create_Menu_Fail"] +" - "+ menuResult.Message);
            return View(model);
        }
    }
}
