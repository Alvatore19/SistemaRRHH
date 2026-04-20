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

        private System.Windows.Forms.Label lblContador;

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
            this.lblContador = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(820, 70);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(348, 45);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Asistencia del Usuario";
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.lblNombre);
            this.gbDatos.Controls.Add(this.lblDUI);
            this.gbDatos.Controls.Add(this.lblCargo);
            this.gbDatos.Location = new System.Drawing.Point(20, 90);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(400, 160);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos del Empleado";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(15, 30);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(73, 20);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre: ";
            // 
            // lblDUI
            // 
            this.lblDUI.AutoSize = true;
            this.lblDUI.Location = new System.Drawing.Point(15, 65);
            this.lblDUI.Name = "lblDUI";
            this.lblDUI.Size = new System.Drawing.Size(46, 20);
            this.lblDUI.TabIndex = 1;
            this.lblDUI.Text = "DUI: ";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Location = new System.Drawing.Point(15, 100);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(60, 20);
            this.lblCargo.TabIndex = 2;
            this.lblCargo.Text = "Cargo: ";
            // 
            // btnAccionAsistencia
            // 
            this.btnAccionAsistencia.BackColor = System.Drawing.Color.LightGreen;
            this.btnAccionAsistencia.Location = new System.Drawing.Point(450, 110);
            this.btnAccionAsistencia.Name = "btnAccionAsistencia";
            this.btnAccionAsistencia.Size = new System.Drawing.Size(200, 60);
            this.btnAccionAsistencia.TabIndex = 2;
            this.btnAccionAsistencia.Text = "INICIAR ASISTENCIA";
            this.btnAccionAsistencia.UseVisualStyleBackColor = false;
            // 
            // lblEstadoActual
            // 
            this.lblEstadoActual.AutoSize = true;
            this.lblEstadoActual.ForeColor = System.Drawing.Color.Red;
            this.lblEstadoActual.Location = new System.Drawing.Point(450, 180);
            this.lblEstadoActual.Name = "lblEstadoActual";
            this.lblEstadoActual.Size = new System.Drawing.Size(166, 20);
            this.lblEstadoActual.TabIndex = 3;
            this.lblEstadoActual.Text = "Estado: NO INICIADA";
            // 
            // lblHorasExtra
            // 
            this.lblHorasExtra.AutoSize = true;
            this.lblHorasExtra.Location = new System.Drawing.Point(450, 230);
            this.lblHorasExtra.Name = "lblHorasExtra";
            this.lblHorasExtra.Size = new System.Drawing.Size(163, 20);
            this.lblHorasExtra.TabIndex = 5;
            this.lblHorasExtra.Text = "Horas Extra: 0 | $0.00";
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblContador.ForeColor = System.Drawing.Color.Black;
            this.lblContador.Location = new System.Drawing.Point(449, 200);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(94, 28);
            this.lblContador.TabIndex = 4;
            this.lblContador.Text = "00:00:00";
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.ColumnHeadersHeight = 34;
            this.dgvHistorial.Location = new System.Drawing.Point(20, 270);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersWidth = 62;
            this.dgvHistorial.Size = new System.Drawing.Size(760, 250);
            this.dgvHistorial.TabIndex = 6;
            // 
            // FrmAsistenciaUsuario
            // 
            this.ClientSize = new System.Drawing.Size(820, 550);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnAccionAsistencia);
            this.Controls.Add(this.lblEstadoActual);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.lblHorasExtra);
            this.Controls.Add(this.dgvHistorial);
            this.Name = "FrmAsistenciaUsuario";
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