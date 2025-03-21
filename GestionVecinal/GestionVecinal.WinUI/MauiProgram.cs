using GestionVecinal.Repositories;
using GestionVecinal.Services;
using GestionVecinal.Services.Mappers;
using GestionVecinal.Views;

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

            builder
                .UseSharedMauiApp();

            var app = builder.Build();
            return app;
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<IComunidadesService, ComunidadesService>();
            return builder;
        }

        public static MauiAppBuilder RegisterRepositories(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<IComunidadesRepository, ComunidadesRepository>();
            return builder;
        }

        public static MauiAppBuilder RegisterViewsAndPages(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<CommunitySelect>();
            return builder;
        }

        public static MauiAppBuilder RegisterAutoMapper(this MauiAppBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(ComunidadMappingProfile));
            return builder;
        }
    }
}
