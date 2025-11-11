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

            // Guarda la conexión para usarla en otros métodos
            _conexion = Conexion.GetConexion();
            _repoPlantilla = new RepoPlantilla(_conexion);

            // Cargar los datos al iniciar el formulario (ejemplo)
            // Asegúrate que tu DataGridView se llama 'dataGridView1'
            CargarJugadores(100, 2); // Valores de ejemplo para los uint
        }

        // Nuevo método para ejecutar el SP y llenar el DataGridView
        public void CargarJugadores(uint valor1, uint valor2)
        {
            try
            {
                // **1. Nombre del Stored Procedure en MySQL**
                // Reemplaza "SP_ObtenerJugadores" con el nombre real de tu SP
                string spName = "SP_ObtenerJugadores";

                // **2. Definición de Parámetros**
                // Crea un objeto anónimo para pasar los parámetros. 
                // Los nombres de las propiedades (e.g., Parametro1, Parametro2)
                // deben coincidir con los nombres de los parámetros definidos en tu Stored Procedure de MySQL.
                var parametros = new
                {
                    Parametro1 = valor1, // Corresponde al primer parámetro uint
                    Parametro2 = valor2  // Corresponde al segundo parámetro uint
                };

                // **3. Ejecución del SP con Dapper**
                // Usamos Query<Jugador> para obtener una lista de objetos 'Jugador'.
                var listaJugadores = _conexion.Query<Jugador>(
                    sql: spName,
                    param: parametros, // Pasamos el objeto con los parámetros
                    commandType: CommandType.StoredProcedure // ¡FUNDAMENTAL! Indica que es un SP
                ).ToList(); // Convertimos el resultado a una Lista

.
                dataGridView1.DataSource = listaJugadores;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar jugadores: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Manejo de errores (ej. loggear la excepción)
            }
        }

        // ... (Tus otros métodos como Confirmar_Click)
    }
}