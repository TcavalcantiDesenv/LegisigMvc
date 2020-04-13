using Model.Entity;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProdutoBarraDao : Obrigatorio<ProdutoBarra>
    {
        private ConexaoDBPG objConexaoDBPGPG;
        private NpgsqlCommand comando;
        private NpgsqlDataReader reader;

        public ProdutoBarraDao()
        {
            objConexaoDBPGPG = ConexaoDBPG.saberEstado();
        }

        public void create(ProdutoBarra obj)
        {
            throw new System.NotImplementedException();
        }

        public void delete(ProdutoBarra obj)
        {
            throw new System.NotImplementedException();
        }

        public bool find(ProdutoBarra obj)
        {
            bool temRegistros;
            string find = "select * from estoque.prd_bar where bar='" + obj.Bar + "'";
            try
            {
                comando = new NpgsqlCommand(find, objConexaoDBPGPG.getCon());
                objConexaoDBPGPG.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Ide = Convert.ToInt32(reader["Ide"].ToString());
                    obj.Cod = Convert.ToInt32(reader["Cod"].ToString());
                    obj.Bar = reader["Bar"].ToString();
                    obj.Val = Convert.ToBoolean(reader["Val"].ToString());

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
                objConexaoDBPGPG.getCon().Close();
                objConexaoDBPGPG.CloseDB();
            }

            return temRegistros;
        }

        public List<ProdutoBarra> findAll()
        {
            List<ProdutoBarra> listaDrogaNossaProduto = new List<ProdutoBarra>();
            string find = "select * from estoque.prd_bar order by Bar asc";
            try
            {
                comando = new NpgsqlCommand(find, objConexaoDBPGPG.getCon());
                objConexaoDBPGPG.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ProdutoBarra obj = new ProdutoBarra();
                    obj.Ide = Convert.ToInt32(reader["Ide"].ToString());
                    obj.Cod = Convert.ToInt32(reader["Cod"].ToString());
                    obj.Bar = reader["Bar"].ToString();
                    obj.Val = Convert.ToBoolean(reader["Val"].ToString());
                    listaDrogaNossaProduto.Add(obj);
                }

            }
            catch (Exception ex)
            {
                ProdutoBarra obj2 = new ProdutoBarra();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDBPGPG.getCon().Close();
                objConexaoDBPGPG.CloseDB();
            }

            return listaDrogaNossaProduto;
        }

        public List<ProdutoBarra> PesquisarPorBarra(string barra)
        {
            List<ProdutoBarra> listaDrogaNossaProduto = new List<ProdutoBarra>();
            string find = "select * from estoque.prd_bar where Bar = '" + barra + "' limit 10";
            try
            {
                comando = new NpgsqlCommand(find, objConexaoDBPGPG.getCon());
                objConexaoDBPGPG.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ProdutoBarra obj = new ProdutoBarra();
                    obj.Ide = Convert.ToInt32(reader["Ide"].ToString());
                    obj.Cod = Convert.ToInt32(reader["Cod"].ToString());
                    obj.Bar = reader["Bar"].ToString();
                    obj.Val = Convert.ToBoolean(reader["Val"].ToString());
                    listaDrogaNossaProduto.Add(obj);
                }

            }
            catch (Exception ex)
            {
                ProdutoBarra obj2 = new ProdutoBarra();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDBPGPG.getCon().Close();
                objConexaoDBPGPG.CloseDB();
            }

            return listaDrogaNossaProduto;
        }

        public void update(ProdutoBarra obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
