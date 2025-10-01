
namespace GranDT.Core
{
    public class Usuario
    {
        public required uint IdUsuario { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Email { get; set; }
        public DateTime FechadeNacimiento { get; set; }
        public required string Contraseña { get; set; }
        public bool esAdmin { get; set; }
    }
}

// `idUsuario` INT UNSIGNED NOT NULL,
//  `Nombre` VARCHAR(45) NOT NULL,
//  `Apellido` VARCHAR(45) NOT NULL,
//  `Email` VARCHAR(90) NOT NULL,
//  `FechadeNacimiento` DATE NULL,
//  `Contraseña` VARCHAR(64) NOT NULL,
//  `esAdmin` TINYINT NULL COMMENT '