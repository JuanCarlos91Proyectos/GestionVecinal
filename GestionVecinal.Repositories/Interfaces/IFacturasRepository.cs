using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Repositories
{
    public interface IFacturasRepository : IBaseRepository
    {
        Task<List<Factura>> GetAsync(int comunidadId);
    }
}
