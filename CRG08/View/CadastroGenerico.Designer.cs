namespace CRG08.View
{
    partial class CadastroGenerico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroGenerico));
            this.Descricao = new System.Windows.Forms.GroupBox();
            this.Alterar = new System.Windows.Forms.Button();
            this.Excluir = new System.Windows.Forms.Button();
            this.Inserir = new System.Windows.Forms.Button();
            this.dtgInsercao = new System.Windows.Forms.DataGridView();
            this.Texto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Voltar = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.Descricao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInsercao)).BeginInit();
            this.SuspendLayout();
            // 
            // Descricao
            // 
            this.Descricao.Controls.Add(this.Alterar);
            this.Descricao.Controls.Add(this.Excluir);
            this.Descricao.Controls.Add(this.Inserir);
            this.Descricao.Controls.Add(this.dtgInsercao);
            this.Descricao.Location = new System.Drawing.Point(12, 12);
            this.Descricao.Name = "Descricao";
            this.Descricao.Size = new System.Drawing.Size(305, 210);
            this.Descricao.TabIndex = 5;
            this.Descricao.TabStop = false;
            this.Descricao.Text = "Descrição";
            // 
            // Alterar
            // 
            this.Alterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpString(this.Alterar, "Alterar um item.");
            this.Alterar.Location = new System.Drawing.Point(181, 178);
            this.Alterar.Name = "Alterar";
            this.helpProvider1.SetShowHelp(this.Alterar, true);
            this.Alterar.Size = new System.Drawing.Size(55, 23);
            this.Alterar.TabIndex = 2;
            this.Alterar.Text = "Alterar";
            this.Alterar.UseVisualStyleBackColor = true;
            this.Alterar.Click += new System.EventHandler(this.Alterar_Click);
            // 
            // Excluir
            // 
            this.Excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpString(this.Excluir, "Excluir um item, este botão não salva e nem altera dados.");
            this.Excluir.Location = new System.Drawing.Point(242, 178);
            this.Excluir.Name = "Excluir";
            this.helpProvider1.SetShowHelp(this.Excluir, true);
            this.Excluir.Size = new System.Drawing.Size(55, 23);
            this.Excluir.TabIndex = 3;
            this.Excluir.Text = "Excluir";
            this.Excluir.UseVisualStyleBackColor = true;
            this.Excluir.Click += new System.EventHandler(this.Excluir_Click);
            // 
            // Inserir
            // 
            this.Inserir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpString(this.Inserir, "Inserir um item.");
            this.Inserir.Location = new System.Drawing.Point(120, 178);
            this.Inserir.Name = "Inserir";
            this.helpProvider1.SetShowHelp(this.Inserir, true);
            this.Inserir.Size = new System.Drawing.Size(55, 23);
            this.Inserir.TabIndex = 1;
            this.Inserir.Text = "Inserir";
            this.Inserir.UseVisualStyleBackColor = true;
            this.Inserir.Click += new System.EventHandler(this.Inserir_Click);
            // 
            // dtgInsercao
            // 
            this.dtgInsercao.AllowUserToAddRows = false;
            this.dtgInsercao.AllowUserToDeleteRows = false;
            this.dtgInsercao.BackgroundColor = System.Drawing.Color.White;
            this.dtgInsercao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgInsercao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Texto,
            this.ID});
            this.helpProvider1.SetHelpString(this.dtgInsercao, "Descrição do Item.");
            this.dtgInsercao.Location = new System.Drawing.Point(6, 19);
            this.dtgInsercao.Name = "dtgInsercao";
            this.dtgInsercao.RowHeadersVisible = false;
            this.helpProvider1.SetShowHelp(this.dtgInsercao, true);
            this.dtgInsercao.Size = new System.Drawing.Size(291, 153);
            this.dtgInsercao.TabIndex = 4;
            // 
            // Texto
            // 
            this.Texto.HeaderText = "Descrição";
            this.Texto.Name = "Texto";
            this.Texto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Texto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Texto.Width = 280;
            // 
            // ID
            // 
            this.ID.HeaderText = "";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Voltar
            // 
            this.Voltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpProvider1.SetHelpString(this.Voltar, "Voltar a tela anterior.");
            this.Voltar.Location = new System.Drawing.Point(242, 228);
            this.Voltar.Name = "Voltar";
            this.helpProvider1.SetShowHelp(this.Voltar, true);
            this.Voltar.Size = new System.Drawing.Size(75, 23);
            this.Voltar.TabIndex = 6;
            this.Voltar.Text = "Voltar";
            this.Voltar.UseVisualStyleBackColor = true;
            this.Voltar.Click += new System.EventHandler(this.Voltar_Click);
            // 
            // CadastroGenerico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(329, 260);
            this.Controls.Add(this.Voltar);
            this.Controls.Add(this.Descricao);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CadastroGenerico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CadastroGenerico";
            this.Load += new System.EventHandler(this.CadastroGenerico_Load);
            this.Descricao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgInsercao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Descricao;
        private System.Windows.Forms.DataGridView dtgInsercao;
        private System.Windows.Forms.Button Voltar;
        private System.Windows.Forms.Button Inserir;
        private System.Windows.Forms.Button Excluir;
        private System.Windows.Forms.Button Alterar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Texto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}