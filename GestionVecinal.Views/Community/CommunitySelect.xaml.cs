using GestionVecinal.Models.DTO;
using GestionVecinal.Models;
using GestionVecinal.Views.Resources.Localization;
using GestionVecinal.Services.Interfaces;
using GestionVecinal.ViewModels;

namespace GestionVecinal.Views;

public class AddCommunityWindowService : IAddCommunityWindowService
{
    private readonly IServiceProvider _serviceProvider;

    public AddCommunityWindowService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void OpenAddCommunityWindow(Action onClose)
    {
        var window = _serviceProvider.GetService<AddCommunity>();
        window.Destroying += (s, e) => onClose?.Invoke();
        Application.Current?.OpenWindow(window);
    }
}

public partial class CommunitySelect : ContentPage
{
    private readonly CommunitySelectViewModel _vm;
    public CommunitySelect(CommunitySelectViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _vm = viewModel;

        viewModel.OnAddCommunityClosed += OnAddCommunityClosed;
    }

    private void OnAddCommunityClosed()
    {
        _vm.IsVisible = true;
        _vm.IsVisibleBusyMessage = false;
        CommunityButtonsLayout.Children.Clear();
        _ = OnStart();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        
        await OnStart();
    }

    private async Task OnStart()
    {
        if (BindingContext is CommunitySelectViewModel vm)
        {
            CommunityButtonsLayout.Children.Clear();
            vm.AddNewCommunityText = AppResources.AddNewCommunity;
            await vm.LoadButtonsAsync();
            if (vm.CommunityButtons.Count > 0)
            {
                foreach (var button in vm.CommunityButtons)
                {
                    button.Pressed += (s, e) =>
                    {
                        vm.ButtonFocusCommand.Execute(button);
                    };
                    button.Released += (s, e) =>
                    {
                        vm.ButtonUnfocusCommand.Execute(button);
                    };
                    CommunityButtonsLayout.Children.Add(button);
                }


            }

        }
    }
}
