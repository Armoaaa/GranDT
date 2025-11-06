using System.Data;
using MySqlConnector;

namespace GranDT.Test;

/// <summary>
/// Provee una conexión MySql para tests de integración locales.
/// Usa la cadena por defecto o puede recibir una diferente.
/// </summary>
public class TestRepo
{
    protected readonly IDbConnection _conexion;
    private const string _cadena = "Server=localhost;User ID=5to_agbd;Password=Trigg3rs!;Database=5to_GranDT;";

    public TestRepo() => _conexion = new MySqlConnection(_cadena);
    public TestRepo(string cadena) => _conexion = new MySqlConnection(cadena);
}
