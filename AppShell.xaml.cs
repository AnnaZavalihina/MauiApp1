using MauiApp1.Services;
using MauiApp1.Views;

namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        private readonly INavigationService _navigationService;

        public AppShell(INavigationService navigationService)
        {
            _navigationService = navigationService;

            InitializeComponent();
            _ = InitializeAsync(); 
        }

        private async Task InitializeAsync()
        {
            await _navigationService.NavigateToAsync("Login");
        }
    }
}
