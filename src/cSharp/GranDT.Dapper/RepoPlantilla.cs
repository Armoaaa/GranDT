using Dapper;
using System.Data;
using System.Linq;
using GranDT.Core;
using GranDT.Core.Repos;

namespace GranDT.Dapper;

public class RepoPlantilla : Repo, IRepoPlantilla
{
    public RepoPlantilla(IDbConnection conexion) : base(conexion) { }

    // Versión simple para compatibilidad: ejecuta el SP de alta (sin recuperar OUT)
    public int AltaPlantilla(Plantilla plantilla)
    {
        // Llamamos al SP como StoredProcedure para mantener consistencia
        return _conexion.Execute("altaPlantilla", new
        {
            UnPresupuesto = plantilla.Presupuesto,
            UnNombrePlantilla = plantilla.NombrePlantilla,
            UnidUsuario = plantilla.IdUsuario,
            UnCantidadJugadores = (plantilla.Titulares?.Count() ?? 0) + (plantilla.Suplentes?.Count() ?? 0)
        }, commandType: CommandType.StoredProcedure);
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

        // Ejecutamos el procedimiento almacenado como StoredProcedure (necesario para parámetros OUT)
        _conexion.Execute("altaPlantilla", parameters, commandType: CommandType.StoredProcedure);

        var id = parameters.Get<int>("AIidPlantilla");
        // actualizar el objeto con el id generado
        plantilla.idPlantillas = (uint)id;
        return id;
    }

    public int ActualizarPlantilla(Plantilla plantilla)
    {
        return _conexion.Execute("actualizarPlantilla", new
        {
            UnidPlantillas = plantilla.idPlantillas,
            UnidUsuario = plantilla.IdUsuario,
            UnPresupuesto = plantilla.Presupuesto,
            UnNombrePlantilla = plantilla.NombrePlantilla,
            UnCantidadJugadores = (plantilla.Titulares?.Count() ?? 0) + (plantilla.Suplentes?.Count() ?? 0)
        }, commandType: CommandType.StoredProcedure);
    }

    public int EliminarPlantilla(Plantilla plantilla)
    {
        return _conexion.Execute("eliminarPlantilla", new { UnidPlantillas = plantilla.idPlantillas, UnidUsuario = plantilla.IdUsuario }, commandType: CommandType.StoredProcedure);
    }

    public int AltaJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular)
    {
        // Usamos el SP que inserta en PlantillaTitular
        return _conexion.Execute("altaPlantillaTitular", new { UnidFutbolista = futbolista.IdFutbolista, UnidPlantillas = plantilla.idPlantillas, UnesTitular = esTitular ? 1 : 0 }, commandType: CommandType.StoredProcedure);
    }

    public int ActualizarJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular)
    {
        return _conexion.Execute("actualizarPlantillaTitular", new { UnidFutbolista = futbolista.IdFutbolista, UnidPlantillas = plantilla.idPlantillas, UnesTitular = esTitular ? 1 : 0 }, commandType: CommandType.StoredProcedure);
    }

    public int EliminarJugador(Plantilla plantilla, Futbolista futbolista)
    {
        return _conexion.Execute("eliminarPlantillaTitular", new { UnidFutbolista = futbolista.IdFutbolista, UnidPlantillas = plantilla.idPlantillas }, commandType: CommandType.StoredProcedure);
    }

    public Plantilla? GetDetallePlantilla(uint idPlantillas)
    {
        using var multi = _conexion.QueryMultiple("GetDetallePlantilla", new { IdPlantilla = idPlantillas }, commandType: CommandType.StoredProcedure);

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
