using GestionVecinal.Models;
using GestionVecinal.Models.Common;
using GestionVecinal.Models.DTO;
using GestionVecinal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.ViewModels
{
    public partial class AddCommunityViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private ComunidadDTO _comunidad = new ComunidadDTO();
        private IComunidadesService _service;
        public ComunidadDTO Comunidad
        {
            get { return _comunidad; }
            set { _comunidad = value; OnPropertyChanged(nameof(Comunidad)); }
        }
        public AddCommunityViewModel(AppSettings appSettings,
            IComunidadesService service,
            IServiceProvider serviceProvider, 
            INavigationService navigationService) 
            : base(appSettings, serviceProvider, navigationService)
        {
            _service = service;
        }

        public async Task<Response<bool>> AddCommunityAsync()
            => await _service.AddAsync(Comunidad);
    }
}
