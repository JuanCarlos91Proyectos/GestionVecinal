using GestionVecinal.Models;
using GestionVecinal.Repositories;
using GestionVecinal.Services;
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
                .RegisterViewsAndPages()
                .RegisterAutoMapper();

            builder.AddAppSettings();

            

            builder.UseSharedMauiApp();

            var app = builder.Build();
            return app;
        }

        private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<IComunidadesService, ComunidadesService>();
            return builder;
        }

        private static MauiAppBuilder RegisterRepositories(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<IComunidadesRepository, ComunidadesRepository>();
            return builder;
        }

        private static MauiAppBuilder RegisterViewsAndPages(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<CommunitySelect>();
            return builder;
        }

        private static MauiAppBuilder RegisterAutoMapper(this MauiAppBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(ComunidadMappingProfile));
            return builder;
        }
        private static void AddAppSettings(this MauiAppBuilder builder)
        {
            builder.ConfigureAppSettings("appsettings.json");
        }
        private static void ConfigureAppSettings(this MauiAppBuilder builder, string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            using Stream stream = assembly.GetManifestResourceStream($"GestionVecinal.WinUI.{fileName}")
                    ?? throw new ArgumentNullException($"Stream can not be null     on {nameof(ConfigureAppSettings)}");

            var config = new ConfigurationBuilder().AddJsonStream(stream).Build();
            builder.Configuration.AddConfiguration(config);
            
            builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
            builder.Services.AddSingleton<AppSettings>(config.GetSection("AppSettings").Get<AppSettings>());
        }
    }
}
