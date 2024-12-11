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
    public class LoginViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private readonly LoginValidator _validator;

        private LoginModel _account = new LoginModel();

        public LoginModel Account
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

        private bool _isPassword = true;
        public bool IsPassword
        {
            get => _isPassword;
            set
            {
                if (_isPassword != value)
                {
                    _isPassword = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand GoToRegisterCommand { get; }
        public ICommand TogglePasswordVisibilityCommand { get; }

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            _validator = new LoginValidator();

            LoginCommand = new Command(OnLogin);
            GoToRegisterCommand = new Command(OnGoToRegister);
            TogglePasswordVisibilityCommand = new Command(OnTogglePasswordVisibility);
        }

        private async void OnLogin()
        {
            ValidationResult result = await _validator.ValidateAsync(Account);

            if (!result.IsValid)
            {
                Error.Message = result.Errors.Select(x=>x.ErrorMessage).FirstOrDefault();
                Error.IsVisible = true;
                OnPropertyChanged(nameof(Error));
                return;
            }
            await _navigationService.NavigateToAsync("Home", null);
        }

        private async void OnGoToRegister()
        {
            await _navigationService.NavigateToAsync("Register", null);
        }

        private void OnTogglePasswordVisibility()
        {
            IsPassword = !IsPassword;
        }
    }
}
