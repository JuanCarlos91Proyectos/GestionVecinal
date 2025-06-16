using GestionVecinal.Models.Common;
using GestionVecinal.Models.DTO;
using System.ComponentModel;

namespace GestionVecinal.Models
{
    public partial class EditCommunityMemberViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private MiembroDTO _miembro = new MiembroDTO();
        public MiembroDTO Miembro
        {
            get { return _miembro; }
            set { _miembro = value; OnPropertyChanged(nameof(Miembro)); }
        }
        public string EditCommunityMemberTitle { get; set; }
        public EditCommunityMemberViewModel(AppSettings appSettings) : base(appSettings)
        {
        }
    }
}
