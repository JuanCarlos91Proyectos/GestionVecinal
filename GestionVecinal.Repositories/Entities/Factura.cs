using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GestionVecinal.Repositories.Entities
{
    public  class Factura
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [ForeignKey(typeof(Comunidad))]
        public int ComunidadId { get; set; } // Foreign key a Comunidades

        [NotNull]
        [ForeignKey(typeof(Proveedor))]
        public int ProveedorId { get; set; } // Foreign key a Miembros
        

        
        

        [NotNull]
        public double Monto { get; set; } = 0;

        [NotNull]
        public DateTime FechaEmision { get; set; }

        [NotNull]
        public DateTime FechaVencimiento { get; set; }

        public string Descripcion { get; set; } = string.Empty;



        public Comunidad? Comunidad { get; set; }
        public Proveedor? Proveedor { get; set; }

    }
}
