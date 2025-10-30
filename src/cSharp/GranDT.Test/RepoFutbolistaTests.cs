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
    public void AltaFutbolista_RespetaTriggersYDevuelveId()
    {
        var futbolista = new Futbolista
        {
            Nombre = "Test",
            Apellido = "Jugador",
            Apodo = "TJugador",
            FechadeNacimiento = new DateTime(2000,1,1),
            Cotizacion = 1000m,
            IdEquipo = 1, 
            IdTipo = 1   
        };



        var id = repoFutbolista.altaFutbolista(futbolista);

        Assert.True(id > 0);
    }

    [Fact]
    public void AltaPuntuacion()
    {

        uint idFutbolista = 4;
        var puntuacion = new Puntuacion { FechaNro = 3, Puntos = 8.5m };

        var id = repoFutbolista.altaPuntuacion(idFutbolista, puntuacion);

        Assert.True(id > 0);
    }
    //

    [Fact]

    public void AgregarFutbolistaAPlantilla_CreaPlantillaYAgregaJugador()
    {

        string nombrePlantilla = "Test Plantilla";
        decimal presupuesto = 1000000m;
        bool esTitular = true;


        var resultado = repoFutbolista.AgregarFutbolistaAPlantilla(
            (uint)1,
            nombrePlantilla,
            presupuesto,
            (uint)4,
            esTitular
        );

        Assert.True(resultado > 0);

    }
}
