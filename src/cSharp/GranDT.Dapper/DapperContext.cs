using System.Data;
using MySqlConnector;

namespace GranDT.Core.Data;

public class DapperContext
{
    // Cadena por defecto simplificada según tu ejemplo.
    private readonly string _connectionString = "Server=localhost;User ID=root;Password=root;Database=5to_rosita_fresita;";

    public DapperContext() { }

    // Permite pasar una cadena de conexión alternativa si se desea.
    public DapperContext(string connectionString)
    {
        if (!string.IsNullOrWhiteSpace(connectionString))
            _connectionString = connectionString;
    }

    // Versión mínima: crea y devuelve una MySqlConnection usando la cadena.
    public IDbConnection CreateConnection()
        => new MySqlConnection(_connectionString);
}
