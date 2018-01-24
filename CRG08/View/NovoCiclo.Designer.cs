namespace CRG08.View
{
    partial class NovoCiclo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NovoCiclo));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCRG = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Descricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Responsavel = new System.Windows.Forms.TextBox();
            this.Operador = new System.Windows.Forms.TextBox();
            this.grpTotalProdutos = new System.Windows.Forms.GroupBox();
            this.InserirProduto = new System.Windows.Forms.Button();
            this.ExcluirProduto = new System.Windows.Forms.Button();
            this.dtgProdutos = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Produto = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidade = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Empresa = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chkPenDrive = new System.Windows.Forms.CheckBox();
            this.Cancelar = new System.Windows.Forms.Button();
            this.Receber = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusPendrive = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpTotalProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProdutos)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "CRG Nº: ";
            // 
            // cmbCRG
            // 
            this.cmbCRG.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCRG.FormattingEnabled = true;
            this.cmbCRG.Items.AddRange(new object[] {
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
            this.cmbCRG.Location = new System.Drawing.Point(64, 11);
            this.cmbCRG.Name = "cmbCRG";
            this.cmbCRG.Size = new System.Drawing.Size(60, 22);
            this.cmbCRG.TabIndex = 1;
            this.cmbCRG.SelectedIndexChanged += new System.EventHandler(this.cmbCRG_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrição:";
            // 
            // Descricao
            // 
            this.Descricao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descricao.Location = new System.Drawing.Point(64, 38);
            this.Descricao.MaxLength = 50;
            this.Descricao.Name = "Descricao";
            this.Descricao.Size = new System.Drawing.Size(221, 20);
            this.Descricao.TabIndex = 2;
            this.Descricao.TextChanged += new System.EventHandler(this.Descricao_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(305, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Resp. Téc:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(311, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "Operador:";
            // 
            // Responsavel
            // 
            this.Responsavel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Responsavel.Location = new System.Drawing.Point(364, 11);
            this.Responsavel.MaxLength = 50;
            this.Responsavel.Name = "Responsavel";
            this.Responsavel.Size = new System.Drawing.Size(208, 20);
            this.Responsavel.TabIndex = 3;
            this.Responsavel.TextChanged += new System.EventHandler(this.Responsavel_TextChanged);
            // 
            // Operador
            // 
            this.Operador.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Operador.Location = new System.Drawing.Point(364, 38);
            this.Operador.MaxLength = 50;
            this.Operador.Name = "Operador";
            this.Operador.Size = new System.Drawing.Size(208, 20);
            this.Operador.TabIndex = 4;
            this.Operador.TextChanged += new System.EventHandler(this.Operador_TextChanged);
            // 
            // grpTotalProdutos
            // 
            this.grpTotalProdutos.Controls.Add(this.InserirProduto);
            this.grpTotalProdutos.Controls.Add(this.ExcluirProduto);
            this.grpTotalProdutos.Controls.Add(this.dtgProdutos);
            this.grpTotalProdutos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTotalProdutos.Location = new System.Drawing.Point(12, 64);
            this.grpTotalProdutos.Name = "grpTotalProdutos";
            this.grpTotalProdutos.Size = new System.Drawing.Size(560, 215);
            this.grpTotalProdutos.TabIndex = 8;
            this.grpTotalProdutos.TabStop = false;
            this.grpTotalProdutos.Text = "Total de Produtos:";
            // 
            // InserirProduto
            // 
            this.InserirProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InserirProduto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InserirProduto.Location = new System.Drawing.Point(410, 185);
            this.InserirProduto.Name = "InserirProduto";
            this.InserirProduto.Size = new System.Drawing.Size(66, 23);
            this.InserirProduto.TabIndex = 5;
            this.InserirProduto.Text = "Inserir";
            this.InserirProduto.UseVisualStyleBackColor = true;
            this.InserirProduto.Click += new System.EventHandler(this.InserirProduto_Click);
            // 
            // ExcluirProduto
            // 
            this.ExcluirProduto.Enabled = false;
            this.ExcluirProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExcluirProduto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExcluirProduto.Location = new System.Drawing.Point(482, 185);
            this.ExcluirProduto.Name = "ExcluirProduto";
            this.ExcluirProduto.Size = new System.Drawing.Size(66, 23);
            this.ExcluirProduto.TabIndex = 7;
            this.ExcluirProduto.Text = "Excluir";
            this.ExcluirProduto.UseVisualStyleBackColor = true;
            this.ExcluirProduto.Click += new System.EventHandler(this.ExcluirProduto_Click);
            // 
            // dtgProdutos
            // 
            this.dtgProdutos.AllowUserToAddRows = false;
            this.dtgProdutos.AllowUserToDeleteRows = false;
            this.dtgProdutos.BackgroundColor = System.Drawing.Color.White;
            this.dtgProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.Produto,
            this.Volume,
            this.Unidade,
            this.Empresa});
            this.dtgProdutos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgProdutos.Location = new System.Drawing.Point(6, 19);
            this.dtgProdutos.Name = "dtgProdutos";
            this.dtgProdutos.RowHeadersVisible = false;
            this.dtgProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgProdutos.Size = new System.Drawing.Size(542, 160);
            this.dtgProdutos.TabIndex = 6;
            this.dtgProdutos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgProdutos_CellEnter_1);
            this.dtgProdutos.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgProdutos_CellLeave);
            this.dtgProdutos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgProdutos_CellValueChanged);
            this.dtgProdutos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgProdutos_EditingControlShowing);
            // 
            // Select
            // 
            this.Select.HeaderText = "";
            this.Select.Name = "Select";
            this.Select.Width = 20;
            // 
            // Produto
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.Produto.DefaultCellStyle = dataGridViewCellStyle1;
            this.Produto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Produto.HeaderText = "Produto";
            this.Produto.MaxDropDownItems = 100;
            this.Produto.Name = "Produto";
            this.Produto.Width = 180;
            // 
            // Volume
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Volume.DefaultCellStyle = dataGridViewCellStyle2;
            this.Volume.HeaderText = "Volume";
            this.Volume.Name = "Volume";
            this.Volume.Width = 50;
            // 
            // Unidade
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.Unidade.DefaultCellStyle = dataGridViewCellStyle3;
            this.Unidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Unidade.HeaderText = "Unidade";
            this.Unidade.Name = "Unidade";
            this.Unidade.Width = 70;
            // 
            // Empresa
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.Empresa.DefaultCellStyle = dataGridViewCellStyle4;
            this.Empresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.Width = 200;
            // 
            // chkPenDrive
            // 
            this.chkPenDrive.AutoSize = true;
            this.chkPenDrive.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPenDrive.Location = new System.Drawing.Point(12, 290);
            this.chkPenDrive.Name = "chkPenDrive";
            this.chkPenDrive.Size = new System.Drawing.Size(135, 18);
            this.chkPenDrive.TabIndex = 8;
            this.chkPenDrive.Text = "Receber Via &Pen Drive";
            this.chkPenDrive.UseVisualStyleBackColor = true;
            this.chkPenDrive.Visible = false;
            this.chkPenDrive.CheckedChanged += new System.EventHandler(this.chkPenDrive_CheckedChanged);
            // 
            // Cancelar
            // 
            this.Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancelar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelar.Location = new System.Drawing.Point(497, 286);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 10;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // Receber
            // 
            this.Receber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Receber.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Receber.Location = new System.Drawing.Point(416, 286);
            this.Receber.Name = "Receber";
            this.Receber.Size = new System.Drawing.Size(75, 23);
            this.Receber.TabIndex = 9;
            this.Receber.Text = "Receber";
            this.Receber.UseVisualStyleBackColor = true;
            this.Receber.Click += new System.EventHandler(this.Receber_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusPendrive});
            this.statusStrip1.Location = new System.Drawing.Point(0, 314);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(580, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusPendrive
            // 
            this.statusPendrive.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusPendrive.Name = "statusPendrive";
            this.statusPendrive.Size = new System.Drawing.Size(0, 17);
            // 
            // NovoCiclo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(580, 336);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Receber);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.chkPenDrive);
            this.Controls.Add(this.grpTotalProdutos);
            this.Controls.Add(this.Operador);
            this.Controls.Add(this.Responsavel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Descricao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCRG);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NovoCiclo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRG 08 - Inclui um novo ciclo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NovoCiclo_FormClosing);
            this.Load += new System.EventHandler(this.NovoCiclo_Load);
            this.grpTotalProdutos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProdutos)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCRG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Descricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Responsavel;
        private System.Windows.Forms.TextBox Operador;
        private System.Windows.Forms.GroupBox grpTotalProdutos;
        private System.Windows.Forms.Button InserirProduto;
        private System.Windows.Forms.Button ExcluirProduto;
        private System.Windows.Forms.DataGridView dtgProdutos;
        private System.Windows.Forms.CheckBox chkPenDrive;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button Receber;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusPendrive;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewComboBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Volume;
        private System.Windows.Forms.DataGridViewComboBoxColumn Unidade;
        private System.Windows.Forms.DataGridViewComboBoxColumn Empresa;
    }
}