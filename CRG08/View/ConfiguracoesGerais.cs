using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using CRG08.Dao;
using CRG08.Util;
using CRG08.VO;

namespace CRG08.View
{
    public partial class ConfiguracoesGerais : Form
    {
        private Principal principal;
        private bool Restart = false;
        public ConfiguracoesGerais(Principal principal)
        {
            InitializeComponent();
            this.principal = principal;
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SalvarAtualizacao_Click(object sender, EventArgs e)
        {
            Configuracao config = ConfiguracaoDAO.retornaConfiguracao();
            if (config == null)
            {
                config = new Configuracao();
                if (cmbPorta.SelectedItem != "" && (Individual.Checked || Desativada.Checked || Automatica.Checked))
                {
                    if (Automatica.Checked)
                    {
                        if (intervalo.Text != "")
                        {
                            config.atualizacao = 3;
                            config.intervalo = Convert.ToInt32(intervalo.Text);
                        }
                        else
                            MessageBox.Show( "Para atualização automática é preciso um intervalo.Favor preencher o tempo.",
                                "Atenção", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else if (Individual.Checked) config.atualizacao = 1;
                    else if (Desativada.Checked) config.atualizacao = 4;
                    config.porta = cmbPorta.SelectedItem.ToString();
                    config.id = 1;
                    bool retorno = ConfiguracaoDAO.insereConfiguracao(config);
                    if (retorno)
                    {
                        MessageBox.Show("Configurações salvas com sucesso.", "Sucesso", MessageBoxButtons.OK,MessageBoxIcon.None);
                        VO.LogMudanca log = new VO.LogMudanca();
                        log.descricao = "Configurações Gerais alterada";
                        log.crg = 0;
                        log.data = DateTime.Now;
                        string[] dados = ObterDadosUltimo();
                        log.responsavel = dados[1];
                        LogMudancaDAO.insereLogMudanca(log);
                        Restart = true;
                    }
                    else
                        MessageBox.Show( "Erro ao tentar salvar as configurações. Verifique o log de Erros para mais detalhes.",
                            "Erro", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Selecione todas as opções de configurações para poder salvá-las.", "Atenção",
                        MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                if (cmbPorta.SelectedItem != "" && (Individual.Checked || Desativada.Checked || Automatica.Checked))
                {
                    if (Automatica.Checked)
                    {
                        if (intervalo.Text != "")
                        {
                            config.atualizacao = 3;
                            config.intervalo = Convert.ToInt32(intervalo.Text);
                        }
                        else
                            MessageBox.Show("Para atualização automática é preciso um intervalo.Favor preencher o tempo.",
                                "Atenção", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else if (Individual.Checked) config.atualizacao = 1;
                    else if (Desativada.Checked) config.atualizacao = 4;
                    config.porta = cmbPorta.SelectedItem.ToString();
                    config.id = 1;
                    bool retorno = ConfiguracaoDAO.alterarConfiguracao(config);
                    if (retorno)
                    {
                        MessageBox.Show("Configurações alteradas com sucesso.", "Sucesso", MessageBoxButtons.OK,MessageBoxIcon.None);
                        Restart = true;
                    }
                    else
                        MessageBox.Show( "Erro ao tentar salvar as configurações. Verifique o log de Erros para mais detalhes.",
                            "Erro", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Selecione todas as opções de configurações para poder salvá-las.", "Atenção",
                        MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            
            principal.CarregaInformacoes();
        }

        private void ConfiguracoesGerais_Load(object sender, EventArgs e)
        {
            Configuracao config = ConfiguracaoDAO.retornaConfiguracao();
            if (config != null)
            {
                for(int i = 0; i<cmbPorta.Items.Count;i++)
                    if (cmbPorta.Items[i].ToString() == config.porta) cmbPorta.SelectedIndex = i;
                switch (config.atualizacao)
                {
                    case 1:
                        Individual.Checked = true;
                        break;
                    case 3:
                        Automatica.Checked = true;
                        intervalo.Text = config.intervalo.ToString();
                        intervalo.Enabled = true;
                        break;
                    case 4:
                        Desativada.Checked = true;
                        break;
                }
            }
        }

        private void Automatica_CheckedChanged(object sender, EventArgs e)
        {
            if (Automatica.Checked) intervalo.Enabled = true;
            else intervalo.Enabled = false;
        }

        private string[] ObterDadosUltimo()
        {
            try
            {
                var operador = UltimosDAO.RetornaUltimoOperador();
                var responsavel = UltimosDAO.RetornaUltimoResponsavel();
                var retorno = new string[2];
                retorno[0] = operador;
                retorno[1] = responsavel;
                return retorno;
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao obter dados do Operador e Responsavel";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao obter dados do Operador e Responsavel", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return new string[2] { "", "" };
            }
        }

        private void ConfiguracoesGerais_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Restart)
            {
                Restart = false;
                Application.Restart();
            }
        }
    }
}
