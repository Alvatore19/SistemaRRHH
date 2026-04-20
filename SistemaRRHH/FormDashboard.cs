using System;
using System.Windows.Forms;

namespace SistemaRRHH
{
    public partial class FormDashboard : Form
    {
        private string _nivel;
        private string _nombre;
        private string _idEmpleado;
        private Form formActivo = null;

        public FormDashboard()
        {
            InitializeComponent();
        }

        public FormDashboard(string nivel, string nombre, string idEmpleado) : this()
        {
            _nivel = nivel;
            _nombre = nombre;
            _idEmpleado = idEmpleado; 

            ConfigurarVistaPorNivelJerarquico(_nivel);
            lblUser.Text = _nombre;
            panelContenedor.AutoScroll = true;
        }

        private void ConfigurarVistaPorNivelJerarquico(string nivel)
        {
            btnAsistencia.Visible = false;
            btnGEmpleados.Visible = false;
            btnPermisos.Visible = false;
            btnCargos.Visible = false;
            btnPortal.Visible = false;

            switch (nivel)
            {
                case "1": // Director General — todo menos Portal
                    btnAsistencia.Visible = true;
                    btnGEmpleados.Visible = true;
                    btnPermisos.Visible = true;
                    btnCargos.Visible = true;
                    break;

                case "2": // Gerentes — Asistencias, Empleados, Permisos
                    btnAsistencia.Visible = true;
                    btnGEmpleados.Visible = true;
                    btnPermisos.Visible = true;
                    break;

                case "3": // Analistas / Desarrolladores — Permisos y Portal
                    btnPermisos.Visible = true;
                    btnPortal.Visible = true;
                    break;

                default:
                    MessageBox.Show("Nivel jerárquico no reconocido: '" + nivel + "'", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "¿Está seguro que desea cerrar sesión?",
            "Cerrar sesión",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void icon_Cerrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                 "¿Está seguro que desea salir de la aplicación?",
                 "Salir",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void AbrirFormularioEnPanel(Form formHijo)
        {
            // 1. Si ya hay un formulario abierto, lo cerramos
            if (formActivo != null)
                formActivo.Close();

            // 2. Guardamos el nuevo formulario como el activo
            formActivo = formHijo;

            // 3. Configuramos para que se comporte como un control dentro del panel
            formHijo.TopLevel = false;         
            formHijo.FormBorderStyle = FormBorderStyle.None; 
            formHijo.Dock = DockStyle.Fill;     

            // 4. Lo agregamos al panel y lo mostramos
            panelContenedor.Controls.Add(formHijo);
            panelContenedor.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }


        private void button6_Click(object sender, EventArgs e) {
            AbrirFormularioEnPanel(new FrmAsistenciaDirector());               // Gestión Empleados
        } // Asistencias
        private void button7_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new Gestion_Empleados());               // Gestión Empleados
        }
        private void button8_Click(object sender, EventArgs e) 
        {
            AbrirFormularioEnPanel(new FormPermisos(_nivel, _idEmpleado)); // Permisos 
        }
        private void btn_Consultas_Pedidos_Click(object sender, EventArgs e) { } // Cargos
        private void btnPortal_Click(object sender, EventArgs e) { } // Portal
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void pnl_menuvertical_Paint(object sender, PaintEventArgs e) { }
        private void panelcontenedor_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }

        private void icon_Minimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void icon_Max_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            icon_Max.Visible = false;       
            icon_Restaurar.Visible = true;
        }

        private void icon_Restaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            icon_Restaurar.Visible = false; 
            icon_Max.Visible = true;
        }
    }
}