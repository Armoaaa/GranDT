namespace GranDT.Core.Repos;

public interface IRepoPlantilla
{

    int AltaPlantilla(Plantilla plantilla);
    int ActualizarPlantilla(Plantilla plantilla);
    int EliminarPlantilla(Plantilla plantilla);


    int AltaJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular);
    int ActualizarJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular);
    int EliminarJugador(Plantilla plantilla, Futbolista futbolista);

    // traer titulares o suplentes
    Plantilla? GetDetallePlantilla(uint idPlantillas);

}
