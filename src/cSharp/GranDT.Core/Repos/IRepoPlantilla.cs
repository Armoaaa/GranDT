namespace GranDT.Core.Repos;

public interface IRepoPlantilla
{
    int altaPlantilla(Plantilla plantilla);
    int actualizarPlantilla(Plantilla plantilla);
    int eliminarPlantilla(Plantilla plantilla);

    int altaJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular);
    int actualizarJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular);

    // traer titulares o suplentes
    IEnumerable<Plantilla> TraerPlantillasPorEmail(string email);
    IEnumerable<Equipos> TraerEquipos();
    IEnumerable<Futbolista> traerFutbolistasXTipoXEquipo(uint idTipo, uint idEquipo);
    Plantilla? ObtenerPlantillaCompleta(uint id);
}
