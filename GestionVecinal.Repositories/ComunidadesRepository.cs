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

        

        public async Task<List<Comunidad>> GetComunidades()
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

        public async Task<List<Derrama>> GetDerramasAsync(int comunidadId)
        {
            var derramas = await _database.Table<Derrama>().Where(x => x.ComunidadId == comunidadId).ToListAsync();
            foreach (var derrama in derramas)
            {
                derrama.Comunidad = await _database.Table<Comunidad>().Where(x => x.Id == comunidadId).FirstOrDefaultAsync();
            }
            return derramas;
        }

        public async Task<List<Factura>> GetFacturasAsync(int comunidadId)
        {
            var facturas = await _database.Table<Factura>().Where(x => x.ComunidadId == comunidadId).ToListAsync();
            foreach (var factura in facturas)
            {
                factura.Comunidad = await _database.Table<Comunidad>().Where(x => x.Id == comunidadId).FirstOrDefaultAsync();
                factura.Proveedor = await _database.Table<Proveedor>().Where(x => x.Id == factura.ProveedorId).FirstOrDefaultAsync();
            }
            return facturas;
        }

        public async Task<List<Incidencia>> GetIncidenciasAsync(int comunidadId)
        {
            var incidencias = await _database.Table<Incidencia>().Where(x => x.ComunidadId == comunidadId).ToListAsync();
            foreach (var incidencia in incidencias)
            {
                incidencia.Comunidad = await _database.Table<Comunidad>().Where(x => x.Id == comunidadId).FirstOrDefaultAsync();
                incidencia.Miembro = await _database.Table<Miembro>().Where(x => x.Id == incidencia.MiembroId).FirstOrDefaultAsync();
            }
            return incidencias;
        }

        public async Task<List<Junta>> GetJuntasAsync(int comunidadId)
        {
            var juntas = await _database.Table<Junta>().Where(x => x.ComunidadId == comunidadId).ToListAsync();
            foreach (var junta in juntas)
            {
                junta.Comunidad = await _database.Table<Comunidad>().Where(x => x.Id == comunidadId).FirstOrDefaultAsync();
            }
            return juntas;
        }

        public async Task<List<Miembro>> GetMiembrosAsync(int comunidadId)
        {
            var miembros = await _database.Table<Miembro>().Where(x => x.ComunidadId == comunidadId).ToListAsync();
            foreach (var miembro in miembros)
            {
                miembro.Comunidad = await _database.Table<Comunidad>().Where(x => x.Id == comunidadId).FirstOrDefaultAsync();
            }
            return miembros;
        }

        public async Task<List<Presidencia>> GetPresidentesAsync(int comunidadId)
        {
            var presidentes = await _database.Table<Presidencia>().Where(x => x.ComunidadId == comunidadId).ToListAsync();
            foreach (var presidente in presidentes)
            {
                presidente.Comunidad = await _database.Table<Comunidad>().Where(x => x.Id == comunidadId).FirstOrDefaultAsync();
            }
            return presidentes;
        }

        public async Task<List<Proveedor>> GetProveedoresAsync(int comunidadId)
        {
            var proveedores = await _database.Table<Proveedor>().Where(x => x.ComunidadId == comunidadId).ToListAsync();
            foreach (var proveedor in proveedores)
            {
                proveedor.Comunidad = await _database.Table<Comunidad>().Where(x => x.Id == comunidadId).FirstOrDefaultAsync();
            }
            return proveedores;
        }

        public async Task<List<Pago>> GetPagosAsync(int comunidadId)
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
