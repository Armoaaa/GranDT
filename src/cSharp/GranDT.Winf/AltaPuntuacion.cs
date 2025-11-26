using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GranDT.Dapper;
using GranDT.Core;
using Dapper;

namespace GranDT.Winf
{
    public partial class AltaPuntuacion : Form
    {
        public AltaPuntuacion()
        {
            InitializeComponent();
        }

        private void AltaPuntuacion_Load(object sender, EventArgs e)
        {
            try
            {
                var conexion = Conexion.GetConexion();
                if (conexion.State != ConnectionState.Open) conexion.Open();

                var sql = @"SELECT idFutbolista, Nombre, Apellido FROM Futbolista ORDER BY Apellido, Nombre";
                var lista = conexion.Query(sql).Select(r => new
                {
                    Id = (int)r.idFutbolista,
                    Display = $"{r.Apellido}, {r.Nombre} ({r.idFutbolista})"
                }).ToList();

                cboFutbolista.DisplayMember = "Display";
                cboFutbolista.ValueMember = "Id";
                cboFutbolista.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar futbolistas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (cboFutbolista.SelectedItem == null || !(cboFutbolista.SelectedValue is int))
            {
                MessageBox.Show("Seleccione un futbolista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idFutbolista = (uint)(int)cboFutbolista.SelectedValue;

            if (!byte.TryParse(txtFechaNro.Text, out var fechaNro))
            {
                MessageBox.Show("Fecha nro inválida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPuntos.Text, out var puntos))
            {
                MessageBox.Show("Puntos inválidos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var puntuacion = new Puntuacion
                {
                    FechaNro = fechaNro,
                    Puntos = puntos
                };

                var conexion = Conexion.GetConexion();
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                var repo = new RepoFutbolista(conexion);
                var id = repo.altaPuntuacion(idFutbolista, puntuacion);

                MessageBox.Show($"Puntuación creada id: {id}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear puntuación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
