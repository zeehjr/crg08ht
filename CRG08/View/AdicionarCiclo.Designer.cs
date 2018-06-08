namespace CRG08.View
{
    partial class AdicionarCiclo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdicionarCiclo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgProdutos = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colProduto = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidade = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colEmpresa = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGerenciarUnidades = new System.Windows.Forms.Button();
            this.btnGerenciarEmpresas = new System.Windows.Forms.Button();
            this.btnGerenciarProdutos = new System.Windows.Forms.Button();
            this.btnNovoProduto = new System.Windows.Forms.Button();
            this.btnExcluirProduto = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumCRG = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRespTecnico = new System.Windows.Forms.TextBox();
            this.txtOperador = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnReceber = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblInfoAparelho = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblInfoTratamento = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPeriodoCiclo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblStatusProdutos = new System.Windows.Forms.Label();
            this.lblStatusProdutosMoreInfo = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProdutos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgProdutos
            // 
            this.dtgProdutos.AllowUserToAddRows = false;
            this.dtgProdutos.AllowUserToDeleteRows = false;
            this.dtgProdutos.BackgroundColor = System.Drawing.Color.White;
            this.dtgProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.colProduto,
            this.colVolume,
            this.colUnidade,
            this.colEmpresa});
            this.dtgProdutos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.helpProvider1.SetHelpString(this.dtgProdutos, resources.GetString("dtgProdutos.HelpString"));
            resources.ApplyResources(this.dtgProdutos, "dtgProdutos");
            this.dtgProdutos.Name = "dtgProdutos";
            this.dtgProdutos.RowHeadersVisible = false;
            this.dtgProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.helpProvider1.SetShowHelp(this.dtgProdutos, ((bool)(resources.GetObject("dtgProdutos.ShowHelp"))));
            this.dtgProdutos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgProdutos_CellEndEdit);
            this.dtgProdutos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgProdutos_EditingControlShowing);
            // 
            // Select
            // 
            resources.ApplyResources(this.Select, "Select");
            this.Select.Name = "Select";
            // 
            // colProduto
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.colProduto.DefaultCellStyle = dataGridViewCellStyle1;
            this.colProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(this.colProduto, "colProduto");
            this.colProduto.MaxDropDownItems = 100;
            this.colProduto.Name = "colProduto";
            // 
            // colVolume
            // 
            resources.ApplyResources(this.colVolume, "colVolume");
            this.colVolume.Name = "colVolume";
            // 
            // colUnidade
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colUnidade.DefaultCellStyle = dataGridViewCellStyle2;
            this.colUnidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(this.colUnidade, "colUnidade");
            this.colUnidade.Name = "colUnidade";
            // 
            // colEmpresa
            // 
            this.colEmpresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.colEmpresa.DefaultCellStyle = dataGridViewCellStyle3;
            this.colEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(this.colEmpresa, "colEmpresa");
            this.colEmpresa.Name = "colEmpresa";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGerenciarUnidades);
            this.groupBox2.Controls.Add(this.btnGerenciarEmpresas);
            this.groupBox2.Controls.Add(this.btnGerenciarProdutos);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnGerenciarUnidades
            // 
            resources.ApplyResources(this.btnGerenciarUnidades, "btnGerenciarUnidades");
            this.helpProvider1.SetHelpKeyword(this.btnGerenciarUnidades, resources.GetString("btnGerenciarUnidades.HelpKeyword"));
            this.helpProvider1.SetHelpString(this.btnGerenciarUnidades, resources.GetString("btnGerenciarUnidades.HelpString"));
            this.btnGerenciarUnidades.Name = "btnGerenciarUnidades";
            this.helpProvider1.SetShowHelp(this.btnGerenciarUnidades, ((bool)(resources.GetObject("btnGerenciarUnidades.ShowHelp"))));
            this.btnGerenciarUnidades.UseVisualStyleBackColor = true;
            this.btnGerenciarUnidades.Click += new System.EventHandler(this.btnGerenciarUnidades_Click);
            // 
            // btnGerenciarEmpresas
            // 
            resources.ApplyResources(this.btnGerenciarEmpresas, "btnGerenciarEmpresas");
            this.helpProvider1.SetHelpKeyword(this.btnGerenciarEmpresas, resources.GetString("btnGerenciarEmpresas.HelpKeyword"));
            this.helpProvider1.SetHelpString(this.btnGerenciarEmpresas, resources.GetString("btnGerenciarEmpresas.HelpString"));
            this.btnGerenciarEmpresas.Name = "btnGerenciarEmpresas";
            this.helpProvider1.SetShowHelp(this.btnGerenciarEmpresas, ((bool)(resources.GetObject("btnGerenciarEmpresas.ShowHelp"))));
            this.btnGerenciarEmpresas.UseVisualStyleBackColor = true;
            this.btnGerenciarEmpresas.Click += new System.EventHandler(this.btnGerenciarEmpresas_Click);
            // 
            // btnGerenciarProdutos
            // 
            resources.ApplyResources(this.btnGerenciarProdutos, "btnGerenciarProdutos");
            this.helpProvider1.SetHelpKeyword(this.btnGerenciarProdutos, resources.GetString("btnGerenciarProdutos.HelpKeyword"));
            this.helpProvider1.SetHelpString(this.btnGerenciarProdutos, resources.GetString("btnGerenciarProdutos.HelpString"));
            this.btnGerenciarProdutos.Name = "btnGerenciarProdutos";
            this.helpProvider1.SetShowHelp(this.btnGerenciarProdutos, ((bool)(resources.GetObject("btnGerenciarProdutos.ShowHelp"))));
            this.btnGerenciarProdutos.UseVisualStyleBackColor = true;
            this.btnGerenciarProdutos.Click += new System.EventHandler(this.btnGerenciarProdutos_Click);
            // 
            // btnNovoProduto
            // 
            resources.ApplyResources(this.btnNovoProduto, "btnNovoProduto");
            this.helpProvider1.SetHelpKeyword(this.btnNovoProduto, resources.GetString("btnNovoProduto.HelpKeyword"));
            this.helpProvider1.SetHelpString(this.btnNovoProduto, resources.GetString("btnNovoProduto.HelpString"));
            this.btnNovoProduto.Name = "btnNovoProduto";
            this.helpProvider1.SetShowHelp(this.btnNovoProduto, ((bool)(resources.GetObject("btnNovoProduto.ShowHelp"))));
            this.btnNovoProduto.UseVisualStyleBackColor = true;
            this.btnNovoProduto.Click += new System.EventHandler(this.btnNovoProduto_Click);
            // 
            // btnExcluirProduto
            // 
            resources.ApplyResources(this.btnExcluirProduto, "btnExcluirProduto");
            this.helpProvider1.SetHelpKeyword(this.btnExcluirProduto, resources.GetString("btnExcluirProduto.HelpKeyword"));
            this.helpProvider1.SetHelpString(this.btnExcluirProduto, resources.GetString("btnExcluirProduto.HelpString"));
            this.btnExcluirProduto.Name = "btnExcluirProduto";
            this.helpProvider1.SetShowHelp(this.btnExcluirProduto, ((bool)(resources.GetObject("btnExcluirProduto.ShowHelp"))));
            this.btnExcluirProduto.UseVisualStyleBackColor = true;
            this.btnExcluirProduto.Click += new System.EventHandler(this.btnExcluirProduto_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.helpProvider1.SetHelpString(this.label3, resources.GetString("label3.HelpString"));
            this.label3.Name = "label3";
            this.helpProvider1.SetShowHelp(this.label3, ((bool)(resources.GetObject("label3.ShowHelp"))));
            // 
            // lblNumCRG
            // 
            resources.ApplyResources(this.lblNumCRG, "lblNumCRG");
            this.helpProvider1.SetHelpKeyword(this.lblNumCRG, resources.GetString("lblNumCRG.HelpKeyword"));
            this.helpProvider1.SetHelpString(this.lblNumCRG, resources.GetString("lblNumCRG.HelpString"));
            this.lblNumCRG.Name = "lblNumCRG";
            this.helpProvider1.SetShowHelp(this.lblNumCRG, ((bool)(resources.GetObject("lblNumCRG.ShowHelp"))));
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.helpProvider1.SetHelpKeyword(this.label5, resources.GetString("label5.HelpKeyword"));
            this.helpProvider1.SetHelpString(this.label5, resources.GetString("label5.HelpString"));
            this.label5.Name = "label5";
            this.helpProvider1.SetShowHelp(this.label5, ((bool)(resources.GetObject("label5.ShowHelp"))));
            // 
            // txtDescricao
            // 
            this.helpProvider1.SetHelpKeyword(this.txtDescricao, resources.GetString("txtDescricao.HelpKeyword"));
            this.helpProvider1.SetHelpString(this.txtDescricao, resources.GetString("txtDescricao.HelpString"));
            resources.ApplyResources(this.txtDescricao, "txtDescricao");
            this.txtDescricao.Name = "txtDescricao";
            this.helpProvider1.SetShowHelp(this.txtDescricao, ((bool)(resources.GetObject("txtDescricao.ShowHelp"))));
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.helpProvider1.SetHelpKeyword(this.label6, resources.GetString("label6.HelpKeyword"));
            this.helpProvider1.SetHelpString(this.label6, resources.GetString("label6.HelpString"));
            this.label6.Name = "label6";
            this.helpProvider1.SetShowHelp(this.label6, ((bool)(resources.GetObject("label6.ShowHelp"))));
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.helpProvider1.SetHelpKeyword(this.label7, resources.GetString("label7.HelpKeyword"));
            this.helpProvider1.SetHelpString(this.label7, resources.GetString("label7.HelpString"));
            this.label7.Name = "label7";
            this.helpProvider1.SetShowHelp(this.label7, ((bool)(resources.GetObject("label7.ShowHelp"))));
            // 
            // txtRespTecnico
            // 
            this.helpProvider1.SetHelpKeyword(this.txtRespTecnico, resources.GetString("txtRespTecnico.HelpKeyword"));
            this.helpProvider1.SetHelpString(this.txtRespTecnico, resources.GetString("txtRespTecnico.HelpString"));
            resources.ApplyResources(this.txtRespTecnico, "txtRespTecnico");
            this.txtRespTecnico.Name = "txtRespTecnico";
            this.helpProvider1.SetShowHelp(this.txtRespTecnico, ((bool)(resources.GetObject("txtRespTecnico.ShowHelp"))));
            // 
            // txtOperador
            // 
            this.helpProvider1.SetHelpKeyword(this.txtOperador, resources.GetString("txtOperador.HelpKeyword"));
            this.helpProvider1.SetHelpString(this.txtOperador, resources.GetString("txtOperador.HelpString"));
            resources.ApplyResources(this.txtOperador, "txtOperador");
            this.txtOperador.Name = "txtOperador";
            this.helpProvider1.SetShowHelp(this.txtOperador, ((bool)(resources.GetObject("txtOperador.ShowHelp"))));
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // btnCancelar
            // 
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.helpProvider1.SetHelpKeyword(this.btnCancelar, resources.GetString("btnCancelar.HelpKeyword"));
            this.helpProvider1.SetHelpString(this.btnCancelar, resources.GetString("btnCancelar.HelpString"));
            this.btnCancelar.Name = "btnCancelar";
            this.helpProvider1.SetShowHelp(this.btnCancelar, ((bool)(resources.GetObject("btnCancelar.ShowHelp"))));
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnReceber
            // 
            resources.ApplyResources(this.btnReceber, "btnReceber");
            this.helpProvider1.SetHelpKeyword(this.btnReceber, resources.GetString("btnReceber.HelpKeyword"));
            this.helpProvider1.SetHelpString(this.btnReceber, resources.GetString("btnReceber.HelpString"));
            this.btnReceber.Name = "btnReceber";
            this.helpProvider1.SetShowHelp(this.btnReceber, ((bool)(resources.GetObject("btnReceber.ShowHelp"))));
            this.btnReceber.UseVisualStyleBackColor = true;
            this.btnReceber.Click += new System.EventHandler(this.btnReceber_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblInfoAparelho);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.lblInfoTratamento);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lblPeriodoCiclo);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lblTitulo);
            this.panel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.helpProvider1.SetHelpString(this.panel3, resources.GetString("panel3.HelpString"));
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            this.helpProvider1.SetShowHelp(this.panel3, ((bool)(resources.GetObject("panel3.ShowHelp"))));
            // 
            // lblInfoAparelho
            // 
            resources.ApplyResources(this.lblInfoAparelho, "lblInfoAparelho");
            this.lblInfoAparelho.ForeColor = System.Drawing.Color.White;
            this.helpProvider1.SetHelpKeyword(this.lblInfoAparelho, resources.GetString("lblInfoAparelho.HelpKeyword"));
            this.lblInfoAparelho.Name = "lblInfoAparelho";
            this.helpProvider1.SetShowHelp(this.lblInfoAparelho, ((bool)(resources.GetObject("lblInfoAparelho.ShowHelp"))));
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.White;
            this.helpProvider1.SetHelpKeyword(this.label8, resources.GetString("label8.HelpKeyword"));
            this.label8.Name = "label8";
            this.helpProvider1.SetShowHelp(this.label8, ((bool)(resources.GetObject("label8.ShowHelp"))));
            // 
            // lblInfoTratamento
            // 
            resources.ApplyResources(this.lblInfoTratamento, "lblInfoTratamento");
            this.lblInfoTratamento.ForeColor = System.Drawing.Color.White;
            this.helpProvider1.SetHelpKeyword(this.lblInfoTratamento, resources.GetString("lblInfoTratamento.HelpKeyword"));
            this.lblInfoTratamento.Name = "lblInfoTratamento";
            this.helpProvider1.SetShowHelp(this.lblInfoTratamento, ((bool)(resources.GetObject("lblInfoTratamento.ShowHelp"))));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.helpProvider1.SetHelpKeyword(this.label1, resources.GetString("label1.HelpKeyword"));
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            // 
            // lblPeriodoCiclo
            // 
            resources.ApplyResources(this.lblPeriodoCiclo, "lblPeriodoCiclo");
            this.lblPeriodoCiclo.ForeColor = System.Drawing.Color.White;
            this.helpProvider1.SetHelpKeyword(this.lblPeriodoCiclo, resources.GetString("lblPeriodoCiclo.HelpKeyword"));
            this.lblPeriodoCiclo.Name = "lblPeriodoCiclo";
            this.helpProvider1.SetShowHelp(this.lblPeriodoCiclo, ((bool)(resources.GetObject("lblPeriodoCiclo.ShowHelp"))));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.helpProvider1.SetHelpKeyword(this.label2, resources.GetString("label2.HelpKeyword"));
            this.label2.Name = "label2";
            this.helpProvider1.SetShowHelp(this.label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
            // 
            // lblTitulo
            // 
            resources.ApplyResources(this.lblTitulo, "lblTitulo");
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.helpProvider1.SetHelpKeyword(this.lblTitulo, resources.GetString("lblTitulo.HelpKeyword"));
            this.lblTitulo.Name = "lblTitulo";
            this.helpProvider1.SetShowHelp(this.lblTitulo, ((bool)(resources.GetObject("lblTitulo.ShowHelp"))));
            this.lblTitulo.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblStatusProdutos
            // 
            resources.ApplyResources(this.lblStatusProdutos, "lblStatusProdutos");
            this.lblStatusProdutos.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStatusProdutos.Name = "lblStatusProdutos";
            // 
            // lblStatusProdutosMoreInfo
            // 
            resources.ApplyResources(this.lblStatusProdutosMoreInfo, "lblStatusProdutosMoreInfo");
            this.lblStatusProdutosMoreInfo.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStatusProdutosMoreInfo.Name = "lblStatusProdutosMoreInfo";
            // 
            // AdicionarCiclo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblStatusProdutosMoreInfo);
            this.Controls.Add(this.lblStatusProdutos);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnReceber);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtOperador);
            this.Controls.Add(this.txtRespTecnico);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblNumCRG);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExcluirProduto);
            this.Controls.Add(this.btnNovoProduto);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dtgProdutos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdicionarCiclo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdicionarCiclo_FormClosing);
            this.Load += new System.EventHandler(this.AdicionarCiclo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProdutos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgProdutos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGerenciarEmpresas;
        private System.Windows.Forms.Button btnGerenciarProdutos;
        private System.Windows.Forms.Button btnNovoProduto;
        private System.Windows.Forms.Button btnExcluirProduto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNumCRG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRespTecnico;
        private System.Windows.Forms.TextBox txtOperador;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnReceber;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPeriodoCiclo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInfoAparelho;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblInfoTratamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGerenciarUnidades;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewComboBoxColumn colProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVolume;
        private System.Windows.Forms.DataGridViewComboBoxColumn colUnidade;
        private System.Windows.Forms.DataGridViewComboBoxColumn colEmpresa;
        private System.Windows.Forms.Label lblStatusProdutos;
        private System.Windows.Forms.Label lblStatusProdutosMoreInfo;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}