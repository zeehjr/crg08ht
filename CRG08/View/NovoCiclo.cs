using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using CRG08.BO;
using CRG08.Dao;
using CRG08.Util;
using CRG08.VO;

namespace CRG08.View
{
    public partial class NovoCiclo : Form
    {
        private bool alterar = false, Pendrive = false, cadastrando = false, finalizadas = false, fechar = false;
        private string caminhoPenDrive;
        private VO.Ciclos ciclo = new VO.Ciclos();
        private int numTrat1 = -1, numTrat2 = -1, nTrat = -1, index;
        private Historico historico;
        private Secagens secagens;
        private Thread t;
        private int crg = -1;

        public NovoCiclo()
        {
            InitializeComponent();
        }

        public NovoCiclo(bool Alterar, int nTrat, VO.Ciclos ciclo, int index, bool finalizadas)
        {
            InitializeComponent();
            this.alterar = Alterar;
            this.nTrat = nTrat;
            this.ciclo = ciclo;
            this.index = index;
            this.finalizadas = finalizadas;
        }

        public NovoCiclo(int crg, string nomeArquivo, int nTrat)
        {
            InitializeComponent();
            this.alterar = false;
            this.nTrat = nTrat;
            this.crg = crg;
            statusPendrive.Text = nomeArquivo;
            chkPenDrive.Visible = false;
            cmbCRG.Enabled = false;
        }

        public NovoCiclo(int numTrat1, int numTrat2, Secagens secagens, int index)
        {
            InitializeComponent();
            this.numTrat1 = numTrat1;
            this.numTrat2 = numTrat2;
            this.secagens = secagens;
            this.index = index;
        }

        public NovoCiclo(int numTrat1, int numTrat2, Historico historico, int index)
        {
            InitializeComponent();
            this.numTrat1 = numTrat1;
            this.numTrat2 = numTrat2;
            this.historico = historico;
            this.index = index;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            fechar = true;
            this.Close();
        }

        private void NovoCiclo_Load(object sender, EventArgs e)
        {
            if (crg == -1)
            {
                cmbCRG.SelectedIndex = ObterUltimoEquipamento() - 1;
            }
            else
            {
                cmbCRG.SelectedIndex = crg - 1;
            }
            string[] dados = ObterDadosUltimo();
            if (dados[0] != "") Operador.Text = dados[0];
            if (dados[1] != "") Responsavel.Text = dados[1];

            if (alterar && !finalizadas)
            {
                cmbCRG.Enabled = false;
                cmbCRG.SelectedIndex = index;
                //chkPenDrive.Enabled = false;
                Descricao.Text = ciclo.descricao;
                Operador.Text = ciclo.operador;
                Responsavel.Text = ciclo.responsavel;
                List<ProdutoCiclo> listaProdutos = ProdutoCicloDAO.listaProdutosCiclo(ciclo);
                List<Produto> listaProd = ProdutoDAO.retornaProdutos();
                List<EmpresaCiclo> listaEmp = EmpresaCicloDAO.retornaEmpresas();
                List<Unidade> listaUnid = UnidadeDAO.retornaUnidades();

                List<string> listaP = new List<string>();
                foreach (var p in listaProd)
                {
                    listaP.Add(p.descricao);
                }
                listaP.Add("Gerenciar Produto");

                List<string> listaU = new List<string>();
                foreach (var u in listaUnid)
                {
                    listaU.Add(u.unidade);
                }
                listaU.Add("Gerenciar Unidade");

                List<string> listaE = new List<string>();
                foreach (var em in listaEmp)
                {
                    listaE.Add(em.nome);
                }
                listaE.Add("Gerenciar Empresa");

                (dtgProdutos.Columns[1] as DataGridViewComboBoxColumn).DataSource = listaP;
                (dtgProdutos.Columns[3] as DataGridViewComboBoxColumn).DataSource = listaU;
                (dtgProdutos.Columns[4] as DataGridViewComboBoxColumn).DataSource = listaE;
                foreach (var p in listaProdutos)
                {
                    dtgProdutos.Rows.Add(false, p.produto.descricao, p.volume, p.unidade.unidade, p.empresa.nome);
                }
                Receber.Enabled = true;
            }
            else if (numTrat1 != -1)
            {
                chkPenDrive.Enabled = false;
                cmbCRG.SelectedIndex = index;
                cmbCRG.Enabled = false;
            }
            else if (finalizadas)
            {
                cmbCRG.Enabled = false;
                cmbCRG.SelectedIndex = index;
                //chkPenDrive.Enabled = false;
                Descricao.Text = ciclo.descricao;
                Operador.Text = ciclo.operador;
                Responsavel.Text = ciclo.responsavel;
                List<ProdutoCiclo> listaProdutos = ProdutoCicloDAO.listaProdutosCiclo(ciclo);
                List<Produto> listaProd = ProdutoDAO.retornaProdutos();
                List<VO.EmpresaCiclo> listaEmp = EmpresaCicloDAO.retornaEmpresas();
                List<Unidade> listaUnid = UnidadeDAO.retornaUnidades();

                List<string> listaP = new List<string>();
                foreach (var p in listaProd)
                {
                    listaP.Add(p.descricao);
                }
                listaP.Add("Gerenciar Produto");

                List<string> listaU = new List<string>();
                foreach (var u in listaUnid)
                {
                    listaU.Add(u.unidade);
                }
                listaU.Add("Gerenciar Unidade");

                List<string> listaE = new List<string>();
                foreach (var em in listaEmp)
                {
                    listaE.Add(em.nome);
                }
                listaE.Add("Gerenciar Empresa");

                (dtgProdutos.Columns[1] as DataGridViewComboBoxColumn).DataSource = listaP;
                (dtgProdutos.Columns[3] as DataGridViewComboBoxColumn).DataSource = listaU;
                (dtgProdutos.Columns[4] as DataGridViewComboBoxColumn).DataSource = listaE;
                foreach (var p in listaProdutos)
                {
                    dtgProdutos.Rows.Add(false, p.produto.descricao, p.volume, p.unidade.unidade, p.empresa.nome);
                }
                chkPenDrive.Enabled = false;
                Receber.Enabled = true;
                Receber.Text = "Salvar";
                ExcluirProduto.Enabled = true;
            }
        }

        private void chkPenDrive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPenDrive.Checked)
            {
                var drives = //DriveInfo.GetDrives();
                    DriveInfo.GetDrives().Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable);

                if (drives.Count() == 0)
                    MessageBox.Show("Nenhum pen drive encontrado. Insira um pendrive com secagens a serem salvas",
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (drives.Count() > 1)
                {
                    List<String> unidades = new List<string>();
                    foreach (var driveInfo in drives)
                    {
                        unidades.Add(driveInfo.Name);
                    }
                    string equip = String.Format("{0:00}", cmbCRG.SelectedItem);
                    if (alterar)
                    {
                        frmPenDrive pendrive = new frmPenDrive(true, this, unidades, equip, ciclo.nTrat);
                        pendrive.ShowDialog(this);
                    }
                    else
                    {
                        frmPenDrive pendrive = new frmPenDrive(false, this, unidades, equip, -1);
                        pendrive.ShowDialog(this);
                    }
                }
                else
                {
                    string unidade = "";
                    foreach (var driveInfo in drives)
                    {
                        unidade = driveInfo.Name;
                    }
                    string equip = String.Format("{0:00}", cmbCRG.SelectedItem);
                    string caminho = unidade + "CRG" + equip;
                    DirectoryInfo Dir = new DirectoryInfo(@"" + caminho);
                    if (Dir.Exists)
                    {
                        if (alterar)
                        {
                            FileInfo[] Files = Dir.GetFiles("SEC" + ciclo.nTrat + ".TRT", SearchOption.AllDirectories);

                            frmPenDrive pendrive = new frmPenDrive(true, Files, this, unidade, equip, ciclo.nTrat);
                            pendrive.ShowDialog(this);
                        }
                        else
                        {
                            FileInfo[] Files = Dir.GetFiles("*.TRT", SearchOption.AllDirectories);

                            frmPenDrive pendrive = new frmPenDrive(false, Files, this, unidade, equip, -1);
                            pendrive.ShowDialog(this);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel localizar a pasta do CRG nº " + equip +
                                        ". Verifique a existência da pasta CRG" + equip + " no pen drive inserido.",
                            "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                statusPendrive.Text = "";
            }
        }

        private void Receber_Click(object sender, EventArgs e)
        {
            bool ok = false;

            if (dtgProdutos.Rows.Count > 0)
            {
                for (int i = 0; i < dtgProdutos.Rows.Count; i++)
                {
                    if (dtgProdutos.Rows[i].Cells[1].Value.ToString() != "" &&
                        dtgProdutos.Rows[i].Cells[2].Value.ToString() != "" &&
                        dtgProdutos.Rows[i].Cells[3].Value.ToString() != "" &&
                        dtgProdutos.Rows[i].Cells[4].Value.ToString() != "" &&
                        Descricao.Text != "" &&
                        Operador.Text != "" &&
                        Responsavel.Text != "" &&
                        cmbCRG.Text != "")
                    {
                        ok = true;
                    }
                    else
                    {
                        i = dtgProdutos.RowCount;
                        ok = false;
                    }
                }
            }
            if (ok && dtgProdutos.Rows.Count > 0)
            {
                if (Receber.Text == "Receber")
                {
                    List<ProdutoCiclo> listaProdutos = new List<ProdutoCiclo>();
                    for (int i = 0; i < dtgProdutos.RowCount; i++)
                    {
                        ProdutoCiclo produtoCiclo = new ProdutoCiclo();
                        produtoCiclo.produto = new Produto();
                        produtoCiclo.produto.descricao = dtgProdutos.Rows[i].Cells[1].Value.ToString();
                        produtoCiclo.produto.idProduto = ProdutoDAO.retornarIDProduto(produtoCiclo.produto.descricao);
                        produtoCiclo.volume = dtgProdutos.Rows[i].Cells[2].Value.ToString();
                        produtoCiclo.unidade = new Unidade();
                        produtoCiclo.unidade.unidade = dtgProdutos.Rows[i].Cells[3].Value.ToString();
                        produtoCiclo.unidade.idUnidade = UnidadeDAO.retornaID(produtoCiclo.unidade.unidade);
                        produtoCiclo.empresa = new VO.EmpresaCiclo();
                        produtoCiclo.empresa.nome = dtgProdutos.Rows[i].Cells[4].Value.ToString();
                        produtoCiclo.empresa.idEmpresa = EmpresaCicloDAO.retornaID(produtoCiclo.empresa.nome);
                        listaProdutos.Add(produtoCiclo);
                    }

                    ciclo.crg = cmbCRG.SelectedIndex + 1;
                    ciclo.descricao = Descricao.Text;
                    ciclo.operador = Operador.Text;
                    ciclo.responsavel = Responsavel.Text;

                    if (statusPendrive.Text != "")
                    {
                        DirectoryInfo Dir = new DirectoryInfo(@"" + statusPendrive.Text.Substring(0, 9));
                        if (Dir.Exists)
                        {
                            var arquivo = Dir.GetFiles()
                                .Single(x => x.Name.Equals(statusPendrive.Text.Substring(9, 10)));
                            Conexao.buffer = File.ReadAllBytes(arquivo.FullName);
                            if (Conexao.buffer.Length == 0)
                            {
                                MessageBox.Show("Arquivo informado não é um arquivo de tratamento válido.", "Erro!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            int checksum = 0;
                            for (int i = 0; i < Conexao.buffer.Length - 2; i++) checksum ^= Conexao.buffer[i];
                            //Verifica integridade do pacote
                            if (checksum == Conexao.buffer[Conexao.buffer.Length - 2])
                            {
                                bool crg150 = true;
                                // Se antigo
                                if (Conexao.buffer[Conexao.buffer.Length - 1] == 19)
                                {
                                    int aux = Conexao.buffer.Length - 22;
                                    ciclo.numSerie = ((char)Conexao.buffer[aux + 12]).ToString() +
                                                     ((char)Conexao.buffer[aux + 13]).ToString() +
                                                     ((char)Conexao.buffer[aux + 14]).ToString() +
                                                     ((char)Conexao.buffer[aux + 15]).ToString() +
                                                     ((char)Conexao.buffer[aux + 16]).ToString() +
                                                     ((char)Conexao.buffer[aux + 17]).ToString() +
                                                     ((char)Conexao.buffer[aux + 18]).ToString() +
                                                     ((char)Conexao.buffer[aux + 19]).ToString();

                                    string dataInicio = string.Concat((Conexao.buffer[6] / 16), (Conexao.buffer[6] % 16)) +
                                                        "/" +
                                                        string.Concat((Conexao.buffer[7] / 16), (Conexao.buffer[7] % 16)) +
                                                        "/20" +
                                                        string.Concat((Conexao.buffer[8] / 16), (Conexao.buffer[8] % 16)) +
                                                        " " +
                                                        string.Concat((Conexao.buffer[4] / 16), (Conexao.buffer[4] % 16)) +
                                                        ":" +
                                                        string.Concat((Conexao.buffer[3] / 16), (Conexao.buffer[3] % 16));
                                    ciclo.dataInicio = Convert.ToDateTime(dataInicio);
                                    ciclo.nTrat = (Conexao.buffer[5] * 256) + Conexao.buffer[2];
                                    ciclo.dataColeta = DateTime.Now;
                                    ciclo.versaoEquip = "100";
                                }
                                //Se novo 102ºC
                                else if (Conexao.buffer[Conexao.buffer.Length - 1] == 23)
                                {
                                    int aux = Conexao.buffer.Length - 10;
                                    ciclo.numSerie = ((char)Conexao.buffer[aux]).ToString() +
                                                     ((char)Conexao.buffer[aux + 1]).ToString() +
                                                     ((char)Conexao.buffer[aux + 2]).ToString() +
                                                     ((char)Conexao.buffer[aux + 3]).ToString() +
                                                     ((char)Conexao.buffer[aux + 4]).ToString() +
                                                     ((char)Conexao.buffer[aux + 5]).ToString() +
                                                     ((char)Conexao.buffer[aux + 6]).ToString() +
                                                     ((char)Conexao.buffer[aux + 7]).ToString();
                                    string dataInicio = string.Concat((Conexao.buffer[7] / 16), (Conexao.buffer[7] % 16)) +
                                                        "/" +
                                                        string.Concat((Conexao.buffer[8] / 16), (Conexao.buffer[8] % 16)) +
                                                        "/20" +
                                                        string.Concat((Conexao.buffer[9] / 16), (Conexao.buffer[9] % 16)) +
                                                        " " +
                                                        string.Concat((Conexao.buffer[5] / 16), (Conexao.buffer[5] % 16)) +
                                                        ":" +
                                                        string.Concat((Conexao.buffer[4] / 16), (Conexao.buffer[4] % 16));
                                    ciclo.dataInicio = Convert.ToDateTime(dataInicio);
                                    ciclo.nTrat = (Conexao.buffer[0] * 256) + Conexao.buffer[1];
                                    ciclo.dataColeta = DateTime.Now;
                                    ciclo.versaoEquip = "100";
                                }
                                //Se novo 150ºC
                                else if (Conexao.buffer[Conexao.buffer.Length - 1] == 22)
                                {
                                    int aux = Conexao.buffer.Length - 10;
                                    ciclo.numSerie = ((char)Conexao.buffer[aux]).ToString() +
                                                     ((char)Conexao.buffer[aux + 1]).ToString() +
                                                     ((char)Conexao.buffer[aux + 2]).ToString() +
                                                     ((char)Conexao.buffer[aux + 3]).ToString() +
                                                     ((char)Conexao.buffer[aux + 4]).ToString() +
                                                     ((char)Conexao.buffer[aux + 5]).ToString() +
                                                     ((char)Conexao.buffer[aux + 6]).ToString() +
                                                     ((char)Conexao.buffer[aux + 7]).ToString();
                                    string dataInicio = string.Concat((Conexao.buffer[7] / 16), (Conexao.buffer[7] % 16)) +
                                                        "/" +
                                                        string.Concat((Conexao.buffer[8] / 16), (Conexao.buffer[8] % 16)) +
                                                        "/20" +
                                                        string.Concat((Conexao.buffer[9] / 16), (Conexao.buffer[9] % 16)) +
                                                        " " +
                                                        string.Concat((Conexao.buffer[5] / 16), (Conexao.buffer[5] % 16)) +
                                                        ":" +
                                                        string.Concat((Conexao.buffer[4] / 16), (Conexao.buffer[4] % 16));
                                    ciclo.dataInicio = Convert.ToDateTime(dataInicio);
                                    ciclo.nTrat = (Conexao.buffer[0] * 256) + Conexao.buffer[1];
                                    ciclo.dataColeta = DateTime.Now;
                                    ciclo.versaoEquip = "150";
                                }
                                bool retorno = false;

                                VO.Ciclos existe = CicloDAO.testaCicloExistente(ciclo);

                                if (existe != null)
                                {
                                    int nl = (Conexao.buffer[2] * 256) + Conexao.buffer[3];
                                    if (existe.nl != nl)
                                    {
                                        alterar = true;
                                    }
                                    else
                                    {
                                        alterar = false;
                                    }
                                }

                                if (!alterar && existe == null) // Se não existe o ciclo no BD, ele insere
                                {


                                    //Versão antiga só 102ºC
                                    if (Conexao.buffer[Conexao.buffer.Length - 1] == 19)
                                    {
                                        retorno = ConexaoBO.EnviaBancodeDadosAntigo(ciclo, Conexao.buffer, false,
                                            listaProdutos, 0, 0);
                                    }
                                    //Versão Nova  até 102ºC
                                    else if (Conexao.buffer[Conexao.buffer.Length - 1] == 23)
                                    {
                                        retorno = ConexaoBO.EnviaBancodeDados(ciclo, Conexao.buffer, false,
                                            listaProdutos, 0,
                                            0, false);
                                    }
                                    //Versão Nova até 150ºC
                                    else if (Conexao.buffer[Conexao.buffer.Length - 1] == 22)
                                    {
                                        retorno = ConexaoBO.EnviaBancodeDados(ciclo, Conexao.buffer, false,
                                            listaProdutos, 0,
                                            0, true);
                                    }



                                    if (retorno)
                                    {
                                        if (ciclo.crg != ObterUltimoEquipamento()) AtualizaUltimoEquipamento(ciclo.crg);
                                        MessageBox.Show("Ciclo adicionado com sucesso", "Sucesso", MessageBoxButtons.OK,
                                            MessageBoxIcon.None);
                                    }
                                }
                                else if (alterar) // Existe o ciclo no BD, mas existem leituras novas
                                {
                                    ciclo.id = existe.id;
                                    int indiceLeitCiclo = LeiturasCicloDAO.retornaQtdeLeituras(ciclo.id, ciclo.crg);
                                    int indiceLeitTrat = LeiturasTratDAO.retornaQtdeLeituras(ciclo.id, ciclo.crg);
                                    //Aparelho antigo só até 102ºC
                                    if (Conexao.buffer[Conexao.buffer.Length - 1] == 19)
                                    {
                                        retorno = ConexaoBO.EnviaBancodeDadosAntigo(ciclo, Conexao.buffer, true,
                                            listaProdutos, indiceLeitCiclo, indiceLeitTrat);
                                    }
                                    //Aparelho novo até 102ºC
                                    else if (Conexao.buffer[Conexao.buffer.Length - 1] == 23)
                                    {
                                        retorno = ConexaoBO.EnviaBancodeDados(ciclo, Conexao.buffer, true, listaProdutos,
                                            indiceLeitCiclo, indiceLeitTrat, false);
                                    }
                                    //Aparelho novo até 150ºC
                                    else if (Conexao.buffer[Conexao.buffer.Length - 1] == 22)
                                    {
                                        retorno = ConexaoBO.EnviaBancodeDados(ciclo, Conexao.buffer, true, listaProdutos,
                                            indiceLeitCiclo, indiceLeitTrat, true);
                                    }
                                    if (retorno)
                                        MessageBox.Show("Ciclo atualizado com sucesso", "Sucesso!", MessageBoxButtons.OK,
                                            MessageBoxIcon.None);
                                }
                                else
                                {
                                    MessageBox.Show("Ciclo já está atualizado!", "Atenção!", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                                }
                                if (retorno)
                                {
                                    AtualizaUltimo(Operador.Text, Responsavel.Text);
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Algum erro ocorreu ao tentar receber o ciclo!", "Erro!", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                    Close();
                                }
                            }
                            else
                                MessageBox.Show("Erro no checksum.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        t = new Thread(new ThreadStart(carregarAguarde));
                        t.Start();

                        string porta = ConfiguracaoDAO.retornaPorta();
                        bool continua = false;

                        var srpComm = new SerialPort(porta, 19200, Parity.None, 8, StopBits.One);
                        srpComm.DtrEnable = true;
                        srpComm.RtsEnable = false;
                        srpComm.ReadBufferSize = 100000;
                        srpComm.WriteBufferSize = 100000;

                        Conexao.srpComm = srpComm;
                        try
                        {
                            Conexao.srpComm.Open();
                            Thread.Sleep(100);

                            int numBytes = 0;
                            int aux = (cmbCRG.SelectedIndex + 1) + 63;
                            Conexao.srpComm.Write(((char)19).ToString());
                            Thread.Sleep(100);
                            Conexao.srpComm.Write(((char)17).ToString());
                            Thread.Sleep(100);
                            Conexao.srpComm.Write(((char)aux).ToString());
                            Thread.Sleep(100);

                            if (Conexao.srpComm.BytesToRead != 0)
                            {
                                numBytes = byte.Parse(Conexao.srpComm.BytesToRead.ToString());
                                Conexao.buffer = new byte[numBytes];
                                Conexao.srpComm.Read(Conexao.buffer, 0, numBytes);
                            }
                            continua = true;
                            int contador = 0;
                            int versaoEquip = Conexao.buffer[0];

                            if (continua)
                                //Verifica se é aparelho novo(102ºC ou 150ºC) ou antigo(só 102ºC)
                                switch (versaoEquip)
                                {
                                    //Versao 150ºC Nova
                                    case 167:
                                        if (alterar)
                                        {
                                            string binario = decimalParaBinario(nTrat);
                                            numTrat1 = binarioParaDecimal(binario.Substring(0, 8));
                                            numTrat2 = binarioParaDecimal(binario.Substring(8, 8));
                                        }
                                        Conexao.srpComm.Write(((char)5).ToString());
                                        Thread.Sleep(100);

                                        if (numTrat1 != -1)
                                        {
                                            Conexao.srpComm.Write(((char)numTrat1).ToString());
                                            Thread.Sleep(100);
                                            Conexao.srpComm.Write(((char)numTrat2).ToString());
                                            Thread.Sleep(8000);
                                        }
                                        else
                                        {
                                            Conexao.srpComm.Write(((char)0).ToString());
                                            Thread.Sleep(100);
                                            Conexao.srpComm.Write(((char)0).ToString());
                                            Thread.Sleep(8000);
                                        }

                                        contador = 0;
                                        do
                                        {
                                            if (Conexao.srpComm.BytesToRead != 0)
                                            {
                                                numBytes = int.Parse(Conexao.srpComm.BytesToRead.ToString());
                                                Conexao.buffer = new byte[numBytes];
                                                Conexao.srpComm.Read(Conexao.buffer, 0, numBytes);
                                            }
                                            contador++;
                                        } while (Conexao.srpComm.BytesToRead != 0);

                                        int checksum = 0;
                                        //Verifica se o ciclo ainda está na memória do equipamento

                                        if (Conexao.buffer.Length > 2)
                                        {
                                            for (int i = 0; i < Conexao.buffer.Length - 2; i++)
                                                checksum ^= Conexao.buffer[i];
                                            if (checksum == Conexao.buffer[Conexao.buffer.Length - 2])
                                            {
                                                int aux2 = Conexao.buffer.Length - 10;
                                                ciclo.numSerie = ((char)Conexao.buffer[aux2]).ToString() +
                                                                 ((char)Conexao.buffer[aux2 + 1]).ToString() +
                                                                 ((char)Conexao.buffer[aux2 + 2]).ToString() +
                                                                 ((char)Conexao.buffer[aux2 + 3]).ToString() +
                                                                 ((char)Conexao.buffer[aux2 + 4]).ToString() +
                                                                 ((char)Conexao.buffer[aux2 + 5]).ToString() +
                                                                 ((char)Conexao.buffer[aux2 + 6]).ToString() +
                                                                 ((char)Conexao.buffer[aux2 + 7]).ToString();
                                                ciclo.nTrat = (Conexao.buffer[0] * 256) + Conexao.buffer[1];
                                                string dataInicio =
                                                    string.Concat((Conexao.buffer[7] / 16), (Conexao.buffer[7] % 16)) +
                                                    "/" +
                                                    string.Concat((Conexao.buffer[8] / 16), (Conexao.buffer[8] % 16)) +
                                                    "/20" +
                                                    string.Concat((Conexao.buffer[9] / 16), (Conexao.buffer[9] % 16)) +
                                                    " " +
                                                    string.Concat((Conexao.buffer[5] / 16), (Conexao.buffer[5] % 16)) +
                                                    ":" +
                                                    string.Concat((Conexao.buffer[4] / 16), (Conexao.buffer[4] % 16));
                                                ciclo.dataInicio = Convert.ToDateTime(dataInicio);
                                                ciclo.dataColeta = DateTime.Now;
                                            }
                                            else
                                            {
                                                t.Abort();
                                                MessageBox.Show("Erro no checksum.", "Erro", MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information);
                                            }
                                        }
                                        else
                                        {
                                            t.Abort();
                                            MessageBox.Show("O ciclo não está mais na memória do equipamento", "Erro",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                                        }
                                        break;
                                    //Versão 102ºC versão Nova
                                    case 166:
                                        if (alterar)
                                        {
                                            string binario = decimalParaBinario(nTrat);
                                            numTrat1 = binarioParaDecimal(binario.Substring(0, 8));
                                            numTrat2 = binarioParaDecimal(binario.Substring(8, 8));
                                        } Conexao.srpComm.Write(((char)5).ToString());
                                        Thread.Sleep(100);

                                        if (numTrat1 != -1)
                                        {
                                            Conexao.srpComm.Write(((char)numTrat1).ToString());
                                            Thread.Sleep(100);
                                            Conexao.srpComm.Write(((char)numTrat2).ToString());
                                            Thread.Sleep(8000);
                                        }
                                        else
                                        {
                                            Conexao.srpComm.Write(((char)0).ToString());
                                            Thread.Sleep(100);
                                            Conexao.srpComm.Write(((char)0).ToString());
                                            Thread.Sleep(8000);
                                        }

                                        contador = 0;
                                        do
                                        {
                                            if (Conexao.srpComm.BytesToRead != 0)
                                            {
                                                numBytes = int.Parse(Conexao.srpComm.BytesToRead.ToString());
                                                Conexao.buffer = new byte[numBytes];
                                                Conexao.srpComm.Read(Conexao.buffer, 0, numBytes);
                                            }
                                            contador++;
                                        } while (Conexao.srpComm.BytesToRead != 0);

                                        int checksum2 = 0;
                                        //Verifica se o ciclo ainda está na memória do equipamento
                                        if (Conexao.buffer.Length > 2)
                                        {
                                            for (int i = 0; i < Conexao.buffer.Length - 2; i++)
                                                checksum2 ^= Conexao.buffer[i];
                                            if (checksum2 == Conexao.buffer[Conexao.buffer.Length - 2])
                                            {
                                                int aux2 = Conexao.buffer.Length - 10;
                                                ciclo.numSerie = ((char)Conexao.buffer[aux2]).ToString() +
                                                                 ((char)Conexao.buffer[aux2 + 1]).ToString() +
                                                                 ((char)Conexao.buffer[aux2 + 2]).ToString() +
                                                                 ((char)Conexao.buffer[aux2 + 3]).ToString() +
                                                                 ((char)Conexao.buffer[aux2 + 4]).ToString() +
                                                                 ((char)Conexao.buffer[aux2 + 5]).ToString() +
                                                                 ((char)Conexao.buffer[aux2 + 6]).ToString() +
                                                                 ((char)Conexao.buffer[aux2 + 7]).ToString();
                                                ciclo.nTrat = (Conexao.buffer[0] * 256) + Conexao.buffer[1];
                                                string dataInicio =
                                                    string.Concat((Conexao.buffer[7] / 16), (Conexao.buffer[7] % 16)) +
                                                    "/" +
                                                    string.Concat((Conexao.buffer[8] / 16), (Conexao.buffer[8] % 16)) +
                                                    "/20" +
                                                    string.Concat((Conexao.buffer[9] / 16), (Conexao.buffer[9] % 16)) +
                                                    " " +
                                                    string.Concat((Conexao.buffer[5] / 16), (Conexao.buffer[5] % 16)) +
                                                    ":" +
                                                    string.Concat((Conexao.buffer[4] / 16), (Conexao.buffer[4] % 16));
                                                ciclo.dataInicio = Convert.ToDateTime(dataInicio);
                                                ciclo.dataColeta = DateTime.Now;
                                            }
                                            else
                                            {
                                                t.Abort();
                                                MessageBox.Show("Erro no checksum.", "Erro", MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information);
                                            }
                                        }
                                        else
                                        {
                                            t.Abort();
                                            MessageBox.Show("O ciclo não está mais na memória do equipamento", "Erro",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        break;
                                    //Versão equipamento antigo só pode 102ºC
                                    case 165:
                                        Conexao.srpComm.Write(((char)6).ToString());
                                        Thread.Sleep(8000);

                                        int cont = 0;
                                        do
                                        {
                                            if (Conexao.srpComm.BytesToRead != 0)
                                            {
                                                numBytes = int.Parse(Conexao.srpComm.BytesToRead.ToString());
                                                Conexao.buffer = new byte[numBytes];
                                                Conexao.srpComm.Read(Conexao.buffer, 0, numBytes);
                                            }
                                            cont++;
                                        } while (Conexao.srpComm.BytesToRead != 0);

                                        int chk = 0;
                                        for (int i = 0; i < Conexao.buffer.Length - 2; i++) chk ^= Conexao.buffer[i];
                                        if (Conexao.buffer.Length > 1)
                                        {
                                            if (((Conexao.buffer[5] * 256) + Conexao.buffer[2]) == nTrat)
                                            {
                                                if (chk == Conexao.buffer[Conexao.buffer.Length - 2])
                                                {
                                                    int aux2 = Conexao.buffer.Length - 10;
                                                    ciclo.numSerie = ((char)Conexao.buffer[aux2]).ToString() +
                                                                     ((char)Conexao.buffer[aux2 + 1]).ToString() +
                                                                     ((char)Conexao.buffer[aux2 + 2]).ToString() +
                                                                     ((char)Conexao.buffer[aux2 + 3]).ToString() +
                                                                     ((char)Conexao.buffer[aux2 + 4]).ToString() +
                                                                     ((char)Conexao.buffer[aux2 + 5]).ToString() +
                                                                     ((char)Conexao.buffer[aux2 + 6]).ToString() +
                                                                     ((char)Conexao.buffer[aux2 + 7]).ToString();
                                                    ciclo.nTrat = (Conexao.buffer[5] * 256) + Conexao.buffer[2];
                                                    string dataInicio =
                                                        string.Concat((Conexao.buffer[6] / 16), (Conexao.buffer[6] % 16)) +
                                                        "/" +
                                                        string.Concat((Conexao.buffer[7] / 16), (Conexao.buffer[7] % 16)) +
                                                        "/20" +
                                                        string.Concat((Conexao.buffer[8] / 16), (Conexao.buffer[8] % 16)) +
                                                        " " +
                                                        string.Concat((Conexao.buffer[4] / 16), (Conexao.buffer[4] % 16)) +
                                                        ":" +
                                                        string.Concat((Conexao.buffer[3] / 16), (Conexao.buffer[3] % 16));
                                                    ciclo.dataInicio = Convert.ToDateTime(dataInicio);
                                                    ciclo.dataColeta = DateTime.Now;
                                                }
                                                else
                                                {
                                                    t.Abort();
                                                    MessageBox.Show("Ciclo não está mais no histórico.", "Erro",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    this.Close();
                                                }
                                            }
                                        }
                                        break;
                                    default:
                                        t.Abort();
                                        MessageBox.Show("Não foi possivel comunicar com o equipamento.", "Erro",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                                        break;
                                }

                            bool retorno = false;

                            VO.Ciclos existe = CicloDAO.testaCicloExistente(ciclo);

                            if (existe != null)
                            {
                                int nl = (Conexao.buffer[2] * 256) + Conexao.buffer[3];
                                if (existe.nl != nl)
                                {
                                    alterar = true;
                                }
                                else
                                {
                                    alterar = false;
                                }
                            }

                            if (!alterar && existe == null) // Insere NOVO Ciclo -`Não existe no BD
                            {

                                //ciclo.id = existe.id;
                                switch (versaoEquip)
                                {
                                    case 167:
                                        retorno = ConexaoBO.EnviaBancodeDados(ciclo, Conexao.buffer, false,
                                        listaProdutos, 0, 0, true);
                                        break;
                                    case 166:
                                        retorno = ConexaoBO.EnviaBancodeDados(ciclo, Conexao.buffer, false,
                                        listaProdutos, 0, 0, false);
                                        break;
                                    case 165:
                                        retorno = ConexaoBO.EnviaBancodeDadosAntigo(ciclo, Conexao.buffer, false,
                                        listaProdutos, 0, 0);
                                        break;
                                }
                                if (retorno)
                                {
                                    t.Abort();
                                    MessageBox.Show("Ciclo adicionado com sucesso", "Sucesso",
                                        MessageBoxButtons.OK, MessageBoxIcon.None);
                                }
                            }
                            else if (alterar) // Ciclo existente no Banco de dados, com leituras novas!
                            {
                                ciclo.id = existe.id;
                                int indiceLeitCiclo = LeiturasCicloDAO.retornaQtdeLeituras(ciclo.id,
                                    ciclo.crg);
                                int indiceLeitTrat = LeiturasTratDAO.retornaQtdeLeituras(ciclo.id,
                                    ciclo.crg);

                                switch (versaoEquip)
                                {
                                    case 167:
                                        retorno = ConexaoBO.EnviaBancodeDados(ciclo, Conexao.buffer, true,
                                        listaProdutos, indiceLeitCiclo, indiceLeitTrat, true);
                                        break;
                                    case 166:
                                        retorno = ConexaoBO.EnviaBancodeDados(ciclo, Conexao.buffer, true,
                                        listaProdutos, indiceLeitCiclo, indiceLeitTrat, false);
                                        break;
                                    case 165:
                                        retorno = ConexaoBO.EnviaBancodeDadosAntigo(ciclo, Conexao.buffer, true,
                                                            listaProdutos, indiceLeitCiclo, indiceLeitTrat);
                                        break;
                                }
                                if (retorno)
                                {
                                    t.Abort();
                                    MessageBox.Show("Ciclo alterado com sucesso!", "Sucesso!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else // Ciclo existente no banco de dados, SEM leituras novas - não necessário atualizar
                            {
                                t.Abort();
                                MessageBox.Show("Ciclo já está atualizado!", "Aviso!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            }
                            this.Close();
                        }
                        catch (Exception error)
                        {
                            t.Abort();
                            VO.LogErro logErro = new VO.LogErro();
                            logErro.crg = cmbCRG.SelectedIndex + 1;
                            logErro.descricao = "Erro ao tentar receber o ciclo";
                            logErro.maisDetalhes = error.Message + " " + error.StackTrace;
                            logErro.data = DateTime.Now;
                            LogErroDAO.inserirLogErro(logErro, logErro.crg);
                            MessageBox.Show("Erro ao tentar receber o ciclo.", "Erro", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        Conexao.srpComm.Close();
                    }
                }
                else if (Receber.Text == "Salvar")
                {
                    ciclo.descricao = Descricao.Text;
                    ciclo.operador = Operador.Text;
                    ciclo.responsavel = Responsavel.Text;

                    List<ProdutoCiclo> listaProdutos = new List<ProdutoCiclo>();
                    for (int i = 0; i < dtgProdutos.RowCount; i++)
                    {
                        ProdutoCiclo produtoCiclo = new ProdutoCiclo();
                        produtoCiclo.produto = new Produto();
                        produtoCiclo.produto.descricao = dtgProdutos.Rows[i].Cells[1].Value.ToString();
                        produtoCiclo.produto.idProduto = ProdutoDAO.retornarIDProduto(produtoCiclo.produto.descricao);
                        produtoCiclo.volume = dtgProdutos.Rows[i].Cells[2].Value.ToString();
                        produtoCiclo.unidade = new Unidade();
                        produtoCiclo.unidade.unidade = dtgProdutos.Rows[i].Cells[3].Value.ToString();
                        produtoCiclo.unidade.idUnidade = UnidadeDAO.retornaID(produtoCiclo.unidade.unidade);
                        produtoCiclo.empresa = new VO.EmpresaCiclo();
                        produtoCiclo.empresa.nome = dtgProdutos.Rows[i].Cells[4].Value.ToString();
                        produtoCiclo.empresa.idEmpresa = EmpresaCicloDAO.retornaID(produtoCiclo.empresa.nome);
                        listaProdutos.Add(produtoCiclo);
                    }

                    CicloDAO.alteraCiclo(ciclo);
                    ProdutoCicloDAO.DeletaProdutosCiclo(ciclo.id, ciclo.crg);
                    for (int i = 0; i < listaProdutos.Count; i++)
                    {
                        listaProdutos[i].ciclo = ciclo;
                        ProdutoCicloDAO.inserirProdutoCiclo(listaProdutos[i]);
                    }

                    MessageBox.Show("Ciclo alterado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Preencher todos os campos para receber o tratamento!", "Erro!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        public void recebeArquivoSelecionadoPenDrive(string caminho)
        {
            caminhoPenDrive = caminho;
            statusPendrive.Text = caminho;
        }

        public void AlterarReceberPendrive()
        {
            caminhoPenDrive = "";
            statusPendrive.Text = "";
            chkPenDrive.Checked = false;
        }

        private void InserirProduto_Click(object sender, EventArgs e)
        {
            List<VO.Produto> listaProdutos = ProdutoDAO.retornaProdutos();
            List<VO.Unidade> listaUnidades = UnidadeDAO.retornaUnidades();
            List<VO.EmpresaCiclo> listaEmpresas = EmpresaCicloDAO.retornaEmpresas();

            List<string> listaP = new List<string>();
            foreach (var p in listaProdutos)
            {
                listaP.Add(p.descricao);
            }
            listaP.Add("Gerenciar Produto");

            List<string> listaU = new List<string>();
            foreach (var u in listaUnidades)
            {
                listaU.Add(u.unidade);
            }
            listaU.Add("Gerenciar Unidade");

            List<string> listaE = new List<string>();
            foreach (var em in listaEmpresas)
            {
                listaE.Add(em.nome);
            }
            listaE.Add("Gerenciar Empresa");

            (dtgProdutos.Columns[1] as DataGridViewComboBoxColumn).DataSource = listaP;
            (dtgProdutos.Columns[3] as DataGridViewComboBoxColumn).DataSource = listaU;
            (dtgProdutos.Columns[4] as DataGridViewComboBoxColumn).DataSource = listaE;


            dtgProdutos.Rows.Add(true, "", "", "", "");
            ExcluirProduto.Enabled = true;
        }

        private void ColumnComboSelectionChanged(object sender, EventArgs e)
        {
            if (dtgProdutos.CurrentCell.ColumnIndex == 1)
            {
                var value =
                    (dtgProdutos.Rows[dtgProdutos.CurrentRow.Index].Cells["Produto"] as DataGridViewComboBoxCell)
                        .EditedFormattedValue.ToString();
                if (value == "Gerenciar Produto")
                {
                    if (!cadastrando)
                    {
                        CadastroGenerico cadastro = new CadastroGenerico("Produto");
                        cadastro.ShowDialog(this);
                    }
                    cadastrando = true;
                    List<VO.Produto> listaProdutos = ProdutoDAO.retornaProdutos(cmbCRG.SelectedIndex + 1);
                    List<string> listaP = new List<string>();
                    foreach (var p in listaProdutos)
                    {
                        listaP.Add(p.descricao);
                    }
                    listaP.Add("Gerenciar Produto");

                    (dtgProdutos.Columns[1] as DataGridViewComboBoxColumn).DataSource = listaP;
                }
                //Thread.Sleep(100);
                cadastrando = false;
            }

            if (dtgProdutos.CurrentCell.ColumnIndex == 3)
            {
                var value =
                    (dtgProdutos.Rows[dtgProdutos.CurrentRow.Index].Cells["Unidade"] as DataGridViewComboBoxCell)
                        .EditedFormattedValue.ToString();
                if (value == "Gerenciar Unidade")
                {
                    if (!cadastrando)
                    {
                        CadastroGenerico cadastro = new CadastroGenerico("Unidade");
                        cadastro.ShowDialog(this);
                    }
                    cadastrando = true;
                    List<VO.Unidade> listaUnidades = UnidadeDAO.retornaUnidades((int)cmbCRG.SelectedIndex + 1);
                    List<string> listaU = new List<string>();
                    foreach (var u in listaUnidades)
                    {
                        listaU.Add(u.unidade);
                    }
                    listaU.Add("Gerenciar Unidade");
                    (dtgProdutos.Columns[3] as DataGridViewComboBoxColumn).DataSource = listaU;
                }

                cadastrando = false;
            }

            if (dtgProdutos.CurrentCell.ColumnIndex == 4)
            {
                var value =
                    (dtgProdutos.Rows[dtgProdutos.CurrentRow.Index].Cells["Empresa"] as DataGridViewComboBoxCell)
                        .EditedFormattedValue.ToString();

                if (value == "Gerenciar Empresa")
                {
                    if (!cadastrando)
                    {
                        CadastroGenerico cadastro = new CadastroGenerico("Empresa");
                        cadastro.ShowDialog(this);
                    }
                    cadastrando = true;
                    List<VO.EmpresaCiclo> listaEmpresas = EmpresaCicloDAO.retornaEmpresas();
                    List<string> listaE = new List<string>();
                    foreach (var em in listaEmpresas)
                    {
                        listaE.Add(em.nome);
                    }
                    listaE.Add("Gerenciar Empresa");

                    (dtgProdutos.Columns[4] as DataGridViewComboBoxColumn).DataSource = listaE;
                }

                cadastrando = false;
            }
        }

        private void dtgProdutos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column2_KeyPress);
            if (dtgProdutos.CurrentCell.ColumnIndex == 1 && e.Control is ComboBox)
            {
                ComboBox combo = e.Control as ComboBox;
                combo.SelectedIndexChanged += ColumnComboSelectionChanged;
            }

            if (dtgProdutos.CurrentCell.ColumnIndex == 3 && e.Control is ComboBox)
            {
                ComboBox combo = e.Control as ComboBox;
                combo.SelectedIndexChanged += ColumnComboSelectionChanged;
            }

            if (dtgProdutos.CurrentCell.ColumnIndex == 4 && e.Control is ComboBox)
            {
                ComboBox combo = e.Control as ComboBox;
                combo.SelectedIndexChanged += ColumnComboSelectionChanged;
            }

            if (dtgProdutos.CurrentCell.ColumnIndex == 2 && e.Control is TextBox)
            {
                var txt = e.Control as TextBox;
                txt.KeyPress += new KeyPressEventHandler(Column2_KeyPress);
            }
            e.CellStyle.BackColor = Color.White;
        }

        private void Column2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public bool AtualizaUltimo(string operador, string responsavel)
        {
            try
            {
                return UltimosDAO.SetarUltimoOperador(operador) &&
                    UltimosDAO.SetarUltimoResponsavel(responsavel);
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao atualizar dados de Operador e Responsavel";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao atualizar dados de Operador e Responsavel", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
        }

        private string[] ObterDadosUltimo()
        {
            try
            {
                string[] retorno = new string[2];
                retorno[0] = UltimosDAO.RetornaUltimoOperador();
                retorno[1] = UltimosDAO.RetornaUltimoResponsavel();
                return retorno;
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao obter dados de Operador e Responsavel";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao obter dados de Operador e Responsavel", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return new string[2] { "", "" };
            }
        }

        private void dtgProdutos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1); //Make sure the clicked row/column is valid.
            var datagridview = sender as DataGridView;

            // Check to make sure the cell clicked is the cell containing the combobox 
            if (datagridview.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && validClick)
            {
                datagridview.BeginEdit(true);
                ((ComboBox)datagridview.EditingControl).DroppedDown = true;
                //((ComboBox)datagridview.EditingControl).BackColor = Color.White;
            }
        }

        private void ExcluirProduto_Click(object sender, EventArgs e)
        {
            List<int> indicesExcluir = new List<int>();
            for (int i = 0; i < dtgProdutos.Rows.Count; i++)
                if ((bool)dtgProdutos.Rows[i].Cells[0].Value) indicesExcluir.Add(i);

            if (indicesExcluir.Count < dtgProdutos.Rows.Count)
            {
                if (MessageBox.Show("Deseja continuar excluindo o(s) produto(s)?", "Atenção", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    for (int i = indicesExcluir.Count; i > 0; i--)
                        dtgProdutos.Rows.RemoveAt(indicesExcluir[i - 1]);
                }
            }
            else
                MessageBox.Show("Não é possivel excluir todos os produtos.", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        public void VerificaReceber()
        {

            bool ok = Descricao.Text != "" && Operador.Text != "" && Responsavel.Text != "";

            if (dtgProdutos.Rows.Count > 0)
            {
                for (int i = 0; i < dtgProdutos.Rows.Count; i++)
                {
                    if (dtgProdutos.Rows[i].Cells[1].Value.ToString() != "" &&
                        dtgProdutos.Rows[i].Cells[2].Value.ToString() != "" &&
                        dtgProdutos.Rows[i].Cells[3].Value.ToString() != "" &&
                        dtgProdutos.Rows[i].Cells[4].Value.ToString() != "")
                    {
                        ok = true;
                    }
                    else
                    {
                        i = dtgProdutos.RowCount;
                        ok = false;
                    }
                }
            }
            if (ok == true && dtgProdutos.Rows.Count > 0) Receber.Enabled = true;
        }

        private void Descricao_TextChanged(object sender, EventArgs e)
        {
            if (!fechar) VerificaReceber();
        }

        private void Responsavel_TextChanged(object sender, EventArgs e)
        {
            if (!fechar) VerificaReceber();
        }

        private void Operador_TextChanged(object sender, EventArgs e)
        {
            if (!fechar) VerificaReceber();
        }

        private void cmbCRG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fechar) VerificaReceber();
        }


        private void dtgProdutos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (!fechar) VerificaReceber();
        }

        private void dtgProdutos_CurrentCellChanged(object sender, EventArgs e)
        {
            if (!fechar) VerificaReceber();
            //if (!fechar) VerificaReceber();
            /*if (dtgProdutos.Rows[dtgProdutos.Rows.Count - 1].Cells[2].Value != "")
            {
                Decimal aux = Convert.ToDecimal(String.Format("{0:n2}",
                    dtgProdutos.Rows[dtgProdutos.Rows.Count - 1].Cells[2].Value));
                dtgProdutos.Rows[dtgProdutos.Rows.Count - 1].Cells[2].Value = aux.ToString();
            }*/
        }

        public static string decimalParaBinario(int numero)
        {
            string valor = "";
            int cont = 8;
            int dividendo = Convert.ToInt32(numero);

            while (valor.Length < 16)
            {
                valor += Convert.ToString(dividendo % 2);

                dividendo = dividendo / 2;
            }

            return inverterString(valor);
        }

        public static string inverterString(string str)
        {
            int tamanho = str.Length;

            char[] caracteres = new char[tamanho];

            for (int i = 0; i < tamanho; i++)
            {
                if (!(tamanho - i > str.Length))
                {
                    caracteres[i] = str[tamanho - 1 - i];
                }
                else
                {
                    caracteres[i] = '0';
                }
            }
            return new string(caracteres);
        }

        public static int binarioParaDecimal(string valorBinario)
        {
            int expoente = 0;
            int numero;
            int soma = 0;
            string numeroInvertido = inverterString(valorBinario);

            for (int i = 0; i < numeroInvertido.Length; i++)
            {
                numero = Convert.ToInt32(numeroInvertido.Substring(i, 1));
                soma += numero * (int)Math.Pow(2, expoente);
                expoente++;
            }
            return soma;
        }

        public void carregarAguarde()
        {
            // Carrega uma thread paralela com o Carregar
            Invoke(new MethodInvoker(() =>
            {
                Carregar carregar = new Carregar();
                carregar.ShowDialog(this);
            }));
        }

        private int ObterUltimoEquipamento()
        {
            return UltimosDAO.RetornaUltimoEquipamento();
        }

        public bool AtualizaUltimoEquipamento(int equipamento)
        {
            try
            {
                return UltimosDAO.SetarUltimoEquipamento(equipamento);
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao atualizar dados do equipamento";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao atualizar dados do equipamento", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
        }

        private void NovoCiclo_FormClosing(object sender, FormClosingEventArgs e)
        {
            fechar = true;
            Application.OpenForms["Ciclos"].Activate();
        }

        private void dtgProdutos_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            var dg = (DataGridView) sender;
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1);
            if (dg.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && validClick)
            {
                dg.BeginEdit(true);
                var cb = ((ComboBox) dg.EditingControl);
                cb.DroppedDown = true;
            }
        }

        private void dtgProdutos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            var dg = (DataGridView) sender;
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1);
            if (dg.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewComboBoxCell && validClick)
            {
                var cb = ((DataGridViewComboBoxCell)dg.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                if (String.IsNullOrWhiteSpace(cb.Value.ToString()))
                {
                    if (cb.Items.Count > 1)
                    {
                        cb.Value = cb.Items[0];
                    }
                }
            }
        }
    }
}
