using GranDT.Core;
using GranDT.Core.Repos;
using GranDT.Dapper;
using Dapper;
using Xunit;

namespace GranDT.Test;

public class RepoPlantillaTests : TestRepo
{
    readonly IRepoPlantilla repoPlantilla;

    public RepoPlantillaTests() : base()
        => repoPlantilla = new RepoPlantilla(_conexion);

    private void LimpiarPlantillaExistente(string nombrePlantilla, uint idUsuario)
    {
        var plantillaExistente = _conexion.QueryFirstOrDefault<int?>(
            "SELECT idPlantillas FROM Plantillas WHERE NombrePlantilla = @nombre AND idUsuario = @idUsr",
            new { nombre = nombrePlantilla, idUsr = idUsuario });

        if (plantillaExistente.HasValue)
        {
            // Primero eliminar los jugadores de la plantilla
            _conexion.Execute("DELETE FROM PlantillaTitular WHERE idPlantillas = @id",
                new { id = plantillaExistente.Value });
            
            // Luego eliminar la plantilla
            _conexion.Execute("DELETE FROM Plantillas WHERE idPlantillas = @id",
                new { id = plantillaExistente.Value });
        }
    }

    [Fact]
    public void TraerPlantillasPorEmail_DevuelvePlantillasCorrectas()
    {
        // Preparar
        string email = "test@test.com";
        string nombre = "Test";
        string apellido = "Usuario";
        DateTime fechaNac = new DateTime(2000, 1, 1);
        string contraseña = "123456";
        bool esAdmin = false;
        string nombrePlantilla = $"Test Plantilla {DateTime.Now.Ticks}"; // Asegura nombre único

        // Asegurar que existe el usuario de prueba
        var idUsr = _conexion.QueryFirstOrDefault<int?>(
            "SELECT idUsuario FROM Usuario WHERE Email = @email",
            new { email });

        if (!idUsr.HasValue)
        {
            _conexion.Execute(
                "INSERT INTO Usuario (Nombre, Apellido, Email, FechadeNacimiento, Contrasena, esAdmin) " +
                "VALUES (@nombre, @apellido, @email, @fechaNac, @contraseña, @esAdmin)",
                new { 
                    nombre, 
                    apellido, 
                    email, 
                    fechaNac, 
                    contraseña = System.Security.Cryptography.SHA256.HashData(
                        System.Text.Encoding.UTF8.GetBytes(contraseña)
                    ), 
                    esAdmin 
                });
            idUsr = _conexion.QueryFirst<int>("SELECT LAST_INSERT_ID()");
        }

        // Verificar que el usuario se creó correctamente
        if (!idUsr.HasValue)
        {
            throw new Exception("No se pudo crear el usuario de prueba");
        }

        // Crear una nueva plantilla para la prueba
        var plantilla = new Plantilla
        {
            NombrePlantilla = nombrePlantilla,
            Presupuesto = 1000000,
            IdUsuario = (uint)idUsr.Value,
            CantidadJugadores = 11
        };
        repoPlantilla.altaPlantilla(plantilla);

        // Actuar
        var plantillas = repoPlantilla.TraerPlantillasPorEmail(email).ToList();

        // Verificar
        Assert.NotEmpty(plantillas);
        Assert.Contains(plantillas, p => p.NombrePlantilla == nombrePlantilla);
        Assert.All(plantillas, p => Assert.Equal((uint)idUsr.Value, p.IdUsuario));
    }

    [Fact]
    public void TraerEquipos_DevuelveEquiposOrdenados()
    {
        // Actuar
        var equipos = repoPlantilla.TraerEquipos().ToList();

        // Verificar
        Assert.NotEmpty(equipos);
        // Verificar que están ordenados por nombre
        var equiposOrdenados = equipos.OrderBy(e => e.Nombre).ToList();
        Assert.Equal(equiposOrdenados, equipos);
    }

    [Fact]
    public void TraerFutbolistasPorTipo_DevuelveFutbolistasCorrectos()
    {
        // Preparar
        string tipoNombre = "Arquero"; // Este tipo debe existir en la base de datos

        // Actuar
        var futbolistas = repoPlantilla.TraerFutbolistasPorTipo(tipoNombre).ToList();

        // Verificar
        Assert.NotEmpty(futbolistas);
        foreach (var f in futbolistas)
        {
            Assert.NotNull(f.Tipo);
            Assert.Equal(tipoNombre, f.Tipo.Nombre);
            Assert.NotNull(f.Equipos);
            Assert.NotEmpty(f.Equipos.Nombre);
        }
        
        // Verificar que estén ordenados por equipo y apellido
        var futbolistasOrdenados = futbolistas
            .OrderBy(f => f.Equipos?.Nombre ?? string.Empty)
            .ThenBy(f => f.Apellido)
            .ToList();
        Assert.Equal(futbolistasOrdenados, futbolistas);
    }

    [Fact]
    public void AltaPlantilla_DevuelveIdYNoDuplica()
    {
        // Asegurar que existe un usuario
        var idUsr = _conexion.QueryFirstOrDefault<int?>("SELECT idUsuario FROM Usuario LIMIT 1;", null);
        if (!idUsr.HasValue)
        {
            throw new Exception("Se requiere al menos un usuario en la base de datos para esta prueba");
        }

        var plantilla = new Plantilla
        {
            Presupuesto = 1000000m,
            NombrePlantilla = "Test Plantillaa",
            IdUsuario = (uint)idUsr.Value,
            CantidadJugadores = 0
        };

        // Limpiar si existe la plantilla
        var plantillaExistente = _conexion.QueryFirstOrDefault<int?>(
            "SELECT idPlantillas FROM Plantillas WHERE NombrePlantilla = @nombre AND idUsuario = @idUsr",
            new { nombre = plantilla.NombrePlantilla, idUsr = plantilla.IdUsuario });

        if (plantillaExistente.HasValue)
        {
            // Primero eliminar los jugadores de la plantilla
            _conexion.Execute("DELETE FROM PlantillaTitular WHERE idPlantillas = @id",
                new { id = plantillaExistente.Value });
            
            // Luego eliminar la plantilla
            _conexion.Execute("DELETE FROM Plantillas WHERE idPlantillas = @id",
                new { id = plantillaExistente.Value });
        }

        var id = repoPlantilla.altaPlantilla(plantilla);

        Assert.True(id > 0);
    }

    [Fact]
    public void ActualizarPlantilla_ModificaCorrectamente()
    {
        // Crear una plantilla primero
        var idUsr = _conexion.QueryFirstOrDefault<int?>("SELECT idUsuario FROM Usuario LIMIT 1;", null);
        if (!idUsr.HasValue)
        {
            throw new Exception("Se requiere al menos un usuario en la base de datos para esta prueba");
        }

        var plantilla = new Plantilla
        {
            Presupuesto = 1000000m,
            NombrePlantilla = "Test Plantilla Update",
            IdUsuario = (uint)idUsr.Value,
            CantidadJugadores = 0
        };

        // Limpiar y crear nueva
        var plantillaExistente = _conexion.QueryFirstOrDefault<int?>(
            "SELECT idPlantillas FROM Plantillas WHERE NombrePlantilla = @nombre AND idUsuario = @idUsr",
            new { nombre = plantilla.NombrePlantilla, idUsr = plantilla.IdUsuario });

        if (plantillaExistente.HasValue)
        {
            // Primero eliminar los jugadores de la plantilla
            _conexion.Execute("DELETE FROM PlantillaTitular WHERE idPlantillas = @id",
                new { id = plantillaExistente.Value });
            
            // Luego eliminar la plantilla
            _conexion.Execute("DELETE FROM Plantillas WHERE idPlantillas = @id",
                new { id = plantillaExistente.Value });
        }

        plantilla.idPlantillas = (uint)repoPlantilla.altaPlantilla(plantilla);

        // Modificar valores
        plantilla.Presupuesto = 2000000m;
        plantilla.NombrePlantilla = "Test Plantilla Updated";

        var resultado = repoPlantilla.actualizarPlantilla(plantilla);

        Assert.True(resultado > 0);

        // Verificar cambios
        var actualizada = _conexion.QueryFirstOrDefault<Plantilla>(
            "SELECT * FROM Plantillas WHERE idPlantillas = @id",
            new { id = plantilla.idPlantillas }
        );

        Assert.NotNull(actualizada);
        Assert.Equal(plantilla.Presupuesto, actualizada.Presupuesto);
        Assert.Equal(plantilla.NombrePlantilla, actualizada.NombrePlantilla);
    }

    [Fact]
    public void EliminarPlantilla_EliminaCorrectamente()
    {
        // Crear una plantilla para eliminar
        var idUsr = _conexion.QueryFirstOrDefault<int?>("SELECT idUsuario FROM Usuario LIMIT 1;", null);
        if (!idUsr.HasValue)
        {
            throw new Exception("Se requiere al menos un usuario en la base de datos para esta prueba");
        }

        var plantilla = new Plantilla
        {
            Presupuesto = 1000000m,
            NombrePlantilla = "Test Plantilla Delete",
            IdUsuario = (uint)idUsr.Value,
            CantidadJugadores = 0
        };

        plantilla.idPlantillas = (uint)repoPlantilla.altaPlantilla(plantilla);

        var resultado = repoPlantilla.eliminarPlantilla(plantilla);

        Assert.True(resultado > 0);

        // Verificar que se eliminó
        var existe = _conexion.QueryFirstOrDefault<bool>(
            "SELECT 1 FROM Plantillas WHERE idPlantillas = @id",
            new { id = plantilla.idPlantillas }
        );

        Assert.False(existe);
    }

    [Fact]
    public void AltaJugador_AgregaJugadorAPlantilla()
    {
        // Asegurar que existe un usuario
        var idUsr = _conexion.QueryFirstOrDefault<int?>("SELECT idUsuario FROM Usuario LIMIT 1;", null);
        if (!idUsr.HasValue)
        {
            throw new Exception("Se requiere al menos un usuario en la base de datos para esta prueba");
        }

        // Asegurar que existe un futbolista
        var idFut = _conexion.QueryFirstOrDefault<int?>("SELECT idFutbolista FROM Futbolista LIMIT 1;", null);
        if (!idFut.HasValue)
        {
            throw new Exception("Se requiere al menos un futbolista en la base de datos para esta prueba");
        }

        // Crear plantilla de prueba
        var plantilla = new Plantilla
        {
            Presupuesto = 1000000m,
            NombrePlantilla = "Test Plantilla Jugadores",
            IdUsuario = (uint)idUsr.Value,
            CantidadJugadores = 0
        };

        // Limpiar y crear nueva
        _conexion.Execute("DELETE FROM Plantillas WHERE NombrePlantilla = @nombre AND idUsuario = @idUsr",
            new { nombre = plantilla.NombrePlantilla, idUsr = plantilla.IdUsuario });

        plantilla.idPlantillas = (uint)repoPlantilla.altaPlantilla(plantilla);

        var futbolista = new Futbolista { IdFutbolista = (uint)idFut.Value };
        bool esTitular = true;

        var resultado = repoPlantilla.altaJugador(plantilla, futbolista, esTitular);

        Assert.True(resultado > 0);

        // Verificar que se agregó el jugador
        var existe = _conexion.QueryFirstOrDefault<bool>(
            "SELECT 1 FROM PlantillaTitular WHERE idPlantillas = @idPlantilla AND idFutbolista = @idFut AND esTitular = @titular",
            new { idPlantilla = plantilla.idPlantillas, idFut = futbolista.IdFutbolista, titular = esTitular ? 1 : 0 }
        );

        Assert.True(existe);
    }

    [Fact]
    public void ActualizarJugador_ModificaEstadoTitular()
    {
        // Similar a AltaJugador pero actualizando el estado
        var idUsr = _conexion.QueryFirstOrDefault<int?>("SELECT idUsuario FROM Usuario LIMIT 1;", null);
        var idFut = _conexion.QueryFirstOrDefault<int?>("SELECT idFutbolista FROM Futbolista LIMIT 1;", null);

        if (!idUsr.HasValue || !idFut.HasValue)
        {
            throw new Exception("Se requiere al menos un usuario y un futbolista en la base de datos para esta prueba");
        }

        var plantilla = new Plantilla
        {
            Presupuesto = 1000000m,
            NombrePlantilla = "Test Plantilla Update Jugador",
            IdUsuario = (uint)idUsr.Value,
            CantidadJugadores = 0
        };

        // Limpiar y crear nueva
        _conexion.Execute("DELETE FROM Plantillas WHERE NombrePlantilla = @nombre AND idUsuario = @idUsr",
            new { nombre = plantilla.NombrePlantilla, idUsr = plantilla.IdUsuario });

        plantilla.idPlantillas = (uint)repoPlantilla.altaPlantilla(plantilla);

        var futbolista = new Futbolista { IdFutbolista = (uint)idFut.Value };
        
        // Primero lo agregamos como titular
        repoPlantilla.altaJugador(plantilla, futbolista, true);

        // Ahora lo cambiamos a suplente
        var resultado = repoPlantilla.actualizarJugador(plantilla, futbolista, false);

        Assert.True(resultado > 0);

        // Verificar que cambió el estado
        var esSuplente = _conexion.QueryFirstOrDefault<bool>(
            "SELECT 1 FROM PlantillaTitular WHERE idPlantillas = @idPlantilla AND idFutbolista = @idFut AND esTitular = 0",
            new { idPlantilla = plantilla.idPlantillas, idFut = futbolista.IdFutbolista }
        );

        Assert.True(esSuplente);
    }
}
