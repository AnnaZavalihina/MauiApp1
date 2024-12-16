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

            InitializeRouting();
            InitializeComponent();
        }
        private static void InitializeRouting()
        {
            Routing.RegisterRoute("Login", typeof(LoginPage));
            Routing.RegisterRoute("Register", typeof(RegisterPage));
            Routing.RegisterRoute("Home", typeof(HomePage));
            Routing.RegisterRoute("Photo", typeof(PhotoCollectionPage));
        }
    }
}
