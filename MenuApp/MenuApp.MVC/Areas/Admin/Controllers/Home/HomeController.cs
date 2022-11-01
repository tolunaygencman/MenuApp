using AspNetCoreHero.ToastNotification.Abstractions;
using MenuApp.Business.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MenuApp.MVC.Areas.Admin.Controllers.Home
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IAdminService _adminManager;
        private readonly INotyfService _notyf;

        public HomeController(IAdminService adminManager, INotyfService notyf)
        {
            _adminManager = adminManager;
            _notyf = notyf;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _adminManager.GetByIdentityId(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            if (TempData["Login"] != null)
                _notyf.Success($"Hoş Geldin {user.Data.FirstName} {user.Data.LastName}");
            return View();
        }
    }
}

