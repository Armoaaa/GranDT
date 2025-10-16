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

    public IDbConnection CreateConnection()
        => new MySqlConnection(_connectionString);
}
