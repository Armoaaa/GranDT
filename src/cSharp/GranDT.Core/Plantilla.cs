

namespace GranDT.Core
{
    public class Plantilla
    {
        public  uint idPlantillas { get; set; }
        public  Decimal Presupuesto { get; set; }
        public required string NombrePlantilla { get; set; }
        public required Usuario usuario { get; set; }
        public required int esAdmin { get; set; }
    }
}

//  `idPlantillas` INT UNSIGNED NOT NULL,
//  `Presupuesto` DECIMAL NULL,
//  `NombrePlantilla` VARCHAR(50) NULL,
//  `idUsuario` INT UNSIGNED NOT NULL,
//  `CantidadJugadores` TINYINT NULL,