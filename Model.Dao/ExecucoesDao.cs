using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class ExecucoesDao : Obrigatorio<Execucao>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public ExecucoesDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Execucao obj)
        {
            throw new System.NotImplementedException();
        }

        public void delete(Execucao obj)
        {
            throw new System.NotImplementedException();
        }

        public bool find(Execucao obj)
        {
            bool temRegistros;
            string find = "select * from Execucoes where ExecucaoId='" + obj.ExecucaoId + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.ExecucaoId = Convert.ToInt32(reader["ExecucaoId"].ToString());
                    obj.Detalhes = reader["Detalhes"].ToString();
                    obj.Fim = Convert.ToDateTime(reader["Fim"].ToString());
                    obj.Inicio = Convert.ToDateTime(reader["Inicio"].ToString());
                   // obj.ProdutoSincronizados = reader["ProdutoSincronizados"].ToString();
                    obj.Status = reader["Status"].ToString();
                }
                else
                {
                  //  obj.Estados = 1;
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

        public List<Execucao> BuscarPorId(string id)
        {
            int execid = Convert.ToInt32(id);
            List<Execucao> listaExecucao = new List<Execucao>();
            string find = "select * from Execucoes where ExecucaoId = " + execid + " order by inicio asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Execucao obj = new Execucao();
                    obj.ExecucaoId = Convert.ToInt32(reader["ExecucaoId"].ToString());
                    obj.Inicio = Convert.ToDateTime(reader["Inicio"].ToString());
                    if (reader["Fim"].ToString() == "")
                    {
                        obj.Fim = null;
                    }
                    else
                    {
                        obj.Fim = Convert.ToDateTime(reader["Fim"].ToString());
                    }// Convert.ToDateTime(reader["Fim"].ToString()) ;

                    obj.Detalhes = reader["Detalhes"].ToString();
                    obj.Status = reader["Status"].ToString();
                    listaExecucao.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Execucao obj2 = new Execucao();
          //      obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaExecucao;
        }

        public int ExecucaoIdAtual()
        {
            int temRegistros = 0;
            string find = "SELECT IDENT_CURRENT('Execucoes') as ID ";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    temRegistros = Convert.ToInt32(reader["ID"].ToString());
                }

                objConexaoDB.getCon().Close();
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

        public List<Execucao> BuscarTodos()
        {
            List<Execucao> listaExecucao = new List<Execucao>();
            string find = "select * from Execucoes order by ExecucaoId DESC";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Execucao obj = new Execucao();
                    obj.ExecucaoId = Convert.ToInt32(reader["ExecucaoId"].ToString());
                    obj.Inicio = Convert.ToDateTime(reader["Inicio"].ToString());
                    if (reader["Fim"].ToString() == "")
                    {
                        obj.Fim = null;
                    }
                    else
                    {
                        obj.Fim = Convert.ToDateTime(reader["Fim"].ToString());
                    }// Convert.ToDateTime(reader["Fim"].ToString()) ;
                    obj.Detalhes = reader["Detalhes"].ToString();
                    obj.Status = reader["Status"].ToString();
                    listaExecucao.Add(obj);
                }
            }
            catch (Exception ex)
            {
                //Execucao obj2 = new Execucao();
                //obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaExecucao;
        }

        public List<Execucao> findAll()
        {
            List<Execucao> listaExecucao = new List<Execucao>();
            string find = "select * from Execucoes order by ExecucaoId DESC";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Execucao obj = new Execucao();
                    obj.ExecucaoId = Convert.ToInt32(reader["ExecucaoId"].ToString());
                    obj.Inicio = Convert.ToDateTime(reader["Inicio"].ToString());
                    if (reader["Fim"].ToString() == "")
                    {
                        obj.Fim = null;
                    }
                    else
                    {
                        obj.Fim = Convert.ToDateTime(reader["Fim"].ToString());
                    }// Convert.ToDateTime(reader["Fim"].ToString()) ;
                    obj.Detalhes = reader["Detalhes"].ToString();
                    obj.Status = reader["Status"].ToString();
                    listaExecucao.Add(obj);
                }
            }
            catch (Exception ex)
            {
                //Execucao obj2 = new Execucao();
                //obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaExecucao;
        }

        public void update(Execucao obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
