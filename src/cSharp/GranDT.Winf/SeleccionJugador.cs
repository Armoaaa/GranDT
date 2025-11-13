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
    private uint _idTipo;
    private int _idEquipos;
    private uint _idPlantilla;
    private bool _esSuplente;
        public SeleccionJugador() : this(2, 1, 1, false)
        {
        }

        // Constructor que recibe los filtros (tipo, equipo), la plantilla destino y si es suplente
        public SeleccionJugador(uint idTipo, int idEquipos, uint idPlantilla = 1, bool esSuplente = false)
        {
            InitializeComponent();

            _idTipo = idTipo;
            _idEquipos = idEquipos;
            _idPlantilla = idPlantilla;
            _esSuplente = esSuplente;

            // Cargar el grid y el listado
            CargarJugadoresDesdeSP(_idTipo, _idEquipos);
            CargarListadoFutbolistasParaSeleccion(_idTipo, _idEquipos);
        }
        public void CargarJugadoresDesdeSP(uint IdTipo, int idEquipos)
        {
            IDbConnection? conexion = null;
            try
            {
                conexion = Conexion.GetConexion();
                string sp = "traerFutbolistasXTipoXEquipo";

                var parametros = new
                {
                    UnIdtipo = IdTipo,
                    UnidEquipos = idEquipos
                };

                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                var listaJugadores = conexion.Query<Futbolista>(
                    sql: sp,
                    param: parametros,
                    commandType: CommandType.StoredProcedure
                ).ToList();

                dataGridView1.DataSource = listaJugadores;
            }
            catch (MySqlConnector.MySqlException myEx)
            {
                MessageBox.Show($"Error de MySQL: {myEx.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        // NOTA: Los controles ya existen en el Designer (`FutbolistaListado` y `Confirmar`).

        // Carga sólo el Nombre Completo (resultado del SP traerFutbolistasParaSeleccion)
        private void CargarListadoFutbolistasParaSeleccion(uint IdTipo, int idEquipos)
        {
            IDbConnection? conexion = null;
            try
            {
                conexion = Conexion.GetConexion();
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                // Si IdTipo == 0 -> buscamos todos los tipos para el equipo (suplente)
                List<string> listaNombres;
                if (IdTipo == 0)
                {
                    var sql = @"SELECT CONCAT(Apellido, ', ', Nombre) AS NombreCompleto FROM Futbolista WHERE idEquipos = @UnidEquipos ORDER BY Apellido, Nombre";
                    listaNombres = conexion.Query<string>(sql, new { UnidEquipos = idEquipos }).ToList();
                }
                else
                {
                    string sp = "traerFutbolistasParaSeleccion";
                    var parametros = new
                    {
                        UnidTipo = IdTipo,
                        UnidEquipos = idEquipos
                    };

                    // El SP devuelve una sola columna (NombreCompleto). La mapeamos a string.
                    listaNombres = conexion.Query<string>(
                        sql: sp,
                        param: parametros,
                        commandType: CommandType.StoredProcedure
                    ).ToList();
                }

                if (FutbolistaListado != null)
                {
                    FutbolistaListado.DataSource = listaNombres;
                }
            }
            catch (MySqlConnector.MySqlException myEx)
            {
                MessageBox.Show($"Error de MySQL: {myEx.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        // El handler del botón Confirmar (expuesto en el Designer) reutiliza esta lógica.
        private void Confirmar_Click(object sender, EventArgs e)
        {
            if (FutbolistaListado == null || FutbolistaListado.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un jugador del listado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nombreCompleto = FutbolistaListado.SelectedItem.ToString();
            if (string.IsNullOrWhiteSpace(nombreCompleto))
            {
                MessageBox.Show("Nombre seleccionado inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // El SP devuelve 'Apellido, Nombre' según la definición. Separamos.
            var partes = nombreCompleto.Split(new string[] { ", " }, StringSplitOptions.None);
            if (partes.Length < 2)
            {
                MessageBox.Show("Formato de nombre inesperado. No se puede obtener Id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var apellido = partes[0].Trim();
            var nombre = partes[1].Trim();

            IDbConnection? conexion = null;
            try
            {
                conexion = Conexion.GetConexion();
                if (conexion.State != ConnectionState.Open) conexion.Open();

                // Buscar idFutbolista por Nombre+Apellido y por los filtros (tipo y equipo)
                var consultaId = @"SELECT idFutbolista FROM Futbolista WHERE Apellido = @Apellido AND Nombre = @Nombre AND idTipo = @IdTipo AND idEquipos = @IdEquipos LIMIT 1";
                var idF = conexion.QueryFirstOrDefault<int?>(consultaId, new { Apellido = apellido, Nombre = nombre, IdTipo = _idTipo, IdEquipos = _idEquipos });

                if (idF == null)
                {
                    MessageBox.Show("No se encontró el id del futbolista seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Llamar al SP altaPlantillaTitular para insertar en PlantillaTitular. Usamos plantilla id = 1 y esTitular = 1 (prueba)
                var p = new DynamicParameters();
                p.Add("UnidFutbolista", idF.Value);
                p.Add("UnidPlantillas", 1);
                p.Add("UnesTitular", 1);

                conexion.Execute("altaPlantillaTitular", p, commandType: CommandType.StoredProcedure);

                MessageBox.Show($"Jugador agregado a la plantilla 1 como titular (idFutbolista={idF}).", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlConnector.MySqlException myEx)
            {
                MessageBox.Show($"Error de MySQL: {myEx.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lógica del DataGridView...
        }

        private void FutbolistaListado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}