namespace GranDT.Core.Repos;

public interface IRepoFutbolista
{
    int altaTipo(string nombre);
    int altaFutbolista(Futbolista futbolista);
    int altaEquipo(string nombre);
    int altaPuntuacion(Futbolista futbolista, Puntuacion puntuacion);
    
}
