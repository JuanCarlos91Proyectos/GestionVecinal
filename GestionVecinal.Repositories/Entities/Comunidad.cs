using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GestionVecinal.Repositories.Entities
{
    public class Comunidad
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Direccion { get; set; } = string.Empty;
        public string Cp { get; set; } = string.Empty;
        public string Poblacion { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;
        [NotNull]
        public int NumeroViviendas { get; set; }
        [NotNull]
        public decimal Cuota { get; set; } = 0;

        
        [OneToMany]
        public List<Miembro> Miembros { get; set; } = new List<Miembro>();
    }
}
