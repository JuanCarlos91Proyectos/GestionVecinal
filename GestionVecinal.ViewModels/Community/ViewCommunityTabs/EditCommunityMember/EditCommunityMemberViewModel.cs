using GestionVecinal.Models;
using GestionVecinal.Models.DTO;
using GestionVecinal.Services.Interfaces;
using System.ComponentModel;

namespace GestionVecinal.ViewModels
{
    public partial class EditCommunityMemberViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private MiembroDTO _member = new();
        public MiembroDTO Member
        {
            get { return _member; }
            set { _member = value; OnPropertyChanged(nameof(Member)); }
        }
        public string EditCommunityMemberTitle { get; set; }
        public EditCommunityMemberViewModel(AppSettings appSettings, IServiceProvider serviceProvider, INavigationService navigationService) : base(appSettings, serviceProvider, navigationService)
        {
        }
    }
}
