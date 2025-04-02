using GestionVecinal.Models.ViewModels;
using GestionVecinal.Services.Interfaces;

namespace GestionVecinal.Views;

public partial class AddComunidad : Window
{
	public AddComunidadViewModel _viewModel;
    private IComunidadesService _service;
	public AddComunidad(IComunidadesService comunidadesService ,AddComunidadViewModel viewModel)
	{
        _service = comunidadesService;
        _viewModel = viewModel;
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnAddComunidadClicked(object sender, EventArgs e)
    {
        var response = await _service.AddAsync(_viewModel.Comunidad);
        if (!response.Success)
            await App.Current.MainPage.DisplayAlert("Error", response.Error.Message, "OK");
        else
            Application.Current.CloseWindow(this);
    }
}