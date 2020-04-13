using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class MonitorDao : Obrigatorio<Monitor1>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public MonitorDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Monitor1 obj)
        {
            string create = "insert into Monitor values('" + obj.Id + "','"+ obj.Metodos + "','" + obj.Tipo + "','" + obj.Finalidade + "','" + obj.Frequencia + "','" + obj.Responsavel + "','" + obj.Situacao + "','" + obj.Validade + "','" + obj.ProxData + "','" + obj.Prazo + "','" + obj.Observacao + "','" + obj.IdCondicionante + "','" + obj.IdLicenca + "','" + obj.IdLei + "')";
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

        public void delete(Monitor1 obj)
        {
            string delete = "delete from Monitor where id ='" + obj.Id + "'";
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

        public bool find(Monitor1 obj)
        {
            bool temRegistros;
            string find = "select*from Monitor where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Metodos = reader["Métodos"].ToString();
                    obj.Tipo = reader["Tipo"].ToString();
                    obj.Finalidade = reader["Finalidade"].ToString();
                    obj.Frequencia = reader["Frequência"].ToString();
                    obj.Responsavel = reader["Responsável"].ToString();
                    obj.Situacao = reader["Situação"].ToString();
                    obj.Validade =Convert.ToDateTime( reader["Validade"].ToString());
                    obj.ProxData =Convert.ToDateTime( reader["ProxData"].ToString());
                    //         obj.Estados = 0;
                    obj.Prazo =Convert.ToInt32( reader["Prazo"].ToString());
                    obj.Observacao = reader["Observação"].ToString();
                    obj.IdCondicionante =Convert.ToInt32( reader["IdCondicionante"].ToString());
                    obj.IdLicenca = Convert.ToInt32(reader["IdLicença"].ToString());
                    obj.IdLei = Convert.ToInt32(reader["IdLei"].ToString());
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

        public List<Monitor1> findAll()
        {
            List<Monitor1> listaMonitor = new List<Monitor1>();
            string find = "select*from Monitor order by Id asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Monitor1 obj = new Monitor1();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Metodos = reader["Métodos"].ToString();
                    obj.Tipo = reader["Tipo"].ToString();
                    obj.Finalidade = reader["Finalidade"].ToString();
                    obj.Frequencia = reader["Frequência"].ToString();
                    obj.Responsavel = reader["Responsável"].ToString();
                    obj.Situacao = reader["Situação"].ToString();
                    obj.Validade = Convert.ToDateTime(reader["Validade"].ToString());
                    obj.ProxData = Convert.ToDateTime(reader["ProxData"].ToString());
                    //         obj.Estados = 0;
                    obj.Prazo = Convert.ToInt32(reader["Prazo"].ToString());
                    obj.Observacao = reader["Observação"].ToString();
                    obj.IdCondicionante = Convert.ToInt32(reader["IdCondicionante"].ToString());
                    obj.IdLicenca = Convert.ToInt32(reader["IdLicença"].ToString());
                    obj.IdLei = Convert.ToInt32(reader["IdLei"].ToString());
                    listaMonitor.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Monitor1 obj2 = new Monitor1();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaMonitor;
        }

        public void update(Monitor1 obj)
        {
            string update = "update Monitor set Metodos='" + obj.Metodos + "',Tipo='" + obj.Tipo + "',Finalidade='" + obj.Finalidade + "',Frequencia='" + obj.Frequencia + "',Responsavel='" + obj.Responsavel + "',Situacao='" + obj.Situacao + "',Validade='" + obj.Validade + "',ProxData='" + obj.ProxData + "',Prazo='" + obj.Prazo + "',Observacao='" + obj.Observacao + "',IdCondicionante='" + obj.IdCondicionante + "',IdLicenca='" + obj.IdLicenca + "',IdLei='" + obj.IdLei + "'  where Id = '" + obj.Id + "' ";
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

        public bool findMonitorPorId(Monitor1 obj)
        {
            bool temRegistros;
            string find = "select*from Monitor where Id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Metodos = reader["Métodos"].ToString();
                    obj.Tipo = reader["Tipo"].ToString();
                    obj.Finalidade = reader["Finalidade"].ToString();
                    obj.Frequencia = reader["Frequência"].ToString();
                    obj.Responsavel = reader["Responsável"].ToString();
                    obj.Situacao = reader["Situação"].ToString();
                    obj.Validade = Convert.ToDateTime(reader["Validade"].ToString());
                    obj.ProxData = Convert.ToDateTime(reader["ProxData"].ToString());
                    //         obj.Estados = 0;
                    obj.Prazo = Convert.ToInt32(reader["Prazo"].ToString());
                    obj.Observacao = reader["Observação"].ToString();
                    obj.IdCondicionante = Convert.ToInt32(reader["IdCondicionante"].ToString());
                    obj.IdLicenca = Convert.ToInt32(reader["IdLicença"].ToString());
                    obj.IdLei = Convert.ToInt32(reader["IdLei"].ToString());

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

        public List<Monitor1> findAllMonitor(Monitor1 objMonitor)
        {
            List<Monitor1> listaMonitor = new List<Monitor1>();
            string findAll = "select* from Monitor where Metodos like '%" + objMonitor.Metodos + "%' or Tipo like '%" + objMonitor.Tipo + "%' or Finalidade like '%" + objMonitor.Finalidade + "%' or Frequencia like '%" + objMonitor.Frequencia + "%' or Responsavel like '%" + objMonitor.Responsavel + "%' or Situacao like '%" + objMonitor.Situacao + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Monitor1 obj = new Monitor1();
                    obj.Metodos = reader["Métodos"].ToString();
                    obj.Tipo = reader["Tipo"].ToString();
                    obj.Finalidade = reader["Finalidade"].ToString();
                    obj.Frequencia = reader["Frequência"].ToString();
                    obj.Responsavel = reader["Responsável"].ToString();
                    obj.Situacao = reader["Situação"].ToString();
                    obj.Validade = Convert.ToDateTime(reader["Validade"].ToString());
                    obj.ProxData = Convert.ToDateTime(reader["ProxData"].ToString());
                    //         obj.Estados = 0;
                    obj.Prazo = Convert.ToInt32(reader["Prazo"].ToString());
                    obj.Observacao = reader["Observação"].ToString();
                    obj.IdCondicionante = Convert.ToInt32(reader["IdCondicionante"].ToString());
                    obj.IdLicenca = Convert.ToInt32(reader["IdLicença"].ToString());
                    obj.IdLei = Convert.ToInt32(reader["IdLei"].ToString());
                    listaMonitor.Add(obj);

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

            return listaMonitor;

        }
    }
}
