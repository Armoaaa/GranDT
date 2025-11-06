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
    public partial class EdicionPlantilla : Form
    {
        private int? _idPlantillaSeleccionada;
        private GranDT.Dapper.RepoPlantilla? _repoPlantilla;

        // Representa un slot en la plantilla: posicion visual, tipo (arquero, defensa, etc), y futbolista seleccionado
        private class Slot
        {
            public string Key { get; set; } = string.Empty; // p.ej "Delantero1"
            public uint TipoId { get; set; }
            public Futbolista? Jugador { get; set; }
            public PictureBox? Pic { get; set; }
        }

        private readonly Dictionary<string, Slot> _slots = new Dictionary<string, Slot>();

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
            // Si se pasó una plantilla seleccionada, podemos cargar sus datos aquí
            if (_idPlantillaSeleccionada.HasValue)
            {
                try
                {
                    var conexion = Conexion.GetConexion();
                    _repoPlantilla = new GranDT.Dapper.RepoPlantilla(conexion);
                    var plantilla = _repoPlantilla.ObtenerPlantillaCompleta((uint)_idPlantillaSeleccionada.Value);
                    if (plantilla != null)
                    {
                        // Inicializar slots visuales y cargar titulares/suplentes en ellos
                        InitializeSlots();
                        MapPlantillaToSlots(plantilla);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la plantilla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Inicializamos slots aunque no haya plantilla (nuevo)
                InitializeSlots();
            }

        }

        private void InitializeSlots()
        {
            // Asociar picture boxes a slots y tipos (según indicación: arquero->tipo 1 y delanteros 1..4??)
            // Asumir el mapeo: arquero -> Tipo 1, defensa -> Tipo 2, medio -> Tipo 3, delantero -> Tipo 4
            // Si tus tipos son distintos, ajusta estos valores.
            _slots.Clear();

            _slots["Delantero1"] = new Slot { Key = "Delantero1", TipoId = 4, Pic = Delantero1 };
            _slots["Delantero2"] = new Slot { Key = "Delantero2", TipoId = 4, Pic = Delantero2 };
            _slots["Delantero3"] = new Slot { Key = "Delantero3", TipoId = 4, Pic = Delantero3 };

            _slots["Medio1"] = new Slot { Key = "Medio1", TipoId = 3, Pic = Medio1 };
            _slots["Medio2"] = new Slot { Key = "Medio2", TipoId = 3, Pic = Medio2 };
            _slots["Medio3"] = new Slot { Key = "Medio3", TipoId = 3, Pic = Medio3 };

            _slots["Defensa1"] = new Slot { Key = "Defensa1", TipoId = 2, Pic = Defensa1 };
            _slots["Defensa2"] = new Slot { Key = "Defensa2", TipoId = 2, Pic = Defensa2 };
            _slots["Defensa3"] = new Slot { Key = "Defensa3", TipoId = 2, Pic = Defensa3 };
            _slots["Defensa4"] = new Slot { Key = "Defensa4", TipoId = 2, Pic = Defensa4 };

            _slots["Arquero"] = new Slot { Key = "Arquero", TipoId = 1, Pic = arquero };

            _slots["Suplente1"] = new Slot { Key = "Suplente1", TipoId = 4, Pic = Suplente1 };
            _slots["Suplente2"] = new Slot { Key = "Suplente2", TipoId = 4, Pic = Suplente2 };
            _slots["Suplente3"] = new Slot { Key = "Suplente3", TipoId = 4, Pic = Suplente3 };
            _slots["Suplente4"] = new Slot { Key = "Suplente4", TipoId = 4, Pic = Suplente4 };
            _slots["Suplente5"] = new Slot { Key = "Suplente5", TipoId = 4, Pic = Suplente5 };
            _slots["Suplente6"] = new Slot { Key = "Suplente6", TipoId = 4, Pic = Suplente6 };
            _slots["Suplente7"] = new Slot { Key = "Suplente7", TipoId = 4, Pic = Suplente7 };

            // pintar nombres iniciales
            foreach (var s in _slots.Values)
            {
                if (s.Pic != null)
                {
                    s.Pic.Cursor = Cursors.Hand;
                    s.Pic.Tag = s.Key; // para identificar en click
                    s.Pic.Click += Slot_Click;
                }
            }
        }

        private void MapPlantillaToSlots(Plantilla plantilla)
        {
            // Mapear titulares (asumimos que plantilla.Titulares tiene puestos ya en el orden o con Tipo)
            // Haremos una asignación simple: asignar titulares a slots titulares por tipo que estén vacíos
            if (plantilla.Titulares != null)
            {
                foreach (var f in plantilla.Titulares)
                {
                    var slot = _slots.Values.FirstOrDefault(s => s.TipoId == f.IdTipo && s.Jugador == null && s.Key != "Arquero");
                    if (slot != null)
                    {
                        slot.Jugador = f;
                        if (slot.Pic != null)
                        {
                            slot.Pic.BackColor = Color.LightGreen;
                            // set tooltip o nombre
                        }
                    }
                }
            }

            if (plantilla.Suplentes != null)
            {
                foreach (var f in plantilla.Suplentes)
                {
                    var slot = _slots.Values.FirstOrDefault(s => s.Key.StartsWith("Suplente") && s.Jugador == null);
                    if (slot != null)
                    {
                        slot.Jugador = f;
                        if (slot.Pic != null)
                        {
                            slot.Pic.BackColor = Color.LightBlue;
                        }
                    }
                }
            }
        }

        private void Slot_Click(object? sender, EventArgs e)
        {
            if (sender is PictureBox pic && pic.Tag is string key && _slots.ContainsKey(key))
            {
                var slot = _slots[key];
                // Abrir selector pasando tipo y equipo de la plantilla (usar idEquipos del formulario si existe)
                try
                {
                    int equipoId = 0; // si tu formulario tiene combobox de equipos, lee desde ahí. Por ahora 0
                    using var dlg = new SeleccionJugador(slot.TipoId, equipoId);
                    var res = dlg.ShowDialog();
                    if (res == DialogResult.OK && dlg.SelectedFutbolista != null)
                    {
                        slot.Jugador = dlg.SelectedFutbolista;
                        // actualizar UI del picturebox (colorear y tooltip)
                        pic.BackColor = Color.LightGreen;
                        pic.Refresh();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar jugador: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void Delantero1_Click(object sender, EventArgs e)
        {

        }

        private void Delantero2_Click(object sender, EventArgs e)
        {

        }

        private void Delantero3_Click(object sender, EventArgs e)
        {

        }

        private void Medio1_Click(object sender, EventArgs e)
        {

        }

        private void Medio2_Click(object sender, EventArgs e)
        {

        }

        private void Medio3_Click(object sender, EventArgs e)
        {

        }

        private void Defensa1_Click(object sender, EventArgs e)
        {

        }

        private void Defensa2_Click(object sender, EventArgs e)
        {

        }

        private void Defensa3_Click(object sender, EventArgs e)
        {

        }

        private void Defensa4_Click(object sender, EventArgs e)
        {

        }

        private void arquero_Click(object sender, EventArgs e)
        {

        }

        private void Suplente1_Click(object sender, EventArgs e)
        {

        }

        private void Suplente2_Click(object sender, EventArgs e)
        {

        }

        private void Suplente3_Click(object sender, EventArgs e)
        {

        }

        private void Suplente4_Click(object sender, EventArgs e)
        {

        }

        private void Suplente5_Click(object sender, EventArgs e)
        {

        }

        private void Suplente6_Click(object sender, EventArgs e)
        {

        }

        private void Suplente7_Click(object sender, EventArgs e)
        {

        }

        private void Confirmar_Click(object sender, EventArgs e)
        {
            // Al confirmar, recorremos los slots y damos altas/actualizaciones según corresponda.
            if (!_idPlantillaSeleccionada.HasValue)
            {
                MessageBox.Show("No hay plantilla cargada para dar de alta jugadores.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_repoPlantilla == null)
                {
                    _repoPlantilla = new GranDT.Dapper.RepoPlantilla(Conexion.GetConexion());
                }

                foreach (var slot in _slots.Values)
                {
                    if (slot.Jugador == null) continue;

                    // decidir si alta o actualizar: no tenemos en UI un indicador si ya existía en DB; asumimos que si el jugador tiene IdFutbolista > 0 y la plantilla ya contiene ese jugador, entonces actualizar
                    // Mejor: intentar Alta y si el SP falla por duplicado, llamar a Actualizar. Pero aquí usaremos: si plantilla ya contenía jugador (comparar contra ObtenerPlantillaCompleta) -> actualizar
                    var plantilla = _repoPlantilla.ObtenerPlantillaCompleta((uint)_idPlantillaSeleccionada.Value);
                    bool existeEnPlantilla = false;
                    if (plantilla != null)
                    {
                        existeEnPlantilla = plantilla.Titulares.Any(t => t.IdFutbolista == slot.Jugador.IdFutbolista) || plantilla.Suplentes.Any(s => s.IdFutbolista == slot.Jugador.IdFutbolista);
                    }

                    bool esTitular = !slot.Key.StartsWith("Suplente");

                    if (existeEnPlantilla)
                    {
                        _repoPlantilla.ActualizarJugadorEnPlantilla((uint)_idPlantillaSeleccionada.Value, slot.Jugador.IdFutbolista, esTitular);
                    }
                    else
                    {
                        _repoPlantilla.AltaJugadorEnPlantilla((uint)_idPlantillaSeleccionada.Value, slot.Jugador.IdFutbolista, esTitular);
                    }
                }

                MessageBox.Show("Jugadores procesados correctamente.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar jugadores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
