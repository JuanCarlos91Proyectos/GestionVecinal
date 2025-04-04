using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Repositories
{
    public interface IMiembrosRepository : IBaseRepository
    {
        Task<List<Miembro>> GetAsync(int comunidadId);
    }
}
