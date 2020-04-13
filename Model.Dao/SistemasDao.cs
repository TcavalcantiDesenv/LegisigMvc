using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class SistemasDao : Obrigatorio<Sistemas>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public SistemasDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Sistemas obj)
        {
            string create = "insert into Sistemas values('" + obj.Id + "','" + obj.Sistema + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
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

        public void delete(Sistemas obj)
        {
            string delete = "delete from Sistemas where id ='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
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

        public bool find(Sistemas obj)
        {
            bool temRegistros;
            string find = "select*from Sistemas where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Sistema = reader["Sistema"].ToString();

               //     obj.Estados = 99;
                }
                else
                {
               //     obj.Estados = 1;
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

        public List<Sistemas> findAll()
        {
            List<Sistemas> listaSistemas = new List<Sistemas>();
            string find = "select*from Sistemas order by Id asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Sistemas obj = new Sistemas();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Sistema = reader["Sistema"].ToString();
                    listaSistemas.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Sistemas obj2 = new Sistemas();
              //  obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaSistemas;
        }

        public void update(Sistemas obj)
        {
            string update = "update Sistemas set Sistema='" + obj.Sistema + "' where id='" + obj.Id + "' ";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

             //   obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool findSistemasPorId(Sistemas obj)
        {
            bool temRegistros;
            string find = "select*from Sistemas where Id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Sistema = reader["Sistema"].ToString();

                 //   obj.Estados = 99;

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

        public List<Sistemas> findAllSistemas(Sistemas objSistemas)
        {
            List<Sistemas> listaSistemas = new List<Sistemas>();
            string findAll = "select* from Sistemas where Sistema like '%" + objSistemas.Sistema + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Sistemas obj = new Sistemas();
                    obj.Sistema = reader["Sistema"].ToString();
                    listaSistemas.Add(obj);

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

            return listaSistemas;

        }

    }
}
