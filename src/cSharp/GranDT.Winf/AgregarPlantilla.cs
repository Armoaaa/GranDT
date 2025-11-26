using GranDT.Core;
using GranDT.Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GranDT.Winf
{
    public partial class AgregarPlantilla : Form
    {
        private readonly IDbConnection _conexion;
        private readonly RepoPlantilla _repoPlantilla;

        public AgregarPlantilla()
        {
            InitializeComponent();

            // Inicializar conexión y repo
            _conexion = Conexion.GetConexion();
            _repoPlantilla = new RepoPlantilla(_conexion);
            Confirmar.FlatAppearance.BorderSize = 0;
            Cancelar.FlatAppearance.BorderSize = 0;


            // Cargar equipos en el ComboBox
            CargarEquipos();
        }

        private void CargarEquipos()
        {
            try
            {
                var equipos = _repoPlantilla.TraerEquipos()?.ToList() ?? new List<Equipos>();

                if (equipos.Any())
                {
                    SEquipos.DisplayMember = "Nombre";
                    SEquipos.ValueMember = "idEquipos";
                    SEquipos.DataSource = equipos;
                }
                else
                {
                    MessageBox.Show("No hay equipos disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar equipos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos
                if (string.IsNullOrWhiteSpace(TNombre.Text))
                {
                    MessageBox.Show("El nombre de la plantilla es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                // Crear plantilla
                var plantilla = new Plantilla
                {
                    NombrePlantilla = TNombre.Text.Trim(),
                    Presupuesto = 65000000,
                    IdUsuario = (uint)Login.SesionActual.IdUsuario,
                    idEquipos = (int)(uint)SEquipos.SelectedValue,
                    CantidadJugadores = 18 // Siempre 18 como solicitado
                };

                // Dar de alta la plantilla
                _repoPlantilla.altaPlantilla(plantilla);

                // Volver a selección de plantilla
                VolverASeleccionPlantilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear plantilla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            // Volver a selección de plantilla sin guardar
            VolverASeleccionPlantilla();
        }

        private void VolverASeleccionPlantilla()
        {
            var seleccionForm = new SeleccionPlantilla();
            seleccionForm.Show();
            this.Hide();
            seleccionForm.FormClosed += (s, args) => this.Close();
        }

        private void AgregarPlantilla_Load(object sender, EventArgs e)
        {

        }
    }
}
