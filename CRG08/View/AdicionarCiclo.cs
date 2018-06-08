using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Windows.Forms;
using CRG08.BO;
using CRG08.Dao;
using CRG08.VO;

namespace CRG08.View
{
    public partial class AdicionarCiclo : Form
    {
        private ItemSecagem secagem;
        private int numCRG;

        public bool Confirmado = false;
        public List<ProdutoCiclo> ListaProdutos;
        public string Descricao = string.Empty;
        public string Operador = string.Empty;
        public string ResponsavelTecnico = string.Empty;

        public AdicionarCiclo(ItemSecagem sec)
        {
            InitializeComponent();
            secagem = sec;
            numCRG = sec.ciclo.crg;
        }

        private void setarStatusOK()
        {
            lblStatusProdutos.Text = "Volume total recebido do aparelho confere com os valores preenchidos.";
            lblStatusProdutos.ForeColor = Color.Green;
            lblStatusProdutos.Visible = false; // MUDAR CASO QUEIRA MOSTRAR POSTERIORMENTE...
            lblStatusProdutosMoreInfo.Visible = false;
            btnReceber.Enabled = true;
        }

        private void setarStatusError(decimal difference)
        {
            lblStatusProdutos.Text = "Volume total recebido do aparelho NÃO confere com os valores preenchidos.";
            lblStatusProdutos.ForeColor = Color.DarkRed;
            lblStatusProdutos.Visible = true;
            lblStatusProdutosMoreInfo.Visible = true;
            if (difference < 0)
            {
                var strDiferenca = string.Empty;
                if (secagem.ciclo.IsMetrosCubicos)
                {
                    strDiferenca = (difference * -1).ToString() + "m³";
                }
                else
                {
                    strDiferenca = (difference * -1).ToString() + ((difference * -1) > 1 ? " peças" : " peça");
                }
                lblStatusProdutosMoreInfo.Text = "Os valores preenchidos possuem " + strDiferenca +
                                                 " a menos do que o valor recebido do aparelho.";
                lblStatusProdutosMoreInfo.ForeColor = Color.DarkRed;
            }
            else
            {
                var strDiferenca = string.Empty;
                if (secagem.ciclo.IsMetrosCubicos)
                {
                    strDiferenca = difference.ToString() + "m³";
                }
                else
                {
                    strDiferenca = difference.ToString() + (difference > 1 ? " peças" : " peça");
                }
                lblStatusProdutosMoreInfo.Text = "Os valores preenchidos possuem " + strDiferenca +
                                                 " a mais do que o valor recebido do aparelho.";
                lblStatusProdutosMoreInfo.ForeColor = Color.DarkBlue;
            }
            btnReceber.Enabled = false;
        }

        private void setarStatusVolumeEmBranco()
        {
            lblStatusProdutos.Visible = true;
            lblStatusProdutos.Text = "Algum volume está em branco ou com valor inválido.";
            lblStatusProdutosMoreInfo.Visible = false;
            btnReceber.Enabled = false;
        }

        private void setarStatus()
        {
            var totalVolumes = calcularTotalDeVolumes();
            var volFixo = Convert.ToDecimal(secagem.ciclo.VolumeFixo);
            var diferenca = totalVolumes - volFixo;

            if (volumesErrados().Count > 0)
            {
                setarStatusVolumeEmBranco();
            }
            else
            {
                if (diferenca != 0)
                {
                    setarStatusError(diferenca);
                }
                else
                {
                    setarStatusOK();
                }
            }


        }

        private List<string> volumesErrados()
        {
            var volumes = dtgProdutos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[colVolume.Index].Value.ToString() != string.Empty)
                .Select(x => x.Cells[colVolume.Index].Value.ToString()).ToList();

            var volumesEmBranco = dtgProdutos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[colVolume.Index].Value.ToString() == string.Empty)
                .Select(x => x.Cells[colVolume.Index].Value.ToString()).ToList();

            var listaRetorno = new List<string>();
            foreach (var item in volumes)
            {
                try
                {
                    Convert.ToDecimal(item);
                }
                catch
                {
                    listaRetorno.Add(item);
                }
            }
            foreach (var item in volumesEmBranco)
            {
                listaRetorno.Add(item);
            }
            return listaRetorno;
        }

        private decimal calcularTotalDeVolumes()
        {
            if (secagem.ciclo.PossuiProdutoFixo == false) return 0;

            var volumes = dtgProdutos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[colVolume.Index].Value.ToString() != string.Empty)
                .Select(x => x.Cells[colVolume.Index].Value.ToString()).ToList();

            decimal somaVolumes = 0;

            if (volumes.Count > 0)
            {
                foreach (var volume in volumes)
                {
                    try
                    {
                        somaVolumes += Convert.ToDecimal(volume.Replace(".", ","));
                    }
                    catch (Exception e)
                    {
                        somaVolumes = 0;
                        MessageBox.Show("O valor informado não é reconhecido como válido: " + volume);
                        return somaVolumes;
                    }
                }
            }

            return somaVolumes;
        }

        private void AdicionarCiclo_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Text = "Novo Ciclo - Tratamento " + secagem.ciclo.nTrat.ToString("000");

            //lblNumLeituras.Text = secagem.leiturasCiclo.Count.ToString();
            //if (!string.IsNullOrWhiteSpace(secagem.ciclo.VolumeFixo))
            //{
            //    lblVolumeTotal.Text = secagem.ciclo.VolumeFixo + " " + (secagem.ciclo.IsMetrosCubicos ? "m³" : "peças");
            //    lblDescVolumeTotal.Visible = true;
            //    lblVolumeTotal.Visible = true;
            //}
            //else
            //{
            //    lblDescVolumeTotal.Visible = false;
            //    lblVolumeTotal.Visible = false;
            //}

            lblTitulo.Text = "Tratamento Nº " + secagem.ciclo.nTrat.ToString("000") + " com " +
                             secagem.ciclo.nl.ToString("000") + " leituras";
            if (!string.IsNullOrWhiteSpace(secagem.ciclo.VolumeFixo))
            {
                lblTitulo.Text += " (" + secagem.ciclo.VolumeFixo + " " +
                                  (secagem.ciclo.IsMetrosCubicos ? "m³" : "peças") + " de volume total)";
                btnGerenciarUnidades.Enabled = false;
            }

            lblPeriodoCiclo.Text = "De " + secagem.ciclo.dataInicio.ToString("dd/MM/yyyy HH:mm") + " até " +
                              secagem.ciclo.dataFim.ToString("dd/MM/yyyy HH:mm");

            if (secagem.ciclo.nlt == secagem.ciclo.tempoTrat)
            {
                lblInfoTratamento.Text = "Início do tratamento na leitura " + secagem.ciclo.NLIniTrat + " em " +
                                         secagem.ciclo.dataIniTrat.ToString("dd/MM/yyyy HH:mm");
            }
            else
            {
                lblInfoTratamento.Text = "Não realizado";
            }

            lblInfoAparelho.Text = "CRG Nº " + numCRG.ToString("00") + " - Nº Série " + secagem.ciclo.numSerie + " - " +
                                   secagem.ciclo.tipoCRG + "ºC";

            lblNumCRG.Text = numCRG.ToString("00");


            var ultimoOperador = UltimosDAO.RetornaUltimoOperador();
            var ultimoResponsavel = UltimosDAO.RetornaUltimoResponsavel();
            txtOperador.Text = ultimoOperador;
            txtRespTecnico.Text = ultimoResponsavel;

            //setarStatus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNovoProduto_Click(object sender, EventArgs e)
        {
            refreshProdutos();
            refreshEmpresas();
            if (string.IsNullOrWhiteSpace(secagem.ciclo.VolumeFixo))
            {
                refreshUnidades();
                dtgProdutos.Rows.Add(true, "", "", "", "", "");
            }
            else
            {
                var unidade = secagem.ciclo.IsMetrosCubicos ? "m³" : "peças";

                if (UnidadeDAO.retornaID(unidade) == -1)
                {
                    UnidadeDAO.InsereUnidade(new Unidade
                    {
                        unidade = unidade
                    });
                }

                colUnidade.DataSource = new List<string> { unidade };
                if (dtgProdutos.RowCount == 0)
                {
                    dtgProdutos.Rows.Add(true, "", secagem.ciclo.VolumeFixo, unidade, "", "");
                }
                else
                {
                    dtgProdutos.Rows.Add(true, "", "", unidade, "", "");
                }

                colUnidade.ReadOnly = true;
            }


        }

        private void AdicionarCiclo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Confirmado) return;
            if (DialogResult.Yes != MessageBox.Show("Cancelar a inclusão do novo ciclo?", "Tem certeza?", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question))
            {
                e.Cancel = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReceber_Click(object sender, EventArgs e)
        {
            var msgErros = string.Empty;

            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                msgErros += Environment.NewLine + "Descrição não pode estar em branco.";
            }

            if (string.IsNullOrWhiteSpace(txtOperador.Text))
            {
                msgErros += Environment.NewLine + "Operador não pode estar em branco.";
            }

            if (string.IsNullOrWhiteSpace(txtRespTecnico.Text))
            {
                msgErros += Environment.NewLine + "Responsável Técnico não pode estar em branco.";
            }

            if (dtgProdutos.RowCount == 0)
            {
                msgErros += Environment.NewLine + "Nenhum produto foi inserido.";
            }

            var lstProdutos = dtgProdutos.Rows.Cast<DataGridViewRow>();
            var produtosErrados = new List<string> { string.Empty, "Gerenciar Produtos" };
            var produtosNull = lstProdutos.Where(x =>
                produtosErrados.Contains(((DataGridViewComboBoxCell)x.Cells[colProduto.Index]).Value.ToString()));
            if (produtosNull.Any())
            {
                msgErros += Environment.NewLine + "Um ou mais produtos não foram informados corretamente.";
            }
            produtosErrados = new List<string> { string.Empty, "Gerenciar Unidades" };
            var unidadesNull = lstProdutos.Where(x =>
                produtosErrados.Contains(((DataGridViewComboBoxCell)x.Cells[colUnidade.Index]).Value.ToString()));
            if (unidadesNull.Any())
            {
                msgErros += Environment.NewLine +
                            "Uma ou mais unidades de medida não foram informadas corretamente.";
            }
            produtosErrados = new List<string> { string.Empty };
            var volumesNull = lstProdutos.Where(x =>
                produtosErrados.Contains(((DataGridViewTextBoxCell)x.Cells[colVolume.Index]).Value.ToString()));
            if (volumesNull.Any() || volumesErrados().Any())
            {
                msgErros += Environment.NewLine +
                            "Um ou mais volumes não foram informados corretamente.";
            }

            if (lblStatusProdutosMoreInfo.Visible)
            {
                msgErros += Environment.NewLine +
                            "Os volumes dos produtos não batem com o volume total recebido do aparelho.";
            }


            produtosErrados = new List<string> { string.Empty, "Gerenciar Empresas" };
            var empresasNull = lstProdutos.Where(x =>
                produtosErrados.Contains(((DataGridViewComboBoxCell)x.Cells[colEmpresa.Index]).Value.ToString()));
            if (empresasNull.Any())
            {
                msgErros += Environment.NewLine +
                            "Uma ou mais empresas não foram informadas corretamente.";
            }

            if (msgErros != string.Empty)
            {
                MessageBox.Show(
                    "Não foi possível adicionar o ciclo." + Environment.NewLine + Environment.NewLine + "Detalhes:" +
                    msgErros, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UltimosDAO.SetarUltimoOperador(txtOperador.Text);
            UltimosDAO.SetarUltimoResponsavel(txtRespTecnico.Text);

            Confirmado = true;

            Descricao = txtDescricao.Text;
            Operador = txtOperador.Text;
            ResponsavelTecnico = txtRespTecnico.Text;

            var listaProdutos = new List<ProdutoCiclo>();
            foreach (var row in dtgProdutos.Rows.Cast<DataGridViewRow>())
            {
                listaProdutos.Add(new ProdutoCiclo
                {
                    ciclo = secagem.ciclo,
                    produto = new Produto
                    {
                        descricao = row.Cells[colProduto.Index].Value.ToString(),
                        idProduto = ProdutoDAO.retornarIDProduto(row.Cells[colProduto.Index].Value.ToString())
                    },
                    volume = row.Cells[colVolume.Index].Value.ToString(),
                    unidade = new Unidade
                    {
                        unidade = row.Cells[colUnidade.Index].ToString(),
                        idUnidade = UnidadeDAO.retornaID(row.Cells[colUnidade.Index].Value.ToString())
                    },
                    empresa = new EmpresaCiclo
                    {
                        nome = row.Cells[colEmpresa.Index].Value.ToString(),
                        idEmpresa = EmpresaCicloDAO.retornaID(row.Cells[colEmpresa.Index].Value.ToString())
                    }
                });
            }

            ListaProdutos = listaProdutos;

            Close();
        }

        private void dtgProdutos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colVolume.Index)
            {
                setarStatus();
            }
        }

        private void refreshProdutos()
        {
            var listaProdutos = ProdutoDAO.retornaProdutos().Select(x => x.descricao).ToList();
            listaProdutos.Add("Gerenciar Produtos");
            colProduto.DataSource = listaProdutos;
        }

        private void refreshUnidades()
        {
            var listaUnidades = UnidadeDAO.retornaUnidades().Select(x => x.unidade).ToList();
            listaUnidades.Add("Gerenciar Unidades");
            colUnidade.DataSource = listaUnidades;
        }

        private void refreshEmpresas()
        {
            var listaEmpresas = EmpresaCicloDAO.retornaEmpresas().Select(x => x.nome).ToList();
            listaEmpresas.Add("Gerenciar Empresas");
            colEmpresa.DataSource = listaEmpresas;
        }

        private void ComboSelectionChanged(object sender, EventArgs e)
        {

            var currentCol = dtgProdutos.CurrentCell.ColumnIndex;
            if (currentCol == colProduto.Index)
            {
                var produto =
                    (dtgProdutos.Rows[dtgProdutos.CurrentRow.Index].Cells[colProduto.Index] as DataGridViewComboBoxCell)
                    .EditedFormattedValue.ToString();
                if (produto == "Gerenciar Produtos")
                {
                    var cadastro = new CadastroGenerico("Produto");
                    cadastro.ShowDialog(this);
                    refreshProdutos();
                }

            }
            else if (currentCol == colUnidade.Index)
            {
                var unidade = (dtgProdutos.Rows[dtgProdutos.CurrentRow.Index].Cells[colUnidade.Index] as DataGridViewComboBoxCell)
                    .EditedFormattedValue.ToString();
                if (unidade == "Gerenciar Unidades")
                {
                    var cadastro = new CadastroGenerico("Unidade");
                    cadastro.ShowDialog(this);
                    refreshUnidades();
                }
            }
            else if (currentCol == colEmpresa.Index)
            {
                var empresa = (dtgProdutos.Rows[dtgProdutos.CurrentRow.Index].Cells[colEmpresa.Index] as DataGridViewComboBoxCell)
                    .EditedFormattedValue.ToString();
                if (empresa == "Gerenciar Empresas")
                {
                    var cadastro = new CadastroGenerico("Empresa");
                    cadastro.ShowDialog(this);
                    refreshEmpresas();
                }
            }
        }

        private void combo_DropDown(object sender, EventArgs e)
        {
            ((ComboBox)sender).BackColor = Color.White;
        }

        private void colVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !e.KeyChar.Equals('.') && !e.KeyChar.Equals(','))
            {
                e.Handled = true;
            }
        }

        private void dtgProdutos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                var box = (ComboBox)e.Control;
                box.SelectedIndexChanged -= ComboSelectionChanged;
                box.SelectedIndexChanged += ComboSelectionChanged;
                box.DropDown -= combo_DropDown;
                box.DropDown += combo_DropDown;
                box.BackColor = Color.White;
                box.DropDownStyle = ComboBoxStyle.DropDownList;

            }
            else if (e.Control is TextBox && dtgProdutos.CurrentCell.ColumnIndex == colVolume.Index)
            {
                var txt = (TextBox)e.Control;
                txt.KeyPress -= colVolume_KeyPress;
                txt.KeyPress += colVolume_KeyPress;
            }
            e.CellStyle.BackColor = Color.White;
        }

        private void btnGerenciarProdutos_Click(object sender, EventArgs e)
        {
            var cadastro = new CadastroGenerico("Produto");
            cadastro.ShowDialog(this);
            refreshProdutos();
        }

        private void btnGerenciarUnidades_Click(object sender, EventArgs e)
        {
            var cadastro = new CadastroGenerico("Unidade");
            cadastro.ShowDialog(this);
            refreshUnidades();
        }

        private void btnGerenciarEmpresas_Click(object sender, EventArgs e)
        {
            var cadastro = new CadastroGenerico("Empresa");
            cadastro.ShowDialog(this);
            refreshEmpresas();
        }

        private void btnExcluirProduto_Click(object sender, EventArgs e)
        {
            foreach (var item in dtgProdutos.Rows.Cast<DataGridViewRow>())
            {
                if ((bool) item.Cells[0].Value == true)
                {
                    dtgProdutos.Rows.Remove(item);
                }
            }
        }
    }
}
