namespace CRG08.View
{
    partial class RelTratamento
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelTratamento));
            this.tratamento1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetGeral = new CRG08.DataSetGeral();
            this.empresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comentarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tratamento2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.tratamento1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetGeral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comentarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tratamento2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tratamento1BindingSource
            // 
            this.tratamento1BindingSource.DataMember = "Tratamento1";
            this.tratamento1BindingSource.DataSource = this.dataSetGeral;
            // 
            // dataSetGeral
            // 
            this.dataSetGeral.DataSetName = "DataSetGeral";
            this.dataSetGeral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // empresaBindingSource
            // 
            this.empresaBindingSource.DataMember = "Empresa";
            this.empresaBindingSource.DataSource = this.dataSetGeral;
            // 
            // comentarioBindingSource
            // 
            this.comentarioBindingSource.DataMember = "Comentario";
            this.comentarioBindingSource.DataSource = this.dataSetGeral;
            // 
            // tratamento2BindingSource
            // 
            this.tratamento2BindingSource.DataMember = "Tratamento2";
            this.tratamento2BindingSource.DataSource = this.dataSetGeral;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetTratamentoTab1";
            reportDataSource1.Value = this.tratamento1BindingSource;
            reportDataSource2.Name = "DataSetEmpresa";
            reportDataSource2.Value = this.empresaBindingSource;
            reportDataSource3.Name = "DataSetComentario";
            reportDataSource3.Value = this.comentarioBindingSource;
            reportDataSource4.Name = "DataSetTratamentoTab2";
            reportDataSource4.Value = this.tratamento2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CRG08.View.RelTratamento.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-1, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(848, 470);
            this.reportViewer1.TabIndex = 0;
            // 
            // RelTratamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(845, 468);
            this.Controls.Add(this.reportViewer1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RelTratamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório Tratamento";
            this.Load += new System.EventHandler(this.RelTratamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tratamento1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetGeral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comentarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tratamento2BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tratamento1BindingSource;
        private DataSetGeral dataSetGeral;
        private System.Windows.Forms.BindingSource empresaBindingSource;
        private System.Windows.Forms.BindingSource comentarioBindingSource;
        private System.Windows.Forms.BindingSource tratamento2BindingSource;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}