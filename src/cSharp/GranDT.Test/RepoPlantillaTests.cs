using GranDT.Core;
using GranDT.Core.Repos;
using GranDT.Dapper;
using System.Text.Json;

namespace GranDT.Test;

public class RepoPlantillaTests : TestRepo
{
    readonly IRepoPlantilla repoPlantilla;

    public RepoPlantillaTests() : base()
        => repoPlantilla = new RepoPlantilla(_conexion);


    [Fact]
    public void TraerPlantillasPorId()
    {
        uint idUsuario = 1;
        // Actuar
        var plantillas = repoPlantilla.TraerPlantillasPorId(idUsuario).ToList();

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
    public void CheckearSinPlantilla()
    {
        uint idUsuario = 100;
        // Actuar
        var plantillas = repoPlantilla.TraerPlantillasPorId(idUsuario).ToList();

        Assert.Empty(plantillas);
        Console.WriteLine($"El usuario {idUsuario} no tiene plantillas, como se esperaba.");

    }






    [Fact]
    public void TraerFutbolistasPorTipo()
    {
        uint idTipo = 3;
        int idEquipos = 1;

        var futbolistas = repoPlantilla.traerFutbolistasXTipoXEquipo(idTipo, idEquipos).ToList();

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
            idEquipos = 1,
            CantidadJugadores = 0
        };

        var id = repoPlantilla.altaPlantilla(plantilla);

        Assert.True(id > 0);
    }

    [Fact]

    public void ObtenerPlantillaCompleta()
    {

        uint idPlantillaExistente = 1;
        var plantillaObtenida = repoPlantilla.ObtenerPlantillaCompleta(idPlantillaExistente);

        Assert.NotNull(plantillaObtenida);
        var jsonPlantilla = JsonSerializer.Serialize(
            plantillaObtenida,
            new JsonSerializerOptions { WriteIndented = true } // Hace que el JSON sea legible
        );

        Console.WriteLine("--- Datos Completos de la Plantilla Recibida ---");
        Console.WriteLine(jsonPlantilla);
        Console.WriteLine("-------------------------------------------------");   //ESTO ES EN CASO DE QUERER VER EL RESULTADO COMPLETO SE NECESITA SYSTEM.TEXT.JSON
        Assert.Equal(idPlantillaExistente, plantillaObtenida.idPlantillas);
    }
    [Fact]
    public void AltaPlantillaTitular()
    {
    // Arrange
    uint idPlantilla = 1;
    uint idFutbolista = 10;

    // Actuar
    repoPlantilla.AltaJugadorEnPlantilla(idPlantilla, idFutbolista, true);
    var plantilla = repoPlantilla.PlantillasPorIdPlantilla(idPlantilla);

    // Assert
    var jugadorEncontrado = plantilla.Titulares
        .Any(f => f.IdFutbolista == idFutbolista);

    Assert.True(jugadorEncontrado, "❌ El alta del jugador en la plantilla titular falló.");
    Console.WriteLine($"✅ El futbolista {idFutbolista} fue agregado correctamente a la plantilla {idPlantilla} como titular.");
}
}