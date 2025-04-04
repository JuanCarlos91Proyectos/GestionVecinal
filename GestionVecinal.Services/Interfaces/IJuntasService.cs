using GestionVecinal.Models.Common;
using GestionVecinal.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Services.Interfaces
{
    public interface IJuntasService
    {
        Task<Response<List<JuntaDTO>>> GetAsync(int comunidadId);
    }
}
