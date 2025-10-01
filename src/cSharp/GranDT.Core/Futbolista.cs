using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GranDT.Core
{
    public class Futbolista
    {
        public required uint IdFutbolista { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Apodo { get; set; }
        public DateTime? FechadeNacimiento { get; set; }
        public decimal? Cotizacion { get; set; }
        public required Equipos equipos { get; set; }
        public required Tipo tipo { get; set; }
    }
}