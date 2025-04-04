using GestionVecinal.Repositories;
using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Repositories
{
    public class ProveedoresRepository : BaseRepository, IProveedoresRepository
    {
        public ProveedoresRepository() : base()
        {

        }

        public async Task<List<Proveedor>> GetAsync(int comunidadId)
        {
            var proveedores = await _database.Table<Proveedor>().Where(x => x.ComunidadId == comunidadId).ToListAsync();
            foreach (var proveedor in proveedores)
            {
                proveedor.Comunidad = await _database.Table<Comunidad>().Where(x => x.Id == comunidadId).FirstOrDefaultAsync();
            }
            return proveedores;
        }
    }
}
