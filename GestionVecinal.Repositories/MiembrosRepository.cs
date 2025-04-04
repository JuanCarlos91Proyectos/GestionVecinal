using GestionVecinal.Repositories;
using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Repositories
{
    public class MiembrosRepository : BaseRepository, IMiembrosRepository
    {
        public MiembrosRepository() : base()
        {

        }
        public async Task<List<Miembro>> GetAsync(int comunidadId)
        {
            var miembros = await _database.Table<Miembro>().Where(x => x.ComunidadId == comunidadId).ToListAsync();
            foreach (var miembro in miembros)
            {
                miembro.Comunidad = await _database.Table<Comunidad>().Where(x => x.Id == comunidadId).FirstOrDefaultAsync();
            }
            return miembros;
        }
    }
}
