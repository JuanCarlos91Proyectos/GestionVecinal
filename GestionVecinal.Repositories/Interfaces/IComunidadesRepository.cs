using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Repositories
{
    public interface IComunidadesRepository : IBaseRepository
    {
        Task<List<Comunidad>> GetComunidades();

        Task<bool> AddAsync(Comunidad comunidad);

        Task<List<Derrama>> GetDerramasAsync(int comunidadId);
        Task<List<Factura>> GetFacturasAsync(int comunidadId);
        Task<List<Incidencia>> GetIncidenciasAsync(int comunidadId);
        Task<List<Junta>> GetJuntasAsync(int comunidadId);
        Task<List<Miembro>> GetMiembrosAsync(int comunidadId);
        Task<List<Presidencia>> GetPresidentesAsync(int comunidadId);
        Task<List<Proveedor>> GetProveedoresAsync(int comunidadId);
        Task<List<Pago>> GetPagosAsync(int comunidadId);
    }
}
