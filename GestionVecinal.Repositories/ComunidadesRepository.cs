using GestionVecinal.Repositories;
using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Repositories
{
    public class ComunidadesRepository : BaseRepository, IComunidadesRepository
    {
        public ComunidadesRepository() : base()
        {

        }

        

        public async Task<List<Comunidad>> GetAsync()
        {
            return await _database.Table<Comunidad>().ToListAsync();
        }

        public async Task<bool> AddAsync(Comunidad comunidad)
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
