using Dapper;
using GranDT.Core.Data;
using System.Data;

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

        var parameters = new DynamicParameters();
        parameters.Add("Nombre", usuario.Nombre);
        parameters.Add("Apellido", usuario.Apellido);
        parameters.Add("Email", usuario.Email);
        parameters.Add("FechaNacimiento", usuario.FechadeNacimiento);
        parameters.Add("Contrasena", usuario.Contrasena);
        parameters.Add("EsAdmin", usuario.esAdmin);

        parameters.Add("AIidUsuario", dbType: DbType.Int32, direction: ParameterDirection.Output);

        conn.Execute("CALL altaUsuario(@Nombre, @Apellido, @Email, @FechaNacimiento, @Contrasena, @EsAdmin, @AIidUsuario);", parameters);

        var id = parameters.Get<int>("AIidUsuario");
        usuario.IdUsuario = (uint)id;
        return id;
    }

    public int altaUsuario(Usuario usuario)
    {
        return AltaUsuario(usuario);
    }
}
