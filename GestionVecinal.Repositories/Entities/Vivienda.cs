using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GestionVecinal.Repositories.Entities
{
    public class Vivienda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        [ForeignKey(typeof(Comunidad))]
        public int ComunidadId { get; set; }
        [NotNull]
        [ForeignKey(typeof(Miembro))]
        public int MiembroId { get; set; }
        public string Escalera { get; set; } = string.Empty;
        [NotNull]
        public string Piso { get; set; } = string.Empty;
        [NotNull]
        public string Puerta { get; set; } = string.Empty;
        [NotNull]
        public string ReferenciaCatastral { get; set; } = string.Empty;
        [NotNull]
        public decimal Coeficiente { get; set; } = 0M;

        [OneToOne]
        public Comunidad Comunidad { get; set; }
        [OneToOne]
        public Miembro? Miembro { get; set; }
    }
}
