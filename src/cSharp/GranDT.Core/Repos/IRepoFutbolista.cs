namespace GranDT.Core.Repos;

public interface IRepoFutbolista
{
    int AltaTipo(string nombre);
    int AltaFutbolista(Futbolista futbolista);
    int AltaEquipo(string nombre);
    int AltaPuntuacion(Futbolista futbolista, Puntuacion puntuacion);
    
}
