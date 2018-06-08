namespace CRG08.View
{
    partial class Grafico
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Grafico));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnT1 = new System.Windows.Forms.Button();
            this.chkT1 = new System.Windows.Forms.CheckBox();
            this.btnT2 = new System.Windows.Forms.Button();
            this.chkT2 = new System.Windows.Forms.CheckBox();
            this.btnT3 = new System.Windows.Forms.Button();
            this.chkT3 = new System.Windows.Forms.CheckBox();
            this.btnT4 = new System.Windows.Forms.Button();
            this.chkT4 = new System.Windows.Forms.CheckBox();
            this.btnCA = new System.Windows.Forms.Button();
            this.chkCA = new System.Windows.Forms.CheckBox();
            this.btnGR = new System.Windows.Forms.Button();
            this.Desmarca = new System.Windows.Forms.Button();
            this.TipoGrafico = new System.Windows.Forms.Button();
            this.Imprimir = new System.Windows.Forms.Button();
            this.btnConfigurar = new System.Windows.Forms.Button();
            this.Sair = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblProdutos = new System.Windows.Forms.Label();
            this.Operador = new System.Windows.Forms.Label();
            this.Responsavel = new System.Windows.Forms.Label();
            this.Descricao = new System.Windows.Forms.Label();
            this.tempoTrat = new System.Windows.Forms.Label();
            this.DadosTrat = new System.Windows.Forms.Label();
            this.Datas = new System.Windows.Forms.Label();
            this.Controlador = new System.Windows.Forms.Label();
            this.Produtos = new System.Windows.Forms.Button();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.txtHorario = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtNL = new System.Windows.Forms.TextBox();
            this.SalvaGrafico = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 406);
            this.panel1.TabIndex = 29;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Left;
            this.helpProvider1.SetHelpString(this.chart1, "Gráfico.");
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(0);
            this.chart1.Name = "chart1";
            this.helpProvider1.SetShowHelp(this.chart1, true);
            this.chart1.Size = new System.Drawing.Size(844, 404);
            this.chart1.TabIndex = 30;
            this.chart1.Text = "chart1";
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // btnT1
            // 
            this.btnT1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnT1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnT1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnT1.Location = new System.Drawing.Point(47, 4);
            this.btnT1.Name = "btnT1";
            this.btnT1.Size = new System.Drawing.Size(18, 17);
            this.btnT1.TabIndex = 2;
            this.btnT1.UseVisualStyleBackColor = true;
            this.btnT1.Click += new System.EventHandler(this.BotoesPaletaDeCor);
            // 
            // chkT1
            // 
            this.chkT1.AutoSize = true;
            this.chkT1.Checked = true;
            this.chkT1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkT1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkT1.Location = new System.Drawing.Point(8, 4);
            this.chkT1.Name = "chkT1";
            this.chkT1.Size = new System.Drawing.Size(38, 18);
            this.chkT1.TabIndex = 1;
            this.chkT1.Text = "T1";
            this.chkT1.UseVisualStyleBackColor = true;
            this.chkT1.CheckedChanged += new System.EventHandler(this.VisualizarLinhasDoGrafico);
            // 
            // btnT2
            // 
            this.btnT2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnT2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnT2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnT2.Location = new System.Drawing.Point(109, 4);
            this.btnT2.Name = "btnT2";
            this.btnT2.Size = new System.Drawing.Size(18, 17);
            this.btnT2.TabIndex = 4;
            this.btnT2.UseVisualStyleBackColor = true;
            this.btnT2.Click += new System.EventHandler(this.BotoesPaletaDeCor);
            // 
            // chkT2
            // 
            this.chkT2.AutoSize = true;
            this.chkT2.Checked = true;
            this.chkT2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkT2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkT2.Location = new System.Drawing.Point(71, 4);
            this.chkT2.Name = "chkT2";
            this.chkT2.Size = new System.Drawing.Size(38, 18);
            this.chkT2.TabIndex = 3;
            this.chkT2.Text = "T2";
            this.chkT2.UseVisualStyleBackColor = true;
            this.chkT2.CheckedChanged += new System.EventHandler(this.VisualizarLinhasDoGrafico);
            // 
            // btnT3
            // 
            this.btnT3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnT3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnT3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnT3.Location = new System.Drawing.Point(171, 4);
            this.btnT3.Name = "btnT3";
            this.btnT3.Size = new System.Drawing.Size(18, 17);
            this.btnT3.TabIndex = 6;
            this.btnT3.UseVisualStyleBackColor = true;
            this.btnT3.Click += new System.EventHandler(this.BotoesPaletaDeCor);
            // 
            // chkT3
            // 
            this.chkT3.AutoSize = true;
            this.chkT3.Checked = true;
            this.chkT3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkT3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkT3.Location = new System.Drawing.Point(133, 4);
            this.chkT3.Name = "chkT3";
            this.chkT3.Size = new System.Drawing.Size(38, 18);
            this.chkT3.TabIndex = 5;
            this.chkT3.Text = "T3";
            this.chkT3.UseVisualStyleBackColor = true;
            this.chkT3.CheckedChanged += new System.EventHandler(this.VisualizarLinhasDoGrafico);
            // 
            // btnT4
            // 
            this.btnT4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnT4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnT4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnT4.Location = new System.Drawing.Point(233, 4);
            this.btnT4.Name = "btnT4";
            this.btnT4.Size = new System.Drawing.Size(18, 17);
            this.btnT4.TabIndex = 8;
            this.btnT4.UseVisualStyleBackColor = true;
            this.btnT4.Click += new System.EventHandler(this.BotoesPaletaDeCor);
            // 
            // chkT4
            // 
            this.chkT4.AutoSize = true;
            this.chkT4.Checked = true;
            this.chkT4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkT4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkT4.Location = new System.Drawing.Point(195, 4);
            this.chkT4.Name = "chkT4";
            this.chkT4.Size = new System.Drawing.Size(38, 18);
            this.chkT4.TabIndex = 7;
            this.chkT4.Text = "T4";
            this.chkT4.UseVisualStyleBackColor = true;
            this.chkT4.CheckedChanged += new System.EventHandler(this.VisualizarLinhasDoGrafico);
            // 
            // btnCA
            // 
            this.btnCA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCA.Location = new System.Drawing.Point(295, 4);
            this.btnCA.Name = "btnCA";
            this.btnCA.Size = new System.Drawing.Size(18, 17);
            this.btnCA.TabIndex = 10;
            this.btnCA.UseVisualStyleBackColor = true;
            this.btnCA.Click += new System.EventHandler(this.BotoesPaletaDeCor);
            // 
            // chkCA
            // 
            this.chkCA.AutoSize = true;
            this.chkCA.Checked = true;
            this.chkCA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCA.Location = new System.Drawing.Point(257, 4);
            this.chkCA.Name = "chkCA";
            this.chkCA.Size = new System.Drawing.Size(41, 18);
            this.chkCA.TabIndex = 9;
            this.chkCA.Text = "CA";
            this.chkCA.UseVisualStyleBackColor = true;
            this.chkCA.CheckedChanged += new System.EventHandler(this.VisualizarLinhasDoGrafico);
            // 
            // btnGR
            // 
            this.btnGR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGR.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGR.Location = new System.Drawing.Point(319, 2);
            this.btnGR.Name = "btnGR";
            this.btnGR.Size = new System.Drawing.Size(31, 20);
            this.btnGR.TabIndex = 11;
            this.btnGR.Text = "GR";
            this.btnGR.UseVisualStyleBackColor = true;
            this.btnGR.Click += new System.EventHandler(this.btnGR_Click);
            // 
            // Desmarca
            // 
            this.Desmarca.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Desmarca.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.Desmarca, "");
            this.helpProvider1.SetHelpString(this.Desmarca, "Função que alterna entre marcar e desmarcar os pontos do gráfico.");
            this.Desmarca.Location = new System.Drawing.Point(706, 422);
            this.Desmarca.Name = "Desmarca";
            this.helpProvider1.SetShowHelp(this.Desmarca, true);
            this.Desmarca.Size = new System.Drawing.Size(75, 23);
            this.Desmarca.TabIndex = 15;
            this.Desmarca.Text = "Desmarcar";
            this.Desmarca.UseVisualStyleBackColor = true;
            this.Desmarca.Click += new System.EventHandler(this.Desmarca_Click);
            // 
            // TipoGrafico
            // 
            this.TipoGrafico.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TipoGrafico.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.TipoGrafico, "");
            this.helpProvider1.SetHelpString(this.TipoGrafico, "Botão altera gráfico entre ciclo e tratamento.");
            this.TipoGrafico.Location = new System.Drawing.Point(787, 422);
            this.TipoGrafico.Name = "TipoGrafico";
            this.helpProvider1.SetShowHelp(this.TipoGrafico, true);
            this.TipoGrafico.Size = new System.Drawing.Size(75, 23);
            this.TipoGrafico.TabIndex = 16;
            this.TipoGrafico.Text = "Tratamento";
            this.TipoGrafico.UseVisualStyleBackColor = true;
            this.TipoGrafico.Click += new System.EventHandler(this.TipoGrafico_Click);
            // 
            // Imprimir
            // 
            this.Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Imprimir.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.Imprimir, "");
            this.helpProvider1.SetHelpString(this.Imprimir, "Impressão do gráfico.");
            this.Imprimir.Location = new System.Drawing.Point(706, 451);
            this.Imprimir.Name = "Imprimir";
            this.helpProvider1.SetShowHelp(this.Imprimir, true);
            this.Imprimir.Size = new System.Drawing.Size(75, 23);
            this.Imprimir.TabIndex = 17;
            this.Imprimir.Text = "Imprimir";
            this.Imprimir.UseVisualStyleBackColor = true;
            this.Imprimir.Click += new System.EventHandler(this.Imprimir_Click);
            // 
            // btnConfigurar
            // 
            this.btnConfigurar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfigurar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.btnConfigurar, "");
            this.helpProvider1.SetHelpString(this.btnConfigurar, "Alteração de cores de cada componente do processo.");
            this.btnConfigurar.Location = new System.Drawing.Point(787, 451);
            this.btnConfigurar.Name = "btnConfigurar";
            this.helpProvider1.SetShowHelp(this.btnConfigurar, true);
            this.btnConfigurar.Size = new System.Drawing.Size(75, 23);
            this.btnConfigurar.TabIndex = 18;
            this.btnConfigurar.Text = "Configurar";
            this.btnConfigurar.UseVisualStyleBackColor = true;
            this.btnConfigurar.Click += new System.EventHandler(this.Cores_Click);
            // 
            // Sair
            // 
            this.Sair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Sair.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.Sair, "");
            this.helpProvider1.SetHelpString(this.Sair, "Função sair, não salva alterações.");
            this.Sair.Location = new System.Drawing.Point(787, 480);
            this.Sair.Name = "Sair";
            this.helpProvider1.SetShowHelp(this.Sair, true);
            this.Sair.Size = new System.Drawing.Size(75, 23);
            this.Sair.TabIndex = 20;
            this.Sair.Text = "Sair";
            this.Sair.UseVisualStyleBackColor = true;
            this.Sair.Click += new System.EventHandler(this.Sair_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblProdutos);
            this.panel2.Controls.Add(this.Operador);
            this.panel2.Controls.Add(this.Responsavel);
            this.panel2.Controls.Add(this.Descricao);
            this.panel2.Controls.Add(this.tempoTrat);
            this.panel2.Controls.Add(this.DadosTrat);
            this.panel2.Controls.Add(this.Datas);
            this.panel2.Controls.Add(this.Controlador);
            this.panel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(12, 431);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(688, 71);
            this.panel2.TabIndex = 21;
            // 
            // lblProdutos
            // 
            this.lblProdutos.AutoSize = true;
            this.lblProdutos.Location = new System.Drawing.Point(7, 45);
            this.lblProdutos.Name = "lblProdutos";
            this.lblProdutos.Size = new System.Drawing.Size(35, 14);
            this.lblProdutos.TabIndex = 29;
            this.lblProdutos.Text = "label1";
            // 
            // Operador
            // 
            this.Operador.AutoSize = true;
            this.Operador.Location = new System.Drawing.Point(326, 45);
            this.Operador.Name = "Operador";
            this.Operador.Size = new System.Drawing.Size(35, 14);
            this.Operador.TabIndex = 27;
            this.Operador.Text = "label1";
            // 
            // Responsavel
            // 
            this.Responsavel.AutoSize = true;
            this.Responsavel.Location = new System.Drawing.Point(326, 32);
            this.Responsavel.Name = "Responsavel";
            this.Responsavel.Size = new System.Drawing.Size(35, 14);
            this.Responsavel.TabIndex = 25;
            this.Responsavel.Text = "label1";
            // 
            // Descricao
            // 
            this.Descricao.AutoSize = true;
            this.Descricao.Location = new System.Drawing.Point(326, 19);
            this.Descricao.Name = "Descricao";
            this.Descricao.Size = new System.Drawing.Size(35, 14);
            this.Descricao.TabIndex = 23;
            this.Descricao.Text = "label1";
            // 
            // tempoTrat
            // 
            this.tempoTrat.AutoSize = true;
            this.tempoTrat.Location = new System.Drawing.Point(326, 6);
            this.tempoTrat.Name = "tempoTrat";
            this.tempoTrat.Size = new System.Drawing.Size(35, 14);
            this.tempoTrat.TabIndex = 28;
            this.tempoTrat.Text = "label1";
            // 
            // DadosTrat
            // 
            this.DadosTrat.AutoSize = true;
            this.DadosTrat.Location = new System.Drawing.Point(7, 32);
            this.DadosTrat.Name = "DadosTrat";
            this.DadosTrat.Size = new System.Drawing.Size(35, 14);
            this.DadosTrat.TabIndex = 26;
            this.DadosTrat.Text = "label1";
            // 
            // Datas
            // 
            this.Datas.AutoSize = true;
            this.Datas.Location = new System.Drawing.Point(7, 19);
            this.Datas.Name = "Datas";
            this.Datas.Size = new System.Drawing.Size(35, 14);
            this.Datas.TabIndex = 24;
            this.Datas.Text = "label1";
            // 
            // Controlador
            // 
            this.Controlador.AutoSize = true;
            this.Controlador.Location = new System.Drawing.Point(7, 6);
            this.Controlador.Name = "Controlador";
            this.Controlador.Size = new System.Drawing.Size(35, 14);
            this.Controlador.TabIndex = 22;
            this.Controlador.Text = "label1";
            // 
            // Produtos
            // 
            this.Produtos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Produtos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpString(this.Produtos, "Empresa e produtos da empresa.");
            this.Produtos.Location = new System.Drawing.Point(706, 480);
            this.Produtos.Name = "Produtos";
            this.helpProvider1.SetShowHelp(this.Produtos, true);
            this.Produtos.Size = new System.Drawing.Size(75, 23);
            this.Produtos.TabIndex = 19;
            this.Produtos.Text = "Produtos";
            this.Produtos.UseVisualStyleBackColor = true;
            this.Produtos.Click += new System.EventHandler(this.Produtos_Click);
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Controls.Add(this.btnGR);
            this.pnlBotoes.Controls.Add(this.chkT1);
            this.pnlBotoes.Controls.Add(this.btnT1);
            this.pnlBotoes.Controls.Add(this.chkT2);
            this.pnlBotoes.Controls.Add(this.btnT2);
            this.pnlBotoes.Controls.Add(this.chkT3);
            this.pnlBotoes.Controls.Add(this.btnT3);
            this.pnlBotoes.Controls.Add(this.chkT4);
            this.pnlBotoes.Controls.Add(this.btnT4);
            this.pnlBotoes.Controls.Add(this.btnCA);
            this.pnlBotoes.Controls.Add(this.chkCA);
            this.pnlBotoes.Location = new System.Drawing.Point(12, 407);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(362, 23);
            this.pnlBotoes.TabIndex = 1;
            // 
            // txtHorario
            // 
            this.txtHorario.Enabled = false;
            this.txtHorario.Location = new System.Drawing.Point(503, 409);
            this.txtHorario.Name = "txtHorario";
            this.txtHorario.Size = new System.Drawing.Size(41, 20);
            this.txtHorario.TabIndex = 14;
            this.txtHorario.Text = "23:55";
            // 
            // txtValor
            // 
            this.txtValor.Enabled = false;
            this.txtValor.Location = new System.Drawing.Point(459, 409);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(38, 20);
            this.txtValor.TabIndex = 13;
            this.txtValor.Text = "99ºC";
            // 
            // txtNL
            // 
            this.txtNL.Enabled = false;
            this.txtNL.Location = new System.Drawing.Point(394, 409);
            this.txtNL.Name = "txtNL";
            this.txtNL.Size = new System.Drawing.Size(59, 20);
            this.txtNL.TabIndex = 12;
            this.txtNL.Text = "NLT = 999";
            // 
            // SalvaGrafico
            // 
            this.SalvaGrafico.Location = new System.Drawing.Point(821, 407);
            this.SalvaGrafico.Name = "SalvaGrafico";
            this.SalvaGrafico.Size = new System.Drawing.Size(41, 15);
            this.SalvaGrafico.TabIndex = 31;
            this.SalvaGrafico.Text = "Salva";
            this.SalvaGrafico.UseVisualStyleBackColor = true;
            this.SalvaGrafico.Visible = false;
            this.SalvaGrafico.Click += new System.EventHandler(this.SalvaGrafico_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpKeyword(this.button1, "");
            this.helpProvider1.SetHelpString(this.button1, "Pode exportar o gráfico em arquivo com extensão .PNG.");
            this.button1.Location = new System.Drawing.Point(550, 407);
            this.button1.Name = "button1";
            this.helpProvider1.SetShowHelp(this.button1, true);
            this.button1.Size = new System.Drawing.Size(62, 24);
            this.button1.TabIndex = 32;
            this.button1.Text = "Exportar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Grafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(872, 509);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SalvaGrafico);
            this.Controls.Add(this.txtHorario);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.txtNL);
            this.Controls.Add(this.Produtos);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Sair);
            this.Controls.Add(this.btnConfigurar);
            this.Controls.Add(this.Imprimir);
            this.Controls.Add(this.TipoGrafico);
            this.Controls.Add(this.Desmarca);
            this.Controls.Add(this.panel1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Grafico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gráfico do Ciclo";
            this.Load += new System.EventHandler(this.Grafico_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnT1;
        private System.Windows.Forms.CheckBox chkT1;
        private System.Windows.Forms.Button btnT2;
        private System.Windows.Forms.CheckBox chkT2;
        private System.Windows.Forms.Button btnT3;
        private System.Windows.Forms.CheckBox chkT3;
        private System.Windows.Forms.Button btnT4;
        private System.Windows.Forms.CheckBox chkT4;
        private System.Windows.Forms.Button btnCA;
        private System.Windows.Forms.CheckBox chkCA;
        private System.Windows.Forms.Button btnGR;
        private System.Windows.Forms.Button Desmarca;
        private System.Windows.Forms.Button TipoGrafico;
        private System.Windows.Forms.Button Imprimir;
        private System.Windows.Forms.Button btnConfigurar;
        private System.Windows.Forms.Button Sair;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Operador;
        private System.Windows.Forms.Label Responsavel;
        private System.Windows.Forms.Label Descricao;
        private System.Windows.Forms.Label tempoTrat;
        private System.Windows.Forms.Label DadosTrat;
        private System.Windows.Forms.Label Datas;
        private System.Windows.Forms.Label Controlador;
        private System.Windows.Forms.Button Produtos;
        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.TextBox txtHorario;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtNL;
        public System.Windows.Forms.Button SalvaGrafico;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblProdutos;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}