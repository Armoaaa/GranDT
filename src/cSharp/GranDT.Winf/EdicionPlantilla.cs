using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GranDT.Winf
{
    public partial class EdicionPlantilla : Form
    {
        private int? _idPlantillaSeleccionada;
        private int? _idEquiposDePlantilla;
        private uint? _idPlantillaActual;

        public EdicionPlantilla()
        {
            InitializeComponent();
            Confirmar.FlatAppearance.BorderSize = 0;
        }

        // Constructor que recibe la id de la plantilla seleccionada
        public EdicionPlantilla(int idPlantilla) : this()
        {
            _idPlantillaSeleccionada = idPlantilla;
        }

        private void Plantilla_Load(object sender, EventArgs e)
        {
            // Validar que el usuario esté logueado
            if (Login.SesionActual.IdUsuario <= 0)
            {
                MessageBox.Show("No hay una sesión de usuario activa. Por favor, inicie sesión primero.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Volver al login
                var loginForm = new Login();
                loginForm.Show();
                this.Hide();
                loginForm.FormClosed += (s, args) => this.Close();
                return;
            }

            try
            {
                var conexion = Conexion.GetConexion();
                if (conexion.State != System.Data.ConnectionState.Open)
                {
                    conexion.Open();
                }

                // Determinar si el usuario es admin para mostrar las opciones de alta
                try
                {
                    var sqlAdmin = @"SELECT esAdmin FROM Usuario WHERE idUsuario = @IdUsuario";
                    var adminVal = conexion.QueryFirstOrDefault<int?>(sqlAdmin, new { IdUsuario = Login.SesionActual.IdUsuario });
                    var esAdmin = adminVal.HasValue && adminVal.Value == 1;

                    btnAltaFutbolista.Visible = esAdmin;
                    btnAltaFutbolista.Enabled = esAdmin;
                    btnAltaEquipo.Visible = esAdmin;
                    btnAltaEquipo.Enabled = esAdmin;
                    btnAltaPuntuacion.Visible = esAdmin;
                    btnAltaPuntuacion.Enabled = esAdmin;
                }
                catch
                {
                    // Si falla la consulta, mantener ocultas las opciones
                    btnAltaFutbolista.Visible = false;
                    btnAltaEquipo.Visible = false;
                    btnAltaPuntuacion.Visible = false;
                }

                // Si se pasó una plantilla seleccionada, podemos cargar sus datos aquí
                if (_idPlantillaSeleccionada.HasValue)
                {
                    // Verificar que la plantilla pertenece al usuario logueado
                    var sqlVerificacion = @"SELECT idUsuario FROM Plantillas WHERE idPlantillas = @UnidPlantillas";
                    var idUsuarioPlantilla = conexion.QueryFirstOrDefault<int?>(sqlVerificacion, new { UnidPlantillas = _idPlantillaSeleccionada.Value });

                    if (!idUsuarioPlantilla.HasValue || idUsuarioPlantilla.Value != Login.SesionActual.IdUsuario)
                    {
                        MessageBox.Show("No tiene permisos para editar esta plantilla. Solo puede editar sus propias plantillas.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // Volver a selección de plantilla
                        var seleccionForm = new SeleccionPlantilla();
                        seleccionForm.Show();
                        this.Hide();
                        seleccionForm.FormClosed += (s, args) => this.Close();
                        return;
                    }

                    var repo = new GranDT.Dapper.RepoPlantilla(conexion);
                    var plantilla = repo.ObtenerPlantillaCompleta((uint)_idPlantillaSeleccionada.Value);
                    if (plantilla != null)
                    {

                        _idPlantillaActual = plantilla.idPlantillas;

                        if (plantilla.idEquipos == 0)
                        {
                            var sql = @"SELECT idEquipos FROM Plantillas WHERE idPlantillas = @UnidPlantillas";
                            _idEquiposDePlantilla = conexion.QueryFirstOrDefault<int?>(sql, new { UnidPlantillas = _idPlantillaSeleccionada.Value });
                        }
                        else
                        {
                            _idEquiposDePlantilla = plantilla.idEquipos;
                        }

                        // Set jersey image according to team id
                        try
                        {
                            Image teamShirt = Properties.Resources.Remera; // default
                            var teamId = _idEquiposDePlantilla ?? 0;
                            if (teamId == 1)
                            {
                                teamShirt = Properties.Resources.Remera; // team 1
                            }
                            else if (teamId == 2)
                            {
                                // resource available is Remera2
                                teamShirt = Properties.Resources.Remera2; // team 2
                            }
                            else
                            {
                                // team 3 and above use Remera3
                                teamShirt = Properties.Resources.Remera3;
                            }

                            // apply to all position picture boxes if they exist
                            var pbs = new PictureBox[] {
                                Delantero1, Delantero2, Delantero3,
                                Medio1, Medio2, Medio3,
                                Defensa1, Defensa2, Defensa3, Defensa4,
                                arquero,
                                Suplente1, Suplente2, Suplente3, Suplente4, Suplente5, Suplente6, Suplente7
                            };

                            foreach (var pb in pbs)
                            {
                                if (pb != null)
                                {
                                    pb.Image = teamShirt;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // if resources missing, ignore and keep default images
                            Console.WriteLine($"Error asignando imagen de remera: {ex.Message}");
                        }

                        // Mapear Titulares y Suplentes a los listboxes
                        try
                        {
                            lstTitulares.Items.Clear();
                            lstSuplentes.Items.Clear();

                            decimal totalCotizacion = 0m;

                            if (plantilla.Titulares != null)
                            {
                                foreach (var f in plantilla.Titulares)
                                {
                                    lstTitulares.Items.Add($"{f.Apellido}, {f.Nombre} ({f.IdFutbolista})");
                                    if (f.Cotizacion.HasValue) totalCotizacion += f.Cotizacion.Value;
                                }
                            }

                            if (plantilla.Suplentes != null)
                            {
                                foreach (var f in plantilla.Suplentes)
                                {
                                    lstSuplentes.Items.Add($"{f.Apellido}, {f.Nombre} ({f.IdFutbolista})");
                                    if (f.Cotizacion.HasValue) totalCotizacion += f.Cotizacion.Value;
                                }
                            }

                            lblTotalCotizacion.Text = $"Total cotización: {totalCotizacion:N2}";

                            // presupuesto fijo 65,000,000
                            decimal presupuestoFijo = 65000000m;
                            var restante = presupuestoFijo - totalCotizacion;
                            lblPresupuestoRestante.Text = $"Presupuesto restante: {restante:N2}";
                            if (restante < 0)
                            {
                                lblPresupuestoRestante.ForeColor = Color.Red;
                            }
                            else
                            {
                                lblPresupuestoRestante.ForeColor = Color.Black;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al mapear jugadores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Aquí puedes mapear los datos de plantilla a los controles del formulario
                        // Ejemplo (si existen controles): txtNombre.Text = plantilla.NombrePlantilla;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la plantilla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void Delantero1_Click(object sender, EventArgs e)
        {
            OpenSeleccionJugador(4u, false);
        }

        private void Delantero2_Click(object sender, EventArgs e)
        {
            OpenSeleccionJugador(4u, false);
        }

        private void Delantero3_Click(object sender, EventArgs e)
        {
            OpenSeleccionJugador(4u, false);
        }

        private void Medio1_Click(object sender, EventArgs e)
        {
            OpenSeleccionJugador(3u, false);
        }

        private void Medio2_Click(object sender, EventArgs e)
        {
            OpenSeleccionJugador(3u, false);
        }

        private void Medio3_Click(object sender, EventArgs e)
        {
            OpenSeleccionJugador(3u, false);
        }

        private void Defensa1_Click(object sender, EventArgs e)
        {
            OpenSeleccionJugador(2u, false);
        }

        private void Defensa2_Click(object sender, EventArgs e)
        {
            OpenSeleccionJugador(2u, false);
        }

        private void Defensa3_Click(object sender, EventArgs e)
        {
            OpenSeleccionJugador(2u, false);
        }

        private void Defensa4_Click(object sender, EventArgs e)
        {
            OpenSeleccionJugador(2u, false);
        }

        private void arquero_Click(object sender, EventArgs e)
        {
            OpenSeleccionJugador(1u, false);
        }

        private void Suplente1_Click(object sender, EventArgs e)
        {
            // Para suplentes permitimos seleccionar de cualquier tipo
            OpenSeleccionJugador(0u, true);
        }

        private void Suplente2_Click(object sender, EventArgs e)
        {
            OpenSeleccionJugador(0u, true);
        }

        private void Suplente3_Click(object sender, EventArgs e)
        {
            OpenSeleccionJugador(0u, true);
        }

        private void Suplente4_Click(object sender, EventArgs e)
        {
            OpenSeleccionJugador(0u, true);
        }

        private void Suplente5_Click(object sender, EventArgs e)
        {
            OpenSeleccionJugador(0u, true);
        }

        private void Suplente6_Click(object sender, EventArgs e)
        {
            OpenSeleccionJugador(0u, true);
        }

        private void Suplente7_Click(object sender, EventArgs e)
        {
            OpenSeleccionJugador(0u, true);
        }

        private void Confirmar_Click(object sender, EventArgs e)
        {

            SeleccionPlantilla ReguistroForm = new SeleccionPlantilla();
            ReguistroForm.Show();
            this.Hide();

            ReguistroForm.FormClosed += (s, args) => this.Close();
        
        }

        // Alta helpers (admin only)
        private void AltaFutbolista_Click(object sender, EventArgs e)
        {
            using var form = new AltaFutbolista();
            form.ShowDialog();
        }

        // Designer wired name for the button
        private void btnAltaFutbolista_Click(object sender, EventArgs e)
        {
            AltaFutbolista_Click(sender, e);
        }

        private void AltaEquipo_Click(object sender, EventArgs e)
        {
            using var form = new AltaEquipo();
            form.ShowDialog();
        }

        private void AltaPuntuacion_Click(object sender, EventArgs e)
        {
            using var form = new AltaPuntuacion();
            form.ShowDialog();
        }

        // Helper que abre el formulario de selección de jugador pasando tipo y equipo desde la plantilla
        private void OpenSeleccionJugador(uint idTipo, bool esSuplente)
        {
            if (!_idEquiposDePlantilla.HasValue || !_idPlantillaActual.HasValue)
            {
                MessageBox.Show("No se ha cargado la plantilla o falta el equipo asociado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si idTipo == 0 -> solicitamos todos los tipos (la lógica en SeleccionJugador debe soportar idTipo==0)
            var seleccionForm = new SeleccionJugador(idTipo, _idEquiposDePlantilla.Value, _idPlantillaActual.Value, esSuplente);
            var result = seleccionForm.ShowDialog();
            if (result == DialogResult.OK)
            {

                Plantilla_Load(this, EventArgs.Empty);
            }

            // Tras cerrar, podrías recargar la plantilla si quieres ver cambios
            // Plantilla_Load(this, EventArgs.Empty);
        }
    }
}
