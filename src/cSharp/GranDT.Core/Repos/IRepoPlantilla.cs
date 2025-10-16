namespace GranDT.Core.Repos;

public interface IRepoPlantilla
{
    // Plantilla básica
    int AltaPlantilla(Plantilla plantilla);
    int ActualizarPlantilla(Plantilla plantilla);
    int EliminarPlantilla(Plantilla plantilla);

    // Jugadores en la plantilla
    int AltaJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular);
    int ActualizarJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular);
    int EliminarJugador(Plantilla plantilla, Futbolista futbolista);

    // Traer titulares o suplentes
    IEnumerable<Futbolista> GetTitulares(Plantilla plantilla);
    IEnumerable<Futbolista> GetSuplentes(Plantilla plantilla);
}
