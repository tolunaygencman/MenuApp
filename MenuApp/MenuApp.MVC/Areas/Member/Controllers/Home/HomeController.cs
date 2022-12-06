using AspNetCoreHero.ToastNotification.Abstractions;
using MenuApp.Business.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MenuApp.MVC.Areas.Member.Controllers.Home
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class HomeController : Controller
    {

        private readonly IMemberService _memberManager;
        private readonly INotyfService _notyf;

        public HomeController(IMemberService memberManager, INotyfService notyf)
        {
            _memberManager = memberManager;
            _notyf = notyf;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _memberManager.GetByIdentityId(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            if (TempData["Login"] != null)
                _notyf.Success($"Hoş Geldin {user.Data.FirstName} {user.Data.LastName}");
            return View();
        }
    }
}
