using GestionVecinal.Repositories;
using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Repositories
{
    public class ViviendaRepository : BaseRepository, IViviendaRepository
    {
        public ViviendaRepository() : base()
        {

        }

        

        public async Task<List<Vivienda>> GetAsync(int comunidadId)
        {
            return await _database.Table<Vivienda>().Where(x => x.ComunidadId == comunidadId).ToListAsync();
        }

        public async Task<bool> AddAsync(Vivienda comunidad)
        {
            try
            {
                await _database.InsertAsync(comunidad);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
