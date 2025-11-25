namespace GranDT.Winf;

public partial class Inicio : Form
{
    public Inicio()
    {
        InitializeComponent();

    }

    


    private void Inicio_Load(object sender, EventArgs e)
    {

    }

    private void Reguistrarse_Click_1(object sender, EventArgs e)
    {
        Reguistro ReguistroForm = new Reguistro();
        ReguistroForm.Show();
        this.Hide();

        ReguistroForm.FormClosed += (s, args) => this.Close();
    }

    private void Login_Click_1(object sender, EventArgs e)
    {
        Login loginForm = new Login();
        loginForm.Show();
        this.Hide();

        loginForm.FormClosed += (s, args) => this.Close();
    }
}
