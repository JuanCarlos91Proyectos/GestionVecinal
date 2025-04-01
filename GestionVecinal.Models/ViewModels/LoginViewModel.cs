using GestionVecinal.Models.Common;
using System.ComponentModel;

namespace GestionVecinal.Models.ViewModels
{
    public partial class LoginViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public LoginViewModel(AppSettings appSettings) : base(appSettings)
        {
        }

        public Response<bool> ValidateLogin(string username, string password)
        {
            var response = new Response<bool>();
            if (username == AppSettings.Admin && password == AppSettings.Password)
            {
                response.setValue(true, true, string.Empty);
            }
            else
            {
                response.setError(AppSettings.Errors.Login, string.Empty);
            }
            return response;
        }
    }
}
