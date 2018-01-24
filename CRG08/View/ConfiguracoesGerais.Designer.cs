namespace CRG08.View
{
    partial class ConfiguracoesGerais
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfiguracoesGerais));
            this.grpAtualizacoes = new System.Windows.Forms.GroupBox();
            this.Desativada = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.intervalo = new System.Windows.Forms.NumericUpDown();
            this.Automatica = new System.Windows.Forms.RadioButton();
            this.Individual = new System.Windows.Forms.RadioButton();
            this.SalvarAtualizacao = new System.Windows.Forms.Button();
            this.Sair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPorta = new System.Windows.Forms.ComboBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.grpAtualizacoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalo)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAtualizacoes
            // 
            this.grpAtualizacoes.Controls.Add(this.Desativada);
            this.grpAtualizacoes.Controls.Add(this.label2);
            this.grpAtualizacoes.Controls.Add(this.intervalo);
            this.grpAtualizacoes.Controls.Add(this.Automatica);
            this.grpAtualizacoes.Controls.Add(this.Individual);
            this.grpAtualizacoes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.helpProvider1.SetHelpKeyword(this.grpAtualizacoes, "Atualização dos ciclos em andamento, pode ser configurada em individual ou desati" +
        "vada em minutos");
            this.grpAtualizacoes.Location = new System.Drawing.Point(12, 33);
            this.grpAtualizacoes.Name = "grpAtualizacoes";
            this.helpProvider1.SetShowHelp(this.grpAtualizacoes, true);
            this.grpAtualizacoes.Size = new System.Drawing.Size(281, 67);
            this.grpAtualizacoes.TabIndex = 7;
            this.grpAtualizacoes.TabStop = false;
            this.grpAtualizacoes.Text = "Atualização";
            // 
            // Desativada
            // 
            this.Desativada.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.Desativada, "");
            this.helpProvider1.SetHelpString(this.Desativada, "Atualização dos ciclos em andamento, pode ser configurada em individual ou desati" +
        "vada.");
            this.Desativada.Location = new System.Drawing.Point(13, 42);
            this.Desativada.Name = "Desativada";
            this.helpProvider1.SetShowHelp(this.Desativada, true);
            this.Desativada.Size = new System.Drawing.Size(79, 17);
            this.Desativada.TabIndex = 5;
            this.Desativada.TabStop = true;
            this.Desativada.Text = "Desativada";
            this.Desativada.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.label2, "Atualização dos ciclos em andamento, pode ser configurada em individual, desativa" +
        "da ou automática em minutos.");
            this.label2.Location = new System.Drawing.Point(175, 49);
            this.label2.Name = "label2";
            this.helpProvider1.SetShowHelp(this.label2, true);
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "minutos";
            this.label2.Visible = false;
            // 
            // intervalo
            // 
            this.intervalo.Enabled = false;
            this.helpProvider1.SetHelpKeyword(this.intervalo, "Atualização dos ciclos em andamento, pode ser configurada em individual, desativa" +
        "da ou automática em minutos.");
            this.intervalo.Location = new System.Drawing.Point(125, 42);
            this.intervalo.Name = "intervalo";
            this.helpProvider1.SetShowHelp(this.intervalo, true);
            this.intervalo.Size = new System.Drawing.Size(44, 20);
            this.intervalo.TabIndex = 4;
            this.intervalo.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.intervalo.Visible = false;
            // 
            // Automatica
            // 
            this.Automatica.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.Automatica, "Atualização dos ciclos em andamento, pode ser configurada em individual, desativa" +
        "da ou automática em minutos.");
            this.Automatica.Location = new System.Drawing.Point(13, 42);
            this.Automatica.Name = "Automatica";
            this.helpProvider1.SetShowHelp(this.Automatica, true);
            this.Automatica.Size = new System.Drawing.Size(114, 17);
            this.Automatica.TabIndex = 3;
            this.Automatica.TabStop = true;
            this.Automatica.Text = "Automática a cada";
            this.Automatica.UseVisualStyleBackColor = true;
            this.Automatica.Visible = false;
            this.Automatica.CheckedChanged += new System.EventHandler(this.Automatica_CheckedChanged);
            // 
            // Individual
            // 
            this.Individual.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.Individual, "Atualização dos ciclos em andamento, pode ser configurada em individual ou desati" +
        "vada.");
            this.Individual.Location = new System.Drawing.Point(13, 19);
            this.Individual.Name = "Individual";
            this.helpProvider1.SetShowHelp(this.Individual, true);
            this.Individual.Size = new System.Drawing.Size(70, 17);
            this.Individual.TabIndex = 2;
            this.Individual.TabStop = true;
            this.Individual.Text = "Individual";
            this.Individual.UseVisualStyleBackColor = true;
            // 
            // SalvarAtualizacao
            // 
            this.SalvarAtualizacao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.helpProvider1.SetHelpKeyword(this.SalvarAtualizacao, "");
            this.helpProvider1.SetHelpString(this.SalvarAtualizacao, "Salva as configurações feitas.");
            this.SalvarAtualizacao.Location = new System.Drawing.Point(137, 107);
            this.SalvarAtualizacao.Name = "SalvarAtualizacao";
            this.helpProvider1.SetShowHelp(this.SalvarAtualizacao, true);
            this.SalvarAtualizacao.Size = new System.Drawing.Size(75, 23);
            this.SalvarAtualizacao.TabIndex = 9;
            this.SalvarAtualizacao.Text = "Salvar";
            this.SalvarAtualizacao.UseVisualStyleBackColor = true;
            this.SalvarAtualizacao.Click += new System.EventHandler(this.SalvarAtualizacao_Click);
            // 
            // Sair
            // 
            this.Sair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.helpProvider1.SetHelpKeyword(this.Sair, "");
            this.helpProvider1.SetHelpString(this.Sair, "Sai da tela de configurações gerais, não salva nenhuma modificação.");
            this.Sair.Location = new System.Drawing.Point(218, 107);
            this.Sair.Name = "Sair";
            this.helpProvider1.SetShowHelp(this.Sair, true);
            this.Sair.Size = new System.Drawing.Size(75, 23);
            this.Sair.TabIndex = 10;
            this.Sair.Text = "Sair";
            this.Sair.UseVisualStyleBackColor = true;
            this.Sair.Click += new System.EventHandler(this.Sair_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Porta:";
            // 
            // cmbPorta
            // 
            this.cmbPorta.FormattingEnabled = true;
            this.helpProvider1.SetHelpKeyword(this.cmbPorta, "");
            this.helpProvider1.SetHelpString(this.cmbPorta, "Porta de comunicação onde o conversor esta ligado.");
            this.cmbPorta.ItemHeight = 13;
            this.cmbPorta.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.cmbPorta.Location = new System.Drawing.Point(44, 6);
            this.cmbPorta.Name = "cmbPorta";
            this.helpProvider1.SetShowHelp(this.cmbPorta, true);
            this.cmbPorta.Size = new System.Drawing.Size(69, 21);
            this.cmbPorta.TabIndex = 7;
            // 
            // ConfiguracoesGerais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(305, 136);
            this.Controls.Add(this.SalvarAtualizacao);
            this.Controls.Add(this.cmbPorta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Sair);
            this.Controls.Add(this.grpAtualizacoes);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfiguracoesGerais";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações Gerais";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfiguracoesGerais_FormClosing);
            this.Load += new System.EventHandler(this.ConfiguracoesGerais_Load);
            this.grpAtualizacoes.ResumeLayout(false);
            this.grpAtualizacoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAtualizacoes;
        private System.Windows.Forms.Button SalvarAtualizacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown intervalo;
        private System.Windows.Forms.RadioButton Automatica;
        private System.Windows.Forms.RadioButton Individual;
        private System.Windows.Forms.Button Sair;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPorta;
        private System.Windows.Forms.RadioButton Desativada;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}