namespace GestionVecinal.Models.DTO
{
    public class ComunidadDTO
    {
        public int Id { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public string Cp { get; set; } = string.Empty;
        public string Poblacion { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;
        public int NumeroViviendas { get; set; }
        public decimal Cuota { get; set; } = 0;
    }
}
