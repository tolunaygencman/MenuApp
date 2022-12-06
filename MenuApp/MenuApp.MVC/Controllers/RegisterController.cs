using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using MenuApp.Business.Abstracts;
using MenuApp.Business.DTOs.Members;
using MenuApp.MVC.Extensions;
using MenuApp.MVC.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IMemberService _memberManager;
        private readonly INotyfService _notyf;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<RegisterController> _localizer;

        public RegisterController(IMemberService memberManager, INotyfService notyf, IMapper mapper, UserManager<IdentityUser> userManager, IStringLocalizer<RegisterController> localizer)
        {
            _memberManager = memberManager;
            _notyf = notyf;
            _mapper = mapper;
            _userManager = userManager;
            _localizer = localizer;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var member = await _userManager.FindByEmailAsync(model.Email);
            if (member is null)
            {
                var memberDto = _mapper.Map<MemberCreateDto>(model);
                if (model.Image != null)
                {
                    memberDto.Image = Convert.ToBase64String(await model.Image.GetBytesAsync());
                }
                var addMemberResult = await _memberManager.AddAsync(memberDto);
                if (addMemberResult.IsSuccess)
                {
                    _notyf.Success(_localizer["Member_Success"]);
                     return RedirectToAction("Index","Login");
                }
                _notyf.Error(_localizer["Member_Error"] + addMemberResult.Message);
                return View(model);

            }
            _notyf.Warning(_localizer["Member_Exist"]);
            return View(model);
        }
    }
}
