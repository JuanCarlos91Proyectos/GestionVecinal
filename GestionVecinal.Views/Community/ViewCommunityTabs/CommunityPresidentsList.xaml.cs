using GestionVecinal.ViewModels;

namespace GestionVecinal.Views;

public partial class CommunityPresidentsList : ContentPage
{
	private CommunityPresidentsListViewModel _vm;
    public CommunityPresidentsList(CommunityPresidentsListViewModel viewModel, int communityId)
	{
		InitializeComponent();
        viewModel.CommunityId = communityId;
		BindingContext = _vm = viewModel;
        _ = _vm.InitialLoad();
    }
}