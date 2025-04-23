namespace GestionVecinal.Models.DTO
{
    public class PresidenciaDTO
    {

        public int Id { get; set; }
        public int ComunidadId { get; set; }
        private ComunidadDTO? Comunidad { get; set; }
        public int MiembroId { get; set; }
        public MiembroDTO? Miembro { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
    }
}
