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
    public partial class SeleccionPlantilla : Form
    {
        public SeleccionPlantilla()
        {
            InitializeComponent();
            var screen = Screen.PrimaryScreen.WorkingArea;
            this.Width = (int)(screen.Width * 0.6);  // 60% del ancho de pantalla
            this.Height = (int)(screen.Height * 0.7); // 70% del alto de pantalla
        }

        private void Equipos_Load(object sender, EventArgs e)
        {

        }
        private void Cerrar_Click(object sender, EventArgs e)
        {
            Inicio inicioForm = new Inicio();
            inicioForm.Show();
            this.Hide();

            inicioForm.FormClosed += (s, args) => this.Close();
        }
        private void Crear_Click(object sender, EventArgs e)
        {
            AgregarPlantilla agregarForm = new AgregarPlantilla();
            agregarForm.Show();
            this.Hide();

            agregarForm.FormClosed += (s, args) => this.Close();
        }

        private void Confirmar_Click(object sender, EventArgs e)
        {
            EdicionPlantilla edicionPlantillaFrom = new EdicionPlantilla();
            edicionPlantillaFrom.Show();
            this.Hide();

            edicionPlantillaFrom.FormClosed += (s, args) => this.Close();
        }

    }
}
