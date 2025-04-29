using GestionVecinal.Models.ViewModels;

namespace GestionVecinal.Views;

public partial class EditCommunityMember : ContentPage
{
	public EditCommunityMemberViewModel _viewModel;
    public EditCommunityMember(EditCommunityMemberViewModel viewModel)
	{
        _viewModel = viewModel;
        InitializeComponent();
        BindingContext = viewModel;
    }
}