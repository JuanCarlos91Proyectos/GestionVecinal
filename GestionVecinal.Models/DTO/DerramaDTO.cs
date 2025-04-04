namespace GestionVecinal.Models.DTO
{
    public class DerramaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int ComunidadId { get; set; }
        public ComunidadDTO? Comunidad { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
