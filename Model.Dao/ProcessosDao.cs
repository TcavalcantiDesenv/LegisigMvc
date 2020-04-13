using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class ProcessosDao : Obrigatorio<Processos>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public ProcessosDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Processos obj)
        {
            string create = "insert into Processos values('" +obj.Id + "','"+ obj.Processo + "','" + obj.Relacionado + "','" + obj.CicloVida + "')";
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

        public void delete(Processos obj)
        {
            string delete = "delete from Processos where id ='" + obj.Id + "'";
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

        public bool find(Processos obj)
        {
            bool temRegistros;
            string find = "select*from Processos where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Processo = reader["Processo"].ToString();
                    obj.Relacionado = reader["Relacionado"].ToString();
                    obj.CicloVida = reader["Ciclo de Vida"].ToString();

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

        public List<Processos> findAll()
        {
            List<Processos> listaProcessos = new List<Processos>();
            string find = "select*from Processos order by NomeFantasia asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Processos obj = new Processos();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Processo = reader["Processo"].ToString();
                    obj.Relacionado = reader["Relacionado"].ToString();
                    obj.CicloVida = reader["Ciclo de Vida"].ToString();
                    listaProcessos.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Processos obj2 = new Processos();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaProcessos;
        }

        public void update(Processos obj)
        {
            string update = "update Processos set Processo='" + obj.Processo + "',Relacionado='" + obj.Relacionado + "',CicloVida='" + obj.CicloVida + "'  where Id = '" + obj.Id + "' ";
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

        public bool findProcessosPorId(Processos obj)
        {
            bool temRegistros;
            string find = "select*from Processos where Id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Processo = reader["Processo"].ToString();
                    obj.Relacionado = reader["Relacionado"].ToString();
                    obj.CicloVida = reader["Ciclo de Vida"].ToString();

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

        public List<Processos> findAllProcessos(Processos objProcessos)
        {
            List<Processos> listaProcessos = new List<Processos>();
            string findAll = "select* from Processos where Processo like '%" + objProcessos.Processo + "%' or Relacionado like '%" + objProcessos.Relacionado + "%' or CicloVida like '%" + objProcessos.CicloVida + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Processos obj = new Processos();
                    obj.Processo = reader["Processo"].ToString();
                    obj.Relacionado = reader["Relacionado"].ToString();
                    obj.CicloVida = reader["Ciclo de Vida"].ToString();
                    listaProcessos.Add(obj);

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

            return listaProcessos;

        }

    }
}
