using GestionVecinal.Models.DTO;
using GestionVecinal.Models.ViewModels;
using GestionVecinal.Services.Interfaces;

namespace GestionVecinal.Views;

public partial class CommunitySelect : ContentPage
{
    private readonly IComunidadesService _comunidadesService;
    public readonly CommunitySelectViewModel _viewModel;
    public CommunitySelect(IComunidadesService comunidadesService, CommunitySelectViewModel viewModel)
    {
        this._comunidadesService = comunidadesService;
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
            this.ComunidadesPicker.Children.Add(_viewModel.AddCommunityButton(comunidad));
        }
        Button newCommunityButton = _viewModel.AddNewCommunityButton();
        newCommunityButton.Clicked += HandleAddNewCommunity;
        this.ComunidadesPicker.Children.Add(newCommunityButton);
    }

    private async Task<List<ComunidadDTO>> GetComunidades()
        => await this._comunidadesService.GetComunidades();

    private void HandleAddNewCommunity(object sender, EventArgs e)
    {
        ComunidadesPicker.IsVisible = false;
        Window window = new AddComunidad();
        window.Destroying += OnCloseAddNewCommunity;
        Application.Current?.OpenWindow(window);
    }

    private void OnCloseAddNewCommunity(object sender, EventArgs e)
    {
        this.ComunidadesPicker.IsVisible = true;
        this.ComunidadesPicker.Children.Clear();
        OnStart().ConfigureAwait(false);
    }
}
