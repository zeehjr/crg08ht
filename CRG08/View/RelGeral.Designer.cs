namespace CRG08
{
    partial class RelGeral
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelGeral));
            this.EmpresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetGeral = new CRG08.DataSetGeral();
            this.Ciclo1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Ciclo2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Tratamento1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Tratamento2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ComentarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.EmpresaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetGeral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ciclo1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ciclo2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tratamento1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tratamento2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComentarioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // EmpresaBindingSource
            // 
            this.EmpresaBindingSource.DataMember = "Empresa";
            this.EmpresaBindingSource.DataSource = this.DataSetGeral;
            // 
            // DataSetGeral
            // 
            this.DataSetGeral.DataSetName = "DataSetGeral";
            this.DataSetGeral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Ciclo1BindingSource
            // 
            this.Ciclo1BindingSource.DataMember = "Ciclo1";
            this.Ciclo1BindingSource.DataSource = this.DataSetGeral;
            // 
            // Ciclo2BindingSource
            // 
            this.Ciclo2BindingSource.DataMember = "Ciclo2";
            this.Ciclo2BindingSource.DataSource = this.DataSetGeral;
            // 
            // Tratamento1BindingSource
            // 
            this.Tratamento1BindingSource.DataMember = "Tratamento1";
            this.Tratamento1BindingSource.DataSource = this.DataSetGeral;
            // 
            // Tratamento2BindingSource
            // 
            this.Tratamento2BindingSource.DataMember = "Tratamento2";
            this.Tratamento2BindingSource.DataSource = this.DataSetGeral;
            // 
            // ComentarioBindingSource
            // 
            this.ComentarioBindingSource.DataMember = "Comentario";
            this.ComentarioBindingSource.DataSource = this.DataSetGeral;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetEmpresa";
            reportDataSource1.Value = this.EmpresaBindingSource;
            reportDataSource2.Name = "DataSetCiclo1";
            reportDataSource2.Value = this.Ciclo1BindingSource;
            reportDataSource3.Name = "DataSetCiclo2";
            reportDataSource3.Value = this.Ciclo2BindingSource;
            reportDataSource4.Name = "DataSetTratamento1";
            reportDataSource4.Value = this.Tratamento1BindingSource;
            reportDataSource5.Name = "DataSetTratamento2";
            reportDataSource5.Value = this.Tratamento2BindingSource;
            reportDataSource6.Name = "DataSetComentario";
            reportDataSource6.Value = this.ComentarioBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CRG08.View.RelGeral.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-1, -1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(947, 462);
            this.reportViewer1.TabIndex = 0;
            // 
            // RelGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(946, 460);
            this.Controls.Add(this.reportViewer1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RelGeral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório Geral";
            this.Load += new System.EventHandler(this.RelGeral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EmpresaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetGeral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ciclo1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ciclo2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tratamento1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tratamento2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComentarioBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource EmpresaBindingSource;
        private DataSetGeral DataSetGeral;
        private System.Windows.Forms.BindingSource Ciclo1BindingSource;
        private System.Windows.Forms.BindingSource Ciclo2BindingSource;
        private System.Windows.Forms.BindingSource Tratamento1BindingSource;
        private System.Windows.Forms.BindingSource Tratamento2BindingSource;
        private System.Windows.Forms.BindingSource ComentarioBindingSource;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}