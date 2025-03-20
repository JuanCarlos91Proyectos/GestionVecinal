using GestionVecinal.Models.Enums;

namespace GestionVecinal.Models
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
        public FormaPagoCuotaEnum FormaPagoCuota { get; set; } = FormaPagoCuotaEnum.Domiciliacion;
        public bool Moroso { get; set; } = false;
    }
}
