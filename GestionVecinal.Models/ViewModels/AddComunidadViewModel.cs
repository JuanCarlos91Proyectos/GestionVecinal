using GestionVecinal.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Models.ViewModels
{
    public partial class AddComunidadViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private ComunidadDTO _comunidad = new ComunidadDTO();
        public ComunidadDTO Comunidad
        {
            get { return _comunidad; }
            set { _comunidad = value; OnPropertyChanged(nameof(Comunidad)); }
        }
        public AddComunidadViewModel(AppSettings appSettings) : base(appSettings)
        {
        }
    }
}
