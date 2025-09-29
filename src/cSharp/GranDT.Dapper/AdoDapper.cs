using System.Data;
using Dapper;
using MySqlConnector;
using GranDT.Core;



namespace GranDT.Dapper;

public class AdoDapper : IAdo
{
    //Defino una asociacion a un objeto que sabe conectarse a una BD.
    private readonly IDbConnection _conexion;

    public AdoDapper(IDbConnection conexion) => this._conexion = conexion;

    //Este constructor usa por defecto la cadena para un conector MySQL
    public AdoDapper(string cadena) => _conexion = new MySqlConnection(cadena);
}
