﻿using SQLite;
using SQLiteNetExtensions.Attributes;

namespace GestionVecinal.Repositories.Entities
{
    public class Proveedor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [ForeignKey(typeof(Comunidad))]
        public int ComunidadId { get; set; }
       

        [NotNull]
        public string Nombre { get; set; } = string.Empty;

        [NotNull]
        public string Contacto { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Direccion { get; set; } = string.Empty;

        [OneToMany]
        public Comunidad? Comunidad { get; set; }
    }
}
