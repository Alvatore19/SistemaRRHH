namespace SistemaRRHH
{
    partial class FormDash
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDash));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnl_menuvertical = new System.Windows.Forms.Panel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnCargos = new System.Windows.Forms.Button();
            this.btnAsistencia = new System.Windows.Forms.Button();
            this.btnGEmpleados = new System.Windows.Forms.Button();
            this.btnPermisos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.icon_Minimizar = new System.Windows.Forms.PictureBox();
            this.icon_Cerrar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnPortal = new System.Windows.Forms.Button();
            this.pnl_menuvertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_Minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon_Cerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_menuvertical
            // 
            this.pnl_menuvertical.BackColor = System.Drawing.Color.White;
            this.pnl_menuvertical.Controls.Add(this.btnPortal);
            this.pnl_menuvertical.Controls.Add(this.pictureBox2);
            this.pnl_menuvertical.Controls.Add(this.btnLogOut);
            this.pnl_menuvertical.Controls.Add(this.btnCargos);
            this.pnl_menuvertical.Controls.Add(this.btnAsistencia);
            this.pnl_menuvertical.Controls.Add(this.btnGEmpleados);
            this.pnl_menuvertical.Controls.Add(this.btnPermisos);
            this.pnl_menuvertical.Controls.Add(this.pictureBox1);
            this.pnl_menuvertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_menuvertical.Location = new System.Drawing.Point(0, 0);
            this.pnl_menuvertical.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_menuvertical.Name = "pnl_menuvertical";
            this.pnl_menuvertical.Size = new System.Drawing.Size(253, 694);
            this.pnl_menuvertical.TabIndex = 0;
            this.pnl_menuvertical.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_menuvertical_Paint);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.Crimson;
            this.btnLogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.Honeydew;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.Location = new System.Drawing.Point(12, 577);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(218, 65);
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
            this.btnCargos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnCargos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCargos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargos.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargos.ForeColor = System.Drawing.Color.White;
            this.btnCargos.Image = ((System.Drawing.Image)(resources.GetObject("btnCargos.Image")));
            this.btnCargos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargos.Location = new System.Drawing.Point(-2, 438);
            this.btnCargos.Margin = new System.Windows.Forms.Padding(4);
            this.btnCargos.Name = "btnCargos";
            this.btnCargos.Size = new System.Drawing.Size(256, 68);
            this.btnCargos.TabIndex = 12;
            this.btnCargos.Text = "  Gestión de Cargos";
            this.btnCargos.UseVisualStyleBackColor = false;
            this.btnCargos.Click += new System.EventHandler(this.btn_Consultas_Pedidos_Click);
            // 
            // btnAsistencia
            // 
            this.btnAsistencia.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAsistencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsistencia.FlatAppearance.BorderSize = 0;
            this.btnAsistencia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnAsistencia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAsistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsistencia.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsistencia.ForeColor = System.Drawing.Color.White;
            this.btnAsistencia.Image = ((System.Drawing.Image)(resources.GetObject("btnAsistencia.Image")));
            this.btnAsistencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsistencia.Location = new System.Drawing.Point(1, 283);
            this.btnAsistencia.Margin = new System.Windows.Forms.Padding(4);
            this.btnAsistencia.Name = "btnAsistencia";
            this.btnAsistencia.Size = new System.Drawing.Size(252, 67);
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
            this.btnGEmpleados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnGEmpleados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGEmpleados.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGEmpleados.ForeColor = System.Drawing.Color.White;
            this.btnGEmpleados.Image = ((System.Drawing.Image)(resources.GetObject("btnGEmpleados.Image")));
            this.btnGEmpleados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGEmpleados.Location = new System.Drawing.Point(1, 358);
            this.btnGEmpleados.Margin = new System.Windows.Forms.Padding(4);
            this.btnGEmpleados.Name = "btnGEmpleados";
            this.btnGEmpleados.Size = new System.Drawing.Size(253, 72);
            this.btnGEmpleados.TabIndex = 5;
            this.btnGEmpleados.Text = "  Gestión Empleados";
            this.btnGEmpleados.UseVisualStyleBackColor = false;
            this.btnGEmpleados.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnPermisos
            // 
            this.btnPermisos.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPermisos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPermisos.FlatAppearance.BorderSize = 0;
            this.btnPermisos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnPermisos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPermisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPermisos.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPermisos.ForeColor = System.Drawing.Color.White;
            this.btnPermisos.Image = ((System.Drawing.Image)(resources.GetObject("btnPermisos.Image")));
            this.btnPermisos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPermisos.Location = new System.Drawing.Point(1, 207);
            this.btnPermisos.Margin = new System.Windows.Forms.Padding(4);
            this.btnPermisos.Name = "btnPermisos";
            this.btnPermisos.Size = new System.Drawing.Size(252, 68);
            this.btnPermisos.TabIndex = 6;
            this.btnPermisos.Text = "Permisos";
            this.btnPermisos.UseVisualStyleBackColor = false;
            this.btnPermisos.Click += new System.EventHandler(this.button8_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.RoyalBlue;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 132);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(253, 559);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.icon_Minimizar);
            this.panel1.Controls.Add(this.icon_Cerrar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(253, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(863, 131);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(430, 69);
            this.lblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(23, 29);
            this.lblUser.TabIndex = 12;
            this.lblUser.Text = "-";
            this.lblUser.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(180, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(506, 43);
            this.label2.TabIndex = 11;
            this.label2.Text = "Sistema Recursos Humanos";
            // 
            // icon_Minimizar
            // 
            this.icon_Minimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.icon_Minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.icon_Minimizar.Image = ((System.Drawing.Image)(resources.GetObject("icon_Minimizar.Image")));
            this.icon_Minimizar.Location = new System.Drawing.Point(773, 15);
            this.icon_Minimizar.Margin = new System.Windows.Forms.Padding(4);
            this.icon_Minimizar.Name = "icon_Minimizar";
            this.icon_Minimizar.Size = new System.Drawing.Size(39, 32);
            this.icon_Minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon_Minimizar.TabIndex = 7;
            this.icon_Minimizar.TabStop = false;
            this.icon_Minimizar.Click += new System.EventHandler(this.icon_Minimizar_Click);
            // 
            // icon_Cerrar
            // 
            this.icon_Cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.icon_Cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.icon_Cerrar.Image = ((System.Drawing.Image)(resources.GetObject("icon_Cerrar.Image")));
            this.icon_Cerrar.Location = new System.Drawing.Point(820, 15);
            this.icon_Cerrar.Margin = new System.Windows.Forms.Padding(4);
            this.icon_Cerrar.Name = "icon_Cerrar";
            this.icon_Cerrar.Size = new System.Drawing.Size(39, 32);
            this.icon_Cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon_Cerrar.TabIndex = 5;
            this.icon_Cerrar.TabStop = false;
            this.icon_Cerrar.Click += new System.EventHandler(this.icon_Cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(275, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "Bienvenido";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(253, 131);
            this.panelContenedor.Margin = new System.Windows.Forms.Padding(4);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(863, 563);
            this.panelContenedor.TabIndex = 2;
            this.panelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelcontenedor_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, -14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(253, 145);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // btnPortal
            // 
            this.btnPortal.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPortal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPortal.FlatAppearance.BorderSize = 0;
            this.btnPortal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnPortal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPortal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPortal.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPortal.ForeColor = System.Drawing.Color.White;
            this.btnPortal.Image = ((System.Drawing.Image)(resources.GetObject("btnPortal.Image")));
            this.btnPortal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPortal.Location = new System.Drawing.Point(4, 131);
            this.btnPortal.Margin = new System.Windows.Forms.Padding(4);
            this.btnPortal.Name = "btnPortal";
            this.btnPortal.Size = new System.Drawing.Size(252, 68);
            this.btnPortal.TabIndex = 15;
            this.btnPortal.Text = "Portal Empleado";
            this.btnPortal.UseVisualStyleBackColor = false;
            this.btnPortal.Click += new System.EventHandler(this.btnPortal_Click);
            // 
            // FormDash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 694);
            this.ControlBox = false;
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_menuvertical);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormDash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pnl_menuvertical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_Minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon_Cerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel pnl_menuvertical;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox icon_Minimizar;
        private System.Windows.Forms.PictureBox icon_Cerrar;
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
    }
}

