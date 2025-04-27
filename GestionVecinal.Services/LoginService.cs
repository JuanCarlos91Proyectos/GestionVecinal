using GestionVecinal.Models;
using GestionVecinal.Models.Common;
using GestionVecinal.Services;
using GestionVecinal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppSettings _appSettings;
        public LoginService(AppSettings appSettings) 
        {
            _appSettings = appSettings;
        }
        public Response<bool> ValidateLogin(string username, string password)
        {
            var response = new Response<bool>();
            if (username == _appSettings.Admin && password == _appSettings.Password)
            {
                response.setValue(true, true, string.Empty);
            }
            else
            {
                response.setError(_appSettings.ErrorLoginMessage, string.Empty);
            }
            return response;
        }
    }
}
