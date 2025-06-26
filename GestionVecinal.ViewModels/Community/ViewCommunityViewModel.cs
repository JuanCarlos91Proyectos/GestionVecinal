using GestionVecinal.Models;
using GestionVecinal.Models.DTO;
using GestionVecinal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.ViewModels
{
    public partial class ViewCommunityViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private List<DerramaDTO> _derramas = new List<DerramaDTO>();
        
        private List<FacturaDTO> _facturas = new List<FacturaDTO>();

        private List<IncidenciaDTO> _incidencias = new List<IncidenciaDTO>();
        private List<JuntaDTO> _juntas = new List<JuntaDTO>();
        
        
        private List<ProveedorDTO> _proveedores = new List<ProveedorDTO>();

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
        
        
        public List<ProveedorDTO> Proveedores
        {
            get { return _proveedores; }
            set { _proveedores = value; OnPropertyChanged(nameof(Proveedores)); }
        }
        public ViewCommunityViewModel(AppSettings appSettings, IServiceProvider serviceProvider, INavigationService navigationService) : base(appSettings, serviceProvider, navigationService)
        {
        }
    }
}
