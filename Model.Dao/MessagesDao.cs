using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class MessagesDao : Obrigatorio<Messages>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public MessagesDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Messages obj)
        {
            string create = "insert into Messages values('" + obj.ID + "','" + obj.Date + "','" + obj.Subject + "','" + obj.From + "','" + obj.To + "','" + obj.Text + "','" + obj.Folder + "','" + obj.Unread + "','" + obj.HasAttachment + "','" + obj.IsReply + "')";
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

        public void delete(Messages obj)
        {
            string delete = "delete from Messages where id ='" + obj.ID + "'";
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

        public bool find(Messages obj)
        {
            bool temRegistros;
            string find = "select*from Messages where id='" + obj.ID + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Date =Convert.ToDateTime( reader["Data"].ToString());
                    obj.Subject = reader["Assunto"].ToString();
                    obj.From = reader["De"].ToString();
                    obj.To = reader["Para"].ToString();
                    obj.Text = reader["Texto"].ToString();
                    obj.Folder = reader["Pasta"].ToString();
                    obj.Unread =Convert.ToBoolean( reader["Não Lida"].ToString());
                    obj.HasAttachment =Convert.ToBoolean( reader["Anexo"].ToString());
                    obj.IsReply =Convert.ToBoolean( reader["Respondida"].ToString());
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

        public List<Messages> findAll()
        {
            List<Messages> listaMessages = new List<Messages>();
            string find = "select*from Messages order by Date asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Messages obj = new Messages();
                    obj.ID = Convert.ToInt32(reader["Id"].ToString());
                    obj.Date = Convert.ToDateTime(reader["Data"].ToString());
                    obj.Subject = reader["Assunto"].ToString();
                    obj.From = reader["De"].ToString();
                    obj.To = reader["Para"].ToString();
                    obj.Text = reader["Texto"].ToString();
                    obj.Folder = reader["Pasta"].ToString();
                    obj.Unread = Convert.ToBoolean(reader["Não Lida"].ToString());
                    obj.HasAttachment = Convert.ToBoolean(reader["Anexo"].ToString());
                    obj.IsReply = Convert.ToBoolean(reader["Respondida"].ToString());
                    listaMessages.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Messages obj2 = new Messages();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaMessages;
        }

        public void update(Messages obj)
        {
            string update = "update Messages set Date='" + obj.Date + "',Subject='" + obj.Subject + "',From='" + obj.From + "',To='" + obj.To + "',Text='" + obj.Text + "',Folder='" + obj.Folder + "',Unread='" + obj.Unread + "',HasAttachment='" + obj.HasAttachment + "',IsReply='" + obj.IsReply + "'  where Id = '" + obj.ID + "' ";
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

        public bool findMessagePorId(Messages obj)
        {
            bool temRegistros;
            string find = "select*from Messages where ID='" + obj.ID + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Date = Convert.ToDateTime(reader["Data"].ToString());
                    obj.Subject = reader["Assunto"].ToString();
                    obj.From = reader["De"].ToString();
                    obj.To = reader["Para"].ToString();
                    obj.Text = reader["Texto"].ToString();
                    obj.Folder = reader["Pasta"].ToString();
                    obj.Unread = Convert.ToBoolean(reader["Não Lida"].ToString());
                    obj.HasAttachment = Convert.ToBoolean(reader["Anexo"].ToString());
                    obj.IsReply = Convert.ToBoolean(reader["Respondida"].ToString());

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

        public List<Messages> findAllMessages(Messages objMessages)
        {
            List<Messages> listaMessages = new List<Messages>();
            string findAll = "select* from Messages where Subject like '%" + objMessages.Subject + "%' or From like '%" + objMessages.From + "%' or To like '%" + objMessages.To + "%' or Text like '%" + objMessages.Text + "%' or Folder like '%" + objMessages.Folder + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Messages obj = new Messages();
                    obj.Date = Convert.ToDateTime(reader["Data"].ToString());
                    obj.Subject = reader["Assunto"].ToString();
                    obj.From = reader["De"].ToString();
                    obj.To = reader["Para"].ToString();
                    obj.Text = reader["Texto"].ToString();
                    obj.Folder = reader["Pasta"].ToString();
                    obj.Unread = Convert.ToBoolean(reader["Não Lida"].ToString());
                    obj.HasAttachment = Convert.ToBoolean(reader["Anexo"].ToString());
                    obj.IsReply = Convert.ToBoolean(reader["Respondida"].ToString());
                    listaMessages.Add(obj);

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

            return listaMessages;

        }
    }
}
