using GestionVecinal.ViewModels;

namespace GestionVecinal.Views;

public partial class EditCommunityMember : Window
{
	private EditCommunityMemberViewModel _vm;
	public EditCommunityMember(EditCommunityMemberViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _vm = viewModel;
		
	}
}