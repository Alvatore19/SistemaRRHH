namespace SistemaRRHH
{
    partial class FormPermisos
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

            // Paneles
            this.pnlDirector = new System.Windows.Forms.Panel();
            this.pnlAnalista = new System.Windows.Forms.Panel();
            this.pnlEmpleado = new System.Windows.Forms.Panel();

            // Grids
            this.dgvDirector = new System.Windows.Forms.DataGridView();
            this.dgvAnalista = new System.Windows.Forms.DataGridView();
            this.dgvEmpleado = new System.Windows.Forms.DataGridView();

            // Controles Empleado
            this.cmbPrioridadEmp = new System.Windows.Forms.ComboBox();
            this.numTiempoEmp = new System.Windows.Forms.NumericUpDown();
            this.cmbUnidadEmp = new System.Windows.Forms.ComboBox();
            this.txtMotivoEmp = new System.Windows.Forms.TextBox();
            this.btnEnviarPermiso = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDirector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTiempoEmp)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 41);
            this.lblTitulo.Text = "Gestión de Permisos";

            // =========================
            // PANEL DIRECTOR
            // =========================
            this.pnlDirector.Controls.Add(this.dgvDirector);
            this.pnlDirector.Location = new System.Drawing.Point(20, 80);
            this.pnlDirector.Name = "pnlDirector";
            this.pnlDirector.Size = new System.Drawing.Size(1000, 500);

            this.dgvDirector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDirector.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // =========================
            // PANEL ANALISTA
            // =========================
            this.pnlAnalista.Controls.Add(this.dgvAnalista);
            this.pnlAnalista.Location = new System.Drawing.Point(20, 80);
            this.pnlAnalista.Name = "pnlAnalista";
            this.pnlAnalista.Size = new System.Drawing.Size(1000, 500);

            this.dgvAnalista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnalista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnalista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnalista_CellContentClick);

            // =========================
            // PANEL EMPLEADO
            // =========================
            this.pnlEmpleado.Controls.Add(this.cmbPrioridadEmp);
            this.pnlEmpleado.Controls.Add(this.numTiempoEmp);
            this.pnlEmpleado.Controls.Add(this.cmbUnidadEmp);
            this.pnlEmpleado.Controls.Add(this.txtMotivoEmp);
            this.pnlEmpleado.Controls.Add(this.btnEnviarPermiso);
            this.pnlEmpleado.Controls.Add(this.dgvEmpleado);
            this.pnlEmpleado.Location = new System.Drawing.Point(20, 80);
            this.pnlEmpleado.Name = "pnlEmpleado";
            this.pnlEmpleado.Size = new System.Drawing.Size(1000, 500);

            this.cmbPrioridadEmp.Items.AddRange(new object[] { "1 - Urgente", "2 - Serio", "3 - Mandados" });
            this.cmbPrioridadEmp.Location = new System.Drawing.Point(20, 20);
            this.cmbPrioridadEmp.Size = new System.Drawing.Size(200, 24);

            this.numTiempoEmp.Location = new System.Drawing.Point(240, 20);

            this.cmbUnidadEmp.Items.AddRange(new object[] { "Horas", "Dias" });
            this.cmbUnidadEmp.Location = new System.Drawing.Point(380, 20);
            this.cmbUnidadEmp.SelectedIndex = 0;

            this.txtMotivoEmp.Location = new System.Drawing.Point(20, 60);
            this.txtMotivoEmp.Multiline = true;
            this.txtMotivoEmp.Size = new System.Drawing.Size(480, 60);

            this.btnEnviarPermiso.Location = new System.Drawing.Point(520, 60);
            this.btnEnviarPermiso.Size = new System.Drawing.Size(120, 60);
            this.btnEnviarPermiso.Text = "Enviar Solicitud";
            this.btnEnviarPermiso.Click += new System.EventHandler(this.btnEnviarPermiso_Click);

            this.dgvEmpleado.Location = new System.Drawing.Point(20, 140);
            this.dgvEmpleado.Size = new System.Drawing.Size(960, 340);
            this.dgvEmpleado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // =========================
            // FORMULARIO PRINCIPAL
            // =========================
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1090, 613);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlDirector);
            this.Controls.Add(this.pnlAnalista);
            this.Controls.Add(this.pnlEmpleado);
            this.Name = "FormPermisos";
            this.Load += new System.EventHandler(this.FormPermisos_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvDirector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTiempoEmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlDirector;
        private System.Windows.Forms.Panel pnlAnalista;
        private System.Windows.Forms.Panel pnlEmpleado;
        private System.Windows.Forms.DataGridView dgvDirector;
        private System.Windows.Forms.DataGridView dgvAnalista;
        private System.Windows.Forms.DataGridView dgvEmpleado;
        private System.Windows.Forms.ComboBox cmbPrioridadEmp;
        private System.Windows.Forms.NumericUpDown numTiempoEmp;
        private System.Windows.Forms.ComboBox cmbUnidadEmp;
        private System.Windows.Forms.TextBox txtMotivoEmp;
        private System.Windows.Forms.Button btnEnviarPermiso;
    }
}