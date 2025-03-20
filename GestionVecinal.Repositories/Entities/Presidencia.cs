using SQLite;

namespace GestionVecinal.Repositories.Entities
{
    public class Presidencia
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public int ComunidadId { get; set; }
        private Comunidad? Comunidad { get; set; }
        [NotNull]
        public int MiembroId { get; set; }
        private Miembro? Miembro { get; set; }
        [NotNull]
        public DateTime FechaInicio { get; set; }
        [NotNull]
        public DateTime FechaFin { get; set; }
    }
}
