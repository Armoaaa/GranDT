using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GranDT.Dapper;
using GranDT.Core;
using GranDT.Core.Repos;

namespace GranDT.Winf
{
    public partial class Reguistro : Form
    {
        //DateTime fecha;
        public Reguistro()
        {
            InitializeComponent();
            var screen = Screen.PrimaryScreen.WorkingArea;
            this.Width = (int)(screen.Width * 0.6);  // 60% del ancho de pantalla
            this.Height = (int)(screen.Height * 0.7); // 70% del alto de pantalla
        }

        private void Reguistro_Load(object sender, EventArgs e)
        {

            //fecha.Year.ToString ("1990");
            //NacimientoT.Text = fecha.ToString("___" + "-__"+"-__");
        }

        private void Reguistrarse_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(NombreT.Text) ||
                string.IsNullOrWhiteSpace(ApellidoT.Text) ||
                string.IsNullOrWhiteSpace(EmailT.Text) ||
                string.IsNullOrWhiteSpace(MaskFecha.Text) ||
                string.IsNullOrWhiteSpace(ContrasenaT.Text))

            {
                MessageBox.Show("Debe completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
            // Validar formato de fecha yyyy-MM-dd
            if (!DateTime.TryParseExact(MaskFecha.Text, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime fechaNacimiento))
            {
                MessageBox.Show("La fecha debe estar en formato yyyy-MM-dd.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Validar email básico
            if (!EmailT.Text.Contains("@") || !EmailT.Text.Contains("."))
            {
                MessageBox.Show("El email no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Crear usuario y registrar
            var usuario = new Usuario
            {
                Nombre = NombreT.Text,
                Apellido = ApellidoT.Text,
                Email = EmailT.Text,
                FechadeNacimiento = fechaNacimiento,
                Contrasena = ContrasenaT.Text,
                esAdmin = false
            };
            var conexion = Conexion.GetConexion();
            var repoUsuario = new RepoUsuario(conexion);
            var id = repoUsuario.AltaUsuario(usuario);
            if (id <= 0)
            {
                MessageBox.Show("No se pudo registrar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Si el registro es exitoso, avanzar al formulario de Equipos
            SeleccionPlantilla EquiposForm = new SeleccionPlantilla();
            EquiposForm.Show();
            this.Hide();
            EquiposForm.FormClosed += (s, args) => this.Close();
        }

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

