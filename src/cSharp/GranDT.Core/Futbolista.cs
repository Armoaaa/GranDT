namespace GranDT.Core;

public class Futbolista
{
    public uint IdFutbolista { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string? Apodo { get; set; }
    public DateTime? FechadeNacimiento { get; set; }
    public decimal? Cotizacion { get; set; }
    public uint IdEquipo { get; set; }
    public uint IdTipo { get; set; }
    public Equipos? Equipos { get; set; }
    public Tipo? Tipo { get; set; }
    public IEnumerable<Puntuacion> Puntuaciones { get; set; } = [];

}