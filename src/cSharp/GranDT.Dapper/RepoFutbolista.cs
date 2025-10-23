using Dapper;
using GranDT.Dapper;
using System.Collections.Generic;
using System.Data;

namespace GranDT.Core.Repos;

public class RepoFutbolista : Repo, IRepoFutbolista
{
    public RepoFutbolista(IDbConnection conexion) : base(conexion) { }

    public int AltaTipo(string nombre)
    {
    return _conexion.Execute("CALL AltaTipo(@Nombre);", new { Nombre = nombre });
    }

    public int AltaEquipo(string nombre)
    {
    return _conexion.Execute("CALL AltaEquipo(@Nombre);", new { Nombre = nombre });
    }

    public int AltaFutbolista(Futbolista futbolista)
    {
        return _conexion.Execute("CALL AltaFutbolista(@Nombre, @Apellido, @Apodo, @FechaNacimiento, @Cotizacion, @IdTipo, @IdEquipo);",
            futbolista);
    }

    public int AltaPuntuacion(Futbolista futbolista, Puntuacion puntuacion)
    {
      return _conexion.Execute("CALL AltaPuntuacion(@FechaNro, @Puntuacion, @IdFutbolista);",
          new { FechaNro = puntuacion.FechaNro, Puntuacion = puntuacion.Puntos, IdFutbolista = futbolista.IdFutbolista });
    }

    // Métodos minúscula para cumplir la interfaz IRepoFutbolista
    public int altaTipo(string nombre)
    {
        return AltaTipo(nombre);
    }

    public int altaFutbolista(Futbolista futbolista)
    {
        return AltaFutbolista(futbolista);
    }

    public int altaEquipo(string nombre)
    {
        return AltaEquipo(nombre);
    }

    public int altaPuntuacion(Futbolista futbolista, Puntuacion puntuacion)
    {
        return AltaPuntuacion(futbolista, puntuacion);
    }
}
