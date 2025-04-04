using GestionVecinal.Repositories;
using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Repositories
{
    public class JuntasRepository : BaseRepository, IJuntasRepository
    {
        public JuntasRepository() : base()
        {

        }

        public async Task<List<Junta>> GetAsync(int comunidadId)
        {
            var juntas = await _database.Table<Junta>().Where(x => x.ComunidadId == comunidadId).ToListAsync();
            foreach (var junta in juntas)
            {
                junta.Comunidad = await _database.Table<Comunidad>().Where(x => x.Id == comunidadId).FirstOrDefaultAsync();
            }
            return juntas;
        }
    }
}
