using GestionVecinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Services
{
    public interface IComunidadesService
    {
        Task<List<ComunidadDTO>> GetComunidades();
    }
}
