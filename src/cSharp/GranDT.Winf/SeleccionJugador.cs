using Dapper;
using GranDT.Core;
using GranDT.Core.Repos;
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

namespace GranDT.Winf
{
    public partial class SeleccionJugador : Form
    {
        public SeleccionJugador()
        {
            InitializeComponent();

            // Llama a la función de carga con los valores uint
            // Puedes obtener estos valores de otros controles o variables
            uint idEquipo = 100; // Ejemplo para el primer parámetro uint
            uint jornada = 2;    // Ejemplo para el segundo parámetro uint

            CargarJugadoresDesdeSP(idEquipo, jornada);
        }

        // --- Nuevo método de Carga ---
        public void CargarJugadoresDesdeSP(uint idEquipo, uint jornada)
        {
            IDbConnection conexion = null;
            try
            {
                conexion = Conexion.GetConexion();

                // 1. Nombre del Stored Procedure en MySQL
                string spName = "SP_ObtenerJugadoresPorEquipoYJornada";

                // 2. Definición de Parámetros
                // Los nombres (e.g., p_idEquipo, p_jornada) DEBEN 
                // coincidir con los nombres de los parámetros definidos en tu Stored Procedure.
                var parametros = new
                {
                    p_idEquipo = idEquipo, // Dapper automáticamente maneja uint
                    p_jornada = jornada    // Dapper automáticamente maneja uint
                };

                // Asegúrate de abrir la conexión si GetConexion() no la abre
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                // 3. Ejecución del SP con Dapper
                var listaJugadores = conexion.Query<Futbolista>(
                    sql: spName,
                    param: parametros,
                    commandType: CommandType.StoredProcedure // Indica que es un SP
                ).ToList();

                // 4. Asignar los Resultados al DataGridView
                // Reemplaza 'dataGr' (asumo que es el nombre incompleto de tu DataGridView)
                // por el nombre correcto, ej: 'dataGridView1'
                dataGridView1.DataSource = listaJugadores;
            }
            catch (MySqlConnector.MySqlException myEx)
            {
                // Manejo de errores específicos de MySQL (ej. SP no existe, error de sintaxis)
                MessageBox.Show($"Error de MySQL: {myEx.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Es crucial cerrar la conexión si la abriste
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        private void Confirmar_Click(object sender, EventArgs e)
        {
            // Lógica para confirmar selección...
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lógica del DataGridView...
        }
    }
}