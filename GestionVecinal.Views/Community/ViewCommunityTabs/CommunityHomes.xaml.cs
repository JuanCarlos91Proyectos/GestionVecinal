using GestionVecinal.ViewModels;

namespace GestionVecinal.Views;

public partial class CommunityHomes : ContentPage
{
    private CommunityHomesViewModel _vm;

    public CommunityHomes(CommunityHomesViewModel viewModel, int communityId)
    {
        InitializeComponent();
        viewModel.CommunityId = communityId;
        BindingContext = _vm = viewModel;
        _ = _vm.InitialLoad();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        // Lógica para añadir vivienda
    }
}