﻿namespace GestionVecinal.Models.DTO
{
    public class FacturaDTO
    {
        public int Id { get; set; }
        public int ProveedorId { get; set; } // Foreign key a Miembros
        private ProveedorDTO? Proveedor { get; set; }

        public int ComunidadId { get; set; } // Foreign key a Comunidad
        private ComunidadDTO? Comunidad { get; set; }
        public double Monto { get; set; } = 0;
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Pagada { get; set; } = false;

    }
}
