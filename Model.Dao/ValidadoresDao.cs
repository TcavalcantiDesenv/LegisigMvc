using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class ValidadoresDao : Obrigatorio<Validadores>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public ValidadoresDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Validadores obj)
        {
            string create = "insert into Validadores values('" + obj.Id + "','" + obj.IdCliente + "','" + obj.Usuário + "','" + obj.Operacao + "','" + obj.Email + "')";
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

        public void delete(Validadores obj)
        {
            string delete = "delete from Validadores where id ='" + obj.Id + "'";
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

        public bool find(Validadores obj)
        {
            bool temRegistros;
            string find = "select*from Validadores where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IdCliente =Convert.ToInt32( reader["IdCliente"].ToString());
                    obj.Usuário = reader["Usuário"].ToString();
                    obj.Operacao = reader["Operaçao"].ToString();
                    obj.Email = reader["Email"].ToString();

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

        public List<Validadores> findAll()
        {
            List<Validadores> listaValidadores = new List<Validadores>();
            string find = "select*from Validadores order by NomeFantasia asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Validadores obj = new Validadores();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"].ToString());
                    obj.Usuário = reader["Usuário"].ToString();
                    obj.Operacao = reader["Operaçao"].ToString();
                    obj.Email = reader["Email"].ToString();
                    listaValidadores.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Validadores obj2 = new Validadores();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaValidadores;
        }

        public void update(Validadores obj)
        {
            string update = "update Validadores set IdCliente='" + obj.IdCliente + "',Usuário='" + obj.Usuário + "',Operacao='" + obj.Operacao + "',Email='" + obj.Email + "' where id='" + obj.Id + "'";
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

        public bool findValidadoresPorId(Validadores obj)
        {
            bool temRegistros;
            string find = "select*from Validadores where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"].ToString());
                    obj.Usuário = reader["Usuário"].ToString();
                    obj.Operacao = reader["Operaçao"].ToString();
                    obj.Email = reader["Email"].ToString();

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

        public List<Validadores> findAllValidadores(Validadores objValidadores)
        {
            List<Validadores> listaValidadores = new List<Validadores>();
            string findAll = "select* from Validadores where Usuário like '%" + objValidadores.Usuário + "%' or Operacao like '%" + objValidadores.Operacao + "%' or Email like '%" + objValidadores.Email + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Validadores obj = new Validadores();
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"].ToString());
                    obj.Usuário = reader["Usuário"].ToString();
                    obj.Operacao = reader["Operaçao"].ToString();
                    obj.Email = reader["Email"].ToString();
                    listaValidadores.Add(obj);

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

            return listaValidadores;

        }

    }
}
