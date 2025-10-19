using System.Data;
using MySqlConnector;

namespace GranDT.Core.Data;

public class DapperContext
{
    private readonly string _connectionString;

    public DapperContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Constructor por defecto: intenta leer la cadena de conexión desde variable de entorno 'GRANDT_CONN' o appsettings.json
    public DapperContext()
    {
        var env = Environment.GetEnvironmentVariable("GRANDT_CONN");
        if (!string.IsNullOrWhiteSpace(env))
        {
            _connectionString = env;
            return;
        }

        throw new InvalidOperationException("No connection string provided. Set GRANDT_CONN environment variable or instantiate DapperContext with a connection string.");
    }

    public IDbConnection CreateConnection()
        => new MySqlConnection(_connectionString);
}
