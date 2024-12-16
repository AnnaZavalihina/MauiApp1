namespace MauiApp1.Services
{
    public class NavigationService : INavigationService
    {
        public Task InitializeAsync() =>
        NavigateToAsync( "//Login");

        public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
        {
            var shellNavigation = new ShellNavigationState(route);

            return routeParameters != null
                ? Shell.Current.GoToAsync(shellNavigation, routeParameters)
                : Shell.Current.GoToAsync(shellNavigation);
        }

        public Task GoBackAsync() =>
            Shell.Current.GoToAsync("..");
    }
}
