using GestionVecinal.Models.DTO;
using GestionVecinal.Services;
using GestionVecinal.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace GestionVecinal.ViewModels
{
    /// <summary>
    /// ViewModel for managing homes in a community.
    /// </summary>
    public class CommunityHomesViewModel : BaseViewModel
    {
        private ObservableCollection<ViviendaDTO> viviendas = new();
        /// <summary>
        /// List of homes in the community.
        /// </summary>
        public ObservableCollection<ViviendaDTO> Viviendas
        {
            get => viviendas;
            set
            {
                viviendas = value;
                OnPropertyChanged(nameof(Viviendas));
            }
        }

        private int communityId;
        /// <summary>
        /// Community identifier.
        /// </summary>
        public int CommunityId
        {
            get => communityId;
            set
            {
                communityId = value;
                OnPropertyChanged(nameof(CommunityId));
            }
        }

        private readonly IViviendaService _viviendasService;
        private readonly IMiembrosService _miembrosService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunityHomesViewModel"/> class.
        /// </summary>
        /// <param name="appSettings">Application settings.</param>
        /// <param name="serviceProvider">Service provider.</param>
        /// <param name="navigationService">Navigation service.</param>
        /// <param name="viviendasService">Homes service.</param>
        /// <param name="miembrosService">Members service.</param>
        public CommunityHomesViewModel(
            Models.AppSettings appSettings,
            IServiceProvider serviceProvider,
            INavigationService navigationService,
            IViviendaService viviendasService,
            IMiembrosService miembrosService)
            : base(appSettings, serviceProvider, navigationService)
        {
            _viviendasService = viviendasService;
            _miembrosService = miembrosService;
            // _ = InitialLoad();
        }

        /// <summary>
        /// Loads the list of homes for the current community.
        /// </summary>
        public async Task InitialLoad()
        {
            var viviendasList = (await _viviendasService.GetAsync(CommunityId)).Value ?? [];
            var miembrosList = (await _miembrosService.GetAsync(CommunityId)).Value ?? [];

            Viviendas.Clear();
            foreach (var vivienda in viviendasList)
            {
                var miembro = miembrosList.FirstOrDefault(m => m.Id == vivienda.MiembroId);
                vivienda.MiembroId = miembro != null ? miembro.Id : 0;
                Viviendas.Add(vivienda);
            }
        }
    }
}