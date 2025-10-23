using System.Data;
using Dapper;
using GranDT.Core;
using GranDT.Core.Repos;

namespace GranDT.Dapper;

public class RepoUsuario : Repo, IRepoUsuario
{
    // Recibe la conexión (inyectada por la capa de tests/servicio)
    public RepoUsuario(IDbConnection conexion) : base(conexion) { }

    private static readonly string _spAltaUsuario = "altaUsuario";

    public int AltaUsuario(Usuario usuario)
    {
        var p = new DynamicParameters();
        p.Add("UnNombre", usuario.Nombre);
        p.Add("UnApellido", usuario.Apellido);
        p.Add("UnEmail", usuario.Email);
        p.Add("UnFechadeNacimiento", usuario.FechadeNacimiento);
        p.Add("UnContrasena", usuario.Contrasena);
        p.Add("UnesAdmin", usuario.esAdmin ? 1 : 0);
        p.Add("AIidUsuario", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _conexion.Execute(
            _spAltaUsuario,
            p,
            commandType: CommandType.StoredProcedure
        );

        return p.Get<int>("AIidUsuario");
    }
}
