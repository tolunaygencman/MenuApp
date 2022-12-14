using AspNetCoreHero.ToastNotification.Abstractions;
using MenuApp.MVC.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;

namespace MenuApp.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly INotyfService _notyf;
        private readonly IStringLocalizer<LoginController> _localizer;

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, INotyfService notyf, IStringLocalizer<LoginController> localizer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _notyf = notyf;
            _localizer = localizer;
        }
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            var user = await _userManager.GetUserAsync(User);
            if (user is null)
            {              
                return RedirectToAction(nameof(SignOut));
            }
            var userRole = await _userManager.GetRolesAsync(user);
            if (userRole[0] is null)
            {
                
                return RedirectToAction(nameof(SignOut));
            }
            return RedirectToAction("Index", "Home", new { Area = userRole[0].ToString() });
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginVM model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null)
            {
                _notyf.Error(_localizer["Email_or_Password_is_Wrong"]);
                return View(model);
            }
            var userRole = await _userManager.GetRolesAsync(user);
            if (userRole is null)
            {
                _notyf.Error(_localizer["Cant_Find_UserRole"]);
                return View(model);
            }
            var checkPass = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (!checkPass.Succeeded)
            {
                _notyf.Error(_localizer["Email_or_Password_is_Wrong"]);
                return View(model);
            }
            TempData["Login"] = "ok";
            return RedirectToAction("Index", "Home", new { Area = userRole[0].ToString() });     
        }
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

    }
}
