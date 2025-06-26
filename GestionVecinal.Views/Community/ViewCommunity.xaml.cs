using GestionVecinal.Models.DTO;
using GestionVecinal.Models;
using GestionVecinal.Services.Interfaces;
using MauiIcons.Core;
using System.Collections.ObjectModel;
using GestionVecinal.ViewModels;

namespace GestionVecinal.Views;

public partial class ViewCommunity : TabbedPage, IQueryAttributable
{
    //public ViewComunidadViewModel _viewModel;
    //   private readonly IComunidadesService _comunidadesService;
    //   private readonly IDerramasService _derramasService;
    //   private readonly IIncidenciasService _incidenciasService;
    //   private readonly IJuntasService _juntasService;
    //   private readonly IMiembrosService _miembrosService;
    //   private readonly IProveedoresService _proveedoresService;
    //   private readonly IFacturasService _facturasService;
    //   private readonly IPresidenciasService _presidenciasService;
    //   private readonly IServiceProvider _serviceProvider;

    //public ViewComunidad(ViewComunidadViewModel viewModel, 
    //    IComunidadesService comunidadesService, 
    //    IDerramasService derramasService, 
    //    IIncidenciasService incidenciasService, 
    //    IJuntasService juntasService, 
    //    IMiembrosService miembrosService, 
    //    IProveedoresService proveedoresService, 
    //    IFacturasService facturasService, 
    //    IPresidenciasService presidenciasService,
    //    IServiceProvider serviceProvider)
    //{
    //    _viewModel = viewModel;
    //    _comunidadesService = comunidadesService;
    //    _derramasService = derramasService;
    //    _incidenciasService = incidenciasService;
    //    _juntasService = juntasService;
    //    _miembrosService = miembrosService;
    //    _proveedoresService = proveedoresService;
    //    _facturasService = facturasService;
    //    _presidenciasService = presidenciasService;
    //    _serviceProvider = serviceProvider;
    //    GetDatosComunidad().ConfigureAwait(false);
    //    InitializeComponent();
    //    BindingContext = _viewModel;
    //    _ = new MauiIcon();
    //}

    //private async Task GetDatosComunidad()
    //{
    //    _viewModel.Derramas = (await _derramasService.GetAsync(_viewModel.Comunidad.Id)).Value;
    //    _viewModel.Facturas = (await _facturasService.GetAsync(_viewModel.Comunidad.Id)).Value;
    //    _viewModel.Incidencias = (await _incidenciasService.GetAsync(_viewModel.Comunidad.Id)).Value;
    //    _viewModel.Juntas = (await _juntasService.GetAsync(_viewModel.Comunidad.Id)).Value;
    //    var miembros = (await _miembrosService.GetAsync(_viewModel.Comunidad.Id)).Value;
    //    _viewModel.Miembros = new ObservableCollection<MiembroDTO>(miembros);

    //    _viewModel.Presidentes = (await _presidenciasService.GetAsync(_viewModel.Comunidad.Id)).Value;
    //    foreach (var miembro in _viewModel.Miembros)
    //    {
    //        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
    //        if (_viewModel.Presidentes.Any(x => x.MiembroId == miembro.Id && x.FechaInicio <= today && x.FechaFin >= today))
    //            miembro.EsPresidente = true;
    //    }
    //    _viewModel.Proveedores = (await _proveedoresService.GetAsync(_viewModel.Comunidad.Id)).Value;
    //}

    //private void HandleEditCommunityMember(object sender, TappedEventArgs e)
    //{
    //    var icon = (MauiIcon)sender;
    //    var memberId = icon.ClassId;
    //    // Aquí puedes agregar la lógica para manejar el evento de clic, por ejemplo, navegar a una página de edición
    //    Console.WriteLine($"Icono de edición clicado para el miembro con ID: {memberId}");
    //    var page = _serviceProvider.GetService<EditCommunityMember>();
    //    page._viewModel.Miembro = _viewModel.Miembros.FirstOrDefault(x => x.Id == int.Parse(memberId));
    //    page._viewModel.EditCommunityMemberTitle= $"Editando miembro Piso {page._viewModel.Miembro.Piso} {page._viewModel.Miembro.Puerta} - {page._viewModel.Miembro.Nombre}";
    //    var window = new Window(page);
    //    window.Destroying += OnCloseEditCommunityMember;

    //    Application.Current?.OpenWindow(window);
    //}

    //private void OnCloseEditCommunityMember(object sender, EventArgs e)
    //{
    //    _ = GetDatosComunidad();
    //}
    private ViewCommunityViewModel _vm;
    public ViewCommunity(ViewCommunityViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _vm = viewModel;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("community", out var communityObj) && communityObj is ComunidadDTO community)
        {
           
            CommunityConfigViewModel communityConfigViewModel = _vm._serviceProvider.GetService<CommunityConfigViewModel>();
            this.Children.Add(new CommunityConfig(community, communityConfigViewModel));
            CommunityMembersViewModel communityMembersViewModel = _vm._serviceProvider.GetService<CommunityMembersViewModel>();
            this.Children.Add(new CommunityMembers(communityMembersViewModel, community.Id));
            PresidentsListViewModel presidentsListViewModel = _vm._serviceProvider.GetService<PresidentsListViewModel>();
            this.Children.Add(new PresidentsList(presidentsListViewModel, community.Id));
            // Ahora puedes usar "usuario" y pasarlo a las páginas hijas
            //var home = new HomePage(usuario);
            //var settings = new SettingsPage();

            //this.Children.Add(home);
            //this.Children.Add(settings);
        }
    }
}