using SQLite;

namespace GestionVecinal.Repositories.Entities
{
    public class Comunidad
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Direccion { get; set; } = string.Empty;
        [NotNull]
        public int NumeroViviendas { get; set; }
        [NotNull]
        public decimal Cuota { get; set; } = 0;
    }
}
