using System.Data;
using MySqlConnector;

namespace GranDT.Winf
{
    public static class Conexion
    {
        private static readonly string _cadena = "Server=localhost;User ID=5to_agbd;Password=Trigg3rs!;Database=5to_GranDT;";
        private static IDbConnection? _conexion;

        public static IDbConnection GetConexion()
        {
            if (_conexion == null)
            {
                _conexion = new MySqlConnection(_cadena);
            }
            return _conexion;
        }
    }
}
