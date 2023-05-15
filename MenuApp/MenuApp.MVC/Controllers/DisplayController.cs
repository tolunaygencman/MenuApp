using AutoMapper;
using MenuApp.Business.Abstracts;
using MenuApp.MVC.Extensions;
using MenuApp.MVC.Models.VMs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MenuApp.MVC.Controllers
{
    public class DisplayController : Controller
    {
        private readonly IDisplayService _displayManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DisplayController(IDisplayService displayManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _displayManager = displayManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Categories(Guid Id)
        {
            if (string.IsNullOrEmpty(Id.ToString()))
                return NotFound();
            var model = await _displayManager.GetDisplayCategories(Id);
            if (model is null)
            {
                return NotFound();
            }
            return View(_mapper.Map<DisplayCategoriesVM>(model.Data));
        }

        public async Task<IActionResult> Foods(Guid Id)
        {
            if (string.IsNullOrEmpty(Id.ToString()))
                return NotFound();
            var model = await _displayManager.GetDisplayFoods(Id);
            if (model is null)
            {
                return NotFound();
            }
            return View(_mapper.Map<DisplayFoodsVM>(model.Data));
        }

        public IActionResult QRCode(Guid Id)
        {
            var request = _httpContextAccessor.HttpContext.Request;
            var baseUri = $"{request.Scheme}://{request.Host}/{request.RouteValues["controller"]}/Categories/{Id}"; // 'Display/Categories/{id} url'
            var picture = QRCodeExtension.CreatePngQR(baseUri, 10);
            return File(picture, "image/png");
        }

    }
}
