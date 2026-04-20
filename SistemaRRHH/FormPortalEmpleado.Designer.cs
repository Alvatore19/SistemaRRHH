namespace SistemaRRHH
{
    partial class FormPortalEmpleado
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlPerfil = new System.Windows.Forms.Panel();
            this.lblPerfilTitulo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.lblCargo = new System.Windows.Forms.Label();
            this.txtJefe = new System.Windows.Forms.TextBox();
            this.lblJefe = new System.Windows.Forms.Label();
            this.txtDui = new System.Windows.Forms.TextBox();
            this.lblDui = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();

            this.tabHistoriales = new System.Windows.Forms.TabControl();
            this.tabAsistencias = new System.Windows.Forms.TabPage();
            this.dgvAsistencias = new System.Windows.Forms.DataGridView();
            this.tabPermisos = new System.Windows.Forms.TabPage();
            this.dgvPermisos = new System.Windows.Forms.DataGridView();
            this.tabBoletas = new System.Windows.Forms.TabPage();
            this.dgvBoletas = new System.Windows.Forms.DataGridView();

            this.pnlPerfil.SuspendLayout();
            this.tabHistoriales.SuspendLayout();
            this.tabAsistencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).BeginInit();
            this.tabPermisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).BeginInit();
            this.tabBoletas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoletas)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Text = "Mi Perfil";

            // ==========================================
            // PANEL DE PERFIL (Arriba)
            // ==========================================
            this.pnlPerfil.BackColor = System.Drawing.Color.White;
            this.pnlPerfil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPerfil.Controls.Add(this.lblPerfilTitulo);
            this.pnlPerfil.Controls.Add(this.lblNombre);
            this.pnlPerfil.Controls.Add(this.txtNombre);
            this.pnlPerfil.Controls.Add(this.lblCargo);
            this.pnlPerfil.Controls.Add(this.txtCargo);
            this.pnlPerfil.Controls.Add(this.lblJefe);
            this.pnlPerfil.Controls.Add(this.txtJefe);
            this.pnlPerfil.Controls.Add(this.lblDui);
            this.pnlPerfil.Controls.Add(this.txtDui);
            this.pnlPerfil.Controls.Add(this.lblEstado);
            this.pnlPerfil.Controls.Add(this.txtEstado);
            this.pnlPerfil.Location = new System.Drawing.Point(20, 65);
            this.pnlPerfil.Size = new System.Drawing.Size(1030, 160);

            this.lblPerfilTitulo.AutoSize = true;
            this.lblPerfilTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPerfilTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblPerfilTitulo.Text = "Datos Personales";

            // Nombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(220, 50);
            this.lblNombre.Text = "Nombre Completo:";
            this.txtNombre.Location = new System.Drawing.Point(220, 70);
            this.txtNombre.Size = new System.Drawing.Size(250, 22);
            this.txtNombre.ReadOnly = true;

            // Cargo
            this.lblCargo.AutoSize = true;
            this.lblCargo.Location = new System.Drawing.Point(490, 50);
            this.lblCargo.Text = "Cargo:";
            this.txtCargo.Location = new System.Drawing.Point(490, 70);
            this.txtCargo.Size = new System.Drawing.Size(250, 22);
            this.txtCargo.ReadOnly = true;

            // Jefe
            this.lblJefe.AutoSize = true;
            this.lblJefe.Location = new System.Drawing.Point(760, 50);
            this.lblJefe.Text = "Jefe Inmediato:";
            this.txtJefe.Location = new System.Drawing.Point(760, 70);
            this.txtJefe.Size = new System.Drawing.Size(250, 22);
            this.txtJefe.ReadOnly = true;

            // DUI
            this.lblDui.AutoSize = true;
            this.lblDui.Location = new System.Drawing.Point(220, 100);
            this.lblDui.Text = "DUI / Documento:";
            this.txtDui.Location = new System.Drawing.Point(220, 120);
            this.txtDui.Size = new System.Drawing.Size(250, 22);
            this.txtDui.ReadOnly = true;

            // Estado
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(490, 100);
            this.lblEstado.Text = "Estado en el Sistema:";
            this.txtEstado.Location = new System.Drawing.Point(490, 120);
            this.txtEstado.Size = new System.Drawing.Size(250, 22);
            this.txtEstado.ReadOnly = true;

            // ==========================================
            // CONTROL DE PESTAÑAS (Abajo)
            // ==========================================
            this.tabHistoriales.Controls.Add(this.tabAsistencias);
            this.tabHistoriales.Controls.Add(this.tabPermisos);
            this.tabHistoriales.Controls.Add(this.tabBoletas);
            this.tabHistoriales.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabHistoriales.Location = new System.Drawing.Point(20, 240);
            this.tabHistoriales.Size = new System.Drawing.Size(1030, 350);

            // Tab 1: Asistencias
            this.tabAsistencias.Controls.Add(this.dgvAsistencias);
            this.tabAsistencias.Text = "Historial de Asistencias";
            this.dgvAsistencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAsistencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAsistencias.BackgroundColor = System.Drawing.Color.White;

            // Tab 2: Permisos
            this.tabPermisos.Controls.Add(this.dgvPermisos);
            this.tabPermisos.Text = "Mis Permisos";
            this.dgvPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPermisos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPermisos.BackgroundColor = System.Drawing.Color.White;

            // Tab 3: Boletas
            this.tabBoletas.Controls.Add(this.dgvBoletas);
            this.tabBoletas.Text = "Historial de Salarios / Boletas";
            this.dgvBoletas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBoletas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBoletas.BackgroundColor = System.Drawing.Color.White;

            // FormPortalEmpleado
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1090, 613);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Controls.Add(this.tabHistoriales);
            this.Controls.Add(this.pnlPerfil);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormPortalEmpleado";
            this.Load += new System.EventHandler(this.FormPortalEmpleado_Load);

            this.pnlPerfil.ResumeLayout(false);
            this.pnlPerfil.PerformLayout();
            this.tabHistoriales.ResumeLayout(false);
            this.tabAsistencias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).EndInit();
            this.tabPermisos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).EndInit();
            this.tabBoletas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoletas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlPerfil;
        private System.Windows.Forms.Label lblPerfilTitulo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.TextBox txtJefe;
        private System.Windows.Forms.Label lblJefe;
        private System.Windows.Forms.TextBox txtDui;
        private System.Windows.Forms.Label lblDui;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label lblEstado;

        private System.Windows.Forms.TabControl tabHistoriales;
        private System.Windows.Forms.TabPage tabAsistencias;
        private System.Windows.Forms.DataGridView dgvAsistencias;
        private System.Windows.Forms.TabPage tabPermisos;
        private System.Windows.Forms.DataGridView dgvPermisos;
        private System.Windows.Forms.TabPage tabBoletas;
        private System.Windows.Forms.DataGridView dgvBoletas;
    }
}