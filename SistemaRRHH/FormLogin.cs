using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Mail;
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

        private void btnLostPass_Click(object sender, EventArgs e)
        {
            // Variables de control
            string codigoGeneradoEnMemoria = "";
            string duiUsuario = "";
            string correoDestino = "";
            string nombreUsuario = "";
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SistemaRRHH;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

            Color colorPrincipal = ColorTranslator.FromHtml("#2e6c80");
            Color colorAcento = ColorTranslator.FromHtml("#d9534f");
            Color colorFondoGris = ColorTranslator.FromHtml("#f9f9f9");

            // 1. Configuración del Formulario (Estilo Correo)
            Form formRecuperacion = new Form
            {
                Text = "Sistema RRHH - Recuperación",
                Size = new Size(400, 350),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White,
                Font = new Font("Arial", 10)
            };

            Label lblTitulo = new Label
            {
                Text = "Recuperación de Acceso",
                ForeColor = colorPrincipal,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 50,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Panel pnlCuerpo = new Panel
            {
                Size = new Size(340, 180),
                Location = new Point(25, 60),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            // --- CONTROLES FASE 1: DUI ---
            Label lblDUI = new Label { Text = "Ingrese su DUI registrado:", Left = 15, Top = 20, Width = 200 };
            TextBox txtDUI = new TextBox { Left = 15, Top = 45, Width = 300, Font = new Font("Arial", 11) };
            Button btnEnviar = new Button
            {
                Text = "Enviar correo de recuperación",
                Left = 15,
                Top = 90,
                Width = 300,
                Height = 45,
                BackColor = colorPrincipal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            // --- CONTROLES FASE 2: CÓDIGO ---
            Label lblCodigo = new Label { Text = "Código de seguridad enviado:", Left = 15, Top = 20, Width = 250, Visible = false };
            TextBox txtCodigo = new TextBox
            {
                Left = 15,
                Top = 45,
                Width = 300,
                Visible = false,
                Font = new Font("Consolas", 14, FontStyle.Bold),
                ForeColor = colorAcento,
                TextAlign = HorizontalAlignment.Center,
                MaxLength = 6
            };
            Button btnVerificar = new Button { Text = "Verificar Código", Left = 15, Top = 95, Width = 300, Height = 45, BackColor = colorPrincipal, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Visible = false };

            // --- CONTROLES FASE 3: NUEVA CONTRASEÑA ---
            Label lblNuevaPass = new Label { Text = "Nueva Contraseña:", Left = 15, Top = 10, Width = 150, Visible = false };
            TextBox txtNuevaPass = new TextBox { Left = 15, Top = 35, Width = 300, Visible = false, UseSystemPasswordChar = true };
            Label lblConfirmPass = new Label { Text = "Confirmar:", Left = 15, Top = 70, Width = 150, Visible = false };
            TextBox txtConfirmPass = new TextBox { Left = 15, Top = 95, Width = 300, Visible = false, UseSystemPasswordChar = true };
            Button btnActualizar = new Button { Text = "Actualizar Contraseña", Left = 15, Top = 130, Width = 300, Height = 40, BackColor = Color.ForestGreen, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Visible = false };

            Label lblEstado = new Label { Text = "", Left = 25, Top = 255, Width = 340, ForeColor = Color.Gray, Font = new Font("Arial", 8), TextAlign = ContentAlignment.MiddleCenter };

            pnlCuerpo.Controls.AddRange(new Control[] { lblDUI, txtDUI, btnEnviar, lblCodigo, txtCodigo, btnVerificar, lblNuevaPass, txtNuevaPass, lblConfirmPass, txtConfirmPass, btnActualizar });
            formRecuperacion.Controls.AddRange(new Control[] { lblTitulo, pnlCuerpo, lblEstado });

            // ==========================================
            // LÓGICA FASE 1: BÚSQUEDA Y ENVÍO DINÁMICO
            // ==========================================
            btnEnviar.Click += async (s, ev) =>
            {
                duiUsuario = txtDUI.Text.Trim();
                if (string.IsNullOrWhiteSpace(duiUsuario)) { MessageBox.Show("Ingrese su DUI."); return; }

                lblEstado.Text = "Verificando identidad...";
                btnEnviar.Enabled = false;

                try
                {
                    // 1. Buscar el correo en la BD
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        await conn.OpenAsync();
                        string sql = "SELECT CorreoElectronico, NombreCompleto FROM Empleado WHERE DocumentoLegal = @dui AND EstadoActivo = 1";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@dui", duiUsuario);
                            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                            {
                                if (reader.Read())
                                {
                                    correoDestino = reader["CorreoElectronico"].ToString();
                                    nombreUsuario = reader["NombreCompleto"].ToString();
                                }
                            }
                        }
                    }

                    // 2. Validar si se encontró correo
                    if (string.IsNullOrEmpty(correoDestino))
                    {
                        lblEstado.Text = "El DUI no existe o no tiene correo asociado.";
                        lblEstado.ForeColor = Color.Red;
                        btnEnviar.Enabled = true;
                        return;
                    }

                    // 3. Generar código y enviar
                    codigoGeneradoEnMemoria = new Random().Next(100000, 999999).ToString();
                    lblEstado.Text = $"Enviando código a: {correoDestino.Substring(0, 3)}***@mail.com";

                    var senderEmail = "sistemarh10@gmail.com";
                    var appPassword = "myzupkxuajtvuhom";

                    using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential(senderEmail, appPassword);
                        using (var mensaje = new MailMessage(senderEmail, correoDestino))
                        {
                            mensaje.Subject = "Código de Recuperación - Sistema RRHH";
                            mensaje.IsBodyHtml = true;
                            mensaje.Body = $@"
                    <div style='font-family: Arial, sans-serif; color: #333; max-width: 600px; border: 1px solid #eee; padding: 20px;'>
                        <h2 style='color: #2e6c80;'>¡Hola, {nombreUsuario}!</h2>
                        <p>Has solicitado recuperar tu acceso al sistema.</p>
                        <hr style='border: 0; border-top: 1px solid #eee;' />
                        <p><strong>Tu código de seguridad es:</strong></p>
                        <div style='background-color: #f9f9f9; padding: 15px; border-radius: 5px; text-align: center;'>
                             <span style='color: #d9534f; font-family: monospace; font-size: 24px; font-weight: bold;'>{codigoGeneradoEnMemoria}</span>
                        </div>
                        <p style='font-size: 0.8em; color: #999; margin-top: 20px;'>Generado el: {DateTime.Now:dd/MM/yyyy HH:mm:ss}</p>
                    </div>";
                            await smtp.SendMailAsync(mensaje);
                        }
                    }

                    // UI Transición
                    lblDUI.Visible = txtDUI.Visible = btnEnviar.Visible = false;
                    lblCodigo.Visible = txtCodigo.Visible = btnVerificar.Visible = true;
                    pnlCuerpo.BackColor = colorFondoGris;
                    lblEstado.Text = $"Código enviado a {correoDestino}";
                    lblEstado.ForeColor = Color.Green;
                }
                catch (Exception ex)
                {
                    lblEstado.Text = "Error en el proceso.";
                    btnEnviar.Enabled = true;
                    MessageBox.Show(ex.Message);
                }
            };

            // ==========================================
            // LÓGICA FASE 2: VERIFICAR CÓDIGO
            // ==========================================
            btnVerificar.Click += (s, ev) =>
            {
                if (txtCodigo.Text.Trim() == codigoGeneradoEnMemoria)
                {
                    lblCodigo.Visible = txtCodigo.Visible = btnVerificar.Visible = false;
                    lblNuevaPass.Visible = txtNuevaPass.Visible = lblConfirmPass.Visible = txtConfirmPass.Visible = btnActualizar.Visible = true;
                    pnlCuerpo.Height = 190;
                    pnlCuerpo.BackColor = Color.White;
                    lblEstado.Text = "Identidad confirmada.";
                }
                else { lblEstado.Text = "Código incorrecto."; lblEstado.ForeColor = Color.Red; }
            };

            // ==========================================
            // LÓGICA FASE 3: SQL UPDATE
            // ==========================================
            btnActualizar.Click += async (s, ev) =>
            {
                if (txtNuevaPass.Text != txtConfirmPass.Text || txtNuevaPass.Text.Length < 4)
                {
                    MessageBox.Show("Verifique que las contraseñas coincidan y tengan mínimo 4 caracteres."); return;
                }

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        await conn.OpenAsync();
                        string query = "UPDATE Empleado SET Contrasena = @Pass WHERE DocumentoLegal = @DUI";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Pass", txtNuevaPass.Text.Trim());
                            cmd.Parameters.AddWithValue("@DUI", duiUsuario);
                            await cmd.ExecuteNonQueryAsync();
                            MessageBox.Show("Contraseña actualizada con éxito.", "RRHH", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            formRecuperacion.Close();
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error SQL: " + ex.Message); }
            };

            formRecuperacion.ShowDialog();
        }


    }
}