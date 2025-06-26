using GestionVecinal.ViewModels;

namespace GestionVecinal.Views;

public partial class PresidentsList : ContentPage
{
	private PresidentsListViewModel _vm;
    public PresidentsList(PresidentsListViewModel viewModel, int communityId)
	{
		InitializeComponent();
        viewModel.CommunityId = communityId;
		BindingContext = _vm = viewModel;
    }
}