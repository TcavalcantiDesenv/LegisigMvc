using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class LinksDao : Obrigatorio<Links>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public LinksDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Links obj)
        {
            string create = "insert into Links values('" + obj.id + "','" + obj.Sistema + "','" + obj.Ambito + "','" + obj.Orgao + "','" + obj.Numero + "','" + obj.Tema + "','" + obj.Link + "')";
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

        public void delete(Links obj)
        {
            string delete = "delete from Links where id ='" + obj.id + "'";
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

        public bool find(Links obj)
        {
            bool temRegistros;
            string find = "select*from Links where id='" + obj.id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Sistema = reader["Sistema"].ToString();
                    obj.Ambito = reader["Âmbito"].ToString();
                    obj.Orgao = reader["Órgão"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Tema = reader["Tema"].ToString();
                    obj.Link = reader["Link"].ToString();
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

        public List<Links> findAll()
        {
            List<Links> listaLinks = new List<Links>();
            string find = "select*from Links order by Sistema asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Links obj = new Links();
                    obj.id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Sistema = reader["Sistema"].ToString();
                    obj.Ambito = reader["Âmbito"].ToString();
                    obj.Orgao = reader["Órgão"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Tema = reader["Tema"].ToString();
                    obj.Link = reader["Link"].ToString();
                    listaLinks.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Links obj2 = new Links();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLinks;
        }

        public void update(Links obj)
        {
            string update = "update Links set Sistema='" + obj.Sistema + "',Ambito='" + obj.Ambito + "',Orgao='" + obj.Orgao + "',Numero='" + obj.Numero + "',Tema='" + obj.Tema + "',Link='" + obj.Link + "'  where Id = '" + obj.id + "' ";
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

        public bool findLinksPorId(Links obj)
        {
            bool temRegistros;
            string find = "select*from Links where id='" + obj.id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Sistema = reader["Sistema"].ToString();
                    obj.Ambito = reader["Âmbito"].ToString();
                    obj.Orgao = reader["Órgão"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Tema = reader["Tema"].ToString();
                    obj.Link = reader["Link"].ToString();

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

        public List<Links> findAllLinks(Links objLinks)
        {
            List<Links> listaLinks = new List<Links>();
            string findAll = "select* from Links where Sistema like '%" + objLinks.Sistema + "%' or Ambito like '%" + objLinks.Ambito + "%' or Orgao like '%" + objLinks.Orgao + "%' or Numero like '%" + objLinks.Numero + "%' or Tema like '%" + objLinks.Tema + "%' or Link like '%" + objLinks.Link + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Links obj = new Links();
                    obj.Sistema = reader["Sistema"].ToString();
                    obj.Ambito = reader["Âmbito"].ToString();
                    obj.Orgao = reader["Órgão"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Tema = reader["Tema"].ToString();
                    obj.Link = reader["Link"].ToString();
                    listaLinks.Add(obj);

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

            return listaLinks;

        }
    }
}
