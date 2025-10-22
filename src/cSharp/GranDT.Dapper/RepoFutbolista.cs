using Dapper;
using GranDT.Core.Data;
using System.Collections.Generic;

namespace GranDT.Core.Repos;

public class RepoFutbolista : IRepoFutbolista
{
    private readonly DapperContext _context;
    
    

    public RepoFutbolista(DapperContext context)
    {
        _context = context;
    }

    public int AltaTipo(string nombre)
    {
        using var conn = _context.CreateConnection();
        return conn.Execute("CALL AltaTipo(@Nombre);", new { Nombre = nombre });
    }

    public int AltaEquipo(string nombre)
    {
        using var conn = _context.CreateConnection();
        return conn.Execute("CALL AltaEquipo(@Nombre);", new { Nombre = nombre });
    }

    public int AltaFutbolista(Futbolista futbolista)
    {
        using var conn = _context.CreateConnection();
        return conn.Execute("CALL AltaFutbolista(@Nombre, @Apellido, @Apodo, @FechaNacimiento, @Cotizacion, @IdTipo, @IdEquipo);",
            futbolista);
    }

    public int AltaPuntuacion(Futbolista futbolista, Puntuacion puntuacion)
    {
        using var conn = _context.CreateConnection();
        return conn.Execute("CALL AltaPuntuacion(@FechaNro, @Puntuacion, @IdFutbolista);",
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
