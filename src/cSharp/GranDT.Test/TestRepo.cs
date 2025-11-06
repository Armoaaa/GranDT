using System.Data;
using MySqlConnector;

namespace GranDT.Test;

/// <summary>

/// </summary>
public class TestRepo
{
    protected readonly IDbConnection _conexion;
    private static readonly string _cadena = "Server=localhost;User ID=root;Password=root!;Database=5to_GranDT;";
    //private static readonly string _cadena = "Server=localhost;User ID=5to_agbd;Password=Trigg3rs!;Database=5to_GranDT;";

    public TestRepo() => _conexion = new MySqlConnection(_cadena);
    public TestRepo(string cadena) => _conexion = new MySqlConnection(cadena);
}
