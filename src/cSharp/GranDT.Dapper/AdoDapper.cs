using System.Data;
using Dapper;

using GranDT.Core;

namespace GranDT.Dapper;

public class AdoDapper : IAdo
{
    private readonly IDbConnection _conexion;

    public AdoDapper(IDbConnection conexion) => this._conexion = conexion;
    public AdoDapper(string cadena) => _conexion = new MySqlConnection(cadena);

    public int AltaTipo(string nombre)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@Nombre", nombre);
        parametros.Add("@idTipo_generado", dbType: DbType.Int32, direction: ParameterDirection.Output);
        _conexion.Execute("altaTipo", parametros, commandType: CommandType.StoredProcedure);
        return parametros.Get<int>("@idTipo_generado");
    }

    public int AltaEquipo(string nombre)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@Nombre", nombre);
        parametros.Add("@idEquipo_generado", dbType: DbType.Int32, direction: ParameterDirection.Output);
        _conexion.Execute("altaEquipo", parametros, commandType: CommandType.StoredProcedure);
        return parametros.Get<int>("@idEquipo_generado");
    }

    public int AltaFutbolista(string nombre, string apellido, string apodo, DateTime? fechaNacimiento, decimal? cotizacion, int idTipo, int idEquipos)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@Nombre", nombre);
        parametros.Add("@Apellido", apellido);
        parametros.Add("@Apodo", apodo);
        parametros.Add("@FechadeNacimiento", fechaNacimiento);
        parametros.Add("@Cotizacion", cotizacion);
        parametros.Add("@idTipo", idTipo);
        parametros.Add("@idEquipos", idEquipos);
        parametros.Add("@idFutbolista_generado", dbType: DbType.Int32, direction: ParameterDirection.Output);
        _conexion.Execute("altaFutbolista", parametros, commandType: CommandType.StoredProcedure);
        return parametros.Get<int>("@idFutbolista_generado");
    }

    public int AltaUsuario(string nombre, string apellido, string email, DateTime? fechaNacimiento, string contrasena, byte? esAdmin)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@Nombre", nombre);
        parametros.Add("@Apellido", apellido);
        parametros.Add("@Email", email);
        parametros.Add("@FechadeNacimiento", fechaNacimiento);
        parametros.Add("@Contrasena", contrasena);
        parametros.Add("@esAdmin", esAdmin);
        parametros.Add("@idUsuario_generado", dbType: DbType.Int32, direction: ParameterDirection.Output);
        _conexion.Execute("altaUsuario", parametros, commandType: CommandType.StoredProcedure);
        return parametros.Get<int>("@idUsuario_generado");
    }

    public int AltaPlantilla(decimal? presupuesto, string nombrePlantilla, int idUsuario, byte? cantidadJugadores)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@Presupuesto", presupuesto);
        parametros.Add("@NombrePlantilla", nombrePlantilla);
        parametros.Add("@idUsuario", idUsuario);
        parametros.Add("@CantidadJugadores", cantidadJugadores);
        parametros.Add("@idPlantilla_generado", dbType: DbType.Int32, direction: ParameterDirection.Output);
        _conexion.Execute("altaPlantilla", parametros, commandType: CommandType.StoredProcedure);
        return parametros.Get<int>("@idPlantilla_generado");
    }

    public void AltaPlantillaTitular(int idFutbolista, int idPlantillas, byte? esTitular)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@idFutbolista", idFutbolista);
        parametros.Add("@idPlantillas", idPlantillas);
        parametros.Add("@esTitular", esTitular);
        _conexion.Execute("altaPlantillaTitular", parametros, commandType: CommandType.StoredProcedure);
    }

    public void AltaPlantillaSuplente(int idFutbolista, int idPlantillas, byte? esSuplente)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@idFutbolista", idFutbolista);
        parametros.Add("@idPlantillas", idPlantillas);
        parametros.Add("@esSuplente", esSuplente);
        _conexion.Execute("altaPlantillaSuplente", parametros, commandType: CommandType.StoredProcedure);
    }

    public int AltaPuntuacion(byte fechaNro, decimal? puntuacion, int idFutbolista)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@fechaNro", fechaNro);
        parametros.Add("@Puntuacion", puntuacion);
        parametros.Add("@idFutbolista", idFutbolista);
        parametros.Add("@idPuntuacion_generado", dbType: DbType.Int32, direction: ParameterDirection.Output);
        _conexion.Execute("altaPuntuacion", parametros, commandType: CommandType.StoredProcedure);
        return parametros.Get<int>("@idPuntuacion_generado");
    }

    public void ActualizarPlantilla(int idPlantillas, int idUsuario, decimal? presupuesto, string nombrePlantilla, byte? cantidadJugadores)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@idPlantillas", idPlantillas);
        parametros.Add("@idUsuario", idUsuario);
        parametros.Add("@Presupuesto", presupuesto);
        parametros.Add("@NombrePlantilla", nombrePlantilla);
        parametros.Add("@CantidadJugadores", cantidadJugadores);
        _conexion.Execute("actualizarPlantilla", parametros, commandType: CommandType.StoredProcedure);
    }

    public void ActualizarPlantillaTitular(int idFutbolista, int idPlantillas, byte? esTitular)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@idFutbolista", idFutbolista);
        parametros.Add("@idPlantillas", idPlantillas);
        parametros.Add("@esTitular", esTitular);
        _conexion.Execute("actualizarPlantillaTitular", parametros, commandType: CommandType.StoredProcedure);
    }

    public void ActualizarPlantillaSuplente(int idFutbolista, int idPlantillas, byte? esSuplente)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@idFutbolista", idFutbolista);
        parametros.Add("@idPlantillas", idPlantillas);
        parametros.Add("@esSuplente", esSuplente);
        _conexion.Execute("actualizarPlantillaSuplente", parametros, commandType: CommandType.StoredProcedure);
    }

    public void EliminarPlantilla(int idPlantillas, int idUsuario)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@idPlantillas", idPlantillas);
        parametros.Add("@idUsuario", idUsuario);
        _conexion.Execute("eliminarPlantilla", parametros, commandType: CommandType.StoredProcedure);
    }

    public void EliminarPlantillaTitular(int idFutbolista, int idPlantillas)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@idFutbolista", idFutbolista);
        parametros.Add("@idPlantillas", idPlantillas);
        _conexion.Execute("eliminarPlantillaTitular", parametros, commandType: CommandType.StoredProcedure);
    }

    public void EliminarPlantillaSuplente(int idFutbolista, int idPlantillas)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@idFutbolista", idFutbolista);
        parametros.Add("@idPlantillas", idPlantillas);
        _conexion.Execute("eliminarPlantillaSuplente", parametros, commandType: CommandType.StoredProcedure);
    }
}