using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class AtribuicoesDao : Obrigatorio<Atribuicoes>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public AtribuicoesDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Atribuicoes obj)
        {
            string create = "insert into Atribuicoes values('" + obj.ID + "','" + obj.Codigo + "','" + obj.Atribuicao + "','" + obj.IdPagina + "')";
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

        public void delete(Atribuicoes obj)
        {
            string delete = "delete from Atribuicoes where id ='" + obj.ID + "'";
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

        public bool find(Atribuicoes obj)
        {
            bool temRegistros;
            string find = "select*from Atribuicoes where id='" + obj.ID + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Codigo = Convert.ToInt32(reader["Código"].ToString());
                    obj.Atribuicao = reader["Atribuição"].ToString();
                    obj.IdPagina = Convert.ToInt32(reader["IdPagina"].ToString());


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

        public List<Atribuicoes> findAll()
        {
            List<Atribuicoes> listaAtribuicoes = new List<Atribuicoes>();
            string find = "select*from Atribuicoes order by ID asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Atribuicoes obj = new Atribuicoes();
                    obj.ID = Convert.ToInt32(reader["Id"].ToString());
                    obj.Codigo = Convert.ToInt32(reader["Código"].ToString());
                    obj.Atribuicao = reader["Atribuição"].ToString();
                    obj.IdPagina = Convert.ToInt32(reader["IdPagina"].ToString());
                    listaAtribuicoes.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Atribuicoes obj2 = new Atribuicoes();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaAtribuicoes;
        }

        public void update(Atribuicoes obj)
        {
            string update = "update Atribuicoes set Codigo='" + obj.Codigo + "',Atribuicao='" + obj.Atribuicao + "',IdPagina='" + obj.IdPagina + "'  where Id = '" + obj.ID + "' ";
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

        public bool findAtribuicoesPorId(Atribuicoes obj)
        {
            bool temRegistros;
            string find = "select*from Atribuicoes where cnpj='" + obj.ID + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Codigo = Convert.ToInt32(reader["Código"].ToString());
                    obj.Atribuicao = reader["Atribuição"].ToString();
                    obj.IdPagina = Convert.ToInt32(reader["IdPagina"].ToString());

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

        public List<Atribuicoes> findAllAtribuicoes(Atribuicoes objAtribuicoes)
        {
            List<Atribuicoes> listaAtribuicoes = new List<Atribuicoes>();
            string findAll = "select* from Atribuicoes where Atribuicao like '%" + objAtribuicoes.Atribuicao + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Atribuicoes obj = new Atribuicoes();
                    obj.Codigo = Convert.ToInt32(reader["Código"].ToString());
                    obj.Atribuicao = reader["Atribuição"].ToString();
                    obj.IdPagina = Convert.ToInt32(reader["IdPagina"].ToString());
                    listaAtribuicoes.Add(obj);

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

            return listaAtribuicoes;

        }
    }
}

