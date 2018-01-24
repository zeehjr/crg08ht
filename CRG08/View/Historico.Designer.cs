namespace CRG08.View
{
    partial class Historico
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Historico));
            this.cmbCRG = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgHistorico = new System.Windows.Forms.DataGridView();
            this.NTrat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receber = new System.Windows.Forms.Button();
            this.inserir = new System.Windows.Forms.Button();
            this.Fechar = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistorico)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCRG
            // 
            this.cmbCRG.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbCRG.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCRG.FormattingEnabled = true;
            this.cmbCRG.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.cmbCRG.Location = new System.Drawing.Point(57, 6);
            this.cmbCRG.Name = "cmbCRG";
            this.cmbCRG.Size = new System.Drawing.Size(60, 23);
            this.cmbCRG.TabIndex = 1;
            this.cmbCRG.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "CRG Nº: ";
            // 
            // dtgHistorico
            // 
            this.dtgHistorico.AllowUserToAddRows = false;
            this.dtgHistorico.AllowUserToDeleteRows = false;
            this.dtgHistorico.BackgroundColor = System.Drawing.Color.White;
            this.dtgHistorico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHistorico.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHistorico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NTrat,
            this.NL,
            this.Descricao});
            this.dtgHistorico.Location = new System.Drawing.Point(12, 34);
            this.dtgHistorico.Name = "dtgHistorico";
            this.dtgHistorico.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHistorico.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgHistorico.RowHeadersVisible = false;
            this.dtgHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgHistorico.Size = new System.Drawing.Size(282, 252);
            this.dtgHistorico.TabIndex = 5;
            this.dtgHistorico.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgHistorico_CellClick);
            // 
            // NTrat
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NTrat.DefaultCellStyle = dataGridViewCellStyle2;
            this.NTrat.HeaderText = "NTrat";
            this.NTrat.Name = "NTrat";
            this.NTrat.ReadOnly = true;
            this.NTrat.Width = 40;
            // 
            // NL
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NL.DefaultCellStyle = dataGridViewCellStyle3;
            this.NL.HeaderText = "NL";
            this.NL.Name = "NL";
            this.NL.ReadOnly = true;
            this.NL.Width = 30;
            // 
            // Descricao
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descricao.DefaultCellStyle = dataGridViewCellStyle4;
            this.Descricao.HeaderText = "Inicio do Ciclo";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 200;
            // 
            // Receber
            // 
            this.Receber.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Receber.Location = new System.Drawing.Point(57, 292);
            this.Receber.Name = "Receber";
            this.Receber.Size = new System.Drawing.Size(75, 39);
            this.Receber.TabIndex = 2;
            this.Receber.Text = "Receber Histórico";
            this.Receber.UseVisualStyleBackColor = true;
            this.Receber.Click += new System.EventHandler(this.Receber_Click);
            // 
            // inserir
            // 
            this.inserir.Enabled = false;
            this.inserir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.inserir.Location = new System.Drawing.Point(138, 292);
            this.inserir.Name = "inserir";
            this.inserir.Size = new System.Drawing.Size(75, 39);
            this.inserir.TabIndex = 3;
            this.inserir.Text = "Salvar  Ciclo";
            this.inserir.UseVisualStyleBackColor = true;
            this.inserir.Click += new System.EventHandler(this.inserir_Click);
            // 
            // Fechar
            // 
            this.Fechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Fechar.Location = new System.Drawing.Point(219, 292);
            this.Fechar.Name = "Fechar";
            this.Fechar.Size = new System.Drawing.Size(75, 39);
            this.Fechar.TabIndex = 4;
            this.Fechar.Text = "Fechar";
            this.Fechar.UseVisualStyleBackColor = true;
            this.Fechar.Click += new System.EventHandler(this.Fechar_Click);
            // 
            // Historico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(308, 343);
            this.Controls.Add(this.Fechar);
            this.Controls.Add(this.inserir);
            this.Controls.Add(this.Receber);
            this.Controls.Add(this.dtgHistorico);
            this.Controls.Add(this.cmbCRG);
            this.Controls.Add(this.label1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Historico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Histórico de Secagens";
            this.Load += new System.EventHandler(this.frmHistorico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistorico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCRG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgHistorico;
        private System.Windows.Forms.Button Receber;
        private System.Windows.Forms.Button inserir;
        private System.Windows.Forms.Button Fechar;
        private System.Windows.Forms.DataGridViewTextBoxColumn NTrat;
        private System.Windows.Forms.DataGridViewTextBoxColumn NL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}