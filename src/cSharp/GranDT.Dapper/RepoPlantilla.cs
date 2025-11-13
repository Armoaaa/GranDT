using System.Data;
using Dapper;
using GranDT.Core;
using GranDT.Core.Repos;

namespace GranDT.Dapper;

public class RepoPlantilla : Repo, IRepoPlantilla
{
    public RepoPlantilla(IDbConnection conexion) : base(conexion) { }

    private static readonly string _spAltaPlantilla = "altaPlantilla";
    private static readonly string _sptraerFutbolistasParaSeleccion = "traerFutbolistasParaSeleccion";
    private static readonly string _spActualizarPlantilla = "actualizarPlantilla";
    private static readonly string _spEliminarPlantilla = "eliminarPlantilla";
    private static readonly string _spAltaPlantillaTitular = "altaPlantillaTitular";
    private static readonly string _spActualizarPlantillaTitular = "actualizarPlantillaTitular";
    private static readonly string _spPlantillasPorIdUsuario = "plantillasPorIdUsuario";
    private static readonly string _spPlantillasPorIdPlantilla = "plantillasPorIdPlantilla";
    private static readonly string _spTraerEquipos = "traerEquipos";
    private static readonly string _sptraerFutbolistasXTipoXEquipo = "traerFutbolistasXTipoXEquipo";
    private static readonly string _spObtenerPlantillaCompleta = "obtenerPlantillaCompleta";
    

    public int altaPlantilla(Plantilla plantilla)
    {
        var p = new DynamicParameters();
        p.Add("UnPresupuesto", plantilla.Presupuesto);
        p.Add("UnNombrePlantilla", plantilla.NombrePlantilla);
        p.Add("UnidUsuario", plantilla.IdUsuario);
        p.Add("UnidEquipos", plantilla.idEquipos);
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

    public IEnumerable<Plantilla> PlantillasPorIdUsuario(uint idUsuario)
    {
        var p = new DynamicParameters();
        p.Add("UnidUsuario", idUsuario);

        return _conexion.Query<Plantilla>(_spPlantillasPorIdUsuario, p, commandType: CommandType.StoredProcedure);

    }
    public IEnumerable<Plantilla> PlantillasPorIdPlantilla(uint idPlantilla)
    {
        var p = new DynamicParameters();
        p.Add("UnidPlantillas", idPlantilla);

        return _conexion.Query<Plantilla>(_spPlantillasPorIdPlantilla, p, commandType: CommandType.StoredProcedure);

    }

    public IEnumerable<Equipos> TraerEquipos()
    {

        return _conexion.Query<Equipos>(_spTraerEquipos, commandType: CommandType.StoredProcedure);
    }

    public IEnumerable<Futbolista> traerFutbolistasXTipoXEquipo(uint idTipo, int idEquipos)
    {
        var p = new DynamicParameters();
        p.Add("UnidTipo", idTipo);
        p.Add("UndEquipos", idEquipos);

        return _conexion.Query<Futbolista, Equipos, Tipo, Futbolista>(
            _sptraerFutbolistasXTipoXEquipo,
            (f, e, t) =>
            {
                f.Equipos = e;
                f.Tipo = t;
                return f;
            },
            p,
            splitOn: "IdEquipos,IdTipoTipo",
            commandType: CommandType.StoredProcedure
        ).ToList();
    }
    public IEnumerable<Futbolista> TraerFutbolistasParaSeleccion(int IdTipo, int idEquipos)
    {
        var p = new DynamicParameters();
        p.Add("UnidTipo", IdTipo);
        p.Add("UnidEquipos", idEquipos);

        return _conexion.Query<Futbolista>(
            _sptraerFutbolistasParaSeleccion,
            p,
            commandType: CommandType.StoredProcedure
        ).ToList();
    }
    public Plantilla? ObtenerPlantillaCompleta(uint idPlantillas)
    {
        using (var multi = _conexion.QueryMultiple(_spObtenerPlantillaCompleta, new { UnidPlantillas = idPlantillas }))
        {

            var plantilla = multi.ReadSingleOrDefault<Plantilla>();
            if (plantilla is not null)
            {
                plantilla.Titulares = multi.Read<Futbolista>().ToList();
                plantilla.Suplentes = multi.Read<Futbolista>().ToList();

                // Nota: Podrías añadir más .Read() aquí si el SP devuelve más conjuntos (Ej: Usuario)
            }

            return plantilla;
        }

    }
    public int AltaJugadorEnPlantilla(uint idPlantillas, uint idFutbolista, bool esTitular)
    {
        var p = new DynamicParameters();
        p.Add("UnidFutbolista", idFutbolista);
        p.Add("UnidPlantillas", idPlantillas);
        p.Add("UnesTitular", esTitular ? 1 : 0);

        return _conexion.Execute(
            _spAltaPlantillaTitular,
            p,
            commandType: CommandType.StoredProcedure
        );
    }
    public int ActualizarJugadorEnPlantilla(uint idPlantillas, uint idFutbolista, bool esTitular)
    {
        var p = new DynamicParameters();
        p.Add("UnidFutbolista", idFutbolista);
        p.Add("UnidPlantillas", idPlantillas);
        p.Add("UnesTitular", esTitular ? 1 : 0); // Mapeo de bool a TINYINT (1 o 0)

        return _conexion.Execute(
            _spActualizarPlantillaTitular,
            p,
            commandType: CommandType.StoredProcedure
        );
    }

}

  
