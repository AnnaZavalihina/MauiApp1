using MauiApp1.Services;

namespace MauiApp1
{
    public partial class App : Application
    {
        private readonly INavigationService _navigationService;

        public App(INavigationService navigationService)
        {
            _navigationService = navigationService;

            InitializeComponent();

            MainPage = new AppShell(navigationService);  
            _navigationService.InitializeAsync();
        }
    }
}
