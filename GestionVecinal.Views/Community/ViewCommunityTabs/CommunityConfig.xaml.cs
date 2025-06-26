using GestionVecinal.Models.DTO;
using GestionVecinal.ViewModels;

namespace GestionVecinal.Views;

public partial class CommunityConfig : ContentPage
{
	private CommunityConfigViewModel _vm;
	public CommunityConfig(ComunidadDTO community, CommunityConfigViewModel viewModel)
	{
		InitializeComponent();
		viewModel.Community = community;
		BindingContext = _vm = viewModel;
	}
}