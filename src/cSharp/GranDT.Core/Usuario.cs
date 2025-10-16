
namespace GranDT.Core
{
    public class Usuario
    {
        public uint IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateTime FechadeNacimiento { get; set; }
        public string Contrasena { get; set; }
        public bool esAdmin { get; set; }
    }
}

