using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class ControleOPDao: Obrigatorio<ControleOP>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public ControleOPDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(ControleOP obj)
        {
            string create = "insert into ControleOP values('" + obj.Id + "','" + obj.Aspecto + "','" + obj.Acao + "','" + obj.SimNao + "','" + obj.EvitImpacAmb + "','" + obj.Ocorrencia + "','" + obj.Oportunidade + "')";
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

        public void delete(ControleOP obj)
        {
            string delete = "delete from ControleOP where id ='" + obj.Id + "'";
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

        public bool find(ControleOP obj)
        {
            bool temRegistros;
            string find = "select*from ControleOP where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Aspecto =Convert.ToInt32( reader["Aspecto"].ToString());
                    obj.Acao = reader["Ação"].ToString();
                    obj.SimNao = reader["SimNao"].ToString();
                    obj.EvitImpacAmb = reader["EvitImpacAmb"].ToString();
                    obj.Ocorrencia = reader["Ocorrência"].ToString();
                    obj.Oportunidade = reader["Oportunidade"].ToString();


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

        public List<ControleOP> findAll()
        {
            List<ControleOP> listaControleOP = new List<ControleOP>();
            string find = "select*from ControleOP order by Id asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ControleOP obj = new ControleOP();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Aspecto = Convert.ToInt32(reader["Aspecto"].ToString());
                    obj.Acao = reader["Ação"].ToString();
                    obj.SimNao = reader["SimNao"].ToString();
                    obj.EvitImpacAmb = reader["EvitImpacAmb"].ToString();
                    obj.Ocorrencia = reader["Ocorrência"].ToString();
                    obj.Oportunidade = reader["Oportunidade"].ToString();
                    listaControleOP.Add(obj);
                }

            }
            catch (Exception ex)
            {
                ControleOP obj2 = new ControleOP();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaControleOP;
        }

        public void update(ControleOP obj)
        {
            string update = "update ControleOP set Aspecto='" + obj.Aspecto + "',Acao='" + obj.Acao + "',SimNao='" + obj.SimNao + "',EvitImpacAmb='" + obj.EvitImpacAmb + "',Ocorrencia='" + obj.Ocorrencia + "',Oportunidade='" + obj.Oportunidade + "' where id='" + obj.Id + "'";
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

        public bool findControleOPPorId(ControleOP obj)
        {
            bool temRegistros;
            string find = "select*from ControleOP where Id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Aspecto = Convert.ToInt32(reader["Aspecto"].ToString());
                    obj.Acao = reader["Ação"].ToString();
                    obj.SimNao = reader["SimNao"].ToString();
                    obj.EvitImpacAmb = reader["EvitImpacAmb"].ToString();
                    obj.Ocorrencia = reader["Ocorrência"].ToString();
                    obj.Oportunidade = reader["Oportunidade"].ToString();

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

        public List<ControleOP> findAllControleOP(ControleOP objControleOP)
        {
            List<ControleOP> listaControleOP = new List<ControleOP>();
            string findAll = "select* from ControleOP where Acao like '%" + objControleOP.Acao + "%' or SimNao like '%" + objControleOP.SimNao + "%' or EvitImpacAmb like '%" + objControleOP.EvitImpacAmb + "%' or Ocorrencia like '%" + objControleOP.Ocorrencia + "%' or Oportunidade like '%" + objControleOP.Oportunidade + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ControleOP obj = new ControleOP();
                    obj.Aspecto = Convert.ToInt32(reader["Aspecto"].ToString());
                    obj.Acao = reader["Ação"].ToString();
                    obj.SimNao = reader["SimNao"].ToString();
                    obj.EvitImpacAmb = reader["EvitImpacAmb"].ToString();
                    obj.Ocorrencia = reader["Ocorrência"].ToString();
                    obj.Oportunidade = reader["Oportunidade"].ToString();
                    listaControleOP.Add(obj);

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

            return listaControleOP;

        }

    }
}
