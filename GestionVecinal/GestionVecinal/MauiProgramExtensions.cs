using GestionVecinal.Models;
using GestionVecinal.Repositories;
using GestionVecinal.Services.Interfaces;
using GestionVecinal.Services.Mappers;
using GestionVecinal.Services;
using GestionVecinal.Views;
using GestionVecinal.ViewModels;
using GestionVecinal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using MauiIcons.Fluent;
using MauiIcons.Material;
using MauiIcons.Cupertino;
using System.Globalization;

namespace GestionVecinal
{
    public static class MauiProgramExtensions
    {
        public static MauiAppBuilder UseSharedMauiApp(this MauiAppBuilder builder)
        {
            builder
                .UseMauiApp<App>()
                // Initialises the .Net Maui Icons - Fluent
                .UseFluentMauiIcons()
                // Initialises the .Net Maui Icons - Material
                .UseMaterialMauiIcons()
                // Initialises the .Net Maui Icons - Cupertino
                .UseCupertinoMauiIcons()
                .RegisterAutoMapper()
                .RegisterServices()
                .RegisterRepositories()
                .RegisterViewsAndViewModels()
                .AddAppSettings()
                .ApplyDefaultLanguage()
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

        private static MauiAppBuilder ApplyDefaultLanguage(this MauiAppBuilder builder)
        {
            var cultureESP = new CultureInfo("es-ES");
            var cultureENG = new CultureInfo("en-US");
            var systemCulture = CultureInfo.CurrentCulture;
            CultureInfo.DefaultThreadCurrentCulture = systemCulture.TwoLetterISOLanguageName == "es" ? cultureESP : cultureENG;
            CultureInfo.DefaultThreadCurrentUICulture = systemCulture.TwoLetterISOLanguageName == "es" ? cultureESP : cultureENG;
            return builder;
        }

        

        private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IAddCommunityWindowService, AddCommunityWindowService>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddTransient<IComunidadesService, ComunidadesService>();
            builder.Services.AddTransient<ILoginService, LoginService>();
            builder.Services.AddTransient<IDerramasService, DerramasService>();
            builder.Services.AddTransient<IPagosService, PagosService>();
            builder.Services.AddTransient<IProveedoresService, ProveedoresService>();
            builder.Services.AddTransient<IFacturasService, FacturasService>();
            builder.Services.AddTransient<IIncidenciasService, IncidenciasService>();
            builder.Services.AddTransient<IJuntasService, JuntasService>();
            builder.Services.AddTransient<IMiembrosService, MiembrosService>();
            builder.Services.AddTransient<IPresidenciasService, PresidenciasService>();
            return builder;
        }

        private static MauiAppBuilder RegisterRepositories(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<IComunidadesRepository, ComunidadesRepository>();
            builder.Services.AddTransient<IDerramasRepository, DerramasRepository>();
            builder.Services.AddTransient<IPagosRepository, PagosRepository>();
            builder.Services.AddTransient<IProveedoresRepository, ProveedoresRepository>();
            builder.Services.AddTransient<IFacturasRepository, FacturasRepository>();
            builder.Services.AddTransient<IIncidenciasRepository, IncidenciasRepository>();
            builder.Services.AddTransient<IJuntasRepository, JuntasRepository>();
            builder.Services.AddTransient<IMiembrosRepository, MiembrosRepository>();
            builder.Services.AddTransient<IPresidenciasRepository, PresidenciasRepository>();
            builder.Services.AddTransient<IProveedoresRepository, ProveedoresRepository>();
            return builder;
        }

        private static MauiAppBuilder RegisterViewsAndViewModels(this MauiAppBuilder builder)
        {

            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<CommunitySelect>();
            builder.Services.AddTransient<AddCommunity>();
            builder.Services.AddTransient<ViewComunidad>();
            builder.Services.AddTransient<EditCommunityMember>();


            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<CommunitySelectViewModel>();
            builder.Services.AddTransient<AddCommunityViewModel>();
            builder.Services.AddTransient<ViewComunidadViewModel>();
            builder.Services.AddTransient<EditCommunityMemberViewModel>();
            return builder;
        }

        private static MauiAppBuilder RegisterAutoMapper(this MauiAppBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(ComunidadMappingProfile));
            builder.Services.AddAutoMapper(typeof(ProveedorMappingProfile));
            builder.Services.AddAutoMapper(typeof(FacturaMappingProfile));
            builder.Services.AddAutoMapper(typeof(IncidenciaMappingProfile));
            builder.Services.AddAutoMapper(typeof(JuntaMappingProfile));
            builder.Services.AddAutoMapper(typeof(MiembroMappingProfile));
            builder.Services.AddAutoMapper(typeof(PresidenciaMappingProfile));
            builder.Services.AddAutoMapper(typeof(ProveedorMappingProfile));
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
            //AppSettings appSettings = ApplyAppSettingsMessages(config.GetSection("AppSettings").Get<AppSettings>() ?? new AppSettings());
            AppSettings appSettings = config.GetSection("AppSettings").Get<AppSettings>() ?? new AppSettings();
            builder.Services.AddSingleton<AppSettings>(appSettings);
            return builder;
        }
    }
}
