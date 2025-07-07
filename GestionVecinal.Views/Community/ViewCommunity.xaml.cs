using GestionVecinal.Models.DTO;
using GestionVecinal.Models;
using GestionVecinal.Services.Interfaces;
using MauiIcons.Core;
using System.Collections.ObjectModel;
using GestionVecinal.ViewModels;

namespace GestionVecinal.Views;

public partial class ViewCommunity : TabbedPage, IQueryAttributable
{
    private ViewCommunityViewModel _vm;
    public ViewCommunity(ViewCommunityViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _vm = viewModel;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("community", out var communityObj) && communityObj is ComunidadDTO community)
        {
           
            CommunityConfigViewModel communityConfigViewModel = _vm._serviceProvider.GetService<CommunityConfigViewModel>();
            this.Children.Add(new CommunityConfig(community, communityConfigViewModel));
            CommunityMembersViewModel communityMembersViewModel = _vm._serviceProvider.GetService<CommunityMembersViewModel>();
            this.Children.Add(new CommunityMembers(communityMembersViewModel, community.Id));
            CommunityPresidentsListViewModel CommunityPresidentsListViewModel = _vm._serviceProvider.GetService<CommunityPresidentsListViewModel>();
            this.Children.Add(new CommunityPresidentsList(CommunityPresidentsListViewModel, community.Id));
            this.Children.Add(new CommunityHomes());
            // Ahora puedes usar "usuario" y pasarlo a las páginas hijas
            //var home = new HomePage(usuario);
            //var settings = new SettingsPage();

            //this.Children.Add(home);
            //this.Children.Add(settings);
        }
    }
}