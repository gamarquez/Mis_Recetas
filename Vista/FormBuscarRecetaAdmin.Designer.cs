
namespace Mis_Recetas.Vista
{
    partial class FormBuscarRecetaAdmin
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNumeroReceta = new System.Windows.Forms.TextBox();
            this.lblNroReceta = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gpResultados = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvRecetas = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecetas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(110)))), ((int)(((byte)(150)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(-6, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(943, 40);
            this.panel2.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Buscar Receta";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumeroReceta);
            this.groupBox1.Controls.Add(this.lblNroReceta);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox1.Location = new System.Drawing.Point(7, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(930, 52);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // txtNumeroReceta
            // 
            this.txtNumeroReceta.Location = new System.Drawing.Point(90, 18);
            this.txtNumeroReceta.Name = "txtNumeroReceta";
            this.txtNumeroReceta.Size = new System.Drawing.Size(144, 23);
            this.txtNumeroReceta.TabIndex = 2;
            // 
            // lblNroReceta
            // 
            this.lblNroReceta.AutoSize = true;
            this.lblNroReceta.Location = new System.Drawing.Point(7, 23);
            this.lblNroReceta.Name = "lblNroReceta";
            this.lblNroReceta.Size = new System.Drawing.Size(75, 16);
            this.lblNroReceta.TabIndex = 1;
            this.lblNroReceta.Text = "N° Receta:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(268, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gpResultados
            // 
            this.gpResultados.Controls.Add(this.dgvRecetas);
            this.gpResultados.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.gpResultados.Location = new System.Drawing.Point(7, 105);
            this.gpResultados.Name = "gpResultados";
            this.gpResultados.Size = new System.Drawing.Size(930, 156);
            this.gpResultados.TabIndex = 36;
            this.gpResultados.TabStop = false;
            this.gpResultados.Text = "Resultados";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnCerrar.Location = new System.Drawing.Point(862, 292);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 37;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvRecetas
            // 
            this.dgvRecetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecetas.Location = new System.Drawing.Point(3, 19);
            this.dgvRecetas.Name = "dgvRecetas";
            this.dgvRecetas.RowHeadersVisible = false;
            this.dgvRecetas.Size = new System.Drawing.Size(924, 134);
            this.dgvRecetas.TabIndex = 0;
            // 
            // FormBuscarRecetaAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(949, 327);
            this.ControlBox = false;
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.gpResultados);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Name = "FormBuscarRecetaAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecetas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNumeroReceta;
        private System.Windows.Forms.Label lblNroReceta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox gpResultados;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvRecetas;
    }
}