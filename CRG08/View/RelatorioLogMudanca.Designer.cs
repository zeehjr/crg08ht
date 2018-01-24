namespace CRG08.View
{
    partial class RelatorioLogMudanca
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelatorioLogMudanca));
            this.empresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetGeral = new CRG08.DataSetGeral();
            this.logMudancaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.empresaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetGeral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logMudancaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // empresaBindingSource
            // 
            this.empresaBindingSource.DataMember = "Empresa";
            this.empresaBindingSource.DataSource = this.dataSetGeral;
            // 
            // dataSetGeral
            // 
            this.dataSetGeral.DataSetName = "DataSetGeral";
            this.dataSetGeral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // logMudancaBindingSource
            // 
            this.logMudancaBindingSource.DataMember = "LogMudanca";
            this.logMudancaBindingSource.DataSource = this.dataSetGeral;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetEmpresa";
            reportDataSource1.Value = this.empresaBindingSource;
            reportDataSource2.Name = "DataSetLogMudanca";
            reportDataSource2.Value = this.logMudancaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CRG08.View.RelatorioLogMudanca.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(751, 421);
            this.reportViewer1.TabIndex = 0;
            // 
            // RelatorioLogMudanca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(749, 420);
            this.Controls.Add(this.reportViewer1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RelatorioLogMudanca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório Log Mudança";
            this.Load += new System.EventHandler(this.RelatorioLogMudanca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.empresaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetGeral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logMudancaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource empresaBindingSource;
        private DataSetGeral dataSetGeral;
        private System.Windows.Forms.BindingSource logMudancaBindingSource;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}