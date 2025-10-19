namespace GranDT.Winf;

public partial class Inicio : Form
{
    public Inicio()
    {
        InitializeComponent();
        var screen = Screen.PrimaryScreen.WorkingArea;
        this.Width = (int)(screen.Width * 0.6);  // 60% del ancho de pantalla
        this.Height = (int)(screen.Height * 0.7); // 70% del alto de pantalla
    }
}
