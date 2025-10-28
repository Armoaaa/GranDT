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

    private void Reguistrarse_Click(object sender, EventArgs e)
    {
        Reguistro ReguistroForm = new Reguistro();
        ReguistroForm.Show();
        this.Hide();

        ReguistroForm.FormClosed += (s, args) => this.Close();
    }

    private void Login_Click(object sender, EventArgs e)
    {
        Login loginForm = new Login();
        loginForm.Show();
        this.Hide();

        loginForm.FormClosed += (s, args) => this.Close();
    }

    private void Inicio_Load(object sender, EventArgs e)
    {

    }
}
