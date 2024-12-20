namespace MauiApp1.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync(string pageName, IDictionary<string, object>? routeParameters = null);
        Task GoBackAsync();
    }
}
