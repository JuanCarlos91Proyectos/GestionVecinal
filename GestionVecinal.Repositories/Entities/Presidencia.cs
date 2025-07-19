using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GestionVecinal.Repositories.Entities
{
    public class Presidencia
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        [ForeignKey(typeof(Comunidad))]
        public int ComunidadId { get; set; }
        
        [NotNull]
        [ForeignKey(typeof(Miembro))]
        public int MiembroId { get; set; }
        
        [NotNull]
        public string FechaInicio { get; set; }
        [NotNull]
        public string FechaFin { get; set; }

        [OneToOne]
        public Comunidad Comunidad { get; set; }
        [OneToMany]
        public Miembro? Miembro { get; set; }
    }
}
