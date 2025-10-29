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
    private static readonly string _spTraerPlantillasPorEmail = "traerPlantillasPorEmail";
    private static readonly string _spTraerEquipos = "traerEquipos";
    private static readonly string _sptraerFutbolistasXTipoXEquipo = "traerFutbolistasXTipoXEquipo";
    private static readonly string _spPlantillaCompleta = "traerPlantillaCompleta"; 

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

    public IEnumerable<Plantilla> TraerPlantillasPorEmail(string email)
    {
        var p = new DynamicParameters();
        p.Add("UnEmail", email);

        return _conexion.Query<Plantilla>(_spTraerPlantillasPorEmail, p, commandType: CommandType.StoredProcedure) ;
        
    }

    public IEnumerable<Equipos> TraerEquipos()
    {
        return _conexion.Query<Equipos>(_spTraerEquipos, commandType: CommandType.StoredProcedure);
    }

    public IEnumerable<Futbolista> traerFutbolistasXTipoXEquipo(uint idTipo, uint idEquipo)
    {
        var p = new DynamicParameters();
        p.Add("UnIdTipo", idTipo);
        p.Add("UnIdEquipo", idEquipo);

        return _conexion.Query<Futbolista, Equipos, Tipo, Futbolista>(
            _sptraerFutbolistasXTipoXEquipo,
            (f, e, t) =>
            {
                f.Equipos = e;
                f.Tipo = t;
                return f;
            },
            p,
            splitOn: "IdEquipoEquipo,IdTipoTipo",
            commandType: CommandType.StoredProcedure
        ).ToList();
    }
// Asumo que tienes una query o Stored Procedure que hace 3 SELECTs:
// 1. SELECT de la Plantilla
// 2. SELECT de los Futbolistas Titulares
// 3. SELECT de los Futbolistas Suplentes


    public Plantilla? ObtenerPlantillaCompleta(uint idPlantilla)
    {
    // 1. Ejecución de QueryMultiple
    // Se utiliza 'using' para asegurar que la conexión se cierre correctamente después de la lectura.
    using (var multi = _conexion.QueryMultiple(_spPlantillaCompleta, new { id = idPlantilla }))
    {
        // 2. Lectura del objeto principal: Plantilla
        // Se usa ReadSingleOrDefault<Plantilla>() porque esperamos 0 o 1 Plantilla principal.
        var plantilla = multi.ReadSingleOrDefault<Plantilla>();

        // 3. Mapeo de Colecciones Relacionadas (si la plantilla existe)
        if (plantilla is not null)
        {
            // Asumo que el segundo SELECT trae a los futbolistas titulares
            // Se usa Read<Futbolista>() para obtener una colección.
            plantilla.Titulares = multi.Read<Futbolista>().ToList(); 
            
            // Asumo que el tercer SELECT trae a los futbolistas suplentes
            // Se usa Read<Futbolista>() para obtener otra colección.
            plantilla.Suplentes = multi.Read<Futbolista>().ToList();
            
            // Nota: Podrías añadir más .Read() aquí si el SP devuelve más conjuntos (Ej: Usuario)
        }
        
        // 4. Retorno
        return plantilla;
    }
}


}