using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GranDT.Core
{
    public class Puntuacion
    {
        public required uint IdPuntuacion { get; set; }
        public required byte FechaNro { get; set; }
        public decimal? Puntos { get; set; }
        public required Futbolista futbolista { get; set; } 
    }
}