using GestionVecinal.Models.DTO;
using GestionVecinal.Services;
using GestionVecinal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.ViewModels
{
    public class PresidentsListViewModel : BaseViewModel
    {
        private List<PresidenciaDTO> _presidentes = new List<PresidenciaDTO>();
        public List<PresidenciaDTO> Presidentes
        {
            get { return _presidentes; }
            set { _presidentes = value; OnPropertyChanged(nameof(Presidentes)); }
        }
        private int _communityId;
        public int CommunityId
        {
            get { return _communityId; }
            set { _communityId = value; OnPropertyChanged(nameof(CommunityId)); }
        }

        private readonly IPresidenciasService _presidenciasService;
        public PresidentsListViewModel(Models.AppSettings appSettings, 
            IServiceProvider serviceProvider, 
            INavigationService navigationService,
            IPresidenciasService presidenciasService) 
            : base(appSettings, serviceProvider, navigationService)
        {
            _presidenciasService = presidenciasService;
            _ = InitialLoad();
        }

        public async Task InitialLoad()
        {
            var presidentes = (await _presidenciasService.GetAsync(CommunityId)).Value ?? [];
            Presidentes = presidentes;
        }
    }
}
