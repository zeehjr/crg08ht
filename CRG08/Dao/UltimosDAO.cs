using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRG08.BO;
using CRG08.VO;

namespace CRG08.Dao
{
    public class UltimosDAO
    {
        #region UltimoCRG
        public static int RetornaUltimoCRG()
        {
            var lista = Utils.ExecutaQueryDados("SELECT crg FROM ultimos order by id desc rows 1");
            if (lista == null || lista.Count == 0) return -1;
            return Convert.ToInt32(lista.First()["CRG"]);
        }

        public static bool SetarUltimoCRG(int numCRG)
        {
            var cntErros = ErrorHandler.GetAllErrors.Count;
            Utils.ExecutaQuery("UPDATE ULTIMOS SET CRG = " + numCRG);
            return ErrorHandler.GetAllErrors.Count == cntErros;
        }
        #endregion

        #region UltimoOperador
        public static string RetornaUltimoOperador()
        {
            var lista = Utils.ExecutaQueryDados("SELECT operador FROM ultimos order by id desc rows 1");
            if (lista == null || lista.Count == 0) return string.Empty;
            return lista.First()["OPERADOR"].ToString();
        }

        public static bool SetarUltimoOperador(string operador)
        {
            var cntErros = ErrorHandler.GetAllErrors.Count;
            Utils.ExecutaQuery("UPDATE ULTIMOS SET OPERADOR = '" + operador + "'");
            return ErrorHandler.GetAllErrors.Count == cntErros;
        }
        #endregion

        #region UltimoResponsavel
        public static string RetornaUltimoResponsavel()
        {
            var lista = Utils.ExecutaQueryDados("SELECT responsavel FROM ultimos order by id desc rows 1");
            if (lista == null || lista.Count == 0) return string.Empty;
            return lista.First()["RESPONSAVEL"].ToString();
        }

        public static bool SetarUltimoResponsavel(string responsavel)
        {
            var cntErros = ErrorHandler.GetAllErrors.Count;
            Utils.ExecutaQuery("UPDATE ULTIMOS SET RESPONSAVEL = '" + responsavel + "'");
            return ErrorHandler.GetAllErrors.Count == cntErros;
        }
        #endregion

        #region UltimoFiltro
        public static UltimoFiltro RetornaUltimoFiltro()
        {
            var lista = Utils.ExecutaQueryDados(
                "SELECT valorfiltro, datainicio, datafim, equipamento, qtdmeses FROM ultimos order by id desc rows 1");
            if (lista == null || lista.Count == 0) return null;
            var retorno = new UltimoFiltro();
            var item = lista.First();
            retorno.ValorFiltro = Convert.ToInt32(item["VALORFILTRO"]);
            retorno.DataInicio = item["DATAINICIO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(item["DATAINICIO"]);
            retorno.DataFim = item["DATAFIM"] == DBNull.Value ? DateTime.MaxValue : Convert.ToDateTime(item["DATAFIM"]);
            retorno.Equipamento = Convert.ToInt32(item["EQUIPAMENTO"]);
            retorno.QtdMeses = Convert.ToInt32(item["QTDMESES"]);
            return retorno;
        }

        public static bool SetarUltimoFiltro(UltimoFiltro ultimoFiltro)
        {
            var cntErros = ErrorHandler.GetAllErrors.Count;
            Utils.ExecutaQuery("UPDATE ULTIMOS SET VALORFILTRO = " + ultimoFiltro.ValorFiltro + ", DATAINICIO = '" + ultimoFiltro.DataInicio.ToString("yyyy-MM-dd HH:mm") + "', DATAFIM = '" + ultimoFiltro.DataFim.ToString("yyyy-MM-dd HH:mm") + "', EQUIPAMENTO = " + ultimoFiltro.Equipamento + ", QTDMESES = " + ultimoFiltro.QtdMeses + ";");
            return ErrorHandler.GetAllErrors.Count == cntErros;
        }
        #endregion

        #region UltimoEquipamento
        public static int RetornaUltimoEquipamento()
        {
            var lista = Utils.ExecutaQueryDados("SELECT equipamento FROM ultimos order by id desc rows 1");
            if (lista == null || lista.Count == 0) return 1;
            return Convert.ToInt32(lista.First()["EQUIPAMENTO"]);
        }

        public static bool SetarUltimoEquipamento(int equipamento)
        {
            var cntErros = ErrorHandler.GetAllErrors.Count;
            Utils.ExecutaQuery("UPDATE ULTIMOS SET EQUIPAMENTO = " + equipamento);
            return ErrorHandler.GetAllErrors.Count == cntErros;
        }
        #endregion

        #region UltimaLogo
        public static string RetornaUltimaLogo()
        {
            var lista = Utils.ExecutaQueryDados("SELECT logo FROM ultimos order by id desc rows 1");
            if (lista == null || lista.Count == 0) return string.Empty;
            return lista.First()["LOGO"].ToString();
        }

        public static bool SetarUltimaLogo(string logo)
        {
            var cntErros = ErrorHandler.GetAllErrors.Count;
            Utils.ExecutaQuery("UPDATE ULTIMOS SET LOGO = '" + logo + "'");
            return ErrorHandler.GetAllErrors.Count == cntErros;
        }
        #endregion

        #region UltimasCores
        public static CoresGrafico RetornaUltimasCores()
        {
            var lista = Utils.ExecutaQueryDados(
                "SELECT corest1, corest2, corest3, corest4, coresca FROM ultimos order by id desc rows 1");
            if (lista == null || lista.Count == 0) return null;
            var retorno = new CoresGrafico();
            var item = lista.First();
            retorno.T1RGB = item["COREST1"].ToString();
            retorno.T2RGB = item["COREST2"].ToString();
            retorno.T3RGB = item["COREST3"].ToString();
            retorno.T4RGB = item["COREST4"].ToString();
            retorno.CARGB = item["CORESCA"].ToString();
            return retorno;
        }

        public static bool SetarUltimasCores(CoresGrafico cores)
        {
            var cntErros = ErrorHandler.GetAllErrors.Count;
            Utils.ExecutaQuery("UPDATE ULTIMOS SET COREST1 = '" + cores.T1RGB + "', COREST2 = '" + cores.T2RGB + "', COREST3 = '" + cores.T3RGB + "', COREST4 = '" + cores.T4RGB + "', CORESCA = '" + cores.CARGB + "';");
            return ErrorHandler.GetAllErrors.Count == cntErros;
        }
        #endregion

        #region UltimasLegendas
        public static LegendasGrafico RetornaUltimasLegendas()
        {
            var lista = Utils.ExecutaQueryDados(
                "SELECT legendat1, legendat2, legendat3, legendat4, legendaca FROM ultimos order by id desc rows 1");
            if (lista == null || lista.Count == 0) return null;
            var retorno = new LegendasGrafico();
            var item = lista.First();
            retorno.T1 = item["LEGENDAT1"].ToString();
            retorno.T2 = item["LEGENDAT2"].ToString();
            retorno.T3 = item["LEGENDAT3"].ToString();
            retorno.T4 = item["LEGENDAT4"].ToString();
            retorno.CA = item["LEGENDACA"].ToString();
            return retorno;
        }

        public static bool SetarUltimasLegendas(LegendasGrafico legendas)
        {
            var cntErros = ErrorHandler.GetAllErrors.Count;
            Utils.ExecutaQuery("UPDATE ULTIMOS SET LEGENDAT1 = '" + legendas.T1 + "', LEGENDAT2 = '" + legendas.T2 + "', LEGENDAT3 = '" + legendas.T3 + "', LEGENDAT4 = '" + legendas.T4 + "', LEGENDACA = '" + legendas.CA + "';");
            return ErrorHandler.GetAllErrors.Count == cntErros;
        }
        #endregion

        #region PrimeiraInicializacao
        public static bool RetornaPrimeiraInicializacao()
        {
            var lista = Utils.ExecutaQueryDados("SELECT primeira_inicializacao FROM ultimos order by id desc rows 1");
            if (lista == null || lista.Count == 0) return true;
            return Convert.ToInt32(lista.First()["PRIMEIRA_INICIALIZACAO"])==1;
        }

        public static bool SetarPrimeiraInicializacao(bool primeiraInicializacao)
        {
            var cntErros = ErrorHandler.GetAllErrors.Count;
            Utils.ExecutaQuery("UPDATE ULTIMOS SET PRIMEIRA_INICIALIZACAO = " + (primeiraInicializacao?1:0));
            return ErrorHandler.GetAllErrors.Count == cntErros;
        }
        #endregion

        #region UltimaComunicacao

        public static ComunicacaoSelecionada RetornaUltimaComunicacao()
        {
            var lista = Utils.ExecutaQueryDados("SELECT comunicacao_tipo, comunicacao_apenasaparelho, crg from ULTIMOS order by id desc rows 1");
            if (lista == null || lista.Count == 0) return new ComunicacaoSelecionada();
            var online = Convert.ToInt32(lista.First()["COMUNICACAO_TIPO"]) == 1;
            var apenasAparelho = Convert.ToInt32(lista.First()["COMUNICACAO_APENASAPARELHO"]) == 1;
            var crg = Convert.ToInt32(lista.First()["CRG"]);
            return new ComunicacaoSelecionada
            {
                ApenasAparelho = apenasAparelho,
                NumCRG = crg,
                Online = online
            };
        }

        public static bool SetarUltimaComunicacao(ComunicacaoSelecionada comunicacao)
        {
            var cntErros = ErrorHandler.GetAllErrors.Count;
            if (comunicacao.ApenasAparelho && comunicacao.NumCRG > 0)
            {
                Utils.ExecutaQuery("UPDATE ULTIMOS SET COMUNICACAO_TIPO = " + (comunicacao.Online ? 1 : 0) + ", COMUNICACAO_APENASAPARELHO = 1, CRG = " + comunicacao.NumCRG);
                goto Retorno;
            }
            Utils.ExecutaQuery("UPDATE ULTIMOS SET COMUNICACAO_TIPO = " + (comunicacao.Online ? 1 : 0) + ", COMUNICACAO_APENASAPARELHO = 0");

            Retorno:
            return cntErros == ErrorHandler.GetAllErrors.Count;
        }
        #endregion
    }
}
