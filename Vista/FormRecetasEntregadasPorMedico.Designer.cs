
namespace Mis_Recetas.Vista
{
    partial class FormRecetasEntregadasPorMedico
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.recetaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsRecetasEntregadasPorMedicoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsRecetasEntregadasPorMedico = new Mis_Recetas.Dataset.DsRecetasEntregadasPorMedico();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMedico = new System.Windows.Forms.ComboBox();
            this.recetaTableAdapter = new Mis_Recetas.Dataset.DsRecetasEntregadasPorMedicoTableAdapters.RecetaTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.recetaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRecetasEntregadasPorMedicoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRecetasEntregadasPorMedico)).BeginInit();
            this.SuspendLayout();
            // 
            // recetaBindingSource
            // 
            this.recetaBindingSource.DataMember = "Receta";
            this.recetaBindingSource.DataSource = this.dsRecetasEntregadasPorMedicoBindingSource;
            // 
            // dsRecetasEntregadasPorMedicoBindingSource
            // 
            this.dsRecetasEntregadasPorMedicoBindingSource.DataSource = this.dsRecetasEntregadasPorMedico;
            this.dsRecetasEntregadasPorMedicoBindingSource.Position = 0;
            // 
            // dsRecetasEntregadasPorMedico
            // 
            this.dsRecetasEntregadasPorMedico.DataSetName = "DsRecetasEntregadasPorMedico";
            this.dsRecetasEntregadasPorMedico.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(235)))), ((int)(((byte)(213)))));
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(771, 38);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.recetaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mis_Recetas.Reporte.ReporteRecetasEntregadasPorMedico.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 38);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(771, 234);
            this.reportViewer1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(235)))), ((int)(((byte)(213)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione médico";
            // 
            // cboMedico
            // 
            this.cboMedico.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMedico.FormattingEnabled = true;
            this.cboMedico.Location = new System.Drawing.Point(142, 7);
            this.cboMedico.Name = "cboMedico";
            this.cboMedico.Size = new System.Drawing.Size(121, 25);
            this.cboMedico.TabIndex = 3;
            // 
            // recetaTableAdapter
            // 
            this.recetaTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(291, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "Generar reporte";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormRecetasEntregadasPorMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 272);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboMedico);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormRecetasEntregadasPorMedico";
            this.Text = "FormRecetasEntregadasPorMedico";
            this.Load += new System.EventHandler(this.FormRecetasEntregadasPorMedico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recetaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRecetasEntregadasPorMedicoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRecetasEntregadasPorMedico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMedico;
        private System.Windows.Forms.BindingSource recetaBindingSource;
        private System.Windows.Forms.BindingSource dsRecetasEntregadasPorMedicoBindingSource;
        private Dataset.DsRecetasEntregadasPorMedico dsRecetasEntregadasPorMedico;
        private Dataset.DsRecetasEntregadasPorMedicoTableAdapters.RecetaTableAdapter recetaTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}