using GestionVecinal.Models.Common;
using System.ComponentModel;

namespace GestionVecinal.Models.ViewModels
{
    public partial class LoginViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public LoginViewModel(AppSettings appSettings) : base(appSettings)
        {
        }
    }
}
