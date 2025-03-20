namespace GestionVecinal.Models
{
    public class ComunidadDTO
    {
        public int Id { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public int NumeroViviendas { get; set; }
        public decimal Cuota { get; set; } = 0;
    }
}
