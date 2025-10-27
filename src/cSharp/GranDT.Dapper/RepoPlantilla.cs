using System.Data;
using Dapper;
using GranDT.Core;
using GranDT.Core.Repos;

namespace GranDT.Dapper;

public class RepoPlantilla : Repo, IRepoPlantilla
{
    public RepoPlantilla(IDbConnection conexion) : base(conexion) { }

    private static readonly string _spAltaPlantilla = "altaPlantilla";
    private static readonly string _spActualizarPlantilla = "actualizarPlantilla";
    private static readonly string _spEliminarPlantilla = "eliminarPlantilla";
    private static readonly string _spAltaPlantillaTitular = "altaPlantillaTitular";
    private static readonly string _spActualizarPlantillaTitular = "actualizarPlantillaTitular";

    public int altaPlantilla(Plantilla plantilla)
    {
        var p = new DynamicParameters();
        p.Add("UnPresupuesto", plantilla.Presupuesto);
        p.Add("UnNombrePlantilla", plantilla.NombrePlantilla);
        p.Add("UnidUsuario", plantilla.IdUsuario);
        p.Add("UnCantidadJugadores", plantilla.CantidadJugadores);
        p.Add("AIidPlantilla", dbType: DbType.Int32, direction: ParameterDirection.Output);

        _conexion.Execute(
            _spAltaPlantilla,
            p,
            commandType: CommandType.StoredProcedure
        );

        return p.Get<int>("AIidPlantilla");
    }

    public int actualizarPlantilla(Plantilla plantilla)
    {
        var p = new DynamicParameters();
        p.Add("UnidPlantillas", plantilla.idPlantillas);
        p.Add("UnidUsuario", plantilla.IdUsuario);
        p.Add("UnPresupuesto", plantilla.Presupuesto);
        p.Add("UnNombrePlantilla", plantilla.NombrePlantilla);
        p.Add("UnCantidadJugadores", plantilla.CantidadJugadores);

        return _conexion.Execute(
            _spActualizarPlantilla,
            p,
            commandType: CommandType.StoredProcedure
        );
    }

    public int eliminarPlantilla(Plantilla plantilla)
    {
        var p = new DynamicParameters();
        p.Add("UnidPlantillas", plantilla.idPlantillas);
        p.Add("UnidUsuario", plantilla.IdUsuario);

        return _conexion.Execute(
            _spEliminarPlantilla,
            p,
            commandType: CommandType.StoredProcedure
        );
    }

    public int altaJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular)
    {
        var p = new DynamicParameters();
        p.Add("UnidFutbolista", futbolista.IdFutbolista);
        p.Add("UnidPlantillas", plantilla.idPlantillas);
        p.Add("UnesTitular", esTitular ? 1 : 0);

        return _conexion.Execute(
            _spAltaPlantillaTitular,
            p,
            commandType: CommandType.StoredProcedure
        );
    }

    public int actualizarJugador(Plantilla plantilla, Futbolista futbolista, bool esTitular)
    {
        var p = new DynamicParameters();
        p.Add("UnidFutbolista", futbolista.IdFutbolista);
        p.Add("UnidPlantillas", plantilla.idPlantillas);
        p.Add("UnesTitular", esTitular ? 1 : 0);

        return _conexion.Execute(
            _spActualizarPlantillaTitular,
            p,
            commandType: CommandType.StoredProcedure
        );
    }
}