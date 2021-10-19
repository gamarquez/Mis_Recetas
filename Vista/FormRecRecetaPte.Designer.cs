
namespace Mis_Recetas.Vista
{
    partial class FormRecRecetaPte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecRecetaPte));
            this.seccionNuevoPaciente = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.btnCargarPaciente = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTipoDocumento2 = new System.Windows.Forms.ComboBox();
            this.txtNroDocumento2 = new System.Windows.Forms.TextBox();
            this.seccionRegistrar = new System.Windows.Forms.GroupBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblNroDoc = new System.Windows.Forms.Label();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.lblApe = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cboMedico = new System.Windows.Forms.ComboBox();
            this.lblMedico = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.seccionBuscarPaciente = new System.Windows.Forms.GroupBox();
            this.dgvPacientes = new System.Windows.Forms.DataGridView();
            this.btnNuevoPaciente = new System.Windows.Forms.Button();
            this.btnBuscarPaciente = new System.Windows.Forms.Button();
            this.txtNroDocumento = new System.Windows.Forms.TextBox();
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.seccionNuevoPaciente.SuspendLayout();
            this.seccionRegistrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.seccionBuscarPaciente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            this.SuspendLayout();
            // 
            // seccionNuevoPaciente
            // 
            this.seccionNuevoPaciente.Controls.Add(this.txtEmail);
            this.seccionNuevoPaciente.Controls.Add(this.label8);
            this.seccionNuevoPaciente.Controls.Add(this.txtApellido);
            this.seccionNuevoPaciente.Controls.Add(this.btnCargarPaciente);
            this.seccionNuevoPaciente.Controls.Add(this.txtNombre);
            this.seccionNuevoPaciente.Controls.Add(this.label3);
            this.seccionNuevoPaciente.Controls.Add(this.label6);
            this.seccionNuevoPaciente.Controls.Add(this.label4);
            this.seccionNuevoPaciente.Controls.Add(this.label5);
            this.seccionNuevoPaciente.Controls.Add(this.cboTipoDocumento2);
            this.seccionNuevoPaciente.Controls.Add(this.txtNroDocumento2);
            this.seccionNuevoPaciente.Location = new System.Drawing.Point(499, 238);
            this.seccionNuevoPaciente.Name = "seccionNuevoPaciente";
            this.seccionNuevoPaciente.Size = new System.Drawing.Size(337, 229);
            this.seccionNuevoPaciente.TabIndex = 8;
            this.seccionNuevoPaciente.TabStop = false;
            this.seccionNuevoPaciente.Text = "Nuevo Paciente";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(142, 150);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(121, 20);
            this.txtEmail.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(94, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "E-mail";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(142, 54);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(121, 20);
            this.txtApellido.TabIndex = 16;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // btnCargarPaciente
            // 
            this.btnCargarPaciente.Location = new System.Drawing.Point(142, 190);
            this.btnCargarPaciente.Name = "btnCargarPaciente";
            this.btnCargarPaciente.Size = new System.Drawing.Size(123, 30);
            this.btnCargarPaciente.TabIndex = 28;
            this.btnCargarPaciente.Text = "Cargar";
            this.btnCargarPaciente.UseVisualStyleBackColor = true;
            this.btnCargarPaciente.Click += new System.EventHandler(this.btnCargarPaciente_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(142, 23);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(122, 20);
            this.txtNombre.TabIndex = 15;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Apellido";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Tipo Documento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Nro. Documento";
            // 
            // cboTipoDocumento2
            // 
            this.cboTipoDocumento2.FormattingEnabled = true;
            this.cboTipoDocumento2.Location = new System.Drawing.Point(142, 87);
            this.cboTipoDocumento2.Name = "cboTipoDocumento2";
            this.cboTipoDocumento2.Size = new System.Drawing.Size(121, 21);
            this.cboTipoDocumento2.TabIndex = 8;
            // 
            // txtNroDocumento2
            // 
            this.txtNroDocumento2.Location = new System.Drawing.Point(142, 119);
            this.txtNroDocumento2.Name = "txtNroDocumento2";
            this.txtNroDocumento2.Size = new System.Drawing.Size(121, 20);
            this.txtNroDocumento2.TabIndex = 9;
            this.txtNroDocumento2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroDocumento2_KeyPress);
            // 
            // seccionRegistrar
            // 
            this.seccionRegistrar.Controls.Add(this.lblEmail);
            this.seccionRegistrar.Controls.Add(this.label9);
            this.seccionRegistrar.Controls.Add(this.lblNroDoc);
            this.seccionRegistrar.Controls.Add(this.lblTipoDoc);
            this.seccionRegistrar.Controls.Add(this.lblApe);
            this.seccionRegistrar.Controls.Add(this.lblNom);
            this.seccionRegistrar.Controls.Add(this.pictureBox1);
            this.seccionRegistrar.Controls.Add(this.label7);
            this.seccionRegistrar.Controls.Add(this.lblApellido);
            this.seccionRegistrar.Controls.Add(this.lblNombre);
            this.seccionRegistrar.Controls.Add(this.cboMedico);
            this.seccionRegistrar.Controls.Add(this.lblMedico);
            this.seccionRegistrar.Controls.Add(this.btnRegistrar);
            this.seccionRegistrar.Controls.Add(this.label1);
            this.seccionRegistrar.Controls.Add(this.label2);
            this.seccionRegistrar.Location = new System.Drawing.Point(12, 238);
            this.seccionRegistrar.Name = "seccionRegistrar";
            this.seccionRegistrar.Size = new System.Drawing.Size(417, 229);
            this.seccionRegistrar.TabIndex = 7;
            this.seccionRegistrar.TabStop = false;
            this.seccionRegistrar.Text = "Registrar Receta";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(180, 121);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(12, 15);
            this.lblEmail.TabIndex = 22;
            this.lblEmail.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(141, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "E-mail:";
            // 
            // lblNroDoc
            // 
            this.lblNroDoc.AutoSize = true;
            this.lblNroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroDoc.Location = new System.Drawing.Point(232, 101);
            this.lblNroDoc.Name = "lblNroDoc";
            this.lblNroDoc.Size = new System.Drawing.Size(12, 15);
            this.lblNroDoc.TabIndex = 20;
            this.lblNroDoc.Text = "-";
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDoc.Location = new System.Drawing.Point(232, 81);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(12, 15);
            this.lblTipoDoc.TabIndex = 19;
            this.lblTipoDoc.Text = "-";
            // 
            // lblApe
            // 
            this.lblApe.AutoSize = true;
            this.lblApe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApe.Location = new System.Drawing.Point(190, 60);
            this.lblApe.Name = "lblApe";
            this.lblApe.Size = new System.Drawing.Size(12, 15);
            this.lblApe.TabIndex = 18;
            this.lblApe.Text = "-";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.Location = new System.Drawing.Point(190, 38);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(12, 15);
            this.lblNom.TabIndex = 17;
            this.lblNom.Text = "-";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(185, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "PACIENTE";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(141, 62);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 14;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(141, 40);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 13;
            this.lblNombre.Text = "Nombre:";
            // 
            // cboMedico
            // 
            this.cboMedico.FormattingEnabled = true;
            this.cboMedico.Location = new System.Drawing.Point(156, 154);
            this.cboMedico.Name = "cboMedico";
            this.cboMedico.Size = new System.Drawing.Size(123, 21);
            this.cboMedico.TabIndex = 12;
            // 
            // lblMedico
            // 
            this.lblMedico.AutoSize = true;
            this.lblMedico.Location = new System.Drawing.Point(34, 157);
            this.lblMedico.Name = "lblMedico";
            this.lblMedico.Size = new System.Drawing.Size(104, 13);
            this.lblMedico.TabIndex = 11;
            this.lblMedico.Text = "Receta para Medico";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(156, 190);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(122, 30);
            this.btnRegistrar.TabIndex = 10;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nro. Documento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tipo Documento:";
            // 
            // seccionBuscarPaciente
            // 
            this.seccionBuscarPaciente.Controls.Add(this.dgvPacientes);
            this.seccionBuscarPaciente.Controls.Add(this.btnNuevoPaciente);
            this.seccionBuscarPaciente.Controls.Add(this.btnBuscarPaciente);
            this.seccionBuscarPaciente.Controls.Add(this.txtNroDocumento);
            this.seccionBuscarPaciente.Controls.Add(this.cboTipoDocumento);
            this.seccionBuscarPaciente.Controls.Add(this.lblDocumento);
            this.seccionBuscarPaciente.Controls.Add(this.lblTipoDocumento);
            this.seccionBuscarPaciente.Location = new System.Drawing.Point(12, 51);
            this.seccionBuscarPaciente.Name = "seccionBuscarPaciente";
            this.seccionBuscarPaciente.Size = new System.Drawing.Size(824, 171);
            this.seccionBuscarPaciente.TabIndex = 6;
            this.seccionBuscarPaciente.TabStop = false;
            this.seccionBuscarPaciente.Text = "Buscar Paciente";
            // 
            // dgvPacientes
            // 
            this.dgvPacientes.AllowUserToAddRows = false;
            this.dgvPacientes.AllowUserToDeleteRows = false;
            this.dgvPacientes.AllowUserToResizeColumns = false;
            this.dgvPacientes.AllowUserToResizeRows = false;
            this.dgvPacientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPacientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPacientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.dgvPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacientes.Location = new System.Drawing.Point(223, 10);
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPacientes.Size = new System.Drawing.Size(595, 155);
            this.dgvPacientes.TabIndex = 5;
            this.dgvPacientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellClick);
            this.dgvPacientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellContentClick);
            // 
            // btnNuevoPaciente
            // 
            this.btnNuevoPaciente.Location = new System.Drawing.Point(96, 122);
            this.btnNuevoPaciente.Name = "btnNuevoPaciente";
            this.btnNuevoPaciente.Size = new System.Drawing.Size(121, 27);
            this.btnNuevoPaciente.TabIndex = 29;
            this.btnNuevoPaciente.Text = "Paciente Nuevo";
            this.btnNuevoPaciente.UseVisualStyleBackColor = true;
            this.btnNuevoPaciente.Click += new System.EventHandler(this.btnNuevoPaciente_Click);
            // 
            // btnBuscarPaciente
            // 
            this.btnBuscarPaciente.Location = new System.Drawing.Point(96, 90);
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.Size = new System.Drawing.Size(121, 26);
            this.btnBuscarPaciente.TabIndex = 4;
            this.btnBuscarPaciente.Text = "Buscar";
            this.btnBuscarPaciente.UseVisualStyleBackColor = true;
            this.btnBuscarPaciente.Click += new System.EventHandler(this.btnBuscarPaciente_Click);
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.Location = new System.Drawing.Point(96, 64);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Size = new System.Drawing.Size(121, 20);
            this.txtNroDocumento.TabIndex = 3;
            this.txtNroDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroDocumento_KeyPress);
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(96, 35);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(121, 21);
            this.cboTipoDocumento.TabIndex = 2;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(5, 67);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(85, 13);
            this.lblDocumento.TabIndex = 1;
            this.lblDocumento.Text = "Nro. Documento";
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Location = new System.Drawing.Point(4, 38);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(86, 13);
            this.lblTipoDocumento.TabIndex = 0;
            this.lblTipoDocumento.Text = "Tipo Documento";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(347, 482);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(154, 30);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(273, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(228, 19);
            this.label10.TabIndex = 24;
            this.label10.Text = "Registrar Pedidos De Recetas";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormRecRecetaPte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(848, 524);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.seccionNuevoPaciente);
            this.Controls.Add(this.seccionRegistrar);
            this.Controls.Add(this.seccionBuscarPaciente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRecRecetaPte";
            this.Text = "FormRecRecetaPte";
            this.Load += new System.EventHandler(this.FormRecRecetaPte_Load);
            this.seccionNuevoPaciente.ResumeLayout(false);
            this.seccionNuevoPaciente.PerformLayout();
            this.seccionRegistrar.ResumeLayout(false);
            this.seccionRegistrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.seccionBuscarPaciente.ResumeLayout(false);
            this.seccionBuscarPaciente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox seccionNuevoPaciente;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Button btnCargarPaciente;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTipoDocumento2;
        private System.Windows.Forms.TextBox txtNroDocumento2;
        private System.Windows.Forms.GroupBox seccionRegistrar;
        private System.Windows.Forms.Label lblNroDoc;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.Label lblApe;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox cboMedico;
        private System.Windows.Forms.Label lblMedico;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox seccionBuscarPaciente;
        private System.Windows.Forms.DataGridView dgvPacientes;
        private System.Windows.Forms.Button btnNuevoPaciente;
        private System.Windows.Forms.Button btnBuscarPaciente;
        private System.Windows.Forms.TextBox txtNroDocumento;
        private System.Windows.Forms.ComboBox cboTipoDocumento;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label10;
    }
}