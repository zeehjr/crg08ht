using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using CRG08.Dao;
using CRG08.Util;
using CRG08.VO;

namespace CRG08.View
{
    public partial class ImportarExportar : Form
    {
        private bool continuarExportandoEmail = false;
        private string mensagem;
        public ImportarExportar(bool importar = false)
        {
            InitializeComponent();
            if (importar)
            {
                Importar.Checked = true;
            }
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Arquivo_Click(object sender, EventArgs e)
        {
            var crg = 0;
            if (Exportar.Checked)
            {
                salvarCiclo.RestoreDirectory = true;
                salvarCiclo.Title = "Exportar Ciclo para...";
                salvarCiclo.Filter = "crg08 files(*.crg08)|*.crg08";
                salvarCiclo.DefaultExt = "crg08";
                salvarCiclo.CheckPathExists = true;

                var dialogResult = salvarCiclo.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    var writer = new XmlTextWriter(salvarCiclo.FileName, null);
                    // Gera o XML de cada ciclo
                    try
                    {
                        writer.Formatting = Formatting.Indented;
                        writer.WriteStartDocument();
                        writer.WriteStartElement("Ciclos");

                        for (int i = 0; i < dtgAndamento.RowCount; i++)
                        {
                            if (dtgAndamento.Rows[i].Cells[0].Value.ToString() == "True")
                            {
                                var id = int.Parse(dtgAndamento.Rows[i].Cells[1].Value.ToString());
                                crg = int.Parse(dtgAndamento.Rows[i].Cells[2].Value.ToString());
                                var ciclo = CicloDAO.buscaCiclo(crg, id);

                                ExportarCiclo(writer, ciclo, i + 1);
                            }
                        }

                        for (int i = 0; i < dtgFinalizados.RowCount; i++)
                        {
                            if (dtgFinalizados.Rows[i].Cells[0].Value.ToString() == "True")
                            {

                                var id = int.Parse(dtgFinalizados.Rows[i].Cells[1].Value.ToString());
                                crg = int.Parse(dtgFinalizados.Rows[i].Cells[2].Value.ToString());
                                var ciclo = CicloDAO.buscaCiclo(crg, id);

                                ExportarCiclo(writer, ciclo, i + 1);
                            }
                        }

                        writer.WriteFullEndElement();
                        writer.WriteEndDocument();
                    }
                    catch (Exception error)
                    {
                        VO.LogErro logErro = new VO.LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro ao tentar exportar";
                        string dataHora = DateTime.Now.ToString();
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, logErro.crg);
                        MessageBox.Show("Erro ao tentar exportar.","Erro",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        writer.Flush();
                        writer.Close();

                        var xmlDoc = new XmlDocument();

                        try
                        {
                            xmlDoc.PreserveWhitespace = true;
                            xmlDoc.Load(salvarCiclo.FileName);
                        }
                        catch (Exception er)
                        {
                            Console.WriteLine(er.Message);
                        }

                        var cspParams = new CspParameters();
                        cspParams.KeyContainerName = "CRG08";

                        var rsaKey = new RSACryptoServiceProvider(cspParams);

                        try
                        {
                            Crypto.Encrypt(xmlDoc, "Ciclo", "Ciclo", rsaKey, "rsaKey");
                            xmlDoc.Save(salvarCiclo.FileName);
                        }
                        catch (Exception er)
                        {
                            VO.LogErro logErro = new VO.LogErro();
                            logErro.crg = crg;
                            logErro.descricao = "Erro ao tentar exportar";
                            string dataHora = DateTime.Now.ToString();
                            logErro.data = DateTime.Now;
                            logErro.maisDetalhes = er.Message;
                            LogErroDAO.inserirLogErro(logErro, logErro.crg);
                            MessageBox.Show("Erro ao tentar exportar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        CarregaCiclos();
                        MessageBox.Show("Ciclo exportado com sucesso!", "Sucesso", MessageBoxButtons.OK,MessageBoxIcon.None);
                    }
                }
            }
            else
            {
                var listaCiclos = new List<ImportarCiclo>();
                var importacaoCiclo = new ImportarCiclo();
                var listaLeituras = new List<LeiturasCiclo>();
                var listaTratamento = new List<LeiturasTrat>();
                var produtosCiclos = new List<ProdutoCiclo>();
                var tag = "";
                var stream = new MemoryStream();
                var xmlDocument = new XmlDocument();
                var cspParams = new CspParameters();

                abrirCiclo.RestoreDirectory = true;
                abrirCiclo.Title = "Importar Ciclo";
                abrirCiclo.Filter = "crg08 files(*.crg08)|*.crg08";
                abrirCiclo.DefaultExt = "crg08";
                abrirCiclo.CheckPathExists = true;
                VO.Ciclos cicloTemp;
                VO.Ciclos cic = new VO.Ciclos();

                var dialogResult = abrirCiclo.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {

                        cspParams.KeyContainerName = "CRG08";
                        var rsaKey = new RSACryptoServiceProvider(cspParams);

                        xmlDocument.PreserveWhitespace = true;
                        xmlDocument.Load(abrirCiclo.FileName);

                        Crypto.Decrypt(xmlDocument, rsaKey, "rsaKey");

                        xmlDocument.Save(stream);
                        stream.Flush();
                        stream.Position = 0;

                        // Carrega os dados no Reader para ler
                        var reader = new XmlTextReader(stream);
                        reader.WhitespaceHandling = WhitespaceHandling.None; // Para ignorar espaço em branco

                        // Carrega os dados de um ciclo, verifica se já existe e questiona 
                        // o usuário se ele deseja substituir e os próximos ciclos também
                        while ((reader.Read()))
                        {
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.EndElement:
                                    if (reader.Name == "Ciclo")
                                    {
                                        importacaoCiclo.leiturasCiclo = listaLeituras;
                                        importacaoCiclo.leiturasTratamento = listaTratamento;
                                        importacaoCiclo.produtosCiclo = produtosCiclos;
                                        importacaoCiclo.ciclo = cic;
                                        listaCiclos.Add(importacaoCiclo);
                                        importacaoCiclo = new ImportarCiclo();
                                        listaLeituras = new List<LeiturasCiclo>();
                                        listaTratamento = new List<LeiturasTrat>();
                                        produtosCiclos = new List<ProdutoCiclo>();
                                        cic = new VO.Ciclos();
                                    }
                                    break;
                                case XmlNodeType.Element:
                                    tag = reader.Name;

                                    if (tag == "LeituraCiclo")
                                    {
                                        listaLeituras.Add(CarregaLeiturasCiclo(reader.ReadSubtree()));
                                    }
                                    else if (tag == "LeituraTratamento")
                                    {
                                        listaTratamento.Add(CarregaLeituraTratamento(reader.ReadSubtree()));
                                    }
                                    else if (tag == "ProdutoCiclo")
                                    {
                                        produtosCiclos.Add(CarregaProdutos(reader.ReadSubtree()));
                                    }
                                    break;
                                case XmlNodeType.Text:

                                    switch (tag)
                                    {
                                        // Cabeçalho
                                        case "Id":
                                            cic.id = Convert.ToInt32(reader.Value);
                                            break;
                                        case "CRG":
                                            cic.crg = Convert.ToInt32(reader.Value);
                                            break;
                                        case "NTrat":
                                            cic.nTrat = Convert.ToInt32(reader.Value);
                                            break;
                                        case "NL":
                                            cic.nl = Convert.ToInt32(reader.Value);
                                            break;
                                        case "BaseTempo":
                                            cic.baseTempo = Convert.ToInt32(reader.Value);
                                            break;
                                        case "NLT":
                                            cic.nlt = Convert.ToInt32(reader.Value);
                                            break;
                                        case "DataColeta":
                                            cic.dataColeta = Convert.ToDateTime(reader.Value);
                                            break;
                                        case "Descricao":
                                            cic.descricao = reader.Value;
                                            break;
                                        case "DataInicio":
                                            cic.dataInicio = Convert.ToDateTime(reader.Value);
                                            break;
                                        case "DataFim":
                                            cic.dataFim = Convert.ToDateTime(reader.Value);
                                            break;
                                        case "NLIniTrat":
                                            cic.NLIniTrat = Convert.ToInt32(reader.Value);
                                            break;
                                        case "TemperaturaControle":
                                            cic.temperaturaControle = Convert.ToSingle(reader.Value);
                                            break;
                                        case "TemperaturaTrat":
                                            cic.temperaturaTrat = Convert.ToSingle(reader.Value);
                                            break;
                                        case "TempoTrat":
                                            cic.tempoTrat = Convert.ToInt32(reader.Value);
                                            break;
                                        case "Responsavel":
                                            cic.responsavel = reader.Value;
                                            break;
                                        case "Operador":
                                            cic.operador = reader.Value;
                                            break;
                                        case "Situacao":
                                            cic.situacao = Convert.ToInt32(reader.Value);
                                            break;
                                        case "NumSerie":
                                            cic.numSerie = reader.Value;
                                            break;
                                        case "VersaoEquip":
                                            cic.versaoEquip = reader.Value;
                                            break;
                                        case "Histerese":
                                            cic.histerese = Convert.ToInt32(reader.Value);
                                            break;
                                        case "TControl":
                                            cic.tControl = Convert.ToInt32(reader.Value);
                                            break;
                                        case "NLAntesTrat":
                                            cic.nlAntesTrat = Convert.ToInt32(reader.Value);
                                            break;
                                        case "NLPostTrat":
                                            cic.nlPostTrat = Convert.ToInt32(reader.Value);
                                            break;
                                        case "Sensor":
                                            cic.sensor = Convert.ToInt32(reader.Value);
                                            break;
                                        case "CA":
                                            cic.CA = reader.Value;
                                            break;
                                        case "tipoCRG":
                                            cic.tipoCRG = Convert.ToInt32(reader.Value);
                                            break;
                                    }
                                    break;
                            }
                        }

                        foreach (var ciclo in listaCiclos)
                        {
                            // Verifica se o ciclo está no banco de dados e add em um Obj temporário = cicloTemp
                            cicloTemp = CicloDAO.testaCiclo(ciclo.ciclo);
                            if (cicloTemp != null)
                            {
                                // Se o obj for diferente de nulo...
                                if (MessageBox.Show("O ciclo de nº " + ciclo.ciclo.nTrat +
                                                    " já existe no Banco de Dados. Deseja atualizar?", "Atenção",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    bool retorno = CicloDAO.alteraCiclo(ciclo.ciclo);
                                    if (retorno)
                                    {
                                        ProdutoCicloDAO.DeletaProdutosCiclo(ciclo.ciclo.id, ciclo.ciclo.crg);
                                        for (int i = 0; i < ciclo.produtosCiclo.Count; i++)
                                        {
                                            ciclo.produtosCiclo[i].ciclo = ciclo.ciclo;
                                            ProdutoCicloDAO.inserirProdutoCiclo(ciclo.produtosCiclo[i]);
                                        }
                                        if (ciclo.leiturasCiclo.Count > 0)
                                        {
                                            if (ciclo.ciclo.tipoCRG == 2) LeiturasCicloDAO.inserirLeiturasCiclo150(ciclo.leiturasCiclo, ciclo.ciclo.nl, ciclo.ciclo);
                                            else LeiturasCicloDAO.inserirLeiturasCiclo(ciclo.leiturasCiclo, ciclo.ciclo.nl, ciclo.ciclo);
                                        }
                                        if (ciclo.leiturasTratamento.Count > 0)
                                        {
                                            if (ciclo.ciclo.tipoCRG == 2) LeiturasTratDAO.inserirLeiturasTratamento150(ciclo.leiturasTratamento, ciclo.ciclo.nlt, ciclo.ciclo);
                                            else LeiturasTratDAO.inserirLeiturasTratamento(ciclo.leiturasTratamento, ciclo.ciclo.nlt, ciclo.ciclo);
                                        }
                                    }
                                    
                                    CarregaCiclos();
                                }
                            }
                            else
                            {
                                // Inclui a ciclo
                                ImportarCiclo(ciclo);
                                CarregaCiclos();
                            }
                        }

                        MessageBox.Show("Importação realizada com sucesso!", "Sucesso", MessageBoxButtons.OK,
                            MessageBoxIcon.None);
                    }
                    catch (Exception ex)
                    {
                        VO.LogErro logErro = new VO.LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro ao tentar importar ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = ex.Message;
                        LogErroDAO.inserirLogErro(logErro, logErro.crg);
                        MessageBox.Show("Erro ao tentar importar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        /// <summary>
        /// Geração do corpo do histórico
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="ciclo"></param>
        /// <param name="id"></param>
        private void ExportarCiclo(XmlTextWriter writer, VO.Ciclos ciclo, int id)
        {
            writer.WriteStartElement("Ciclo");

            writer.WriteElementString("Id", ciclo.id.ToString());
            writer.WriteElementString("CRG", ciclo.crg.ToString());
            writer.WriteElementString("NTrat", ciclo.nTrat.ToString());
            writer.WriteElementString("NL", ciclo.nl.ToString());
            writer.WriteElementString("BaseTempo", ciclo.baseTempo.ToString());
            writer.WriteElementString("NLT", ciclo.nlt.ToString());
            writer.WriteElementString("DataColeta", ciclo.dataColeta.ToString());
            writer.WriteElementString("Descricao", ciclo.descricao);
            writer.WriteElementString("DataInicio", ciclo.dataInicio.ToString());
            writer.WriteElementString("DataFim", ciclo.dataFim.ToString());
            writer.WriteElementString("NLIniTrat", ciclo.NLIniTrat.ToString());
            writer.WriteElementString("DataIniTrat", ciclo.dataIniTrat.ToString());
            writer.WriteElementString("TemperaturaControle", ciclo.temperaturaControle.ToString());
            writer.WriteElementString("TemperaturaTrat", ciclo.temperaturaTrat.ToString());
            writer.WriteElementString("TempoTrat", ciclo.tempoTrat.ToString());
            writer.WriteElementString("Responsavel", ciclo.responsavel);
            writer.WriteElementString("Operador", ciclo.operador);
            writer.WriteElementString("Situacao", ciclo.situacao.ToString());
            writer.WriteElementString("NumSerie", ciclo.numSerie);
            writer.WriteElementString("VersaoEquip", ciclo.versaoEquip);
            writer.WriteElementString("Histerese", ciclo.histerese.ToString());
            writer.WriteElementString("TControl", ciclo.tControl.ToString());
            writer.WriteElementString("NLAntesTrat", ciclo.nlAntesTrat.ToString());
            writer.WriteElementString("NLPostTrat", ciclo.nlPostTrat.ToString());
            writer.WriteElementString("Sensor", ciclo.sensor.ToString());
            writer.WriteElementString("CA", ciclo.CA);
            writer.WriteElementString("tipoCRG", ciclo.tipoCRG.ToString());

            // Leituras do Ciclo
            var listaLeiturasCiclo = LeiturasCicloDAO.ListaLeiturasCiclos(ciclo);
            foreach (var leitura in listaLeiturasCiclo)
            {
                writer.WriteStartElement("LeituraCiclo");
                writer.WriteElementString("IdLeituraCiclo", leitura.idLeiturasCiclo.ToString());
                writer.WriteElementString("Horario", leitura.horario);
                writer.WriteElementString("T1", leitura.T1.ToString());
                writer.WriteElementString("T2", leitura.T2.ToString());
                writer.WriteElementString("T3", leitura.T3.ToString());
                writer.WriteElementString("T4", leitura.T4.ToString());
                writer.WriteElementString("Ciclo", leitura.ciclo.id.ToString());

                writer.WriteEndElement();
            }

            // Leituras de Tratamento
            var listaLeiturasTrat = LeiturasTratDAO.ListaLeiturasTratamento(ciclo);
            foreach (var leitura in listaLeiturasTrat)
            {
                writer.WriteStartElement("LeituraTratamento");
                writer.WriteElementString("IdLeituraTratamento", leitura.idLeiturasTrat.ToString());
                writer.WriteElementString("Horario", leitura.horario);
                writer.WriteElementString("T1", leitura.T1.ToString());
                writer.WriteElementString("T2", leitura.T2.ToString());
                writer.WriteElementString("T3", leitura.T3.ToString());
                writer.WriteElementString("T4", leitura.T4.ToString());
                writer.WriteElementString("Ciclo", leitura.ciclo.id.ToString());

                writer.WriteEndElement();
            }

            // Produtos
            var listaProdutos = ProdutoCicloDAO.listaProdutosCiclo(ciclo);
            foreach (var leitura in listaProdutos)
            {
                writer.WriteStartElement("ProdutoCiclo");
                writer.WriteElementString("IdProdutoCiclo", leitura.idProdutoCiclo.ToString());
                writer.WriteElementString("Produto", leitura.produto.idProduto.ToString());
                writer.WriteElementString("Volume", leitura.volume);
                writer.WriteElementString("Unidade", leitura.unidade.idUnidade.ToString());
                writer.WriteElementString("Empresa", leitura.empresa.idEmpresa.ToString());
                writer.WriteElementString("Ciclo", leitura.ciclo.id.ToString());

                    writer.WriteEndElement();
            }

            writer.WriteEndElement();   // Fecha a tag <Ciclo>
        }

        private void ImportarExportar_Load(object sender, EventArgs e)
        {
            CarregaCiclos();
        }

        public void CarregaCiclos()
        {
            dtgAndamento.Rows.Clear();
            dtgFinalizados.Rows.Clear();
            List<VO.Ciclos> CiclosAndamento = CicloDAO.listaCiclosPorSituacaoAll(0);
            List<VO.Ciclos> CiclosFinalizados = CicloDAO.listaCiclosPorSituacaoAll(1);
            foreach (var c in CiclosAndamento)
            {
                dtgAndamento.Rows.Add(false, c.id, c.crg, c.numSerie, c.nTrat.ToString("000"), c.nl.ToString("000"), c.nlt.ToString("000"), c.dataColeta, c.dataInicio, c.descricao);
            }
            foreach (var c in CiclosFinalizados)
            {
                dtgFinalizados.Rows.Add(false, c.id, c.crg, c.numSerie, c.nTrat.ToString("000"), c.nl.ToString("000"), c.nlt.ToString("000"), c.dataColeta, c.dataInicio, c.descricao);
            }
        }

        private LeiturasCiclo CarregaLeiturasCiclo(XmlReader reader)
        {
            var tag = "";
            var leiturasCiclo = new LeiturasCiclo();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        tag = reader.Name;
                        break;
                    case XmlNodeType.Text:

                        switch (tag)
                        {
                            case "IdLeituraCiclo":
                                leiturasCiclo.idLeiturasCiclo = Convert.ToInt32(reader.Value);
                                break;
                            case "Horario":
                                leiturasCiclo.horario = reader.Value;
                                break;
                            case "T1":
                                leiturasCiclo.T1 = Convert.ToSingle(reader.Value);
                                break;
                            case "T2":
                                leiturasCiclo.T2 = Convert.ToSingle(reader.Value);
                                break;
                            case "T3":
                                leiturasCiclo.T3 = Convert.ToSingle(reader.Value);
                                break;
                            case "T4":
                                leiturasCiclo.T4 = Convert.ToSingle(reader.Value);
                                break;
                            case "Ciclo":
                                leiturasCiclo.ciclo = new VO.Ciclos();
                                leiturasCiclo.ciclo.id = Convert.ToInt32(reader.Value);
                                break;
                        }
                        break;
                }
            }

            return leiturasCiclo;
        }

        private LeiturasTrat CarregaLeituraTratamento(XmlReader reader)
        {
            var tag = "";
            var leituraTratamento = new LeiturasTrat();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        tag = reader.Name;
                        break;
                    case XmlNodeType.Text:

                        switch (tag)
                        {
                            case "IdLeituraTratamento":
                                leituraTratamento.idLeiturasTrat = Convert.ToInt32(reader.Value);
                                break;
                            case "Horario":
                                leituraTratamento.horario = reader.Value;
                                break;
                            case "T1":
                                leituraTratamento.T1 = Convert.ToSingle(reader.Value);
                                break;
                            case "T2":
                                leituraTratamento.T2 = Convert.ToSingle(reader.Value);
                                break;
                            case "T3":
                                leituraTratamento.T3 = Convert.ToSingle(reader.Value);
                                break;
                            case "T4":
                                leituraTratamento.T4 = Convert.ToSingle(reader.Value);
                                break;
                            case "Ciclo":
                                leituraTratamento.ciclo = new VO.Ciclos();
                                leituraTratamento.ciclo.id = Convert.ToInt32(reader.Value);
                                break;
                        }
                        break;
                }
            }

            return leituraTratamento;
        }

        private ProdutoCiclo CarregaProdutos(XmlReader reader)
        {
            var tag = "";
            var produtosCiclo = new ProdutoCiclo();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        tag = reader.Name;
                        break;
                    case XmlNodeType.Text:

                        switch (tag)
                        {
                            case "IdProdutoCiclo":
                                produtosCiclo.idProdutoCiclo = Convert.ToInt32(reader.Value);
                                break;
                            case "Produto":
                                produtosCiclo.produto = new Produto();
                                produtosCiclo.produto.idProduto = Convert.ToInt32(reader.Value);
                                break;
                            case "Volume":
                                produtosCiclo.volume = reader.Value;
                                break;
                            case "Unidade":
                                produtosCiclo.unidade = new Unidade();
                                produtosCiclo.unidade.idUnidade = Convert.ToInt32(reader.Value);
                                break;
                            case "Empresa":
                                produtosCiclo.empresa = new EmpresaCiclo();
                                produtosCiclo.empresa.idEmpresa = Convert.ToInt32(reader.Value);
                                break;
                            case "Ciclo":
                                produtosCiclo.ciclo = new VO.Ciclos();
                                produtosCiclo.ciclo.id = Convert.ToInt32(reader.Value);
                                break;
                        }
                        break;
                }
            }

            return produtosCiclo;
        }

        private void ImportarCiclo(ImportarCiclo ciclo)
        {
            try
            {
                // Inclui o ciclo no banco de dados
                CicloDAO.inserirCiclo(ciclo.ciclo);
                ciclo.ciclo.id = CicloDAO.retornaId(ciclo.ciclo);
                
                // Insere as leituras da ciclo
                if (ciclo.ciclo.tipoCRG == 2) LeiturasCicloDAO.inserirLeiturasCiclo150(ciclo.leiturasCiclo, 0, ciclo.ciclo);
                else LeiturasCicloDAO.inserirLeiturasCiclo(ciclo.leiturasCiclo,0,ciclo.ciclo);

                // Caso haja tratamento, insere-se neste método
                if (ciclo.leiturasTratamento.Count > 0)
                {
                    if (ciclo.ciclo.tipoCRG == 2) LeiturasTratDAO.inserirLeiturasTratamento150(ciclo.leiturasTratamento, 0, ciclo.ciclo);
                    else LeiturasTratDAO.inserirLeiturasTratamento(ciclo.leiturasTratamento, 0, ciclo.ciclo);
                }
                foreach (var p in ciclo.produtosCiclo)
                {
                    //Insere produtos do ciclo
                    p.ciclo.id = ciclo.ciclo.id;
                    ProdutoCicloDAO.inserirProdutoCiclo(p);
                }
                
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private void Exportar_CheckedChanged(object sender, EventArgs e)
        {
            if (Exportar.Checked)
            {
                Arquivo.Text = "Salvar como Arquivo";
                Email.Enabled = true;
            }
            else
            {
                Arquivo.Text = "Abrir Arquivo";
                Email.Enabled = false;
            }

        }

        private void Email_Click(object sender, EventArgs e)
        {
            FormularioEmail form = new FormularioEmail(this);
            form.ShowDialog(this);
            if (continuarExportandoEmail)
            {
                var crg = 0;

                FileInfo file = new FileInfo(@Environment.CurrentDirectory + "\\CiclosExportados.crg08");
                if (file.Exists) file.Delete();

                var writer = new XmlTextWriter(Environment.CurrentDirectory + "\\CiclosExportados.crg08", null);
                // Gera o XML de cada ciclo
                try
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Ciclos");

                    for (int i = 0; i < dtgAndamento.RowCount; i++)
                    {
                        if (dtgAndamento.Rows[i].Cells[0].Value.ToString() == "True")
                        {
                            var id = int.Parse(dtgAndamento.Rows[i].Cells[1].Value.ToString());
                            crg = int.Parse(dtgAndamento.Rows[i].Cells[2].Value.ToString());
                            var ciclo = CicloDAO.buscaCiclo(crg, id);

                            ExportarCiclo(writer, ciclo, i + 1);
                        }
                    }

                    for (int i = 0; i < dtgFinalizados.RowCount; i++)
                    {
                        if (dtgFinalizados.Rows[i].Cells[0].Value.ToString() == "True")
                        {

                            var id = int.Parse(dtgFinalizados.Rows[i].Cells[1].Value.ToString());
                            crg = int.Parse(dtgFinalizados.Rows[i].Cells[2].Value.ToString());
                            var ciclo = CicloDAO.buscaCiclo(crg, id);

                            ExportarCiclo(writer, ciclo, i + 1);
                        }
                    }

                    writer.WriteFullEndElement();
                    writer.WriteEndDocument();
                }
                catch (Exception error)
                {
                    VO.LogErro logErro = new VO.LogErro();
                    logErro.crg = crg;
                    logErro.descricao = "Erro ao tentar exportar";
                    string dataHora = DateTime.Now.ToString();
                    logErro.data = DateTime.Now;
                    logErro.maisDetalhes = error.Message;
                    LogErroDAO.inserirLogErro(logErro, logErro.crg);
                    MessageBox.Show("Erro ao tentar exportar por email.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    writer.Flush();
                    writer.Close();

                    var xmlDoc = new XmlDocument();

                    try
                    {
                        xmlDoc.PreserveWhitespace = true;
                        xmlDoc.Load(file.Name);
                    }
                    catch (Exception er)
                    {
                        Console.WriteLine(er.Message);
                    }

                    var cspParams = new CspParameters();
                    cspParams.KeyContainerName = "CRG08";

                    var rsaKey = new RSACryptoServiceProvider(cspParams);

                    try
                    {
                        Crypto.Encrypt(xmlDoc, "Ciclo", "Ciclo", rsaKey, "rsaKey");
                        xmlDoc.Save(file.Name);
                    }
                    catch (Exception er)
                    {
                        VO.LogErro logErro = new VO.LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro ao tentar exportar";
                        string dataHora = DateTime.Now.ToString();
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = er.Message;
                        LogErroDAO.inserirLogErro(logErro, logErro.crg);
                        MessageBox.Show("Erro ao tentar exportar por email.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    MailMessage msg = new MailMessage();
                    List<Destinatarios> listaDestinatarios = ListaDestinatarios();
                    string[] dadosConfiguracao = ObterDadosEmail();

                    if (listaDestinatarios.Count > 0)
                    {
                        msg.From = new MailAddress(dadosConfiguracao[1]);
                        foreach (var d in listaDestinatarios)
                        {
                            msg.To.Add(new MailAddress(d.email));
                        }
                        msg.Subject = "Envio de Ciclos Exportados pelo CRG 08";
                        msg.Body = "Ciclo exportado no dia " + DateTime.Today.ToString().Substring(0, 10) +
                                   " do equipamento CRG 08 enviado via software do CRG 08 desenvolvido pela Digisystem Indústria de " +
                                   "Sistema Eletrônico LTDA, e autorizado conforme configuração do usuário no software.";

                        msg.Attachments.Add(new Attachment(@Environment.CurrentDirectory + "\\CiclosExportados.crg08"));

                        SmtpClient smtp = new SmtpClient(dadosConfiguracao[0]);
                        smtp.Port = Convert.ToInt32(dadosConfiguracao[4]);
                        if (int.Parse(dadosConfiguracao[5]) == 1) smtp.EnableSsl = true;
                        else smtp.EnableSsl = false;
                        smtp.Credentials = new NetworkCredential(dadosConfiguracao[2], dadosConfiguracao[3]);
                        smtp.SendAsync(msg, msg.Subject);
                        smtp.SendCompleted += new SendCompletedEventHandler(stmp_SendCompletedRGD);
                    }
                    MessageBox.Show("O email foi enviado com sucesso!", "Sucesso", MessageBoxButtons.OK,MessageBoxIcon.None);
                }
            }
        }

        public void ContinuaEnviandoPorEmail()
        {
            continuarExportandoEmail = true;
        }

        public static List<Destinatarios> ListaDestinatarios()
        {
            try
            {
                List<Destinatarios> destinatarios = new List<Destinatarios>();
                var path = Environment.CurrentDirectory + "\\Destinatarios.xml";
                var stream = new MemoryStream();
                var xmlDocument = new XmlDocument();
                var cspParams = new CspParameters();

                cspParams.KeyContainerName = "Destinatarios";
                var rsaKey = new RSACryptoServiceProvider(cspParams);

                xmlDocument.PreserveWhitespace = true;
                xmlDocument.Load(path);

                Crypto.Decrypt(xmlDocument, rsaKey, "rsaKey");

                xmlDocument.Save(stream);
                stream.Flush();
                stream.Position = 0;

                XDocument xml = XDocument.Load(stream);

                foreach (XElement x in xml.Element("Destinatarios").Elements())
                {
                    Destinatarios d = new Destinatarios()
                    {
                        id = int.Parse(x.Attribute("Id").Value),
                        email = x.Attribute("Email").Value
                    };
                    destinatarios.Add(d);
                }
                return destinatarios;
            }
            catch (Exception er)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao tentar listar destinatários";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = er.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                return new List<Destinatarios>();
            }
        }

        private string[] ObterDadosEmail()
        {
            try
            {
                var path = Environment.CurrentDirectory + "\\ConfiguracaoEmail.xml";
                var stream = new MemoryStream();
                var xmlDocument = new XmlDocument();
                var cspParams = new CspParameters();

                cspParams.KeyContainerName = "Configuracao";
                var rsaKey = new RSACryptoServiceProvider(cspParams);

                xmlDocument.PreserveWhitespace = true;
                xmlDocument.Load(path);

                Crypto.Decrypt(xmlDocument, rsaKey, "rsaKey");

                xmlDocument.Save(stream);
                stream.Flush();
                stream.Position = 0;

                XDocument doc = XDocument.Load(stream);
                var config = doc.Element("ConfiguracaoEmail").Element("Configuracao");
                string[] retorno = new string[6];
                retorno[0] = config.Element("SMTP").Value;
                retorno[1] = config.Element("De").Value;
                retorno[2] = config.Element("NomeUsuario").Value;
                retorno[3] = config.Element("Senha").Value;
                retorno[4] = config.Element("Porta").Value;
                retorno[5] = config.Element("SSL").Value;
                return retorno;
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao obter dados da Configuração de Email";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao obter dados da Configuração de Email", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return new string[6];
            }
        }

        public void stmp_SendCompletedRGD(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                mensagem = "Email sending cancelled!";
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao tentar enviar os relatórios da pressão diários";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = mensagem;
                LogErroDAO.inserirLogErro(logErro, logErro.crg);
            }
            else if (e.Error != null)
            {
                mensagem = e.Error.Message;
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao tentar enviar os relatórios da pressão diários";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = mensagem;
                LogErroDAO.inserirLogErro(logErro, logErro.crg);
            }
            else
            {
                mensagem = "Email sent sucessfully!";
            }
        }
    }
}
