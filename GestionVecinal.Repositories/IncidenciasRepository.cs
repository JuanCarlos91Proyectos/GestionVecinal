using GestionVecinal.Repositories;
using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Repositories
{
    public class IncidenciasRepository : BaseRepository, IIncidenciasRepository
    {
        public IncidenciasRepository() : base()
        {

        }

        public async Task<List<Incidencia>> GetAsync(int comunidadId)
        {
            var incidencias = await _database.Table<Incidencia>().Where(x => x.ComunidadId == comunidadId).ToListAsync();
            foreach (var incidencia in incidencias)
            {
                incidencia.Comunidad = await _database.Table<Comunidad>().Where(x => x.Id == comunidadId).FirstOrDefaultAsync();
                incidencia.Miembro = await _database.Table<Miembro>().Where(x => x.Id == incidencia.MiembroId).FirstOrDefaultAsync();
            }
            return incidencias;
        }

    }
}
