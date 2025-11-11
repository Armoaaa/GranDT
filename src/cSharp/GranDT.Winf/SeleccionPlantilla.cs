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

namespace GranDT.Winf
{
    public partial class SeleccionPlantilla : Form
    {
        private int? _selectedPlantillaId;

        public SeleccionPlantilla()
        {
            InitializeComponent();
            var screen = Screen.PrimaryScreen.WorkingArea;
            this.Width = (int)(screen.Width * 0.6);  // 60% del ancho de pantalla
            this.Height = (int)(screen.Height * 0.7); // 70% del alto de pantalla
        }

        private void Equipos_Load(object sender, EventArgs e)
        {
            try
            {
                var conexion = Conexion.GetConexion();
                var repo = new RepoPlantilla(conexion);
                // Traer plantillas del usuario en sesión (si no hay sesión, pasará 0)
                var plantillas = repo.PlantillasPorIdUsuario((uint)Login.SesionActual.IdUsuario)?.ToList() ?? new List<Plantilla>();
                if (plantillas.Count == 0)
                {
                    // No hay plantillas para mostrar
                    SPlantilla.DataSource = null;
                    SPlantilla.Items.Clear();
                    SPlantilla.Items.Add("-- Sin plantillas --");
                    SPlantilla.SelectedIndex = 0;
                    return;
                }

                SPlantilla.DisplayMember = nameof(Plantilla.NombrePlantilla);
                SPlantilla.ValueMember = nameof(Plantilla.idPlantillas);
                SPlantilla.DataSource = plantillas;
                // seleccionar el primero por defecto
                if (SPlantilla.Items.Count > 0)
                {
                    SPlantilla.SelectedIndex = 0;
                    if (SPlantilla.SelectedItem is Plantilla p)
                        _selectedPlantillaId = (int)p.idPlantillas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar plantillas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            // Obtener la plantilla seleccionada
            if (SPlantilla.SelectedItem is Plantilla p)
            {
                var idPlantilla = (int)p.idPlantillas;
                // Abrir formulario de edición pasando la id seleccionada
                EdicionPlantilla edicionPlantillaFrom = new EdicionPlantilla(idPlantilla);
                edicionPlantillaFrom.Show();
                this.Hide();

                edicionPlantillaFrom.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una plantilla válida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SPlantilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SPlantilla.SelectedItem is Plantilla p)
            {
                _selectedPlantillaId = (int)p.idPlantillas;
            }
        }
    }
}
