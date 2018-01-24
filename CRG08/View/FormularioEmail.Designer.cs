namespace CRG08.View
{
    partial class FormularioEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioEmail));
            this.Continuar = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExcluirDestinatario = new System.Windows.Forms.Button();
            this.AlterarDestinatario = new System.Windows.Forms.Button();
            this.AdicionarDestinatario = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dtgDestinatarios = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destinatario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkSSL = new System.Windows.Forms.CheckBox();
            this.txtPorta = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDe = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNomeUsuario = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtServidorSMTP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDestinatarios)).BeginInit();
            this.SuspendLayout();
            // 
            // Continuar
            // 
            this.Continuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpString(this.Continuar, "Continuar após as informações prestadas.");
            this.Continuar.Location = new System.Drawing.Point(353, 227);
            this.Continuar.Name = "Continuar";
            this.helpProvider1.SetShowHelp(this.Continuar, true);
            this.Continuar.Size = new System.Drawing.Size(75, 23);
            this.Continuar.TabIndex = 10;
            this.Continuar.Text = "Continuar";
            this.Continuar.UseVisualStyleBackColor = true;
            this.Continuar.Click += new System.EventHandler(this.Continuar_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpString(this.Cancelar, "Cancelar tela de e-mail.");
            this.Cancelar.Location = new System.Drawing.Point(434, 227);
            this.Cancelar.Name = "Cancelar";
            this.helpProvider1.SetShowHelp(this.Cancelar, true);
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 11;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ExcluirDestinatario);
            this.panel1.Controls.Add(this.AlterarDestinatario);
            this.panel1.Controls.Add(this.AdicionarDestinatario);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dtgDestinatarios);
            this.panel1.Controls.Add(this.chkSSL);
            this.panel1.Controls.Add(this.txtPorta);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtDe);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtSenha);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtNomeUsuario);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtServidorSMTP);
            this.panel1.Controls.Add(this.label7);
            this.helpProvider1.SetHelpKeyword(this.panel1, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI.");
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(497, 209);
            this.panel1.TabIndex = 12;
            // 
            // ExcluirDestinatario
            // 
            this.ExcluirDestinatario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpKeyword(this.ExcluirDestinatario, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI.");
            this.helpProvider1.SetHelpString(this.ExcluirDestinatario, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI para " +
        "continuar a configuração deste item..");
            this.ExcluirDestinatario.Location = new System.Drawing.Point(396, 161);
            this.ExcluirDestinatario.Name = "ExcluirDestinatario";
            this.helpProvider1.SetShowHelp(this.ExcluirDestinatario, true);
            this.ExcluirDestinatario.Size = new System.Drawing.Size(69, 23);
            this.ExcluirDestinatario.TabIndex = 9;
            this.ExcluirDestinatario.Text = "Excluir";
            this.ExcluirDestinatario.UseVisualStyleBackColor = true;
            this.ExcluirDestinatario.Click += new System.EventHandler(this.ExcluirDestinatario_Click);
            // 
            // AlterarDestinatario
            // 
            this.AlterarDestinatario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpKeyword(this.AlterarDestinatario, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI.");
            this.helpProvider1.SetHelpString(this.AlterarDestinatario, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI para " +
        "continuar a configuração deste item..");
            this.AlterarDestinatario.Location = new System.Drawing.Point(396, 130);
            this.AlterarDestinatario.Name = "AlterarDestinatario";
            this.helpProvider1.SetShowHelp(this.AlterarDestinatario, true);
            this.AlterarDestinatario.Size = new System.Drawing.Size(69, 23);
            this.AlterarDestinatario.TabIndex = 8;
            this.AlterarDestinatario.Text = "Alterar";
            this.AlterarDestinatario.UseVisualStyleBackColor = true;
            this.AlterarDestinatario.Click += new System.EventHandler(this.AlterarDestinatario_Click);
            // 
            // AdicionarDestinatario
            // 
            this.AdicionarDestinatario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpKeyword(this.AdicionarDestinatario, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI.");
            this.helpProvider1.SetHelpString(this.AdicionarDestinatario, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI para " +
        "continuar a configuração deste item..");
            this.AdicionarDestinatario.Location = new System.Drawing.Point(396, 101);
            this.AdicionarDestinatario.Name = "AdicionarDestinatario";
            this.helpProvider1.SetShowHelp(this.AdicionarDestinatario, true);
            this.AdicionarDestinatario.Size = new System.Drawing.Size(69, 23);
            this.AdicionarDestinatario.TabIndex = 7;
            this.AdicionarDestinatario.Text = "Adicionar";
            this.AdicionarDestinatario.UseVisualStyleBackColor = true;
            this.AdicionarDestinatario.Click += new System.EventHandler(this.AdicionarDestinatario_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.label10, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI.");
            this.helpProvider1.SetHelpString(this.label10, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI para " +
        "continuar a configuração deste item..");
            this.label10.Location = new System.Drawing.Point(57, 101);
            this.label10.Name = "label10";
            this.helpProvider1.SetShowHelp(this.label10, true);
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Para:";
            // 
            // dtgDestinatarios
            // 
            this.dtgDestinatarios.AllowUserToAddRows = false;
            this.dtgDestinatarios.AllowUserToDeleteRows = false;
            this.dtgDestinatarios.BackgroundColor = System.Drawing.Color.White;
            this.dtgDestinatarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDestinatarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Destinatario});
            this.helpProvider1.SetHelpKeyword(this.dtgDestinatarios, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI.");
            this.helpProvider1.SetHelpString(this.dtgDestinatarios, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI para " +
        "continuar a configuração deste item..");
            this.dtgDestinatarios.Location = new System.Drawing.Point(89, 101);
            this.dtgDestinatarios.Name = "dtgDestinatarios";
            this.dtgDestinatarios.RowHeadersVisible = false;
            this.dtgDestinatarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.helpProvider1.SetShowHelp(this.dtgDestinatarios, true);
            this.dtgDestinatarios.Size = new System.Drawing.Size(304, 83);
            this.dtgDestinatarios.TabIndex = 19;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Destinatario
            // 
            this.Destinatario.HeaderText = "Destinatário";
            this.Destinatario.Name = "Destinatario";
            this.Destinatario.Width = 290;
            // 
            // chkSSL
            // 
            this.chkSSL.AutoSize = true;
            this.chkSSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpString(this.chkSSL, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI para " +
        "continuar a configuração deste item..");
            this.chkSSL.Location = new System.Drawing.Point(137, 78);
            this.chkSSL.Name = "chkSSL";
            this.helpProvider1.SetShowHelp(this.chkSSL, true);
            this.chkSSL.Size = new System.Drawing.Size(41, 16);
            this.chkSSL.TabIndex = 6;
            this.chkSSL.Text = "SSL";
            this.chkSSL.UseVisualStyleBackColor = true;
            // 
            // txtPorta
            // 
            this.helpProvider1.SetHelpKeyword(this.txtPorta, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI.");
            this.helpProvider1.SetHelpString(this.txtPorta, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI para " +
        "continuar a configuração deste item..");
            this.txtPorta.Location = new System.Drawing.Point(89, 75);
            this.txtPorta.Name = "txtPorta";
            this.helpProvider1.SetShowHelp(this.txtPorta, true);
            this.txtPorta.Size = new System.Drawing.Size(45, 20);
            this.txtPorta.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.label12, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI.");
            this.helpProvider1.SetHelpString(this.label12, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI para " +
        "continuar a configuração deste item..");
            this.label12.Location = new System.Drawing.Point(54, 78);
            this.label12.Name = "label12";
            this.helpProvider1.SetShowHelp(this.label12, true);
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Porta:";
            // 
            // txtDe
            // 
            this.helpProvider1.SetHelpKeyword(this.txtDe, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI.");
            this.helpProvider1.SetHelpString(this.txtDe, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI para " +
        "continuar a configuração deste item..");
            this.txtDe.Location = new System.Drawing.Point(89, 29);
            this.txtDe.Name = "txtDe";
            this.helpProvider1.SetShowHelp(this.txtDe, true);
            this.txtDe.Size = new System.Drawing.Size(292, 20);
            this.txtDe.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.label11, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI.");
            this.helpProvider1.SetHelpString(this.label11, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI para " +
        "continuar a configuração deste item..");
            this.label11.Location = new System.Drawing.Point(0, 30);
            this.label11.Name = "label11";
            this.helpProvider1.SetShowHelp(this.label11, true);
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Email Remetente:";
            // 
            // txtSenha
            // 
            this.helpProvider1.SetHelpKeyword(this.txtSenha, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI.");
            this.helpProvider1.SetHelpString(this.txtSenha, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI para " +
        "continuar a configuração deste item..");
            this.txtSenha.Location = new System.Drawing.Point(339, 52);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.helpProvider1.SetShowHelp(this.txtSenha, true);
            this.txtSenha.Size = new System.Drawing.Size(146, 20);
            this.txtSenha.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.label9, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI.");
            this.helpProvider1.SetHelpString(this.label9, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI para " +
        "continuar a configuração deste item..");
            this.label9.Location = new System.Drawing.Point(297, 55);
            this.label9.Name = "label9";
            this.helpProvider1.SetShowHelp(this.label9, true);
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Senha:";
            // 
            // txtNomeUsuario
            // 
            this.helpProvider1.SetHelpKeyword(this.txtNomeUsuario, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI.");
            this.helpProvider1.SetHelpString(this.txtNomeUsuario, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI para " +
        "continuar a configuração deste item..");
            this.txtNomeUsuario.Location = new System.Drawing.Point(89, 52);
            this.txtNomeUsuario.Name = "txtNomeUsuario";
            this.helpProvider1.SetShowHelp(this.txtNomeUsuario, true);
            this.txtNomeUsuario.Size = new System.Drawing.Size(203, 20);
            this.txtNomeUsuario.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.label8, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI.");
            this.helpProvider1.SetHelpString(this.label8, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI para " +
        "continuar a configuração deste item..");
            this.label8.Location = new System.Drawing.Point(12, 55);
            this.label8.Name = "label8";
            this.helpProvider1.SetShowHelp(this.label8, true);
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Nome Usuário:";
            // 
            // txtServidorSMTP
            // 
            this.helpProvider1.SetHelpKeyword(this.txtServidorSMTP, "");
            this.helpProvider1.SetHelpString(this.txtServidorSMTP, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI para " +
        "continuar a configuração deste item..");
            this.txtServidorSMTP.Location = new System.Drawing.Point(89, 6);
            this.txtServidorSMTP.Name = "txtServidorSMTP";
            this.helpProvider1.SetShowHelp(this.txtServidorSMTP, true);
            this.txtServidorSMTP.Size = new System.Drawing.Size(292, 20);
            this.txtServidorSMTP.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.label7, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI.");
            this.helpProvider1.SetHelpString(this.label7, "Cadastro de e-mail para envio de tratamentos, contacte o departamento de TI para " +
        "continuar a configuração deste item..");
            this.label7.Location = new System.Drawing.Point(7, 9);
            this.label7.Name = "label7";
            this.helpProvider1.SetShowHelp(this.label7, true);
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Servidor SMTP:";
            // 
            // FormularioEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(519, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Continuar);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormularioEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe os dados do email";
            this.Load += new System.EventHandler(this.FormularioEmail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDestinatarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Continuar;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ExcluirDestinatario;
        private System.Windows.Forms.Button AlterarDestinatario;
        private System.Windows.Forms.Button AdicionarDestinatario;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dtgDestinatarios;
        private System.Windows.Forms.CheckBox chkSSL;
        private System.Windows.Forms.TextBox txtPorta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDe;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNomeUsuario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtServidorSMTP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destinatario;
        private System.Windows.Forms.HelpProvider helpProvider1;

    }
}