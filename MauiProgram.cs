using FluentValidation;
using MauiApp1.Data;
using MauiApp1.Models.Response;
using MauiApp1.Services;
using MauiApp1.Validators;
using MauiApp1.ViewModels;
using MauiApp1.Views;
using Microsoft.Extensions.Logging;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        => MauiApp
            .CreateBuilder()
            .UseMauiApp<App>()
            .ConfigureFonts(
                fonts =>
                {
                    fonts.AddFont("PlaywriteDEVAGuides-Regular.ttf", "CustomRegular");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
            .RegisterAppServices()
            .RegisterViewModels()
            .RegisterViews()
            .Build();

        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<INavigationService, NavigationService>();
            mauiAppBuilder.Services.AddSingleton<DbService>();

#if DEBUG
            mauiAppBuilder.Logging.AddDebug();
#endif

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<RegisterViewModel>();
            mauiAppBuilder.Services.AddSingleton<LoginViewModel>();

            mauiAppBuilder.Services.AddSingleton<PhotoCollectionViewModel>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<LoginPage>();
            mauiAppBuilder.Services.AddTransient<RegisterPage>();

            mauiAppBuilder.Services.AddTransient<PhotoCollectionPage>();

            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterValidators(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<IValidator<LoginModel>, LoginValidator>();
            mauiAppBuilder.Services.AddTransient<IValidator<RegisterModel>, RegistrationValidator>();

            return mauiAppBuilder;
        }
    }
}