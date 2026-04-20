namespace SistemaRRHH
{
    partial class FrmAsistenciaUsuario
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDUI;
        private System.Windows.Forms.Label lblCargo;

        private System.Windows.Forms.Button btnAccionAsistencia;
        private System.Windows.Forms.Label lblEstadoActual;

        private System.Windows.Forms.Label lblHorasExtra;

        private System.Windows.Forms.DataGridView dgvHistorial;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDUI = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.btnAccionAsistencia = new System.Windows.Forms.Button();
            this.lblEstadoActual = new System.Windows.Forms.Label();
            this.lblHorasExtra = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();

            this.panelTop.SuspendLayout();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();

            // ================= PANEL TOP =================
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 70;
            this.panelTop.Controls.Add(this.lblTitulo);

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblTitulo.Text = "Asistencia del Usuario";

            // ================= DATOS =================
            this.gbDatos.Text = "Datos del Empleado";
            this.gbDatos.Location = new System.Drawing.Point(20, 90);
            this.gbDatos.Size = new System.Drawing.Size(400, 160);

            this.lblNombre.Text = "Nombre: ";
            this.lblNombre.Location = new System.Drawing.Point(15, 30);
            this.lblNombre.AutoSize = true;

            this.lblDUI.Text = "DUI: ";
            this.lblDUI.Location = new System.Drawing.Point(15, 65);
            this.lblDUI.AutoSize = true;

            this.lblCargo.Text = "Cargo: ";
            this.lblCargo.Location = new System.Drawing.Point(15, 100);
            this.lblCargo.AutoSize = true;

            this.gbDatos.Controls.Add(this.lblNombre);
            this.gbDatos.Controls.Add(this.lblDUI);
            this.gbDatos.Controls.Add(this.lblCargo);

            // ================= BOTÓN ASISTENCIA =================
            this.btnAccionAsistencia.Text = "INICIAR ASISTENCIA";
            this.btnAccionAsistencia.BackColor = System.Drawing.Color.LightGreen;
            this.btnAccionAsistencia.Location = new System.Drawing.Point(450, 110);
            this.btnAccionAsistencia.Size = new System.Drawing.Size(200, 60);

            // ================= ESTADO =================
            this.lblEstadoActual.Text = "Estado: NO INICIADA";
            this.lblEstadoActual.Location = new System.Drawing.Point(450, 180);
            this.lblEstadoActual.AutoSize = true;
            this.lblEstadoActual.ForeColor = System.Drawing.Color.Red;

            // ================= HORAS EXTRA =================
            this.lblHorasExtra.Text = "Horas Extra: 0 | $0.00";
            this.lblHorasExtra.Location = new System.Drawing.Point(450, 210);
            this.lblHorasExtra.AutoSize = true;

            // ================= GRID HISTORIAL =================
            this.dgvHistorial.Location = new System.Drawing.Point(20, 270);
            this.dgvHistorial.Size = new System.Drawing.Size(760, 250);
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;

            // ================= FORM =================
            this.ClientSize = new System.Drawing.Size(820, 550);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnAccionAsistencia);
            this.Controls.Add(this.lblEstadoActual);
            this.Controls.Add(this.lblHorasExtra);
            this.Controls.Add(this.dgvHistorial);

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asistencia Usuario";

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}