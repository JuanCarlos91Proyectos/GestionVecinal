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
            var builder = MauiApp.CreateBuilder();
            builder.UseSharedMauiApp();

            var app = builder.Build();
            return app;
        }
    }
}
