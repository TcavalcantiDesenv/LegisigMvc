using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class Usuarios_PaginasDao : Obrigatorio<Usuarios_Paginas>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public Usuarios_PaginasDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Usuarios_Paginas obj)
        {
            string create = "insert into Usuarios_Paginas values('" + obj.id + "','" + obj.IdUsuario + "','" + obj.Codigo + "','" + obj.Pagina + "')";
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

        public void delete(Usuarios_Paginas obj)
        {
            string delete = "delete from Usuarios_Paginas where id ='" + obj.id + "'";
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

        public bool find(Usuarios_Paginas obj)
        {
            bool temRegistros;
            string find = "select*from Usuarios_Paginas where id='" + obj.id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IdUsuario = Convert.ToInt32(reader["IdUsuário"].ToString());
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

        public List<Usuarios_Paginas> findAll()
        {
            List<Usuarios_Paginas> listaUsuarios_Paginas = new List<Usuarios_Paginas>();
            string find = "select*from Usuarios_Paginas order by id asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Usuarios_Paginas obj = new Usuarios_Paginas();
                    obj.id = Convert.ToInt32(reader["Id"].ToString());
                    obj.IdUsuario = Convert.ToInt32(reader["IdUsuário"].ToString());
                    obj.Codigo = Convert.ToInt32(reader["Código"].ToString());
                    obj.Pagina = reader["Página"].ToString();
                    listaUsuarios_Paginas.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Usuarios_Paginas obj2 = new Usuarios_Paginas();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaUsuarios_Paginas;
        }

        public void update(Usuarios_Paginas obj)
        {
            string update = "update Usuarios_Paginas set IdUsuario='" + obj.IdUsuario + "',Codigo='" + obj.Codigo + "',Pagina='" + obj.Pagina + "' where id='" + obj.id + "'";
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

        public bool findUsuarios_PaginasPorId(Usuarios_Paginas obj)
        {
            bool temRegistros;
            string find = "select*from Usuarios_Paginas where id='" + obj.id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IdUsuario = Convert.ToInt32(reader["IdUsuário"].ToString());
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

        public List<Usuarios_Paginas> findAllUsuarios_Paginas(Usuarios_Paginas objUsuarios_Paginas)
        {
            List<Usuarios_Paginas> listaUsuarios_Paginas = new List<Usuarios_Paginas>();
            string findAll = "select* from Usuarios_Paginas where Pagina like '%" + objUsuarios_Paginas.Pagina +  "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Usuarios_Paginas obj = new Usuarios_Paginas();
                    obj.IdUsuario = Convert.ToInt32(reader["IdUsuário"].ToString());
                    obj.Codigo = Convert.ToInt32(reader["Código"].ToString());
                    obj.Pagina = reader["Página"].ToString();
                    listaUsuarios_Paginas.Add(obj);

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

            return listaUsuarios_Paginas;

        }

    }
}
