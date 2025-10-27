namespace GranDT.Core.Repos;

public interface IRepoFutbolista
{
    int altaTipo(string nombre);
    int altaFutbolista(Futbolista futbolista);
    int altaEquipo(string nombre);
    int altaPuntuacion(Futbolista futbolista, Puntuacion puntuacion);
    (decimal promedio, int cantidadFechas) PromedioFutbolista(uint idFutbolista);
    int AgregarFutbolistaAPlantilla(uint idUsuario, string nombrePlantilla, decimal presupuesto, uint idFutbolista, bool esTitular);
}
