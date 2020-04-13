using Model.Entity;
using Model.Neg;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace PlatinDashboard.Presentation.MVC.ApiServices
{
    public class ServicosApi
    {
        private readonly string _abcfarmaUrl = ConfigurationManager.AppSettings["abcfarmaUrl"];
        private readonly string _cnpj_cpf = ConfigurationManager.AppSettings["cnpj_cpf"];
        private readonly string _senha = ConfigurationManager.AppSettings["senha"];
        private readonly string _cnpj_sh = ConfigurationManager.AppSettings["cnpj_sh"];

        public List<ProdutosAbcFarma> BuscarTodosProdutos(int pagina,int gravar)
        {
            #region Variaveis 
            string url = _abcfarmaUrl;
            string v_pagina = pagina.ToString();
            #endregion

            var cli = new WebClient();
            cli.Headers.Clear();
            cli.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

            string parametros = "cnpj_cpf=" + _cnpj_cpf + "&senha=" + _senha + "&cnpj_sh=" + _cnpj_sh + "&pagina=" + v_pagina;
            var response = cli.UploadString(url, parametros);

            ProdutosAbcFarmaHeader listaprodutos = JsonConvert.DeserializeObject<ProdutosAbcFarmaHeader>(response);

            // Cria o arquivo a ser baixado
            var nomearquivo = DateTime.Now.ToString("ddMMyyyhhmmss");

            return listaprodutos.data;
           
        }

        public bool GravarArquivoProdutos()
        {
            // Lista todos os Itens da tabela do mes atual e grava na tabela do mes anterior
            string ArquivoGerado = "";
            var ObjAbcFarmaAnteriorNeg = new AbcFarmaAnteriorNeg();
            var ObjAbcFatmaNeg = new AbcFatmaNeg();
            var nomearquivo = DateTime.Now.ToString("ddMMyyyhhmmss");
            string arquivo = HttpContext.Current.Server.MapPath("/Arquivos/altpreco_" + nomearquivo + ".abc");
            StreamWriter file = new StreamWriter(arquivo);
            string cEspaco = "";
            var ProdutosBase = ObjAbcFatmaNeg.findAll().OrderBy(p => p.NOME);
            foreach (var abcProduto in ProdutosBase)
            {
                ProdutosAbcFarmaAnterior objProduto2 = new ProdutosAbcFarmaAnterior();
                objProduto2.ATC_CODE = abcProduto.ATC_CODE;
                objProduto2.CAP = abcProduto.CAP;
                objProduto2.CAS = abcProduto.CAS;
                objProduto2.CEST = abcProduto.CEST;
                objProduto2.CLASSE_TERAPEUTICA = abcProduto.CLASSE_TERAPEUTICA;
                objProduto2.COMPOSICAO = abcProduto.COMPOSICAO;
                objProduto2.CONFAZ_87 = abcProduto.CONFAZ_87;
                objProduto2.DATA_VIGENCIA = abcProduto.DATA_VIGENCIA;
                objProduto2.DCB = abcProduto.DCB;
                objProduto2.DESCRICAO = abcProduto.DESCRICAO;
                objProduto2.DESCRICAO_LISTA = abcProduto.DESCRICAO_LISTA;
                objProduto2.DESCRICAO_REGIME_PRECO = abcProduto.DESCRICAO_REGIME_PRECO;
                objProduto2.DESCRICAO_TIPO_PRODUTO = abcProduto.DESCRICAO_TIPO_PRODUTO;
                objProduto2.EAN = abcProduto.EAN;
                objProduto2.GGREM = abcProduto.GGREM;
                objProduto2.ID_FABRICANTE = abcProduto.ID_FABRICANTE;
                objProduto2.ID_LCCT = abcProduto.ID_LCCT;
                objProduto2.ID_PRODUTO = abcProduto.ID_PRODUTO;
                objProduto2.ID_REGIME_PRECO = abcProduto.ID_REGIME_PRECO;
                objProduto2.ID_TARJA = abcProduto.ID_TARJA;
                objProduto2.ID_TIPO_PRODUTO = abcProduto.ID_TIPO_PRODUTO;
                objProduto2.NCM = abcProduto.NCM;
                objProduto2.NOME = abcProduto.NOME;
                objProduto2.NOME_FABRICANTE = abcProduto.NOME_FABRICANTE;
                objProduto2.NOVO = abcProduto.NOVO;
                objProduto2.PERCENTUAL_IPI = abcProduto.PERCENTUAL_IPI;
                objProduto2.PF_0 = abcProduto.PF_0;
                objProduto2.PF_12 = abcProduto.PF_12;
                objProduto2.PF_17 = abcProduto.PF_17;
                objProduto2.PF_17_5 = abcProduto.PF_17_5;
                objProduto2.PF_17_5_ALC = abcProduto.PF_17_5_ALC;
                objProduto2.PF_17_ALC = abcProduto.PF_17_ALC;
                objProduto2.PF_18 = abcProduto.PF_18;
                objProduto2.PF_18_ALC = abcProduto.PF_18_ALC;
                objProduto2.PF_20 = abcProduto.PF_20;
                objProduto2.PMC_0 = abcProduto.PMC_0;
                objProduto2.PMC_12 = abcProduto.PMC_12;
                objProduto2.PMC_17 = abcProduto.PMC_17;
                objProduto2.PMC_17_5 = abcProduto.PMC_17_5;
                objProduto2.PMC_17_5_ALC = abcProduto.PMC_17_5_ALC;
                objProduto2.PMC_17_ALC = abcProduto.PMC_17_ALC;
                objProduto2.PMC_18 = abcProduto.PMC_18;
                objProduto2.PMC_18_ALC = abcProduto.PMC_18_ALC;
                objProduto2.PMC_20 = abcProduto.PMC_20;
                objProduto2.PORTARIA_344_98 = abcProduto.PORTARIA_344_98;
                objProduto2.PRODUTO_REFERENCIA = abcProduto.PRODUTO_REFERENCIA;
                objProduto2.QTD_EMBALAGEM = abcProduto.QTD_EMBALAGEM;
                objProduto2.REGISTRO_ANVISA = abcProduto.REGISTRO_ANVISA;
                objProduto2.TISS_TUSS = abcProduto.TISS_TUSS;
                objProduto2.VARIACAO_PRECO = abcProduto.VARIACAO_PRECO;

                if (objProduto2.ID_LCCT == "-") objProduto2.ID_LCCT = "0";
                if (objProduto2.ID_LCCT == "+") objProduto2.ID_LCCT = "1";
                if (objProduto2.ID_LCCT == "N") objProduto2.ID_LCCT = "2";
                if (objProduto2.ID_TIPO_PRODUTO != "G") objProduto2.ID_TIPO_PRODUTO = " ";

                ArquivoGerado = (objProduto2.EAN.Trim() + cEspaco.PadRight(13)).Substring(0, 13) +
                (objProduto2.NOME.Trim() + " " + objProduto2.DESCRICAO.Trim() + cEspaco.PadRight(30)).Substring(0, 30) +
                objProduto2.PF_20.Trim().PadLeft(11, '0').Replace(".", "") +
                objProduto2.PMC_20.Trim().PadLeft(11, '0').Replace(".", "") +
                (objProduto2.NOME_FABRICANTE.Trim() + cEspaco.PadRight(10)).Substring(0, 10) +
                objProduto2.PF_18.Trim().PadLeft(11, '0').Replace(".", "") +
                objProduto2.PMC_18.Trim().PadLeft(11, '0').Replace(".", "") +
                objProduto2.PF_17.Trim().PadLeft(11, '0').Replace(".", "") +
                objProduto2.PMC_17.Trim().PadLeft(11, '0').Replace(".", "") +
                objProduto2.PF_12.Trim().PadLeft(11, '0').Replace(".", "") +
                objProduto2.PMC_12.Trim().PadLeft(11, '0').Replace(".", "") +
                objProduto2.ID_LCCT.Trim().PadRight(1, '0') +
                objProduto2.ID_TIPO_PRODUTO +
                objProduto2.ID_REGIME_PRECO.Trim().PadRight(1, '0') +
                objProduto2.DATA_VIGENCIA.ToString().Trim().Substring(0, 10).PadRight(8).Replace("/", "") + "0";

                file.WriteLine(ArquivoGerado);
            }
            file.Close();

            return true;

        }
    }
}