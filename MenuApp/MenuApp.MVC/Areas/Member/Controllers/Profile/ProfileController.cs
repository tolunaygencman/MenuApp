using AspNetCoreHero.ToastNotification.Abstractions;
using MenuApp.Business.Abstracts;
using MenuApp.MVC.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Areas.Member.Controllers.Profile
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class ProfileController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly INotyfService _notyf;
        private readonly IStringLocalizer<ProfileController> _localizer;

        public ProfileController(IAccountService accountService, INotyfService notyf, IStringLocalizer<ProfileController> localizer)
        {
            _accountService = accountService;
            _notyf = notyf;
            _localizer = localizer;
        }

        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.ChangePasswordAsync(model.CurrentPassword, model.NewPassword);
                if (result.IsSuccess)
                {
                    _notyf.Success(_localizer["Change_Password_Success"]);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
    }
}
