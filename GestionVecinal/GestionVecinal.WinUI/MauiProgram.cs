namespace GestionVecinal.WinUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseSharedMauiApp();

            var app = builder.Build();
            return app;
        }
    }
}
