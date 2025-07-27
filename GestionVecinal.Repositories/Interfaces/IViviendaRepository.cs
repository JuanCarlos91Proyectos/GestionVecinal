using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Repositories
{
    public interface IViviendaRepository : IBaseRepository
    {
        Task<List<Vivienda>> GetAsync(int comunidadId);

        Task<bool> AddAsync(Vivienda comunidad);
    }
}
