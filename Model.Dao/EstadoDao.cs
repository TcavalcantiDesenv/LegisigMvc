using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class EstadoDao : Obrigatorio<Estado>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public EstadoDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Estado obj)
        {
            string create = "insert into Estado values('" + obj.Id + "','" + obj.Nome + "','" + obj.UF + "','" + obj.Pais + "')";
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

        public void delete(Estado obj)
        {
            string delete = "delete from Estado where Id ='" + obj.Id + "'";
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

        public bool find(Estado obj)
        {
            bool temRegistros;
            string find = "select*from Estado where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Nome = reader["Nome"].ToString();
                    obj.UF = reader["UF"].ToString();
                    obj.Pais = reader["País"].ToString();

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

        public List<Estado> findAll()
        {
            List<Estado> listaEstado = new List<Estado>();
            string find = "select*from Estado order by UF asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Estado obj = new Estado();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Nome = reader["Nome"].ToString();
                    obj.UF = reader["UF"].ToString();
                    obj.Pais = reader["País"].ToString();
                    listaEstado.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Estado obj2 = new Estado();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaEstado;
        }

        public void update(Estado obj)
        {
            string update = "update Estado set Nome='" + obj.Nome + "',UF='" + obj.UF + "',Pais='" + obj.Pais + "' where id='" + obj.Id + "'  where Id = '" + obj.Id + "' ";
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

        public bool findEstadoPorId(Estado obj)
        {
            bool temRegistros;
            string find = "select*from Estado where Id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Nome = reader["Nome"].ToString();
                    obj.UF = reader["UF"].ToString();
                    obj.Pais = reader["País"].ToString();

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

        public List<Estado> findAllEstado(Estado objEstado)
        {
            List<Estado> listaEstado = new List<Estado>();
            string findAll = "select* from Estado where Nome like '%" + objEstado.Nome + "%' or UF like '%" + objEstado.UF + "%' or Pais like '%" + objEstado.Pais + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Estado obj = new Estado();
                    obj.Nome = reader["Nome"].ToString();
                    obj.UF = reader["UF"].ToString();
                    obj.Pais = reader["País"].ToString();
                    listaEstado.Add(obj);

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

            return listaEstado;

        }
    }
}
