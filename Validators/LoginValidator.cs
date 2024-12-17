using FluentValidation;
using MauiApp1.Models;

namespace MauiApp1.Validators
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Login is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
