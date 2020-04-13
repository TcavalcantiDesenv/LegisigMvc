using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class AtividadesDao : Obrigatorio<Atividades>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public AtividadesDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Atividades obj)
        {
            string create = "insert into Atividades values('" + obj.Id + "','" + obj.ProcessoId + "','" + obj.Descricao + "')";
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

        public void delete(Atividades obj)
        {
            string delete = "delete from Atividades where id ='" + obj.Id + "'";
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

        public bool find(Atividades obj)
        {
            bool temRegistros;
            string find = "select*from Atividades where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.ProcessoId =Convert.ToInt32( reader["ProcessoId"].ToString());
                    obj.Descricao = reader["Descricao"].ToString();


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

        public List<Atividades> findAll()
        {
            List<Atividades> listaAtividades = new List<Atividades>();
            string find = "select*from Atividades order by id asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Atividades obj = new Atividades();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.ProcessoId = Convert.ToInt32(reader["ProcessoId"].ToString());
                    obj.Descricao = reader["Descricao"].ToString();
                    listaAtividades.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Atividades obj2 = new Atividades();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaAtividades;
        }

        public void update(Atividades obj)
        {
            string update = "update Atividades set ProcessoId='" + obj.ProcessoId + "',Descricao='" + obj.Descricao + "' where id='" + obj.Id + "'  where Id = '" + obj.Id + "' ";
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

        public bool findAtividadesPorId(Atividades obj)
        {
            bool temRegistros;
            string find = "select*from Atividades where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.ProcessoId = Convert.ToInt32(reader["ProcessoId"].ToString());
                    obj.Descricao = reader["Descricao"].ToString();

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

        public List<Atividades> findAllAtividades(Atividades objAtividades)
        {
            List<Atividades> listaAtividades = new List<Atividades>();
            string findAll = "select* from Atividades where Descricao like '%" + objAtividades.Descricao + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Atividades obj = new Atividades();
                    obj.ProcessoId = Convert.ToInt32(reader["ProcessoId"].ToString());
                    obj.Descricao = reader["Descricao"].ToString();
                    listaAtividades.Add(obj);

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

            return listaAtividades;

        }

    }
}
