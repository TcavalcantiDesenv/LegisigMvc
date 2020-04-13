using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class ProdutoSincronizadoDao : Obrigatorio<ProdutoSincronizado>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public ProdutoSincronizadoDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(ProdutoSincronizado obj)
        {
            string nome = obj.Nome.Replace("'", "");
            string detalhes = obj.Detalhes.Replace("'", "");
            string descricao = obj.Descricao.Replace("'", "");
            string precode = obj.PrecoDe.ToString().Replace(",", ".");
            string precopor = obj.PrecoPor.ToString().Replace(",", ".");

            //  insert into ProdutosSincronizados values('7898953980288','7oil 1000mg 100S Vit Blue    ','Produto atualizado com sucesso','0','Sincronizado com sucesso',convert(datetime, '20/11/2018 15:04:57', 105),'39','Atualizar','7oil 1000mg 100S Vit Blue    ','74.97','74.97')
            string create = "insert into ProdutosSincronizados values('" + obj.Ean + "','" + nome + "','" + descricao + "','" + obj.Quantidade + "','" + obj.Status + "',convert(datetime,'" + obj.DataSincronizacao + "',105),'" + obj.ExecucaoId + "','" + obj.Operacao + "','" + detalhes + "','" + precode + "','" + precopor + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void delete(ProdutoSincronizado obj)
        {
            string delete = "delete from ProdutoSincronizado where ProdutoSincronizadoId ='" + obj.ProdutoSincronizadoId + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool find(ProdutoSincronizado obj)
        {
            bool temRegistros;
            string find = "select * from ProdutoSincronizado where ProdutoSincronizadoId='" + obj.ProdutoSincronizadoId + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.ProdutoSincronizadoId = Convert.ToInt32(reader["ProdutoSincronizadoId"].ToString());
                    obj.ExecucaoId = Convert.ToInt32(reader["ExecucaoId"].ToString());
                    obj.Ean = reader["Aplicar"].ToString();
                    obj.Nome = reader["Nome"].ToString();
                    obj.Descricao = reader["Descricao"].ToString();
                    obj.Quantidade = Convert.ToDouble(reader["Quantidade"].ToString());
                    obj.Status = reader["Status"].ToString();
                    obj.DataSincronizacao = Convert.ToDateTime(reader["DataSincronizacao"].ToString());
                    obj.Operacao = reader["Operacao"].ToString();
                    obj.Detalhes = reader["Detalhes"].ToString();
                    obj.PrecoDe = Convert.ToDouble(reader["PrecoDe"].ToString());
                    obj.PrecoPor = Convert.ToDouble(reader["PrecoPor"].ToString());

                    //obj.Estados = 99;
                }
                else
                {
                    //obj.Estados = 1;
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

        public List<ProdutoSincronizado> findAll()
        {
            List<ProdutoSincronizado> listaProdutoSincronizado = new List<ProdutoSincronizado>();
            string find = "select * from ProdutosSincronizados order by ProdutoSincronizadoId desc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ProdutoSincronizado obj = new ProdutoSincronizado();
                    obj.ProdutoSincronizadoId = Convert.ToInt32(reader["ProdutoSincronizadoId"].ToString());
                    obj.ExecucaoId = Convert.ToInt32(reader["ExecucaoId"].ToString());
                    obj.Ean = reader["Ean"].ToString();
                    obj.Nome = reader["Nome"].ToString();
                    obj.Descricao = reader["Descricao"].ToString();
                    obj.Quantidade = Convert.ToDouble(reader["Quantidade"].ToString());
                    obj.Status = reader["Status"].ToString();
                    obj.DataSincronizacao = Convert.ToDateTime(reader["DataSincronizacao"].ToString());
                    obj.ExecucaoId = Convert.ToInt32(reader["ExecucaoId"].ToString());
                    obj.Operacao = reader["Operacao"].ToString();
                    obj.Detalhes = reader["Detalhes"].ToString();
                    obj.PrecoDe = Convert.ToDouble(reader["PrecoDe"].ToString());
                    obj.PrecoPor = Convert.ToDouble(reader["PrecoPor"].ToString());
                    listaProdutoSincronizado.Add(obj);
                }

            }
            catch (Exception ex)
            {
                ProdutoSincronizado obj2 = new ProdutoSincronizado();
              //  obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaProdutoSincronizado;
        }

        public List<ProdutoSincronizado> BuscarPorId(string id)
        {
            int execid = Convert.ToInt32(id);
            List<ProdutoSincronizado> listaExecucao = new List<ProdutoSincronizado>();
            string find = "select * from ProdutosSincronizados where ExecucaoId = " + id + " order by ProdutoSincronizadoId desc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ProdutoSincronizado obj = new ProdutoSincronizado();
                    obj.ProdutoSincronizadoId = Convert.ToInt32(reader["ProdutoSincronizadoId"].ToString());
                    obj.ExecucaoId = Convert.ToInt32(reader["ExecucaoId"].ToString());
                    obj.Ean = reader["Ean"].ToString();
                    obj.Nome = reader["Nome"].ToString();
                    obj.Descricao = reader["Descricao"].ToString();
                    obj.Quantidade = Convert.ToDouble(reader["Quantidade"].ToString());
                    obj.Status = reader["Status"].ToString();
                    obj.DataSincronizacao = Convert.ToDateTime(reader["DataSincronizacao"].ToString());
                    obj.Operacao = reader["Operacao"].ToString();
                    obj.Detalhes = reader["Detalhes"].ToString();
                    obj.PrecoDe = Convert.ToDouble(reader["PrecoDe"].ToString());
                    obj.PrecoPor = Convert.ToDouble(reader["PrecoPor"].ToString());
                    listaExecucao.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Execucao obj2 = new Execucao();
              //  obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaExecucao;
        }
        public List<ProdutoSincronizado> BuscarDetalhePorId(string id)
        {
            int execid = Convert.ToInt32(id);
            List<ProdutoSincronizado> listaExecucao = new List<ProdutoSincronizado>();
            string find = "select * from ProdutosSincronizados where ProdutoSincronizadoId = " + id + " order by ProdutoSincronizadoId asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ProdutoSincronizado obj = new ProdutoSincronizado();
                    obj.ProdutoSincronizadoId = Convert.ToInt32(reader["ProdutoSincronizadoId"].ToString());
                    obj.Ean = reader["Ean"].ToString();
                    obj.Nome = reader["Nome"].ToString();
                    obj.Descricao = reader["Descricao"].ToString();
                    obj.Quantidade = Convert.ToDouble(reader["Quantidade"].ToString());
                    obj.Status = reader["Status"].ToString();
                    obj.DataSincronizacao = Convert.ToDateTime(reader["DataSincronizacao"].ToString());
                    obj.ExecucaoId = Convert.ToInt32(reader["ExecucaoId"].ToString());
                    obj.Operacao = reader["Operacao"].ToString();
                    obj.Detalhes = reader["Detalhes"].ToString();
                    obj.PrecoDe = Convert.ToDouble(reader["PrecoDe"].ToString());
                    obj.PrecoPor = Convert.ToDouble(reader["PrecoPor"].ToString());
                    listaExecucao.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Execucao obj2 = new Execucao();
              //  obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaExecucao;
        }
        public List<ProdutoSincronizado> BuscarPorEan_Status(string ean)
        {
            List<ProdutoSincronizado> listaExecucao = new List<ProdutoSincronizado>();
            string find = "select * from ProdutosSincronizados where ean = '" + ean + "' and Status = 'Sincronizado com sucesso' order by ProdutoSincronizadoId desc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ProdutoSincronizado obj = new ProdutoSincronizado();
                    obj.ProdutoSincronizadoId = Convert.ToInt32(reader["ProdutoSincronizadoId"].ToString());
                    obj.ExecucaoId = Convert.ToInt32(reader["ExecucaoId"].ToString());
                    obj.Ean = reader["Ean"].ToString();
                    obj.Nome = reader["Nome"].ToString();
                    obj.Descricao = reader["Descricao"].ToString();
                    obj.Quantidade = Convert.ToDouble(reader["Quantidade"].ToString());
                    obj.Status = reader["Status"].ToString();
                    obj.DataSincronizacao = Convert.ToDateTime(reader["DataSincronizacao"].ToString());
                    obj.Operacao = reader["Operacao"].ToString();
                    obj.Detalhes = reader["Detalhes"].ToString();
                    obj.PrecoDe = Convert.ToDouble(reader["PrecoDe"].ToString());
                    obj.PrecoPor = Convert.ToDouble(reader["PrecoPor"].ToString());
                    listaExecucao.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Execucao obj2 = new Execucao();
              //  obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaExecucao;
        }
        public void update(ProdutoSincronizado obj)
        {
            string update = "update ProdutoSincronizado set Ean='" + obj.Ean + "',Nome='" + obj.Nome + "',Descricao='" + obj.Descricao + "',Quantidade='" + obj.Quantidade + "',Status='" + obj.Status + "',DataSincronizacao='" + obj.DataSincronizacao + "',ExecucaoId='" + obj.ExecucaoId + "',Operacao='" + obj.Operacao + "',Detalhes='" + obj.Detalhes + "',PrecoDe='" + obj.PrecoDe + "',PrecoPor='" + obj.PrecoPor + "'PrecoPor" ;
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

              //  obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }
    }
}
