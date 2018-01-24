using System.Windows.Forms;

namespace CRG08.View
{
    public partial class SelectEquip : Form
    {
        public SelectEquip()
        {
            InitializeComponent();
        }

        private Monitorar monitorar;
        private int equipamento = 0;
        public SelectEquip(Monitorar monitorar, int equipamento)
        {
            InitializeComponent();
            this.monitorar = monitorar;
            this.equipamento = equipamento;
        }

        private void groupBox1_Enter(object sender, System.EventArgs e)
        {

        }

        private void SelectEquip_Load(object sender, System.EventArgs e)
        {
            cmbEquip.SelectedIndex = equipamento - 1;
            OK.Focus();
        }

        private void OK_Click(object sender, System.EventArgs e)
        {
            monitorar.ligarCRG(cmbEquip.SelectedIndex + 1);
            this.Close();
        }

        private void Cancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
