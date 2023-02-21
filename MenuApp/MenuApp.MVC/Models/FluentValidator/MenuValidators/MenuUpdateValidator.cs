using FluentValidation;
using MenuApp.MVC.Areas.Member.Models.MenuVMs;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Models.FluentValidator.MenuValidators
{
    public class MenuUpdateValidator : AbstractValidator<MenuUpdateVM>
    {
        public MenuUpdateValidator(IStringLocalizer<MenuUpdateVM> stringLocalizer)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(x => stringLocalizer["Empty_Menu_Name"]);

            RuleFor(x => x.TextColor).NotEmpty().WithMessage(x => stringLocalizer["Empty_TextColor"]);

            RuleFor(x => x.ButtonColor).NotEmpty().WithMessage(x => stringLocalizer["Empty_ButtonColor"]);

            RuleFor(x => x.BackgroundImage.Length).LessThanOrEqualTo(5242880)
               .WithMessage(x => stringLocalizer["File_Size"]).When(x => x.BackgroundImage != null);

            RuleFor(x => x.BackgroundImage.ContentType).Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                .WithMessage(x => stringLocalizer["Correct_Image_File_Type"]).When(x => x.BackgroundImage != null);

        }
    }
}
