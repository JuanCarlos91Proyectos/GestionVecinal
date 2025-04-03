using GestionVecinal.Models.ViewModels;

namespace GestionVecinal.Views;

public partial class ViewComunidad : TabbedPage
{
	public ViewComunidadViewModel _viewModel;
    public ViewComunidad(ViewComunidadViewModel viewModel)
	{
		_viewModel = viewModel;
        InitializeComponent();
        BindingContext = _viewModel;

    }
}