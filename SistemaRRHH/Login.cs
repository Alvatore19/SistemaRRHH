using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaRRHH
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e) { }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string dui = txtDUI.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(dui) || string.IsNullOrEmpty(password))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Por favor ingresa DUI y contraseña.";
                return;
            }

            try
            {
                var (nivel, nombre) = ValidarCredenciales(dui, password);

                if (!string.IsNullOrEmpty(nivel))
                {
                    FormDashboard dashboard = new FormDashboard(nivel, nombre);
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

        private (string nivel, string nombre) ValidarCredenciales(string dui, string password)
        {
            string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=SistemaRRHH;Integrated Security=true";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(
                        @"SELECT c.NivelJerarquico, e.NombreCompleto
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
                            return (reader["NivelJerarquico"].ToString(),
                                    reader["NombreCompleto"].ToString());
                    }

                    return (string.Empty, string.Empty);
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Error de base de datos: " + sqlEx.Message);
            }
        }

        private void lblError_Click(object sender, EventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}