﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Services.Interfaces
{
    public interface INavigationService
    {
        Task GoToAsync(string route, IDictionary<string, object>? parameters = null);
        Task GoBackAsync();
    }

}
