using FluentValidation;
using MenuApp.MVC.Models.VMs;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Models.FluentValidator.AccountValidators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordVM>
    {
        public ChangePasswordValidator(IStringLocalizer<ChangePasswordVM> stringLocalizer)
        {
            RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage(x => stringLocalizer["Empty_Password"]);

            RuleFor(x => x.NewPassword).NotEmpty().WithMessage(x => stringLocalizer["Empty_Password"])
                .MinimumLength(8).WithMessage(x => stringLocalizer["Password_Minumum_Length"])
                .Equal(x => x.ConfirmPassword).WithMessage(x => stringLocalizer["Password_Control"])
                .NotEqual(x => x.CurrentPassword).WithMessage(x => stringLocalizer["Same_Password"]);

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage(x => stringLocalizer["Empty_Password"])
                .MinimumLength(8).WithMessage(x => stringLocalizer["Password_Minumum_Length"])
                .Equal(x => x.NewPassword).WithMessage(x => stringLocalizer["Password_Control"])
                .NotEqual(x => x.CurrentPassword).WithMessage(x => stringLocalizer["Same_Password"]);

        }
    }
}
