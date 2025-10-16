using Dapper;
using GranDT.Core.Data;

namespace GranDT.Core.Repos;

public class RepoUsuario : IRepoUsuario
{
    private readonly DapperContext _context;

    public RepoUsuario(DapperContext context)
    {
        _context = context;
    }

    public int AltaUsuario(Usuario usuario)
    {
        using var conn = _context.CreateConnection();
        return conn.Execute("CALL AltaUsuario(@Nombre, @Apellido, @Email, @FechaNacimiento, @Contrasena, @EsAdmin);", usuario);
    }
}
