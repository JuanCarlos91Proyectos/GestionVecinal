using GestionVecinal.Models;
using GestionVecinal.Services.Interfaces;
using GestionVecinal.ViewModels;

namespace GestionVecinal.Views;

public partial class Login : ContentPage
{   
    public Login(LoginViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
    }
}