using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using CRG08.Dao;
using CRG08.Util;
using CRG08.VO;

namespace CRG08.View
{
    public partial class Ciclos : Form
    {
        private Principal principal;
        private Thread t;
        public Ciclos(Principal principal)
        {
            InitializeComponent();
            this.principal = principal;
        }

        public Ciclos()
        {
            InitializeComponent();
        }

        private int equip = -1, qtdeMeses = -1, selecao = -1;
        private string dataInicio = "", dataFim = "";
        
        private void Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Relatorios_Click(object sender, EventArgs e)
        {
            if (tabCiclos.TabPages[tabCiclos.SelectedIndex].Name == "CiclosAndamento")
            {
                var checados = DtgChecked(dtgAndamento);
                if (checados.Count == 1)
                {
                    var relatorio = new DetalhesCiclo(Convert.ToInt32(checados[0].Cells[1].Value),
                        Convert.ToInt32(checados[0].Cells[2].Value));
                    relatorio.ShowDialog(this);
                }
                else if (checados.Count == 0)
                {
                    MessageBox.Show("Não há nenhum ciclo selecionado! Por favor, selecione um ciclo.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Você possui atualmente " + checados.Count +
                        " ciclos selecionados! Por favor, selecione apenas 1.", "Atenção", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                var checados = DtgChecked(dtgFinalizados);
                if (checados.Count == 1)
                {
                    var relatorio = new DetalhesCiclo(Convert.ToInt32(checados[0].Cells[1].Value),
                        Convert.ToInt32(checados[0].Cells[2].Value));
                    relatorio.ShowDialog(this);
                }
                else if (checados.Count == 0)
                {
                    MessageBox.Show("Não há nenhum ciclo selecionado! Por favor, selecione um ciclo.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Você possui atualmente " + checados.Count +
                        " ciclos selecionados! Por favor, selecione apenas 1.", "Atenção", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void Novo_Click(object sender, EventArgs e)
        {
            principal.ParaAtualizacao();
            NovoCiclo novoCiclo = new NovoCiclo();
            novoCiclo.ShowDialog(this);
            CarregaCiclos();
            principal.RetomaAtualizacao();
        }

        private void Alterar_Click(object sender, EventArgs e)
        {
            if (Atualizar.Text == "Atualizar")
            {
                var frmTipoCom = new frmSelecionarMeioComunicacao();
                frmTipoCom.ShowDialog(this);
                var tipoCom = frmTipoCom.comunicacao;
                if (string.IsNullOrWhiteSpace(tipoCom)) return;
                MessageBox.Show(tipoCom);
                return;


                int[] atualizacao = ConfiguracaoDAO.RetornaAtualizacao();
                Configuracao config = new Configuracao();
                config.atualizacao = atualizacao[0];
                if (config.atualizacao == 1)
                {
                    var checados = DtgChecked(dtgAndamento);
                    if (checados.Count > 0)
                    {
                        foreach (var item in checados)
                        {
                            var ciclo = CicloDAO.buscaCiclo(Convert.ToInt32(item.Cells[2].Value),
                                Convert.ToInt32(item.Cells[1].Value));
                            var novoCiclo = new NovoCiclo(true, Convert.ToInt32(item.Cells[4].Value), ciclo,
                                Convert.ToInt32(item.Cells[2].Value) - 1, false);
                            novoCiclo.ShowDialog(this);
                        }
                        CarregaCiclos();
                    }
                    else
                    {
                        MessageBox.Show("Não há nenhum ciclo selecionado!", "Atenção", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    /*for (int i = 0; i < dtgAndamento.Rows.Count; i++)
                    {
                        var rows = dtgAndamento.Rows;
                        if ((bool) dtgAndamento.Rows[i].Cells[0].Value)
                        {
                            VO.Ciclos ciclo = CicloDAO.buscaCiclo(Convert.ToInt32(dtgAndamento.Rows[i].Cells[2].Value),
                                Convert.ToInt32(dtgAndamento.Rows[i].Cells[1].Value));
                            NovoCiclo novoCiclo = new NovoCiclo(true,Convert.ToInt32(dtgAndamento.Rows[i].Cells[4].Value),
                                ciclo, Convert.ToInt32(dtgAndamento.Rows[i].Cells[2].Value) - 1, false);
                            novoCiclo.ShowDialog(this);
                        }
                    }*/
                    
                }
            }
            else
            {
                var checados = DtgChecked(dtgFinalizados);
                if (checados.Count > 0)
                {
                    foreach (var item in checados)
                    {
                        var ciclo = CicloDAO.buscaCiclo(Convert.ToInt32(item.Cells[2].Value),
                            Convert.ToInt32(item.Cells[1].Value));
                        var novoCiclo = new NovoCiclo(true, Convert.ToInt32(item.Cells[4].Value), ciclo,
                            Convert.ToInt32(item.Cells[2].Value) - 1, false);
                        novoCiclo.ShowDialog(this);
                    }
                    CarregaCiclos();
                }
                else
                {
                    MessageBox.Show("Não há nenhum ciclo selecionado!", "Atenção", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                }
            }
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            principal.ParaAtualizacao();
            Historico historico = new Historico(this);
            historico.ShowDialog(this);
            principal.RetomaAtualizacao();
        }

        private void Ciclos_Load(object sender, EventArgs e)
        {
            int[] atualizacao = ConfiguracaoDAO.RetornaAtualizacao();
            Configuracao config = new Configuracao();
            config.atualizacao = atualizacao[0];
            if (config.atualizacao == 3 || config.atualizacao == 4) Atualizar.Enabled = false;
            CarregaCiclos();
        }

        public void CarregaCiclos()
        {
            string[] filtro = ObterDadosFiltro();
            dtgAndamento.Rows.Clear();
            dtgFinalizados.Rows.Clear();
            List<VO.Ciclos> CiclosAndamento = CicloDAO.listaCiclosPorSituacaoAll(0);

            foreach (var c in CiclosAndamento)
            {
                dtgAndamento.Rows.Add(false, c.id, c.crg, c.numSerie, c.nTrat.ToString("000"), c.nl.ToString("000"),
                    c.nlt.ToString("000"), c.dataColeta, c.dataInicio, c.descricao);
            }

            //selecao = int.Parse(filtro[0]);
            if (selecao == 4)
            {
                int crg = int.Parse(filtro[3]);
                List<VO.Ciclos> CiclosFinalizados = CicloDAO.listaCiclosPorSituacaoEq(crg,1);
                foreach (var c in CiclosFinalizados)
                {
                    dtgFinalizados.Rows.Add(false, c.id, c.crg, c.numSerie, c.nTrat.ToString("000"),
                        c.nl.ToString("000"), c.nlt.ToString("000"), c.dataColeta, c.dataInicio, c.descricao);
                }
            }
            else if (selecao == 3)
            {
                int crg = int.Parse(filtro[3]);
                int mes = int.Parse(filtro[4]);
                List<VO.Ciclos> CiclosFinalizados = CicloDAO.listaCiclosPorSituacaoMes(crg, 1, -mes);
                foreach (var c in CiclosFinalizados)
                {
                    dtgFinalizados.Rows.Add(false, c.id, c.crg, c.numSerie, c.nTrat.ToString("000"),
                        c.nl.ToString("000"), c.nlt.ToString("000"), c.dataColeta, c.dataInicio, c.descricao);
                }
            }
            else if (selecao == 2)
            {
                int crg = int.Parse(filtro[3]);
                string dataInicio = filtro[1];
                string dataFim = filtro[2];
                List<VO.Ciclos> CiclosFinalizados = CicloDAO.listaCiclosPorSituacaoEntre(crg, 1, Convert.ToDateTime(dataInicio), Convert.ToDateTime(dataFim));
                foreach (var c in CiclosFinalizados)
                {
                    dtgFinalizados.Rows.Add(false, c.id, c.crg, c.numSerie, c.nTrat.ToString("000"),
                        c.nl.ToString("000"), c.nlt.ToString("000"), c.dataColeta, c.dataInicio, c.descricao);
                }
            }
            else
            {
                List<VO.Ciclos> CiclosFinalizados = CicloDAO.listaCiclosPorSituacaoAll(1);
                foreach (var c in CiclosFinalizados)
                {
                    dtgFinalizados.Rows.Add(false, c.id, c.crg, c.numSerie, c.nTrat.ToString("000"),
                        c.nl.ToString("000"), c.nlt.ToString("000"), c.dataColeta, c.dataInicio, c.descricao);
                }
            }
        }

        private void Excluir_Click(object sender, EventArgs e)
        {
            var checados = new List<DataGridViewRow>();
            if (tabCiclos.SelectedIndex == 0)
            {
                checados = DtgChecked(dtgAndamento);
            }
            else
            {
                checados = DtgChecked(dtgFinalizados);
            }
            if (checados.Count > 0)
            {
                if (MessageBox.Show("Deseja excluir o(s) ciclo(s) selecionado(s)?", "Atenção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    foreach (var item in checados)
                    {
                        VO.LogMudanca log = new VO.LogMudanca();
                        log.descricao = "O tratamento nº " + Convert.ToInt32(item.Cells[4].Value) +
                                        " do CRG nº " +
                                        Convert.ToInt32(item.Cells[2].Value) + " iniciado no dia " +
                                        item.Cells[8].Value +
                                        " foi excluído";
                        log.crg = Convert.ToInt32(item.Cells[2].Value);
                        log.data = DateTime.Now;
                        string[] dados = ObterDadosUltimo();
                        log.responsavel = dados[1];
                        LogMudancaDAO.insereLogMudanca(log);

                        LeiturasCicloDAO.DeletaLeiturasCiclo(Convert.ToInt32(item.Cells[1].Value),
                            Convert.ToInt32(item.Cells[2].Value));
                        LeiturasTratDAO.DeletaLeiturasTratamento(Convert.ToInt32(item.Cells[1].Value),
                            Convert.ToInt32(item.Cells[2].Value));
                        ProdutoCicloDAO.DeletaProdutosCiclo(Convert.ToInt32(item.Cells[1].Value),
                            Convert.ToInt32(item.Cells[2].Value));
                        CicloDAO.DeletaCiclo(Convert.ToInt32(item.Cells[1].Value),
                            Convert.ToInt32(item.Cells[2].Value));
                    }
                    CarregaCiclos();
                }
            }
            else
            {
                MessageBox.Show("Não há nenhum ciclo selecionado!", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void Finalizar_Click(object sender, EventArgs e)
        {
            if (Finalizar.Text == "Enviar Finalizadas")
            {
                var checados = DtgChecked(dtgAndamento);
                if (checados.Count > 0)
                {
                    if (MessageBox.Show("Deseja continuar a enviar os ciclos para finalizadas?", "Atenção",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        foreach (var item in checados)
                        {
                            CicloDAO.alteraSituacao(Convert.ToInt32(item.Cells[2].Value),
                                Convert.ToInt32(item.Cells[1].Value));
                        }
                        CarregaCiclos();
                    }
                }
                else
                {
                    MessageBox.Show("Não há nenhum ciclo selecionado!", "Atenção", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                var filtro = new Filtro(this);
                filtro.ShowDialog(this);
            }
        }

        private void tabCiclos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabCiclos.SelectedIndex >= 0)
            {
                if (tabCiclos.TabPages[tabCiclos.SelectedIndex].Name == "CiclosFinalizados")
                {
                    Atualizar.Text = "Alterar";
                    Finalizar.Text = "Filtrar";
                }
                else if (tabCiclos.TabPages[tabCiclos.SelectedIndex].Name == "CiclosAndamento")
                {
                    Atualizar.Text = "Atualizar";
                    Finalizar.Text = "Enviar Finalizadas";
                    int[] atualizacao = ConfiguracaoDAO.RetornaAtualizacao();
                    Configuracao config = new Configuracao();
                    config.atualizacao = atualizacao[0];
                    if (config.atualizacao == 3 || config.atualizacao == 4) Atualizar.Enabled = false;
                }
            }
        }
        

        private string[] ObterDadosUltimo()
        {
            try
            {
                var path = Environment.CurrentDirectory + "\\Ultimos.xml";
                var stream = new MemoryStream();
                var xmlDocument = new XmlDocument();
                var cspParams = new CspParameters();

                cspParams.KeyContainerName = "Ultimo";
                var rsaKey = new RSACryptoServiceProvider(cspParams);

                xmlDocument.PreserveWhitespace = true;
                xmlDocument.Load(path);

                Crypto.Decrypt(xmlDocument, rsaKey, "rsaKey");

                xmlDocument.Save(stream);
                stream.Flush();
                stream.Position = 0;

                XDocument doc = XDocument.Load(stream);
                var ult = doc.Element("Ultimos").Element("ultimo");
                string[] retorno = new string[2];
                retorno[0] = ult.Element("Operador").Value;
                retorno[1] = ult.Element("Responsavel").Value;
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

        public void carregarAguarde()
        {
            // Carrega uma thread paralela com o Carregar
            Carregar carregar = new Carregar();
            carregar.ShowDialog(this);
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

        public bool AtualizaUltimo(string operador, string responsavel)
        {
            try
            {
                string path = Environment.CurrentDirectory + "\\Ultimos.xml";
                var stream = new MemoryStream();
                var xmlDocument = new XmlDocument();
                var cspParams = new CspParameters();

                cspParams.KeyContainerName = "Ultimo";
                var rsaKey = new RSACryptoServiceProvider(cspParams);

                xmlDocument.PreserveWhitespace = true;
                xmlDocument.Load(path);

                Crypto.Decrypt(xmlDocument, rsaKey, "rsaKey");

                xmlDocument.Save(stream);
                stream.Flush();
                stream.Position = 0;

                XDocument doc = XDocument.Load(stream);
                var ult = from ultimo in doc.Element("Ultimos").Elements("ultimo") select ultimo;
                foreach (var ut in ult.Where(x => x.Element("Id").Value.Equals((1).ToString())))
                {
                    ut.Element("Operador").Value = operador;
                    ut.Element("Responsavel").Value = responsavel;
                    doc.Save(path);
                }
                return true;
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
            finally
            {
                var xmlDoc = new XmlDocument();
                string path = Environment.CurrentDirectory + "\\Ultimos.xml";
                try
                {
                    xmlDoc.PreserveWhitespace = true;
                    xmlDoc.Load(path);
                }
                catch (Exception er)
                {
                    Console.WriteLine(er.Message);
                }

                var cspParams = new CspParameters();
                cspParams.KeyContainerName = "Ultimo";

                var rsaKey = new RSACryptoServiceProvider(cspParams);

                try
                {
                    Crypto.Encrypt(xmlDoc, "Ultimos", "ultimo", rsaKey, "rsaKey");
                    xmlDoc.Save(path);
                }
                catch (Exception er)
                {
                    VO.LogErro logErro = new VO.LogErro();
                    logErro.crg = 0;
                    logErro.descricao = "Erro ao tentar encriptografar Ultimo";
                    logErro.data = DateTime.Now;
                    logErro.maisDetalhes = er.Message;
                    LogErroDAO.inserirLogErro(logErro, 0);
                }
            }
        }

        private string[] ObterDadosFiltro()
        {
            try
            {
                var path = Environment.CurrentDirectory + "\\Ultimos.xml";
                var stream = new MemoryStream();
                var xmlDocument = new XmlDocument();
                var cspParams = new CspParameters();

                cspParams.KeyContainerName = "Ultimo";
                var rsaKey = new RSACryptoServiceProvider(cspParams);

                xmlDocument.PreserveWhitespace = true;
                xmlDocument.Load(path);

                Crypto.Decrypt(xmlDocument, rsaKey, "rsaKey");

                xmlDocument.Save(stream);
                stream.Flush();
                stream.Position = 0;

                XDocument doc = XDocument.Load(stream);
                var ult = doc.Element("Ultimos").Element("ultimo");
                string[] retorno = new string[5];
                retorno[0] = ult.Element("ValorFiltro").Value;
                retorno[1] = ult.Element("DataInicio").Value;
                retorno[2] = ult.Element("DataFim").Value;
                retorno[3] = ult.Element("Equipamento").Value;
                retorno[4] = ult.Element("QtdeMeses").Value;
                return retorno;
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao obter dados do filtro";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao obter dados do filtro", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return new string[2] { "", "" };
            }
        }

        private void dtgAndamento_DataSourceChanged(object sender, EventArgs e)
        {
            
        }

        private List<DataGridViewRow> DtgChecked(DataGridView dtg)
        {
            if (dtg.RowCount > 0)
            {
                var checados = dtg.Rows.Cast<DataGridViewRow>().Where(r => (bool) r.Cells[0].Value);
                return checados.ToList();
            }
            return new List<DataGridViewRow>();
        }

        private void dtgAndamento_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dtgAndamento_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }

        private void dtgAndamento_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
        }

        

        private void dtgFinalizados_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dtgFinalizados_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }

        private void dtgFinalizados_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
        }

        private void dtgAndamento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            if (rowIndex == -1) return;
            var colIndex = e.ColumnIndex;
            if (colIndex == -1) return;

            if (colIndex == 0)
            {
                dtgAndamento.CommitEdit(DataGridViewDataErrorContexts.Commit);
                var cb = (bool) dtgAndamento.Rows[rowIndex].Cells[0].Value;
                if (DtgChecked(dtgAndamento).Count == 1)
                {
                    toggleBotoesDtgAndamento(true);
                }
                else
                {
                    toggleBotoesDtgAndamento(false);
                }
            }
        }

        private void toggleBotoesDtgAndamento(bool e)
        {
            Relatorios.Enabled = e;
            Atualizar.Enabled = e;
            Excluir.Enabled = e;
            Finalizar.Enabled = e;
        }

        private void verificaBotoesDtgAndamento()
        {
            if (DtgChecked(dtgAndamento).Count == 1)
            {
                toggleBotoesDtgAndamento(true);
            }
            else
            {
                toggleBotoesDtgAndamento(false);
            }
        }

        private void dtgAndamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            if (rowIndex == -1) return;
            var row = dtgAndamento.Rows[rowIndex];
            if (e.ColumnIndex != 0)
            {
                row.Cells[0].Value = !(bool) row.Cells[0].Value;
            }

            verificaBotoesDtgAndamento();
            
            //row.Cells[7].ReadOnly = false;
            //dtgAndamento.CurrentCell = row.Cells[9];
            //dtgAndamento.BeginEdit(false);
        }

        private void dtgAndamento_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                dtgAndamento.CurrentCell = dtgAndamento.Rows[e.RowIndex].Cells[9];
            }
        }

        private void dtgFinalizados_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                dtgFinalizados.CurrentCell = dtgFinalizados.Rows[e.RowIndex].Cells[9];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            principal.ParaAtualizacao();
            var frmSecagens = new Secagens(this);
            frmSecagens.ShowDialog(this);
            principal.RetomaAtualizacao();
        }

        private void dtgFinalizados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var row = dtgFinalizados.Rows[rowIndex];
            row.Cells[0].Value = !(bool)row.Cells[0].Value;
        }

        private void dtgAndamento_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                var row = dtgAndamento.Rows[e.RowIndex];
                var ciclo = CicloDAO.buscaCiclo(Convert.ToInt32(row.Cells[2].Value),
                                Convert.ToInt32(row.Cells[1].Value));
                ciclo.descricao = (string) row.Cells[9].Value;
                CicloDAO.alteraCiclo(ciclo);
            }
        }

        private void dtgFinalizados_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                var row = dtgFinalizados.Rows[e.RowIndex];
                var ciclo = CicloDAO.buscaCiclo(Convert.ToInt32(row.Cells[2].Value),
                                Convert.ToInt32(row.Cells[1].Value));
                ciclo.descricao = (string)row.Cells[9].Value;
                CicloDAO.alteraCiclo(ciclo);
            }
        }


    }
}
