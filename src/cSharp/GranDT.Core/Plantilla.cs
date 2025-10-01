

namespace GranDT.Core
{
    public class Plantilla
    {
        public  required uint idPlantillas { get; set; }
        public  Decimal? Presupuesto { get; set; }
        public string? NombrePlantilla { get; set; }
        public required Usuario usuario { get; set; }
        public byte? esAdmin { get; set; }
    }
}

