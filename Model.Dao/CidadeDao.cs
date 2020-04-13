using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class CidadeDao : Obrigatorio<Cidade>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public CidadeDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Cidade obj)
        {
            string create = "insert into Cidade values('" + obj.Id + "','" + obj.Nome + "','" + obj.Estado + "','"  + "')";
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

        public void delete(Cidade obj)
        {
            string delete = "delete from Cidade where id ='" + obj.Id + "'";
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

        public void update(Cidade obj)
        {
            string update = "update Cidade set Nome='" + obj.Nome + "',Estado='" + obj.Estado + "'  where Id = '" + obj.Id + "' ";
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

        public bool find(Cidade obj)
        {
            bool temRegistros;
            string find = "select*from Cidade where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Nome = reader["Nome"].ToString();
                    obj.Estado = Convert.ToInt32(reader["Nome"].ToString());

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

        List<Cidade> Obrigatorio<Cidade>.findAll()
        {
            List<Cidade> listaCidade = new List<Cidade>();
            string find = "select*from Cidade order by Nome asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Cidade obj = new Cidade();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Nome = reader["Nome"].ToString();
                    obj.Estado = Convert.ToInt32(reader["Nome"].ToString());
                    listaCidade.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Cidade obj2 = new Cidade();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaCidade; ;
        }

        public List<Cidade> findAll()
        {
            List<Cidade> listaClientes = new List<Cidade>();
            string find = "select*from Cidade order by Nome asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Cidade obj = new Cidade();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Nome = reader["Nome"].ToString();
                    obj.Estado = Convert.ToInt32(reader["Nome"].ToString());
                    listaClientes.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Cidade obj2 = new Cidade();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaClientes; ;
        }

        public List<Cidade> findAllCidade(Cidade objCidade)
        {
            List<Cidade> listaCidade = new List<Cidade>();
            string findAll = "select* from Cidade where nome like '%" + objCidade.Nome +  "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Cidade obj = new Cidade();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Nome = reader["Nome"].ToString();
                    obj.Estado = Convert.ToInt32(reader["Nome"].ToString());
                    listaCidade.Add(obj);

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

            return listaCidade;

        }

        public List<Cidade> findCidadePorId(Cidade objCidade)
        {
            List<Cidade> listaCidade = new List<Cidade>();
            string findAll = "select * from Cidade where Id = '" + objCidade.Id + "' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Cidade obj = new Cidade();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Nome = reader["Nome"].ToString();
                    obj.Estado = Convert.ToInt32(reader["Nome"].ToString());
                    listaCidade.Add(obj);

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

            return listaCidade;

        }

    }
}
