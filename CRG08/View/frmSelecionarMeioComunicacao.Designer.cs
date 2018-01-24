namespace CRG08.View
{
    partial class frmSelecionarMeioComunicacao
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
            this.cmbNumCRG = new System.Windows.Forms.ComboBox();
            this.rdBtnOnline = new System.Windows.Forms.RadioButton();
            this.rdBtnPendrive = new System.Windows.Forms.RadioButton();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblNumCRG = new System.Windows.Forms.Label();
            this.ckApenasAparelho = new System.Windows.Forms.CheckBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // cmbNumCRG
            // 
            this.cmbNumCRG.BackColor = System.Drawing.Color.White;
            this.cmbNumCRG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNumCRG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNumCRG.FormattingEnabled = true;
            this.helpProvider1.SetHelpKeyword(this.cmbNumCRG, "");
            this.helpProvider1.SetHelpString(this.cmbNumCRG, "Número do Crg que se quer baixar os dados.");
            this.cmbNumCRG.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
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
            this.cmbNumCRG.Location = new System.Drawing.Point(95, 61);
            this.cmbNumCRG.Name = "cmbNumCRG";
            this.helpProvider1.SetShowHelp(this.cmbNumCRG, true);
            this.cmbNumCRG.Size = new System.Drawing.Size(56, 21);
            this.cmbNumCRG.TabIndex = 2;
            this.cmbNumCRG.SelectedIndexChanged += new System.EventHandler(this.cmbNumCRG_SelectedIndexChanged);
            // 
            // rdBtnOnline
            // 
            this.rdBtnOnline.AutoSize = true;
            this.rdBtnOnline.Checked = true;
            this.rdBtnOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdBtnOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.rdBtnOnline, "");
            this.helpProvider1.SetHelpString(this.rdBtnOnline, "Conexão via cabo(On Line).");
            this.rdBtnOnline.Location = new System.Drawing.Point(37, 12);
            this.rdBtnOnline.Name = "rdBtnOnline";
            this.helpProvider1.SetShowHelp(this.rdBtnOnline, true);
            this.rdBtnOnline.Size = new System.Drawing.Size(53, 17);
            this.rdBtnOnline.TabIndex = 3;
            this.rdBtnOnline.TabStop = true;
            this.rdBtnOnline.Text = "Cabo";
            this.rdBtnOnline.UseVisualStyleBackColor = true;
            this.rdBtnOnline.CheckedChanged += new System.EventHandler(this.rdBtnOnline_CheckedChanged);
            // 
            // rdBtnPendrive
            // 
            this.rdBtnPendrive.AutoSize = true;
            this.rdBtnPendrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdBtnPendrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.rdBtnPendrive, "");
            this.helpProvider1.SetHelpString(this.rdBtnPendrive, "Conexão via Pen Drive.");
            this.rdBtnPendrive.Location = new System.Drawing.Point(96, 12);
            this.rdBtnPendrive.Name = "rdBtnPendrive";
            this.helpProvider1.SetShowHelp(this.rdBtnPendrive, true);
            this.rdBtnPendrive.Size = new System.Drawing.Size(74, 17);
            this.rdBtnPendrive.TabIndex = 4;
            this.rdBtnPendrive.Text = "Pendrive";
            this.rdBtnPendrive.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.btnConfirmar, "");
            this.helpProvider1.SetHelpString(this.btnConfirmar, "Confirma as informações para comunicação.");
            this.btnConfirmar.Location = new System.Drawing.Point(12, 96);
            this.btnConfirmar.Name = "btnConfirmar";
            this.helpProvider1.SetShowHelp(this.btnConfirmar, true);
            this.btnConfirmar.Size = new System.Drawing.Size(87, 35);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.btnCancelar, "");
            this.helpProvider1.SetHelpString(this.btnCancelar, "Cancela o processo de escolha de comunicação.");
            this.btnCancelar.Location = new System.Drawing.Point(103, 96);
            this.btnCancelar.Name = "btnCancelar";
            this.helpProvider1.SetShowHelp(this.btnCancelar, true);
            this.btnCancelar.Size = new System.Drawing.Size(87, 35);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblNumCRG
            // 
            this.lblNumCRG.AutoSize = true;
            this.lblNumCRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.lblNumCRG, "");
            this.helpProvider1.SetHelpString(this.lblNumCRG, "Número do Crg que se quer baixar os dados.");
            this.lblNumCRG.Location = new System.Drawing.Point(38, 64);
            this.lblNumCRG.Name = "lblNumCRG";
            this.helpProvider1.SetShowHelp(this.lblNumCRG, true);
            this.lblNumCRG.Size = new System.Drawing.Size(55, 13);
            this.lblNumCRG.TabIndex = 7;
            this.lblNumCRG.Text = "Nº CRG:";
            // 
            // ckApenasAparelho
            // 
            this.ckApenasAparelho.AutoSize = true;
            this.ckApenasAparelho.Checked = true;
            this.ckApenasAparelho.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckApenasAparelho.Enabled = false;
            this.ckApenasAparelho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpString(this.ckApenasAparelho, "Escolha do aparelho que deseja cominicar ou puxar dados on line.");
            this.ckApenasAparelho.Location = new System.Drawing.Point(25, 39);
            this.ckApenasAparelho.Name = "ckApenasAparelho";
            this.helpProvider1.SetShowHelp(this.ckApenasAparelho, true);
            this.ckApenasAparelho.Size = new System.Drawing.Size(158, 17);
            this.ckApenasAparelho.TabIndex = 8;
            this.ckApenasAparelho.Text = "Apenas do aparelho a seguir";
            this.ckApenasAparelho.UseVisualStyleBackColor = true;
            this.ckApenasAparelho.CheckedChanged += new System.EventHandler(this.ckApenasAparelho_CheckedChanged);
            // 
            // frmSelecionarMeioComunicacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(202, 141);
            this.Controls.Add(this.ckApenasAparelho);
            this.Controls.Add(this.lblNumCRG);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.rdBtnPendrive);
            this.Controls.Add(this.rdBtnOnline);
            this.Controls.Add(this.cmbNumCRG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelecionarMeioComunicacao";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comunicação";
            this.Load += new System.EventHandler(this.frmSelecionarMeioComunicacao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbNumCRG;
        private System.Windows.Forms.RadioButton rdBtnOnline;
        private System.Windows.Forms.RadioButton rdBtnPendrive;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblNumCRG;
        private System.Windows.Forms.CheckBox ckApenasAparelho;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}