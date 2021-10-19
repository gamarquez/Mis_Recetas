
namespace Mis_Recetas.Vista
{
    partial class FormAdminPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdminPanel));
            this.gpReportes = new System.Windows.Forms.GroupBox();
            this.btnModificarEstado = new System.Windows.Forms.Button();
            this.gpboxRecetas = new System.Windows.Forms.GroupBox();
            this.btnModificarReceta = new System.Windows.Forms.Button();
            this.gpboxPacientes = new System.Windows.Forms.GroupBox();
            this.btnModificarMedico = new System.Windows.Forms.Button();
            this.btnAltaMedico = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnModPaciente = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAltaUsuario = new System.Windows.Forms.Button();
            this.gpReportes.SuspendLayout();
            this.gpboxRecetas.SuspendLayout();
            this.gpboxPacientes.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpReportes
            // 
            this.gpReportes.Controls.Add(this.btnModificarEstado);
            this.gpReportes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpReportes.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.gpReportes.Location = new System.Drawing.Point(304, 267);
            this.gpReportes.Name = "gpReportes";
            this.gpReportes.Size = new System.Drawing.Size(257, 96);
            this.gpReportes.TabIndex = 5;
            this.gpReportes.TabStop = false;
            this.gpReportes.Text = "Reportes";
            // 
            // btnModificarEstado
            // 
            this.btnModificarEstado.Location = new System.Drawing.Point(7, 31);
            this.btnModificarEstado.Name = "btnModificarEstado";
            this.btnModificarEstado.Size = new System.Drawing.Size(244, 44);
            this.btnModificarEstado.TabIndex = 1;
            this.btnModificarEstado.Text = "Reportes";
            this.btnModificarEstado.UseVisualStyleBackColor = true;
            this.btnModificarEstado.Click += new System.EventHandler(this.btnModificarEstado_Click);
            // 
            // gpboxRecetas
            // 
            this.gpboxRecetas.Controls.Add(this.btnModificarReceta);
            this.gpboxRecetas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpboxRecetas.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.gpboxRecetas.Location = new System.Drawing.Point(304, 65);
            this.gpboxRecetas.Name = "gpboxRecetas";
            this.gpboxRecetas.Size = new System.Drawing.Size(257, 95);
            this.gpboxRecetas.TabIndex = 4;
            this.gpboxRecetas.TabStop = false;
            this.gpboxRecetas.Text = "Recetas";
            // 
            // btnModificarReceta
            // 
            this.btnModificarReceta.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnModificarReceta.Location = new System.Drawing.Point(7, 30);
            this.btnModificarReceta.Name = "btnModificarReceta";
            this.btnModificarReceta.Size = new System.Drawing.Size(244, 44);
            this.btnModificarReceta.TabIndex = 1;
            this.btnModificarReceta.Text = "Modificar Receta";
            this.btnModificarReceta.UseVisualStyleBackColor = true;
            this.btnModificarReceta.Click += new System.EventHandler(this.btnModificarReceta_Click);
            // 
            // gpboxPacientes
            // 
            this.gpboxPacientes.Controls.Add(this.btnModificarMedico);
            this.gpboxPacientes.Controls.Add(this.btnAltaMedico);
            this.gpboxPacientes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpboxPacientes.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.gpboxPacientes.Location = new System.Drawing.Point(12, 65);
            this.gpboxPacientes.Name = "gpboxPacientes";
            this.gpboxPacientes.Size = new System.Drawing.Size(257, 146);
            this.gpboxPacientes.TabIndex = 3;
            this.gpboxPacientes.TabStop = false;
            this.gpboxPacientes.Text = "Médicos";
            // 
            // btnModificarMedico
            // 
            this.btnModificarMedico.Location = new System.Drawing.Point(7, 80);
            this.btnModificarMedico.Name = "btnModificarMedico";
            this.btnModificarMedico.Size = new System.Drawing.Size(244, 44);
            this.btnModificarMedico.TabIndex = 1;
            this.btnModificarMedico.Text = "Modificar Médico";
            this.btnModificarMedico.UseVisualStyleBackColor = true;
            this.btnModificarMedico.Click += new System.EventHandler(this.btnModificarMedico_Click);
            // 
            // btnAltaMedico
            // 
            this.btnAltaMedico.Location = new System.Drawing.Point(7, 30);
            this.btnAltaMedico.Name = "btnAltaMedico";
            this.btnAltaMedico.Size = new System.Drawing.Size(244, 44);
            this.btnAltaMedico.TabIndex = 0;
            this.btnAltaMedico.Text = "Alta de Médico";
            this.btnAltaMedico.UseVisualStyleBackColor = true;
            this.btnAltaMedico.Click += new System.EventHandler(this.btnAltaMedico_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Panel Admin";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button1.Location = new System.Drawing.Point(160, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 44);
            this.button1.TabIndex = 7;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(110)))), ((int)(((byte)(150)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 42);
            this.panel1.TabIndex = 8;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnModPaciente);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox1.Location = new System.Drawing.Point(304, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 95);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pacientes";
            // 
            // btnModPaciente
            // 
            this.btnModPaciente.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnModPaciente.Location = new System.Drawing.Point(7, 30);
            this.btnModPaciente.Name = "btnModPaciente";
            this.btnModPaciente.Size = new System.Drawing.Size(244, 44);
            this.btnModPaciente.TabIndex = 1;
            this.btnModPaciente.Text = "Modificar Paciente";
            this.btnModPaciente.UseVisualStyleBackColor = true;
            this.btnModPaciente.Click += new System.EventHandler(this.btnModPaciente_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.btnAltaUsuario);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox2.Location = new System.Drawing.Point(12, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 138);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Usuarios";
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button2.Location = new System.Drawing.Point(7, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(244, 44);
            this.button2.TabIndex = 2;
            this.button2.Text = "Modificar Usuario";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAltaUsuario
            // 
            this.btnAltaUsuario.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnAltaUsuario.Location = new System.Drawing.Point(7, 30);
            this.btnAltaUsuario.Name = "btnAltaUsuario";
            this.btnAltaUsuario.Size = new System.Drawing.Size(244, 44);
            this.btnAltaUsuario.TabIndex = 1;
            this.btnAltaUsuario.Text = "Alta de Usuario";
            this.btnAltaUsuario.UseVisualStyleBackColor = true;
            this.btnAltaUsuario.Click += new System.EventHandler(this.btnAltaUsuario_Click);
            // 
            // FormAdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(573, 440);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gpReportes);
            this.Controls.Add(this.gpboxRecetas);
            this.Controls.Add(this.gpboxPacientes);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAdminPanel";
            this.gpReportes.ResumeLayout(false);
            this.gpboxRecetas.ResumeLayout(false);
            this.gpboxPacientes.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpReportes;
        private System.Windows.Forms.Button btnModificarEstado;
        private System.Windows.Forms.GroupBox gpboxRecetas;
        private System.Windows.Forms.Button btnModificarReceta;
        private System.Windows.Forms.GroupBox gpboxPacientes;
        private System.Windows.Forms.Button btnModificarMedico;
        private System.Windows.Forms.Button btnAltaMedico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnModPaciente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAltaUsuario;
        private System.Windows.Forms.Button button2;
    }
}