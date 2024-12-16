namespace MauiApp1.Services
{
    public interface INavigationService
    {
        Task InitializeAsync();
        Task NavigateToAsync(string pageName, IDictionary<string, object>? routeParameters);
        Task GoBackAsync();
    }
}
