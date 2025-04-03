using GestionVecinal.Models.DTO;
using GestionVecinal.Models.ViewModels;
using GestionVecinal.Services.Interfaces;

namespace GestionVecinal.Views;

public partial class CommunitySelect : ContentPage
{
    private readonly IComunidadesService _comunidadesService;
    public readonly CommunitySelectViewModel _viewModel;
    private readonly IServiceProvider _serviceProvider;
    public CommunitySelect(IComunidadesService comunidadesService, CommunitySelectViewModel viewModel, IServiceProvider serviceProvider)
    {
        this._comunidadesService = comunidadesService;
        this._serviceProvider = serviceProvider;
        _viewModel = viewModel;
        OnStart().ConfigureAwait(false);
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async Task OnStart()
    {
        _viewModel.Comunidades = await this.GetComunidades();
        foreach (var comunidad in _viewModel.Comunidades)
        {
            Button comunidadButton = _viewModel.AddCommunityButton(comunidad);
            comunidadButton.Clicked += HandleViewComunidad;
            this.ComunidadesPicker.Children.Add(comunidadButton);
        }
        Button newCommunityButton = _viewModel.AddNewCommunityButton();
        newCommunityButton.Clicked += HandleAddNewCommunity;
        this.ComunidadesPicker.Children.Add(newCommunityButton);
    }

    private async Task<List<ComunidadDTO>> GetComunidades()
        => await this._comunidadesService.GetComunidades();

    private async void HandleViewComunidad(object sender, EventArgs e)
    {
        var comunidadId = ((Button)sender).ClassId;
        var page = _serviceProvider.GetService<ViewComunidad>();
        page._viewModel.Comunidad = _viewModel.Comunidades.First(x => x.Id.ToString().Equals(comunidadId));
        await Navigation.PushAsync(page);
    }

    private void HandleAddNewCommunity(object sender, EventArgs e)
    {
        this.ComunidadesPicker.IsVisible = false;
        this.BusyMessage.IsVisible = true;
        Window window = _serviceProvider.GetService<AddComunidad>();
        window.Destroying += OnCloseAddNewCommunity;
        Application.Current?.OpenWindow(window);
    }

    private void OnCloseAddNewCommunity(object sender, EventArgs e)
    {
        this.ComunidadesPicker.IsVisible = true;
        this.BusyMessage.IsVisible = false;
        this.ComunidadesPicker.Children.Clear();
        OnStart().ConfigureAwait(false);
    }

    //private void ContentPage_Disappearing(object sender, EventArgs e)
    //{
    //    Application.Current.Quit();
    //}
}
