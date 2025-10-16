namespace GranDT.Core.Repos;

public interface IRepoUsuario
{
    //int AltaUsuario(string nombre, string apellido, string email, DateTime? fechaNacimiento, string contrasena, bool esAdmin);
    int AltaUsuario(Usuario usuario);
    
}
