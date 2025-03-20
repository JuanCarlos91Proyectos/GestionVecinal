using SQLite;

namespace GestionVecinal.Repositories.Entities
{
    public class Incidencia
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public int MiembroId { get; set; }
        private Miembro? Miembro { get; set; }
        [NotNull]
        public int ComunidadId { get; set; }
        private Comunidad? Comunidad { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        [NotNull]
        public DateTime Fecha { get; set; }
        [NotNull]
        public bool Resuelta { get; set; } = false;
        [NotNull]
        public int TipoIncidencia { get; set; }
    }
}
