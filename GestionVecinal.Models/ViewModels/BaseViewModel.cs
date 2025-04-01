using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Models.ViewModels
{
    public partial class BaseViewModel : INotifyPropertyChanged
    {
        public AppSettings _appSettings;
        public AppSettings appSettings
        {
            get { return _appSettings; }
            set
            {
                _appSettings = value;
                OnPropertyChanged(nameof(appSettings));
            }
        }
        public readonly IServiceProvider serviceProvider;

        public event PropertyChangedEventHandler? PropertyChanged;

        public BaseViewModel(IServiceProvider serviceProvider, AppSettings appSettings)
        {
            this.serviceProvider = serviceProvider;
            this._appSettings = appSettings;
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
