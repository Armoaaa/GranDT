using System;
using System.Data;
using System.Windows.Forms;
using GranDT.Dapper;

namespace GranDT.Winf
{
    public partial class AltaEquipo : Form
    {
        public AltaEquipo()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            var nombre = txtNombre.Text?.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Debe ingresar un nombre de equipo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var conexion = Conexion.GetConexion();
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                var repo = new RepoFutbolista(conexion);
                var id = repo.altaEquipo(nombre);

                MessageBox.Show($"Equipo creado con id: {id}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear equipo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}