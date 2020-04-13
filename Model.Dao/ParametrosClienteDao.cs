using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class ParametrosClienteDao : Obrigatorio<ParametrosCliente>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public ParametrosClienteDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(ParametrosCliente obj)
        {
            string create = "insert into ParametrosCliente values('" + obj.Id + "','" + obj.Capitulo + "','" + obj.Item + "','" + obj.Parametro + "','" + obj.Obrigacao + "','" + obj.IDLegisGeral + "','" + obj.IDCliente + "','" + obj.Numero + "','" + obj.Aplicavel + "','" + obj.Conhecimento + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
               // obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void delete(ParametrosCliente obj)
        {
            string delete = "delete from ParametrosCliente where id ='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
              //  obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool find(ParametrosCliente obj)
        {
            bool temRegistros;
            string find = "select*from ParametrosClientes where IDCliente = 2098 and IDLegisGeral = 41 where id='" + obj.Id + "'";
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
                    obj.Parametro = reader["Parametro"].ToString();
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.IDLegisGeral =Convert.ToInt32( reader["IDLegisGeral"].ToString());
                    obj.IDCliente =Convert.ToInt32( reader["IDCliente"].ToString());
                    obj.Numero =Convert.ToInt32( reader["Numero"].ToString());
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    obj.Conhecimento = reader["Conhecimento"].ToString();

                  //  obj.Estados = 99;
                }
                else
                {
                 //   obj.Estados = 1;
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

        public List<ParametrosCliente> buscarPorLeiCliente(string cliente, string lei)
        {
            List<ParametrosCliente> listaParametrosCliente = new List<ParametrosCliente>();
            string find = "select*from ParametrosClientes where IDCliente = '" + cliente + "' and IDLegisGeral = '" + lei + "' ";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ParametrosCliente obj = new ParametrosCliente();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Capitulo = reader["Capitulo"].ToString();
                    obj.Item = reader["item"].ToString();
                    obj.Parametro = reader["Parametro"].ToString();
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.Numero = Convert.ToInt32(reader["Numero"].ToString());
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    obj.Conhecimento = reader["Conhecimento"].ToString();
                    listaParametrosCliente.Add(obj);
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

            return listaParametrosCliente;
        }
        public List<ParametrosCliente> buscarPorID(string Id)
        {
            List<ParametrosCliente> listaParametrosCliente = new List<ParametrosCliente>();
            string find = "select*from ParametrosClientes where Id = '" + Id + "' ";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ParametrosCliente obj = new ParametrosCliente();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Capitulo = reader["Capitulo"].ToString();
                    obj.Item = reader["item"].ToString();
                    obj.Parametro = reader["Parametro"].ToString();
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.Numero = Convert.ToInt32(reader["Numero"].ToString());
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    obj.Conhecimento = reader["Conhecimento"].ToString();
                    listaParametrosCliente.Add(obj);
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

            return listaParametrosCliente;
        }

        public List<ParametrosCliente> findAll()
        {
            List<ParametrosCliente> listaParametrosCliente = new List<ParametrosCliente>();
            string find = "select*from ParametrosCliente order by Id asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ParametrosCliente obj = new ParametrosCliente();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.Capitulo = reader["Capitulo"].ToString();
                    obj.Item = reader["Item"].ToString();
                    obj.Parametro = reader["Parametro"].ToString();
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.Numero = Convert.ToInt32(reader["Numero"].ToString());
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    obj.Conhecimento = reader["Conhecimento"].ToString();
                    listaParametrosCliente.Add(obj);
                }

            }
            catch (Exception ex)
            {
                ParametrosCliente obj2 = new ParametrosCliente();
              //  obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaParametrosCliente;
        }

        public void update(ParametrosCliente obj)
        {
            string update = "update ParametrosCliente set Capitulo='" + obj.Capitulo + "',Item='" + obj.Item + "',Parametro='" + obj.Parametro + "',Obrigacao='" + obj.Obrigacao + "',IDLegisGeral='" + obj.IDLegisGeral + "',IDCliente='" + obj.IDCliente + "',Numero='" + obj.Numero + "',Aplicavel='" + obj.Aplicavel + "',Conhecimento='" + obj.Conhecimento + "' where Id ='" + obj.Id + "' ";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                //obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool findParametrosClientePorId(ParametrosCliente obj)
        {
            bool temRegistros;
            string find = "select*from ParametrosCliente where Id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Capitulo = reader["Capitulo"].ToString();
                    obj.Item = reader["Item"].ToString();
                    obj.Parametro = reader["Parametro"].ToString();
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.Numero = Convert.ToInt32(reader["Numero"].ToString());
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    obj.Conhecimento = reader["Conhecimento"].ToString();

                  //  obj.Estados = 99;

                }
                else
                {
                  //  obj.Estados = 1;
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

        public List<ParametrosCliente> findAllParametrosCliente(ParametrosCliente objCLiente)
        {
            List<ParametrosCliente> listaParametrosCliente = new List<ParametrosCliente>();
            string findAll = "select* from ParametrosCliente where Capitulo like '%" + objCLiente.Capitulo + "%' or Item like '%" + objCLiente.Item + "%' or Parametro like '%" + objCLiente.Parametro + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ParametrosCliente obj = new ParametrosCliente();
                    obj.Capitulo = reader["Capitulo"].ToString();
                    obj.Item = reader["Item"].ToString();
                    obj.Parametro = reader["Parametro"].ToString();
                    obj.Obrigacao = reader["Obrigacao"].ToString();
                    obj.IDLegisGeral = Convert.ToInt32(reader["IDLegisGeral"].ToString());
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.Numero = Convert.ToInt32(reader["Numero"].ToString());
                    obj.Aplicavel = reader["Aplicavel"].ToString();
                    obj.Conhecimento = reader["Conhecimento"].ToString();
                    listaParametrosCliente.Add(obj);

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

            return listaParametrosCliente;

        }
    }
}
