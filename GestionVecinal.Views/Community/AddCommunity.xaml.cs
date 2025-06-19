using GestionVecinal.Models;
using GestionVecinal.Services.Interfaces;
using GestionVecinal.ViewModels;

namespace GestionVecinal.Views;

public partial class AddCommunity : Window
{
	public AddCommunity(AddCommunityViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnAddComunidadClicked(object sender, EventArgs e)
    {
        if (BindingContext is AddCommunityViewModel vm)
        {
            var response = await vm.AddCommunityAsync();
            if (!response.Success)
                await Application.Current.MainPage.DisplayAlert("Error", response.Error?.Message, "OK");
            else
                Application.Current?.CloseWindow(this);
        }
            
    }
}