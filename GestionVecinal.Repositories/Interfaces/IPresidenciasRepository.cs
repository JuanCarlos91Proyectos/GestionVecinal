using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Repositories
{
    public interface IPresidenciasRepository : IBaseRepository
    {
        Task<List<Presidencia>> GetAsync(int comunidadId);
    }
}
