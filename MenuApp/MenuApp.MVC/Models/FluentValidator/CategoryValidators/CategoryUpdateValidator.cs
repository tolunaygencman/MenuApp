using FluentValidation;
using MenuApp.MVC.Areas.Member.Models.CategoryVMs;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Models.FluentValidator.CategoryValidators
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateVM>
    {
        public CategoryUpdateValidator(IStringLocalizer<CategoryUpdateVM> stringLocalizer)
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage(x => stringLocalizer["Empty_Category_Name"]);

            RuleFor(x => x.Description).NotEmpty().WithMessage(x => stringLocalizer["Empty_Description"])
                    .MaximumLength(256).WithMessage(x => stringLocalizer["Description_Length"]);


            RuleFor(x => x.Image.Length).LessThanOrEqualTo(5242880)
                   .WithMessage(x => stringLocalizer["File_Size"]).When(x => x.Image != null);

            RuleFor(x => x.Image.ContentType).Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                    .WithMessage(x => stringLocalizer["Correct_Image_File_Type"]).When(x => x.Image != null);
        }
    }
}
