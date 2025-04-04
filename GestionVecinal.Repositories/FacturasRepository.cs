using GestionVecinal.Repositories;
using GestionVecinal.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Repositories
{
    public class FacturasRepository : BaseRepository, IFacturasRepository
    {
        public FacturasRepository() : base()
        {

        }

        

        public async Task<List<Factura>> GetAsync(int comunidadId)
        {
            var facturas = await _database.Table<Factura>().Where(x => x.ComunidadId == comunidadId).ToListAsync();
            foreach (var factura in facturas)
            {
                factura.Comunidad = await _database.Table<Comunidad>().Where(x => x.Id == comunidadId).FirstOrDefaultAsync();
                factura.Proveedor = await _database.Table<Proveedor>().Where(x => x.Id == factura.ProveedorId).FirstOrDefaultAsync();
            }
            return facturas;
        }

       
    }
}
