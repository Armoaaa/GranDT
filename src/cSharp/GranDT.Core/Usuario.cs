
namespace GranDT.Core
{
    public class Usuario
    {
        public required uint IdUsuario { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Email { get; set; }
        public DateTime FechadeNacimiento { get; set; }
        public required string Contrasena { get; set; }
        public bool esAdmin { get; set; }
    }
}

