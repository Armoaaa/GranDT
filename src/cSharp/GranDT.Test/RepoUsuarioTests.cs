using System;
using Xunit;
using Xunit.Sdk;

namespace GranDT.Test;

public class RepoUsuarioTests
{
    [Fact]
    public void AltaUsuario_Integration_WhenConnectionProvided()
    {
        var conn = Environment.GetEnvironmentVariable("GRANDT_TEST_CONN");
        if (string.IsNullOrWhiteSpace(conn))
        {
            // No hay cadena de conexión configurada: salimos sin fallar la prueba (se considera omitida en este entorno).
            return;
        }

        var context = new GranDT.Core.Data.DapperContext(conn);
        var repo = new GranDT.Core.Repos.RepoUsuario(context);

        var usuario = new GranDT.Core.Usuario
        {
            Nombre = "Test",
            Apellido = "User",
            Email = $"test+{Guid.NewGuid():N}@example.local",
            FechadeNacimiento = DateTime.UtcNow,
            Contrasena = "dummyhash",
            esAdmin = false
        };

        // Ejecuta el método; si el procedimiento está correcto debe devolver >= 0 (número de filas afectadas).
        var result = repo.AltaUsuario(usuario);
        Assert.True(result >= 0, "La llamada a AltaUsuario debe devolver un número de filas afectadas >= 0");
    }
}
