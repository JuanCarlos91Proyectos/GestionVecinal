namespace GestionVecinal.Models.DTO
{
    public class DerramaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
