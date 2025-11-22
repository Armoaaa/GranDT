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

            // Si se pasó una plantilla seleccionada, podemos cargar sus datos aquí
            if (_idPlantillaSeleccionada.HasValue)
            {
                try
                {
                    var conexion = Conexion.GetConexion();
                    if (conexion.State != System.Data.ConnectionState.Open)
                    {
                        conexion.Open();
                    }
                    
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
                        // Guardamos el id de la plantilla
                        _idPlantillaActual = plantilla.idPlantillas;
                        
                        // Obtener el idEquipos de la plantilla (el SP obtenerPlantillaCompleta no lo devuelve)
                        // Hacemos una consulta directa para obtenerlo
                        if (plantilla.idEquipos == 0)
                        {
                            var sql = @"SELECT idEquipos FROM Plantillas WHERE idPlantillas = @UnidPlantillas";
                            _idEquiposDePlantilla = conexion.QueryFirstOrDefault<int?>(sql, new { UnidPlantillas = _idPlantillaSeleccionada.Value });
                        }
                        else
                        {
                            _idEquiposDePlantilla = plantilla.idEquipos;
                        }
                        
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
            seleccionForm.ShowDialog();

            // Tras cerrar, podrías recargar la plantilla si quieres ver cambios
            // Plantilla_Load(this, EventArgs.Empty);
        }
    }
}
