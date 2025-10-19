namespace GranDT.Core.Repos;

public interface IRepoPlantilla
{

    int altaPlantilla(Plantilla plantilla);
    int actualizarPlantilla(Plantilla plantilla);
    int eliminarPlantilla(Plantilla plantilla);


    int altaJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular);
    int actualizarJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular);
    int eliminarJugador(Plantilla plantilla, Futbolista futbolista);

    // traer titulares o suplentes
    Plantilla? GetDetallePlantilla(uint idPlantillas);

}
