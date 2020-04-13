using Model.Dao;
using PlatinDashboard.Presentation.MVC.ApiServices;
using System.Collections.Generic;

namespace Model.Neg
{
    public class AbcFatmaNeg
    {
        private AbcFarmaDao objAbcFatmaDao;

        public AbcFatmaNeg()
        {
            objAbcFatmaDao = new AbcFarmaDao();

        }
        public bool find(ProdutosAbcFarma objProdutosAbcFarma)
        {
            return objAbcFatmaDao.find(objProdutosAbcFarma);
        }
        public List<ProdutosAbcFarma> findAll()
        {
            return objAbcFatmaDao.findAll();
        }
        public void delete(ProdutosAbcFarma objProdutosAbcFarma)
        {
            bool verificacao = true;
            //verificando se existe
            ProdutosAbcFarma objProdutosAbcFarmaAux = new ProdutosAbcFarma();
            objProdutosAbcFarmaAux.EAN = objProdutosAbcFarma.EAN;
            verificacao = objAbcFatmaDao.find(objProdutosAbcFarmaAux);
            if (!verificacao)
            {
                objProdutosAbcFarma.Estados = 33;
                return;
            }


            objProdutosAbcFarma.Estados = 99;
            objAbcFatmaDao.delete(objProdutosAbcFarma);
            return;
        }

        public void create(ProdutosAbcFarma obj)
        {
            bool verificacao = true;

            string ID_PRODUTO = obj.ID_PRODUTO?.ToString() ??" ";
            string EAN = obj.EAN?.ToString() ??" ";
            string REGISTRO_ANVISA = obj.REGISTRO_ANVISA?.ToString() ??" ";
            string GGREM = obj.GGREM?.ToString() ??" ";
            string NOME = obj.NOME?.ToString() ??" ";
            string DESCRICAO = obj.DESCRICAO?.ToString() ??" ";
            string COMPOSICAO = obj.COMPOSICAO?.ToString() ??" ";
            string QTD_EMBALAGEM = obj.QTD_EMBALAGEM?.ToString() ??" ";
            string PF_20 = obj.PF_20?.ToString() ??" ";
            string PMC_20 = obj.PMC_20?.ToString() ??" ";
            string PF_18 = obj.PF_18?.ToString() ??" ";
            string PMC_18 = obj.PMC_18?.ToString() ??" ";
            string PF_17 = obj.PF_17?.ToString() ??" ";
            string PMC_17 = obj.PMC_17?.ToString() ??" ";
            string PF_17_5 = obj.PF_17_5?.ToString() ??" ";
            string PMC_17_5 = obj.PMC_17_5?.ToString() ??" ";
            string PF_12 = obj.PF_12?.ToString() ??" ";
            string PMC_12 = obj.PMC_12?.ToString() ??" ";
            string PF_0 = obj.PF_0?.ToString() ??" ";
            string PMC_0 = obj.PMC_0?.ToString() ??" ";
            string PERCENTUAL_IPI = obj.PERCENTUAL_IPI?.ToString() ??" ";
            string DATA_VIGENCIA = obj.DATA_VIGENCIA.ToString();
            string NOVO = obj.NOVO?.ToString() ??" ";
            string VARIACAO_PRECO = obj.VARIACAO_PRECO?.ToString() ??" ";
            string PF_17_ALC = obj.PF_17_ALC?.ToString() ??" ";
            string PMC_17_ALC = obj.PMC_17_ALC?.ToString() ??" ";
            string PF_17_5_ALC = obj.PF_17_5_ALC?.ToString() ??" ";
            string PMC_17_5_ALC = obj.PMC_17_5_ALC?.ToString() ??" ";
            string PF_18_ALC = obj.PF_18_ALC?.ToString() ??" ";
            string PMC_18_ALC = obj.PMC_18_ALC?.ToString() ??" ";
            string NCM = obj.NCM?.ToString() ??" ";
            string ID_TARJA = obj.ID_TARJA?.ToString() ??" ";
            string CLASSE_TERAPEUTICA = obj.CLASSE_TERAPEUTICA?.ToString() ??" ";
            string PORTARIA_344_98 = obj.PORTARIA_344_98?.ToString() ??" ";
            string PRODUTO_REFERENCIA = obj.PRODUTO_REFERENCIA?.ToString() ??" ";
            string CAS = obj.CAS?.ToString() ??" ";
            string DCB = obj.DCB?.ToString() ??" ";
            string ATC_CODE = obj.ATC_CODE?.ToString() ??" ";
            string CAP = obj.CAP?.ToString() ??" ";
            string CONFAZ_87 = obj.CONFAZ_87?.ToString() ??" ";
            string TISS_TUSS = obj.TISS_TUSS?.ToString() ??" ";
            string CEST = obj.CEST?.ToString() ??" ";
            string ID_FABRICANTE = obj.ID_FABRICANTE?.ToString() ??" ";
            string NOME_FABRICANTE = obj.NOME_FABRICANTE?.ToString() ??" ";
            string ID_LCCT = obj.ID_LCCT?.ToString() ??" ";
            string DESCRICAO_LISTA = obj.DESCRICAO_LISTA?.ToString() ??" ";
            string ID_REGIME_PRECO = obj.ID_REGIME_PRECO?.ToString() ??" ";
            string DESCRICAO_REGIME_PRECO = obj.DESCRICAO_REGIME_PRECO?.ToString() ??" ";
            string ID_TIPO_PRODUTO = obj.ID_TIPO_PRODUTO?.ToString() ??" ";
            string DESCRICAO_TIPO_PRODUTO = obj.DESCRICAO_TIPO_PRODUTO?.ToString() ??" ";
            string ArquivoGerado = obj.ArquivoGerado?.ToString() ??" ";

            //begin verificar duplicidade cpf retorna estado=8
            ProdutosAbcFarma objProdutosAbcFarma1 = new ProdutosAbcFarma();
            objProdutosAbcFarma1.EAN = obj.EAN;
            verificacao = !objAbcFatmaDao.buscarProdutoPorEan(objProdutosAbcFarma1);
            //if (!verificacao)
            //{
            //    obj.Estados = 9;
            //    return;
            //}


            //se nao tem erro
            obj.Estados = 99;

            objAbcFatmaDao.create(obj);
            return;
        }
    }
}
