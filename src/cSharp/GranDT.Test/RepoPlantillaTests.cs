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
    public void TraerPlantillasPorEmail()
    {
        string email = "asd@attttt.com";
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
    public void CheckearSinPlantilla()
    {
        string email = "juanperez@example.com";
        // Actuar
        var plantillas = repoPlantilla.TraerPlantillasPorEmail(email).ToList();

        Assert.Empty(plantillas);
        Console.WriteLine($"El usuario {email} no tiene plantillas, como se esperaba.");

    }






    [Fact]
    public void TraerFutbolistasPorTipo()
    {
        uint idTipo = 3;
        uint idEquipo = 1;

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


        var plantilla = new Plantilla
        {
            Presupuesto = 1000000m,
            NombrePlantilla = "Test Plantilla Update",
            IdUsuario = 1,
            CantidadJugadores = 0
        };


        plantilla.idPlantillas = (uint)repoPlantilla.altaPlantilla(plantilla);

        // Modificar valores
        plantilla.Presupuesto = 2000000m;
        plantilla.NombrePlantilla = "Test Plantilla Updated";

        var resultado = repoPlantilla.actualizarPlantilla(plantilla);

        Assert.True(resultado > 0);


    }

    [Fact]
    public void EliminarPlantilla_EliminaCorrectamente()
    {


        var plantilla = new Plantilla
        {
            Presupuesto = 1000000m,
            NombrePlantilla = "Test Plantilla Delete",
            IdUsuario = 4,
            CantidadJugadores = 0
        };

        plantilla.idPlantillas = (uint)repoPlantilla.altaPlantilla(plantilla);

        var resultado = repoPlantilla.eliminarPlantilla(plantilla);

        Assert.True(resultado > 0);

    }

    [Fact]
    public void AltaJugador_AgregaJugadorAPlantilla()
    {
        var plantilla = new Plantilla
        {
            Presupuesto = 1000000m,
            NombrePlantilla = "Test Plantilla Jugadores",
            IdUsuario = 1,
            CantidadJugadores = 0
        };



        plantilla.idPlantillas = (uint)repoPlantilla.altaPlantilla(plantilla);

        var futbolista = new Futbolista { IdFutbolista = 2 };
        bool esTitular = true;

        var resultado = repoPlantilla.altaJugador(plantilla, futbolista, esTitular);

        Assert.True(resultado > 0);

    }

    [Fact]
    public void ModificaEstadoTitular()
    {

        var plantilla = new Plantilla
        {
            Presupuesto = 1000000m,
            NombrePlantilla = "Test Plantilla Update Jugador",
            IdUsuario = 1,
            CantidadJugadores = 0
        };


        plantilla.idPlantillas = (uint)repoPlantilla.altaPlantilla(plantilla);

        var futbolista = new Futbolista { IdFutbolista = (uint)1 };

        repoPlantilla.altaJugador(plantilla, futbolista, true);

        var resultado = repoPlantilla.actualizarJugador(plantilla, futbolista, false);

        Assert.True(resultado > 0);

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
}
