namespace CRG08.View
{
    partial class SelectEquip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectEquip));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbEquip = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbEquip);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Equipamentos";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmbEquip
            // 
            this.cmbEquip.FormattingEnabled = true;
            this.helpProvider1.SetHelpKeyword(this.cmbEquip, "");
            this.helpProvider1.SetHelpString(this.cmbEquip, "Seleciona o equipamento.");
            this.cmbEquip.Items.AddRange(new object[] {
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
            "16"});
            this.cmbEquip.Location = new System.Drawing.Point(50, 22);
            this.cmbEquip.Name = "cmbEquip";
            this.helpProvider1.SetShowHelp(this.cmbEquip, true);
            this.cmbEquip.Size = new System.Drawing.Size(44, 21);
            this.cmbEquip.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.label1, "Seleciona o equipamento.");
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, true);
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nº:";
            // 
            // OK
            // 
            this.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpKeyword(this.OK, "");
            this.helpProvider1.SetHelpString(this.OK, "Ok para confirmar a escolha do equipamento.");
            this.OK.Location = new System.Drawing.Point(23, 77);
            this.OK.Name = "OK";
            this.helpProvider1.SetShowHelp(this.OK, true);
            this.OK.Size = new System.Drawing.Size(59, 23);
            this.OK.TabIndex = 2;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpKeyword(this.Cancelar, "");
            this.helpProvider1.SetHelpString(this.Cancelar, "Cancela a seleção de equipamento.");
            this.Cancelar.Location = new System.Drawing.Point(88, 77);
            this.Cancelar.Name = "Cancelar";
            this.helpProvider1.SetShowHelp(this.Cancelar, true);
            this.Cancelar.Size = new System.Drawing.Size(59, 23);
            this.Cancelar.TabIndex = 3;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // SelectEquip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(173, 112);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.groupBox1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectEquip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRG 08";
            this.Load += new System.EventHandler(this.SelectEquip_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbEquip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}