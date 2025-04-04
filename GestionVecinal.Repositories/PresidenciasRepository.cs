using GestionVecinal.Repositories;
using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Repositories
{
    public class PresidenciasRepository : BaseRepository, IPresidenciasRepository
    {
        public PresidenciasRepository() : base()
        {

        }
        public async Task<List<Presidencia>> GetAsync(int comunidadId)
        {
            var presidentes = await _database.Table<Presidencia>().Where(x => x.ComunidadId == comunidadId).ToListAsync();
            foreach (var presidente in presidentes)
            {
                presidente.Comunidad = await _database.Table<Comunidad>().Where(x => x.Id == comunidadId).FirstOrDefaultAsync();
            }
            return presidentes;
        }
    }
}
