using FluentValidation.Results;
using MauiApp1.Models;
using MauiApp1.Models.Messages;
using MauiApp1.Services;
using MauiApp1.Validators;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiApp1.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;
        private readonly RegistrationValidator _validator;
        public event PropertyChangedEventHandler? PropertyChanged;

        private RegisterModel _account = new RegisterModel();

        public RegisterModel Account
        {
            get => _account;
            set
            {
                if (_account != value)
                {
                    _account = value;
                    OnPropertyChanged();
                }
            }
        }

        private ErrorMessage _error = new ErrorMessage();

        public ErrorMessage Error
        {
            get => _error;
            set
            {
                if (_error != value)
                {
                    _error = value;
                    OnPropertyChanged();
                }
            }
        }

        private (bool IsPasswordVisible, bool IsPasswordRepeatVisible) _passwordVisibility = (true, true);
        public (bool IsPasswordVisible, bool IsPasswordRepeatVisible) PasswordVisibility
        {
            get => _passwordVisibility;
            set
            {
                if (_passwordVisibility != value)
                {
                    _passwordVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand RegisterCommand { get; }
        public ICommand GoToLoginCommand { get; }
        public ICommand TogglePasswordVisibilityCommand { get; }
        public ICommand TogglePasswordRepeatVisibilityCommand { get; }


        public RegisterViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            _validator = new RegistrationValidator();

            RegisterCommand = new Command(OnRegistration);
            GoToLoginCommand = new Command(OnGoToLogin);
            TogglePasswordVisibilityCommand = new Command(OnTogglePasswordVisibility);
            TogglePasswordRepeatVisibilityCommand = new Command(OnTogglePasswordRepeatVisibility);

        }

        private async void OnRegistration()
        {
            ValidationResult result = await _validator.ValidateAsync(Account);

            if (!result.IsValid)
            {
                Error.Message = string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
                Error.IsVisible = true;
                OnPropertyChanged(nameof(Error));
                return;
            }

            if (!Account.Password.Equals(Account.PasswordRepeat)) 
            {
                Error.Message = "Repeat password";
                Error.IsVisible = true;
                OnPropertyChanged(nameof(Error));
                return;
            }

            await _navigationService.NavigateToAsync("Home", null);
        }

        private async void OnGoToLogin()
        {
            await _navigationService.NavigateToAsync("Login", null);
        }

        private void OnTogglePasswordVisibility()
        {
            PasswordVisibility = (!PasswordVisibility.IsPasswordVisible, PasswordVisibility.IsPasswordRepeatVisible);
        }
        private void OnTogglePasswordRepeatVisibility()
        {
            PasswordVisibility = (PasswordVisibility.IsPasswordVisible, !PasswordVisibility.IsPasswordRepeatVisible);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
