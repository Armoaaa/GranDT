using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GranDT.Winf
{
    public partial class EdicionPlantilla : Form
    {
        private int? _idPlantillaSeleccionada;

        public EdicionPlantilla()
        {
            InitializeComponent();
            var screen = Screen.PrimaryScreen.WorkingArea;
            this.Width = (int)(screen.Width * 0.6);  // 60% del ancho de pantalla
            this.Height = (int)(screen.Height * 0.7); // 70% del alto de pantalla
        }

        // Constructor que recibe la id de la plantilla seleccionada
        public EdicionPlantilla(int idPlantilla) : this()
        {
            _idPlantillaSeleccionada = idPlantilla;
        }

        private void Plantilla_Load(object sender, EventArgs e)
        {
            // Si se pasó una plantilla seleccionada, podemos cargar sus datos aquí
            if (_idPlantillaSeleccionada.HasValue)
            {
                try
                {
                    var conexion = Conexion.GetConexion();
                    var repo = new GranDT.Dapper.RepoPlantilla(conexion);
                    var plantilla = repo.ObtenerPlantillaCompleta((uint)_idPlantillaSeleccionada.Value);
                    if (plantilla != null)
                    {
                        // Aquí puedes mapear los datos de plantilla a los controles del formulario
                        // Ejemplo (si existen controles): txtNombre.Text = plantilla.NombrePlantilla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la plantilla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }




        private void Delantero1_Click(object sender, EventArgs e)
        {

        }

        private void Delantero2_Click(object sender, EventArgs e)
        {

        }

        private void Delantero3_Click(object sender, EventArgs e)
        {

        }

        private void Medio1_Click(object sender, EventArgs e)
        {

        }

        private void Medio2_Click(object sender, EventArgs e)
        {

        }

        private void Medio3_Click(object sender, EventArgs e)
        {

        }

        private void Defensa1_Click(object sender, EventArgs e)
        {

        }

        private void Defensa2_Click(object sender, EventArgs e)
        {

        }

        private void Defensa3_Click(object sender, EventArgs e)
        {

        }

        private void Defensa4_Click(object sender, EventArgs e)
        {

        }

        private void arquero_Click(object sender, EventArgs e)
        {

        }

        private void Suplente1_Click(object sender, EventArgs e)
        {

        }

        private void Suplente2_Click(object sender, EventArgs e)
        {

        }

        private void Suplente3_Click(object sender, EventArgs e)
        {

        }

        private void Suplente4_Click(object sender, EventArgs e)
        {

        }

        private void Suplente5_Click(object sender, EventArgs e)
        {

        }

        private void Suplente6_Click(object sender, EventArgs e)
        {

        }

        private void Suplente7_Click(object sender, EventArgs e)
        {

        }

        private void Confirmar_Click(object sender, EventArgs e)
        {

        }
    }
}
