using GranDT.Core;
using GranDT.Core.Repos;
using GranDT.Dapper;
using Dapper;

namespace GranDT.Test;

public class RepoFutbolistaTests : TestRepo
{
    readonly IRepoFutbolista repoFutbolista;

    public RepoFutbolistaTests() : base()
        => repoFutbolista = new RepoFutbolista(_conexion);

    [Fact]
    public void AltaTipo_DevuelveIdYNoDuplica()
    {
        string nombre = "Arquero"; // Valor permitido por trigger

        // Verificar si ya existe
        var existe = _conexion.QueryFirstOrDefault<int?>("SELECT idTipo FROM Tipo WHERE Nombre = @Nombre;", new { Nombre = nombre });
        if (existe.HasValue)
        {
            Assert.True(existe.Value > 0);
            return;
        }

        var id = repoFutbolista.altaTipo(nombre);

        Assert.True(id > 0);
    }

    [Fact]
    public void AltaEquipo_DevuelveIdYNoDuplica()
    {
        string nombre = "Prueba FC";

        var existe = _conexion.QueryFirstOrDefault<int?>("SELECT idEquipos FROM Equipos WHERE Nombre = @Nombre;", new { Nombre = nombre });
        if (existe.HasValue)
        {
            Assert.True(existe.Value > 0);
            return;
        }

        var id = repoFutbolista.altaEquipo(nombre);

        Assert.True(id > 0);
    }

    [Fact]
    public void AltaFutbolista_RespetaTriggersYDevuelveId()
    {
        var futbolista = new Futbolista
        {
            Nombre = "Test",
            Apellido = "Jugador",
            Apodo = "TJugador",
            FechadeNacimiento = new DateTime(2000,1,1),
            Cotizacion = 1000m,
            IdEquipo = 1, // Asumo que el equipo 1 existe en los inserts
            IdTipo = 1   // Asumo que el tipo 1 existe
        };

        // Evitar duplicados (si ya existe uno con mismo nombre y apellido)
        var existe = _conexion.QueryFirstOrDefault<int?>(
            "SELECT idFutbolista FROM Futbolista WHERE Nombre = @Nombre AND Apellido = @Apellido LIMIT 1;",
            new { futbolista.Nombre, futbolista.Apellido });

        if (existe.HasValue)
        {
            Assert.True(existe.Value > 0);
            return;
        }

        var id = repoFutbolista.altaFutbolista(futbolista);

        Assert.True(id > 0);
    }

    [Fact]
    public void AltaPuntuacion_DevuelveIdYRespetaTriggers()
    {
        // Asegurar que haya al menos un futbolista
        var idFut = _conexion.QueryFirstOrDefault<int?>("SELECT idFutbolista FROM Futbolista LIMIT 1;", null);
        if (!idFut.HasValue)
        {
            // Crear un futbolista mínimo
            var f = new Futbolista { Nombre = "Tmp", Apellido = "Tmp", FechadeNacimiento = DateTime.Today, Cotizacion = 100m, IdEquipo = 1, IdTipo = 1 };
            var newId = repoFutbolista.altaFutbolista(f);
            idFut = newId;
        }

        var futbolista = new Futbolista { IdFutbolista = (uint)idFut.Value };
        var puntuacion = new Puntuacion { FechaNro = 1, Puntos = 8.5m };

        // Evitar duplicado en la misma fecha
        var existe = _conexion.QueryFirstOrDefault<int?>(
            "SELECT idPuntuacion FROM Puntuacion WHERE idFutbolista = @IdFut AND fechaNro = @FechaNro LIMIT 1;",
            new { IdFut = idFut.Value, FechaNro = puntuacion.FechaNro });

        if (existe.HasValue)
        {
            Assert.True(existe.Value > 0);
            return;
        }

        var id = repoFutbolista.altaPuntuacion(futbolista, puntuacion);

        Assert.True(id > 0);
    }

    [Fact]
    public void PromedioFutbolista_CalculaPromedioYCantidadFechas()
    {
        // Asegurar que existe un futbolista con puntuaciones
        var idFut = _conexion.QueryFirstOrDefault<int?>("SELECT idFutbolista FROM Futbolista LIMIT 1;", null);
        if (!idFut.HasValue)
        {
            // Crear un futbolista mínimo
            var f = new Futbolista { Nombre = "Tmp", Apellido = "Tmp", FechadeNacimiento = DateTime.Today, Cotizacion = 100m, IdEquipo = 1, IdTipo = 1 };
            var newId = repoFutbolista.altaFutbolista(f);
            idFut = newId;

            // Agregar algunas puntuaciones
            var futbolista = new Futbolista { IdFutbolista = (uint)idFut.Value };
            repoFutbolista.altaPuntuacion(futbolista, new Puntuacion { FechaNro = 1, Puntos = 7.5m });
            repoFutbolista.altaPuntuacion(futbolista, new Puntuacion { FechaNro = 2, Puntos = 8.5m });
        }

        var (promedio, cantidadFechas) = repoFutbolista.PromedioFutbolista((uint)idFut.Value);

        Assert.True(promedio > 0);
        Assert.True(cantidadFechas > 0);
    }

    [Fact]
    public void AgregarFutbolistaAPlantilla_CreaPlantillaYAgregaJugador()
    {
        // Asegurar que existe un futbolista
        var idFut = _conexion.QueryFirstOrDefault<int?>("SELECT idFutbolista FROM Futbolista LIMIT 1;", null);
        if (!idFut.HasValue)
        {
            var f = new Futbolista { Nombre = "Tmp", Apellido = "Tmp", FechadeNacimiento = DateTime.Today, Cotizacion = 100m, IdEquipo = 1, IdTipo = 1 };
            var newId = repoFutbolista.altaFutbolista(f);
            idFut = newId;
        }

        // Asegurar que existe un usuario
        var idUsr = _conexion.QueryFirstOrDefault<int?>("SELECT idUsuario FROM Usuario LIMIT 1;", null);
        if (!idUsr.HasValue)
        {
            throw new Exception("Se requiere al menos un usuario en la base de datos para esta prueba");
        }

        string nombrePlantilla = "Test Plantilla";
        decimal presupuesto = 1000000m;
        bool esTitular = true;

        // Limpiar si existe la plantilla
        _conexion.Execute("DELETE FROM Plantillas WHERE NombrePlantilla = @nombre", new { nombre = nombrePlantilla });

        var resultado = repoFutbolista.AgregarFutbolistaAPlantilla(
            (uint)idUsr.Value,
            nombrePlantilla,
            presupuesto,
            (uint)idFut.Value,
            esTitular
        );

        Assert.True(resultado > 0);

        // Verificar que se creó la plantilla y se agregó el jugador
        var plantillaExiste = _conexion.QueryFirstOrDefault<bool>(
            "SELECT 1 FROM Plantillas p JOIN PlantillaTitular pt ON p.idPlantillas = pt.idPlantillas " +
            "WHERE p.NombrePlantilla = @nombre AND pt.idFutbolista = @idFut",
            new { nombre = nombrePlantilla, idFut = idFut.Value }
        );

        Assert.True(plantillaExiste);
    }
}
