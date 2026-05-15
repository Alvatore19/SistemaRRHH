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
            this.cmbJefe = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIngresarEmpleado = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbNuevoJefe = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbEliminar = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMotivoDespido = new System.Windows.Forms.Label();
            this.txtMotivoDespido = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.cmbActualizarJefe = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblEscala = new System.Windows.Forms.Label();
            this.cmbEscalaSalarial = new System.Windows.Forms.ComboBox();
            this.lblMotivoAumento = new System.Windows.Forms.Label();
            this.txtMotivoAumento = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtActualizarCargo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtActualizarNombre = new System.Windows.Forms.TextBox();
            this.cmbActualizarSeleccion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControlVistas = new System.Windows.Forms.TabControl();
            this.tabArbol = new System.Windows.Forms.TabPage();
            this.panelArbol = new System.Windows.Forms.Panel();
            this.tabDirectorio = new System.Windows.Forms.TabPage();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.tabAprobaciones = new System.Windows.Forms.TabPage();
            this.dgvSolicitudes = new System.Windows.Forms.DataGridView();
            this.panelAprobacionAcciones = new System.Windows.Forms.Panel();
            this.lblMotivoRechazo = new System.Windows.Forms.Label();
            this.txtMotivoRechazo = new System.Windows.Forms.TextBox();
            this.btnAprobarDespido = new System.Windows.Forms.Button();
            this.btnRechazarDespido = new System.Windows.Forms.Button();
            this.panelStats = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblZoom = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControlVistas.SuspendLayout();
            this.tabArbol.SuspendLayout();
            this.tabDirectorio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.tabAprobaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).BeginInit();
            this.panelAprobacionAcciones.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombre.Location = new System.Drawing.Point(70, 22);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(255, 26);
            this.txtNombre.TabIndex = 15;
            // 
            // grup
            // 
            this.grup.BackColor = System.Drawing.Color.White;
            this.grup.Controls.Add(this.txtPassword);
            this.grup.Controls.Add(this.txtUsername);
            this.grup.Controls.Add(this.label20);
            this.grup.Controls.Add(this.label18);
            this.grup.Controls.Add(this.label19);
            this.grup.Controls.Add(this.cmbCargo);
            this.grup.Controls.Add(this.txtDui);
            this.grup.Controls.Add(this.label15);
            this.grup.Controls.Add(this.cmbJefe);
            this.grup.Controls.Add(this.label3);
            this.grup.Controls.Add(this.btnIngresarEmpleado);
            this.grup.Controls.Add(this.label2);
            this.grup.Controls.Add(this.label1);
            this.grup.Controls.Add(this.txtNombre);
            this.grup.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grup.Location = new System.Drawing.Point(10, 10);
            this.grup.Name = "grup";
            this.grup.Size = new System.Drawing.Size(340, 229);
            this.grup.TabIndex = 2;
            this.grup.TabStop = false;
            this.grup.Text = "✨ Nuevo Empleado";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.Location = new System.Drawing.Point(70, 167);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(255, 26);
            this.txtPassword.TabIndex = 0;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsername.Location = new System.Drawing.Point(70, 137);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(255, 26);
            this.txtUsername.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Gray;
            this.label20.Location = new System.Drawing.Point(10, 115);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(174, 20);
            this.label20.TabIndex = 2;
            this.label20.Text = "Credenciales de Acceso:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label18.Location = new System.Drawing.Point(10, 170);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 19);
            this.label18.TabIndex = 3;
            this.label18.Text = "Pass:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label19.Location = new System.Drawing.Point(10, 140);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 19);
            this.label19.TabIndex = 4;
            this.label19.Text = "Correo:";
            // 
            // cmbCargo
            // 
            this.cmbCargo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCargo.Location = new System.Drawing.Point(70, 52);
            this.cmbCargo.Name = "cmbCargo";
            this.cmbCargo.Size = new System.Drawing.Size(100, 27);
            this.cmbCargo.TabIndex = 5;
            // 
            // txtDui
            // 
            this.txtDui.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDui.Location = new System.Drawing.Point(230, 82);
            this.txtDui.Name = "txtDui";
            this.txtDui.Size = new System.Drawing.Size(95, 26);
            this.txtDui.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label15.Location = new System.Drawing.Point(180, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 19);
            this.label15.TabIndex = 7;
            this.label15.Text = "DUI:";
            // 
            // cmbJefe
            // 
            this.cmbJefe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbJefe.Location = new System.Drawing.Point(70, 82);
            this.cmbJefe.Name = "cmbJefe";
            this.cmbJefe.Size = new System.Drawing.Size(100, 27);
            this.cmbJefe.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(10, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Jefe:";
            // 
            // btnIngresarEmpleado
            // 
            this.btnIngresarEmpleado.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnIngresarEmpleado.FlatAppearance.BorderSize = 0;
            this.btnIngresarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarEmpleado.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnIngresarEmpleado.ForeColor = System.Drawing.Color.White;
            this.btnIngresarEmpleado.Location = new System.Drawing.Point(0, 199);
            this.btnIngresarEmpleado.Name = "btnIngresarEmpleado";
            this.btnIngresarEmpleado.Size = new System.Drawing.Size(340, 30);
            this.btnIngresarEmpleado.TabIndex = 12;
            this.btnIngresarEmpleado.Text = "Ingresar Empleado";
            this.btnIngresarEmpleado.UseVisualStyleBackColor = false;
            this.btnIngresarEmpleado.Click += new System.EventHandler(this.btnIngresarEmpleado_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(10, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "Cargo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nombre:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.cmbNuevoJefe);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbEliminar);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblMotivoDespido);
            this.groupBox2.Controls.Add(this.txtMotivoDespido);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(10, 451);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 150);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "🗑️ Despedir Empleado";
            // 
            // cmbNuevoJefe
            // 
            this.cmbNuevoJefe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbNuevoJefe.Location = new System.Drawing.Point(130, 52);
            this.cmbNuevoJefe.Name = "cmbNuevoJefe";
            this.cmbNuevoJefe.Size = new System.Drawing.Size(195, 27);
            this.cmbNuevoJefe.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(10, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Reasignar equipo:";
            // 
            // cmbEliminar
            // 
            this.cmbEliminar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEliminar.Location = new System.Drawing.Point(130, 22);
            this.cmbEliminar.Name = "cmbEliminar";
            this.cmbEliminar.Size = new System.Drawing.Size(195, 27);
            this.cmbEliminar.TabIndex = 2;
            this.cmbEliminar.SelectedIndexChanged += new System.EventHandler(this.cmbEliminar_SelectedIndexChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(10, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Empleado:";
            // 
            // lblMotivoDespido
            // 
            this.lblMotivoDespido.AutoSize = true;
            this.lblMotivoDespido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMotivoDespido.Location = new System.Drawing.Point(10, 85);
            this.lblMotivoDespido.Name = "lblMotivoDespido";
            this.lblMotivoDespido.Size = new System.Drawing.Size(56, 19);
            this.lblMotivoDespido.TabIndex = 4;
            this.lblMotivoDespido.Text = "Motivo:";
            // 
            // txtMotivoDespido
            // 
            this.txtMotivoDespido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMotivoDespido.Location = new System.Drawing.Point(130, 82);
            this.txtMotivoDespido.Name = "txtMotivoDespido";
            this.txtMotivoDespido.Size = new System.Drawing.Size(195, 26);
            this.txtMotivoDespido.TabIndex = 5;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Firebrick;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(2, 123);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(338, 27);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Procesar / Solicitar Despido";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.btnActualizar);
            this.groupBox3.Controls.Add(this.cmbActualizarJefe);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.lblEscala);
            this.groupBox3.Controls.Add(this.cmbEscalaSalarial);
            this.groupBox3.Controls.Add(this.lblMotivoAumento);
            this.groupBox3.Controls.Add(this.txtMotivoAumento);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtActualizarCargo);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtActualizarNombre);
            this.groupBox3.Controls.Add(this.cmbActualizarSeleccion);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(10, 245);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 199);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "✏️ Actualizar Datos y Escala";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBox1.Location = new System.Drawing.Point(215, 112);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(110, 26);
            this.textBox1.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label16.Location = new System.Drawing.Point(180, 115);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 19);
            this.label16.TabIndex = 1;
            this.label16.Text = "DUI:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(0, 175);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(340, 25);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Guardar Cambios de Empleado";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // cmbActualizarJefe
            // 
            this.cmbActualizarJefe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbActualizarJefe.Location = new System.Drawing.Point(215, 82);
            this.cmbActualizarJefe.Name = "cmbActualizarJefe";
            this.cmbActualizarJefe.Size = new System.Drawing.Size(110, 27);
            this.cmbActualizarJefe.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label11.Location = new System.Drawing.Point(180, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 19);
            this.label11.TabIndex = 4;
            this.label11.Text = "Jefe:";
            // 
            // lblEscala
            // 
            this.lblEscala.AutoSize = true;
            this.lblEscala.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEscala.Location = new System.Drawing.Point(10, 115);
            this.lblEscala.Name = "lblEscala";
            this.lblEscala.Size = new System.Drawing.Size(48, 19);
            this.lblEscala.TabIndex = 5;
            this.lblEscala.Text = "Escala:";
            // 
            // cmbEscalaSalarial
            // 
            this.cmbEscalaSalarial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEscalaSalarial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEscalaSalarial.Location = new System.Drawing.Point(70, 112);
            this.cmbEscalaSalarial.Name = "cmbEscalaSalarial";
            this.cmbEscalaSalarial.Size = new System.Drawing.Size(100, 27);
            this.cmbEscalaSalarial.TabIndex = 6;
            // 
            // lblMotivoAumento
            // 
            this.lblMotivoAumento.AutoSize = true;
            this.lblMotivoAumento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMotivoAumento.Location = new System.Drawing.Point(10, 145);
            this.lblMotivoAumento.Name = "lblMotivoAumento";
            this.lblMotivoAumento.Size = new System.Drawing.Size(64, 19);
            this.lblMotivoAumento.TabIndex = 7;
            this.lblMotivoAumento.Text = "Justificar:";
            // 
            // txtMotivoAumento
            // 
            this.txtMotivoAumento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMotivoAumento.Location = new System.Drawing.Point(70, 142);
            this.txtMotivoAumento.Name = "txtMotivoAumento";
            this.txtMotivoAumento.Size = new System.Drawing.Size(255, 26);
            this.txtMotivoAumento.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.Location = new System.Drawing.Point(10, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 19);
            this.label9.TabIndex = 9;
            this.label9.Text = "Cargo:";
            // 
            // txtActualizarCargo
            // 
            this.txtActualizarCargo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtActualizarCargo.Location = new System.Drawing.Point(70, 82);
            this.txtActualizarCargo.Name = "txtActualizarCargo";
            this.txtActualizarCargo.Size = new System.Drawing.Size(100, 26);
            this.txtActualizarCargo.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.Location = new System.Drawing.Point(10, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 19);
            this.label8.TabIndex = 11;
            this.label8.Text = "Nombre:";
            // 
            // txtActualizarNombre
            // 
            this.txtActualizarNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtActualizarNombre.Location = new System.Drawing.Point(70, 52);
            this.txtActualizarNombre.Name = "txtActualizarNombre";
            this.txtActualizarNombre.Size = new System.Drawing.Size(255, 26);
            this.txtActualizarNombre.TabIndex = 12;
            // 
            // cmbActualizarSeleccion
            // 
            this.cmbActualizarSeleccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbActualizarSeleccion.Location = new System.Drawing.Point(70, 22);
            this.cmbActualizarSeleccion.Name = "cmbActualizarSeleccion";
            this.cmbActualizarSeleccion.Size = new System.Drawing.Size(255, 27);
            this.cmbActualizarSeleccion.TabIndex = 13;
            this.cmbActualizarSeleccion.SelectedIndexChanged += new System.EventHandler(this.cmbActualizarSeleccion_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.Location = new System.Drawing.Point(10, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 19);
            this.label7.TabIndex = 14;
            this.label7.Text = "Buscar:";
            // 
            // tabControlVistas
            // 
            this.tabControlVistas.Controls.Add(this.tabArbol);
            this.tabControlVistas.Controls.Add(this.tabDirectorio);
            this.tabControlVistas.Controls.Add(this.tabAprobaciones);
            this.tabControlVistas.Location = new System.Drawing.Point(360, 10);
            this.tabControlVistas.Name = "tabControlVistas";
            this.tabControlVistas.SelectedIndex = 0;
            this.tabControlVistas.Size = new System.Drawing.Size(710, 381);
            this.tabControlVistas.TabIndex = 8;
            // 
            // tabArbol
            // 
            this.tabArbol.Controls.Add(this.panelArbol);
            this.tabArbol.Location = new System.Drawing.Point(4, 28);
            this.tabArbol.Name = "tabArbol";
            this.tabArbol.Padding = new System.Windows.Forms.Padding(3);
            this.tabArbol.Size = new System.Drawing.Size(702, 349);
            this.tabArbol.TabIndex = 0;
            this.tabArbol.Text = "🌳 Árbol Organizacional";
            this.tabArbol.UseVisualStyleBackColor = true;
            // 
            // panelArbol
            // 
            this.panelArbol.BackColor = System.Drawing.Color.White;
            this.panelArbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelArbol.Location = new System.Drawing.Point(3, 3);
            this.panelArbol.Name = "panelArbol";
            this.panelArbol.Size = new System.Drawing.Size(696, 343);
            this.panelArbol.TabIndex = 3;
            // 
            // tabDirectorio
            // 
            this.tabDirectorio.Controls.Add(this.dgvEmpleados);
            this.tabDirectorio.Location = new System.Drawing.Point(4, 28);
            this.tabDirectorio.Name = "tabDirectorio";
            this.tabDirectorio.Padding = new System.Windows.Forms.Padding(3);
            this.tabDirectorio.Size = new System.Drawing.Size(702, 349);
            this.tabDirectorio.TabIndex = 1;
            this.tabDirectorio.Text = "📋 Directorio de Personal";
            this.tabDirectorio.UseVisualStyleBackColor = true;
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmpleados.Location = new System.Drawing.Point(3, 3);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.RowHeadersWidth = 47;
            this.dgvEmpleados.Size = new System.Drawing.Size(696, 343);
            this.dgvEmpleados.TabIndex = 0;
            // 
            // tabAprobaciones
            // 
            this.tabAprobaciones.Controls.Add(this.dgvSolicitudes);
            this.tabAprobaciones.Controls.Add(this.panelAprobacionAcciones);
            this.tabAprobaciones.Location = new System.Drawing.Point(4, 28);
            this.tabAprobaciones.Name = "tabAprobaciones";
            this.tabAprobaciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabAprobaciones.Size = new System.Drawing.Size(702, 349);
            this.tabAprobaciones.TabIndex = 2;
            this.tabAprobaciones.Text = "⚖️ Bandeja de Despidos (Dirección)";
            this.tabAprobaciones.UseVisualStyleBackColor = true;
            // 
            // dgvSolicitudes
            // 
            this.dgvSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitudes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSolicitudes.Location = new System.Drawing.Point(3, 3);
            this.dgvSolicitudes.Name = "dgvSolicitudes";
            this.dgvSolicitudes.RowHeadersWidth = 47;
            this.dgvSolicitudes.Size = new System.Drawing.Size(696, 299);
            this.dgvSolicitudes.TabIndex = 0;
            // 
            // panelAprobacionAcciones
            // 
            this.panelAprobacionAcciones.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelAprobacionAcciones.Controls.Add(this.lblMotivoRechazo);
            this.panelAprobacionAcciones.Controls.Add(this.txtMotivoRechazo);
            this.panelAprobacionAcciones.Controls.Add(this.btnAprobarDespido);
            this.panelAprobacionAcciones.Controls.Add(this.btnRechazarDespido);
            this.panelAprobacionAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAprobacionAcciones.Location = new System.Drawing.Point(3, 302);
            this.panelAprobacionAcciones.Name = "panelAprobacionAcciones";
            this.panelAprobacionAcciones.Size = new System.Drawing.Size(696, 44);
            this.panelAprobacionAcciones.TabIndex = 1;
            // 
            // lblMotivoRechazo
            // 
            this.lblMotivoRechazo.AutoSize = true;
            this.lblMotivoRechazo.Location = new System.Drawing.Point(10, 11);
            this.lblMotivoRechazo.Name = "lblMotivoRechazo";
            this.lblMotivoRechazo.Size = new System.Drawing.Size(145, 19);
            this.lblMotivoRechazo.TabIndex = 0;
            this.lblMotivoRechazo.Text = "Motivo (Si se rechaza):";
            // 
            // txtMotivoRechazo
            // 
            this.txtMotivoRechazo.Location = new System.Drawing.Point(161, 8);
            this.txtMotivoRechazo.Name = "txtMotivoRechazo";
            this.txtMotivoRechazo.Size = new System.Drawing.Size(311, 26);
            this.txtMotivoRechazo.TabIndex = 1;
            // 
            // btnAprobarDespido
            // 
            this.btnAprobarDespido.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAprobarDespido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAprobarDespido.ForeColor = System.Drawing.Color.White;
            this.btnAprobarDespido.Location = new System.Drawing.Point(478, 7);
            this.btnAprobarDespido.Name = "btnAprobarDespido";
            this.btnAprobarDespido.Size = new System.Drawing.Size(97, 28);
            this.btnAprobarDespido.TabIndex = 2;
            this.btnAprobarDespido.Text = "✅ Aprobar Despido";
            this.btnAprobarDespido.UseVisualStyleBackColor = false;
            this.btnAprobarDespido.Click += new System.EventHandler(this.btnAprobarDespido_Click);
            // 
            // btnRechazarDespido
            // 
            this.btnRechazarDespido.BackColor = System.Drawing.Color.OrangeRed;
            this.btnRechazarDespido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechazarDespido.ForeColor = System.Drawing.Color.White;
            this.btnRechazarDespido.Location = new System.Drawing.Point(581, 7);
            this.btnRechazarDespido.Name = "btnRechazarDespido";
            this.btnRechazarDespido.Size = new System.Drawing.Size(103, 28);
            this.btnRechazarDespido.TabIndex = 3;
            this.btnRechazarDespido.Text = "❌ Denegar Solicitud";
            this.btnRechazarDespido.UseVisualStyleBackColor = false;
            this.btnRechazarDespido.Click += new System.EventHandler(this.btnRechazarDespido_Click);
            // 
            // panelStats
            // 
            this.panelStats.Location = new System.Drawing.Point(10, 25);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(690, 145);
            this.panelStats.TabIndex = 4;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.panelStats);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox5.Location = new System.Drawing.Point(360, 420);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(710, 180);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "📊 Estadísticas por Departamentos";
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(967, 394);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(84, 19);
            this.lblZoom.TabIndex = 0;
            this.lblZoom.Text = "Zoom 100%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(365, 394);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(495, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Presionando Ctrl y usando la rueda del mouse puedes regular el zoom del arbol";
            // 
            // FormGestionEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1090, 613);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblZoom);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControlVistas);
            this.Controls.Add(this.grup);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGestionEmpleados";
            this.Text = "Gestión de Empleados";
            this.grup.ResumeLayout(false);
            this.grup.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControlVistas.ResumeLayout(false);
            this.tabArbol.ResumeLayout(false);
            this.tabDirectorio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.tabAprobaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).EndInit();
            this.panelAprobacionAcciones.ResumeLayout(false);
            this.panelAprobacionAcciones.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Existing Controls
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.GroupBox grup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbJefe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIngresarEmpleado;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox cmbEliminar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbNuevoJefe;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbActualizarJefe;
        private System.Windows.Forms.Label label11;
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
        private System.Windows.Forms.Label lblEscala;
        private System.Windows.Forms.ComboBox cmbEscalaSalarial;
        private System.Windows.Forms.Label lblMotivoAumento;
        private System.Windows.Forms.TextBox txtMotivoAumento;  

        // New Controls
        private System.Windows.Forms.Label lblMotivoDespido;
        private System.Windows.Forms.TextBox txtMotivoDespido;
        private System.Windows.Forms.TabControl tabControlVistas;
        private System.Windows.Forms.TabPage tabArbol;
        private System.Windows.Forms.Panel panelArbol;
        private System.Windows.Forms.TabPage tabDirectorio;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.TabPage tabAprobaciones;
        private System.Windows.Forms.DataGridView dgvSolicitudes;
        private System.Windows.Forms.Panel panelAprobacionAcciones;
        private System.Windows.Forms.Label lblMotivoRechazo;
        private System.Windows.Forms.TextBox txtMotivoRechazo;
        private System.Windows.Forms.Button btnAprobarDespido;
        private System.Windows.Forms.Button btnRechazarDespido;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.Label label4;
    }
}