using GestionVecinal.Models.Common;
using System.ComponentModel;

namespace GestionVecinal.Models.ViewModels
{
    public partial class EditCommunityMemberViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public EditCommunityMemberViewModel(AppSettings appSettings) : base(appSettings)
        {
        }
    }
}
