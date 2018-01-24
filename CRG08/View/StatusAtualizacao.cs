using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CRG08.View
{
    public partial class StatusAtualizacao : Form
    {
        private readonly List<String> lista;

        public StatusAtualizacao(List<String> Mensagens)
        {
            InitializeComponent();
            this.lista = Mensagens;
        }

        public StatusAtualizacao()
        {
            InitializeComponent();
        }

        private void StatusAtualizacao_Load(object sender, EventArgs e)
        {
            button1.Focus();
            if (lista.Count > 0)
            {
                foreach (var m in lista)
                {
                    if (m != null) listBox1.Items.Add(m);
                }
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
