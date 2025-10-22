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
    public partial class Equipos : Form
    {
        public Equipos()
        {
            InitializeComponent();
            var screen = Screen.PrimaryScreen.WorkingArea;
            this.Width = (int)(screen.Width * 0.6);  // 60% del ancho de pantalla
            this.Height = (int)(screen.Height * 0.7); // 70% del alto de pantalla
        }

        private void Equipos_Load(object sender, EventArgs e)
        {

        }

        private void Confirmar_Click(object sender, EventArgs e)
        {
            {
                Plantilla PlantillaForm = new Plantilla();
                PlantillaForm.Show();
                this.Hide();

                // Cuando el Login se cierre, cerrar también este formulario
                PlantillaForm.FormClosed += (s, args) => this.Close();
            }
        }
    }
}
