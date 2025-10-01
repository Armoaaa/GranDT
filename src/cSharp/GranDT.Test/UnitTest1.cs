// filepath: GranDT.Tests/AdoDapperTests.cs
using Xunit;
using GranDT.Dapper;

public class AdoDapperTests
{
    [Fact]
    public void AltaTipo_DeberiaCrearTipo()
    {
        var ado = new AdoDapper($"Server=localhost;Database=bd_PokemonRPG;uid=5to_agbd;Password=Trigg3rs!;");
        int id = ado.AltaTipo("Arquero");
        Assert.True(id > 0);
    }
}
