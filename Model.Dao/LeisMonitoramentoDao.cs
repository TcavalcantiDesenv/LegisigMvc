using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class LeisMonitoramentoDao : Obrigatorio<LeisMonitoramento>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public LeisMonitoramentoDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(LeisMonitoramento obj)
        {
            string create = "insert into LeisMonitoramento values('" + obj.Id + "','"+ obj.IdLei + "','" + obj.IdMonitora + "')";
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

        public void delete(LeisMonitoramento obj)
        {
            string delete = "delete from LeisMonitoramento where id ='" + obj.Id + "'";
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

        public bool find(LeisMonitoramento obj)
        {
            bool temRegistros;
            string find = "select*from LeisMonitoramento where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IdLei =Convert.ToInt32 (reader["IdLei"].ToString());
                    obj.IdMonitora =Convert.ToInt32 (reader["IdMonitora"].ToString());
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

        public List<LeisMonitoramento> findAll()
        {
            List<LeisMonitoramento> listaLeisMonitoramento = new List<LeisMonitoramento>();
            string find = "select*from LeisMonitoramento order by IdLei asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    LeisMonitoramento obj = new LeisMonitoramento();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.IdLei =Convert.ToInt32( reader["IdLei"].ToString());
                    obj.IdMonitora =Convert.ToInt32 (reader["IdMonitora"].ToString());
                    listaLeisMonitoramento.Add(obj);
                }

            }
            catch (Exception ex)
            {
                LeisMonitoramento obj2 = new LeisMonitoramento();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLeisMonitoramento;
        }

        public void update(LeisMonitoramento obj)
        {
            string update = "update LeisMonitoramento set IdLei='" + obj.IdLei + "',IdMonitora='" + obj.IdMonitora + "'  where Id = '" + obj.Id + "' ";
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

        public bool findLeisMonitoramentoPorId(LeisMonitoramento obj)
        {
            bool temRegistros;
            string find = "select*from LeisMonitoramento where IdLei='" + obj.IdLei + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IdLei =Convert.ToInt32( reader["IdLei"].ToString());
                    obj.IdMonitora =Convert.ToInt32( reader["IdMonitora"].ToString());
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

        public List<LeisMonitoramento> findAllLeisMonitoramento(LeisMonitoramento objLeisMonitoramento)
        {
            List<LeisMonitoramento> listaLeisMonitoramento = new List<LeisMonitoramento>();
            string findAll = "select* from LeisMonitoramento where IdLei like '%" + objLeisMonitoramento.IdLei + "%' or IdMonitora like '%" + objLeisMonitoramento.IdMonitora +  "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    LeisMonitoramento obj = new LeisMonitoramento();
                    obj.IdLei = Convert.ToInt32(reader["IdLei"].ToString());
                    obj.IdMonitora = Convert.ToInt32(reader["IdMonitora"].ToString());
                    obj.Estados = 99;
                    listaLeisMonitoramento.Add(obj);

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

            return listaLeisMonitoramento;

        }

    }
}
