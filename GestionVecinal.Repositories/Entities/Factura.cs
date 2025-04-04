using SQLite;

namespace GestionVecinal.Repositories.Entities
{
    public  class Factura
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public int ProveedorId { get; set; } // Foreign key a Miembros
        public Proveedor? Proveedor { get; set; }

        public int ComunidadId { get; set; } // Foreign key a Comunidades
        public Comunidad? Comunidad { get; set; }

        [NotNull]
        public double Monto { get; set; } = 0;

        [NotNull]
        public DateTime FechaEmision { get; set; }

        [NotNull]
        public DateTime FechaVencimiento { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        public bool Pagada { get; set; } = false;

    }
}
