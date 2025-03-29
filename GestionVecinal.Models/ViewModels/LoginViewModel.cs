using GestionVecinal.Models.Common;
using System.ComponentModel;

namespace GestionVecinal.Models.ViewModels
{
    public partial class LoginViewModel : INotifyPropertyChanged
    {
        public readonly AppSettings appSettings;
        public readonly IServiceProvider serviceProvider;
        public event PropertyChangedEventHandler? PropertyChanged;

        public LoginViewModel(IServiceProvider serviceProvider, AppSettings appSettings)
        {
            this.serviceProvider = serviceProvider;
            this.appSettings = appSettings;
        }

        public Response<bool> ValidateLogin(string username, string password)
        {
            var response = new Response<bool>();
            if (username == appSettings.Admin && password == appSettings.Password)
            {
                response.setValue(true, true, string.Empty);
            }
            else
            {
                response.setError(appSettings.Errors.Login, string.Empty);
            }
            return response;
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
