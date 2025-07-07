using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Models.DTO
{
    public class ViviendaDTO
    {
        public int Id { get; set; }
        public int ComunidadId { get; set; }
        public int MiembroId { get; set; }
        public string Escalera { get; set; } = string.Empty;
        public string Piso { get; set; } = string.Empty;
        public string Puerta { get; set; } = string.Empty;
        public string ReferenciaCatastral { get; set; } = string.Empty;
        public decimal Coeficiente { get; set; } = 0M;
    }
}
