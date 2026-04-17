using System;
using System.Windows.Forms;

namespace SistemaRRHH
{
    public partial class FormDash : Form
    {
        private string _rol;

        public FormDash()
        {
            InitializeComponent();
        }

        public FormDash(string role) : this()
        {
            _rol = role;
        }

        private void FormDash_Load(object sender, EventArgs e)
        {
            // Aquí puedes usar _rol para mostrar/ocultar elementos según permisos
            // Ejemplo: lblRol.Text = _rol;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDash formu = new FormDash(_rol);
            formu.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pnl_menuvertical.Width = pnl_menuvertical.Width == 190 ? 68 : 190;
        }

        private void button3_Click(object sender, EventArgs e) { }

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

        private void icon_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AbrirFormularioEnPanel(Form formHijo)
        {
            panelContenedor.Controls.Clear();
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(formHijo);
            panelContenedor.Tag = formHijo;
            formHijo.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            pnl_menuvertical.Width = pnl_menuvertical.Width == 190 ? 68 : 190;
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void pnl_menuvertical_Paint(object sender, PaintEventArgs e) { }
        private void panelcontenedor_Paint(object sender, PaintEventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void button2_Click_1(object sender, EventArgs e) { }
        private void button6_Click(object sender, EventArgs e) { }
        private void button7_Click(object sender, EventArgs e) { }
        private void button8_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void icon_Restaurar_Click(object sender, EventArgs e) { }
        private void btn_Consultas_Pedidos_Click(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {

        }

        private void btnPortal_Click(object sender, EventArgs e)
        {

        }
    }
}