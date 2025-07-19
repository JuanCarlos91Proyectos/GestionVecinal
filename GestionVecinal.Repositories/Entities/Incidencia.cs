using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GestionVecinal.Repositories.Entities
{
    public class Incidencia
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        [NotNull]
        [ForeignKey(typeof(Comunidad))]
        public int ComunidadId { get; set; }
        [NotNull]
        [ForeignKey(typeof(Miembro))]
        public int MiembroId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        [NotNull]
        public DateTime Fecha { get; set; }
        [NotNull]
        public bool Resuelta { get; set; } = false;
        [NotNull]
        public int TipoIncidencia { get; set; }

        [OneToOne]
        public Comunidad? Comunidad { get; set; }
        [OneToOne]
        public Miembro? Miembro { get; set; }
    }
}
