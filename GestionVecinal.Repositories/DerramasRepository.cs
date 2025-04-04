using GestionVecinal.Repositories;
using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Repositories
{
    public class DerramasRepository : BaseRepository, IDerramasRepository
    {
        public DerramasRepository() : base()
        {

        }

        public async Task<List<Derrama>> GetAsync(int comunidadId)
        {
            var derramas = await _database.Table<Derrama>().Where(x => x.ComunidadId == comunidadId).ToListAsync();
            foreach (var derrama in derramas)
            {
                derrama.Comunidad = await _database.Table<Comunidad>().Where(x => x.Id == comunidadId).FirstOrDefaultAsync();
            }
            return derramas;
        }

        
    }
}
