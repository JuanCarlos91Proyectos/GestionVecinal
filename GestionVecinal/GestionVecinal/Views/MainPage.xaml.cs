using GestionVecinal.Models;
using GestionVecinal.Services;

namespace GestionVecinal.Views
{
    public partial class MainPage : TabbedPage
    {
        public List<ComunidadDTO> _comunidades;
        private readonly IComunidadesService _comunidadesService;
        public MainPage(IComunidadesService comunidadesService)
        {
            this._comunidades = new List<ComunidadDTO>();
            this._comunidadesService = comunidadesService;
            Task.Run(() => OnStart());
            InitializeComponent();
        }

        private async Task OnStart()
        {
            this._comunidades = await this.GetComunidades();
        }

        private async Task<List<ComunidadDTO>> GetComunidades()
        {
            List<ComunidadDTO> result = await this._comunidadesService.GetComunidades();
            return result;
        }

    }

}
