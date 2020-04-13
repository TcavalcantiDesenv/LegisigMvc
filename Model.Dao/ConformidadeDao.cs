using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model.Dao;

namespace Model.Entity
{
    public class ConformidadeDao : Obrigatorio<Conformidade>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public ConformidadeDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Conformidade obj)
        {
            string create = "insert into Conformidade values('" + obj.IDCliente + "','" + obj.IDLegis + "','" + obj.IDParametros + "', 0,'" + obj.Evidencias + "','" + obj.DataAvaliacao.ToString("yyyy-MM-dd") + "','" + obj.Avaliado + "','" + obj.Anexo + "','" + obj.DataValidacao.ToString("yyyy-MM-dd") + "','" + obj.Validado + "','" + obj.ProxAvaliacao.ToString("yyyy-MM-dd") + "','" + obj.Resultado + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
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

        public void delete(Conformidade obj)
        {
            string delete = "delete from Conformidade where id ='" + obj.id + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool find(Conformidade obj)
        {
            bool temRegistros;
            string find = "select*from Conformidade where IDParametros='" + obj.id + "'";
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
                    obj.Evidencias = reader["Evidencias"].ToString();
                    obj.DataAvaliacao =Convert.ToDateTime( reader["DataAvaliacao"].ToString());
                    obj.Avaliado = reader["Avaliado"].ToString();
                    obj.Anexo = reader["Anexo"].ToString();
                    obj.DataValidacao = Convert.ToDateTime(reader["DataValidacao"].ToString());
                    //         obj.Estados = 0;
                    obj.Validado = reader["Validado"].ToString();
                    obj.ProxAvaliacao = Convert.ToDateTime(reader["ProxAvaliacao"].ToString());
                    obj.Resultado = reader["Resultado"].ToString();


                }
                else
                {
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

        public List<Conformidade> findAll()
        {
            List<Conformidade> listaConformidade = new List<Conformidade>();
            string find = "select*from Conformidade order by id asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Conformidade obj = new Conformidade();
                    obj.id = Convert.ToInt32(reader["Id"].ToString());
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDLegis = Convert.ToInt32(reader["IDLegis"].ToString());
                    obj.IDParametros = Convert.ToInt32(reader["IDParametros"].ToString());
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.Evidencias = reader["Evidencias"].ToString();
                    obj.DataAvaliacao = Convert.ToDateTime(reader["DataAvaliacao"].ToString());
                    obj.Avaliado = reader["Avaliado"].ToString();
                    obj.Anexo = reader["Anexo"].ToString();
                    obj.DataValidacao = Convert.ToDateTime(reader["DataValidacao"].ToString());
                    //         obj.Estados = 0;
                    obj.Validado = reader["Validado"].ToString();
                    obj.ProxAvaliacao = Convert.ToDateTime(reader["ProxAvaliacao"].ToString());
                    obj.Resultado = reader["Resultado"].ToString();
                    listaConformidade.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Conformidade obj2 = new Conformidade();
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaConformidade;
        }
        public List<Conformidade> buscarPorClienteParametro(string cliente, string parametro)
        {
            List<Conformidade> listaConformidade = new List<Conformidade>();
            string find = "select*from Conformidade where IDCliente = '" + cliente + "' and IDParametros = '" + parametro+"' order by id asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Conformidade obj = new Conformidade();
                    obj.id = Convert.ToInt32(reader["Id"].ToString());
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDLegis = Convert.ToInt32(reader["IDLegis"].ToString());
                    obj.IDParametros = Convert.ToInt32(reader["IDParametros"].ToString());
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.Evidencias = reader["Evidencias"].ToString();
                    obj.DataAvaliacao = Convert.ToDateTime(reader["DataAvaliacao"].ToString());
                    obj.Avaliado = reader["Avaliado"].ToString();
                    obj.Anexo = reader["Anexo"].ToString();
                    obj.DataValidacao = Convert.ToDateTime(reader["DataValidacao"].ToString());
                    //         obj.Estados = 0;
                    obj.Validado = reader["Validado"].ToString();
                    obj.ProxAvaliacao = Convert.ToDateTime(reader["ProxAvaliacao"].ToString());
                    obj.Resultado = reader["Resultado"].ToString();
                    listaConformidade.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Conformidade obj2 = new Conformidade();
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaConformidade;
        }
        public List<Conformidade> buscarPorID(string Id)
        {
            List<Conformidade> listaConformidade = new List<Conformidade>();
            string find = "select*from Conformidade where Id = '" + Id + "' ";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Conformidade obj = new Conformidade();
                    obj.id = Convert.ToInt32(reader["Id"].ToString());
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDLegis = Convert.ToInt32(reader["IDLegis"].ToString());
                    obj.IDParametros = Convert.ToInt32(reader["IDParametros"].ToString());
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.Evidencias = reader["Evidencias"].ToString();
                    obj.DataAvaliacao = Convert.ToDateTime(reader["DataAvaliacao"].ToString());
                    obj.Avaliado = reader["Avaliado"].ToString();
                    obj.Anexo = reader["Anexo"].ToString();
                    obj.DataValidacao = Convert.ToDateTime(reader["DataValidacao"].ToString());
                    //         obj.Estados = 0;
                    obj.Validado = reader["Validado"].ToString();
                    obj.ProxAvaliacao = Convert.ToDateTime(reader["ProxAvaliacao"].ToString());
                    obj.Resultado = reader["Resultado"].ToString();
                    listaConformidade.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Conformidade obj2 = new Conformidade();
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaConformidade;
        }

        public void update(Conformidade obj)
        {
            string update = "update Conformidade set IDCliente='" + obj.IDCliente + "',IDLegis='" + obj.IDLegis + "',IDParametros='" + obj.IDParametros + "',Obrigacao=0,Evidencias='" + obj.Evidencias + "',DataAvaliacao='" + obj.DataAvaliacao.ToString("yyyy-MM-dd") + "',Avaliado='" + obj.Avaliado + "',Anexo='" + obj.Anexo + "',DataValidacao='" + obj.DataValidacao.ToString("yyyy-MM-dd") + "',Validado='" + obj.Validado + "',ProxAvaliacao='" + obj.ProxAvaliacao.ToString("yyyy-MM-dd") + "',Resultado='" + obj.Resultado + "' where Id='" + obj.id + "'";                                                                                                                                                                                                                                                                                                                                                                                                                               
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
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

        public bool findConformidadePorId(Conformidade obj)
        {
            bool temRegistros;
            string find = "select*from Conformidade where id='" + obj.id + "'";
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
                    obj.Evidencias = reader["Evidencias"].ToString();
                    obj.DataAvaliacao = Convert.ToDateTime(reader["DataAvaliacao"].ToString());
                    obj.Avaliado = reader["Avaliado"].ToString();
                    obj.Anexo = reader["Anexo"].ToString();
                    obj.DataValidacao = Convert.ToDateTime(reader["DataValidacao"].ToString());
                    //         obj.Estados = 0;
                    obj.Validado = reader["Validado"].ToString();
                    obj.ProxAvaliacao = Convert.ToDateTime(reader["ProxAvaliacao"].ToString());
                    obj.Resultado = reader["Resultado"].ToString();


                }
                else
                {
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

        public List<Conformidade> findAllConformidade(Conformidade objConformidade)
        {
            List<Conformidade> listaConformidade = new List<Conformidade>();
            string findAll = "select* from Conformidade where Evidencias like '%" + objConformidade.Evidencias + "%' or Avaliado like '%" + objConformidade.Avaliado + "%' or Anexo like '%" + objConformidade.Anexo + "%' or Validado like '%" + objConformidade.Validado + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Conformidade obj = new Conformidade();
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDLegis = Convert.ToInt32(reader["IDLegis"].ToString());
                    obj.IDParametros = Convert.ToInt32(reader["IDParametros"].ToString());
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.Evidencias = reader["Evidencias"].ToString();
                    obj.DataAvaliacao = Convert.ToDateTime(reader["DataAvaliacao"].ToString());
                    obj.Avaliado = reader["Avaliado"].ToString();
                    obj.Anexo = reader["Anexo"].ToString();
                    obj.DataValidacao = Convert.ToDateTime(reader["DataValidacao"].ToString());
                    //         obj.Estados = 0;
                    obj.Validado = reader["Validado"].ToString();
                    obj.ProxAvaliacao = Convert.ToDateTime(reader["ProxAvaliacao"].ToString());
                    obj.Resultado = reader["Resultado"].ToString();
                    listaConformidade.Add(obj);

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

            return listaConformidade;

        }

      
    }
}
