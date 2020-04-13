using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class PaginasDao : Obrigatorio<Paginas>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public PaginasDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Paginas obj)
        {
            string create = "insert into Paginas values('" + obj.Id + "','"+ obj.Codigo + "','" + obj.Pagina + "')";
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

        public void delete(Paginas obj)
        {
            string delete = "delete from Paginas where id ='" + obj.Id + "'";
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

        public bool find(Paginas obj)
        {
            bool temRegistros;
            string find = "select*from Paginas where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Codigo =Convert.ToInt32( reader["Código"].ToString());
                    obj.Pagina = reader["Página"].ToString();

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

        public List<Paginas> findAll()
        {
            List<Paginas> listaPaginas = new List<Paginas>();
            string find = "select*from Paginas order by id asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Paginas obj = new Paginas();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Codigo = Convert.ToInt32(reader["Código"].ToString());
                    obj.Pagina = reader["Página"].ToString();
                    listaPaginas.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Paginas obj2 = new Paginas();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaPaginas;
        }

        public void update(Paginas obj)
        {
            string update = "update Paginas set Codigo='" + obj.Codigo + "',Pagina='" + obj.Pagina + "'  where Id = '" + obj.Id + "' ";
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

        public bool findPaginasPorId(Paginas obj)
        {
            bool temRegistros;
            string find = "select*from Paginas where Id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Codigo = Convert.ToInt32(reader["Código"].ToString());
                    obj.Pagina = reader["Página"].ToString();

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

        public List<Paginas> findAllPagina(Paginas objPagina)
        {
            List<Paginas> listaPaginas = new List<Paginas>();
            string findAll = "select* from Paginas where Pagina like '%" + objPagina.Pagina + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Paginas obj = new Paginas();
                    obj.Codigo = Convert.ToInt32(reader["Código"].ToString());
                    obj.Pagina = reader["Página"].ToString();
                    listaPaginas.Add(obj);

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

            return listaPaginas;

        }
    }
}
