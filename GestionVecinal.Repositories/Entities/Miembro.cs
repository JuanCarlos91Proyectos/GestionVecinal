﻿using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GestionVecinal.Repositories.Entities
{
    public class Miembro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public int ComunidadId { get; set; }
        [NotNull]
        public string Nombre { get; set; } = string.Empty;
        [NotNull]
        public string Apellidos { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [NotNull]
        public int FormaPagoCuota { get; set; }

        public Comunidad? Comunidad { get; set; }
    }
}
