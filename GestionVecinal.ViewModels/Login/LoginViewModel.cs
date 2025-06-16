using GestionVecinal.Models;
using GestionVecinal.Models.Common;
using GestionVecinal.Services;
using GestionVecinal.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows.Input;

namespace GestionVecinal.ViewModels.Login
{
    public partial class LoginViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private string _username;
        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        private readonly ILoginService _loginService;

        public ICommand LoginCommand { get; }
        public LoginViewModel(AppSettings appSettings, ILoginService loginService, IServiceProvider serviceProvider, INavigationService navigationService) : base(appSettings, serviceProvider, navigationService)
        {
            _loginService = loginService;
            LoginCommand = new Command(async () => await LoginAsync());
        }

        private async Task LoginAsync()
        {
            string username = Username;
            string password = Password;
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
            // Ejemplo simple
            await _navigationService.GoToAsync("CommunitySelect");

            // O con parámetros
            // await _navigationService.GoToAsync("communityselect", new Dictionary<string, object> { ["UserId"] = 123 });
        }

    }
}
