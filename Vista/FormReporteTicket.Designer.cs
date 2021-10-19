
namespace Mis_Recetas.Vista
{
    partial class FormReporteTicket
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
            this.dsTicketBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsTicket = new Mis_Recetas.Dataset.DsTicket();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.recetaTableAdapter = new Mis_Recetas.Dataset.DsTicketTableAdapters.RecetaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.recetaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTicketBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // recetaBindingSource
            // 
            this.recetaBindingSource.DataMember = "Receta";
            this.recetaBindingSource.DataSource = this.dsTicketBindingSource;
            // 
            // dsTicketBindingSource
            // 
            this.dsTicketBindingSource.DataSource = this.dsTicket;
            this.dsTicketBindingSource.Position = 0;
            // 
            // dsTicket
            // 
            this.dsTicket.DataSetName = "DsTicket";
            this.dsTicket.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.recetaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mis_Recetas.Reporte.ReporteTicket.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(334, 411);
            this.reportViewer1.TabIndex = 0;
            // 
            // recetaTableAdapter
            // 
            this.recetaTableAdapter.ClearBeforeFill = true;
            // 
            // FormReporteTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 411);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormReporteTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReporteTicket";
            this.Load += new System.EventHandler(this.FormReporteTicket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recetaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTicketBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTicket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Dataset.DsTicket dsTicket;
        private System.Windows.Forms.BindingSource dsTicketBindingSource;
        private System.Windows.Forms.BindingSource recetaBindingSource;
        private Dataset.DsTicketTableAdapters.RecetaTableAdapter recetaTableAdapter;
    }
}