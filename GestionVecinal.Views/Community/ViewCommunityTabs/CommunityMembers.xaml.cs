using GestionVecinal.ViewModels;
using MauiIcons.Fluent;

namespace GestionVecinal.Views;

public partial class CommunityMembers : ContentPage
{
    private CommunityMembersViewModel _vm;
    public CommunityMembers(CommunityMembersViewModel viewModel, int communityId)
	{
		InitializeComponent();
        viewModel.CommunityId = communityId;
        BindingContext = _vm = viewModel;
        _ = _vm.InitialLoad();
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {

    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {

    }
}