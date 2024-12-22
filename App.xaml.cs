using MauiApp1.Services;

namespace MauiApp1
{
    public partial class App : Application
    {

        public App(INavigationService navigationService)
        {
            InitializeComponent();

            MainPage = new AppShell(navigationService);
        }
    }
}
