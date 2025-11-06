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
        private int _idEquipo;
        private GranDT.Dapper.RepoPlantilla _repo;

        public Futbolista? SelectedFutbolista { get; private set; }

        // Constructor para filtrar por tipo y equipo
        public SeleccionJugador(uint idTipo, int idEquipo)
        {
            InitializeComponent();
            _idTipo = idTipo;
            _idEquipo = idEquipo;
            var conexion = Conexion.GetConexion();
            _repo = new GranDT.Dapper.RepoPlantilla(conexion);

            LoadFutbolistas();
        }

        // Constructor por compatibilidad (sin filtro)
        public SeleccionJugador() : this(0, 0)
        {
        }
        public SeleccionJugador()
        {
            InitializeComponent();
        }

        private void Confirmar_Click(object sender, EventArgs e)
        {
            // Tomar el futbolista seleccionado en el grid y devolverlo
            if (futbolistaBindingSource.Current is Futbolista f)
            {
                SelectedFutbolista = f;
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            MessageBox.Show("Seleccione un futbolista antes de confirmar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadFutbolistas()
        {
            try
            {
                IEnumerable<Futbolista> lista;
                if (_idTipo == 0 && _idEquipo == 0)
                {
)
                    lista = _repo.traerFutbolistasXTipoXEquipo(0, 0);
                }
                else
                {
                    lista = _repo.traerFutbolistasXTipoXEquipo(_idTipo, _idEquipo);
                }

                futbolistaBindingSource.DataSource = lista.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al traer futbolistas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
