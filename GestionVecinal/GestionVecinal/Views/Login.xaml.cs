using GestionVecinal.Models;
using GestionVecinal.Models.ViewModels;
using GestionVecinal.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace GestionVecinal.Views;

public partial class Login : ContentPage
{
    public readonly LoginViewModel _viewModel;
    private readonly ILoginService _loginService;
    private readonly IServiceProvider _serviceProvider;
    public Login(LoginViewModel viewModel, ILoginService loginService, IServiceProvider serviceProvider)
	{
        _viewModel = viewModel;
        _loginService = loginService;
        _serviceProvider = serviceProvider;
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;
        var loginResult = _loginService.ValidateLogin(username, password);
        if (!loginResult.Success)
        {
            ShowErrorMessage(loginResult.Error?.Message ?? "");
            return;
        }
        await GoToCommunitySelect();
    }

    private async Task GoToCommunitySelect()
    {
        var page = _serviceProvider.GetService<CommunitySelect>();
        await Navigation.PushAsync(page);
    }

    private void ShowErrorMessage(string errorMessage)
    {
        ErrorMessage.Text = errorMessage;
        ErrorMessage.IsVisible = true;
    }
}