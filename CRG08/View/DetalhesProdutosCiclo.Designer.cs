namespace CRG08.View
{
    partial class DetalhesProdutosCiclo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetalhesProdutosCiclo));
            this.dtgprodutos = new System.Windows.Forms.DataGridView();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fechar = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.dtgprodutos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgprodutos
            // 
            this.dtgprodutos.AllowUserToAddRows = false;
            this.dtgprodutos.AllowUserToDeleteRows = false;
            this.dtgprodutos.BackgroundColor = System.Drawing.Color.White;
            this.dtgprodutos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgprodutos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgprodutos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgprodutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgprodutos.ColumnHeadersVisible = false;
            this.dtgprodutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Empresa,
            this.idEmpresa,
            this.idProduto});
            this.dtgprodutos.GridColor = System.Drawing.Color.AliceBlue;
            this.helpProvider1.SetHelpKeyword(this.dtgprodutos, "");
            this.helpProvider1.SetHelpString(this.dtgprodutos, "Visualização de todos os produtos do ciclo.");
            this.dtgprodutos.Location = new System.Drawing.Point(12, 12);
            this.dtgprodutos.Name = "dtgprodutos";
            this.dtgprodutos.ReadOnly = true;
            this.dtgprodutos.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgprodutos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.helpProvider1.SetShowHelp(this.dtgprodutos, true);
            this.dtgprodutos.Size = new System.Drawing.Size(292, 227);
            this.dtgprodutos.TabIndex = 2;
            this.dtgprodutos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgprodutos_CellMouseClick);
            this.dtgprodutos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgprodutos_CellMouseDoubleClick);
            // 
            // Empresa
            // 
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.ReadOnly = true;
            this.Empresa.Width = 250;
            // 
            // idEmpresa
            // 
            this.idEmpresa.HeaderText = "idEmpresa";
            this.idEmpresa.Name = "idEmpresa";
            this.idEmpresa.ReadOnly = true;
            this.idEmpresa.Visible = false;
            // 
            // idProduto
            // 
            this.idProduto.HeaderText = "idProduto";
            this.idProduto.Name = "idProduto";
            this.idProduto.ReadOnly = true;
            this.idProduto.Visible = false;
            // 
            // Fechar
            // 
            this.Fechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.helpProvider1.SetHelpKeyword(this.Fechar, "");
            this.helpProvider1.SetHelpString(this.Fechar, "Fecha visualizador.");
            this.Fechar.Location = new System.Drawing.Point(229, 245);
            this.Fechar.Name = "Fechar";
            this.helpProvider1.SetShowHelp(this.Fechar, true);
            this.Fechar.Size = new System.Drawing.Size(75, 23);
            this.Fechar.TabIndex = 1;
            this.Fechar.Text = "Fechar";
            this.Fechar.UseVisualStyleBackColor = true;
            this.Fechar.Click += new System.EventHandler(this.Fechar_Click);
            // 
            // DetalhesProdutosCiclo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(316, 278);
            this.Controls.Add(this.Fechar);
            this.Controls.Add(this.dtgprodutos);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DetalhesProdutosCiclo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produtos do Ciclo";
            this.Load += new System.EventHandler(this.DetalhesProdutosCiclo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgprodutos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgprodutos;
        private System.Windows.Forms.Button Fechar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProduto;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}