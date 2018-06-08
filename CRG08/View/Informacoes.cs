using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRG08.View
{
    public partial class Informacoes : Form
    {
        public Informacoes()
        {
            InitializeComponent();
        }

        private void Informacoes_Load(object sender, EventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fileInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            var version = fileInfo.FileVersion;
            var modifiedDate = File.GetLastWriteTime(assembly.Location).ToString("dd/MM/yyyy");
            //Versao.Text = "Versão " + Application.ProductVersion + " (" + (File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location).ToString("dd/MM/yyyy")) + ") -  EPROM 8.6 OU 9.6 - 29/08/2017 ";
            Versao.Text = $"Versão {version} ({modifiedDate}) - EPROM 8.6 OU 9.6 - 29/08/2017";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
