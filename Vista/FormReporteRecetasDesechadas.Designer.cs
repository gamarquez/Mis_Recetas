
namespace Mis_Recetas.Vista
{
    partial class FormReporteRecetasDesechadas
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
            this.dsRecetasDesechadas = new Mis_Recetas.Dataset.DsRecetasDesechadas();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.recetaTableAdapter = new Mis_Recetas.Dataset.DsRecetasDesechadasTableAdapters.RecetaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.recetaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRecetasDesechadas)).BeginInit();
            this.SuspendLayout();
            // 
            // recetaBindingSource
            // 
            this.recetaBindingSource.DataMember = "Receta";
            this.recetaBindingSource.DataSource = this.dsRecetasDesechadas;
            // 
            // dsRecetasDesechadas
            // 
            this.dsRecetasDesechadas.DataSetName = "DsRecetasDesechadas";
            this.dsRecetasDesechadas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.recetaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mis_Recetas.Reporte.ReporteRecetasDesechadas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(918, 249);
            this.reportViewer1.TabIndex = 0;
            // 
            // recetaTableAdapter
            // 
            this.recetaTableAdapter.ClearBeforeFill = true;
            // 
            // FormReporteRecetasDesechadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 249);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormReporteRecetasDesechadas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReporteRecetasDesechadas";
            this.Load += new System.EventHandler(this.FormReporteRecetasDesechadas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recetaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRecetasDesechadas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Dataset.DsRecetasDesechadas dsRecetasDesechadas;
        private System.Windows.Forms.BindingSource recetaBindingSource;
        private Dataset.DsRecetasDesechadasTableAdapters.RecetaTableAdapter recetaTableAdapter;
    }
}