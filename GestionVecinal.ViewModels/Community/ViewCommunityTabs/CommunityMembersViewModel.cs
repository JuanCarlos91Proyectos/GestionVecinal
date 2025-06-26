using GestionVecinal.Models.DTO;
using GestionVecinal.Services;
using GestionVecinal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.ViewModels
{
    public class CommunityMembersViewModel : BaseViewModel
    {
        private ObservableCollection<MiembroDTO> _miembros = new ObservableCollection<MiembroDTO>();
        public ObservableCollection<MiembroDTO> Miembros
        {
            get { return _miembros; }
            set { _miembros = value; OnPropertyChanged(nameof(Miembros)); }
        }
        private int _communityId;
        public int CommunityId
        {
            get { return _communityId; }
            set { _communityId = value; OnPropertyChanged(nameof(CommunityId)); }
        }
        private readonly IMiembrosService _miembrosService;
        private readonly IPresidenciasService _presidenciasService;
        public CommunityMembersViewModel(Models.AppSettings appSettings, 
            IServiceProvider serviceProvider, 
            INavigationService navigationService,
            IMiembrosService miembrosService,
             IPresidenciasService presidenciasService)
            : base(appSettings, serviceProvider, navigationService)
        {
            _miembrosService = miembrosService;
            _presidenciasService = presidenciasService;
            _ = InitialLoad();
        }

        public async Task InitialLoad()
        {
            var miembros = (await _miembrosService.GetAsync(CommunityId)).Value ?? [];
            var presidentes = (await _presidenciasService.GetAsync(CommunityId)).Value ?? [];
            foreach (var miembro in miembros)
            {
                DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                if (presidentes.Any(x => x.MiembroId == miembro.Id && x.FechaInicio <= today && x.FechaFin >= today))
                    miembro.EsPresidente = true;
                Miembros.Add(miembro);
            }
        }
    }
}
