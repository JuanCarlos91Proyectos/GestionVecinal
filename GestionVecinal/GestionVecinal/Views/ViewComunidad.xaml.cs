using GestionVecinal.Models.DTO;
using GestionVecinal.Models.ViewModels;
using GestionVecinal.Services.Interfaces;
using MauiIcons.Core;
using System.Collections.ObjectModel;

namespace GestionVecinal.Views;

public partial class ViewComunidad : TabbedPage
{
	public ViewComunidadViewModel _viewModel;
    private readonly IComunidadesService _comunidadesService;
    private readonly IDerramasService _derramasService;
    private readonly IIncidenciasService _incidenciasService;
    private readonly IJuntasService _juntasService;
    private readonly IMiembrosService _miembrosService;
    private readonly IProveedoresService _proveedoresService;
    private readonly IFacturasService _facturasService;
    private readonly IPresidenciasService _presidenciasService;

    public ViewComunidad(ViewComunidadViewModel viewModel, 
        IComunidadesService comunidadesService, 
        IDerramasService derramasService, 
        IIncidenciasService incidenciasService, 
        IJuntasService juntasService, 
        IMiembrosService miembrosService, 
        IProveedoresService proveedoresService, 
        IFacturasService facturasService, 
        IPresidenciasService presidenciasService)
    {
        _viewModel = viewModel;
        _comunidadesService = comunidadesService;
        _derramasService = derramasService;
        _incidenciasService = incidenciasService;
        _juntasService = juntasService;
        _miembrosService = miembrosService;
        _proveedoresService = proveedoresService;
        _facturasService = facturasService;
        _presidenciasService = presidenciasService;
        GetDatosComunidad().ConfigureAwait(false);
        InitializeComponent();
        BindingContext = _viewModel;
        _ = new MauiIcon();
    }

    private async Task GetDatosComunidad()
    {
        _viewModel.Derramas = (await _derramasService.GetAsync(_viewModel.Comunidad.Id)).Value;
        _viewModel.Facturas = (await _facturasService.GetAsync(_viewModel.Comunidad.Id)).Value;
        _viewModel.Incidencias = (await _incidenciasService.GetAsync(_viewModel.Comunidad.Id)).Value;
        _viewModel.Juntas = (await _juntasService.GetAsync(_viewModel.Comunidad.Id)).Value;
        var miembros = (await _miembrosService.GetAsync(_viewModel.Comunidad.Id)).Value;
        _viewModel.Miembros = new ObservableCollection<MiembroDTO>(miembros);
        
        _viewModel.Presidentes = (await _presidenciasService.GetAsync(_viewModel.Comunidad.Id)).Value;
        foreach (var miembro in _viewModel.Miembros)
        {
            if (_viewModel.Presidentes.Any(x => x.MiembroId == miembro.Id && x.FechaInicio <= DateTime.Now && x.FechaFin >= DateTime.Now))
                miembro.EsPresidente = true;
        }
        _viewModel.Proveedores = (await _proveedoresService.GetAsync(_viewModel.Comunidad.Id)).Value;
    }

    private void SetMiembrosList()
    {
        foreach(var miembro in _viewModel.Miembros)
        {

        }
    }
}