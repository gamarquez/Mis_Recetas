
namespace Mis_Recetas.Vista
{
    partial class FormReporteRecArchivadas
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.recetaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsRecArchivadasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsRecArchivadas = new Mis_Recetas.Dataset.DsRecArchivadas();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.RecetaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recetaTableAdapter = new Mis_Recetas.Dataset.DsRecArchivadasTableAdapters.RecetaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.recetaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRecArchivadasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRecArchivadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecetaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // recetaBindingSource1
            // 
            this.recetaBindingSource1.DataMember = "Receta";
            this.recetaBindingSource1.DataSource = this.dsRecArchivadasBindingSource;
            // 
            // dsRecArchivadasBindingSource
            // 
            this.dsRecArchivadasBindingSource.DataSource = this.dsRecArchivadas;
            this.dsRecArchivadasBindingSource.Position = 0;
            // 
            // dsRecArchivadas
            // 
            this.dsRecArchivadas.DataSetName = "DsRecArchivadas";
            this.dsRecArchivadas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.recetaBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mis_Recetas.Reporte.ReporteRecArchivadas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(807, 286);
            this.reportViewer1.TabIndex = 0;
            // 
            // RecetaBindingSource
            // 
            this.RecetaBindingSource.DataMember = "Receta";
            this.RecetaBindingSource.DataSource = this.dsRecArchivadas;
            // 
            // recetaTableAdapter
            // 
            this.recetaTableAdapter.ClearBeforeFill = true;
            // 
            // FormReporteRecArchivadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 286);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormReporteRecArchivadas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReporteRecArchivadas";
            this.Load += new System.EventHandler(this.FormReporteRecArchivadas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recetaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRecArchivadasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRecArchivadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecetaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource RecetaBindingSource;
        private Dataset.DsRecArchivadas dsRecArchivadas;
        private System.Windows.Forms.BindingSource dsRecArchivadasBindingSource;
        private System.Windows.Forms.BindingSource recetaBindingSource1;
        private Dataset.DsRecArchivadasTableAdapters.RecetaTableAdapter recetaTableAdapter;
    }
}