using GestionVecinal.Models;
using GestionVecinal.Services.Interfaces;
using GestionVecinal.ViewModels.Login;

namespace GestionVecinal.Views.Login;

public partial class Login : ContentPage
{
    public readonly LoginViewModel _viewModel;
    
    public Login(LoginViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
    }
}