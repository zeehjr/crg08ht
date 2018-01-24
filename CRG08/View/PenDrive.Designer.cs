namespace CRG08.View
{
    partial class frmPenDrive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPenDrive));
            this.dtgTratamentos = new System.Windows.Forms.DataGridView();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ok = new System.Windows.Forms.Button();
            this.cmbUnidades = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTratamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgTratamentos
            // 
            this.dtgTratamentos.AllowUserToAddRows = false;
            this.dtgTratamentos.AllowUserToDeleteRows = false;
            this.dtgTratamentos.BackgroundColor = System.Drawing.Color.White;
            this.dtgTratamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTratamentos.ColumnHeadersVisible = false;
            this.dtgTratamentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descricao});
            this.helpProvider1.SetHelpKeyword(this.dtgTratamentos, "");
            this.helpProvider1.SetHelpString(this.dtgTratamentos, "Lista de tratamentos do pen drive.");
            this.dtgTratamentos.Location = new System.Drawing.Point(12, 38);
            this.dtgTratamentos.Name = "dtgTratamentos";
            this.dtgTratamentos.ReadOnly = true;
            this.dtgTratamentos.RowHeadersVisible = false;
            this.dtgTratamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.helpProvider1.SetShowHelp(this.dtgTratamentos, true);
            this.dtgTratamentos.Size = new System.Drawing.Size(162, 150);
            this.dtgTratamentos.TabIndex = 3;
            // 
            // Descricao
            // 
            this.Descricao.HeaderText = "";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 150;
            // 
            // Ok
            // 
            this.Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpKeyword(this.Ok, "");
            this.helpProvider1.SetHelpString(this.Ok, "Ok para efetivar a escolha da unidade.");
            this.Ok.Location = new System.Drawing.Point(107, 7);
            this.Ok.Name = "Ok";
            this.helpProvider1.SetShowHelp(this.Ok, true);
            this.Ok.Size = new System.Drawing.Size(67, 23);
            this.Ok.TabIndex = 2;
            this.Ok.Text = "OK";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // cmbUnidades
            // 
            this.cmbUnidades.FormattingEnabled = true;
            this.helpProvider1.SetHelpKeyword(this.cmbUnidades, "");
            this.helpProvider1.SetHelpString(this.cmbUnidades, "Unidade onde o pen drive foi inserido.");
            this.cmbUnidades.Location = new System.Drawing.Point(56, 9);
            this.cmbUnidades.Name = "cmbUnidades";
            this.helpProvider1.SetShowHelp(this.cmbUnidades, true);
            this.cmbUnidades.Size = new System.Drawing.Size(45, 21);
            this.cmbUnidades.TabIndex = 1;
            this.cmbUnidades.SelectedIndexChanged += new System.EventHandler(this.cmbUnidades_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.label1, "");
            this.helpProvider1.SetHelpString(this.label1, "Unidade onde o pen drive foi inserido.");
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, true);
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Unidade:";
            // 
            // frmPenDrive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(190, 202);
            this.Controls.Add(this.dtgTratamentos);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.cmbUnidades);
            this.Controls.Add(this.label1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPenDrive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trat(s)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPenDrive_FormClosing);
            this.Load += new System.EventHandler(this.frmPenDrive_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTratamentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgTratamentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.ComboBox cmbUnidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}