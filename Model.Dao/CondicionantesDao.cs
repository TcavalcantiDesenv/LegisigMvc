using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class CondicionantesDao : Obrigatorio<Condicionantes>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public CondicionantesDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Condicionantes obj)
        {
            string create = "insert into Condicionantes values('" + obj.Id + "','" + obj.Numero + "','" + obj.Descricao + "','" + obj.Avaliacao + "','" + obj.Controles + "','" + obj.Responsavel + "','" + obj.MeiosAnalise + "','" + obj.FrequenciaMonotora + "','" + obj.Situacao + "','" + obj.AplicavelPrazo + "','" + obj.Data + "','" + obj.Alerta + "','" + obj.IdLicenca + "')";
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

        public void delete(Condicionantes obj)
        {
            string delete = "delete from Condicionantes where Id ='" + obj.Id + "'";
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

        public bool find(Condicionantes obj)
        {
            bool temRegistros;
            string find = "select*from Condicionantes where Id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Numero = reader["Numero"].ToString();
                    obj.Descricao = reader["Descrição"].ToString();
                    obj.Avaliacao = reader["Avaliação"].ToString();
                    obj.Controles = reader["Controles"].ToString();
                    obj.Responsavel = reader["Responsável"].ToString();
                    obj.MeiosAnalise = reader["MeiosAnálise"].ToString();
                    obj.FrequenciaMonotora = reader["FrequênciaMonotora"].ToString();
                    obj.Situacao = reader["Situação"].ToString();
                    obj.AplicavelPrazo = reader["AplicavelPrazo"].ToString();
                    //         obj.Estados = 0;
                    obj.Data = Convert.ToDateTime(reader["Data"].ToString());
                    obj.Alerta = Convert.ToInt32(reader["Alerta"].ToString());
                    obj.IdLicenca = Convert.ToInt32(reader["IdLicenca"].ToString());


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

        public List<Condicionantes> findAll()
        {
            List<Condicionantes> listaCondicionantes = new List<Condicionantes>();
            string find = "select*from Condicionantes order by Id asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Condicionantes obj = new Condicionantes();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Numero = reader["Numero"].ToString();
                    obj.Descricao = reader["Descrição"].ToString();
                    obj.Avaliacao = reader["Avaliação"].ToString();
                    obj.Controles = reader["Controles"].ToString();
                    obj.Responsavel = reader["Responsável"].ToString();
                    obj.MeiosAnalise = reader["MeiosAnálise"].ToString();
                    obj.FrequenciaMonotora = reader["FrequênciaMonotora"].ToString();
                    obj.Situacao = reader["Situação"].ToString();
                    obj.AplicavelPrazo = reader["AplicavelPrazo"].ToString();
                    //         obj.Estados = 0;
                    obj.Data = Convert.ToDateTime(reader["Data"].ToString());
                    obj.Alerta = Convert.ToInt32(reader["Alerta"].ToString());
                    obj.IdLicenca = Convert.ToInt32(reader["IdLicenca"].ToString());
                    listaCondicionantes.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Condicionantes obj2 = new Condicionantes();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaCondicionantes;
        }

        public void update(Condicionantes obj)
        {
            string update = "update Condicionantes set Numero='" + obj.Numero + "',Descricao='" + obj.Descricao + "',Avaliacao='" + obj.Avaliacao + "',Controles='" + obj.Controles + "',Responsavel='" + obj.Responsavel + "',MeiosAnalise='" + obj.MeiosAnalise + "',FrequenciaMonotora='" + obj.FrequenciaMonotora + "',Situacao='" + obj.Situacao + "',AplicavelPrazo='" + obj.AplicavelPrazo + "',Data='" + obj.Data + "',Alerta='" + obj.Alerta + "',IdLicenca='" + obj.IdLicenca + "'  where Id = '" + obj.Id + "' ";
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

        public bool findCondicionantesPorId(Condicionantes obj)
        {
            bool temRegistros;
            string find = "select*from Condicionantes where Id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Numero = reader["Numero"].ToString();
                    obj.Descricao = reader["Descrição"].ToString();
                    obj.Avaliacao = reader["Avaliação"].ToString();
                    obj.Controles = reader["Controles"].ToString();
                    obj.Responsavel = reader["Responsável"].ToString();
                    obj.MeiosAnalise = reader["MeiosAnálise"].ToString();
                    obj.FrequenciaMonotora = reader["FrequênciaMonotora"].ToString();
                    obj.Situacao = reader["Situação"].ToString();
                    obj.AplicavelPrazo = reader["AplicavelPrazo"].ToString();
                    //         obj.Estados = 0;
                    obj.Data = Convert.ToDateTime(reader["Data"].ToString());
                    obj.Alerta = Convert.ToInt32(reader["Alerta"].ToString());
                    obj.IdLicenca = Convert.ToInt32(reader["IdLicenca"].ToString());

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

        public List<Condicionantes> findAllCondicionantes(Condicionantes objCondicionantes)
        {
            List<Condicionantes> listaCondicionantes = new List<Condicionantes>();
            string findAll = "select* from Condicionantes where Numero like '%" + objCondicionantes.Numero + "%' or Descricao like '%" + objCondicionantes.Descricao + "%' or Avaliacao like '%" + objCondicionantes.Avaliacao + "%' or Controles like '%" + objCondicionantes.Controles + "%' or Responsavel like '%" + objCondicionantes.Responsavel + "%' or MeiosAnalise like '%" + objCondicionantes.MeiosAnalise + "%' or FrequenciaMonotora like '%" + objCondicionantes.FrequenciaMonotora + "%' or Situacao like '%" + objCondicionantes.Situacao + "%' or AplicavelPrazo like '%" + objCondicionantes.AplicavelPrazo + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Condicionantes obj = new Condicionantes();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Descricao = reader["Descrição"].ToString();
                    obj.Avaliacao = reader["Avaliação"].ToString();
                    obj.Controles = reader["Controles"].ToString();
                    obj.Responsavel = reader["Responsável"].ToString();
                    obj.MeiosAnalise = reader["MeiosAnálise"].ToString();
                    obj.FrequenciaMonotora = reader["FrequênciaMonotora"].ToString();
                    obj.Situacao = reader["Situação"].ToString();
                    obj.AplicavelPrazo = reader["AplicavelPrazo"].ToString();
                    //         obj.Estados = 0;
                    obj.Data = Convert.ToDateTime(reader["Data"].ToString());
                    obj.Alerta = Convert.ToInt32(reader["Alerta"].ToString());
                    obj.IdLicenca = Convert.ToInt32(reader["IdLicenca"].ToString());
                    listaCondicionantes.Add(obj);

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

            return listaCondicionantes;

        }
    }
}
