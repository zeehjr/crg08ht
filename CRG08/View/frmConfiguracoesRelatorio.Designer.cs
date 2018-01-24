namespace CRG08.View
{
    partial class frmConfiguracoesRelatorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracoesRelatorio));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPadraoDepoisTrat = new System.Windows.Forms.LinkLabel();
            this.lblPadraoTrat = new System.Windows.Forms.LinkLabel();
            this.lblPadraoAntesTrat = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.udLinhasTrat = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.udLinhasDepois = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.udLinhasAntes = new System.Windows.Forms.NumericUpDown();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udLinhasTrat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLinhasDepois)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLinhasAntes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPadraoDepoisTrat);
            this.groupBox1.Controls.Add(this.lblPadraoTrat);
            this.groupBox1.Controls.Add(this.lblPadraoAntesTrat);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.udLinhasTrat);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.udLinhasDepois);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.udLinhasAntes);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tratamento";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblPadraoDepoisTrat
            // 
            this.lblPadraoDepoisTrat.ActiveLinkColor = System.Drawing.Color.Gray;
            this.lblPadraoDepoisTrat.AutoSize = true;
            this.lblPadraoDepoisTrat.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.lblPadraoDepoisTrat, "");
            this.helpProvider1.SetHelpString(this.lblPadraoDepoisTrat, "Padrão de leituras depois do tratamento é de 10 leituras.");
            this.lblPadraoDepoisTrat.LinkColor = System.Drawing.Color.Black;
            this.lblPadraoDepoisTrat.Location = new System.Drawing.Point(225, 102);
            this.lblPadraoDepoisTrat.Name = "lblPadraoDepoisTrat";
            this.helpProvider1.SetShowHelp(this.lblPadraoDepoisTrat, true);
            this.lblPadraoDepoisTrat.Size = new System.Drawing.Size(45, 14);
            this.lblPadraoDepoisTrat.TabIndex = 15;
            this.lblPadraoDepoisTrat.TabStop = true;
            this.lblPadraoDepoisTrat.Text = "Padrão";
            this.lblPadraoDepoisTrat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPadraoDepoisTrat_LinkClicked);
            // 
            // lblPadraoTrat
            // 
            this.lblPadraoTrat.ActiveLinkColor = System.Drawing.Color.Gray;
            this.lblPadraoTrat.AutoSize = true;
            this.lblPadraoTrat.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.lblPadraoTrat, "");
            this.helpProvider1.SetHelpString(this.lblPadraoTrat, "Padrão de leituras do tratamento é de 20 leituras.");
            this.lblPadraoTrat.LinkColor = System.Drawing.Color.Black;
            this.lblPadraoTrat.Location = new System.Drawing.Point(225, 76);
            this.lblPadraoTrat.Name = "lblPadraoTrat";
            this.helpProvider1.SetShowHelp(this.lblPadraoTrat, true);
            this.lblPadraoTrat.Size = new System.Drawing.Size(45, 14);
            this.lblPadraoTrat.TabIndex = 14;
            this.lblPadraoTrat.TabStop = true;
            this.lblPadraoTrat.Text = "Padrão";
            this.lblPadraoTrat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPadraoTrat_LinkClicked);
            // 
            // lblPadraoAntesTrat
            // 
            this.lblPadraoAntesTrat.ActiveLinkColor = System.Drawing.Color.Gray;
            this.lblPadraoAntesTrat.AutoSize = true;
            this.lblPadraoAntesTrat.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.lblPadraoAntesTrat, "");
            this.helpProvider1.SetHelpString(this.lblPadraoAntesTrat, "Padrão de leituras antes do tratamento é de 10 leituras.");
            this.lblPadraoAntesTrat.LinkColor = System.Drawing.Color.Black;
            this.lblPadraoAntesTrat.Location = new System.Drawing.Point(225, 51);
            this.lblPadraoAntesTrat.Name = "lblPadraoAntesTrat";
            this.helpProvider1.SetShowHelp(this.lblPadraoAntesTrat, true);
            this.lblPadraoAntesTrat.Size = new System.Drawing.Size(45, 14);
            this.lblPadraoAntesTrat.TabIndex = 13;
            this.lblPadraoAntesTrat.TabStop = true;
            this.lblPadraoAntesTrat.Text = "Padrão";
            this.lblPadraoAntesTrat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPadraoAntesTrat_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.label4, "");
            this.helpProvider1.SetHelpString(this.label4, "Configuração da quantidade de leituras após o fim do tratamento.");
            this.label4.Location = new System.Drawing.Point(26, 102);
            this.label4.Name = "label4";
            this.helpProvider1.SetShowHelp(this.label4, true);
            this.label4.Size = new System.Drawing.Size(149, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Leituras depois do tratamento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.label3, "");
            this.helpProvider1.SetHelpString(this.label3, "Configuração da quantidade de leituras do tratamento para o relatório.");
            this.label3.Location = new System.Drawing.Point(26, 76);
            this.label3.Name = "label3";
            this.helpProvider1.SetShowHelp(this.label3, true);
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Leituras do tratamento:";
            // 
            // udLinhasTrat
            // 
            this.helpProvider1.SetHelpKeyword(this.udLinhasTrat, "");
            this.helpProvider1.SetHelpString(this.udLinhasTrat, "Configuração da quantidade de leituras do tratamento para o relatório.");
            this.udLinhasTrat.Location = new System.Drawing.Point(181, 74);
            this.udLinhasTrat.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.udLinhasTrat.Name = "udLinhasTrat";
            this.helpProvider1.SetShowHelp(this.udLinhasTrat, true);
            this.udLinhasTrat.Size = new System.Drawing.Size(38, 20);
            this.udLinhasTrat.TabIndex = 2;
            this.udLinhasTrat.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.label2, "");
            this.helpProvider1.SetHelpString(this.label2, "Configuração da quantidade das leituras antes do início do tratamento.");
            this.label2.Location = new System.Drawing.Point(26, 51);
            this.label2.Name = "label2";
            this.helpProvider1.SetShowHelp(this.label2, true);
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Leituras antes do tratamento:";
            // 
            // udLinhasDepois
            // 
            this.helpProvider1.SetHelpKeyword(this.udLinhasDepois, "");
            this.helpProvider1.SetHelpString(this.udLinhasDepois, "Configuração da quantidade de leituras após o fim do tratamento.");
            this.udLinhasDepois.Location = new System.Drawing.Point(181, 100);
            this.udLinhasDepois.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.udLinhasDepois.Name = "udLinhasDepois";
            this.helpProvider1.SetShowHelp(this.udLinhasDepois, true);
            this.udLinhasDepois.Size = new System.Drawing.Size(38, 20);
            this.udLinhasDepois.TabIndex = 1;
            this.udLinhasDepois.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udLinhasDepois.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpString(this.label1, "Configuração da preferência das leituras do tratamento.");
            this.label1.Location = new System.Drawing.Point(17, 28);
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, true);
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Exibição de linhas";
            // 
            // udLinhasAntes
            // 
            this.helpProvider1.SetHelpKeyword(this.udLinhasAntes, "");
            this.helpProvider1.SetHelpString(this.udLinhasAntes, "Configuração da quantidade de leituras antes do início do tratamento.");
            this.udLinhasAntes.Location = new System.Drawing.Point(181, 49);
            this.udLinhasAntes.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.udLinhasAntes.Name = "udLinhasAntes";
            this.helpProvider1.SetShowHelp(this.udLinhasAntes, true);
            this.udLinhasAntes.Size = new System.Drawing.Size(38, 20);
            this.udLinhasAntes.TabIndex = 0;
            this.udLinhasAntes.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnSalvar
            // 
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpKeyword(this.btnSalvar, "");
            this.helpProvider1.SetHelpString(this.btnSalvar, "Salva as configurações do relatório de tratamento.");
            this.btnSalvar.Location = new System.Drawing.Point(141, 162);
            this.btnSalvar.Name = "btnSalvar";
            this.helpProvider1.SetShowHelp(this.btnSalvar, true);
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnSair
            // 
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpKeyword(this.btnSair, "");
            this.helpProvider1.SetHelpString(this.btnSair, "Função sair, não salva alterações.");
            this.btnSair.Location = new System.Drawing.Point(222, 162);
            this.btnSair.Name = "btnSair";
            this.helpProvider1.SetShowHelp(this.btnSair, true);
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 2;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // frmConfiguracoesRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 193);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.groupBox1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfiguracoesRelatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConfiguracoesRelatorio";
            this.Load += new System.EventHandler(this.frmConfiguracoesRelatorio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udLinhasTrat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLinhasDepois)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLinhasAntes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown udLinhasTrat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown udLinhasDepois;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown udLinhasAntes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.LinkLabel lblPadraoDepoisTrat;
        private System.Windows.Forms.LinkLabel lblPadraoTrat;
        private System.Windows.Forms.LinkLabel lblPadraoAntesTrat;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}