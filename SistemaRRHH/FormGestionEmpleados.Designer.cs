namespace SistemaRRHH
{
    partial class FormGestionEmpleados
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.grup = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbCargo = new System.Windows.Forms.ComboBox();
            this.txtDui = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSueldo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbJefe = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIngresarEmpleado = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelArbol = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbNuevoJefe = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cmbEliminar = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.cmbActualizarJefe = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtActualizarSueldo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtActualizarCargo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtActualizarNombre = new System.Windows.Forms.TextBox();
            this.cmbActualizarSeleccion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();

            this.grup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();

            // Configuración General del Formulario
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1090, 613);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            // --- GRUPO: INGRESAR EMPLEADO ---
            this.grup.BackColor = System.Drawing.Color.White;
            this.grup.Controls.Add(this.txtPassword);
            this.grup.Controls.Add(this.txtUsername);
            this.grup.Controls.Add(this.label20);
            this.grup.Controls.Add(this.label18);
            this.grup.Controls.Add(this.label19);
            this.grup.Controls.Add(this.cmbCargo);
            this.grup.Controls.Add(this.txtDui);
            this.grup.Controls.Add(this.label15);
            this.grup.Controls.Add(this.txtSueldo);
            this.grup.Controls.Add(this.label4);
            this.grup.Controls.Add(this.cmbJefe);
            this.grup.Controls.Add(this.label3);
            this.grup.Controls.Add(this.btnIngresarEmpleado);
            this.grup.Controls.Add(this.label2);
            this.grup.Controls.Add(this.label1);
            this.grup.Controls.Add(this.txtNombre);
            this.grup.Location = new System.Drawing.Point(10, 10);
            this.grup.Name = "grup";
            this.grup.Size = new System.Drawing.Size(340, 240);
            this.grup.TabIndex = 2;
            this.grup.TabStop = false;
            this.grup.Text = "✨ Nuevo Empleado";
            this.grup.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            // Controles de Ingreso 
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(10, 25); this.label1.Text = "Nombre:"; this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombre.Location = new System.Drawing.Point(70, 22); this.txtNombre.Size = new System.Drawing.Size(255, 23); this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(10, 55); this.label2.Text = "Cargo:"; this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCargo.Location = new System.Drawing.Point(70, 52); this.cmbCargo.Size = new System.Drawing.Size(100, 23); this.cmbCargo.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.label4.AutoSize = true; this.label4.Location = new System.Drawing.Point(180, 55); this.label4.Text = "Sueldo:"; this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSueldo.Location = new System.Drawing.Point(230, 52); this.txtSueldo.Size = new System.Drawing.Size(95, 23); this.txtSueldo.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(10, 85); this.label3.Text = "Jefe:"; this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbJefe.Location = new System.Drawing.Point(70, 82); this.cmbJefe.Size = new System.Drawing.Size(100, 23); this.cmbJefe.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.label15.AutoSize = true; this.label15.Location = new System.Drawing.Point(180, 85); this.label15.Text = "DUI:"; this.label15.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDui.Location = new System.Drawing.Point(230, 82); this.txtDui.Size = new System.Drawing.Size(95, 23); this.txtDui.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.label20.AutoSize = true; this.label20.Location = new System.Drawing.Point(10, 120); this.label20.Text = "Credenciales de Acceso:"; this.label20.ForeColor = System.Drawing.Color.Gray;
            this.label19.AutoSize = true; this.label19.Location = new System.Drawing.Point(10, 145); this.label19.Text = "Correo:"; this.label19.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsername.Location = new System.Drawing.Point(70, 142); this.txtUsername.Size = new System.Drawing.Size(255, 23); this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.label18.AutoSize = true; this.label18.Location = new System.Drawing.Point(10, 175); this.label18.Text = "Pass:"; this.label18.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.Location = new System.Drawing.Point(70, 172); this.txtPassword.Size = new System.Drawing.Size(255, 23); this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.btnIngresarEmpleado.Location = new System.Drawing.Point(10, 205);
            this.btnIngresarEmpleado.Size = new System.Drawing.Size(315, 25);
            this.btnIngresarEmpleado.Text = "Ingresar Empleado";
            this.btnIngresarEmpleado.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnIngresarEmpleado.ForeColor = System.Drawing.Color.White;
            this.btnIngresarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarEmpleado.FlatAppearance.BorderSize = 0;
            this.btnIngresarEmpleado.Click += new System.EventHandler(this.btnIngresarEmpleado_Click);

            // --- GRUPO: ACTUALIZAR DATOS ---
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.btnActualizar);
            this.groupBox3.Controls.Add(this.cmbActualizarJefe);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtActualizarSueldo);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtActualizarCargo);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtActualizarNombre);
            this.groupBox3.Controls.Add(this.cmbActualizarSeleccion);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(10, 260);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 205);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "✏️ Actualizar Datos";
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            this.label7.AutoSize = true; this.label7.Location = new System.Drawing.Point(10, 25); this.label7.Text = "Buscar:"; this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbActualizarSeleccion.Location = new System.Drawing.Point(70, 22); this.cmbActualizarSeleccion.Size = new System.Drawing.Size(255, 23); this.cmbActualizarSeleccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbActualizarSeleccion.SelectedIndexChanged += new System.EventHandler(this.cmbActualizarSeleccion_SelectedIndexChanged);

            this.label8.AutoSize = true; this.label8.Location = new System.Drawing.Point(10, 55); this.label8.Text = "Nombre:"; this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtActualizarNombre.Location = new System.Drawing.Point(70, 52); this.txtActualizarNombre.Size = new System.Drawing.Size(255, 23); this.txtActualizarNombre.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.label9.AutoSize = true; this.label9.Location = new System.Drawing.Point(10, 85); this.label9.Text = "Cargo:"; this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtActualizarCargo.Location = new System.Drawing.Point(70, 82); this.txtActualizarCargo.Size = new System.Drawing.Size(100, 23); this.txtActualizarCargo.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.label10.AutoSize = true; this.label10.Location = new System.Drawing.Point(180, 85); this.label10.Text = "Sueldo:"; this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtActualizarSueldo.Location = new System.Drawing.Point(230, 82); this.txtActualizarSueldo.Size = new System.Drawing.Size(95, 23); this.txtActualizarSueldo.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.label11.AutoSize = true; this.label11.Location = new System.Drawing.Point(10, 115); this.label11.Text = "Jefe:"; this.label11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbActualizarJefe.Location = new System.Drawing.Point(70, 112); this.cmbActualizarJefe.Size = new System.Drawing.Size(100, 23); this.cmbActualizarJefe.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.label16.AutoSize = true; this.label16.Location = new System.Drawing.Point(180, 115); this.label16.Text = "DUI:"; this.label16.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBox1.Location = new System.Drawing.Point(230, 112); this.textBox1.Size = new System.Drawing.Size(95, 23); this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.btnActualizar.Location = new System.Drawing.Point(10, 155);
            this.btnActualizar.Size = new System.Drawing.Size(315, 25);
            this.btnActualizar.Text = "Guardar Cambios";
            this.btnActualizar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // --- GRUPO: DESPEDIR EMPLEADO ---
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.cmbNuevoJefe);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.cmbEliminar);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(10, 475);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 120);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "🗑️ Despedir Empleado";
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            this.label5.AutoSize = true; this.label5.Location = new System.Drawing.Point(10, 25); this.label5.Text = "Empleado:"; this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEliminar.Location = new System.Drawing.Point(130, 22); this.cmbEliminar.Size = new System.Drawing.Size(195, 23); this.cmbEliminar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEliminar.SelectedIndexChanged += new System.EventHandler(this.cmbEliminar_SelectedIndexChanged);

            this.label6.AutoSize = true; this.label6.Location = new System.Drawing.Point(10, 55); this.label6.Text = "Reasignar equipo a:"; this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbNuevoJefe.Location = new System.Drawing.Point(130, 52); this.cmbNuevoJefe.Size = new System.Drawing.Size(195, 23); this.cmbNuevoJefe.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.btnEliminar.Location = new System.Drawing.Point(10, 85);
            this.btnEliminar.Size = new System.Drawing.Size(315, 25);
            this.btnEliminar.Text = "Procesar Despido";
            this.btnEliminar.BackColor = System.Drawing.Color.Firebrick;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // --- PANELES PRINCIPALES (Árbol y Stats) ---
            this.panelArbol.BackColor = System.Drawing.Color.White;
            this.panelArbol.Location = new System.Drawing.Point(360, 10);
            this.panelArbol.Name = "panelArbol";
            this.panelArbol.Size = new System.Drawing.Size(710, 400);
            this.panelArbol.TabIndex = 3;
            this.panelArbol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelArbol.Paint += new System.Windows.Forms.PaintEventHandler(this.panelArbol_Paint);

            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.panelStats);
            this.groupBox5.Location = new System.Drawing.Point(360, 420);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(710, 180);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "📊 Estadísticas Organizacionales";
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            this.panelStats.Location = new System.Drawing.Point(10, 25);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(690, 145);
            this.panelStats.TabIndex = 4;
            this.panelStats.Paint += new System.Windows.Forms.PaintEventHandler(this.panelStats_Paint);

            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panelArbol);
            this.Controls.Add(this.grup);
            this.Name = "FormGestionEmpleados";
            this.Text = "Gestión de Empleados";

            this.grup.ResumeLayout(false);
            this.grup.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.GroupBox grup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbJefe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIngresarEmpleado;
        private System.Windows.Forms.Panel panelArbol;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSueldo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox cmbEliminar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbNuevoJefe;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbActualizarJefe;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtActualizarSueldo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtActualizarCargo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtActualizarNombre;
        private System.Windows.Forms.ComboBox cmbActualizarSeleccion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtDui;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbCargo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
    }
}