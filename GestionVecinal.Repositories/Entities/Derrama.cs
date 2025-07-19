using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GestionVecinal.Repositories.Entities
{
    public class Derrama
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [ForeignKey(typeof(Comunidad))]
        public int ComunidadId { get; set; }
        
        [NotNull]
        public string Descripcion { get; set; } = string.Empty;

        [NotNull]
        public double Monto { get; set; }

        [NotNull]
        public DateTime Fecha { get; set; }

        [OneToOne]
        public Comunidad? Comunidad { get; set; }
    }
}
