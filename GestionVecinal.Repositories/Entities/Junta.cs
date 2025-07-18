﻿using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GestionVecinal.Repositories.Entities
{
    public class Junta
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        [ForeignKey(typeof(Comunidad))] 
        public int ComunidadId { get; set; }

        [NotNull]
        public DateTime Fecha { get; set; }

        [NotNull]
        public string? Lugar { get; set; }

        public string? Acta { get; set; }

        [OneToOne]
        public Comunidad? Comunidad { get; set; }

        //public List<int> Asistencia { get; set; } = new List<int>();// Puede ser una lista de IDs de miembros que asistieron
        //private List<Miembro> Asistentes { get; set; } = new List<Miembro>(); // Puede ser una lista de miembros que asistieron
    }
}
