using Dapper;
using GranDT.Core;
using MySql.Data.MySqlClient;
using System.Data;
namespace GranDT.Winf
{
    public partial class Register : Form
    {
        private readonly string connectionString = "server=localhost;database=GranDT;uid=root;pwd=tu_contrase�a;";
        public Register()
        {
            InitializeComponent();
        }


        private void Contrase�a_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Apellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void Email_TextChanged(object sender, EventArgs e)
        {

        }

         

        private void Registrarse_Click(object sender, EventArgs e)
        {
            string nombre = Nombre.Text.Trim();
            string apellido = Apellido.Text.Trim();
            string email = Email.Text.Trim();
            string contrasena = Contrase�a.Text.Trim();
            DateTime? fechaNacimiento = null;

            if (DateTime.TryParse(Nacimiento.Text, out DateTime fecha))
                fechaNacimiento = fecha;

            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();

                    var parametros = new DynamicParameters();
                    parametros.Add("@Nombre", nombre);
                    parametros.Add("@Apellido", apellido);
                    parametros.Add("@Email", email);
                    parametros.Add("@FechadeNacimiento", fechaNacimiento);
                    parametros.Add("@Contrasena", contrasena);
                    parametros.Add("@esAdmin", 0); // usuario normal
                    parametros.Add("@idUsuario_generado", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    // Ejecuto el procedimiento almacenado
                    conexion.Execute("altaUsuario", parametros, commandType: CommandType.StoredProcedure);

                    int idGenerado = parametros.Get<int>("@idUsuario_generado");

                    MessageBox.Show($"Usuario registrado correctamente (ID: {idGenerado})", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpio campos
                    Nombre.Clear();
                    Apellido.Clear();
                    Email.Clear();
                    Contrase�a.Clear();
                    Nacimiento.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el usuario:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Nacimiento_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
