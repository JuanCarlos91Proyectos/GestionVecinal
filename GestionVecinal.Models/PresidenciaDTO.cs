namespace GestionVecinal.Models
{
    public class PresidenciaDTO
    {

        public int Id { get; set; }
        public int ComunidadId { get; set; }
        private ComunidadDTO? Comunidad { get; set; }
        public int MiembroId { get; set; }
        private MiembroDTO? Miembro { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
