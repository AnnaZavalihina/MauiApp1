using FluentValidation;
using MauiApp1.Models;

namespace MauiApp1.Validators
{
    public class RegistrationValidator : AbstractValidator<RegisterModel>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters long.");
            
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Should be an email address.");
           
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.")
                .When(x => !string.IsNullOrEmpty(x.Password));

            RuleFor(x => x.PasswordRepeat)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
