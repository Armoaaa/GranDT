namespace GranDT.Core.Repos;

public interface IRepoFutbolista
{
    int altaTipo(string nombre);
    int altaFutbolista(Futbolista futbolista);
    int altaEquipo(string nombre);
    int altaPuntuacion(uint IdFutbolista, Puntuacion puntuacion);
    (decimal promedio, int cantidadFechas) PromedioFutbolista(uint idFutbolista);
    
}
 