using GestionVecinal.Models.Common;
using System.ComponentModel;

namespace GestionVecinal.Models.ViewModels
{
    public partial class LoginViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public LoginViewModel(IServiceProvider serviceProvider, AppSettings appSettings) : base(serviceProvider, appSettings)
        {
        }

        public Response<bool> ValidateLogin(string username, string password)
        {
            var response = new Response<bool>();
            if (username == _appSettings.Admin && password == _appSettings.Password)
            {
                response.setValue(true, true, string.Empty);
            }
            else
            {
                response.setError(_appSettings.Errors.Login, string.Empty);
            }
            return response;
        }
    }
}
