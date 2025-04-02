using GestionVecinal.Models.ViewModels;

namespace GestionVecinal.Views;

public partial class AddComunidad : Window
{
	public AddComunidadViewModel _viewModel;
	public AddComunidad(AddComunidadViewModel viewModel)
	{
        _viewModel = viewModel;
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnAddComunidadClicked(object sender, EventArgs e)
    {
        Console.WriteLine("Datos añadidos");
        var x = _viewModel.Comunidad;
    }
}