using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class ParametrosDao : Obrigatorio<Parametros>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public ParametrosDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Parametros obj)
        {
            string create = "insert into Parametros values('" + obj.Id + "','" + obj.Capitulo + "','" + obj.Item + "','" + obj.Parametro + "','" + obj.Obrigacao + "','" + obj.IDLegisGeral + "','" + obj.IDCliente + "','" + obj.Numero + "','" + obj.Aplicavel + "','" + obj.lei + "','" + obj.param + "','" + obj.Conhecimento + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
        //        // obj.Estados  = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void delete(Parametros obj)
        {
            string delete = "delete from Parametros where id ='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
           //     // obj.Estados  = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool find1(Parametros obj)
        {
            bool temRegistros;
            string find = "select*from Parametros where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Capitulo = reader["Capitulo"].ToString();
                    obj.Item = reader["Item"].ToString();
                    //obj.Parametro = reader["Parametro"].ToString();
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.IDCliente = reader["IDCliente"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    //         // obj.Estados  = 0;
                    obj.lei = reader["lei"].ToString();
                    obj.param = reader["Parametro"].ToString();
                    obj.Conhecimento = reader["Conhecimento"].ToString();

              //      // obj.Estados  = 99;
                }
                else
                {
             //       // obj.Estados  = 1;
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

        public List<Parametros> find(Parametros obj1)
        {
            List<Parametros> listaParametros = new List<Parametros>();
            string find = "SELECT * FROM Parametros WHERE IDLegisGeral ='" + obj1.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Parametros obj = new Parametros();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Capitulo = reader["Capitulo"].ToString();
                    obj.Item = reader["Item"].ToString();
                    //obj.Parametro = reader["Parametro"].ToString();
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.IDCliente = reader["IDCliente"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    //         // obj.Estados  = 0;
                    obj.lei = reader["lei"].ToString();
                    obj.param = reader["param"].ToString();
                    obj.Conhecimento = reader["Conhecimento"].ToString();

                    listaParametros.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Parametros obj2 = new Parametros();
             //   obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaParametros;
        }

        public List<Parametros> findAll()
        {
            List<Parametros> listaParametros = new List<Parametros>();
            string find = "select*from Parametros order by Capitulo asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Parametros obj = new Parametros();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Capitulo = reader["Capitulo"].ToString();
                    obj.Item = reader["Item"].ToString();
                    //obj.Parametro = reader["Parametro"].ToString();
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.IDCliente = reader["IDCliente"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    //         // obj.Estados  = 0;
                    obj.lei = reader["lei"].ToString();
                    obj.param = reader["param"].ToString();
                    obj.Conhecimento = reader["Conhecimento"].ToString();


                    listaParametros.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Parametros obj2 = new Parametros();
             //   obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaParametros;
        }

        public void update(Parametros obj)
        {
            string update = "update Parametros set Capitulo='" + obj.Capitulo + "',Item='" + obj.Item + "',Parametro='" + obj.Parametro + "',Obrigacao='" + obj.Obrigacao + "',IDLegisGeral='" + obj.IDLegisGeral + "',IDCliente='" + obj.IDCliente + "',Numero='" + obj.Numero + "',Aplicavel='" + obj.Aplicavel + "',lei='" + obj.lei + "',param='" + obj.param + "',Conhecimento='" + obj.Conhecimento + "'  where Id = '" + obj.Id + "' ";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                // obj.Estados  = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool findParametrosPorId(Parametros obj)
        {
            bool temRegistros;
            string find = "select*from Parametros where Id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Capitulo = reader["Capitulo"].ToString();
                    obj.Item = reader["Item"].ToString();
                    //obj.Parametro = reader["Parametro"].ToString();
                    obj.Capitulo = reader["Capitulo"].ToString();
                    obj.Item = reader["Item"].ToString();
                    //obj.Parametro = reader["Parametro"].ToString();
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.IDCliente = reader["IDCliente"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    //         // obj.Estados  = 0;
                    obj.lei = reader["lei"].ToString();
                    obj.param = reader["Parametro"].ToString();
                    obj.Conhecimento = reader["Conhecimento"].ToString();

                    // obj.Estados  = 99;

                }
                else
                {
                    // obj.Estados  = 1;
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

        public List<Parametros> FindAllParametros(Parametros objParametros)
        {
            List<Parametros> listaParametros = new List<Parametros>();
            string findAll = "select* from Parametros where Capitulo like '%" + objParametros.Capitulo + "%' or Item like '%" + objParametros.Item + "%' or lei like '%" + objParametros.lei + "%'or param like '%" + objParametros.param + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Parametros obj = new Parametros();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Capitulo = reader["Capitulo"].ToString();
                    obj.Item = reader["Item"].ToString();
                    //obj.Parametro = reader["Parametro"].ToString();
                    obj.Capitulo = reader["Capitulo"].ToString();
                    obj.Item = reader["Item"].ToString();
                    //obj.Parametro = reader["Parametro"].ToString();
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.IDCliente = reader["IDCliente"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    //         // obj.Estados  = 0;
                    obj.lei = reader["lei"].ToString();
                    obj.param = reader["Parametro"].ToString();
                    obj.Conhecimento = reader["Conhecimento"].ToString();

                    listaParametros.Add(obj);

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

            return listaParametros;

        }

        bool Obrigatorio<Parametros>.find(Parametros obj)
        {
            throw new NotImplementedException();
        }
    }
}
