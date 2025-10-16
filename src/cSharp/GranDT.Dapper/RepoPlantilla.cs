using Dapper;
using GranDT.Core.Data;

namespace GranDT.Core.Repos;

public class RepoPlantilla : IRepoPlantilla
{
    private readonly DapperContext _context;

    public RepoPlantilla(DapperContext context)
    {
        _context = context;
    }

    public int AltaPlantilla(Plantilla plantilla)
    {
        using var conn = _context.CreateConnection();
        return conn.Execute("CALL AltaPlantilla(@Presupuesto, @NombrePlantilla, @IdUsuario, @CantidadJugadores);", plantilla);
    }

    public int ActualizarPlantilla(Plantilla plantilla)
    {
        using var conn = _context.CreateConnection();
        return conn.Execute("CALL ActualizarPlantilla(@IdPlantillas, @IdUsuario, @Presupuesto, @NombrePlantilla, @CantidadJugadores);", plantilla);
    }

    public int EliminarPlantilla(Plantilla plantilla)
    {
        using var conn = _context.CreateConnection();
        return conn.Execute("CALL EliminarPlantilla(@IdPlantillas, @IdUsuario);", plantilla);
    }

    public int AltaJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular)
    {
        using var conn = _context.CreateConnection();
        return conn.Execute("CALL AltaPlantillaJugador(@IdFutbolista, @IdPlantilla, @EsTitular);",
            new { IdFutbolista = futbolista.IdFutbolista, IdPlantilla = plantilla.idPlantillas, EsTitular = esTitular });
    }

    public int ActualizarJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular)
    {
        using var conn = _context.CreateConnection();
        return conn.Execute("CALL ActualizarPlantillaJugador(@IdFutbolista, @IdPlantilla, @EsTitular);",
            new { IdFutbolista = futbolista.IdFutbolista, IdPlantilla = plantilla.idPlantillas, EsTitular = esTitular });
    }

    public int EliminarJugador(Plantilla plantilla, Futbolista futbolista)
    {
        using var conn = _context.CreateConnection();
        return conn.Execute("CALL EliminarPlantillaJugador(@IdFutbolista, @IdPlantilla);",
            new { IdFutbolista = futbolista.IdFutbolista, IdPlantilla = plantilla.idPlantillas });
    }

    public Plantilla? GetDetallePlantilla(uint idPlantillas)
    {
        using var conn = _context.CreateConnection();
        using var multi = conn.QueryMultiple("CALL GetDetallePlantilla(@IdPlantilla);", new { IdPlantilla = idPlantillas });

        var plantilla = multi.Read<Plantilla>().FirstOrDefault();
        if (plantilla != null)
        {
            plantilla.Titulares = multi.Read<Futbolista>().ToList();
            plantilla.Suplentes = multi.Read<Futbolista>().ToList();
        }

        return plantilla;
    }
}
