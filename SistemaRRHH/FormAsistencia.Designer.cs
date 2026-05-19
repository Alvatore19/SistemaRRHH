namespace SistemaRRHH
{
    partial class FormAsistencia
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
            this.lblTituloPrincipal = new System.Windows.Forms.Label();

            // Paneles Contenedores
            this.pnlDirector = new System.Windows.Forms.Panel();
            this.pnlEmpleado = new System.Windows.Forms.Panel();

            // Controles Director
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.chkUsarFecha = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvAsistenciaGlobal = new System.Windows.Forms.DataGridView();

            // Controles Empleado
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDUI = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.btnAccionAsistencia = new System.Windows.Forms.Button();
            this.btnSimular = new System.Windows.Forms.Button();
            this.lblEstadoActual = new System.Windows.Forms.Label();
            this.lblHorasExtra = new System.Windows.Forms.Label();
            this.lblContador = new System.Windows.Forms.Label();
            this.dgvHistorialPersonal = new System.Windows.Forms.DataGridView();

            this.pnlDirector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaGlobal)).BeginInit();
            this.pnlEmpleado.SuspendLayout();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialPersonal)).BeginInit();
            this.SuspendLayout();

            // lblTituloPrincipal
            this.lblTituloPrincipal.AutoSize = true;
            this.lblTituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTituloPrincipal.Location = new System.Drawing.Point(20, 20);
            this.lblTituloPrincipal.Name = "lblTituloPrincipal";
            this.lblTituloPrincipal.Size = new System.Drawing.Size(315, 41);
            this.lblTituloPrincipal.Text = "Control de Asistencia";

            // =========================
            // PANEL DIRECTOR
            // =========================
            this.pnlDirector.BackColor = System.Drawing.Color.White;
            this.pnlDirector.Controls.Add(this.lblEstado);
            this.pnlDirector.Controls.Add(this.cboEstado);
            this.pnlDirector.Controls.Add(this.lblFecha);
            this.pnlDirector.Controls.Add(this.dtpFecha);
            this.pnlDirector.Controls.Add(this.chkUsarFecha);
            this.pnlDirector.Controls.Add(this.btnBuscar);
            this.pnlDirector.Controls.Add(this.dgvAsistenciaGlobal);
            this.pnlDirector.Location = new System.Drawing.Point(20, 80);
            this.pnlDirector.Name = "pnlDirector";
            this.pnlDirector.Size = new System.Drawing.Size(1000, 500);

            this.lblEstado.Location = new System.Drawing.Point(20, 25);
            this.lblEstado.Text = "Filtrar Estado:";
            this.lblEstado.AutoSize = true;

            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Location = new System.Drawing.Point(120, 22);
            this.cboEstado.Size = new System.Drawing.Size(150, 24);

            this.lblFecha.Location = new System.Drawing.Point(290, 25);
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.AutoSize = true;

            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(340, 22);
            this.dtpFecha.Size = new System.Drawing.Size(130, 22);

            this.chkUsarFecha.Location = new System.Drawing.Point(490, 22);
            this.chkUsarFecha.Text = "Habilitar Fecha";
            this.chkUsarFecha.AutoSize = true;

            this.btnBuscar.Location = new System.Drawing.Point(620, 15);
            this.btnBuscar.Size = new System.Drawing.Size(100, 35);
            this.btnBuscar.Text = "🔍 Buscar";
            this.btnBuscar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            this.dgvAsistenciaGlobal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAsistenciaGlobal.Location = new System.Drawing.Point(20, 70);
            this.dgvAsistenciaGlobal.Size = new System.Drawing.Size(960, 410);
            this.dgvAsistenciaGlobal.ReadOnly = true;
            this.dgvAsistenciaGlobal.AllowUserToAddRows = false;
            this.dgvAsistenciaGlobal.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvAsistenciaGlobal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAsistenciaGlobal.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAsistenciaGlobal_DataBindingComplete);

            // =========================
            // PANEL EMPLEADO
            // =========================
            this.pnlEmpleado.BackColor = System.Drawing.Color.White;
            this.pnlEmpleado.Controls.Add(this.gbDatos);
            this.pnlEmpleado.Controls.Add(this.btnAccionAsistencia);
            this.pnlEmpleado.Controls.Add(this.btnSimular);
            this.pnlEmpleado.Controls.Add(this.lblEstadoActual);
            this.pnlEmpleado.Controls.Add(this.lblHorasExtra);
            this.pnlEmpleado.Controls.Add(this.lblContador);
            this.pnlEmpleado.Controls.Add(this.dgvHistorialPersonal);
            this.pnlEmpleado.Location = new System.Drawing.Point(20, 80);
            this.pnlEmpleado.Name = "pnlEmpleado";
            this.pnlEmpleado.Size = new System.Drawing.Size(1000, 500);

            this.gbDatos.Controls.Add(this.lblNombre);
            this.gbDatos.Controls.Add(this.lblDUI);
            this.gbDatos.Controls.Add(this.lblCargo);
            this.gbDatos.Location = new System.Drawing.Point(20, 20);
            this.gbDatos.Size = new System.Drawing.Size(400, 150);
            this.gbDatos.Text = "Información del Empleado";
            this.gbDatos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.lblNombre.Location = new System.Drawing.Point(20, 40);
            this.lblNombre.Size = new System.Drawing.Size(350, 20);
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.lblDUI.Location = new System.Drawing.Point(20, 75);
            this.lblDUI.Size = new System.Drawing.Size(350, 20);
            this.lblDUI.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.lblCargo.Location = new System.Drawing.Point(20, 110);
            this.lblCargo.Size = new System.Drawing.Size(350, 20);
            this.lblCargo.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.btnAccionAsistencia.Location = new System.Drawing.Point(450, 30);
            this.btnAccionAsistencia.Size = new System.Drawing.Size(250, 60);
            this.btnAccionAsistencia.Text = "🟢 INICIAR JORNADA";
            this.btnAccionAsistencia.BackColor = System.Drawing.Color.LightGreen;
            this.btnAccionAsistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccionAsistencia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAccionAsistencia.Click += new System.EventHandler(this.btnAccionAsistencia_Click);

            // 
            // btnSimular
            // 
            this.btnSimular.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSimular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimular.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSimular.Location = new System.Drawing.Point(730, 110);
            this.btnSimular.Name = "btnSimular";
            this.btnSimular.Size = new System.Drawing.Size(150, 40);
            this.btnSimular.Text = "⏱️ SIMULAR 8H";
            this.btnSimular.UseVisualStyleBackColor = false;
            this.btnSimular.Click += new System.EventHandler(this.btnSimular_Click);

            this.lblContador.Location = new System.Drawing.Point(450, 100);
            this.lblContador.AutoSize = true;
            this.lblContador.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold);
            this.lblContador.Text = "00:00:00";

            this.lblEstadoActual.Location = new System.Drawing.Point(450, 140);
            this.lblEstadoActual.AutoSize = true;
            this.lblEstadoActual.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEstadoActual.ForeColor = System.Drawing.SystemColors.HotTrack;

            this.lblHorasExtra.Location = new System.Drawing.Point(750, 50);
            this.lblHorasExtra.AutoSize = true;
            this.lblHorasExtra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHorasExtra.Text = "Horas Extra: 0.00\nPago Extra: $0.00";

            this.dgvHistorialPersonal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorialPersonal.Location = new System.Drawing.Point(20, 200);
            this.dgvHistorialPersonal.Size = new System.Drawing.Size(960, 280);
            this.dgvHistorialPersonal.ReadOnly = true;
            this.dgvHistorialPersonal.AllowUserToAddRows = false;
            this.dgvHistorialPersonal.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvHistorialPersonal.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // FrmAsistencia
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1090, 613);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Controls.Add(this.lblTituloPrincipal);
            this.Controls.Add(this.pnlDirector);
            this.Controls.Add(this.pnlEmpleado);
            this.Name = "FrmAsistencia";
            this.Load += new System.EventHandler(this.FrmAsistencia_Load);

            this.pnlDirector.ResumeLayout(false);
            this.pnlDirector.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaGlobal)).EndInit();
            this.pnlEmpleado.ResumeLayout(false);
            this.pnlEmpleado.PerformLayout();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialPersonal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTituloPrincipal;
        private System.Windows.Forms.Panel pnlDirector;
        private System.Windows.Forms.Panel pnlEmpleado;

        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.CheckBox chkUsarFecha;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvAsistenciaGlobal;

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDUI;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Button btnAccionAsistencia;
        private System.Windows.Forms.Label lblEstadoActual;
        private System.Windows.Forms.Label lblHorasExtra;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.DataGridView dgvHistorialPersonal;
        private System.Windows.Forms.Button btnSimular;
    }
}