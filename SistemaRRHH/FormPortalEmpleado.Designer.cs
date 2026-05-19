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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCargo = new System.Windows.Forms.Label();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.lblJefe = new System.Windows.Forms.Label();
            this.txtJefe = new System.Windows.Forms.TextBox();
            this.lblDui = new System.Windows.Forms.Label();
            this.txtDui = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.tabHistoriales = new System.Windows.Forms.TabControl();
            this.tabAsistencias = new System.Windows.Forms.TabPage();
            this.dgvAsistencias = new System.Windows.Forms.DataGridView();
            this.tabPermisos = new System.Windows.Forms.TabPage();
            this.dgvPermisos = new System.Windows.Forms.DataGridView();
            this.tabBoletas = new System.Windows.Forms.TabPage();
            this.dgvBoletas = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlPerfil.SuspendLayout();
            this.tabHistoriales.SuspendLayout();
            this.tabAsistencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).BeginInit();
            this.tabPermisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).BeginInit();
            this.tabBoletas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoletas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(130, 38);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Mi Perfil";
            // 
            // pnlPerfil
            // 
            this.pnlPerfil.BackColor = System.Drawing.Color.White;
            this.pnlPerfil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPerfil.Controls.Add(this.btnPrint);
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
            this.pnlPerfil.Name = "pnlPerfil";
            this.pnlPerfil.Size = new System.Drawing.Size(1030, 160);
            this.pnlPerfil.TabIndex = 1;
            // 
            // lblPerfilTitulo
            // 
            this.lblPerfilTitulo.AutoSize = true;
            this.lblPerfilTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPerfilTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblPerfilTitulo.Name = "lblPerfilTitulo";
            this.lblPerfilTitulo.Size = new System.Drawing.Size(162, 25);
            this.lblPerfilTitulo.TabIndex = 0;
            this.lblPerfilTitulo.Text = "Datos Personales";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(220, 50);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(94, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre Completo:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(220, 70);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(250, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Location = new System.Drawing.Point(490, 50);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(38, 13);
            this.lblCargo.TabIndex = 3;
            this.lblCargo.Text = "Cargo:";
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(490, 70);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.ReadOnly = true;
            this.txtCargo.Size = new System.Drawing.Size(250, 20);
            this.txtCargo.TabIndex = 4;
            // 
            // lblJefe
            // 
            this.lblJefe.AutoSize = true;
            this.lblJefe.Location = new System.Drawing.Point(760, 50);
            this.lblJefe.Name = "lblJefe";
            this.lblJefe.Size = new System.Drawing.Size(79, 13);
            this.lblJefe.TabIndex = 5;
            this.lblJefe.Text = "Jefe Inmediato:";
            // 
            // txtJefe
            // 
            this.txtJefe.Location = new System.Drawing.Point(760, 70);
            this.txtJefe.Name = "txtJefe";
            this.txtJefe.ReadOnly = true;
            this.txtJefe.Size = new System.Drawing.Size(250, 20);
            this.txtJefe.TabIndex = 6;
            // 
            // lblDui
            // 
            this.lblDui.AutoSize = true;
            this.lblDui.Location = new System.Drawing.Point(220, 100);
            this.lblDui.Name = "lblDui";
            this.lblDui.Size = new System.Drawing.Size(95, 13);
            this.lblDui.TabIndex = 7;
            this.lblDui.Text = "DUI / Documento:";
            // 
            // txtDui
            // 
            this.txtDui.Location = new System.Drawing.Point(220, 120);
            this.txtDui.Name = "txtDui";
            this.txtDui.ReadOnly = true;
            this.txtDui.Size = new System.Drawing.Size(250, 20);
            this.txtDui.TabIndex = 8;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(490, 100);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(109, 13);
            this.lblEstado.TabIndex = 9;
            this.lblEstado.Text = "Estado en el Sistema:";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(490, 120);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(250, 20);
            this.txtEstado.TabIndex = 10;
            // 
            // tabHistoriales
            // 
            this.tabHistoriales.Controls.Add(this.tabAsistencias);
            this.tabHistoriales.Controls.Add(this.tabPermisos);
            this.tabHistoriales.Controls.Add(this.tabBoletas);
            this.tabHistoriales.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabHistoriales.Location = new System.Drawing.Point(20, 240);
            this.tabHistoriales.Name = "tabHistoriales";
            this.tabHistoriales.SelectedIndex = 0;
            this.tabHistoriales.Size = new System.Drawing.Size(1030, 350);
            this.tabHistoriales.TabIndex = 0;
            // 
            // tabAsistencias
            // 
            this.tabAsistencias.Controls.Add(this.dgvAsistencias);
            this.tabAsistencias.Location = new System.Drawing.Point(4, 29);
            this.tabAsistencias.Name = "tabAsistencias";
            this.tabAsistencias.Size = new System.Drawing.Size(1022, 317);
            this.tabAsistencias.TabIndex = 0;
            this.tabAsistencias.Text = "Historial de Asistencias";
            // 
            // dgvAsistencias
            // 
            this.dgvAsistencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAsistencias.BackgroundColor = System.Drawing.Color.White;
            this.dgvAsistencias.ColumnHeadersHeight = 26;
            this.dgvAsistencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAsistencias.Location = new System.Drawing.Point(0, 0);
            this.dgvAsistencias.Name = "dgvAsistencias";
            this.dgvAsistencias.RowHeadersWidth = 47;
            this.dgvAsistencias.Size = new System.Drawing.Size(1022, 317);
            this.dgvAsistencias.TabIndex = 0;
            // 
            // tabPermisos
            // 
            this.tabPermisos.Controls.Add(this.dgvPermisos);
            this.tabPermisos.Location = new System.Drawing.Point(4, 29);
            this.tabPermisos.Name = "tabPermisos";
            this.tabPermisos.Size = new System.Drawing.Size(1022, 317);
            this.tabPermisos.TabIndex = 1;
            this.tabPermisos.Text = "Mis Permisos";
            // 
            // dgvPermisos
            // 
            this.dgvPermisos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPermisos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPermisos.ColumnHeadersHeight = 26;
            this.dgvPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPermisos.Location = new System.Drawing.Point(0, 0);
            this.dgvPermisos.Name = "dgvPermisos";
            this.dgvPermisos.RowHeadersWidth = 47;
            this.dgvPermisos.Size = new System.Drawing.Size(1022, 317);
            this.dgvPermisos.TabIndex = 0;
            // 
            // tabBoletas
            // 
            this.tabBoletas.Controls.Add(this.dgvBoletas);
            this.tabBoletas.Location = new System.Drawing.Point(4, 29);
            this.tabBoletas.Name = "tabBoletas";
            this.tabBoletas.Size = new System.Drawing.Size(1022, 317);
            this.tabBoletas.TabIndex = 2;
            this.tabBoletas.Text = "Historial de Salarios / Boletas";
            // 
            // dgvBoletas
            // 
            this.dgvBoletas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBoletas.BackgroundColor = System.Drawing.Color.White;
            this.dgvBoletas.ColumnHeadersHeight = 26;
            this.dgvBoletas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBoletas.Location = new System.Drawing.Point(0, 0);
            this.dgvBoletas.Name = "dgvBoletas";
            this.dgvBoletas.RowHeadersWidth = 47;
            this.dgvBoletas.Size = new System.Drawing.Size(1022, 317);
            this.dgvBoletas.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.CadetBlue;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnPrint.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPrint.Location = new System.Drawing.Point(26, 63);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(156, 70);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = " 🖶 Imprimir boleta de pago";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FormPortalEmpleado
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1090, 613);
            this.Controls.Add(this.tabHistoriales);
            this.Controls.Add(this.pnlPerfil);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
        private System.Windows.Forms.Button btnPrint;
    }
}