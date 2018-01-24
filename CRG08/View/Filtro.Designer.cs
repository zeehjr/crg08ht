namespace CRG08.View
{
    partial class Filtro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filtro));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.TodosRegistros = new System.Windows.Forms.RadioButton();
            this.IntervaloMeses = new System.Windows.Forms.RadioButton();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.IntervaloData = new System.Windows.Forms.RadioButton();
            this.ListaEquipamentos = new System.Windows.Forms.ComboBox();
            this.Equipamento = new System.Windows.Forms.RadioButton();
            this.TodosEquipamentos = new System.Windows.Forms.RadioButton();
            this.Cancelar = new System.Windows.Forms.Button();
            this.Filtrar = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.TodosRegistros);
            this.panel1.Controls.Add(this.IntervaloMeses);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.IntervaloData);
            this.panel1.Location = new System.Drawing.Point(10, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 91);
            this.panel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(158, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "e";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.label1, "");
            this.helpProvider1.SetHelpString(this.label1, "Filtra ciclos em relação aos ultimos meses.");
            this.label1.Location = new System.Drawing.Point(204, 41);
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, true);
            this.label1.Size = new System.Drawing.Size(47, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "mês(es)";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.helpProvider1.SetHelpKeyword(this.comboBox1, "");
            this.helpProvider1.SetHelpString(this.comboBox1, "Filtra ciclos em relação aos ultimos meses.");
            this.comboBox1.Items.AddRange(new object[] {
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
            "12"});
            this.comboBox1.Location = new System.Drawing.Point(152, 38);
            this.comboBox1.Name = "comboBox1";
            this.helpProvider1.SetShowHelp(this.comboBox1, true);
            this.comboBox1.Size = new System.Drawing.Size(48, 22);
            this.comboBox1.TabIndex = 6;
            // 
            // TodosRegistros
            // 
            this.TodosRegistros.AutoSize = true;
            this.TodosRegistros.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.TodosRegistros, "");
            this.helpProvider1.SetHelpString(this.TodosRegistros, "Filtra ciclos utilizando todos os registros.");
            this.TodosRegistros.Location = new System.Drawing.Point(23, 63);
            this.TodosRegistros.Name = "TodosRegistros";
            this.helpProvider1.SetShowHelp(this.TodosRegistros, true);
            this.TodosRegistros.Size = new System.Drawing.Size(103, 18);
            this.TodosRegistros.TabIndex = 5;
            this.TodosRegistros.TabStop = true;
            this.TodosRegistros.Text = "Todos Registros";
            this.TodosRegistros.UseVisualStyleBackColor = true;
            // 
            // IntervaloMeses
            // 
            this.IntervaloMeses.AutoSize = true;
            this.IntervaloMeses.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.IntervaloMeses, "");
            this.helpProvider1.SetHelpString(this.IntervaloMeses, "Filtra ciclos em relação aos ultimos meses.");
            this.IntervaloMeses.Location = new System.Drawing.Point(23, 39);
            this.IntervaloMeses.Name = "IntervaloMeses";
            this.helpProvider1.SetShowHelp(this.IntervaloMeses, true);
            this.IntervaloMeses.Size = new System.Drawing.Size(133, 18);
            this.IntervaloMeses.TabIndex = 3;
            this.IntervaloMeses.TabStop = true;
            this.IntervaloMeses.Text = "Durante o(s) último(s):";
            this.IntervaloMeses.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.dateTimePicker2, "");
            this.helpProvider1.SetHelpString(this.dateTimePicker2, "Filtra ciclos entre datas.");
            this.dateTimePicker2.Location = new System.Drawing.Point(173, 12);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.helpProvider1.SetShowHelp(this.dateTimePicker2, true);
            this.dateTimePicker2.Size = new System.Drawing.Size(71, 20);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.dateTimePicker1, "");
            this.helpProvider1.SetHelpString(this.dateTimePicker1, "Filtra ciclos entre datas.");
            this.dateTimePicker1.Location = new System.Drawing.Point(82, 11);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.helpProvider1.SetShowHelp(this.dateTimePicker1, true);
            this.dateTimePicker1.Size = new System.Drawing.Size(74, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // IntervaloData
            // 
            this.IntervaloData.AutoSize = true;
            this.IntervaloData.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.IntervaloData, "");
            this.helpProvider1.SetHelpString(this.IntervaloData, "Filtra ciclos entre datas.");
            this.IntervaloData.Location = new System.Drawing.Point(23, 15);
            this.IntervaloData.Name = "IntervaloData";
            this.helpProvider1.SetShowHelp(this.IntervaloData, true);
            this.IntervaloData.Size = new System.Drawing.Size(53, 18);
            this.IntervaloData.TabIndex = 0;
            this.IntervaloData.TabStop = true;
            this.IntervaloData.Text = "Entre:";
            this.IntervaloData.UseVisualStyleBackColor = true;
            // 
            // ListaEquipamentos
            // 
            this.ListaEquipamentos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaEquipamentos.FormattingEnabled = true;
            this.helpProvider1.SetHelpKeyword(this.ListaEquipamentos, "");
            this.helpProvider1.SetHelpString(this.ListaEquipamentos, "Filtra ciclos por numero de equipamento.");
            this.ListaEquipamentos.Items.AddRange(new object[] {
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
            this.ListaEquipamentos.Location = new System.Drawing.Point(103, 44);
            this.ListaEquipamentos.Name = "ListaEquipamentos";
            this.helpProvider1.SetShowHelp(this.ListaEquipamentos, true);
            this.ListaEquipamentos.Size = new System.Drawing.Size(121, 22);
            this.ListaEquipamentos.TabIndex = 8;
            // 
            // Equipamento
            // 
            this.Equipamento.AutoSize = true;
            this.Equipamento.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.Equipamento, "");
            this.helpProvider1.SetHelpString(this.Equipamento, "Filtra ciclos por numero de equipamento.");
            this.Equipamento.Location = new System.Drawing.Point(10, 45);
            this.Equipamento.Name = "Equipamento";
            this.helpProvider1.SetShowHelp(this.Equipamento, true);
            this.Equipamento.Size = new System.Drawing.Size(86, 18);
            this.Equipamento.TabIndex = 7;
            this.Equipamento.TabStop = true;
            this.Equipamento.Text = "Equipamento";
            this.Equipamento.UseVisualStyleBackColor = true;
            this.Equipamento.CheckedChanged += new System.EventHandler(this.Equipamento_CheckedChanged);
            // 
            // TodosEquipamentos
            // 
            this.TodosEquipamentos.AutoSize = true;
            this.TodosEquipamentos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.TodosEquipamentos, "");
            this.helpProvider1.SetHelpString(this.TodosEquipamentos, "Filtra ciclos para todos os equipamentos.");
            this.TodosEquipamentos.Location = new System.Drawing.Point(10, 17);
            this.TodosEquipamentos.Name = "TodosEquipamentos";
            this.helpProvider1.SetShowHelp(this.TodosEquipamentos, true);
            this.TodosEquipamentos.Size = new System.Drawing.Size(124, 18);
            this.TodosEquipamentos.TabIndex = 6;
            this.TodosEquipamentos.TabStop = true;
            this.TodosEquipamentos.Text = "Todos Equipamentos";
            this.TodosEquipamentos.UseVisualStyleBackColor = true;
            this.TodosEquipamentos.CheckedChanged += new System.EventHandler(this.TodosEquipamentos_CheckedChanged);
            // 
            // Cancelar
            // 
            this.Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancelar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpString(this.Cancelar, "Cancela a tela de Filtros.");
            this.Cancelar.Location = new System.Drawing.Point(203, 179);
            this.Cancelar.Name = "Cancelar";
            this.helpProvider1.SetShowHelp(this.Cancelar, true);
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 11;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // Filtrar
            // 
            this.Filtrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Filtrar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpString(this.Filtrar, "Função de filtrar utilizando os parâmetros marcados acima.");
            this.Filtrar.Location = new System.Drawing.Point(122, 179);
            this.Filtrar.Name = "Filtrar";
            this.helpProvider1.SetShowHelp(this.Filtrar, true);
            this.Filtrar.Size = new System.Drawing.Size(75, 23);
            this.Filtrar.TabIndex = 10;
            this.Filtrar.Text = "Filtrar";
            this.Filtrar.UseVisualStyleBackColor = true;
            this.Filtrar.Click += new System.EventHandler(this.Filtrar_Click);
            // 
            // Filtro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(289, 214);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ListaEquipamentos);
            this.Controls.Add(this.Equipamento);
            this.Controls.Add(this.TodosEquipamentos);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Filtrar);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Filtro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtros";
            this.Load += new System.EventHandler(this.Filtro_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton TodosRegistros;
        private System.Windows.Forms.RadioButton IntervaloMeses;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton IntervaloData;
        private System.Windows.Forms.ComboBox ListaEquipamentos;
        private System.Windows.Forms.RadioButton Equipamento;
        private System.Windows.Forms.RadioButton TodosEquipamentos;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button Filtrar;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}