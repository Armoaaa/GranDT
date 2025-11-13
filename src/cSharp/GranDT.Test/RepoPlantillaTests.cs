using GranDT.Core;
using GranDT.Core.Repos;
using GranDT.Dapper;
using System.Text.Json;
using System.Linq;
using Dapper;
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
        var plantillas = repoPlantilla.PlantillasPorIdUsuario(idUsuario).ToList();

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
        var plantillas = repoPlantilla.PlantillasPorIdUsuario(idUsuario).ToList();

        Assert.Empty(plantillas);
        Console.WriteLine($"El usuario {idUsuario} no tiene plantillas, como se esperaba.");

    }

    [Fact]
    public void TraerFutbolistasPorTipo()
    {
        uint IdTipo = 3;
        int idEquipos = 1;

        var futbolistas = repoPlantilla.traerFutbolistasXTipoXEquipo(IdTipo, idEquipos).ToList();

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
    public void AltaPlantillaSuplente()
    {
        uint idPlantillas = 1; 
        uint idFutbolista = 11;
        bool esTitular = false;
        try
        {
            repoPlantilla.AltaJugadorEnPlantilla(idPlantillas, idFutbolista, esTitular);

            var plantilla = repoPlantilla.PlantillasPorIdPlantilla(idPlantillas);

            Assert.NotNull(plantilla);

            Console.WriteLine($"El futbolista {idFutbolista} fue agregado correctamente a la plantilla {idPlantillas} como SUPLENTE.");

        }
        finally
        {}
    }

    [Fact]
    public void ActualizarPlantilla_ModificaCamposCorrectamente()
    {

        var plantilla = new Plantilla
        {
            idPlantillas = 1,
            IdUsuario = 4,
            NombrePlantilla = "Super Boca",
            Presupuesto = 2000,
            CantidadJugadores = 18
        };
        repoPlantilla.actualizarPlantilla(plantilla);

    }
    [Fact]
    public void ActualizarPlantillaTitular_CambiaATitularASuplente()
    {

        uint idPlantillas = 1;
        uint idFutbolista = 10;
        bool esTitular = false;

        repoPlantilla.ActualizarJugadorEnPlantilla(idPlantillas, idFutbolista, esTitular);

    }
    [Fact]
    public void TraerFutbolistasParaSeleccion()
    {
    // Arrange
        int idTipo = 2;
        int idEquipos = 1;

    // Act
        var futbolistas = repoPlantilla.TraerFutbolistasParaSeleccion(idTipo, idEquipos).ToList();

        Assert.NotEmpty(futbolistas);
    }

}
    
