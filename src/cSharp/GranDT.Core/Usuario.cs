

namespace GranDT.Core
{
    public class Usuario
    {
        public uint IdUsuario { get; set; }
        public string Nombre { get; set; }  = string.Empty;
        public string Apellido { get; set; }  = string.Empty;
        public string Email { get; set; }  = string.Empty;
        public DateTime FechadeNacimiento { get; set; }
        public required string Contrasena { get; set; } = string.Empty;
        public bool esAdmin { get; set; }
    }
}

