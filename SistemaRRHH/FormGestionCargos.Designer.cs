namespace SistemaRRHH
{
    partial class FormGestionCargos
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
            this.tabControlPrincipal = new System.Windows.Forms.TabControl();
            this.tabCargos = new System.Windows.Forms.TabPage();
            this.gbCrudCargos = new System.Windows.Forms.GroupBox();
            this.lblNombreCargo = new System.Windows.Forms.Label();
            this.txtNombreCargo = new System.Windows.Forms.TextBox();
            this.lblSueldoBase = new System.Windows.Forms.Label();
            this.txtSueldoBase = new System.Windows.Forms.TextBox();
            this.lblEscala1 = new System.Windows.Forms.Label();
            this.txtEscala1 = new System.Windows.Forms.TextBox();
            this.lblEscala2 = new System.Windows.Forms.Label();
            this.txtEscala2 = new System.Windows.Forms.TextBox();
            this.lblEscala3 = new System.Windows.Forms.Label();
            this.txtEscala3 = new System.Windows.Forms.TextBox();
            this.btnGuardarCargo = new System.Windows.Forms.Button();
            this.btnEditarCargo = new System.Windows.Forms.Button();
            this.btnEliminarCargo = new System.Windows.Forms.Button();
            this.dgvCargos = new System.Windows.Forms.DataGridView();
            this.gbFusionCargos = new System.Windows.Forms.GroupBox();
            this.cmbCargoFusion1 = new System.Windows.Forms.ComboBox();
            this.cmbCargoFusion2 = new System.Windows.Forms.ComboBox();
            this.txtNuevoCargoFusion = new System.Windows.Forms.TextBox();
            this.btnFusionarCargos = new System.Windows.Forms.Button();
            this.tabDepartamentos = new System.Windows.Forms.TabPage();
            this.gbCrudDeptos = new System.Windows.Forms.GroupBox();
            this.txtNombreDepto = new System.Windows.Forms.TextBox();
            this.btnGuardarDepto = new System.Windows.Forms.Button();
            this.dgvDepartamentos = new System.Windows.Forms.DataGridView();
            this.gbFusionDeptos = new System.Windows.Forms.GroupBox();
            this.rbJefe1 = new System.Windows.Forms.RadioButton();
            this.rbJefe2 = new System.Windows.Forms.RadioButton();
            this.cmbFusionDepto1 = new System.Windows.Forms.ComboBox();
            this.cmbFusionDepto2 = new System.Windows.Forms.ComboBox();
            this.txtNuevoDeptoFusion = new System.Windows.Forms.TextBox();
            this.btnFusionarDeptos = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();

            this.tabControlPrincipal.SuspendLayout();
            this.tabCargos.SuspendLayout();
            this.gbCrudCargos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargos)).BeginInit();
            this.gbFusionCargos.SuspendLayout();
            this.tabDepartamentos.SuspendLayout();
            this.gbCrudDeptos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentos)).BeginInit();
            this.gbFusionDeptos.SuspendLayout();
            this.SuspendLayout();

            // 
            // tabControlPrincipal
            // 
            this.tabControlPrincipal.Controls.Add(this.tabCargos);
            this.tabControlPrincipal.Controls.Add(this.tabDepartamentos);
            this.tabControlPrincipal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tabControlPrincipal.Location = new System.Drawing.Point(12, 60);
            this.tabControlPrincipal.Name = "tabControlPrincipal";
            this.tabControlPrincipal.SelectedIndex = 0;
            this.tabControlPrincipal.Size = new System.Drawing.Size(1066, 540);
            this.tabControlPrincipal.TabIndex = 1;

            // 
            // tabCargos
            // 
            this.tabCargos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabCargos.Controls.Add(this.gbCrudCargos);
            this.tabCargos.Controls.Add(this.dgvCargos);
            this.tabCargos.Controls.Add(this.gbFusionCargos);
            this.tabCargos.Location = new System.Drawing.Point(4, 26);
            this.tabCargos.Name = "tabCargos";
            this.tabCargos.Padding = new System.Windows.Forms.Padding(3);
            this.tabCargos.Size = new System.Drawing.Size(1058, 510);
            this.tabCargos.TabIndex = 0;
            this.tabCargos.Text = "🏢 Gestión de Cargos y Salarios";

            // 
            // gbCrudCargos
            // 
            this.gbCrudCargos.BackColor = System.Drawing.Color.White;
            this.gbCrudCargos.Controls.Add(this.lblNombreCargo);
            this.gbCrudCargos.Controls.Add(this.txtNombreCargo);
            this.gbCrudCargos.Controls.Add(this.lblSueldoBase);
            this.gbCrudCargos.Controls.Add(this.txtSueldoBase);
            this.gbCrudCargos.Controls.Add(this.lblEscala1);
            this.gbCrudCargos.Controls.Add(this.txtEscala1);
            this.gbCrudCargos.Controls.Add(this.lblEscala2);
            this.gbCrudCargos.Controls.Add(this.txtEscala2);
            this.gbCrudCargos.Controls.Add(this.lblEscala3);
            this.gbCrudCargos.Controls.Add(this.txtEscala3);
            this.gbCrudCargos.Controls.Add(this.btnGuardarCargo);
            this.gbCrudCargos.Controls.Add(this.btnEditarCargo);
            this.gbCrudCargos.Controls.Add(this.btnEliminarCargo);
            this.gbCrudCargos.Location = new System.Drawing.Point(20, 20);
            this.gbCrudCargos.Name = "gbCrudCargos";
            this.gbCrudCargos.Size = new System.Drawing.Size(1010, 160);
            this.gbCrudCargos.TabIndex = 0;
            this.gbCrudCargos.TabStop = false;
            this.gbCrudCargos.Text = "Crear / Editar Cargo";

            this.lblNombreCargo.AutoSize = true;
            this.lblNombreCargo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombreCargo.Location = new System.Drawing.Point(20, 40);
            this.lblNombreCargo.Name = "lblNombreCargo";
            this.lblNombreCargo.Size = new System.Drawing.Size(109, 15);
            this.lblNombreCargo.TabIndex = 0;
            this.lblNombreCargo.Text = "Nombre del Cargo:";

            this.txtNombreCargo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombreCargo.Location = new System.Drawing.Point(140, 37);
            this.txtNombreCargo.Name = "txtNombreCargo";
            this.txtNombreCargo.Size = new System.Drawing.Size(250, 23);
            this.txtNombreCargo.TabIndex = 1;

            this.lblSueldoBase.AutoSize = true;
            this.lblSueldoBase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSueldoBase.Location = new System.Drawing.Point(20, 80);
            this.lblSueldoBase.Name = "lblSueldoBase";
            this.lblSueldoBase.Size = new System.Drawing.Size(90, 15);
            this.lblSueldoBase.TabIndex = 2;
            this.lblSueldoBase.Text = "Sueldo Base ($):";

            this.txtSueldoBase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSueldoBase.Location = new System.Drawing.Point(140, 77);
            this.txtSueldoBase.Name = "txtSueldoBase";
            this.txtSueldoBase.Size = new System.Drawing.Size(120, 23);
            this.txtSueldoBase.TabIndex = 3;

            this.lblEscala1.AutoSize = true;
            this.lblEscala1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEscala1.Location = new System.Drawing.Point(450, 30);
            this.lblEscala1.Name = "lblEscala1";
            this.lblEscala1.Size = new System.Drawing.Size(102, 15);
            this.lblEscala1.TabIndex = 4;
            this.lblEscala1.Text = "+1 Año (Escala 1):";

            this.txtEscala1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEscala1.Location = new System.Drawing.Point(570, 27);
            this.txtEscala1.Name = "txtEscala1";
            this.txtEscala1.Size = new System.Drawing.Size(100, 23);
            this.txtEscala1.TabIndex = 5;

            this.lblEscala2.AutoSize = true;
            this.lblEscala2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEscala2.Location = new System.Drawing.Point(450, 70);
            this.lblEscala2.Name = "lblEscala2";
            this.lblEscala2.Size = new System.Drawing.Size(108, 15);
            this.lblEscala2.TabIndex = 6;
            this.lblEscala2.Text = "+3 Años (Escala 2):";

            this.txtEscala2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEscala2.Location = new System.Drawing.Point(570, 67);
            this.txtEscala2.Name = "txtEscala2";
            this.txtEscala2.Size = new System.Drawing.Size(100, 23);
            this.txtEscala2.TabIndex = 7;

            this.lblEscala3.AutoSize = true;
            this.lblEscala3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEscala3.Location = new System.Drawing.Point(450, 110);
            this.lblEscala3.Name = "lblEscala3";
            this.lblEscala3.Size = new System.Drawing.Size(108, 15);
            this.lblEscala3.TabIndex = 8;
            this.lblEscala3.Text = "+5 Años (Escala 3):";

            this.txtEscala3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEscala3.Location = new System.Drawing.Point(570, 107);
            this.txtEscala3.Name = "txtEscala3";
            this.txtEscala3.Size = new System.Drawing.Size(100, 23);
            this.txtEscala3.TabIndex = 9;

            this.btnGuardarCargo.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGuardarCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCargo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarCargo.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCargo.Location = new System.Drawing.Point(780, 25);
            this.btnGuardarCargo.Name = "btnGuardarCargo";
            this.btnGuardarCargo.Size = new System.Drawing.Size(200, 30);
            this.btnGuardarCargo.TabIndex = 10;
            this.btnGuardarCargo.Text = "💾 Guardar Cargo";
            this.btnGuardarCargo.UseVisualStyleBackColor = false;

            this.btnEditarCargo.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEditarCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarCargo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditarCargo.ForeColor = System.Drawing.Color.White;
            this.btnEditarCargo.Location = new System.Drawing.Point(780, 65);
            this.btnEditarCargo.Name = "btnEditarCargo";
            this.btnEditarCargo.Size = new System.Drawing.Size(200, 30);
            this.btnEditarCargo.TabIndex = 11;
            this.btnEditarCargo.Text = "✏️ Actualizar";
            this.btnEditarCargo.UseVisualStyleBackColor = false;

            this.btnEliminarCargo.BackColor = System.Drawing.Color.Firebrick;
            this.btnEliminarCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarCargo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarCargo.ForeColor = System.Drawing.Color.White;
            this.btnEliminarCargo.Location = new System.Drawing.Point(780, 105);
            this.btnEliminarCargo.Name = "btnEliminarCargo";
            this.btnEliminarCargo.Size = new System.Drawing.Size(200, 30);
            this.btnEliminarCargo.TabIndex = 12;
            this.btnEliminarCargo.Text = "🗑️ Eliminar";
            this.btnEliminarCargo.UseVisualStyleBackColor = false;

            // 
            // dgvCargos
            // 
            this.dgvCargos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCargos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargos.Location = new System.Drawing.Point(20, 190);
            this.dgvCargos.Name = "dgvCargos";
            this.dgvCargos.Size = new System.Drawing.Size(1010, 160);
            this.dgvCargos.TabIndex = 1;

            // 
            // gbFusionCargos
            // 
            this.gbFusionCargos.BackColor = System.Drawing.Color.White;
            this.gbFusionCargos.Controls.Add(this.cmbCargoFusion1);
            this.gbFusionCargos.Controls.Add(this.cmbCargoFusion2);
            this.gbFusionCargos.Controls.Add(this.txtNuevoCargoFusion);
            this.gbFusionCargos.Controls.Add(this.btnFusionarCargos);
            this.gbFusionCargos.Location = new System.Drawing.Point(20, 360);
            this.gbFusionCargos.Name = "gbFusionCargos";
            this.gbFusionCargos.Size = new System.Drawing.Size(1010, 130);
            this.gbFusionCargos.TabIndex = 2;
            this.gbFusionCargos.TabStop = false;
            this.gbFusionCargos.Text = "🤝 Fusión de Cargos";

            this.cmbCargoFusion1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCargoFusion1.FormattingEnabled = true;
            this.cmbCargoFusion1.Location = new System.Drawing.Point(20, 35);
            this.cmbCargoFusion1.Name = "cmbCargoFusion1";
            this.cmbCargoFusion1.Size = new System.Drawing.Size(400, 23);
            this.cmbCargoFusion1.TabIndex = 0;
            this.cmbCargoFusion1.Text = "-- Seleccione Cargo 1 --";

            this.cmbCargoFusion2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCargoFusion2.FormattingEnabled = true;
            this.cmbCargoFusion2.Location = new System.Drawing.Point(20, 75);
            this.cmbCargoFusion2.Name = "cmbCargoFusion2";
            this.cmbCargoFusion2.Size = new System.Drawing.Size(400, 23);
            this.cmbCargoFusion2.TabIndex = 1;
            this.cmbCargoFusion2.Text = "-- Seleccione Cargo 2 --";

            this.txtNuevoCargoFusion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNuevoCargoFusion.Location = new System.Drawing.Point(480, 35);
            this.txtNuevoCargoFusion.Name = "txtNuevoCargoFusion";
            this.txtNuevoCargoFusion.Size = new System.Drawing.Size(500, 23);
            this.txtNuevoCargoFusion.TabIndex = 2;
            this.txtNuevoCargoFusion.Text = "Nombre del Nuevo Cargo Fusionado";

            this.btnFusionarCargos.BackColor = System.Drawing.Color.DarkOrange;
            this.btnFusionarCargos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFusionarCargos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFusionarCargos.ForeColor = System.Drawing.Color.White;
            this.btnFusionarCargos.Location = new System.Drawing.Point(480, 75);
            this.btnFusionarCargos.Name = "btnFusionarCargos";
            this.btnFusionarCargos.Size = new System.Drawing.Size(500, 30);
            this.btnFusionarCargos.TabIndex = 3;
            this.btnFusionarCargos.Text = "⚡ Ejecutar Fusión de Cargos";
            this.btnFusionarCargos.UseVisualStyleBackColor = false;

            // 
            // tabDepartamentos
            // 
            this.tabDepartamentos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabDepartamentos.Controls.Add(this.gbCrudDeptos);
            this.tabDepartamentos.Controls.Add(this.dgvDepartamentos);
            this.tabDepartamentos.Controls.Add(this.gbFusionDeptos);
            this.tabDepartamentos.Location = new System.Drawing.Point(4, 26);
            this.tabDepartamentos.Name = "tabDepartamentos";
            this.tabDepartamentos.Padding = new System.Windows.Forms.Padding(3);
            this.tabDepartamentos.Size = new System.Drawing.Size(1058, 510);
            this.tabDepartamentos.TabIndex = 1;
            this.tabDepartamentos.Text = "📁 Gestión de Departamentos";

            // 
            // gbCrudDeptos
            // 
            this.gbCrudDeptos.BackColor = System.Drawing.Color.White;
            this.gbCrudDeptos.Controls.Add(this.txtNombreDepto);
            this.gbCrudDeptos.Controls.Add(this.btnGuardarDepto);
            this.gbCrudDeptos.Location = new System.Drawing.Point(20, 20);
            this.gbCrudDeptos.Name = "gbCrudDeptos";
            this.gbCrudDeptos.Size = new System.Drawing.Size(1010, 100);
            this.gbCrudDeptos.TabIndex = 0;
            this.gbCrudDeptos.TabStop = false;
            this.gbCrudDeptos.Text = "Crear Departamento";

            this.txtNombreDepto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombreDepto.Location = new System.Drawing.Point(20, 45);
            this.txtNombreDepto.Name = "txtNombreDepto";
            this.txtNombreDepto.Size = new System.Drawing.Size(400, 23);
            this.txtNombreDepto.TabIndex = 0;

            this.btnGuardarDepto.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGuardarDepto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarDepto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarDepto.ForeColor = System.Drawing.Color.White;
            this.btnGuardarDepto.Location = new System.Drawing.Point(480, 42);
            this.btnGuardarDepto.Name = "btnGuardarDepto";
            this.btnGuardarDepto.Size = new System.Drawing.Size(250, 30);
            this.btnGuardarDepto.TabIndex = 1;
            this.btnGuardarDepto.Text = "💾 Guardar Depto";
            this.btnGuardarDepto.UseVisualStyleBackColor = false;

            // 
            // dgvDepartamentos
            // 
            this.dgvDepartamentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartamentos.Location = new System.Drawing.Point(20, 130);
            this.dgvDepartamentos.Name = "dgvDepartamentos";
            this.dgvDepartamentos.Size = new System.Drawing.Size(1010, 180);
            this.dgvDepartamentos.TabIndex = 1;

            // 
            // gbFusionDeptos
            // 
            this.gbFusionDeptos.BackColor = System.Drawing.Color.White;
            this.gbFusionDeptos.Controls.Add(this.rbJefe1);
            this.gbFusionDeptos.Controls.Add(this.rbJefe2);
            this.gbFusionDeptos.Controls.Add(this.cmbFusionDepto1);
            this.gbFusionDeptos.Controls.Add(this.cmbFusionDepto2);
            this.gbFusionDeptos.Controls.Add(this.txtNuevoDeptoFusion);
            this.gbFusionDeptos.Controls.Add(this.btnFusionarDeptos);
            this.gbFusionDeptos.Location = new System.Drawing.Point(20, 320);
            this.gbFusionDeptos.Name = "gbFusionDeptos";
            this.gbFusionDeptos.Size = new System.Drawing.Size(1010, 170);
            this.gbFusionDeptos.TabIndex = 2;
            this.gbFusionDeptos.TabStop = false;
            this.gbFusionDeptos.Text = "🤝 Fusión de Departamentos Estructurales";

            this.rbJefe1.AutoSize = true;
            this.rbJefe1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbJefe1.Location = new System.Drawing.Point(20, 40);
            this.rbJefe1.Name = "rbJefe1";
            this.rbJefe1.Size = new System.Drawing.Size(63, 19);
            this.rbJefe1.TabIndex = 0;
            this.rbJefe1.TabStop = true;
            this.rbJefe1.Text = "Líder 1:";
            this.rbJefe1.UseVisualStyleBackColor = true;

            this.rbJefe2.AutoSize = true;
            this.rbJefe2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbJefe2.Location = new System.Drawing.Point(20, 80);
            this.rbJefe2.Name = "rbJefe2";
            this.rbJefe2.Size = new System.Drawing.Size(63, 19);
            this.rbJefe2.TabIndex = 1;
            this.rbJefe2.TabStop = true;
            this.rbJefe2.Text = "Líder 2:";
            this.rbJefe2.UseVisualStyleBackColor = true;

            this.cmbFusionDepto1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFusionDepto1.FormattingEnabled = true;
            this.cmbFusionDepto1.Location = new System.Drawing.Point(100, 38);
            this.cmbFusionDepto1.Name = "cmbFusionDepto1";
            this.cmbFusionDepto1.Size = new System.Drawing.Size(320, 23);
            this.cmbFusionDepto1.TabIndex = 2;

            this.cmbFusionDepto2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFusionDepto2.FormattingEnabled = true;
            this.cmbFusionDepto2.Location = new System.Drawing.Point(100, 78);
            this.cmbFusionDepto2.Name = "cmbFusionDepto2";
            this.cmbFusionDepto2.Size = new System.Drawing.Size(320, 23);
            this.cmbFusionDepto2.TabIndex = 3;

            this.txtNuevoDeptoFusion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNuevoDeptoFusion.Location = new System.Drawing.Point(480, 38);
            this.txtNuevoDeptoFusion.Name = "txtNuevoDeptoFusion";
            this.txtNuevoDeptoFusion.Size = new System.Drawing.Size(500, 23);
            this.txtNuevoDeptoFusion.TabIndex = 4;
            this.txtNuevoDeptoFusion.Text = "Nuevo Nombre del Departamento";

            this.btnFusionarDeptos.BackColor = System.Drawing.Color.DarkOrange;
            this.btnFusionarDeptos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFusionarDeptos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFusionarDeptos.ForeColor = System.Drawing.Color.White;
            this.btnFusionarDeptos.Location = new System.Drawing.Point(480, 78);
            this.btnFusionarDeptos.Name = "btnFusionarDeptos";
            this.btnFusionarDeptos.Size = new System.Drawing.Size(500, 30);
            this.btnFusionarDeptos.TabIndex = 5;
            this.btnFusionarDeptos.Text = "⚡ Ejecutar Fusión de Deptos";
            this.btnFusionarDeptos.UseVisualStyleBackColor = false;

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitulo.Location = new System.Drawing.Point(12, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(388, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Cargos y Departamentos";

            // 
            // FormGestionCargos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1090, 613);
            this.Controls.Add(this.tabControlPrincipal);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGestionCargos";
            this.Text = "Gestión de Cargos";

            this.tabControlPrincipal.ResumeLayout(false);
            this.tabCargos.ResumeLayout(false);
            this.gbCrudCargos.ResumeLayout(false);
            this.gbCrudCargos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargos)).EndInit();
            this.gbFusionCargos.ResumeLayout(false);
            this.gbFusionCargos.PerformLayout();
            this.tabDepartamentos.ResumeLayout(false);
            this.gbCrudDeptos.ResumeLayout(false);
            this.gbCrudDeptos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentos)).EndInit();
            this.gbFusionDeptos.ResumeLayout(false);
            this.gbFusionDeptos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Contenedores Principales
        private System.Windows.Forms.TabControl tabControlPrincipal;
        private System.Windows.Forms.TabPage tabCargos;
        private System.Windows.Forms.TabPage tabDepartamentos;

        // Controles Cargos
        private System.Windows.Forms.GroupBox gbCrudCargos;
        private System.Windows.Forms.Label lblNombreCargo;
        private System.Windows.Forms.TextBox txtNombreCargo;
        private System.Windows.Forms.Label lblSueldoBase;
        private System.Windows.Forms.TextBox txtSueldoBase;
        private System.Windows.Forms.Label lblEscala1;
        private System.Windows.Forms.TextBox txtEscala1;
        private System.Windows.Forms.Label lblEscala2;
        private System.Windows.Forms.TextBox txtEscala2;
        private System.Windows.Forms.Label lblEscala3;
        private System.Windows.Forms.TextBox txtEscala3;
        private System.Windows.Forms.Button btnGuardarCargo;
        private System.Windows.Forms.Button btnEditarCargo;
        private System.Windows.Forms.Button btnEliminarCargo;
        private System.Windows.Forms.DataGridView dgvCargos;

        private System.Windows.Forms.GroupBox gbFusionCargos;
        private System.Windows.Forms.ComboBox cmbCargoFusion1;
        private System.Windows.Forms.ComboBox cmbCargoFusion2;
        private System.Windows.Forms.TextBox txtNuevoCargoFusion;
        private System.Windows.Forms.Button btnFusionarCargos;

        // Controles Deptos
        private System.Windows.Forms.GroupBox gbCrudDeptos;
        private System.Windows.Forms.TextBox txtNombreDepto;
        private System.Windows.Forms.Button btnGuardarDepto;
        private System.Windows.Forms.DataGridView dgvDepartamentos;

        private System.Windows.Forms.GroupBox gbFusionDeptos;
        private System.Windows.Forms.RadioButton rbJefe1;
        private System.Windows.Forms.RadioButton rbJefe2;
        private System.Windows.Forms.ComboBox cmbFusionDepto1;
        private System.Windows.Forms.ComboBox cmbFusionDepto2;
        private System.Windows.Forms.TextBox txtNuevoDeptoFusion;
        private System.Windows.Forms.Button btnFusionarDeptos;
        private System.Windows.Forms.Label lblTitulo;
    }
}