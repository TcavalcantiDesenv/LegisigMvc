using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class AmbitoDao : Obrigatorio<Ambito>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public AmbitoDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Ambito obj)
        {
            string create = "insert into Ambito values('" + obj.Id + "','" + obj.Descricao + "')";
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

        public void delete(Ambito obj)
        {
            string delete = "delete from Ambito where id ='" + obj.Id + "'";
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

        public bool find(Ambito obj)
        {
            bool temRegistros;
            string find = "select*from Ambito where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Descricao = reader["Descrição"].ToString();
                    
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

        public List<Ambito> findAll()
        {
            List<Ambito> listaAmbito = new List<Ambito>();
            string find = "select*from Ambito order by Descrição asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Ambito obj = new Ambito();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Descricao = reader["Descrição"].ToString();
                    
                    listaAmbito.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Ambito obj2 = new Ambito();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaAmbito;
        }

        public void update(Ambito obj)
        {
            string update = "update Ambito set Descricao='" + obj.Descricao + "'  where Id = '" + obj.Id + "'";
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

        public bool findAmbitoDescricao(Ambito obj)
        {
            bool temRegistros;
            string find = "select*from Ambito where Descricao='" + obj.Descricao + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Descricao = reader["Descrição"].ToString();
                    
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

        public List<Ambito> findAllAmbito(Ambito objAmbito)
        {
            List<Ambito> listaAmbito = new List<Ambito>();
            string findAll = "select* from Ambito where Descricao like '%" + objAmbito.Descricao +  "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Ambito obj = new Ambito();
                    obj.Descricao = reader["Descrição"].ToString();
                    
                    listaAmbito.Add(obj);

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

            return listaAmbito;

        }
    }
}
