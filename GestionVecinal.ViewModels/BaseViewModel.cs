using GestionVecinal.Models;
using GestionVecinal.Services.Interfaces;
using System.ComponentModel;

namespace GestionVecinal.ViewModels
{
    public partial class BaseViewModel : INotifyPropertyChanged
    {
        private AppSettings _appSettings;
        public AppSettings AppSettings
        {
            get { return _appSettings; }
            set { _appSettings = value; OnPropertyChanged(nameof(AppSettings)); }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }

        private bool _errorMessageVisible;
        public bool ErrorMessageVisible
        {
            get => _errorMessageVisible;
            set { _errorMessageVisible = value; OnPropertyChanged(nameof(ErrorMessageVisible)); }
        }

        

        public event PropertyChangedEventHandler? PropertyChanged;
        public readonly IServiceProvider _serviceProvider;
        public readonly INavigationService _navigationService;

        public BaseViewModel(AppSettings appSettings, IServiceProvider serviceProvider, INavigationService navigationService)
        {
            this._appSettings = appSettings;
            this._serviceProvider = serviceProvider;
            this._navigationService = navigationService;
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ShowErrorMessage(string errorMessage)
        {
            _errorMessage = errorMessage;
            _errorMessageVisible = true;
        }

        public void HideErrorMessage()
        {
            _errorMessage = string.Empty;
            _errorMessageVisible = false;
        }
    }
}
