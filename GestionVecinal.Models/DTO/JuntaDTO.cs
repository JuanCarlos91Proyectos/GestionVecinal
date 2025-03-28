namespace GestionVecinal.Models.DTO
{
    public class JuntaDTO
    {
        public int Id { get; set; }
        public int ComunidadId { get; set; }
        private ComunidadDTO? Comunidad { get; set; }
        public DateTime Fecha { get; set; }
        public string? Lugar { get; set; }
        public string? Acta { get; set; }
        public List<int> Asistencia { get; set; } = new List<int>();// Puede ser una lista de IDs de miembros que asistieron
        private List<MiembroDTO> Asistentes { get; set; } = new List<MiembroDTO>();// Puede ser una lista de miembros que asistieron
    }
}
