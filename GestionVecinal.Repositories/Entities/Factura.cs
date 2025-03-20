using SQLite;

namespace GestionVecinal.Repositories.Entities
{
    public  class Factura
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public int ProveedorId { get; set; } // Foreign key a Miembros
        private Proveedor? Proveedor { get; set; }

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
