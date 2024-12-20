using MauiApp1.Services;

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
            await _navigationService.NavigateToAsync("///Login");
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            // Clear any user session or authentication tokens
            // e.g., Preferences.Clear("UserToken");

            // Redirect to LoginPage and reset navigation stack
            await _navigationService.NavigateToAsync("///Login");
        }
    }
}
