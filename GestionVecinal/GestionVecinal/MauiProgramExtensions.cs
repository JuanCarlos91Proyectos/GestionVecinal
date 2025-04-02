using GestionVecinal.Models.ViewModels;
using GestionVecinal.Models;
using GestionVecinal.Repositories;
using GestionVecinal.Services.Interfaces;
using GestionVecinal.Services.Mappers;
using GestionVecinal.Services;
using GestionVecinal.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace GestionVecinal
{
    public static class MauiProgramExtensions
    {
        public static MauiAppBuilder UseSharedMauiApp(this MauiAppBuilder builder)
        {
            builder
                .UseMauiApp<App>()
                .RegisterAutoMapper()
                .RegisterServices()
                .RegisterRepositories()
                .RegisterViewsAndViewModels()
                .AddAppSettings()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder;
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
            builder.Services.AddTransient<AddComunidad>();
            //builder.Services.AddTransient<MainPage>();


            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<CommunitySelectViewModel>();
            //builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<AddComunidadViewModel>();
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

            using Stream stream = assembly.GetManifestResourceStream($"GestionVecinal.{fileName}")
                    ?? throw new ArgumentNullException($"Stream can not be null on {nameof(ConfigureAppSettings)}");

            IConfigurationRoot config = new ConfigurationBuilder().AddJsonStream(stream).Build();
            builder.Configuration.AddConfiguration(config);

            builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
            builder.Services.AddSingleton<AppSettings>(config.GetSection("AppSettings").Get<AppSettings>());
            return builder;
        }
    }
}
