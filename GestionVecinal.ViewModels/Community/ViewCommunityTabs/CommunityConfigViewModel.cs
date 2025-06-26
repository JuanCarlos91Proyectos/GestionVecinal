using GestionVecinal.Models;
using GestionVecinal.Models.DTO;
using GestionVecinal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.ViewModels
{
    
    public class CommunityConfigViewModel : BaseViewModel
    {
        private ComunidadDTO _community = new ComunidadDTO();
        public ComunidadDTO Community
        {
            get { return _community; }
            set { _community = value; OnPropertyChanged(nameof(Community)); }
        }
        public CommunityConfigViewModel(AppSettings appSettings, IServiceProvider serviceProvider, INavigationService navigationService) : base(appSettings, serviceProvider, navigationService)
        {
        }
    }
}
