using Model.Dao;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Entity
{
    public class CondicaoOpDao : Obrigatorio<CondicaoOp>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public CondicaoOpDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(CondicaoOp obj)
        {
            string create = "insert into CondicaoOp values('" + obj.Id + "','" + obj.Sigla + "','" + obj.Descricao + "')";
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

        public void delete(CondicaoOp obj)
        {
            string delete = "delete from CondicaoOp where Id ='" + obj.Id + "'";
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

        public bool find(CondicaoOp obj)
        {
            bool temRegistros;
            string find = "select*from CondicaoOp where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Sigla = reader["Sigla"].ToString();
                    obj.Descricao = reader["Descrição"].ToString();


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

        public List<CondicaoOp> findAll()
        {
            List<CondicaoOp> listaCondicaoOp = new List<CondicaoOp>();
            string find = "select*from CondicaoOp order by NomeFantasia asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    CondicaoOp obj = new CondicaoOp();
                    obj.Sigla = reader["Sigla"].ToString();
                    obj.Descricao = reader["Descrição"].ToString();
                    listaCondicaoOp.Add(obj);
                }

            }
            catch (Exception ex)
            {
                CondicaoOp obj2 = new CondicaoOp();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaCondicaoOp;
        }

        public void update(CondicaoOp obj)
        {
            string update = "update CondicaoOp set Sigla='" + obj.Sigla + "',Descricao='" + obj.Descricao + "'  where Id = '" + obj.Id + "' ";
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

        public bool findCondicaoPorId(CondicaoOp obj)
        {
            bool temRegistros;
            string find = "select*from CondicaoOp where Id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Sigla = reader["Sigla"].ToString();
                    obj.Descricao = reader["Descrição"].ToString();

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

        public List<CondicaoOp> findAllCondicaoOp(CondicaoOp objCondicaoOp)
        {
            List<CondicaoOp> listaCondicaoOp = new List<CondicaoOp>();
            string findAll = "select* from CondicaoOp where Sigla like '%" + objCondicaoOp.Sigla + "%' or Descricao like '%" + objCondicaoOp.Descricao + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    CondicaoOp obj = new CondicaoOp();
                    obj.Sigla = reader["Sigla"].ToString();
                    obj.Descricao = reader["Descrição"].ToString();
                    listaCondicaoOp.Add(obj);

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

            return listaCondicaoOp;

        }

    }
}
