namespace CRG08.View
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.monitorarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ciclosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ciclosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarImportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesGeraisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dadosEmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logErrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logMudançasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesRelatórioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBackup = new System.Windows.Forms.Label();
            this.lblAtualizacao = new System.Windows.Forms.Label();
            this.lblPorta = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monitorarToolStripMenuItem,
            this.ciclosToolStripMenuItem,
            this.configuraçõesToolStripMenuItem,
            this.informaçõesToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(571, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // monitorarToolStripMenuItem
            // 
            this.monitorarToolStripMenuItem.Name = "monitorarToolStripMenuItem";
            this.monitorarToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.monitorarToolStripMenuItem.Text = "&Monitorar";
            this.monitorarToolStripMenuItem.Click += new System.EventHandler(this.monitorarToolStripMenuItem_Click);
            // 
            // ciclosToolStripMenuItem
            // 
            this.ciclosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ciclosToolStripMenuItem1,
            this.exportarImportarToolStripMenuItem});
            this.ciclosToolStripMenuItem.Name = "ciclosToolStripMenuItem";
            this.ciclosToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.ciclosToolStripMenuItem.Text = "&Ciclos";
            this.ciclosToolStripMenuItem.Click += new System.EventHandler(this.ciclosToolStripMenuItem_Click);
            // 
            // ciclosToolStripMenuItem1
            // 
            this.ciclosToolStripMenuItem1.Name = "ciclosToolStripMenuItem1";
            this.ciclosToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.ciclosToolStripMenuItem1.Text = "&Ciclos";
            this.ciclosToolStripMenuItem1.Click += new System.EventHandler(this.ciclosToolStripMenuItem1_Click);
            // 
            // exportarImportarToolStripMenuItem
            // 
            this.exportarImportarToolStripMenuItem.Name = "exportarImportarToolStripMenuItem";
            this.exportarImportarToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exportarImportarToolStripMenuItem.Text = "&Exportar/Importar";
            this.exportarImportarToolStripMenuItem.Click += new System.EventHandler(this.exportarImportarToolStripMenuItem_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem,
            this.configuraçõesGeraisToolStripMenuItem,
            this.dadosEmpresaToolStripMenuItem,
            this.logErrosToolStripMenuItem,
            this.logMudançasToolStripMenuItem,
            this.configuraçõesRelatórioToolStripMenuItem});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.configuraçõesToolStripMenuItem.Text = "&Configurações";
            this.configuraçõesToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.backupToolStripMenuItem.Text = "&Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // configuraçõesGeraisToolStripMenuItem
            // 
            this.configuraçõesGeraisToolStripMenuItem.Name = "configuraçõesGeraisToolStripMenuItem";
            this.configuraçõesGeraisToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.configuraçõesGeraisToolStripMenuItem.Text = "&Configurações Gerais";
            this.configuraçõesGeraisToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesGeraisToolStripMenuItem_Click);
            // 
            // dadosEmpresaToolStripMenuItem
            // 
            this.dadosEmpresaToolStripMenuItem.Name = "dadosEmpresaToolStripMenuItem";
            this.dadosEmpresaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.dadosEmpresaToolStripMenuItem.Text = "&Dados Empresa";
            this.dadosEmpresaToolStripMenuItem.Click += new System.EventHandler(this.dadosEmpresaToolStripMenuItem_Click);
            // 
            // logErrosToolStripMenuItem
            // 
            this.logErrosToolStripMenuItem.Name = "logErrosToolStripMenuItem";
            this.logErrosToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.logErrosToolStripMenuItem.Text = "&Log Erros";
            this.logErrosToolStripMenuItem.Click += new System.EventHandler(this.logErrosToolStripMenuItem_Click);
            // 
            // logMudançasToolStripMenuItem
            // 
            this.logMudançasToolStripMenuItem.Name = "logMudançasToolStripMenuItem";
            this.logMudançasToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.logMudançasToolStripMenuItem.Text = "&Log Mudanças";
            this.logMudançasToolStripMenuItem.Click += new System.EventHandler(this.logMudançasToolStripMenuItem_Click);
            // 
            // configuraçõesRelatórioToolStripMenuItem
            // 
            this.configuraçõesRelatórioToolStripMenuItem.Name = "configuraçõesRelatórioToolStripMenuItem";
            this.configuraçõesRelatórioToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.configuraçõesRelatórioToolStripMenuItem.Text = "Relatório";
            this.configuraçõesRelatórioToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesRelatórioToolStripMenuItem_Click);
            // 
            // informaçõesToolStripMenuItem
            // 
            this.informaçõesToolStripMenuItem.Name = "informaçõesToolStripMenuItem";
            this.informaçõesToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.informaçõesToolStripMenuItem.Text = "&Informações";
            this.informaçõesToolStripMenuItem.Click += new System.EventHandler(this.informaçõesToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "&Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = " o menu de &Configurações.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(390, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "*Para alterar alguma das configurações acima ou a imagem acesse ";
            // 
            // lblBackup
            // 
            this.lblBackup.AutoSize = true;
            this.lblBackup.Location = new System.Drawing.Point(12, 241);
            this.lblBackup.Name = "lblBackup";
            this.lblBackup.Size = new System.Drawing.Size(233, 13);
            this.lblBackup.TabIndex = 18;
            this.lblBackup.Text = "O Backup está como automático semanalmente";
            // 
            // lblAtualizacao
            // 
            this.lblAtualizacao.AutoSize = true;
            this.lblAtualizacao.Location = new System.Drawing.Point(12, 254);
            this.lblAtualizacao.Name = "lblAtualizacao";
            this.lblAtualizacao.Size = new System.Drawing.Size(268, 13);
            this.lblAtualizacao.TabIndex = 17;
            this.lblAtualizacao.Text = "A atualização está como automática a cada 15 minutos";
            this.lblAtualizacao.Visible = false;
            // 
            // lblPorta
            // 
            this.lblPorta.AutoSize = true;
            this.helpProvider1.SetHelpString(this.lblPorta, "Mostra porta configurada.");
            this.lblPorta.Location = new System.Drawing.Point(12, 223);
            this.lblPorta.Name = "lblPorta";
            this.helpProvider1.SetShowHelp(this.lblPorta, true);
            this.lblPorta.Size = new System.Drawing.Size(165, 13);
            this.lblPorta.TabIndex = 16;
            this.lblPorta.Text = "A porta de comunicação é COM3";
            // 
            // pictureBox1
            // 
            this.helpProvider1.SetHelpKeyword(this.pictureBox1, "Teste");
            this.helpProvider1.SetHelpString(this.pictureBox1, "Logo da empresa, pode ser alterado em configurações>Dados empresa.");
            this.pictureBox1.Image = global::CRG08.Properties.Resources.LogoDigiComNome;
            this.pictureBox1.Location = new System.Drawing.Point(56, 115);
            this.pictureBox1.Name = "pictureBox1";
            this.helpProvider1.SetShowHelp(this.pictureBox1, true);
            this.pictureBox1.Size = new System.Drawing.Size(456, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Logo da empresa, pode ser alterado em configurações>Dados empresa.");
            // 
            // button8
            // 
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button8.FlatAppearance.BorderSize = 2;
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.button8, "");
            this.helpProvider1.SetHelpString(this.button8, "Configuração da Porta e atualização dos dados individual ou desativada.");
            this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
            this.button8.Location = new System.Drawing.Point(499, 27);
            this.button8.Name = "button8";
            this.helpProvider1.SetShowHelp(this.button8, true);
            this.button8.Size = new System.Drawing.Size(70, 70);
            this.button8.TabIndex = 28;
            this.button8.TabStop = false;
            this.button8.Text = "Config. Geral";
            this.button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.configuraçõesGeraisToolStripMenuItem_Click);
            this.button8.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button8.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // button7
            // 
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button7.FlatAppearance.BorderSize = 2;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpString(this.button7, "Log de Erro grava e mostra  data/hora, descrição e os detalhes dos erros.");
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.Location = new System.Drawing.Point(428, 27);
            this.button7.Name = "button7";
            this.helpProvider1.SetShowHelp(this.button7, true);
            this.button7.Size = new System.Drawing.Size(70, 70);
            this.button7.TabIndex = 27;
            this.button7.TabStop = false;
            this.button7.Text = "Log Erro";
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.logErrosToolStripMenuItem_Click);
            this.button7.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button7.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button6.FlatAppearance.BorderSize = 2;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpString(this.button6, "Log de mudança que mostra e grava dados como data/hora, descrição e o Responsável" +
        " pela mudança.");
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(357, 27);
            this.button6.Name = "button6";
            this.helpProvider1.SetShowHelp(this.button6, true);
            this.button6.Size = new System.Drawing.Size(70, 70);
            this.button6.TabIndex = 26;
            this.button6.TabStop = false;
            this.button6.Text = "Log Mudança";
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.logMudançasToolStripMenuItem_Click);
            this.button6.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button6.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button5.FlatAppearance.BorderSize = 2;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpString(this.button5, "Gera e restaura cópia de segurança manualmente, possui a função de ativar Backup " +
        "automático onde pode-se configurar período do backup e pasta de destino.");
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(286, 27);
            this.button5.Name = "button5";
            this.helpProvider1.SetShowHelp(this.button5, true);
            this.button5.Size = new System.Drawing.Size(70, 70);
            this.button5.TabIndex = 25;
            this.button5.TabStop = false;
            this.button5.Text = "Backup";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            this.button5.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button5.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button4.FlatAppearance.BorderSize = 2;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpString(this.button4, "Exporta ciclos em andamento e finalizados, podem ser salvos como arquivo ou envia" +
        "do por e-mail.");
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(215, 27);
            this.button4.Name = "button4";
            this.helpProvider1.SetShowHelp(this.button4, true);
            this.button4.Size = new System.Drawing.Size(70, 70);
            this.button4.TabIndex = 24;
            this.button4.TabStop = false;
            this.button4.Text = "Exportar";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.exportarImportarToolStripMenuItem_Click);
            this.button4.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button4.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpString(this.button3, "Importa ciclos em andamento e ciclos finalizados, podem ser achados no lugar onde" +
        " foram exportados.");
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(144, 27);
            this.button3.Name = "button3";
            this.helpProvider1.SetShowHelp(this.button3, true);
            this.button3.Size = new System.Drawing.Size(70, 70);
            this.button3.TabIndex = 23;
            this.button3.TabStop = false;
            this.button3.Text = "Importar";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button3.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpString(this.button2, "Novo ciclo, baixa os dados do aparelho via on line ou pen drive.");
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(73, 27);
            this.button2.Name = "button2";
            this.helpProvider1.SetShowHelp(this.button2, true);
            this.button2.Size = new System.Drawing.Size(70, 70);
            this.button2.TabIndex = 22;
            this.button2.TabStop = false;
            this.button2.Text = "Ciclos";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ciclosToolStripMenuItem1_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpString(this.button1, "Monitora o aparelho que se encontra na estufa, necessário configurações de Nº CRG" +
        " e porta.");
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(2, 27);
            this.button1.Name = "button1";
            this.helpProvider1.SetShowHelp(this.button1, true);
            this.button1.Size = new System.Drawing.Size(70, 70);
            this.button1.TabIndex = 21;
            this.button1.TabStop = false;
            this.button1.Text = "Monitorar";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.monitorarToolStripMenuItem_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(571, 322);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblAtualizacao);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblBackup);
            this.Controls.Add(this.lblPorta);
            this.HelpButton = true;
            this.helpProvider1.SetHelpKeyword(this, "");
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Principal";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " CRG 08 - Estação de Controle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem monitorarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ciclosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informaçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBackup;
        private System.Windows.Forms.Label lblAtualizacao;
        private System.Windows.Forms.Label lblPorta;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesGeraisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dadosEmpresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logErrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logMudançasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ciclosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportarImportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesRelatórioToolStripMenuItem;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}