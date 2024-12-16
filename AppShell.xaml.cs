using MauiApp1.Services;

namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        private readonly INavigationService _navigationService;

        public AppShell(INavigationService navigationService)
        {
            _navigationService = navigationService;

            AppShell.InitializeRouting();
            InitializeComponent();
        }
        private static void InitializeRouting()
        {
            Routing.RegisterRoute("Login", typeof(LoginPage));
            Routing.RegisterRoute("Register", typeof(RegisterPage));
            Routing.RegisterRoute("Home", typeof(HomePage));
        }
    }
}
