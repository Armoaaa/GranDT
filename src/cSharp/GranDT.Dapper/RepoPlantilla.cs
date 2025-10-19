using Dapper;
using GranDT.Core.Data;
using System.Data;
using System.Linq;

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

    // Implementación que cumple la firma de la interfaz IRepoPlantilla
    public int altaPlantilla(Plantilla plantilla)
    {
        using var conn = _context.CreateConnection();

        var parameters = new DynamicParameters();
        // parámetros de entrada
        parameters.Add("UnPresupuesto", plantilla.Presupuesto);
        parameters.Add("UnNombrePlantilla", plantilla.NombrePlantilla);
        parameters.Add("UnidUsuario", plantilla.IdUsuario);

        // Si no hay propiedad explícita de cantidad, calculamos a partir de las colecciones (o 0)
        var cantidad = 0;
        if (plantilla.Titulares != null)
            cantidad += plantilla.Titulares.Count();
        if (plantilla.Suplentes != null)
            cantidad += plantilla.Suplentes.Count();

        parameters.Add("UnCantidadJugadores", cantidad);

        // parámetro de salida
        parameters.Add("AIidPlantilla", dbType: DbType.Int32, direction: ParameterDirection.Output);

        // Ejecutamos el procedimiento almacenado
        conn.Execute("CALL altaPlantilla(@UnPresupuesto, @UnNombrePlantilla, @UnidUsuario, @UnCantidadJugadores, @AIidPlantilla);", parameters);

        var id = parameters.Get<int>("AIidPlantilla");
        // actualizar el objeto con el id generado
        plantilla.idPlantillas = (uint)id;
        return id;
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

    // Métodos con nombres en minúscula para cumplir la interfaz IRepoPlantilla
    public int actualizarPlantilla(Plantilla plantilla)
    {
        return ActualizarPlantilla(plantilla);
    }

    public int eliminarPlantilla(Plantilla plantilla)
    {
        return EliminarPlantilla(plantilla);
    }

    public int altaJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular)
    {
        return AltaJugador(plantilla, futbolista, esTitular);
    }

    public int actualizarJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular)
    {
        return ActualizarJugador(plantilla, futbolista, esTitular);
    }

    public int eliminarJugador(Plantilla plantilla, Futbolista futbolista)
    {
        return EliminarJugador(plantilla, futbolista);
    }
}
