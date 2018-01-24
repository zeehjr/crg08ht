namespace CRG08.View
{
    partial class OpcoesImpressao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpcoesImpressao));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbEmpresas = new System.Windows.Forms.ComboBox();
            this.Individual = new System.Windows.Forms.RadioButton();
            this.Todos = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLinhasDepois = new System.Windows.Forms.NumericUpDown();
            this.txtLinhasTratamento = new System.Windows.Forms.NumericUpDown();
            this.txtLinhasAntes = new System.Windows.Forms.NumericUpDown();
            this.lblPadraoDepoisTrat = new System.Windows.Forms.LinkLabel();
            this.lblPadraoTrat = new System.Windows.Forms.LinkLabel();
            this.lblPadraoAntesTrat = new System.Windows.Forms.LinkLabel();
            this.lblLinhasDepois = new System.Windows.Forms.Label();
            this.lblLinhasTratamento = new System.Windows.Forms.Label();
            this.lblQtdLinhasAntes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Geral = new System.Windows.Forms.RadioButton();
            this.Tratamento = new System.Windows.Forms.RadioButton();
            this.Continuar = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinhasDepois)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinhasTratamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinhasAntes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbEmpresas);
            this.groupBox1.Controls.Add(this.Individual);
            this.groupBox1.Controls.Add(this.Todos);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Produto(s)";
            // 
            // cmbEmpresas
            // 
            this.cmbEmpresas.Enabled = false;
            this.cmbEmpresas.FormattingEnabled = true;
            this.helpProvider1.SetHelpKeyword(this.cmbEmpresas, "");
            this.helpProvider1.SetHelpString(this.cmbEmpresas, "Seleciona somente produtos listados da empresa.");
            this.cmbEmpresas.Location = new System.Drawing.Point(23, 61);
            this.cmbEmpresas.Name = "cmbEmpresas";
            this.helpProvider1.SetShowHelp(this.cmbEmpresas, true);
            this.cmbEmpresas.Size = new System.Drawing.Size(121, 22);
            this.cmbEmpresas.TabIndex = 3;
            // 
            // Individual
            // 
            this.Individual.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.Individual, "");
            this.helpProvider1.SetHelpString(this.Individual, "Seleciona somente produtos listados da empresa.");
            this.Individual.Location = new System.Drawing.Point(6, 42);
            this.Individual.Name = "Individual";
            this.helpProvider1.SetShowHelp(this.Individual, true);
            this.Individual.Size = new System.Drawing.Size(214, 18);
            this.Individual.TabIndex = 2;
            this.Individual.Text = "Imprimir somente produtos da empresa:";
            this.Individual.UseVisualStyleBackColor = true;
            this.Individual.CheckedChanged += new System.EventHandler(this.Individual_CheckedChanged);
            // 
            // Todos
            // 
            this.Todos.AutoSize = true;
            this.Todos.Checked = true;
            this.helpProvider1.SetHelpKeyword(this.Todos, "");
            this.helpProvider1.SetHelpString(this.Todos, "Seleciona todos os produtos.");
            this.Todos.Location = new System.Drawing.Point(6, 19);
            this.Todos.Name = "Todos";
            this.helpProvider1.SetShowHelp(this.Todos, true);
            this.Todos.Size = new System.Drawing.Size(152, 18);
            this.Todos.TabIndex = 1;
            this.Todos.TabStop = true;
            this.Todos.Text = "Imprimir todos os produtos";
            this.Todos.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLinhasDepois);
            this.groupBox2.Controls.Add(this.txtLinhasTratamento);
            this.groupBox2.Controls.Add(this.txtLinhasAntes);
            this.groupBox2.Controls.Add(this.lblPadraoDepoisTrat);
            this.groupBox2.Controls.Add(this.lblPadraoTrat);
            this.groupBox2.Controls.Add(this.lblPadraoAntesTrat);
            this.groupBox2.Controls.Add(this.lblLinhasDepois);
            this.groupBox2.Controls.Add(this.lblLinhasTratamento);
            this.groupBox2.Controls.Add(this.lblQtdLinhasAntes);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtFiltro);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Geral);
            this.groupBox2.Controls.Add(this.Tratamento);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 196);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Itens a serem impressos";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtLinhasDepois
            // 
            this.helpProvider1.SetHelpKeyword(this.txtLinhasDepois, "");
            this.helpProvider1.SetHelpString(this.txtLinhasDepois, "Número de Leituras após o tratamento.");
            this.txtLinhasDepois.Location = new System.Drawing.Point(157, 158);
            this.txtLinhasDepois.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtLinhasDepois.Name = "txtLinhasDepois";
            this.helpProvider1.SetShowHelp(this.txtLinhasDepois, true);
            this.txtLinhasDepois.Size = new System.Drawing.Size(34, 20);
            this.txtLinhasDepois.TabIndex = 14;
            this.txtLinhasDepois.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // txtLinhasTratamento
            // 
            this.helpProvider1.SetHelpKeyword(this.txtLinhasTratamento, "");
            this.helpProvider1.SetHelpString(this.txtLinhasTratamento, "Número de leituras do tratamento.");
            this.txtLinhasTratamento.Location = new System.Drawing.Point(157, 132);
            this.txtLinhasTratamento.Name = "txtLinhasTratamento";
            this.helpProvider1.SetShowHelp(this.txtLinhasTratamento, true);
            this.txtLinhasTratamento.Size = new System.Drawing.Size(34, 20);
            this.txtLinhasTratamento.TabIndex = 13;
            this.txtLinhasTratamento.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // txtLinhasAntes
            // 
            this.helpProvider1.SetHelpKeyword(this.txtLinhasAntes, "");
            this.helpProvider1.SetHelpString(this.txtLinhasAntes, "Numero de leituras que antecede o tratamento.");
            this.txtLinhasAntes.Location = new System.Drawing.Point(157, 106);
            this.txtLinhasAntes.Name = "txtLinhasAntes";
            this.helpProvider1.SetShowHelp(this.txtLinhasAntes, true);
            this.txtLinhasAntes.Size = new System.Drawing.Size(34, 20);
            this.txtLinhasAntes.TabIndex = 10;
            this.txtLinhasAntes.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtLinhasAntes.ValueChanged += new System.EventHandler(this.txtLinhasAntes_ValueChanged);
            // 
            // lblPadraoDepoisTrat
            // 
            this.lblPadraoDepoisTrat.ActiveLinkColor = System.Drawing.Color.Gray;
            this.lblPadraoDepoisTrat.AutoSize = true;
            this.lblPadraoDepoisTrat.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPadraoDepoisTrat.LinkColor = System.Drawing.Color.Black;
            this.lblPadraoDepoisTrat.Location = new System.Drawing.Point(192, 160);
            this.lblPadraoDepoisTrat.Name = "lblPadraoDepoisTrat";
            this.lblPadraoDepoisTrat.Size = new System.Drawing.Size(45, 14);
            this.lblPadraoDepoisTrat.TabIndex = 12;
            this.lblPadraoDepoisTrat.TabStop = true;
            this.lblPadraoDepoisTrat.Text = "Padrão";
            this.toolTip.SetToolTip(this.lblPadraoDepoisTrat, "Reseta o valor padrão para quantidade de linhas depois do tratamento.");
            this.lblPadraoDepoisTrat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPadraoDepoisTrat_LinkClicked);
            // 
            // lblPadraoTrat
            // 
            this.lblPadraoTrat.ActiveLinkColor = System.Drawing.Color.Gray;
            this.lblPadraoTrat.AutoSize = true;
            this.lblPadraoTrat.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPadraoTrat.LinkColor = System.Drawing.Color.Black;
            this.lblPadraoTrat.Location = new System.Drawing.Point(192, 134);
            this.lblPadraoTrat.Name = "lblPadraoTrat";
            this.lblPadraoTrat.Size = new System.Drawing.Size(45, 14);
            this.lblPadraoTrat.TabIndex = 11;
            this.lblPadraoTrat.TabStop = true;
            this.lblPadraoTrat.Text = "Padrão";
            this.toolTip.SetToolTip(this.lblPadraoTrat, "Reseta o valor padrão para quantidade de linhas do tratamento.");
            this.lblPadraoTrat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPadraoTrat_LinkClicked);
            // 
            // lblPadraoAntesTrat
            // 
            this.lblPadraoAntesTrat.ActiveLinkColor = System.Drawing.Color.Gray;
            this.lblPadraoAntesTrat.AutoSize = true;
            this.lblPadraoAntesTrat.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPadraoAntesTrat.LinkColor = System.Drawing.Color.Black;
            this.lblPadraoAntesTrat.Location = new System.Drawing.Point(192, 108);
            this.lblPadraoAntesTrat.Name = "lblPadraoAntesTrat";
            this.lblPadraoAntesTrat.Size = new System.Drawing.Size(45, 14);
            this.lblPadraoAntesTrat.TabIndex = 10;
            this.lblPadraoAntesTrat.TabStop = true;
            this.lblPadraoAntesTrat.Text = "Padrão";
            this.toolTip.SetToolTip(this.lblPadraoAntesTrat, "Reseta o valor padrão para quantidade de linhas antes do tratamento.");
            this.lblPadraoAntesTrat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPadraoAntesTrat_LinkClicked);
            // 
            // lblLinhasDepois
            // 
            this.lblLinhasDepois.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.lblLinhasDepois, "");
            this.helpProvider1.SetHelpString(this.lblLinhasDepois, "Número de Leituras após o tratamento.");
            this.lblLinhasDepois.Location = new System.Drawing.Point(6, 160);
            this.lblLinhasDepois.Name = "lblLinhasDepois";
            this.helpProvider1.SetShowHelp(this.lblLinhasDepois, true);
            this.lblLinhasDepois.Size = new System.Drawing.Size(146, 14);
            this.lblLinhasDepois.TabIndex = 10;
            this.lblLinhasDepois.Text = "Linhas depois do tratamento:";
            // 
            // lblLinhasTratamento
            // 
            this.lblLinhasTratamento.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.lblLinhasTratamento, "");
            this.helpProvider1.SetHelpString(this.lblLinhasTratamento, "Número de leituras do tratamento.");
            this.lblLinhasTratamento.Location = new System.Drawing.Point(6, 134);
            this.lblLinhasTratamento.Name = "lblLinhasTratamento";
            this.helpProvider1.SetShowHelp(this.lblLinhasTratamento, true);
            this.lblLinhasTratamento.Size = new System.Drawing.Size(111, 14);
            this.lblLinhasTratamento.TabIndex = 10;
            this.lblLinhasTratamento.Text = "Linhas do tratamento:";
            // 
            // lblQtdLinhasAntes
            // 
            this.lblQtdLinhasAntes.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.lblQtdLinhasAntes, "");
            this.helpProvider1.SetHelpString(this.lblQtdLinhasAntes, "Numero de leituras que antecede o tratamento.");
            this.lblQtdLinhasAntes.Location = new System.Drawing.Point(6, 108);
            this.lblQtdLinhasAntes.Name = "lblQtdLinhasAntes";
            this.helpProvider1.SetShowHelp(this.lblQtdLinhasAntes, true);
            this.lblQtdLinhasAntes.Size = new System.Drawing.Size(141, 14);
            this.lblQtdLinhasAntes.TabIndex = 10;
            this.lblQtdLinhasAntes.Text = "Linhas antes do tratamento:";
            this.lblQtdLinhasAntes.Click += new System.EventHandler(this.lblQtdLinhasAntes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(116, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ex: 1-10 ou 1;2;3";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Enabled = false;
            this.helpProvider1.SetHelpKeyword(this.txtFiltro, "");
            this.helpProvider1.SetHelpString(this.txtFiltro, "Habilitado somente se geral estiver escolhido, pode-se escolher os numeros das le" +
        "ituras do ciclo.");
            this.txtFiltro.Location = new System.Drawing.Point(119, 59);
            this.txtFiltro.Name = "txtFiltro";
            this.helpProvider1.SetShowHelp(this.txtFiltro, true);
            this.txtFiltro.Size = new System.Drawing.Size(100, 20);
            this.txtFiltro.TabIndex = 6;
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            this.txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltro_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.label1, "");
            this.helpProvider1.SetHelpString(this.label1, "Habilitado somente se geral estiver escolhido, pode-se escolher os numeros das le" +
        "ituras do ciclo.");
            this.label1.Location = new System.Drawing.Point(3, 62);
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, true);
            this.label1.Size = new System.Drawing.Size(116, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filtrar leituras do Ciclo:";
            // 
            // Geral
            // 
            this.Geral.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.Geral, "");
            this.helpProvider1.SetHelpString(this.Geral, "Será impresso a tabela do ciclo e do tratamento.");
            this.Geral.Location = new System.Drawing.Point(6, 41);
            this.Geral.Name = "Geral";
            this.helpProvider1.SetShowHelp(this.Geral, true);
            this.Geral.Size = new System.Drawing.Size(51, 18);
            this.Geral.TabIndex = 5;
            this.Geral.Text = "Geral";
            this.Geral.UseVisualStyleBackColor = true;
            this.Geral.CheckedChanged += new System.EventHandler(this.Geral_CheckedChanged);
            // 
            // Tratamento
            // 
            this.Tratamento.AutoSize = true;
            this.Tratamento.Checked = true;
            this.helpProvider1.SetHelpKeyword(this.Tratamento, "");
            this.helpProvider1.SetHelpString(this.Tratamento, "Será impresso a tabela com as temperaturas e gráfico do tratamento.");
            this.Tratamento.Location = new System.Drawing.Point(6, 19);
            this.Tratamento.Name = "Tratamento";
            this.helpProvider1.SetShowHelp(this.Tratamento, true);
            this.Tratamento.Size = new System.Drawing.Size(79, 18);
            this.Tratamento.TabIndex = 4;
            this.Tratamento.TabStop = true;
            this.Tratamento.Text = "Tratamento";
            this.Tratamento.UseVisualStyleBackColor = true;
            this.Tratamento.CheckedChanged += new System.EventHandler(this.Tratamento_CheckedChanged);
            // 
            // Continuar
            // 
            this.Continuar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Continuar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.Continuar, "");
            this.helpProvider1.SetHelpString(this.Continuar, "Continua com o processo de impressão.");
            this.Continuar.Location = new System.Drawing.Point(116, 343);
            this.Continuar.Name = "Continuar";
            this.helpProvider1.SetShowHelp(this.Continuar, true);
            this.Continuar.Size = new System.Drawing.Size(75, 22);
            this.Continuar.TabIndex = 8;
            this.Continuar.Text = "Continuar";
            this.Continuar.UseVisualStyleBackColor = true;
            this.Continuar.Click += new System.EventHandler(this.Continuar_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cancelar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.Cancelar, "");
            this.helpProvider1.SetHelpString(this.Cancelar, "Cancela impressão, não salva alterações.");
            this.Cancelar.Location = new System.Drawing.Point(197, 343);
            this.Cancelar.Name = "Cancelar";
            this.helpProvider1.SetShowHelp(this.Cancelar, true);
            this.Cancelar.Size = new System.Drawing.Size(75, 22);
            this.Cancelar.TabIndex = 9;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.label3, "");
            this.helpProvider1.SetHelpString(this.label3, "Qualquer informação que o operador possa achar necessária para acrescentar.");
            this.label3.Location = new System.Drawing.Point(15, 318);
            this.label3.Name = "label3";
            this.helpProvider1.SetShowHelp(this.label3, true);
            this.label3.Size = new System.Drawing.Size(64, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Comentário:";
            // 
            // txtComentario
            // 
            this.txtComentario.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.txtComentario, "");
            this.helpProvider1.SetHelpString(this.txtComentario, "Qualquer informação que o operador possa achar necessária para acrescentar.");
            this.txtComentario.Location = new System.Drawing.Point(77, 315);
            this.txtComentario.Name = "txtComentario";
            this.helpProvider1.SetShowHelp(this.txtComentario, true);
            this.txtComentario.Size = new System.Drawing.Size(195, 20);
            this.txtComentario.TabIndex = 7;
            // 
            // toolTip
            // 
            this.toolTip.ToolTipTitle = "Resetar para o valor padrão";
            // 
            // OpcoesImpressao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(285, 374);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Continuar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpcoesImpressao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opções de Impressão";
            this.Load += new System.EventHandler(this.OpcoesImpressao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinhasDepois)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinhasTratamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinhasAntes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbEmpresas;
        private System.Windows.Forms.RadioButton Individual;
        private System.Windows.Forms.RadioButton Todos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton Geral;
        private System.Windows.Forms.RadioButton Tratamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Continuar;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label lblQtdLinhasAntes;
        private System.Windows.Forms.Label lblLinhasTratamento;
        private System.Windows.Forms.Label lblLinhasDepois;
        private System.Windows.Forms.LinkLabel lblPadraoDepoisTrat;
        private System.Windows.Forms.LinkLabel lblPadraoTrat;
        private System.Windows.Forms.LinkLabel lblPadraoAntesTrat;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.NumericUpDown txtLinhasDepois;
        private System.Windows.Forms.NumericUpDown txtLinhasTratamento;
        private System.Windows.Forms.NumericUpDown txtLinhasAntes;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}