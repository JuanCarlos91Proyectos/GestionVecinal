using GestionVecinal.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Services.Interfaces
{
    public interface ILoginService
    {
        Response<bool> ValidateLogin(string username, string password);
    }
}
