using GranDT.Core;
using GranDT.Core.Repos;
using GranDT.Dapper;
using Xunit;

namespace GranDT.Test;

public class RepoUsuarioTests : TestRepo
{
    // Repo que vamos a usar en este test
    readonly IRepoUsuario repoUsuario;

    // Este test usa la conexión provista por la clase base TestRepo
    public RepoUsuarioTests() : base()
        => repoUsuario = new RepoUsuario(_conexion);

    [Theory]
    [InlineData("Juan", "Pérez", "juan@test.com", "2000-01-01", "password123", false)]
    [InlineData("Maria", "González", "maria@test.com", "1995-05-05", "pass456", true)]
    public void AltaUsuario(string nombre, string apellido, string email, string fechaNacimiento, string contrasena, bool esAdmin)
    {
        var usuario = new Usuario
        {
            Nombre = nombre,
            Apellido = apellido,
            Email = email,
            FechadeNacimiento = DateTime.Parse(fechaNacimiento),
            Contrasena = contrasena,
            esAdmin = esAdmin
        };

        var id = repoUsuario.AltaUsuario(usuario);

        Assert.True(id > 0);
    }

    [Fact]
    public void loginUsuarioCORRECTO()
    {
        var email = "armoa34@outlook.com";
        var contrasena = "Meamo123jaja";

        Usuario? resultado = repoUsuario.loginUsuario(email, contrasena);

        Assert.NotNull(resultado);

    }
        [Fact]
    public void loginUsuarioINCORRECTO()
    {
        var email = "armoa34@outlook.com";
        var contrasena = "Meamo123jaASASja";

        Usuario? resultado = repoUsuario.loginUsuario(email, contrasena);

        Assert.Null(resultado);
        if (resultado == null)
        {
            Console.WriteLine("Login fallado");
        }
    }
}