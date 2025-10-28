namespace GranDT.Core.Repos;

public interface IRepoUsuario
{
            //int altaUsuario(string nombre, string apellido, string email, DateTime? fechaNacimiento, string contrasena, bool esAdmin);
            int AltaUsuario(Usuario usuario);
            bool loginUsuario(string email, string contrasena);
}
