using GestionVecinal.Models;
using GestionVecinal.Models.ViewModels;
using Microsoft.Extensions.Configuration;

namespace GestionVecinal.Views;

public partial class Login : ContentPage
{
    public readonly LoginViewModel _viewModel;
    public Login(LoginViewModel viewModel)
	{
        _viewModel = viewModel;
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;
        var loginResult = _viewModel.ValidateLogin(username, password);
        if (loginResult.Success)
        {

            var page = _viewModel.serviceProvider.GetService<CommunitySelect>();
            await Navigation.PushAsync(page);
        }
        else
        {
            ErrorMessage.Text = loginResult.Error?.Message;
            ErrorMessage.IsVisible = true;
        }
    }
}