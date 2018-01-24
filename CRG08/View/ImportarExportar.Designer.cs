namespace CRG08.View
{
    partial class ImportarExportar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportarExportar));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Andamento = new System.Windows.Forms.TabPage();
            this.dtgAndamento = new System.Windows.Forms.DataGridView();
            this.Selecionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataColeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InicioCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Finalizados = new System.Windows.Forms.TabPage();
            this.dtgFinalizados = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IDF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NLTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importar = new System.Windows.Forms.RadioButton();
            this.Exportar = new System.Windows.Forms.RadioButton();
            this.Email = new System.Windows.Forms.Button();
            this.Arquivo = new System.Windows.Forms.Button();
            this.Sair = new System.Windows.Forms.Button();
            this.salvarCiclo = new System.Windows.Forms.SaveFileDialog();
            this.abrirCiclo = new System.Windows.Forms.OpenFileDialog();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.tabControl1.SuspendLayout();
            this.Andamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAndamento)).BeginInit();
            this.Finalizados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFinalizados)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Andamento);
            this.tabControl1.Controls.Add(this.Finalizados);
            this.tabControl1.Location = new System.Drawing.Point(12, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(619, 305);
            this.tabControl1.TabIndex = 8;
            // 
            // Andamento
            // 
            this.Andamento.Controls.Add(this.dtgAndamento);
            this.Andamento.Location = new System.Drawing.Point(4, 22);
            this.Andamento.Name = "Andamento";
            this.Andamento.Padding = new System.Windows.Forms.Padding(3);
            this.Andamento.Size = new System.Drawing.Size(611, 279);
            this.Andamento.TabIndex = 0;
            this.Andamento.Text = "Ciclos em Andamento";
            this.Andamento.UseVisualStyleBackColor = true;
            // 
            // dtgAndamento
            // 
            this.dtgAndamento.AllowUserToAddRows = false;
            this.dtgAndamento.AllowUserToDeleteRows = false;
            this.dtgAndamento.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgAndamento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgAndamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAndamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selecionar,
            this.ID,
            this.crg,
            this.NSerie,
            this.Trat,
            this.NL,
            this.NLT,
            this.DataColeta,
            this.InicioCiclo,
            this.Descricao});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgAndamento.DefaultCellStyle = dataGridViewCellStyle10;
            this.dtgAndamento.Location = new System.Drawing.Point(1, 2);
            this.dtgAndamento.Name = "dtgAndamento";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgAndamento.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dtgAndamento.RowHeadersVisible = false;
            this.dtgAndamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAndamento.Size = new System.Drawing.Size(608, 274);
            this.dtgAndamento.TabIndex = 6;
            // 
            // Selecionar
            // 
            this.Selecionar.HeaderText = "";
            this.Selecionar.Name = "Selecionar";
            this.Selecionar.Width = 20;
            // 
            // ID
            // 
            this.ID.HeaderText = "";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // crg
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crg.DefaultCellStyle = dataGridViewCellStyle2;
            this.crg.HeaderText = "CRG";
            this.crg.Name = "crg";
            this.crg.Width = 35;
            // 
            // NSerie
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NSerie.DefaultCellStyle = dataGridViewCellStyle3;
            this.NSerie.HeaderText = "Nº Série";
            this.NSerie.Name = "NSerie";
            this.NSerie.Width = 70;
            // 
            // Trat
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Trat.DefaultCellStyle = dataGridViewCellStyle4;
            this.Trat.HeaderText = "NTrat";
            this.Trat.Name = "Trat";
            this.Trat.Width = 40;
            // 
            // NL
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NL.DefaultCellStyle = dataGridViewCellStyle5;
            this.NL.HeaderText = "NL";
            this.NL.Name = "NL";
            this.NL.Width = 35;
            // 
            // NLT
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NLT.DefaultCellStyle = dataGridViewCellStyle6;
            this.NLT.HeaderText = "NLT";
            this.NLT.Name = "NLT";
            this.NLT.Width = 35;
            // 
            // DataColeta
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataColeta.DefaultCellStyle = dataGridViewCellStyle7;
            this.DataColeta.HeaderText = "Data Coleta";
            this.DataColeta.Name = "DataColeta";
            this.DataColeta.Width = 115;
            // 
            // InicioCiclo
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InicioCiclo.DefaultCellStyle = dataGridViewCellStyle8;
            this.InicioCiclo.HeaderText = "Inicio Ciclo";
            this.InicioCiclo.Name = "InicioCiclo";
            this.InicioCiclo.Width = 115;
            // 
            // Descricao
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descricao.DefaultCellStyle = dataGridViewCellStyle9;
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.Width = 135;
            // 
            // Finalizados
            // 
            this.Finalizados.Controls.Add(this.dtgFinalizados);
            this.Finalizados.Location = new System.Drawing.Point(4, 22);
            this.Finalizados.Name = "Finalizados";
            this.Finalizados.Padding = new System.Windows.Forms.Padding(3);
            this.Finalizados.Size = new System.Drawing.Size(611, 279);
            this.Finalizados.TabIndex = 1;
            this.Finalizados.Text = "Ciclos Finalizados";
            this.Finalizados.UseVisualStyleBackColor = true;
            // 
            // dtgFinalizados
            // 
            this.dtgFinalizados.AllowUserToAddRows = false;
            this.dtgFinalizados.AllowUserToDeleteRows = false;
            this.dtgFinalizados.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgFinalizados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dtgFinalizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFinalizados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.IDF,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.NLTT,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgFinalizados.DefaultCellStyle = dataGridViewCellStyle21;
            this.dtgFinalizados.Location = new System.Drawing.Point(1, 2);
            this.dtgFinalizados.Name = "dtgFinalizados";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgFinalizados.RowHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dtgFinalizados.RowHeadersVisible = false;
            this.dtgFinalizados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgFinalizados.Size = new System.Drawing.Size(608, 274);
            this.dtgFinalizados.TabIndex = 7;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 20;
            // 
            // IDF
            // 
            this.IDF.HeaderText = "";
            this.IDF.Name = "IDF";
            this.IDF.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn1.HeaderText = "CRG";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 35;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn2.HeaderText = "Nº Série";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn3.HeaderText = "NTrat";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 40;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn4.HeaderText = "NL";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 35;
            // 
            // NLTT
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NLTT.DefaultCellStyle = dataGridViewCellStyle17;
            this.NLTT.HeaderText = "NLT";
            this.NLTT.Name = "NLTT";
            this.NLTT.Width = 35;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn5.HeaderText = "Data Coleta";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 115;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTextBoxColumn6.HeaderText = "Inicio Ciclo";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 115;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn7.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 135;
            // 
            // Importar
            // 
            this.Importar.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.Importar, "");
            this.helpProvider1.SetHelpString(this.Importar, "importa ciclos em andamento ou finalizados.");
            this.Importar.Location = new System.Drawing.Point(82, 12);
            this.Importar.Name = "Importar";
            this.helpProvider1.SetShowHelp(this.Importar, true);
            this.Importar.Size = new System.Drawing.Size(63, 17);
            this.Importar.TabIndex = 2;
            this.Importar.Text = "Importar";
            this.Importar.UseVisualStyleBackColor = true;
            // 
            // Exportar
            // 
            this.Exportar.AutoSize = true;
            this.Exportar.Checked = true;
            this.helpProvider1.SetHelpKeyword(this.Exportar, "");
            this.helpProvider1.SetHelpString(this.Exportar, "Exporta ciclos em andamento ou finalizados.");
            this.Exportar.Location = new System.Drawing.Point(12, 12);
            this.Exportar.Name = "Exportar";
            this.helpProvider1.SetShowHelp(this.Exportar, true);
            this.Exportar.Size = new System.Drawing.Size(64, 17);
            this.Exportar.TabIndex = 1;
            this.Exportar.TabStop = true;
            this.Exportar.Text = "Exportar";
            this.Exportar.UseVisualStyleBackColor = true;
            this.Exportar.CheckedChanged += new System.EventHandler(this.Exportar_CheckedChanged);
            // 
            // Email
            // 
            this.Email.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.helpProvider1.SetHelpKeyword(this.Email, "");
            this.helpProvider1.SetHelpString(this.Email, "Envia o arquivo exportado para um e-mail já configurado.");
            this.Email.Location = new System.Drawing.Point(363, 345);
            this.Email.Name = "Email";
            this.helpProvider1.SetShowHelp(this.Email, true);
            this.Email.Size = new System.Drawing.Size(84, 38);
            this.Email.TabIndex = 3;
            this.Email.Text = "Enviar por Email";
            this.Email.UseVisualStyleBackColor = true;
            this.Email.Click += new System.EventHandler(this.Email_Click);
            // 
            // Arquivo
            // 
            this.Arquivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.helpProvider1.SetHelpKeyword(this.Arquivo, "");
            this.helpProvider1.SetHelpString(this.Arquivo, "Salva arquivo exportado em local definido pelo operador.");
            this.Arquivo.Location = new System.Drawing.Point(453, 345);
            this.Arquivo.Name = "Arquivo";
            this.helpProvider1.SetShowHelp(this.Arquivo, true);
            this.Arquivo.Size = new System.Drawing.Size(84, 38);
            this.Arquivo.TabIndex = 4;
            this.Arquivo.Text = "Salvar como Arquivo";
            this.Arquivo.UseVisualStyleBackColor = true;
            this.Arquivo.Click += new System.EventHandler(this.Arquivo_Click);
            // 
            // Sair
            // 
            this.Sair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.helpProvider1.SetHelpKeyword(this.Sair, "");
            this.helpProvider1.SetHelpString(this.Sair, "Função sair, não salva alterações.");
            this.Sair.Location = new System.Drawing.Point(543, 345);
            this.Sair.Name = "Sair";
            this.helpProvider1.SetShowHelp(this.Sair, true);
            this.Sair.Size = new System.Drawing.Size(84, 38);
            this.Sair.TabIndex = 5;
            this.Sair.Text = "Sair";
            this.Sair.UseVisualStyleBackColor = true;
            this.Sair.Click += new System.EventHandler(this.Sair_Click);
            // 
            // abrirCiclo
            // 
            this.abrirCiclo.FileName = "openFileDialog1";
            // 
            // ImportarExportar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(641, 393);
            this.Controls.Add(this.Sair);
            this.Controls.Add(this.Arquivo);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Exportar);
            this.Controls.Add(this.Importar);
            this.Controls.Add(this.tabControl1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportarExportar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar/Exportar";
            this.Load += new System.EventHandler(this.ImportarExportar_Load);
            this.tabControl1.ResumeLayout(false);
            this.Andamento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAndamento)).EndInit();
            this.Finalizados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFinalizados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Andamento;
        private System.Windows.Forms.TabPage Finalizados;
        private System.Windows.Forms.RadioButton Importar;
        private System.Windows.Forms.RadioButton Exportar;
        private System.Windows.Forms.Button Email;
        private System.Windows.Forms.Button Arquivo;
        private System.Windows.Forms.Button Sair;
        private System.Windows.Forms.SaveFileDialog salvarCiclo;
        private System.Windows.Forms.OpenFileDialog abrirCiclo;
        private System.Windows.Forms.DataGridView dtgAndamento;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selecionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn crg;
        private System.Windows.Forms.DataGridViewTextBoxColumn NSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trat;
        private System.Windows.Forms.DataGridViewTextBoxColumn NL;
        private System.Windows.Forms.DataGridViewTextBoxColumn NLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataColeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn InicioCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridView dtgFinalizados;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDF;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn NLTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.HelpProvider helpProvider1;

    }
}