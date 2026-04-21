namespace SistemaRRHH
{
    partial class FormDashboard
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

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDashboard));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnl_menuvertical = new System.Windows.Forms.Panel();
            this.btnPortal = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnCargos = new System.Windows.Forms.Button();
            this.btnAsistencia = new System.Windows.Forms.Button();
            this.btnGEmpleados = new System.Windows.Forms.Button();
            this.btnPermisos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.icon_Restaurar = new System.Windows.Forms.Button();
            this.icon_Max = new System.Windows.Forms.Button();
            this.icon_Minimizar = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pnl_menuvertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_menuvertical
            // 
            this.pnl_menuvertical.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnl_menuvertical.BackColor = System.Drawing.Color.White;
            this.pnl_menuvertical.Controls.Add(this.btnPortal);
            this.pnl_menuvertical.Controls.Add(this.pictureBox2);
            this.pnl_menuvertical.Controls.Add(this.btnLogOut);
            this.pnl_menuvertical.Controls.Add(this.btnCargos);
            this.pnl_menuvertical.Controls.Add(this.btnAsistencia);
            this.pnl_menuvertical.Controls.Add(this.btnGEmpleados);
            this.pnl_menuvertical.Controls.Add(this.btnPermisos);
            this.pnl_menuvertical.Controls.Add(this.pictureBox1);
            this.pnl_menuvertical.Location = new System.Drawing.Point(0, 0);
            this.pnl_menuvertical.Name = "pnl_menuvertical";
            this.pnl_menuvertical.Size = new System.Drawing.Size(190, 720);
            this.pnl_menuvertical.TabIndex = 0;
            this.pnl_menuvertical.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_menuvertical_Paint);
            // 
            // btnPortal
            // 
            this.btnPortal.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPortal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPortal.FlatAppearance.BorderSize = 0;
            this.btnPortal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnPortal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnPortal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPortal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPortal.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPortal.Image = ((System.Drawing.Image)(resources.GetObject("btnPortal.Image")));
            this.btnPortal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPortal.Location = new System.Drawing.Point(3, 183);
            this.btnPortal.Name = "btnPortal";
            this.btnPortal.Size = new System.Drawing.Size(189, 55);
            this.btnPortal.TabIndex = 15;
            this.btnPortal.Text = "Portal Empleado";
            this.btnPortal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPortal.UseVisualStyleBackColor = false;
            this.btnPortal.Click += new System.EventHandler(this.btnPortal_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, -11);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(190, 118);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.Crimson;
            this.btnLogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnLogOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.Honeydew;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.Location = new System.Drawing.Point(11, 644);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(164, 53);
            this.btnLogOut.TabIndex = 13;
            this.btnLogOut.Text = "Cerrar Sesión";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnCargos
            // 
            this.btnCargos.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCargos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargos.FlatAppearance.BorderSize = 0;
            this.btnCargos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnCargos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnCargos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargos.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargos.ForeColor = System.Drawing.Color.White;
            this.btnCargos.Image = ((System.Drawing.Image)(resources.GetObject("btnCargos.Image")));
            this.btnCargos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargos.Location = new System.Drawing.Point(-2, 433);
            this.btnCargos.Name = "btnCargos";
            this.btnCargos.Size = new System.Drawing.Size(192, 55);
            this.btnCargos.TabIndex = 12;
            this.btnCargos.Text = "  Gestión de Cargos";
            this.btnCargos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCargos.UseVisualStyleBackColor = false;
            this.btnCargos.Click += new System.EventHandler(this.btn_Consultas_Pedidos_Click);
            // 
            // btnAsistencia
            // 
            this.btnAsistencia.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAsistencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsistencia.FlatAppearance.BorderSize = 0;
            this.btnAsistencia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnAsistencia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAsistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsistencia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsistencia.ForeColor = System.Drawing.Color.White;
            this.btnAsistencia.Image = ((System.Drawing.Image)(resources.GetObject("btnAsistencia.Image")));
            this.btnAsistencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsistencia.Location = new System.Drawing.Point(1, 307);
            this.btnAsistencia.Name = "btnAsistencia";
            this.btnAsistencia.Size = new System.Drawing.Size(189, 54);
            this.btnAsistencia.TabIndex = 8;
            this.btnAsistencia.Text = "Asistencias";
            this.btnAsistencia.UseVisualStyleBackColor = false;
            this.btnAsistencia.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnGEmpleados
            // 
            this.btnGEmpleados.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGEmpleados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGEmpleados.FlatAppearance.BorderSize = 0;
            this.btnGEmpleados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnGEmpleados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnGEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGEmpleados.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGEmpleados.ForeColor = System.Drawing.Color.White;
            this.btnGEmpleados.Image = ((System.Drawing.Image)(resources.GetObject("btnGEmpleados.Image")));
            this.btnGEmpleados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGEmpleados.Location = new System.Drawing.Point(1, 368);
            this.btnGEmpleados.Name = "btnGEmpleados";
            this.btnGEmpleados.Size = new System.Drawing.Size(190, 58);
            this.btnGEmpleados.TabIndex = 5;
            this.btnGEmpleados.Text = "  Gestión Empleados";
            this.btnGEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGEmpleados.UseVisualStyleBackColor = false;
            this.btnGEmpleados.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnPermisos
            // 
            this.btnPermisos.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPermisos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPermisos.FlatAppearance.BorderSize = 0;
            this.btnPermisos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnPermisos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnPermisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPermisos.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPermisos.ForeColor = System.Drawing.Color.White;
            this.btnPermisos.Image = ((System.Drawing.Image)(resources.GetObject("btnPermisos.Image")));
            this.btnPermisos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPermisos.Location = new System.Drawing.Point(1, 245);
            this.btnPermisos.Name = "btnPermisos";
            this.btnPermisos.Size = new System.Drawing.Size(189, 55);
            this.btnPermisos.TabIndex = 6;
            this.btnPermisos.Text = "Permisos";
            this.btnPermisos.UseVisualStyleBackColor = false;
            this.btnPermisos.Click += new System.EventHandler(this.button8_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.RoyalBlue;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 812);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.icon_Restaurar);
            this.panel1.Controls.Add(this.icon_Max);
            this.panel1.Controls.Add(this.icon_Minimizar);
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(190, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1090, 106);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // icon_Restaurar
            // 
            this.icon_Restaurar.BackColor = System.Drawing.Color.Transparent;
            this.icon_Restaurar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.icon_Restaurar.Image = ((System.Drawing.Image)(resources.GetObject("icon_Restaurar.Image")));
            this.icon_Restaurar.Location = new System.Drawing.Point(993, 9);
            this.icon_Restaurar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.icon_Restaurar.Name = "icon_Restaurar";
            this.icon_Restaurar.Size = new System.Drawing.Size(39, 41);
            this.icon_Restaurar.TabIndex = 15;
            this.icon_Restaurar.UseVisualStyleBackColor = false;
            this.icon_Restaurar.Click += new System.EventHandler(this.icon_Restaurar_Click);
            // 
            // icon_Max
            // 
            this.icon_Max.BackColor = System.Drawing.Color.Transparent;
            this.icon_Max.Image = ((System.Drawing.Image)(resources.GetObject("icon_Max.Image")));
            this.icon_Max.Location = new System.Drawing.Point(1034, 9);
            this.icon_Max.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.icon_Max.Name = "icon_Max";
            this.icon_Max.Size = new System.Drawing.Size(45, 41);
            this.icon_Max.TabIndex = 14;
            this.icon_Max.UseVisualStyleBackColor = false;
            this.icon_Max.Click += new System.EventHandler(this.icon_Max_Click);
            // 
            // icon_Minimizar
            // 
            this.icon_Minimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.icon_Minimizar.Image = ((System.Drawing.Image)(resources.GetObject("icon_Minimizar.Image")));
            this.icon_Minimizar.Location = new System.Drawing.Point(949, 9);
            this.icon_Minimizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.icon_Minimizar.Name = "icon_Minimizar";
            this.icon_Minimizar.Size = new System.Drawing.Size(39, 41);
            this.icon_Minimizar.TabIndex = 13;
            this.icon_Minimizar.UseVisualStyleBackColor = true;
            this.icon_Minimizar.Click += new System.EventHandler(this.icon_Minimizar_Click_1);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(151, 65);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(16, 24);
            this.lblUser.TabIndex = 12;
            this.lblUser.Text = "-";
            this.lblUser.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(292, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(422, 37);
            this.label2.TabIndex = 11;
            this.label2.Text = "Sistema Recursos Humanos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Bienvenid@";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContenedor.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panelContenedor.Location = new System.Drawing.Point(190, 106);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1090, 613);
            this.panelContenedor.TabIndex = 2;
            this.panelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelcontenedor_Paint);
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 715);
            this.ControlBox = false;
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_menuvertical);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pnl_menuvertical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel pnl_menuvertical;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnAsistencia;
        private System.Windows.Forms.Button btnGEmpleados;
        private System.Windows.Forms.Button btnPermisos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Button btnCargos;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnPortal;
        private System.Windows.Forms.Button icon_Minimizar;
        private System.Windows.Forms.Button icon_Max;
        private System.Windows.Forms.Button icon_Restaurar;
    }
}