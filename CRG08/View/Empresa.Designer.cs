namespace CRG08.View
{
    partial class Empresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Empresa));
            this.btnLimparEmpresa = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCnpj = new System.Windows.Forms.MaskedTextBox();
            this.txtFax = new System.Windows.Forms.MaskedTextBox();
            this.txtFone = new System.Windows.Forms.MaskedTextBox();
            this.txtCEP = new System.Windows.Forms.MaskedTextBox();
            this.chkLogoEmpresa = new System.Windows.Forms.CheckBox();
            this.cmbUF = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnImagem = new System.Windows.Forms.Button();
            this.lblQtdNumCredenciamento = new System.Windows.Forms.Label();
            this.lblQtdIE = new System.Windows.Forms.Label();
            this.lblQtdCnpj = new System.Windows.Forms.Label();
            this.lblQtdFax = new System.Windows.Forms.Label();
            this.lblQtdFone = new System.Windows.Forms.Label();
            this.lblQtdUF = new System.Windows.Forms.Label();
            this.lblQtdCidade = new System.Windows.Forms.Label();
            this.lblQtdCEP = new System.Windows.Forms.Label();
            this.lblQtdEndereco = new System.Windows.Forms.Label();
            this.lblQtdEmpresa = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.txtIE = new System.Windows.Forms.TextBox();
            this.txtNumCredenciamento = new System.Windows.Forms.TextBox();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.lblCEP = new System.Windows.Forms.Label();
            this.lblCidade = new System.Windows.Forms.Label();
            this.lblUF = new System.Windows.Forms.Label();
            this.lblFone = new System.Windows.Forms.Label();
            this.lblFax = new System.Windows.Forms.Label();
            this.lblCnpj = new System.Windows.Forms.Label();
            this.lblIE = new System.Windows.Forms.Label();
            this.lblNumCredenciamento = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.btnSalvarEmpresa = new System.Windows.Forms.Button();
            this.Sair = new System.Windows.Forms.Button();
            this.abrirArquivo = new System.Windows.Forms.OpenFileDialog();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimparEmpresa
            // 
            this.btnLimparEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.helpProvider1.SetHelpKeyword(this.btnLimparEmpresa, "");
            this.helpProvider1.SetHelpString(this.btnLimparEmpresa, "Limpa todos os dados e deixa o formulário em branco.");
            this.btnLimparEmpresa.Location = new System.Drawing.Point(305, 375);
            this.btnLimparEmpresa.Name = "btnLimparEmpresa";
            this.helpProvider1.SetShowHelp(this.btnLimparEmpresa, true);
            this.btnLimparEmpresa.Size = new System.Drawing.Size(75, 23);
            this.btnLimparEmpresa.TabIndex = 0;
            this.btnLimparEmpresa.Text = "Limpar";
            this.btnLimparEmpresa.UseVisualStyleBackColor = true;
            this.btnLimparEmpresa.Click += new System.EventHandler(this.btnLimparEmpresa_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCnpj);
            this.groupBox1.Controls.Add(this.txtFax);
            this.groupBox1.Controls.Add(this.txtFone);
            this.groupBox1.Controls.Add(this.txtCEP);
            this.groupBox1.Controls.Add(this.chkLogoEmpresa);
            this.groupBox1.Controls.Add(this.cmbUF);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.btnImagem);
            this.groupBox1.Controls.Add(this.lblQtdNumCredenciamento);
            this.groupBox1.Controls.Add(this.lblQtdIE);
            this.groupBox1.Controls.Add(this.lblQtdCnpj);
            this.groupBox1.Controls.Add(this.lblQtdFax);
            this.groupBox1.Controls.Add(this.lblQtdFone);
            this.groupBox1.Controls.Add(this.lblQtdUF);
            this.groupBox1.Controls.Add(this.lblQtdCidade);
            this.groupBox1.Controls.Add(this.lblQtdCEP);
            this.groupBox1.Controls.Add(this.lblQtdEndereco);
            this.groupBox1.Controls.Add(this.lblQtdEmpresa);
            this.groupBox1.Controls.Add(this.txtEndereco);
            this.groupBox1.Controls.Add(this.txtCidade);
            this.groupBox1.Controls.Add(this.txtIE);
            this.groupBox1.Controls.Add(this.txtNumCredenciamento);
            this.groupBox1.Controls.Add(this.lblEndereco);
            this.groupBox1.Controls.Add(this.lblCEP);
            this.groupBox1.Controls.Add(this.lblCidade);
            this.groupBox1.Controls.Add(this.lblUF);
            this.groupBox1.Controls.Add(this.lblFone);
            this.groupBox1.Controls.Add(this.lblFax);
            this.groupBox1.Controls.Add(this.lblCnpj);
            this.groupBox1.Controls.Add(this.lblIE);
            this.groupBox1.Controls.Add(this.lblNumCredenciamento);
            this.groupBox1.Controls.Add(this.lblEmpresa);
            this.groupBox1.Controls.Add(this.txtEmpresa);
            this.helpProvider1.SetHelpKeyword(this.groupBox1, "Cadastro da empresa responsável pelos tratamentos.");
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.helpProvider1.SetShowHelp(this.groupBox1, true);
            this.groupBox1.Size = new System.Drawing.Size(530, 357);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações da Empresa";
            // 
            // txtCnpj
            // 
            this.txtCnpj.Location = new System.Drawing.Point(122, 224);
            this.txtCnpj.Mask = "00.000.000/0000-00";
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(121, 20);
            this.txtCnpj.TabIndex = 7;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(290, 186);
            this.txtFax.Mask = "(00) 0000-0000";
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(104, 20);
            this.txtFax.TabIndex = 6;
            // 
            // txtFone
            // 
            this.txtFone.Location = new System.Drawing.Point(122, 186);
            this.txtFone.Mask = "(00) 0000-00009";
            this.txtFone.Name = "txtFone";
            this.txtFone.Size = new System.Drawing.Size(104, 20);
            this.txtFone.TabIndex = 5;
            this.txtFone.TextChanged += new System.EventHandler(this.txtFone_TextChanged);
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(122, 110);
            this.txtCEP.Mask = "00000-000";
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(85, 20);
            this.txtCEP.TabIndex = 2;
            // 
            // chkLogoEmpresa
            // 
            this.chkLogoEmpresa.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.chkLogoEmpresa, "");
            this.helpProvider1.SetHelpString(this.chkLogoEmpresa, "Cadastro ou substituição da logo da empresa responsável pelos tratamentos.");
            this.chkLogoEmpresa.Location = new System.Drawing.Point(96, 331);
            this.chkLogoEmpresa.Name = "chkLogoEmpresa";
            this.helpProvider1.SetShowHelp(this.chkLogoEmpresa, true);
            this.chkLogoEmpresa.Size = new System.Drawing.Size(273, 17);
            this.chkLogoEmpresa.TabIndex = 10;
            this.chkLogoEmpresa.Text = "Substituir Logo da Digisystem pelo Logo da Empresa";
            this.chkLogoEmpresa.UseVisualStyleBackColor = true;
            this.chkLogoEmpresa.CheckedChanged += new System.EventHandler(this.chkLogoEmpresa_CheckedChanged);
            // 
            // cmbUF
            // 
            this.cmbUF.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbUF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbUF.FormattingEnabled = true;
            this.helpProvider1.SetHelpKeyword(this.cmbUF, "");
            this.helpProvider1.SetHelpString(this.cmbUF, "Cadastro do estado da empresa responsável pelos tratamentos.");
            this.cmbUF.Items.AddRange(new object[] {
            "",
            "AC",
            "AL",
            "AP",
            "AM",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MT",
            "MS",
            "MG",
            "PA",
            "PB",
            "PR",
            "PE",
            "PI",
            "RJ",
            "RN",
            "RS",
            "RO",
            "RR",
            "SC",
            "SP",
            "SE",
            "TO"});
            this.cmbUF.Location = new System.Drawing.Point(437, 148);
            this.cmbUF.Name = "cmbUF";
            this.helpProvider1.SetShowHelp(this.cmbUF, true);
            this.cmbUF.Size = new System.Drawing.Size(48, 21);
            this.cmbUF.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.helpProvider1.SetHelpKeyword(this.pictureBox1, "");
            this.helpProvider1.SetHelpString(this.pictureBox1, "Imagem da logo caso tenha.");
            this.pictureBox1.Location = new System.Drawing.Point(370, 218);
            this.pictureBox1.Name = "pictureBox1";
            this.helpProvider1.SetShowHelp(this.pictureBox1, true);
            this.pictureBox1.Size = new System.Drawing.Size(134, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // btnImagem
            // 
            this.btnImagem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.helpProvider1.SetHelpKeyword(this.btnImagem, "");
            this.helpProvider1.SetHelpString(this.btnImagem, "Procura uma imagem da empresa nas pastas locais.");
            this.btnImagem.Location = new System.Drawing.Point(379, 323);
            this.btnImagem.Name = "btnImagem";
            this.helpProvider1.SetShowHelp(this.btnImagem, true);
            this.btnImagem.Size = new System.Drawing.Size(119, 23);
            this.btnImagem.TabIndex = 11;
            this.btnImagem.Text = "Selecionar Imagem";
            this.btnImagem.UseVisualStyleBackColor = true;
            this.btnImagem.Click += new System.EventHandler(this.btnImagem_Click);
            // 
            // lblQtdNumCredenciamento
            // 
            this.lblQtdNumCredenciamento.AutoSize = true;
            this.lblQtdNumCredenciamento.Enabled = false;
            this.lblQtdNumCredenciamento.Location = new System.Drawing.Point(283, 305);
            this.lblQtdNumCredenciamento.Name = "lblQtdNumCredenciamento";
            this.lblQtdNumCredenciamento.Size = new System.Drawing.Size(19, 13);
            this.lblQtdNumCredenciamento.TabIndex = 36;
            this.lblQtdNumCredenciamento.Text = "10";
            this.lblQtdNumCredenciamento.Visible = false;
            // 
            // lblQtdIE
            // 
            this.lblQtdIE.AutoSize = true;
            this.lblQtdIE.Enabled = false;
            this.lblQtdIE.Location = new System.Drawing.Point(242, 266);
            this.lblQtdIE.Name = "lblQtdIE";
            this.lblQtdIE.Size = new System.Drawing.Size(13, 13);
            this.lblQtdIE.TabIndex = 35;
            this.lblQtdIE.Text = "9";
            this.lblQtdIE.Visible = false;
            // 
            // lblQtdCnpj
            // 
            this.lblQtdCnpj.AutoSize = true;
            this.lblQtdCnpj.Enabled = false;
            this.lblQtdCnpj.Location = new System.Drawing.Point(251, 228);
            this.lblQtdCnpj.Name = "lblQtdCnpj";
            this.lblQtdCnpj.Size = new System.Drawing.Size(13, 13);
            this.lblQtdCnpj.TabIndex = 34;
            this.lblQtdCnpj.Text = "8";
            this.lblQtdCnpj.Visible = false;
            // 
            // lblQtdFax
            // 
            this.lblQtdFax.AutoSize = true;
            this.lblQtdFax.Enabled = false;
            this.lblQtdFax.Location = new System.Drawing.Point(400, 191);
            this.lblQtdFax.Name = "lblQtdFax";
            this.lblQtdFax.Size = new System.Drawing.Size(13, 13);
            this.lblQtdFax.TabIndex = 33;
            this.lblQtdFax.Text = "7";
            this.lblQtdFax.Visible = false;
            // 
            // lblQtdFone
            // 
            this.lblQtdFone.AutoSize = true;
            this.lblQtdFone.Enabled = false;
            this.lblQtdFone.Location = new System.Drawing.Point(233, 191);
            this.lblQtdFone.Name = "lblQtdFone";
            this.lblQtdFone.Size = new System.Drawing.Size(13, 13);
            this.lblQtdFone.TabIndex = 32;
            this.lblQtdFone.Text = "6";
            this.lblQtdFone.Visible = false;
            // 
            // lblQtdUF
            // 
            this.lblQtdUF.AutoSize = true;
            this.lblQtdUF.Enabled = false;
            this.lblQtdUF.Location = new System.Drawing.Point(491, 153);
            this.lblQtdUF.Name = "lblQtdUF";
            this.lblQtdUF.Size = new System.Drawing.Size(13, 13);
            this.lblQtdUF.TabIndex = 31;
            this.lblQtdUF.Text = "5";
            this.lblQtdUF.Visible = false;
            // 
            // lblQtdCidade
            // 
            this.lblQtdCidade.AutoSize = true;
            this.lblQtdCidade.Enabled = false;
            this.lblQtdCidade.Location = new System.Drawing.Point(393, 152);
            this.lblQtdCidade.Name = "lblQtdCidade";
            this.lblQtdCidade.Size = new System.Drawing.Size(13, 13);
            this.lblQtdCidade.TabIndex = 30;
            this.lblQtdCidade.Text = "4";
            this.lblQtdCidade.Visible = false;
            // 
            // lblQtdCEP
            // 
            this.lblQtdCEP.AutoSize = true;
            this.lblQtdCEP.Enabled = false;
            this.lblQtdCEP.Location = new System.Drawing.Point(217, 115);
            this.lblQtdCEP.Name = "lblQtdCEP";
            this.lblQtdCEP.Size = new System.Drawing.Size(13, 13);
            this.lblQtdCEP.TabIndex = 29;
            this.lblQtdCEP.Text = "3";
            this.lblQtdCEP.Visible = false;
            // 
            // lblQtdEndereco
            // 
            this.lblQtdEndereco.AutoSize = true;
            this.lblQtdEndereco.Enabled = false;
            this.lblQtdEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtdEndereco.Location = new System.Drawing.Point(446, 93);
            this.lblQtdEndereco.Name = "lblQtdEndereco";
            this.lblQtdEndereco.Size = new System.Drawing.Size(10, 12);
            this.lblQtdEndereco.TabIndex = 28;
            this.lblQtdEndereco.Text = "2";
            // 
            // lblQtdEmpresa
            // 
            this.lblQtdEmpresa.AutoSize = true;
            this.lblQtdEmpresa.Enabled = false;
            this.lblQtdEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtdEmpresa.Location = new System.Drawing.Point(445, 54);
            this.lblQtdEmpresa.Name = "lblQtdEmpresa";
            this.lblQtdEmpresa.Size = new System.Drawing.Size(10, 12);
            this.lblQtdEmpresa.TabIndex = 27;
            this.lblQtdEmpresa.Text = "1";
            // 
            // txtEndereco
            // 
            this.helpProvider1.SetHelpKeyword(this.txtEndereco, "");
            this.helpProvider1.SetHelpString(this.txtEndereco, "Cadastro do endereço da empresa responsável pelos tratamentos.");
            this.txtEndereco.Location = new System.Drawing.Point(122, 72);
            this.txtEndereco.MaxLength = 80;
            this.txtEndereco.Name = "txtEndereco";
            this.helpProvider1.SetShowHelp(this.txtEndereco, true);
            this.txtEndereco.Size = new System.Drawing.Size(374, 20);
            this.txtEndereco.TabIndex = 1;
            this.txtEndereco.TextChanged += new System.EventHandler(this.txtEndereco_TextChanged);
            // 
            // txtCidade
            // 
            this.helpProvider1.SetHelpKeyword(this.txtCidade, "");
            this.helpProvider1.SetHelpString(this.txtCidade, "Cadastro cidade da empresa responsável pelos tratamentos.");
            this.txtCidade.Location = new System.Drawing.Point(122, 148);
            this.txtCidade.MaxLength = 30;
            this.txtCidade.Name = "txtCidade";
            this.helpProvider1.SetShowHelp(this.txtCidade, true);
            this.txtCidade.Size = new System.Drawing.Size(262, 20);
            this.txtCidade.TabIndex = 3;
            // 
            // txtIE
            // 
            this.helpProvider1.SetHelpKeyword(this.txtIE, "");
            this.helpProvider1.SetHelpString(this.txtIE, "Cadastro de inscrição estadual da empresa responsável pelos tratamentos.");
            this.txtIE.Location = new System.Drawing.Point(122, 262);
            this.txtIE.MaxLength = 14;
            this.txtIE.Name = "txtIE";
            this.helpProvider1.SetShowHelp(this.txtIE, true);
            this.txtIE.Size = new System.Drawing.Size(111, 20);
            this.txtIE.TabIndex = 8;
            // 
            // txtNumCredenciamento
            // 
            this.helpProvider1.SetHelpKeyword(this.txtNumCredenciamento, "");
            this.helpProvider1.SetHelpString(this.txtNumCredenciamento, "Cadastro do numero de credenciamento da empresa responsável pelos tratamentos.");
            this.txtNumCredenciamento.Location = new System.Drawing.Point(122, 300);
            this.txtNumCredenciamento.MaxLength = 20;
            this.txtNumCredenciamento.Name = "txtNumCredenciamento";
            this.helpProvider1.SetShowHelp(this.txtNumCredenciamento, true);
            this.txtNumCredenciamento.Size = new System.Drawing.Size(154, 20);
            this.txtNumCredenciamento.TabIndex = 9;
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.lblEndereco, "");
            this.helpProvider1.SetHelpString(this.lblEndereco, "Cadastro do endereço da empresa responsável pelos tratamentos.");
            this.lblEndereco.Location = new System.Drawing.Point(57, 76);
            this.lblEndereco.Name = "lblEndereco";
            this.helpProvider1.SetShowHelp(this.lblEndereco, true);
            this.lblEndereco.Size = new System.Drawing.Size(59, 13);
            this.lblEndereco.TabIndex = 18;
            this.lblEndereco.Text = "Endereço :";
            // 
            // lblCEP
            // 
            this.lblCEP.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.lblCEP, "");
            this.helpProvider1.SetHelpString(this.lblCEP, "Cadastro do cep da empresa responsável pelos tratamentos.");
            this.lblCEP.Location = new System.Drawing.Point(82, 114);
            this.lblCEP.Name = "lblCEP";
            this.helpProvider1.SetShowHelp(this.lblCEP, true);
            this.lblCEP.Size = new System.Drawing.Size(34, 13);
            this.lblCEP.TabIndex = 19;
            this.lblCEP.Text = "CEP :";
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.lblCidade, "");
            this.helpProvider1.SetHelpString(this.lblCidade, "Cadastro cidade da empresa responsável pelos tratamentos.");
            this.lblCidade.Location = new System.Drawing.Point(70, 152);
            this.lblCidade.Name = "lblCidade";
            this.helpProvider1.SetShowHelp(this.lblCidade, true);
            this.lblCidade.Size = new System.Drawing.Size(46, 13);
            this.lblCidade.TabIndex = 20;
            this.lblCidade.Text = "Cidade :";
            // 
            // lblUF
            // 
            this.lblUF.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.lblUF, "");
            this.helpProvider1.SetHelpString(this.lblUF, "Cadastro do estado da empresa responsável pelos tratamentos.");
            this.lblUF.Location = new System.Drawing.Point(411, 152);
            this.lblUF.Name = "lblUF";
            this.helpProvider1.SetShowHelp(this.lblUF, true);
            this.lblUF.Size = new System.Drawing.Size(27, 13);
            this.lblUF.TabIndex = 21;
            this.lblUF.Text = "UF :";
            // 
            // lblFone
            // 
            this.lblFone.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.lblFone, "Cadastro da empresa responsável pelos tratamentos.");
            this.helpProvider1.SetHelpString(this.lblFone, "Cadastro do telefone e fax da empresa responsável pelos tratamentos.");
            this.lblFone.Location = new System.Drawing.Point(79, 190);
            this.lblFone.Name = "lblFone";
            this.helpProvider1.SetShowHelp(this.lblFone, true);
            this.lblFone.Size = new System.Drawing.Size(37, 13);
            this.lblFone.TabIndex = 22;
            this.lblFone.Text = "Fone :";
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.helpProvider1.SetHelpString(this.lblFax, "Cadastro do telefone e fax da empresa responsável pelos tratamentos.");
            this.lblFax.Location = new System.Drawing.Point(257, 190);
            this.lblFax.Name = "lblFax";
            this.helpProvider1.SetShowHelp(this.lblFax, true);
            this.lblFax.Size = new System.Drawing.Size(30, 13);
            this.lblFax.TabIndex = 23;
            this.lblFax.Text = "Fax :";
            // 
            // lblCnpj
            // 
            this.lblCnpj.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.lblCnpj, "");
            this.helpProvider1.SetHelpString(this.lblCnpj, "Cadastro do CNPJ da empresa responsável pelos tratamentos.");
            this.lblCnpj.Location = new System.Drawing.Point(76, 228);
            this.lblCnpj.Name = "lblCnpj";
            this.helpProvider1.SetShowHelp(this.lblCnpj, true);
            this.lblCnpj.Size = new System.Drawing.Size(40, 13);
            this.lblCnpj.TabIndex = 24;
            this.lblCnpj.Text = "CNPJ :";
            // 
            // lblIE
            // 
            this.lblIE.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.lblIE, "");
            this.helpProvider1.SetHelpString(this.lblIE, "Cadastro de inscrição estadual da empresa responsável pelos tratamentos.");
            this.lblIE.Location = new System.Drawing.Point(93, 266);
            this.lblIE.Name = "lblIE";
            this.helpProvider1.SetShowHelp(this.lblIE, true);
            this.lblIE.Size = new System.Drawing.Size(23, 13);
            this.lblIE.TabIndex = 25;
            this.lblIE.Text = "IE :";
            // 
            // lblNumCredenciamento
            // 
            this.lblNumCredenciamento.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.lblNumCredenciamento, "");
            this.helpProvider1.SetHelpString(this.lblNumCredenciamento, "Cadastro do numero de credenciamento da empresa responsável pelos tratamentos.");
            this.lblNumCredenciamento.Location = new System.Drawing.Point(11, 304);
            this.lblNumCredenciamento.Name = "lblNumCredenciamento";
            this.helpProvider1.SetShowHelp(this.lblNumCredenciamento, true);
            this.lblNumCredenciamento.Size = new System.Drawing.Size(105, 13);
            this.lblNumCredenciamento.TabIndex = 26;
            this.lblNumCredenciamento.Text = "Nº Credenciamento :";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.lblEmpresa, "");
            this.helpProvider1.SetHelpString(this.lblEmpresa, "Cadastro da empresa responsável pelos tratamentos.");
            this.lblEmpresa.Location = new System.Drawing.Point(62, 38);
            this.lblEmpresa.Name = "lblEmpresa";
            this.helpProvider1.SetShowHelp(this.lblEmpresa, true);
            this.lblEmpresa.Size = new System.Drawing.Size(54, 13);
            this.lblEmpresa.TabIndex = 17;
            this.lblEmpresa.Text = "Empresa :";
            // 
            // txtEmpresa
            // 
            this.helpProvider1.SetHelpKeyword(this.txtEmpresa, "");
            this.helpProvider1.SetHelpString(this.txtEmpresa, "Cadastro da empresa responsável pelos tratamentos.");
            this.txtEmpresa.Location = new System.Drawing.Point(122, 34);
            this.txtEmpresa.MaxLength = 80;
            this.txtEmpresa.Name = "txtEmpresa";
            this.helpProvider1.SetShowHelp(this.txtEmpresa, true);
            this.txtEmpresa.Size = new System.Drawing.Size(374, 20);
            this.txtEmpresa.TabIndex = 0;
            // 
            // btnSalvarEmpresa
            // 
            this.btnSalvarEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.helpProvider1.SetHelpKeyword(this.btnSalvarEmpresa, "");
            this.helpProvider1.SetHelpString(this.btnSalvarEmpresa, "Salva todas as informações adicionadas ou modificadas.");
            this.btnSalvarEmpresa.Location = new System.Drawing.Point(386, 375);
            this.btnSalvarEmpresa.Name = "btnSalvarEmpresa";
            this.helpProvider1.SetShowHelp(this.btnSalvarEmpresa, true);
            this.btnSalvarEmpresa.Size = new System.Drawing.Size(75, 23);
            this.btnSalvarEmpresa.TabIndex = 1;
            this.btnSalvarEmpresa.Text = "Salvar";
            this.btnSalvarEmpresa.UseVisualStyleBackColor = true;
            this.btnSalvarEmpresa.Click += new System.EventHandler(this.btnSalvarEmpresa_Click);
            // 
            // Sair
            // 
            this.Sair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.helpProvider1.SetHelpKeyword(this.Sair, "");
            this.helpProvider1.SetHelpString(this.Sair, "Sai da tela cadastro da empresa, não salva alterações.");
            this.Sair.Location = new System.Drawing.Point(467, 375);
            this.Sair.Name = "Sair";
            this.helpProvider1.SetShowHelp(this.Sair, true);
            this.Sair.Size = new System.Drawing.Size(75, 23);
            this.Sair.TabIndex = 2;
            this.Sair.Text = "Sair";
            this.Sair.UseVisualStyleBackColor = true;
            this.Sair.Click += new System.EventHandler(this.Sair_Click);
            // 
            // abrirArquivo
            // 
            this.abrirArquivo.FileName = "openFileDialog1";
            // 
            // Empresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(557, 411);
            this.Controls.Add(this.Sair);
            this.Controls.Add(this.btnLimparEmpresa);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalvarEmpresa);
            this.HelpButton = true;
            this.helpProvider1.SetHelpKeyword(this, "Cadastro da empresa responsável pelos tratamentos.");
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Empresa";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empresa";
            this.Load += new System.EventHandler(this.Empresa_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLimparEmpresa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbUF;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnImagem;
        private System.Windows.Forms.Label lblQtdNumCredenciamento;
        private System.Windows.Forms.Label lblQtdIE;
        private System.Windows.Forms.Label lblQtdCnpj;
        private System.Windows.Forms.Label lblQtdFax;
        private System.Windows.Forms.Label lblQtdFone;
        private System.Windows.Forms.Label lblQtdUF;
        private System.Windows.Forms.Label lblQtdCidade;
        private System.Windows.Forms.Label lblQtdCEP;
        private System.Windows.Forms.Label lblQtdEndereco;
        private System.Windows.Forms.Label lblQtdEmpresa;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.TextBox txtIE;
        private System.Windows.Forms.TextBox txtNumCredenciamento;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.Label lblCEP;
        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.Label lblUF;
        private System.Windows.Forms.Label lblFone;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.Label lblCnpj;
        private System.Windows.Forms.Label lblIE;
        private System.Windows.Forms.Label lblNumCredenciamento;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Button btnSalvarEmpresa;
        private System.Windows.Forms.Button Sair;
        private System.Windows.Forms.CheckBox chkLogoEmpresa;
        private System.Windows.Forms.OpenFileDialog abrirArquivo;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.MaskedTextBox txtCnpj;
        private System.Windows.Forms.MaskedTextBox txtFax;
        private System.Windows.Forms.MaskedTextBox txtFone;
        private System.Windows.Forms.MaskedTextBox txtCEP;
    }
}