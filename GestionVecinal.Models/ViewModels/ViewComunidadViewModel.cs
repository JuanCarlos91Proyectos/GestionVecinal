using GestionVecinal.Models.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Models
{
    public partial class ViewComunidadViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private ComunidadDTO _comunidad = new ComunidadDTO();
        
        private List<DerramaDTO> _derramas = new List<DerramaDTO>();
        
        private List<FacturaDTO> _facturas = new List<FacturaDTO>();

        private List<IncidenciaDTO> _incidencias = new List<IncidenciaDTO>();
        private List<JuntaDTO> _juntas = new List<JuntaDTO>();
        private ObservableCollection<MiembroDTO> _miembros = new ObservableCollection<MiembroDTO>();
        private List<PresidenciaDTO> _presidentes = new List<PresidenciaDTO>();
        private List<ProveedorDTO> _proveedores = new List<ProveedorDTO>();

        public ComunidadDTO Comunidad
        {
            get { return _comunidad; }
            set { _comunidad = value; OnPropertyChanged(nameof(Comunidad)); }
        }
        public List<DerramaDTO> Derramas
        {
            get { return _derramas; }
            set { _derramas = value; OnPropertyChanged(nameof(Derramas)); }
        }
        public List<FacturaDTO> Facturas
        {
            get { return _facturas; }
            set { _facturas = value; OnPropertyChanged(nameof(Facturas)); }
        }
        public List<IncidenciaDTO> Incidencias
        {
            get { return _incidencias; }
            set { _incidencias = value; OnPropertyChanged(nameof(Incidencias)); }
        }
        public List<JuntaDTO> Juntas
        {
            get { return _juntas; }
            set { _juntas = value; OnPropertyChanged(nameof(Juntas)); }
        }
        public ObservableCollection<MiembroDTO> Miembros
        {
            get { return _miembros; }
            set { _miembros = value; OnPropertyChanged(nameof(Miembros)); }
        }
        public List<PresidenciaDTO> Presidentes
        {
            get { return _presidentes; }
            set { _presidentes = value; OnPropertyChanged(nameof(Presidentes)); }
        }
        public List<ProveedorDTO> Proveedores
        {
            get { return _proveedores; }
            set { _proveedores = value; OnPropertyChanged(nameof(Proveedores)); }
        }
        public ViewComunidadViewModel(AppSettings appSettings) : base(appSettings)
        {
        }
    }
}
