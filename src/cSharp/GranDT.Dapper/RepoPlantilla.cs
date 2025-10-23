using Dapper;
using System.Data;
using System.Linq;
using GranDT.Dapper;

namespace GranDT.Core.Repos;

public class RepoPlantilla : Repo, IRepoPlantilla
{
    public RepoPlantilla(IDbConnection conexion) : base(conexion) { }

    public int AltaPlantilla(Plantilla plantilla)
    {
    return _conexion.Execute("CALL AltaPlantilla(@Presupuesto, @NombrePlantilla, @IdUsuario, @CantidadJugadores);", plantilla);
    }

    // Implementación que cumple la firma de la interfaz IRepoPlantilla
    public int altaPlantilla(Plantilla plantilla)
    {
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
    _conexion.Execute("CALL altaPlantilla(@UnPresupuesto, @UnNombrePlantilla, @UnidUsuario, @UnCantidadJugadores, @AIidPlantilla);", parameters);

        var id = parameters.Get<int>("AIidPlantilla");
        // actualizar el objeto con el id generado
        plantilla.idPlantillas = (uint)id;
        return id;
    }

    public int ActualizarPlantilla(Plantilla plantilla)
    {
    return _conexion.Execute("CALL ActualizarPlantilla(@IdPlantillas, @IdUsuario, @Presupuesto, @NombrePlantilla, @CantidadJugadores);", plantilla);
    }

    public int EliminarPlantilla(Plantilla plantilla)
    {
    return _conexion.Execute("CALL EliminarPlantilla(@IdPlantillas, @IdUsuario);", plantilla);
    }

    public int AltaJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular)
    {
        return _conexion.Execute("CALL AltaPlantillaJugador(@IdFutbolista, @IdPlantilla, @EsTitular);",
            new { IdFutbolista = futbolista.IdFutbolista, IdPlantilla = plantilla.idPlantillas, EsTitular = esTitular });
    }

    public int ActualizarJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular)
    {
        return _conexion.Execute("CALL ActualizarPlantillaJugador(@IdFutbolista, @IdPlantilla, @EsTitular);",
            new { IdFutbolista = futbolista.IdFutbolista, IdPlantilla = plantilla.idPlantillas, EsTitular = esTitular });
    }

    public int EliminarJugador(Plantilla plantilla, Futbolista futbolista)
    {
        return _conexion.Execute("CALL EliminarPlantillaJugador(@IdFutbolista, @IdPlantilla);",
            new { IdFutbolista = futbolista.IdFutbolista, IdPlantilla = plantilla.idPlantillas });
    }

    public Plantilla? GetDetallePlantilla(uint idPlantillas)
    {
        using var multi = _conexion.QueryMultiple("CALL GetDetallePlantilla(@IdPlantilla);", new { IdPlantilla = idPlantillas });

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
