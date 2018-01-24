using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
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
    public partial class Ciclos : Form
    {
        private Principal principal;
        private Thread t;
        private bool _carregando = false;
        private Carregar frmCarregar = new Carregar();
        private Thread thCarregar;

        private delegate List<byte> funcaoAssincrona();

        public Ciclos(Principal principal)
        {
            InitializeComponent();
            this.principal = principal;
        }

        public Ciclos()
        {
            InitializeComponent();
        }

        private void IniciaCarregamento()
        {
            _carregando = true;
            thCarregar = new Thread(Carregando);
            thCarregar.Start();
        }

        private void Carregando()
        {
            frmCarregar.Invoke(new MethodInvoker(() =>
            {

            }));
            while (_carregando)
            {
                Thread.Sleep(500);
            }
            frmCarregar.Close();
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

        //private void RecebeSecagemOnline(IAsyncResult ar)
        //{
        //    
        //}
        

        private void Novo_Click(object sender, EventArgs e)
        {
            principal.ParaAtualizacao();
            

            var seleciona = new frmSelecionarMeioComunicacao();
            seleciona.ShowDialog(this);
            if (!seleciona.Sucesso) goto Fim;
            var tipoCom = seleciona.TipoComunicacao;
            var crg = seleciona.NumCRG;
            if (string.IsNullOrWhiteSpace(tipoCom)) goto Fim;

            if (tipoCom == "ONLINE")
            {

                if (crg <= 0)
                {
                    MessageBox.Show("Número do CRG inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var func = new funcaoAssincrona(() => SecagensBO.ReceberSecagem(0, crg, ConfiguracaoDAO.retornaPorta()));

                this.Enabled = false;
                frmCarregar = new Carregar();
                frmCarregar.Show(this);
                var asyncResult = func.BeginInvoke((ar) =>
                {
                    
                }, null);

                while (asyncResult.IsCompleted == false)
                {
                    Application.DoEvents();
                    Thread.Sleep(50);
                }

                frmCarregar.Invoke(new MethodInvoker(() => frmCarregar.Close()));

                var listaRetorno = func.EndInvoke(asyncResult);

                if (listaRetorno == null || listaRetorno.Count == 0)
                {
                    MessageBox.Show("Não foi possível comunicar com o equipamento!", "Erro de comunicação",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Enabled = true;
                    return;
                }
                var secagem = SecagensBO.DescriptografarSecagem(listaRetorno);

                if (secagem == null)
                {
                    MessageBox.Show("Não foi possível carregar este ciclo!", "Erro", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    this.Enabled = true;
                    return;
                }
                secagem.ciclo.crg = crg;

                var status = SecagensBO.SalvarSecagem(false, secagem, this);

                if (status.Cancelado)
                {
                    this.Enabled = true;
                    return;
                }

                if (!status.Sucesso)
                {
                    var msgs = string.Empty;
                    foreach (var msg in ErrorHandler.GetAllErrors)
                    {
                        msgs += Environment.NewLine + msg.ErrorMessage;
                    }
                    MessageBox.Show(
                        "Não foi possível salvar o ciclo " + secagem.ciclo.nTrat + "!" + Environment.NewLine +
                        Environment.NewLine + "Detalhes: " + msgs, "Erro", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    ErrorHandler.ClearErrors();
                    this.Enabled = true;
                    return;
                }

                MessageBox.Show(
                    "Ciclo " + secagem.ciclo.nTrat + " " + (status.Salvo ? "salvo" : "atualizado") + " com sucesso!",
                    "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregaCiclos();
                Enabled = true;
                Activate();
            }
            else
            {
                var frmPendrive = new frmPendriveList(crg, -1);
                frmPendrive.ShowDialog(this);
                var arquivo = frmPendrive.Arquivo;
                var ntrat = frmPendrive.NTrat;
                crg = crg == -1 ? frmPendrive.Crg : crg;

                if (string.IsNullOrWhiteSpace(arquivo) || ntrat == -1 || crg == -1) return;

                var bytes = File.ReadAllBytes(arquivo);
                var secagem = SecagensBO.DescriptografarSecagem(bytes.ToList(), 1);
                if (secagem == null)
                {
                    var msg = "Não foi possível carregar este ciclo!";
                    if (ErrorHandler.GetLastError != null)
                    {
                        msg += Environment.NewLine + Environment.NewLine + "Detalhes:" + Environment.NewLine +
                               ErrorHandler.GetLastError.ErrorMessage;
                        ErrorHandler.ClearErrors();
                    }
                    MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto Fim;
                }

                secagem.ciclo.crg = crg;


                var status = SecagensBO.SalvarSecagem(false, secagem);

                if (status.Cancelado) return;

                if (status.Sucesso)
                {
                    MessageBox.Show("Ciclo " + secagem.ciclo.nTrat + " " + (status.Salvo ? "salvo" : "atualizado") +
                                    " com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Fim;
                }

                var ultimoErro = ErrorHandler.GetLastError;
                if (ultimoErro != null)
                {
                    MessageBox.Show(ultimoErro.ErrorMessage, ultimoErro.Identifier == 0 ? "Erro" : "Informação",
                        MessageBoxButtons.OK,
                        ultimoErro.Identifier == 0 ? MessageBoxIcon.Error : MessageBoxIcon.Information);
                    goto Fim;
                }
            }
            

            Fim:
            CarregaCiclos();
            principal.RetomaAtualizacao();
        }

        private void Alterar_Click(object sender, EventArgs e)
        {
            if (Atualizar.Text == "Atualizar")
            {
                var checados = DtgChecked(dtgAndamento);
                if (checados.Count == 0) return;
                var frmTipoCom = new frmSelecionarMeioComunicacao(0);
                frmTipoCom.ShowDialog(this);
                if (!frmTipoCom.Sucesso) return;
                var tipoCom = frmTipoCom.TipoComunicacao;
                if (string.IsNullOrWhiteSpace(tipoCom)) return;


                foreach (var item in checados)
                {
                    var crg = Convert.ToInt32(item.Cells[2].Value);
                    var nTrat = Convert.ToInt32(item.Cells[4].Value);

                    if (tipoCom == "ONLINE")
                    {
                        var func = new funcaoAssincrona(() => SecagensBO.ReceberSecagem(0, crg, ConfiguracaoDAO.retornaPorta()));

                        this.Enabled = false;
                        frmCarregar = new Carregar();
                        frmCarregar.Show(this);
                        var asyncResult = func.BeginInvoke((ar) =>
                        {

                        }, null);

                        while (asyncResult.IsCompleted == false)
                        {
                            Application.DoEvents();
                            Thread.Sleep(50);
                        }

                        frmCarregar.Invoke(new MethodInvoker(() => frmCarregar.Close()));

                        var listaRetorno = func.EndInvoke(asyncResult);

                        if (listaRetorno == null || listaRetorno.Count == 0)
                        {
                            MessageBox.Show("Não foi possível comunicar com o equipamento!", "Erro de comunicação",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Enabled = true;
                            return;
                        }
                        var secagem = SecagensBO.DescriptografarSecagem(listaRetorno);

                        if (secagem == null)
                        {
                            MessageBox.Show("Não foi possível carregar este ciclo!", "Erro", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            this.Enabled = true;
                            return;
                        }
                        secagem.ciclo.crg = crg;

                        var status = SecagensBO.SalvarSecagem(true, secagem, this);

                        if (status.Cancelado)
                        {
                            this.Enabled = true;
                            return;
                        }

                        if (!status.Sucesso)
                        {
                            var msgs = string.Empty;
                            foreach (var msg in ErrorHandler.GetAllErrors)
                            {
                                msgs += Environment.NewLine + msg.ErrorMessage;
                            }
                            MessageBox.Show(
                                "Não foi possível salvar o ciclo " + secagem.ciclo.nTrat + "!" + Environment.NewLine +
                                Environment.NewLine + "Detalhes: " + msgs, "Erro", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            this.Enabled = true;
                            return;
                        }

                        MessageBox.Show(
                            "Ciclo " + secagem.ciclo.nTrat + " " + (status.Salvo ? "salvo" : "atualizado") + " com sucesso!",
                            "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CarregaCiclos();
                        Enabled = true;
                        Activate();
                    }
                    else
                    {
                        var frmPendrive = new frmPendriveList(crg, nTrat);
                        frmPendrive.ShowDialog(this);
                        var arquivo = frmPendrive.Arquivo;

                        if (string.IsNullOrWhiteSpace(arquivo) || nTrat == -1 || crg == -1) return;

                        var bytes = File.ReadAllBytes(arquivo);
                        if (!bytes.Any())
                        {
                            ErrorHandler.ThrowNew(0, "Arquivo inválido!");
                            goto Fim;
                        }
                        var secagem = SecagensBO.DescriptografarSecagem(bytes.ToList(), 1);
                        if (secagem == null)
                        {
                            var msg = "Não foi possível carregar este ciclo!";
                            if (ErrorHandler.GetLastError != null)
                            {
                                msg += Environment.NewLine + Environment.NewLine + "Detalhes:" + Environment.NewLine +
                                       ErrorHandler.GetLastError.ErrorMessage;
                                ErrorHandler.ClearErrors();
                            }
                            MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            goto Fim;
                        }

                        secagem.ciclo.crg = crg;


                        var status = SecagensBO.SalvarSecagem(true, secagem);

                        if (status.Sucesso)
                        {
                            MessageBox.Show("Ciclo " + secagem.ciclo.nTrat + " " + (status.Salvo ? "salvo" : "atualizado") +
                                            " com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            goto Fim;
                        }

                        var ultimoErro = ErrorHandler.GetLastError;
                        if (ultimoErro != null)
                        {
                            MessageBox.Show(ultimoErro.ErrorMessage, ultimoErro.Identifier == 0 ? "Erro" : "Informação",
                                MessageBoxButtons.OK,
                                ultimoErro.Identifier == 0 ? MessageBoxIcon.Error : MessageBoxIcon.Information);
                            goto Fim;
                        }
                    }
                    Fim:
                    Activate();
                    CarregaCiclos();
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
            CheckForIllegalCrossThreadCalls = false;
            int[] atualizacao = ConfiguracaoDAO.RetornaAtualizacao();
            Configuracao config = new Configuracao();
            config.atualizacao = atualizacao[0];
            if (config.atualizacao == 3 || config.atualizacao == 4) Atualizar.Enabled = false;
            CarregaCiclos();
        }

        public void CarregaCiclos()
        {
            var filtro = UltimosDAO.RetornaUltimoFiltro();
            dtgAndamento.Rows.Clear();
            dtgFinalizados.Rows.Clear();
            List<VO.Ciclos> CiclosAndamento = CicloDAO.listaCiclosPorSituacaoAll(0);

            foreach (var c in CiclosAndamento)
            {
                dtgAndamento.Rows.Add(false, c.id, c.crg, c.numSerie, c.nTrat.ToString("000"), c.nl.ToString("000"),
                    c.nlt.ToString("000"), c.dataColeta, c.dataInicio, c.descricao);
            }

            selecao = filtro.ValorFiltro;
            if (selecao == 4)
            {
                int crg = filtro.Equipamento;
                List<VO.Ciclos> CiclosFinalizados = CicloDAO.listaCiclosPorSituacaoEq(crg,1);
                foreach (var c in CiclosFinalizados)
                {
                    dtgFinalizados.Rows.Add(false, c.id, c.crg, c.numSerie, c.nTrat.ToString("000"),
                        c.nl.ToString("000"), c.nlt.ToString("000"), c.dataColeta, c.dataInicio, c.descricao);
                }
            }
            else if (selecao == 3)
            {
                int crg = filtro.Equipamento;
                int mes = filtro.QtdMeses;
                List<VO.Ciclos> CiclosFinalizados = CicloDAO.listaCiclosPorSituacaoMes(crg, 1, -mes);
                foreach (var c in CiclosFinalizados)
                {
                    dtgFinalizados.Rows.Add(false, c.id, c.crg, c.numSerie, c.nTrat.ToString("000"),
                        c.nl.ToString("000"), c.nlt.ToString("000"), c.dataColeta, c.dataInicio, c.descricao);
                }
            }
            else if (selecao == 2)
            {
                int crg = filtro.Equipamento;
                List<VO.Ciclos> CiclosFinalizados = CicloDAO.listaCiclosPorSituacaoEntre(crg, 1, filtro.DataInicio, filtro.DataFim);
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

            toggleBotoesDtgAndamento(false);
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
                    verificaBotoesDtgFinalizados();
                }
                else if (tabCiclos.TabPages[tabCiclos.SelectedIndex].Name == "CiclosAndamento")
                {
                    Atualizar.Text = "Atualizar";
                    Finalizar.Text = "Enviar Finalizadas";
                    //int[] atualizacao = ConfiguracaoDAO.RetornaAtualizacao();
                    //Configuracao config = new Configuracao();
                    //config.atualizacao = atualizacao[0];
                    //if (config.atualizacao == 3 || config.atualizacao == 4) Atualizar.Enabled = false;
                    verificaBotoesDtgAndamento();
                }
            }
        }
        

        private string[] ObterDadosUltimo()
        {
            try
            {
                var ultimoOperador = UltimosDAO.RetornaUltimoOperador();
                var ultimoResponsavel = UltimosDAO.RetornaUltimoResponsavel();
                var retorno = new string[2];
                retorno[0] = ultimoOperador;
                retorno[1] = ultimoResponsavel;
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
            var checados = DtgChecked(dtgAndamento);
            if (checados.Count == 1)
            {
                toggleBotoesDtgAndamento(true);
            }
            else if (checados.Count == 0)
            {
                toggleBotoesDtgAndamento(false);
            }
            else
            {
                Relatorios.Enabled = false;
                Atualizar.Enabled = false;
                Excluir.Enabled = true;
                Finalizar.Enabled = true;
            }
        }

        private void toggleBotoesDtgFinalizados(bool e)
        {
            Relatorios.Enabled = e;
            Atualizar.Enabled = false;
            Excluir.Enabled = e;
            Finalizar.Enabled = e;
        }

        private void verificaBotoesDtgFinalizados()
        {
            var checados = DtgChecked(dtgFinalizados);
            if (checados.Count == 1)
            {
                toggleBotoesDtgFinalizados(true);
            }
            else if (checados.Count == 0)
            {
                toggleBotoesDtgFinalizados(false);
            }
            else
            {
                Relatorios.Enabled = false;
                Atualizar.Enabled = false;
                Excluir.Enabled = true;
                Finalizar.Enabled = true;
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

        private void dtgFinalizados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            if (rowIndex == -1) return;
            var colIndex = e.ColumnIndex;
            if (colIndex == -1) return;

            if (colIndex == 0)
            {
                dtgFinalizados.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtgAndamento_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                verificaBotoesDtgAndamento();
            }
        }

        private void dtgFinalizados_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                verificaBotoesDtgFinalizados();
            }
        }

        private void AsyncFunction(IAsyncResult ar)
        {
            try
            {
                var lista = ((funcaoAssincrona) ar.AsyncState).EndInvoke(ar);
                MessageBox.Show(lista.Count().ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private List<byte> GeraBytes()
        {
            var listaRetorno = new List<byte>();
            while (listaRetorno.Count < 5)
            {
                listaRetorno.Add(Convert.ToByte(listaRetorno.Count +1));
            }
            return listaRetorno;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dtgFinalizados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            if (rowIndex == -1) return;
            var row = dtgFinalizados.Rows[rowIndex];
            if (e.ColumnIndex != 0)
            {
                row.Cells[0].Value = !(bool)row.Cells[0].Value;
            }

            verificaBotoesDtgFinalizados();

            //row.Cells[7].ReadOnly = false;
            //dtgAndamento.CurrentCell = row.Cells[9];
            //dtgAndamento.BeginEdit(false);
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
