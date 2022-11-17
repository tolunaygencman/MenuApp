using FluentValidation;
using MenuApp.MVC.Models.VMs;
using Microsoft.Extensions.Localization;

namespace MenuApp.MVC.Models.FluentValidator.LoginValidators
{
    public class LoginValidator : AbstractValidator<LoginVM>
    {
        public LoginValidator(IStringLocalizer<LoginVM> stringLocalizer)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(x => stringLocalizer["Empty_Email"])
                .EmailAddress().WithMessage(stringLocalizer["Valid_Email"]);

            RuleFor(x => x.Password).NotEmpty().WithMessage(x => stringLocalizer["Empty_Password"]);
        }
    }
}
