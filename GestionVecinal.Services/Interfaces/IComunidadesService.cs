using GestionVecinal.Models.Common;
using GestionVecinal.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Services.Interfaces
{
    public interface IComunidadesService
    {
        Task<List<ComunidadDTO>> GetComunidades();
        Task<Response<bool>> AddAsync(ComunidadDTO comunidad);
        Task<Response<List<DerramaDTO>>> GetDerramasAsync(int comunidadId);
        Task<Response<List<FacturaDTO>>> GetFacturasAsync(int comunidadId);
        Task<Response<List<IncidenciaDTO>>> GetIncidenciasAsync(int comunidadId);
        Task<Response<List<JuntaDTO>>> GetJuntasAsync(int comunidadId);
        Task<Response<List<MiembroDTO>>> GetMiembrosAsync(int comunidadId);
        Task<Response<List<PresidenciaDTO>>> GetPresidentesAsync(int comunidadId);
        Task<Response<List<ProveedorDTO>>> GetProveedoresAsync(int comunidadId);
    }
}
