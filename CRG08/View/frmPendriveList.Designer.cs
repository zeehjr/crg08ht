namespace CRG08.View
{
    partial class frmPendriveList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPendriveList));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCRG = new System.Windows.Forms.ComboBox();
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.lbArquivos = new System.Windows.Forms.ListBox();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.label1, "");
            this.helpProvider1.SetHelpString(this.label1, "Número do Crg para baixar os tratamento.");
            this.label1.Location = new System.Drawing.Point(38, 9);
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, true);
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nº CRG:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.label2, "");
            this.helpProvider1.SetHelpString(this.label2, "Unidade que do Pen Drive com os arquivos de tratamento.");
            this.label2.Location = new System.Drawing.Point(35, 33);
            this.label2.Name = "label2";
            this.helpProvider1.SetShowHelp(this.label2, true);
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Unidade:";
            // 
            // cbCRG
            // 
            this.cbCRG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCRG.FormattingEnabled = true;
            this.helpProvider1.SetHelpKeyword(this.cbCRG, "");
            this.helpProvider1.SetHelpString(this.cbCRG, "Número do Crg para baixar os tratamento.");
            this.cbCRG.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
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
            this.cbCRG.Location = new System.Drawing.Point(99, 6);
            this.cbCRG.Name = "cbCRG";
            this.helpProvider1.SetShowHelp(this.cbCRG, true);
            this.cbCRG.Size = new System.Drawing.Size(64, 21);
            this.cbCRG.TabIndex = 2;
            this.cbCRG.SelectedIndexChanged += new System.EventHandler(this.cbCRG_SelectedIndexChanged);
            // 
            // cbUnidade
            // 
            this.cbUnidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnidade.FormattingEnabled = true;
            this.helpProvider1.SetHelpKeyword(this.cbUnidade, "");
            this.helpProvider1.SetHelpString(this.cbUnidade, "Unidade que do Pen Drive com os arquivos de tratamento.");
            this.cbUnidade.Location = new System.Drawing.Point(99, 30);
            this.cbUnidade.Name = "cbUnidade";
            this.helpProvider1.SetShowHelp(this.cbUnidade, true);
            this.cbUnidade.Size = new System.Drawing.Size(64, 21);
            this.cbUnidade.TabIndex = 3;
            this.cbUnidade.SelectedIndexChanged += new System.EventHandler(this.cbUnidade_SelectedIndexChanged);
            // 
            // lbArquivos
            // 
            this.lbArquivos.FormattingEnabled = true;
            this.helpProvider1.SetHelpKeyword(this.lbArquivos, "");
            this.helpProvider1.SetHelpString(this.lbArquivos, "Local onde aparecem os tratamentos no pen drive.");
            this.lbArquivos.Location = new System.Drawing.Point(26, 57);
            this.lbArquivos.Name = "lbArquivos";
            this.helpProvider1.SetShowHelp(this.lbArquivos, true);
            this.lbArquivos.Size = new System.Drawing.Size(168, 121);
            this.lbArquivos.TabIndex = 4;
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.btnSelecionar, "");
            this.helpProvider1.SetHelpString(this.btnSelecionar, "Seleciona o tratamento escolhido.");
            this.btnSelecionar.ImageIndex = 0;
            this.btnSelecionar.ImageList = this.imageList1;
            this.btnSelecionar.Location = new System.Drawing.Point(50, 184);
            this.btnSelecionar.Name = "btnSelecionar";
            this.helpProvider1.SetShowHelp(this.btnSelecionar, true);
            this.btnSelecionar.Size = new System.Drawing.Size(125, 41);
            this.btnSelecionar.TabIndex = 5;
            this.btnSelecionar.Text = "Selecionar";
            this.btnSelecionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelecionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1413915804_3207.ico");
            // 
            // frmPendriveList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 234);
            this.Controls.Add(this.btnSelecionar);
            this.Controls.Add(this.lbArquivos);
            this.Controls.Add(this.cbUnidade);
            this.Controls.Add(this.cbCRG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPendriveList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecionar Tratamento";
            this.Load += new System.EventHandler(this.frmPendriveList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCRG;
        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.ListBox lbArquivos;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}