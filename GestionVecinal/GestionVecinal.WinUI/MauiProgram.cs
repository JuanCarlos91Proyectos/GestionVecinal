using GestionVecinal.Models;
using GestionVecinal.Models.ViewModels;
using GestionVecinal.Repositories;
using GestionVecinal.Services;
using GestionVecinal.Services.Interfaces;
using GestionVecinal.Services.Mappers;
using GestionVecinal.Views;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace GestionVecinal.WinUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder()
                .RegisterServices()
                .RegisterRepositories()
                .RegisterViewsAndViewModels()
                .RegisterAutoMapper()
                .AddAppSettings();

            

            builder.UseSharedMauiApp();

            var app = builder.Build();
            return app;
        }

        private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<IComunidadesService, ComunidadesService>();
            builder.Services.AddTransient<ILoginService, LoginService>();
            return builder;
        }

        private static MauiAppBuilder RegisterRepositories(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<IComunidadesRepository, ComunidadesRepository>();
            return builder;
        }

        private static MauiAppBuilder RegisterViewsAndViewModels(this MauiAppBuilder builder)
        {
            
            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<CommunitySelect>();
            builder.Services.AddTransient<MainPage>();


            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<CommunitySelectViewModel>();
            return builder;
        }

        private static MauiAppBuilder RegisterAutoMapper(this MauiAppBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(ComunidadMappingProfile));
            return builder;
        }
        private static MauiAppBuilder AddAppSettings(this MauiAppBuilder builder)
        {
            builder = builder.ConfigureAppSettings("appsettings.json");
            return builder;
        }
        private static MauiAppBuilder ConfigureAppSettings(this MauiAppBuilder builder, string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            using Stream stream = assembly.GetManifestResourceStream($"GestionVecinal.WinUI.{fileName}")
                    ?? throw new ArgumentNullException($"Stream can not be null     on {nameof(ConfigureAppSettings)}");

            var config = new ConfigurationBuilder().AddJsonStream(stream).Build();
            builder.Configuration.AddConfiguration(config);
            
            builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
            builder.Services.AddSingleton<AppSettings>(config.GetSection("AppSettings").Get<AppSettings>());
            return builder;
        }
    }
}
