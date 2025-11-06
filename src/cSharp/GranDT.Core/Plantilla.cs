namespace GranDT.Core;

public class Plantilla
{
    public uint idPlantillas { get; set; }
    public Decimal? Presupuesto { get; set; }
    public string? NombrePlantilla { get; set; }
    public uint IdUsuario { get; set; }
    public byte CantidadJugadores { get; set; }
    public int idEquipos { get; set; }
    public Usuario? Usuario { get; set; }
    public Equipos? Equipos { get; set; }
    public Futbolista? Futbolista { get; set; }
    public IEnumerable<Futbolista> Titulares { get; set; } = [];
    public IEnumerable<Futbolista> Suplentes { get; set; } = [];
}

