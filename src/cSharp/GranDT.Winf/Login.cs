using GranDT.Dapper;

namespace GranDT.Winf
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            var screen = Screen.PrimaryScreen.WorkingArea;
            this.Width = (int)(screen.Width * 0.6);  // 60% del ancho de pantalla
            this.Height = (int)(screen.Height * 0.7); // 70% del alto de pantalla
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Reguistrarse_Click(object sender, EventArgs e)
        {
            // Validar que los emails coincidan
            if (EmailT.Text != EmailC.Text)
            {
                MessageBox.Show("Los emails no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Validar que las contraseñas coincidan
            if (ContrasenaT.Text != ContrasenaC.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(EmailT.Text) || string.IsNullOrWhiteSpace(ContrasenaT.Text))
            {
                MessageBox.Show("Debe completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Intentar loguear
            var conexion = Conexion.GetConexion();
            var repoUsuario = new RepoUsuario(conexion);
            var loginExitoso = repoUsuario.loginUsuario(EmailT.Text, ContrasenaT.Text);
            if (loginExitoso == null)
            
            {
                MessageBox.Show("No se pudo iniciar sesión. Verifique sus credenciales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Si el login es exitoso, almacenar sesión y avanzar al formulario de selección de plantilla
            SeleccionPlantilla EquiposForm = new SeleccionPlantilla();
            // Guardar IdUsuario en la sesión para que otros formularios puedan usarlo
            SesionActual.IdUsuario = (int)loginExitoso.IdUsuario;
            EquiposForm.Show();
            this.Hide();
            EquiposForm.FormClosed += (s, args) => this.Close();
        }
        public static class SesionActual
        {
            public static int IdUsuario { get; set; }
        }
        // var usuario = _repositorio.loginUsuario(email, contrasena);
        //if (usuario != null)
        //{
        //    SesionActual.IdUsuario = usuario.IdUsuario;
        //    SesionActual.Nombre = usuario.Nombre;
        //}
        private void Atras_Click(object sender, EventArgs e)
        {
            Inicio InicioForm = new Inicio();
            InicioForm.Show();
            this.Hide();

            // Cuando el Login se cierre, cerrar también este formulario
            InicioForm.FormClosed += (s, args) => this.Close();
        }

        
    }
}
