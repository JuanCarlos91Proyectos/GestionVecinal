using SQLite;

namespace GestionVecinal.Repositories.Entities
{
    public class Derrama
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public int ComunidadId { get; set; }
        public Comunidad? Comunidad { get; set; }
        [NotNull]
        public string Descripcion { get; set; } = string.Empty;

        [NotNull]
        public double Monto { get; set; }

        [NotNull]
        public DateTime Fecha { get; set; }
    }
}
