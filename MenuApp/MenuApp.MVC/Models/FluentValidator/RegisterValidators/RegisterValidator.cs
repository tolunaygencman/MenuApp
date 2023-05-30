using FluentValidation;
using MenuApp.MVC.Models.VMs;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Models.FluentValidator.RegisterValidators
{
    public class RegisterValidator : AbstractValidator<RegisterVM>
    {
        public RegisterValidator(IStringLocalizer<RegisterVM> stringLocalizer)
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(x => stringLocalizer["FirstName_Not_Empty"])
                .MinimumLength(2).WithMessage(x => stringLocalizer["FirstName_Minumum_Length"])
                .Matches(@"^(?!'+$)[a-zA-Z'ğüşöçıİĞÜŞÖÇ]+(?:\s+[a-zA-Z'ğüşöçıİĞÜŞÖÇ]+)*$").WithMessage(stringLocalizer["Valid_FirstName"]);

            RuleFor(x => x.LastName).NotEmpty().WithMessage(x => stringLocalizer["LastName_Not_Empty"])
               .MinimumLength(2).WithMessage(x => stringLocalizer["LastName_Minumum_Length"])
               .Matches(@"^(?!'+$)[a-zA-Z'ğüşöçıİĞÜŞÖÇ]+(?:\s+[a-zA-Z'ğüşöçıİĞÜŞÖÇ]+)*$").WithMessage(stringLocalizer["Valid_LastName"]);

            RuleFor(x => x.Email).NotEmpty().WithMessage(stringLocalizer["Empty_Email"])
                .EmailAddress().WithMessage(stringLocalizer["Valid_Email"]);

            RuleFor(x => x.RestourantName).NotEmpty().WithMessage(x => stringLocalizer["Restourant_Not_Empty"]);

            RuleFor(x => x.Address).MaximumLength(512).WithMessage(x => stringLocalizer["Adress_Length"]).When(x => x.Address != null);

            RuleFor(x => x.Image.Length).LessThanOrEqualTo(5242880)
               .WithMessage(x => stringLocalizer["File_Size"]).When(x => x.Image != null);

            RuleFor(x => x.Image.ContentType).Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                .WithMessage(x => stringLocalizer["Correct_Image_File_Type"]).When(x => x.Image != null);

            RuleFor(x => x.Password).NotEmpty().WithMessage(x => stringLocalizer["Empty_Password"])
                .MinimumLength(8).WithMessage(x => stringLocalizer["Password_Minumum_Length"])
                .Equal(x => x.ConfirmPassword).WithMessage(x => stringLocalizer["Password_Control"]);

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage(x => stringLocalizer["Empty_Password"])
                .MinimumLength(8).WithMessage(x => stringLocalizer["Password_Minumum_Length"])
                .Equal(x => x.Password).WithMessage(x => stringLocalizer["Password_Control"]);
        }
    }
}
