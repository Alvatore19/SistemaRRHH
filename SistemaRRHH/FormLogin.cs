using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaRRHH
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e) { }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDUI.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Por favor ingresa DUI y contraseña.";
                return;
            }

            string dui = txtDUI.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                // 1. Recibimos la nueva variable 'idEmpleado' desde el método
                var (nivel, nombre, idEmpleado) = ValidarCredenciales(dui, password);

                if (!string.IsNullOrEmpty(nivel))
                {
                    // 2. Pasamos el 'idEmpleado' al constructor del Dashboard
                    FormDashboard dashboard = new FormDashboard(nivel, nombre, idEmpleado);
                    dashboard.FormClosed += (s, args) => Application.Exit();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "DUI o contraseña incorrectos.";
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error: " + ex.Message;
            }
        }

        // 3. Modificamos la firma del método para que retorne 3 strings en la tupla
        private (string nivel, string nombre, string idEmpleado) ValidarCredenciales(string dui, string password)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SistemaRRHH;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // 4. Agregamos 'e.IdEmpleado' a la consulta SELECT
                    SqlCommand cmd = new SqlCommand(
                        @"SELECT c.NivelJerarquico, e.NombreCompleto, e.IdEmpleado
                        FROM Empleado e
                        INNER JOIN Cargo c ON e.IdCargo = c.IdCargo
                        WHERE e.DocumentoLegal = @DocumentoLegal
                        AND e.Contrasena = @Password
                        AND e.EstadoActivo = 1",
                    connection);

                    cmd.Parameters.AddWithValue("@DocumentoLegal", dui);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // 5. Retornamos también la columna IdEmpleado
                            return (reader["NivelJerarquico"].ToString(),
                                    reader["NombreCompleto"].ToString(),
                                    reader["IdEmpleado"].ToString());
                        }
                    }

                    return (string.Empty, string.Empty, string.Empty);
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Error de base de datos: " + sqlEx.Message);
            }
        }

        private void lblError_Click(object sender, EventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void txtPassword_TextChanged(object sender, EventArgs e) { }
    }
}