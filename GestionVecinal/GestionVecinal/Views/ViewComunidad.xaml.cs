using GestionVecinal.Models.ViewModels;
using GestionVecinal.Services.Interfaces;

namespace GestionVecinal.Views;

public partial class ViewComunidad : TabbedPage
{
	public ViewComunidadViewModel _viewModel;
    private readonly IComunidadesService _comunidadesService;
    public ViewComunidad(ViewComunidadViewModel viewModel, IComunidadesService comunidadesService)
	{
		_viewModel = viewModel;
        _comunidadesService = comunidadesService;
        GetDatosComunidad().ConfigureAwait(false);
        InitializeComponent();
        BindingContext = _viewModel;
    }

    private async Task GetDatosComunidad()
    {
        _viewModel.Derramas = (await _comunidadesService.GetDerramasAsync(_viewModel.Comunidad.Id)).Value;
        _viewModel.Facturas = (await _comunidadesService.GetFacturasAsync(_viewModel.Comunidad.Id)).Value;
        _viewModel.Incidencias = (await _comunidadesService.GetIncidenciasAsync(_viewModel.Comunidad.Id)).Value;
        _viewModel.Juntas = (await _comunidadesService.GetJuntasAsync(_viewModel.Comunidad.Id)).Value;
        _viewModel.Miembros = (await _comunidadesService.GetMiembrosAsync(_viewModel.Comunidad.Id)).Value;
        
        _viewModel.Presidentes = (await _comunidadesService.GetPresidentesAsync(_viewModel.Comunidad.Id)).Value;
        foreach (var miembro in _viewModel.Miembros)
        {
            if (_viewModel.Presidentes.Any(x => x.MiembroId == miembro.Id && x.FechaInicio <= DateTime.Now && x.FechaFin >= DateTime.Now))
                miembro.EsPresidente = true;
        }
        _viewModel.Proveedores = (await _comunidadesService.GetProveedoresAsync(_viewModel.Comunidad.Id)).Value;
    }
}