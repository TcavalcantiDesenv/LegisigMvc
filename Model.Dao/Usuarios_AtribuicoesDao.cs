using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class Usuarios_AtribuicoesDao : Obrigatorio<Usuarios_Atribuicoes>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public Usuarios_AtribuicoesDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Usuarios_Atribuicoes obj)
        {
            string create = "insert into Usuarios_Atribuicoes values('" + obj.ID + "','" + obj.IDUsuario + "','" + obj.IDPagina + "','" + obj.Cod_Atribuicao + "','" + obj.Nivel + "','" + obj.Atribuicao + "','" + obj.DataIni + "','" + obj.DataFim + "','" + obj.HoraIni + "','" + obj.HoraFim + "','" + obj.Ativo + "')";
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

        public void delete(Usuarios_Atribuicoes obj)
        {
            string delete = "delete from Usuarios_Atribuicoes where id ='" + obj.ID + "'";
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

        public bool find(Usuarios_Atribuicoes obj)
        {
            bool temRegistros;
            string find = "select*from Usuarios_Atribuicoes where id='" + obj.ID + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IDUsuario =Convert.ToInt32( reader["IDUsuário"].ToString());
                    obj.IDPagina = Convert.ToInt32(reader["IDPágina"].ToString());
                    obj.Cod_Atribuicao = Convert.ToInt32(reader["Cod_Atribuição"].ToString());
                    obj.Nivel = reader["Nível"].ToString();
                    obj.Atribuicao = reader["Atribuição"].ToString();
                    obj.DataIni =Convert.ToDateTime( reader["DataIni"].ToString());
                    obj.DataFim = Convert.ToDateTime(reader["DataFim"].ToString());
                    obj.HoraIni = reader["HoraIni"].ToString();
                    obj.HoraFim = reader["HoraFim"].ToString();
                    //         obj.Estados = 0;
                    obj.Ativo = Convert.ToInt32(reader["Ativo"].ToString());

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

        public List<Usuarios_Atribuicoes> findAll()
        {
            List<Usuarios_Atribuicoes> listaUsuarios_Atribuicoes = new List<Usuarios_Atribuicoes>();
            string find = "select*from Usuarios_Atribuicoes order by NomeFantasia asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Usuarios_Atribuicoes obj = new Usuarios_Atribuicoes();
                    obj.ID = Convert.ToInt32(reader["Id"].ToString());
                    obj.IDUsuario = Convert.ToInt32(reader["IDUsuário"].ToString());
                    obj.IDPagina = Convert.ToInt32(reader["IDPágina"].ToString());
                    obj.Cod_Atribuicao = Convert.ToInt32(reader["Cod_Atribuição"].ToString());
                    obj.Nivel = reader["Nível"].ToString();
                    obj.Atribuicao = reader["Atribuição"].ToString();
                    obj.DataIni = Convert.ToDateTime(reader["DataIni"].ToString());
                    obj.DataFim = Convert.ToDateTime(reader["DataFim"].ToString());
                    obj.HoraIni = reader["HoraIni"].ToString();
                    obj.HoraFim = reader["HoraFim"].ToString();
                    //         obj.Estados = 0;
                    obj.Ativo = Convert.ToInt32(reader["Ativo"].ToString());
                    listaUsuarios_Atribuicoes.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Usuarios_Atribuicoes obj2 = new Usuarios_Atribuicoes();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaUsuarios_Atribuicoes;
        }

        public void update(Usuarios_Atribuicoes obj)
        {
            string update = "update Usuarios_Atribuicoes set IDUsuario='" + obj.IDUsuario + "',IDPagina='" + obj.IDPagina + "',Cod_Atribuicao='" + obj.Cod_Atribuicao + "',Nivel='" + obj.Nivel + "',Atribuicao='" + obj.Atribuicao + "',DataIni='" + obj.DataIni + "',DataFim='" + obj.DataFim + "',HoraIni='" + obj.HoraIni + "',HoraFim='" + obj.HoraFim + "',Ativo='" + obj.Ativo + "' where id='" + obj.ID + "'";
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

        public bool findUsuarios_AtribuicoesPorId(Usuarios_Atribuicoes obj)
        {
            bool temRegistros;
                        string find = "select*from Usuarios_Atribuicoes where Id= '"+ obj.ID + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IDUsuario = Convert.ToInt32(reader["IDUsuário"].ToString());
                    obj.IDPagina = Convert.ToInt32(reader["IDPágina"].ToString());
                    obj.Cod_Atribuicao = Convert.ToInt32(reader["Cod_Atribuição"].ToString());
                    obj.Nivel = reader["Nível"].ToString();
                    obj.Atribuicao = reader["Atribuição"].ToString();
                    obj.DataIni = Convert.ToDateTime(reader["DataIni"].ToString());
                    obj.DataFim = Convert.ToDateTime(reader["DataFim"].ToString());
                    obj.HoraIni = reader["HoraIni"].ToString();
                    obj.HoraFim = reader["HoraFim"].ToString();
                    //         obj.Estados = 0;
                    obj.Ativo = Convert.ToInt32(reader["Ativo"].ToString());

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

        public List<Usuarios_Atribuicoes> findAllUsuarios_Atribuicoes(Usuarios_Atribuicoes objUsuarios_Atribuicoes)
        {
            List<Usuarios_Atribuicoes> listaUsuarios_Atribuicoes = new List<Usuarios_Atribuicoes>();
            string findAll = "select* from Usuarios_Atribuicoes where Nivel like '%" + objUsuarios_Atribuicoes.Nivel + "%' or Atribuicao like '%" + objUsuarios_Atribuicoes.Atribuicao + "%' or HoraIni like '%" + objUsuarios_Atribuicoes.HoraIni + "%' or HoraFim like '%" + objUsuarios_Atribuicoes.HoraFim + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Usuarios_Atribuicoes obj = new Usuarios_Atribuicoes();
                    obj.IDUsuario = Convert.ToInt32(reader["IDUsuário"].ToString());
                    obj.IDPagina = Convert.ToInt32(reader["IDPágina"].ToString());
                    obj.Cod_Atribuicao = Convert.ToInt32(reader["Cod_Atribuição"].ToString());
                    obj.Nivel = reader["Nível"].ToString();
                    obj.Atribuicao = reader["Atribuição"].ToString();
                    obj.DataIni = Convert.ToDateTime(reader["DataIni"].ToString());
                    obj.DataFim = Convert.ToDateTime(reader["DataFim"].ToString());
                    obj.HoraIni = reader["HoraIni"].ToString();
                    obj.HoraFim = reader["HoraFim"].ToString();
                    //         obj.Estados = 0;
                    obj.Ativo = Convert.ToInt32(reader["Ativo"].ToString());
                    listaUsuarios_Atribuicoes.Add(obj);

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

            return listaUsuarios_Atribuicoes;

        }

    }
}
