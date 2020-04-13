using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class AnexosDao : Obrigatorio<Anexos>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public AnexosDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Anexos obj)
        {
            string create = "insert into Anexos values('" + obj.Id + "','" + obj.Arquivo + "','" + obj.ContentType + "','" + obj.Data + "','" + obj.IDCliente + "','" + obj.IDLegisGeral + "','" + obj.IDConformidade + "','" + obj.IDParametros + "')";
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

        public void delete(Anexos obj)
        {
            string delete = "delete from Anexos where id ='" + obj.Id + "'";
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

        public bool find(Anexos obj)
        {
            bool temRegistros;
            string find = "select*from Anexos where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Arquivo = reader["Arquivo"].ToString();
                    obj.ContentType = reader["ContentType"].ToString();
                    //obj.Data =Convert.ToString (  reader["Data"].ToString());
                    obj.IDCliente =Convert.ToInt32( reader["IDCliente"].ToString());
                    obj.IDLegisGeral =Convert.ToInt32( reader["IDLegisGeral"].ToString());
                    obj.IDConformidade =Convert.ToInt32( reader["IDConformidade"].ToString());
                    obj.IDParametros =Convert.ToInt32( reader["IDPârametros"].ToString());
                    
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

        public List<Anexos> findAll()
        {
            List<Anexos> listaAnexos = new List<Anexos>();
            string find = "select*from Anexos order by arquivos asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Anexos obj = new Anexos();
                    obj.Arquivo = reader["Arquivo"].ToString();
                    obj.ContentType = reader["ContentType"].ToString();
                    //obj.Data =Convert.ToString (  reader["Data"].ToString());
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.IDConformidade = Convert.ToInt32(reader["IDConformidade"].ToString());
                    obj.IDParametros = Convert.ToInt32(reader["IDPârametros"].ToString());

                    listaAnexos.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Anexos obj2 = new Anexos();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaAnexos;
        }

        public void update(Anexos obj)
        {
            string update = "update Anexos set Arquivo='" + obj.Arquivo + "',ContentType='" + obj.ContentType + "',Data='" + obj.Data + "',IDCliente='" + obj.IDCliente + "',IDLegisGeral='" + obj.IDLegisGeral + "',IDConformidade='" + obj.IDConformidade + "',IDParametros='" + obj.IDParametros + "'  where Id = '" + obj.Id + "' ";
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

        public bool findAnexosPorArquivo(Anexos obj)
        {
            bool temRegistros;
            string find = "select*from Anexos where Arquivo='" + obj.Arquivo + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Arquivo = reader["Arquivo"].ToString();
                    obj.ContentType = reader["ContentType"].ToString();
                    //obj.Data =Convert.ToString (  reader["Data"].ToString());
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.IDConformidade = Convert.ToInt32(reader["IDConformidade"].ToString());
                    obj.IDParametros = Convert.ToInt32(reader["IDPârametros"].ToString());
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

        public List<Anexos> findAllAnexos(Anexos objAnexo)
        {
            List<Anexos> listaAnexos = new List<Anexos>();
            string findAll = "select* from Anexos where Arquivo like '%" + objAnexo.Arquivo + "%' or ContentType like '%" + objAnexo.ContentType + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Anexos obj = new Anexos();
                    obj.Arquivo = reader["Arquivo"].ToString();
                    obj.ContentType = reader["ContentType"].ToString();
                    //obj.Data =Convert.ToString (  reader["Data"].ToString());
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.IDConformidade = Convert.ToInt32(reader["IDConformidade"].ToString());
                    obj.IDParametros = Convert.ToInt32(reader["IDPârametros"].ToString());

                    listaAnexos.Add(obj);

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

            return listaAnexos;

        }
    }
}
