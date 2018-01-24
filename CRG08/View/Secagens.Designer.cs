namespace CRG08.View
{
    partial class Secagens
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
            this.lvSecagens = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnReceber = new System.Windows.Forms.Button();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.cmbCRG = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // lvSecagens
            // 
            this.lvSecagens.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvSecagens.FullRowSelect = true;
            this.lvSecagens.GridLines = true;
            this.helpProvider1.SetHelpKeyword(this.lvSecagens, "");
            this.helpProvider1.SetHelpString(this.lvSecagens, "Lista de tratamentos na memória do equipamento Crg.");
            this.lvSecagens.Location = new System.Drawing.Point(12, 35);
            this.lvSecagens.MultiSelect = false;
            this.lvSecagens.Name = "lvSecagens";
            this.helpProvider1.SetShowHelp(this.lvSecagens, true);
            this.lvSecagens.Size = new System.Drawing.Size(426, 250);
            this.lvSecagens.TabIndex = 0;
            this.lvSecagens.UseCompatibleStateImageBehavior = false;
            this.lvSecagens.View = System.Windows.Forms.View.Details;
            this.lvSecagens.SelectedIndexChanged += new System.EventHandler(this.listaSecagens_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nº Leituras";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Data Início";
            this.columnHeader3.Width = 100;
            // 
            // btnReceber
            // 
            this.btnReceber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.btnReceber, "");
            this.helpProvider1.SetHelpString(this.btnReceber, "Recebe os tratamentos da memória do Crg.");
            this.btnReceber.Location = new System.Drawing.Point(12, 291);
            this.btnReceber.Name = "btnReceber";
            this.helpProvider1.SetShowHelp(this.btnReceber, true);
            this.btnReceber.Size = new System.Drawing.Size(75, 29);
            this.btnReceber.TabIndex = 1;
            this.btnReceber.Text = "Receber";
            this.btnReceber.UseVisualStyleBackColor = true;
            this.btnReceber.Click += new System.EventHandler(this.btnReceber_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Enabled = false;
            this.btnInserir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInserir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.btnInserir, "");
            this.helpProvider1.SetHelpString(this.btnInserir, "Botão inserir.");
            this.btnInserir.Location = new System.Drawing.Point(119, 291);
            this.btnInserir.Name = "btnInserir";
            this.helpProvider1.SetShowHelp(this.btnInserir, true);
            this.btnInserir.Size = new System.Drawing.Size(75, 29);
            this.btnInserir.TabIndex = 2;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnSair
            // 
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.btnSair, "");
            this.helpProvider1.SetHelpString(this.btnSair, "Sair dos tratamentos, não salva alterações.");
            this.btnSair.Location = new System.Drawing.Point(363, 291);
            this.btnSair.Name = "btnSair";
            this.helpProvider1.SetShowHelp(this.btnSair, true);
            this.btnSair.Size = new System.Drawing.Size(75, 29);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // cmbCRG
            // 
            this.cmbCRG.DisplayMember = "1";
            this.cmbCRG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCRG.FormattingEnabled = true;
            this.helpProvider1.SetHelpKeyword(this.cmbCRG, "");
            this.helpProvider1.SetHelpString(this.cmbCRG, "Adicionar o número do equipamento que se quer baixar os dados on line.");
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
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32"});
            this.cmbCRG.Location = new System.Drawing.Point(73, 8);
            this.cmbCRG.Name = "cmbCRG";
            this.helpProvider1.SetShowHelp(this.cmbCRG, true);
            this.cmbCRG.Size = new System.Drawing.Size(79, 21);
            this.cmbCRG.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.label1, "");
            this.helpProvider1.SetHelpString(this.label1, "Adicionar o número do equipamento que se quer baixar os dados on line.");
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, true);
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nº CRG:";
            // 
            // Secagens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 330);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCRG);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.btnReceber);
            this.Controls.Add(this.lvSecagens);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Secagens";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tratamentos";
            this.Load += new System.EventHandler(this.Secagens_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvSecagens;
        private System.Windows.Forms.Button btnReceber;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.ComboBox cmbCRG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}