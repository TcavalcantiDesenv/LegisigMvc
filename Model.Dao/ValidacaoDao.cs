using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class ValidacaoDao : Obrigatorio<Validacao>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public ValidacaoDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Validacao obj)
        {
            string create = "insert into Validacao values('" + obj.id + "','" + obj.IDCliente + "','" + obj.IDLegis + "','" + obj.IDParametros + "','" + obj.Obrigacao + "','" + obj.Evidencias + "','" + obj.DataAvaliacao + "','" + obj.Avaliado + "','" + obj.Anexo + "','" + obj.DataValidacao + "','" + obj.Validado + "','" + obj.ProxAvaliacao + "','" + obj.Resultado + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
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

        public void delete(Validacao obj)
        {
            string delete = "delete from Validacao where id ='" + obj.id + "'";
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

        public bool find(Validacao obj)
        {
            bool temRegistros;
            string find = "select*from Validacao where id='" + obj.id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IDCliente =Convert.ToInt32( reader["IDCliente"].ToString());
                    obj.IDLegis = Convert.ToInt32(reader["IDLegis"].ToString());
                    obj.IDParametros = Convert.ToInt32(reader["IDParametros"].ToString());
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.Evidencias = reader["Evidências"].ToString();
                    obj.DataAvaliacao =Convert.ToDateTime( reader["DataAvaliação"].ToString());
                    obj.Avaliado = reader["Avaliado"].ToString();
                    obj.Anexo = reader["Anexo"].ToString();
                    obj.DataValidacao = Convert.ToDateTime(reader["DataValidação"].ToString());
                    //         obj.Estados = 0;
                    obj.Validado = reader["Validado"].ToString();
                    obj.ProxAvaliacao = Convert.ToDateTime(reader["ProxAvaliação"].ToString());
                    obj.Resultado = reader["Resultado"].ToString();

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

        public List<Validacao> findAll()
        {
            List<Validacao> listaValidacao = new List<Validacao>();
            string find = "select*from Validacao order by id asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Validacao obj = new Validacao();
                    obj.id = Convert.ToInt32(reader["Id"].ToString());
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDLegis = Convert.ToInt32(reader["IDLegis"].ToString());
                    obj.IDParametros = Convert.ToInt32(reader["IDParametros"].ToString());
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.Evidencias = reader["Evidências"].ToString();
                    obj.DataAvaliacao = Convert.ToDateTime(reader["DataAvaliação"].ToString());
                    obj.Avaliado = reader["Avaliado"].ToString();
                    obj.Anexo = reader["Anexo"].ToString();
                    obj.DataValidacao = Convert.ToDateTime(reader["DataValidação"].ToString());
                    //         obj.Estados = 0;
                    obj.Validado = reader["Validado"].ToString();
                    obj.ProxAvaliacao = Convert.ToDateTime(reader["ProxAvaliação"].ToString());
                    obj.Resultado = reader["Resultado"].ToString();
                    listaValidacao.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Validacao obj2 = new Validacao();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaValidacao;
        }

        public void update(Validacao obj)
        {
            string update = "update Validacao set IDCliente='" + obj.IDCliente + "',IDLegis='" + obj.IDLegis + "',IDParametros='" + obj.IDParametros + "',Obrigacao='" + obj.Obrigacao + "',Evidencias='" + obj.Evidencias + "',DataAvaliacao='" + obj.DataAvaliacao + "',Avaliado='" + obj.Avaliado + "',Anexo='" + obj.Anexo + "',DataValidacao='" + obj.DataValidacao + "',Validado='" + obj.Validado + "',ProxAvaliacao='" + obj.ProxAvaliacao + "',Resultado='" + obj.Resultado + "' where id='" + obj.id + "'";
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
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

        public bool findValidacaoPorId(Validacao obj)
        {
            bool temRegistros;
            string find = "select*from Validacao where id='" + obj.id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDLegis = Convert.ToInt32(reader["IDLegis"].ToString());
                    obj.IDParametros = Convert.ToInt32(reader["IDParametros"].ToString());
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.Evidencias = reader["Evidências"].ToString();
                    obj.DataAvaliacao = Convert.ToDateTime(reader["DataAvaliação"].ToString());
                    obj.Avaliado = reader["Avaliado"].ToString();
                    obj.Anexo = reader["Anexo"].ToString();
                    obj.DataValidacao = Convert.ToDateTime(reader["DataValidação"].ToString());
                    //         obj.Estados = 0;
                    obj.Validado = reader["Validado"].ToString();
                    obj.ProxAvaliacao = Convert.ToDateTime(reader["ProxAvaliação"].ToString());
                    obj.Resultado = reader["Resultado"].ToString();

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

        public List<Validacao> findAllValidacao(Validacao objValidacao)
        {
            List<Validacao> listaValidacao = new List<Validacao>();
            string findAll = "select* from Validacao where Evidencias like '%" + objValidacao.Evidencias + "%' or Avaliado like '%" + objValidacao.Avaliado + "%' or Anexo like '%" + objValidacao.Anexo + "%' or Validado like '%" + objValidacao.Validado + "%' or Resultado like '%" + objValidacao.Resultado + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Validacao obj = new Validacao();
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDLegis = Convert.ToInt32(reader["IDLegis"].ToString());
                    obj.IDParametros = Convert.ToInt32(reader["IDParametros"].ToString());
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.Evidencias = reader["Evidências"].ToString();
                    obj.DataAvaliacao = Convert.ToDateTime(reader["DataAvaliação"].ToString());
                    obj.Avaliado = reader["Avaliado"].ToString();
                    obj.Anexo = reader["Anexo"].ToString();
                    obj.DataValidacao = Convert.ToDateTime(reader["DataValidação"].ToString());
                    //         obj.Estados = 0;
                    obj.Validado = reader["Validado"].ToString();
                    obj.ProxAvaliacao = Convert.ToDateTime(reader["ProxAvaliação"].ToString());
                    obj.Resultado = reader["Resultado"].ToString();
                    listaValidacao.Add(obj);

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

            return listaValidacao;

        }

    }
}
