using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GranDT.Dapper;
using GranDT.Core;
using Dapper;

namespace GranDT.Winf
{
    public partial class AltaFutbolista : Form
    {
        public AltaFutbolista()
        {
            InitializeComponent();
        }

        private void AltaFutbolista_Load(object sender, EventArgs e)
        {
            try
            {
                var conexion = Conexion.GetConexion();
                if (conexion.State != ConnectionState.Open) conexion.Open();

                // cargar tipos (id, nombre)
                var sqlTipos = @"SELECT idTipo, Nombre FROM Tipo ORDER BY Nombre";
                var tipos = conexion.Query(sqlTipos).Select(r => new { Id = (int)r.idTipo, Nombre = (string)r.Nombre }).ToList();
                cboTipo.DisplayMember = "Nombre";
                cboTipo.ValueMember = "Id";
                cboTipo.DataSource = tipos;

                // cargar equipos (id, nombre)
                var sqlEquipos = @"SELECT idEquipos, Nombre FROM Equipos ORDER BY Nombre";
                var equipos = conexion.Query(sqlEquipos).Select(r => new { Id = (int)r.idEquipos, Nombre = (string)r.Nombre }).ToList();
                cboEquipo.DisplayMember = "Nombre";
                cboEquipo.ValueMember = "Id";
                cboEquipo.DataSource = equipos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos/equipos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            var nombre = txtNombre.Text?.Trim();
            var apellido = txtApellido.Text?.Trim();
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            {
                MessageBox.Show("Debe completar nombre y apellido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var futbolista = new Futbolista
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Apodo = txtApodo.Text?.Trim(),
                    FechadeNacimiento = dateNacimiento.Value,
                    Cotizacion = decimal.TryParse(txtCotizacion.Text, out var c) ? c : null,
                    IdTipo = cboTipo.SelectedValue is int t ? (uint)t : 0,
                    IdEquipos = cboEquipo.SelectedValue is int eId ? eId : 0
                };

                var conexion = Conexion.GetConexion();
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                var repo = new RepoFutbolista(conexion);
                var id = repo.altaFutbolista(futbolista);

                MessageBox.Show($"Futbolista creado id: {id}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear futbolista: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
