using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Models
{
    public partial class BaseViewModel : INotifyPropertyChanged
    {
        private AppSettings _appSettings;
        public AppSettings AppSettings
        {
            get { return _appSettings; }
            set { _appSettings = value; OnPropertyChanged(nameof(AppSettings)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public BaseViewModel(AppSettings appSettings)
        {
            this._appSettings = appSettings;
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
