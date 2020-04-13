using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model.Entity;
namespace Model.Dao
{
    public class ArquivosDao : Obrigatorio<Arquivos>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public ArquivosDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }
        public void create(Arquivos obj)
        {
            string create = @"insert into Arquivos values('" + obj?.NOME + "','" + obj?.DESCRICAO + "',convert(date, '" + obj?.DATA + "', 103) ')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void delete(Arquivos obj)
        {
            string delete = "delete from Arquivos where EAN ='" + obj.IDARQUIVO + "'";
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

        public bool find(Arquivos obj)
        {
            bool temRegistros;
            string find = "select * from Arquivos where IDARQUIVO='" + obj.IDARQUIVO + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IDARQUIVO = Convert.ToInt32( reader["IDARQUIVO"].ToString());
                    obj.DATA = Convert.ToDateTime(reader["DATA"].ToString());
                    obj.DESCRICAO = reader["DESCRICAO"].ToString();
                    obj.NOME = reader["NOME"].ToString();
                    obj.OBSERVACAO = reader["OBSERVACAO"].ToString();
                   
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

        public List<Arquivos> findAll()
        {
            List<Arquivos> listaClientes = new List<Arquivos>();
            string find = "select * from Arquivos order by Nome asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Arquivos obj = new Arquivos();
                    obj.IDARQUIVO = Convert.ToInt32(reader["IDARQUIVO"].ToString());
                    obj.DATA = Convert.ToDateTime(reader["DATA"].ToString());
                    obj.DESCRICAO = reader["DESCRICAO"].ToString();
                    obj.NOME = reader["NOME"].ToString();
                    obj.OBSERVACAO = reader["OBSERVACAO"].ToString();
                    obj.Estados = 99;
                    listaClientes.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Arquivos obj2 = new Arquivos();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaClientes;
        }

        public void update(Arquivos obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
