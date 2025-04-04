using GestionVecinal.Repositories;
using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Repositories
{
    public class PagosRepository : BaseRepository, IPagosRepository
    {
        public PagosRepository() : base()
        {

        }

        public async Task<List<Pago>> GetAsync(int comunidadId)
        {
            var pagos = await _database.Table<Pago>().Where(x => x.ComunidadId == comunidadId).ToListAsync();
            foreach (var pago in pagos)
            {
                pago.Comunidad = await _database.Table<Comunidad>().Where(x => x.Id == comunidadId).FirstOrDefaultAsync();
                pago.Miembro = await _database.Table<Miembro>().Where(x => x.Id == pago.MiembroId).FirstOrDefaultAsync();
            }
            return pagos;
        }
    }
}
