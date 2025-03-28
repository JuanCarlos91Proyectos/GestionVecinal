using GestionVecinal.Models;
using Microsoft.Extensions.Configuration;

namespace GestionVecinal.Views;

public partial class Login : ContentPage
{
    private readonly IServiceProvider _serviceProvider;
    private readonly AppSettings _appSettings;
    public Login(IServiceProvider serviceProvider, AppSettings appSettings)
	{
        _serviceProvider = serviceProvider;
        _appSettings = appSettings;
        InitializeComponent();
	}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        // Aqu� puedes agregar la l�gica para validar el usuario y contrase�a
        if (username == "admin" && password == "1234") // Ejemplo b�sico
        {

            var page = _serviceProvider.GetService<CommunitySelect>();
            await Navigation.PushAsync(page);
        }
        else
        {
            ErrorMessage.Text = "Usuario o contrase�a incorrectos";
            ErrorMessage.IsVisible = true;
        }
    }
}