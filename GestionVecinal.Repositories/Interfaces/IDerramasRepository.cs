using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Repositories
{
    public interface IDerramasRepository : IBaseRepository
    {
        Task<List<Derrama>> GetAsync(int comunidadId);
    }
}
