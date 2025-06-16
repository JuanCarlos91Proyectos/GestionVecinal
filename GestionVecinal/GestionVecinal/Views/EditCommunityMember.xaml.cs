using GestionVecinal.Models;
using GestionVecinal.Models;

namespace GestionVecinal;

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