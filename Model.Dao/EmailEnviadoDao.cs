using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class EmailEnviadoDao : Obrigatorio<EmailEnviado>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public EmailEnviadoDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(EmailEnviado obj)
        {
            string create = "insert into EmailEnviado values('" + obj.Id + "','" + obj.Nome + "','" + obj.RazaoSocial + "','" + obj.Email + "','" + obj.Motivo + "','" + obj.Data + "','" + obj.Status + "')";
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

        public void delete(EmailEnviado obj)
        {
            string delete = "delete from EmailEnviado where id ='" + obj.Id + "'";
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

        public bool find(EmailEnviado obj)
        {
            bool temRegistros;
            string find = "select*from EmailEnviado where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Nome = reader["Nome"].ToString();
                    obj.RazaoSocial = reader["RazãoSocial"].ToString();
                    obj.Email = reader["Email"].ToString();
                    obj.Motivo = reader["Motivo"].ToString();
                    obj.Data =Convert.ToDateTime( reader["Data"].ToString());
                    obj.Status = reader["Status"].ToString();


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

        public List<EmailEnviado> findAll()
        {
            List<EmailEnviado> listaEmailEnviado = new List<EmailEnviado>();
            string find = "select*from EmailEnviado order by Id asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    EmailEnviado obj = new EmailEnviado();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Nome = reader["Nome"].ToString();
                    obj.RazaoSocial = reader["RazãoSocial"].ToString();
                    obj.Email = reader["Email"].ToString();
                    obj.Motivo = reader["Motivo"].ToString();
                    obj.Data = Convert.ToDateTime(reader["Data"].ToString());
                    obj.Status = reader["Status"].ToString();
                    listaEmailEnviado.Add(obj);
                }

            }
            catch (Exception ex)
            {
                EmailEnviado obj2 = new EmailEnviado();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaEmailEnviado;
        }

        public void update(EmailEnviado obj)
        {
            string update = "update EmailEnviado set Nome='" + obj.Nome + "',RazaoSocial='" + obj.RazaoSocial + "',Email='" + obj.Email + "',Motivo='" + obj.Motivo + "',Data='" + obj.Data + "',Status='" + obj.Status + "' where Id='" + obj.Id + "'";
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

        public bool findEmailEnviadoPorId(EmailEnviado obj)
        {
            bool temRegistros;
            string find = "select*from EmailEnviado where Id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Nome = reader["Nome"].ToString();
                    obj.RazaoSocial = reader["RazãoSocial"].ToString();
                    obj.Email = reader["Email"].ToString();
                    obj.Motivo = reader["Motivo"].ToString();
                    obj.Data = Convert.ToDateTime(reader["Data"].ToString());
                    obj.Status = reader["Status"].ToString();

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

        public List<EmailEnviado> findAllEmailEnviado(EmailEnviado objEmailEnviado)
        {
            List<EmailEnviado> listaEmailEnviado = new List<EmailEnviado>();
            string findAll = "select* from EmailEnviado where Nome like '%" + objEmailEnviado.Nome + "%' or RazaoSocial like '%" + objEmailEnviado.RazaoSocial + "%' or Email like '%" + objEmailEnviado.Email + "%' or Motivo like '%" + objEmailEnviado.Motivo + "%' or Status like '%" + objEmailEnviado.Status + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    EmailEnviado obj = new EmailEnviado();
                    obj.Nome = reader["Nome"].ToString();
                    obj.RazaoSocial = reader["RazãoSocial"].ToString();
                    obj.Email = reader["Email"].ToString();
                    obj.Motivo = reader["Motivo"].ToString();
                    obj.Data = Convert.ToDateTime(reader["Data"].ToString());
                    obj.Status = reader["Status"].ToString();
                    listaEmailEnviado.Add(obj);

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

            return listaEmailEnviado;

        }
    }
}

