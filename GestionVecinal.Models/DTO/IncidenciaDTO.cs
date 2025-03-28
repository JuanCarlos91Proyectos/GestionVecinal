using GestionVecinal.Models.Enums;

namespace GestionVecinal.Models.DTO
{
    public class IncidenciaDTO
    {
        public int Id { get; set; }
        public int MiembroId { get; set; }
        private MiembroDTO? Miembro { get; set; }
        public int ComunidadId { get; set; }
        private ComunidadDTO? Comunidad { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public bool Resuelta { get; set; } = false;
        public TipoIncidenciaEnum TipoIncidencia { get; set; } = TipoIncidenciaEnum.Otro;
    }
}
