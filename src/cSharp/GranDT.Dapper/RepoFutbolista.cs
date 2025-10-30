using Dapper;
using GranDT.Core;
using GranDT.Core.Repos;
using System.Data;

namespace GranDT.Dapper;

public class RepoFutbolista : Repo, IRepoFutbolista
{
    public RepoFutbolista(IDbConnection conexion) : base(conexion) { }

    public int altaTipo(string nombre)
    {
        var p = new DynamicParameters();
        p.Add("UnNombre", nombre);
        p.Add("AIidTipo", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _conexion.Execute("altaTipo", p, commandType: CommandType.StoredProcedure);

        return p.Get<int>("AIidTipo");
    }

    public int altaEquipo(string nombre)
    {
        var p = new DynamicParameters();
        // El SP altaEquipo tiene el parámetro IN llamado `Nombre`
        p.Add("Nombre", nombre);
        p.Add("AIidEquipo", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _conexion.Execute("altaEquipo", p, commandType: CommandType.StoredProcedure);

        return p.Get<int>("AIidEquipo");
    }

    public int altaFutbolista(Futbolista futbolista)
    {
        var p = new DynamicParameters();
        p.Add("UnNombre", futbolista.Nombre);
        p.Add("UnApellido", futbolista.Apellido);
        p.Add("UnApodo", futbolista.Apodo);
        p.Add("UnFechadeNacimiento", futbolista.FechadeNacimiento);
        p.Add("UnCotizacion", futbolista.Cotizacion);
        p.Add("UnidTipo", futbolista.IdTipo);
        p.Add("UnidEquipos", futbolista.IdEquipo);
        p.Add("AIidFutbolista", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _conexion.Execute("altaFutbolista", p, commandType: CommandType.StoredProcedure);

        return p.Get<int>("AIidFutbolista");
    }

    public int altaPuntuacion(uint IdFutbolista, Puntuacion puntuacion)
    {
        var p = new DynamicParameters();
        p.Add("UnfechaNro", puntuacion.FechaNro);
        p.Add("UnPuntuacion", puntuacion.Puntos);
        p.Add("UnidFutbolista", IdFutbolista);
        p.Add("AIidpuntuacion", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _conexion.Execute("altaPuntuacion", p, commandType: CommandType.StoredProcedure);

        return p.Get<int>("AIidpuntuacion");
    }

    public (decimal promedio, int cantidadFechas) PromedioFutbolista(uint idFutbolista)
    {
        var p = new DynamicParameters();
        p.Add("UnidFutbolista", idFutbolista);

        var result = _conexion.QuerySingle("promedioFutbolista", p, commandType: CommandType.StoredProcedure);
        return (result.PromedioPuntuacion, (int)result.CantidadFechas);
    }

    public int AgregarFutbolistaAPlantilla(uint idUsuario, string nombrePlantilla, decimal presupuesto, uint idFutbolista, bool esTitular)
    {
        var p = new DynamicParameters();
        p.Add("UnidUsuario", idUsuario);
        p.Add("UnNombrePlantilla", nombrePlantilla);
        p.Add("UnPresupuesto", presupuesto);
        p.Add("UnidFutbolista", idFutbolista);
        p.Add("UnesTitular", esTitular ? 1 : 0);

        _conexion.Execute("agregarFutbolistaAPlantilla", p, commandType: CommandType.StoredProcedure);


        return 1;
    }
}
