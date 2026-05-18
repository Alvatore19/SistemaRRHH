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
            this.lblNivelJerarquico = new System.Windows.Forms.Label();
            this.numNivelJerarquico = new System.Windows.Forms.NumericUpDown();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
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
            this.tabDepartamentos = new System.Windows.Forms.TabPage();
            this.gbCrudDeptos = new System.Windows.Forms.GroupBox();
            this.lblNombreDepto = new System.Windows.Forms.Label();
            this.txtNombreDepto = new System.Windows.Forms.TextBox();
            this.btnGuardarDepto = new System.Windows.Forms.Button();
            this.btnEditarDepto = new System.Windows.Forms.Button();
            this.btnEliminarDepto = new System.Windows.Forms.Button();
            this.dgvDepartamentos = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();

            this.tabControlPrincipal.SuspendLayout();
            this.tabCargos.SuspendLayout();
            this.gbCrudCargos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNivelJerarquico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargos)).BeginInit();
            this.tabDepartamentos.SuspendLayout();
            this.gbCrudDeptos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentos)).BeginInit();
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
            this.gbCrudCargos.Controls.Add(this.lblNivelJerarquico);
            this.gbCrudCargos.Controls.Add(this.numNivelJerarquico);
            this.gbCrudCargos.Controls.Add(this.lblDepartamento);
            this.gbCrudCargos.Controls.Add(this.cmbDepartamento);
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
            this.lblNombreCargo.Location = new System.Drawing.Point(20, 30);
            this.lblNombreCargo.Name = "lblNombreCargo";
            this.lblNombreCargo.Size = new System.Drawing.Size(109, 15);
            this.lblNombreCargo.TabIndex = 0;
            this.lblNombreCargo.Text = "Nombre del Cargo:";

            this.txtNombreCargo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombreCargo.Location = new System.Drawing.Point(140, 27);
            this.txtNombreCargo.Name = "txtNombreCargo";
            this.txtNombreCargo.Size = new System.Drawing.Size(250, 23);
            this.txtNombreCargo.TabIndex = 1;

            this.lblSueldoBase.AutoSize = true;
            this.lblSueldoBase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSueldoBase.Location = new System.Drawing.Point(20, 60);
            this.lblSueldoBase.Name = "lblSueldoBase";
            this.lblSueldoBase.Size = new System.Drawing.Size(90, 15);
            this.lblSueldoBase.TabIndex = 2;
            this.lblSueldoBase.Text = "Sueldo Base ($):";

            this.txtSueldoBase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSueldoBase.Location = new System.Drawing.Point(140, 57);
            this.txtSueldoBase.Name = "txtSueldoBase";
            this.txtSueldoBase.Size = new System.Drawing.Size(120, 23);
            this.txtSueldoBase.TabIndex = 3;

            this.lblNivelJerarquico.AutoSize = true;
            this.lblNivelJerarquico.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNivelJerarquico.Location = new System.Drawing.Point(20, 90);
            this.lblNivelJerarquico.Name = "lblNivelJerarquico";
            this.lblNivelJerarquico.Size = new System.Drawing.Size(97, 15);
            this.lblNivelJerarquico.TabIndex = 13;
            this.lblNivelJerarquico.Text = "Nivel Jerárquico:";

            this.numNivelJerarquico.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numNivelJerarquico.Location = new System.Drawing.Point(140, 87);
            this.numNivelJerarquico.Name = "numNivelJerarquico";
            this.numNivelJerarquico.Size = new System.Drawing.Size(120, 23);
            this.numNivelJerarquico.TabIndex = 14;
            this.numNivelJerarquico.Minimum = 1;
            this.numNivelJerarquico.Maximum = 4;
            this.numNivelJerarquico.Value = 4;

            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDepartamento.Location = new System.Drawing.Point(20, 120);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(86, 15);
            this.lblDepartamento.TabIndex = 15;
            this.lblDepartamento.Text = "Departamento:";

            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(140, 117);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(250, 23);
            this.cmbDepartamento.TabIndex = 16;

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
            // AMPLÍO EL ALTO DEL DATAGRIDVIEW
            this.dgvCargos.Size = new System.Drawing.Size(1010, 300);
            this.dgvCargos.TabIndex = 1;

            // 
            // tabDepartamentos
            // 
            this.tabDepartamentos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabDepartamentos.Controls.Add(this.gbCrudDeptos);
            this.tabDepartamentos.Controls.Add(this.dgvDepartamentos);
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
            this.gbCrudDeptos.Controls.Add(this.lblNombreDepto);
            this.gbCrudDeptos.Controls.Add(this.txtNombreDepto);
            this.gbCrudDeptos.Controls.Add(this.btnGuardarDepto);
            this.gbCrudDeptos.Controls.Add(this.btnEditarDepto);
            this.gbCrudDeptos.Controls.Add(this.btnEliminarDepto);
            this.gbCrudDeptos.Location = new System.Drawing.Point(20, 20);
            this.gbCrudDeptos.Name = "gbCrudDeptos";
            this.gbCrudDeptos.Size = new System.Drawing.Size(1010, 100);
            this.gbCrudDeptos.TabIndex = 0;
            this.gbCrudDeptos.TabStop = false;
            this.gbCrudDeptos.Text = "Crear / Editar Departamento";

            this.lblNombreDepto.AutoSize = true;
            this.lblNombreDepto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombreDepto.Location = new System.Drawing.Point(20, 30);
            this.lblNombreDepto.Name = "lblNombreDepto";
            this.lblNombreDepto.Size = new System.Drawing.Size(155, 15);
            this.lblNombreDepto.TabIndex = 2;
            this.lblNombreDepto.Text = "Nombre del Departamento:";

            this.txtNombreDepto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombreDepto.Location = new System.Drawing.Point(20, 50);
            this.txtNombreDepto.Name = "txtNombreDepto";
            this.txtNombreDepto.Size = new System.Drawing.Size(400, 23);
            this.txtNombreDepto.TabIndex = 0;

            this.btnGuardarDepto.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGuardarDepto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarDepto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarDepto.ForeColor = System.Drawing.Color.White;
            this.btnGuardarDepto.Location = new System.Drawing.Point(440, 47);
            this.btnGuardarDepto.Name = "btnGuardarDepto";
            this.btnGuardarDepto.Size = new System.Drawing.Size(150, 30);
            this.btnGuardarDepto.TabIndex = 1;
            this.btnGuardarDepto.Text = "💾 Guardar";
            this.btnGuardarDepto.UseVisualStyleBackColor = false;

            this.btnEditarDepto.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEditarDepto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarDepto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditarDepto.ForeColor = System.Drawing.Color.White;
            this.btnEditarDepto.Location = new System.Drawing.Point(610, 47);
            this.btnEditarDepto.Name = "btnEditarDepto";
            this.btnEditarDepto.Size = new System.Drawing.Size(150, 30);
            this.btnEditarDepto.TabIndex = 3;
            this.btnEditarDepto.Text = "✏️ Actualizar";
            this.btnEditarDepto.UseVisualStyleBackColor = false;

            this.btnEliminarDepto.BackColor = System.Drawing.Color.Firebrick;
            this.btnEliminarDepto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarDepto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarDepto.ForeColor = System.Drawing.Color.White;
            this.btnEliminarDepto.Location = new System.Drawing.Point(780, 47);
            this.btnEliminarDepto.Name = "btnEliminarDepto";
            this.btnEliminarDepto.Size = new System.Drawing.Size(150, 30);
            this.btnEliminarDepto.TabIndex = 4;
            this.btnEliminarDepto.Text = "🗑️ Eliminar";
            this.btnEliminarDepto.UseVisualStyleBackColor = false;

            // 
            // dgvDepartamentos
            // 
            this.dgvDepartamentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartamentos.Location = new System.Drawing.Point(20, 130);
            this.dgvDepartamentos.Name = "dgvDepartamentos";
            // AMPLÍO EL ALTO DEL DATAGRIDVIEW DE DEPARTAMENTOS
            this.dgvDepartamentos.Size = new System.Drawing.Size(1010, 360);
            this.dgvDepartamentos.TabIndex = 1;

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
            ((System.ComponentModel.ISupportInitialize)(this.numNivelJerarquico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargos)).EndInit();
            this.tabDepartamentos.ResumeLayout(false);
            this.gbCrudDeptos.ResumeLayout(false);
            this.gbCrudDeptos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPrincipal;
        private System.Windows.Forms.TabPage tabCargos;
        private System.Windows.Forms.TabPage tabDepartamentos;
        private System.Windows.Forms.GroupBox gbCrudCargos;
        private System.Windows.Forms.Label lblNombreCargo;
        private System.Windows.Forms.TextBox txtNombreCargo;
        private System.Windows.Forms.Label lblSueldoBase;
        private System.Windows.Forms.TextBox txtSueldoBase;
        private System.Windows.Forms.Label lblNivelJerarquico;
        private System.Windows.Forms.NumericUpDown numNivelJerarquico;

        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.ComboBox cmbDepartamento;

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

        // --- VARIABLES DE DEPARTAMENTOS ---
        private System.Windows.Forms.GroupBox gbCrudDeptos;
        private System.Windows.Forms.Label lblNombreDepto;
        private System.Windows.Forms.TextBox txtNombreDepto;
        private System.Windows.Forms.Button btnGuardarDepto;
        private System.Windows.Forms.Button btnEditarDepto;
        private System.Windows.Forms.Button btnEliminarDepto;
        private System.Windows.Forms.DataGridView dgvDepartamentos;
        // ----------------------------------

        private System.Windows.Forms.Label lblTitulo;
    }
}