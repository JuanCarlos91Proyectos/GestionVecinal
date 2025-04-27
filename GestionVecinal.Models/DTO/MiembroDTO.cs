using GestionVecinal.Models.Enums;
using GestionVecinal.Models.Extensions;
using System;
using System.Reflection;
using System.ComponentModel;

namespace GestionVecinal.Models.DTO
{
    public class MiembroDTO
    {
        public int Id { get; set; }
        public int ComunidadId { get; set; }
        private ComunidadDTO? Comunidad { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Piso { get; set; } = string.Empty;
        public string Puerta { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal? Coeficiente { get; set; }
        public FormaPagoCuotaEnum FormaPagoCuota { get; set; } = FormaPagoCuotaEnum.Domiciliacion;
        public string FormaPago
        {
            get
            {
                return FormaPagoCuota.GetDescription();
            }
        }
        public bool Moroso { get; set; } = false;
        public bool EsPresidente { get; set;} = false;
    }
}
