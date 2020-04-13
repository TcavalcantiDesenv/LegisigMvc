using Model.Entity;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Model.Dao
{
    public class SyncProdutoDao : Obrigatorio<SyncProduto>
    {
        private ConexaoDBPG objConexaoDBPGPG;
        private NpgsqlCommand comando;
        private NpgsqlDataReader reader;

        public SyncProdutoDao()
        {
            objConexaoDBPGPG = ConexaoDBPG.saberEstado();
        }

        public void create(SyncProduto obj)
        {
            throw new System.NotImplementedException();
        }

        public void delete(SyncProduto obj)
        {
            throw new System.NotImplementedException();
        }

        public bool find(SyncProduto obj)
        {
            bool temRegistros;
            string find = "select * from prd_cad where Barras='" + obj.Barras + "'";
            try
            {
                comando = new NpgsqlCommand(find, objConexaoDBPGPG.getCon());
                objConexaoDBPGPG.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Nome = reader["Nome"].ToString();
                    obj.Descricao = reader["Descricao"].ToString();
                    obj.Uad = Convert.ToDouble(reader["Uad"].ToString());
                    obj.Modelo = reader["Modelo"].ToString();
                    obj.Departamento = reader["Departamento"].ToString();
                    obj.Preco = Convert.ToDouble(reader["Preco"].ToString());
                    obj.Quantidade = Convert.ToDouble(reader["Quantidade"].ToString());
                    obj.Fornecedor = reader["Fornecedor"].ToString();
                    obj.Classificacao = Convert.ToInt32(reader["Endereco"].ToString());

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

        public List<SyncProduto> findAll()
        {
            List<SyncProduto> listaDrogaNossaProduto = new List<SyncProduto>();
            string find = @"select nome,descricao,uad,modelo,departamento,preco,quantidade,fornecedor,classificacao,barras,pe.ide,pe.cod,pe.cum,pe.ucu 
                            from estoque.prd_bar as pb, web.prd_cad as pc, estoque.prd_cab as pe
                            where pb.bar = pc.Barras and pe.cvf <> 'I' and uad = '1'
                            and pb.cod = pe.cod order by Nome asc  ";
            try
            {
                comando = new NpgsqlCommand(find, objConexaoDBPGPG.getCon());
                objConexaoDBPGPG.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    SyncProduto obj = new SyncProduto();
                    obj.Nome = reader["Nome"].ToString();
                    obj.Descricao = reader["Descricao"].ToString();
                    obj.Uad = Convert.ToDouble(reader["Uad"].ToString());
                    obj.Modelo = reader["Modelo"].ToString();
                    obj.Departamento = reader["Departamento"].ToString();
                    obj.Preco = Convert.ToDouble(reader["Preco"].ToString());
                    obj.Quantidade = Convert.ToDouble(reader["Quantidade"].ToString());
                    obj.Fornecedor = reader["Fornecedor"].ToString();
                    obj.Classificacao = Convert.ToInt32(reader["Classificacao"].ToString());
                    obj.Barras = reader["Barras"].ToString();
                    obj.Cum = Convert.ToDouble(reader["Cum"].ToString());
                    obj.Ucu = Convert.ToDouble(reader["Ucu"].ToString());
                    //         obj.dca = Convert.ToDateTime(reader["dca"].ToString());

                    listaDrogaNossaProduto.Add(obj);
                }

            }
            catch (Exception ex)
            {
                SyncProduto obj2 = new SyncProduto();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDBPGPG.getCon().Close();
                objConexaoDBPGPG.CloseDB();
            }

            return listaDrogaNossaProduto;
        }

        public void update(SyncProduto obj)
        {
            throw new System.NotImplementedException();
        }

        public bool findClientePorBarra(SyncProduto obj)
        {
            bool temRegistros;
            string find = "select * from prd_cad where Barras='" + obj.Barras + "'";
            try
            {
                comando = new NpgsqlCommand(find, objConexaoDBPGPG.getCon());
                objConexaoDBPGPG.getCon().Open();

                NpgsqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Nome = reader["Nome"].ToString();
                    obj.Descricao = reader["Descricao"].ToString();
                    obj.Uad = Convert.ToDouble(reader["Uad"].ToString());
                    obj.Modelo = reader["Modelo"].ToString();
                    obj.Departamento = reader["Departamento"].ToString();
                    obj.Preco = Convert.ToDouble(reader["Preco"].ToString());
                    obj.Quantidade = Convert.ToDouble(reader["Quantidade"].ToString());
                    obj.Fornecedor = reader["Fornecedor"].ToString();
                    obj.Classificacao = Convert.ToInt32(reader["Endereco"].ToString());

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

        public List<SyncProduto> findAllProdutos(SyncProduto objProduto)
        {
            List<SyncProduto> listaSyncProduto = new List<SyncProduto>();
            string findAll = "select * from prd_cad where Nome like '%" + objProduto.Nome + "%' or Departamento like '%" + objProduto.Departamento + "%' or Modelo like '%" + objProduto.Modelo + "%' ";
            try
            {

                comando = new NpgsqlCommand(findAll, objConexaoDBPGPG.getCon());
                objConexaoDBPGPG.getCon().Open();
                NpgsqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    SyncProduto obj = new SyncProduto();
                    obj.Nome = reader["Nome"].ToString();
                    obj.Descricao = reader["Descricao"].ToString();
                    obj.Uad = Convert.ToDouble(reader["Uad"].ToString());
                    obj.Modelo = reader["Modelo"].ToString();
                    obj.Departamento = reader["Departamento"].ToString();
                    obj.Preco = Convert.ToDouble(reader["Preco"].ToString());
                    obj.Quantidade = Convert.ToDouble(reader["Quantidade"].ToString());
                    obj.Fornecedor = reader["Fornecedor"].ToString();
                    obj.Classificacao = Convert.ToInt32(reader["Endereco"].ToString());
                    listaSyncProduto.Add(obj);

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

            return listaSyncProduto;

        }

        List<SyncProduto> Obrigatorio<SyncProduto>.findAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
