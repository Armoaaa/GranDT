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
    public void TraerPlantillasPorEmail()
    {
        string email = "armoa34@outlook.com";
        // Actuar
        var plantillas = repoPlantilla.TraerPlantillasPorEmail(email).ToList();

        Assert.NotEmpty(plantillas);
        foreach (var p in plantillas)
        {
            Assert.NotNull(p.NombrePlantilla);
            Console.WriteLine(
            $"ID: {p.idPlantillas} | " +
            $"Nombre: {p.NombrePlantilla} | " +
            $"Presupuesto: {p.Presupuesto} | " +
            $"Usuario: {p.Usuario?.Nombre} {p.Usuario?.Apellido}"
        );
        }
        
    }


    
    
    [Fact]
    public void TraerFutbolistasPorTipo()
    {
        uint idTipo = 1;
        uint idEquipo = 2;
    
        var futbolistas = repoPlantilla.traerFutbolistasXTipoXEquipo(idTipo, idEquipo).ToList();
    
        Assert.NotEmpty(futbolistas);
    
        foreach (var f in futbolistas)
        {
            Assert.NotNull(f.Tipo);
            Assert.NotNull(f.Equipos);
            // Console.WriteLine($"{f.Nombre} {f.Apellido} - {f.Tipo?.Nombre} ({f.Equipos?.Nombre})"); // ESTO ES PARA QUE SE MUESTRE EN LA CONSOLA LA 
        }
    }

    [Fact]
    public void AltaPlantilla()
    {

        var plantilla = new Plantilla
        {
            Presupuesto = 1000000m,
            NombrePlantilla = "Test Plantillaa",
            IdUsuario = 1,
            CantidadJugadores = 0
        };

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
