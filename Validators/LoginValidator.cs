using FluentValidation;
using MauiApp1.Models;

namespace MauiApp1.Validators
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Login is required.")
                .MinimumLength(3).WithMessage("Login must be at least 3 characters long.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")  
                .Matches("[0-9]").WithMessage("Password must contain at least one digit.")  
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.")  
                .When(x => !string.IsNullOrEmpty(x.Password)); 
        }
    }
}
