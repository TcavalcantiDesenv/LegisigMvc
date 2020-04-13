using Model.Entity;
using PlatinDashboard.Presentation.MVC.ApiServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class AbcFarmaAnteriorDao
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public AbcFarmaAnteriorDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public bool find(ProdutosAbcFarmaAnterior obj)
        {
            bool temRegistros;
            string find = "select * from AbcFarmaAnterior where ID_PRODUTO='" + obj.ID_PRODUTO + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.ID_PRODUTO = reader["ID_PRODUTO"].ToString();
                    obj.EAN = reader["EAN"].ToString();
                    obj.REGISTRO_ANVISA = reader["REGISTRO_ANVISA"].ToString();
                    obj.GGREM = reader["GGREM"].ToString();
                    obj.NOME = reader["NOME"].ToString();
                    obj.DESCRICAO = reader["DESCRICAO"].ToString();
                    obj.COMPOSICAO = reader["COMPOSICAO"].ToString();
                    obj.QTD_EMBALAGEM = reader["QTD_EMBALAGEM"].ToString();
                    obj.PF_20 = reader["PF_20"].ToString();
                    obj.PMC_20 = reader["PMC_20"].ToString();
                    obj.PF_18 = reader["PF_18"].ToString();
                    obj.PMC_18 = reader["PMC_18"].ToString();
                    obj.PF_17 = reader["PF_17"].ToString();
                    obj.PMC_17 = reader["PMC_17"].ToString();
                    obj.PF_17_5 = reader["PF_17_5"].ToString();
                    obj.PMC_17_5 = reader["PMC_17_5"].ToString();
                    obj.PF_12 = reader["PF_12"].ToString();
                    obj.PMC_12 = reader["PMC_12"].ToString();
                    obj.PF_0 = reader["PF_0"].ToString();
                    obj.PMC_0 = reader["PMC_0"].ToString();
                    obj.PERCENTUAL_IPI = reader["PERCENTUAL_IPI"].ToString();
                    obj.DATA_VIGENCIA = Convert.ToDateTime(reader["DATA_VIGENCIA"].ToString());
                    obj.NOVO = reader["NOVO"].ToString();
                    obj.VARIACAO_PRECO = reader["VARIACAO_PRECO"].ToString();
                    obj.PF_17_ALC = reader["PF_17_ALC"].ToString();
                    obj.PMC_17_ALC = reader["PMC_17_ALC"].ToString();
                    obj.PF_17_5_ALC = reader["PF_17_5_ALC"].ToString();
                    obj.PMC_17_5_ALC = reader["PMC_17_5_ALC"].ToString();
                    obj.PF_18_ALC = reader["PF_18_ALC"].ToString();
                    obj.PMC_18_ALC = reader["PMC_18_ALC"].ToString();
                    obj.NCM = reader["NCM"].ToString();
                    obj.ID_TARJA = reader["ID_TARJA"].ToString();
                    obj.CLASSE_TERAPEUTICA = reader["CLASSE_TERAPEUTICA"].ToString();
                    obj.PORTARIA_344_98 = reader["PORTARIA_344_98"].ToString();
                    obj.PRODUTO_REFERENCIA = reader["PRODUTO_REFERENCIA"].ToString();
                    obj.CAS = reader["CAS"].ToString();
                    obj.DCB = reader["DCB"].ToString();
                    obj.ATC_CODE = reader["ATC_CODE"].ToString();
                    obj.CAP = reader["CAP"].ToString();
                    obj.CONFAZ_87 = reader["CONFAZ_87"].ToString();
                    obj.TISS_TUSS = reader["TISS_TUSS"].ToString();
                    obj.CEST = reader["CEST"].ToString();
                    obj.ID_FABRICANTE = reader["ID_FABRICANTE"].ToString();
                    obj.NOME_FABRICANTE = reader["NOME_FABRICANTE"].ToString();
                    obj.ID_LCCT = reader["ID_LCCT"].ToString();
                    obj.DESCRICAO_LISTA = reader["DESCRICAO_LISTA"].ToString();
                    obj.ID_REGIME_PRECO = reader["ID_REGIME_PRECO"].ToString();
                    obj.DESCRICAO_REGIME_PRECO = reader["DESCRICAO_REGIME_PRECO"].ToString();
                    obj.ID_TIPO_PRODUTO = reader["ID_TIPO_PRODUTO"].ToString();
                    obj.DESCRICAO_TIPO_PRODUTO = reader["DESCRICAO_TIPO_PRODUTO"].ToString();
                    obj.ArquivoGerado = reader["ArquivoGerado"].ToString();
                    obj.Estados = 99;
                }
                else
                {
                    obj.Estados = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return temRegistros;
        }
        public bool buscarProdutoPorEan(ProdutosAbcFarmaAnterior obj)
        {
            bool temRegistros;
            string find = "select * from AbcFarmaAnterior where EAN='" + obj.EAN + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.ID_PRODUTO = reader["ID_PRODUTO"].ToString();
                    obj.EAN = reader["EAN"].ToString();
                    obj.REGISTRO_ANVISA = reader["REGISTRO_ANVISA"].ToString();
                    obj.GGREM = reader["GGREM"].ToString();
                    obj.NOME = reader["NOME"].ToString();
                    obj.DESCRICAO = reader["DESCRICAO"].ToString();
                    obj.COMPOSICAO = reader["COMPOSICAO"].ToString();
                    obj.QTD_EMBALAGEM = reader["QTD_EMBALAGEM"].ToString();
                    obj.PF_20 = reader["PF_20"].ToString();
                    obj.PMC_20 = reader["PMC_20"].ToString();
                    obj.PF_18 = reader["PF_18"].ToString();
                    obj.PMC_18 = reader["PMC_18"].ToString();
                    obj.PF_17 = reader["PF_17"].ToString();
                    obj.PMC_17 = reader["PMC_17"].ToString();
                    obj.PF_17_5 = reader["PF_17_5"].ToString();
                    obj.PMC_17_5 = reader["PMC_17_5"].ToString();
                    obj.PF_12 = reader["PF_12"].ToString();
                    obj.PMC_12 = reader["PMC_12"].ToString();
                    obj.PF_0 = reader["PF_0"].ToString();
                    obj.PMC_0 = reader["PMC_0"].ToString();
                    //       obj.PERCENTUAL_IPI = reader["PERCENTUAL_IPI"].ToString();
                    obj.DATA_VIGENCIA = Convert.ToDateTime(reader["DATA_VIGENCIA"].ToString());
                    obj.NOVO = reader["NOVO"].ToString();
                    obj.VARIACAO_PRECO = reader["VARIACAO_PRECO"].ToString();
                    obj.PF_17_ALC = reader["PF_17_ALC"].ToString();
                    obj.PMC_17_ALC = reader["PMC_17_ALC"].ToString();
                    obj.PF_17_5_ALC = reader["PF_17_5_ALC"].ToString();
                    obj.PMC_17_5_ALC = reader["PMC_17_5_ALC"].ToString();
                    obj.PF_18_ALC = reader["PF_18_ALC"].ToString();
                    obj.PMC_18_ALC = reader["PMC_18_ALC"].ToString();
                    obj.NCM = reader["NCM"].ToString();
                    obj.ID_TARJA = reader["ID_TARJA"].ToString();
                    obj.CLASSE_TERAPEUTICA = reader["CLASSE_TERAPEUTICA"].ToString();
                    obj.PORTARIA_344_98 = reader["PORTARIA_344_98"].ToString();
                    obj.PRODUTO_REFERENCIA = reader["PRODUTO_REFERENCIA"].ToString();
                    obj.CAS = reader["CAS"].ToString();
                    obj.DCB = reader["DCB"].ToString();
                    obj.ATC_CODE = reader["ATC_CODE"].ToString();
                    obj.CAP = reader["CAP"].ToString();
                    obj.CONFAZ_87 = reader["CONFAZ_87"].ToString();
                    obj.TISS_TUSS = reader["TISS_TUSS"].ToString();
                    obj.CEST = reader["CEST"].ToString();
                    obj.ID_FABRICANTE = reader["ID_FABRICANTE"].ToString();
                    obj.NOME_FABRICANTE = reader["NOME_FABRICANTE"].ToString();
                    obj.ID_LCCT = reader["ID_LCCT"].ToString();
                    obj.DESCRICAO_LISTA = reader["DESCRICAO_LISTA"].ToString();
                    obj.ID_REGIME_PRECO = reader["ID_REGIME_PRECO"].ToString();
                    obj.DESCRICAO_REGIME_PRECO = reader["DESCRICAO_REGIME_PRECO"].ToString();
                    obj.ID_TIPO_PRODUTO = reader["ID_TIPO_PRODUTO"].ToString();
                    obj.DESCRICAO_TIPO_PRODUTO = reader["DESCRICAO_TIPO_PRODUTO"].ToString();
                    obj.ArquivoGerado = reader["ArquivoGerado"].ToString();

                    obj.Estados = 99;

                }
                else
                {
                    obj.Estados = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
            return temRegistros;
        }

        public List<ProdutosAbcFarmaAnterior> findAll()
        {
            List<ProdutosAbcFarmaAnterior> listaClientes = new List<ProdutosAbcFarmaAnterior>();
            string find = "select * from AbcFarmaAnterior order by NomeFantasia asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ProdutosAbcFarmaAnterior obj = new ProdutosAbcFarmaAnterior();
                    obj.ID_PRODUTO = reader["ID_PRODUTO"].ToString();
                    obj.EAN = reader["EAN"].ToString();
                    obj.REGISTRO_ANVISA = reader["REGISTRO_ANVISA"].ToString();
                    obj.GGREM = reader["GGREM"].ToString();
                    obj.NOME = reader["NOME"].ToString();
                    obj.DESCRICAO = reader["DESCRICAO"].ToString();
                    obj.COMPOSICAO = reader["COMPOSICAO"].ToString();
                    obj.QTD_EMBALAGEM = reader["QTD_EMBALAGEM"].ToString();
                    obj.PF_20 = reader["PF_20"].ToString();
                    obj.PMC_20 = reader["PMC_20"].ToString();
                    obj.PF_18 = reader["PF_18"].ToString();
                    obj.PMC_18 = reader["PMC_18"].ToString();
                    obj.PF_17 = reader["PF_17"].ToString();
                    obj.PMC_17 = reader["PMC_17"].ToString();
                    obj.PF_17_5 = reader["PF_17_5"].ToString();
                    obj.PMC_17_5 = reader["PMC_17_5"].ToString();
                    obj.PF_12 = reader["PF_12"].ToString();
                    obj.PMC_12 = reader["PMC_12"].ToString();
                    obj.PF_0 = reader["PF_0"].ToString();
                    obj.PMC_0 = reader["PMC_0"].ToString();
                    obj.PERCENTUAL_IPI = reader["PERCENTUAL_IPI"].ToString();
                    obj.DATA_VIGENCIA = Convert.ToDateTime(reader["DATA_VIGENCIA"].ToString());
                    obj.NOVO = reader["NOVO"].ToString();
                    obj.VARIACAO_PRECO = reader["VARIACAO_PRECO"].ToString();
                    obj.PF_17_ALC = reader["PF_17_ALC"].ToString();
                    obj.PMC_17_ALC = reader["PMC_17_ALC"].ToString();
                    obj.PF_17_5_ALC = reader["PF_17_5_ALC"].ToString();
                    obj.PMC_17_5_ALC = reader["PMC_17_5_ALC"].ToString();
                    obj.PF_18_ALC = reader["PF_18_ALC"].ToString();
                    obj.PMC_18_ALC = reader["PMC_18_ALC"].ToString();
                    obj.NCM = reader["NCM"].ToString();
                    obj.ID_TARJA = reader["ID_TARJA"].ToString();
                    obj.CLASSE_TERAPEUTICA = reader["CLASSE_TERAPEUTICA"].ToString();
                    obj.PORTARIA_344_98 = reader["PORTARIA_344_98"].ToString();
                    obj.PRODUTO_REFERENCIA = reader["PRODUTO_REFERENCIA"].ToString();
                    obj.CAS = reader["CAS"].ToString();
                    obj.DCB = reader["DCB"].ToString();
                    obj.ATC_CODE = reader["ATC_CODE"].ToString();
                    obj.CAP = reader["CAP"].ToString();
                    obj.CONFAZ_87 = reader["CONFAZ_87"].ToString();
                    obj.TISS_TUSS = reader["TISS_TUSS"].ToString();
                    obj.CEST = reader["CEST"].ToString();
                    obj.ID_FABRICANTE = reader["ID_FABRICANTE"].ToString();
                    obj.NOME_FABRICANTE = reader["NOME_FABRICANTE"].ToString();
                    obj.ID_LCCT = reader["ID_LCCT"].ToString();
                    obj.DESCRICAO_LISTA = reader["DESCRICAO_LISTA"].ToString();
                    obj.ID_REGIME_PRECO = reader["ID_REGIME_PRECO"].ToString();
                    obj.DESCRICAO_REGIME_PRECO = reader["DESCRICAO_REGIME_PRECO"].ToString();
                    obj.ID_TIPO_PRODUTO = reader["ID_TIPO_PRODUTO"].ToString();
                    obj.DESCRICAO_TIPO_PRODUTO = reader["DESCRICAO_TIPO_PRODUTO"].ToString();
                    obj.ArquivoGerado = reader["ArquivoGerado"].ToString();
                    obj.Estados = 99;
                    listaClientes.Add(obj);
                }

            }
            catch (Exception ex)
            {
                ProdutosAbcFarmaAnterior obj2 = new ProdutosAbcFarmaAnterior();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaClientes;
        }

        public void update(ProdutosAbcFarmaAnterior obj)
        {
            throw new System.NotImplementedException();
        }
        public void create(ProdutosAbcFarmaAnterior obj)
        {
            string create = @"insert AbcFarmaAnterior(ID_PRODUTO,EAN,REGISTRO_ANVISA,GGREM,NOME,DESCRICAO,COMPOSICAO,QTD_EMBALAGEM,PF_20,PMC_20,
            PF_18,PMC_18,PF_17,PMC_17,PF_17_5,PMC_17_5,PF_12,PMC_12,PF_0,PMC_0,DATA_VIGENCIA,NOVO,VARIACAO_PRECO,
            PF_17_ALC,PMC_17_ALC,PF_17_5_ALC,PMC_17_5_ALC,PF_18_ALC,PMC_18_ALC,NCM,ID_TARJA,CLASSE_TERAPEUTICA,
            PORTARIA_344_98,PRODUTO_REFERENCIA,CAS,DCB,ATC_CODE,CAP,CONFAZ_87,TISS_TUSS,CEST,
            ID_FABRICANTE,NOME_FABRICANTE,ID_LCCT,DESCRICAO_LISTA,ID_REGIME_PRECO,
            DESCRICAO_REGIME_PRECO,ID_TIPO_PRODUTO,DESCRICAO_TIPO_PRODUTO,
            ArquivoGerado) values('" + obj?.ID_PRODUTO + "','" + obj?.EAN + "','" + obj?.REGISTRO_ANVISA +
                "','" + obj?.GGREM +
                "','" + obj?.NOME +
                "','" + obj?.DESCRICAO + "','" + obj?.COMPOSICAO +
                "','" + obj?.QTD_EMBALAGEM +
                "','" + obj?.PF_20 +
                "','" + obj?.PMC_20 +
                "','" + obj?.PF_18 +
                "','" + obj?.PMC_18 +
                "','" + obj?.PF_17 +
                "','" + obj?.PMC_17 +
                "','" + obj?.PF_17_5 +
                "','" + obj?.PMC_17_5 +
                "','" + obj?.PF_12 +
                "','" + obj?.PMC_12 +
                "','" + obj?.PF_0 +
                "','" + obj?.PMC_0 +
                "', convert(date, '" + obj?.DATA_VIGENCIA + "', 103)" +
                ",'" + obj?.NOVO +
                "','" + obj?.VARIACAO_PRECO +
                "','" + obj?.PF_17_ALC +
                "','" + obj?.PMC_17_ALC +
                "','" + obj?.PF_17_5_ALC +
                "','" + obj?.PMC_17_5_ALC +
                "','" + obj?.PF_18_ALC +
                "','" + obj?.PMC_18_ALC +
                "','" + obj?.NCM +
                "','" + obj?.ID_TARJA +
                "','" + obj?.CLASSE_TERAPEUTICA +
                "','" + obj?.PORTARIA_344_98 +
                "','" + obj?.PRODUTO_REFERENCIA +
                "','" + obj?.CAS +
                "','" + obj?.DCB +
                "','" + obj?.ATC_CODE +
                "','" + obj?.CAP +
                "','" + obj?.CONFAZ_87 +
                "','" + obj?.TISS_TUSS +
                "','" + obj?.CEST +
                "','" + obj?.ID_FABRICANTE +
                "','" + obj?.NOME_FABRICANTE +
                "','" + obj?.ID_LCCT +
                "','" + obj?.DESCRICAO_LISTA +
                "','" + obj?.ID_REGIME_PRECO +
                "','" + obj?.DESCRICAO_REGIME_PRECO +
                "','" + obj?.ID_TIPO_PRODUTO +
                "','" + obj?.DESCRICAO_TIPO_PRODUTO +
                "','" + obj?.ArquivoGerado + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }
        public void delete(ProdutosAbcFarmaAnterior obj)
        {
            string delete = "delete from AbcFarmaAnterior where EAN ='" + obj.EAN + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }
        public void deleteTodos()
        {
            string delete = "delete from AbcFarmaAnterior ";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }
    }
}
