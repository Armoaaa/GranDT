namespace GranDT.Core.Repos;

public interface IRepoPlantilla
{
    int altaPlantilla(Plantilla plantilla);
    int actualizarPlantilla(Plantilla plantilla);
    int eliminarPlantilla(Plantilla plantilla);

    int altaJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular);
    int actualizarJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular);

    // traer titulares o suplentes
    IEnumerable<Plantilla> PlantillasPorIdUsuario(uint idUsuario);
    IEnumerable<Plantilla> PlantillasPorIdPlantilla(uint idPlantilla);
    IEnumerable<Equipos> TraerEquipos();
    IEnumerable<Futbolista> traerFutbolistasXTipoXEquipo(uint idTipo, int idEquipos);
    Plantilla? ObtenerPlantillaCompleta(uint idPlantillas);
    int AltaJugadorEnPlantilla(uint idPlantillas, uint idFutbolista, bool esTitular);
    int ActualizarJugadorEnPlantilla(uint idPlantillas, uint idFutbolista, bool esTitular);
}

