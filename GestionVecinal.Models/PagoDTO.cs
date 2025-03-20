using GestionVecinal.Models.Enums;

namespace GestionVecinal.Models
{
    public class PagoDTO
    {
        public int Id { get; set; }
        public int MiembroId { get; set; }
        private MiembroDTO? Miembro { get; set; }
        public int ComunidadId { get; set; }
        private ComunidadDTO? Comunidad { get; set; }
        public double Monto { get; set; } = 0;
        public DateTime? FechaPago { get; set; }
        public TipoPagoEnum TipoPago { get; set; } = TipoPagoEnum.Cuota;
        public string Descripcion { get; set; } = string.Empty;
    }
}
