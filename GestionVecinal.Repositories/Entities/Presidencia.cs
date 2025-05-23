﻿using SQLite;

namespace GestionVecinal.Repositories.Entities
{
    public class Presidencia
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public int ComunidadId { get; set; }
        public Comunidad? Comunidad { get; set; }
        [NotNull]
        public int MiembroId { get; set; }
        public Miembro? Miembro { get; set; }
        [NotNull]
        public string FechaInicio { get; set; }
        [NotNull]
        public string FechaFin { get; set; }
    }
}
