using SQLite;

namespace GestionVecinal.Repositories.Entities
{
    public class Pago
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public int MiembroId { get; set; }
        public Miembro? Miembro { get; set; }
        [NotNull]
        public int ComunidadId { get; set; }
        public Comunidad? Comunidad { get; set; }
        [NotNull]
        public double Monto { get; set; } = 0;
        [NotNull]
        public DateTime? FechaPago { get; set; }
        [NotNull]
        public int TipoPago { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}
