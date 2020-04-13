using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class ClientesDao : Obrigatorio<Clientes>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public ClientesDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Clientes obj)
        {
            string create = "insert into clientes values('" + obj.Id + "','" + obj.NomeFantasia + "','" + obj.RazaoSocial + "','" + obj.CNPJ + "','" + obj.IE + "','" + obj.Endereco + "','" + obj.Bairro + "','" + obj.Cidade + "','" + obj.CEP + "','" + obj.Estado + "','" + obj.HomePage + "','" + obj.Fone1 + "','" + obj.Fone2 + "','" + obj.Fone3 + "','" + obj.Fone4 + "','" + DateTime.Now.ToString() + "','" + "0" + "','" + obj.EmailEmp + "','" + obj.EmailSis + "','" + "0" + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
             //   obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void delete(Clientes obj)
        {
            string delete = "delete from clientes where id ='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
             //   obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool find(Clientes obj) 
        {
            bool temRegistros;
            string find = "select*from clientes where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.N_Cliente = reader["N_Cliente"].ToString();
                    obj.NomeFantasia = reader["NomeFantasia"].ToString();
                    obj.RazaoSocial = reader["RazaoSocial"].ToString();
                    obj.CNPJ = reader["CNPJ"].ToString();
                    obj.IE = reader["IE"].ToString();
                    obj.Endereco = reader["Endereco"].ToString();
                    obj.Bairro = reader["Bairro"].ToString();
                    obj.Cidade = reader["Cidade"].ToString();
           //         obj.Estados = 0;
                    obj.CEP = reader["CEP"].ToString();
                    obj.Estado = reader["Estado"].ToString();
                    obj.HomePage = reader["HomePage"].ToString();
                    obj.Fone1 = reader["Fone1"].ToString();
                    obj.Fone2 = reader["Fone2"].ToString();
                    obj.Fone3 = reader["Fone3"].ToString();
                    obj.Fone4 = reader["Fone4"].ToString();
                    obj.DataCadastro = reader["DataCadastro"].ToString();
                    obj.IdUsuario = reader["IdUsuario"].ToString();
                    obj.EmailEmp = reader["EmailEmp"].ToString();
                    obj.EmailSis = reader["EmailSis"].ToString();
                    obj.Aplicar = reader["Aplicar"].ToString();


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

        public List<Clientes> findAll()
        {
            List<Clientes> listaClientes = new List<Clientes>();
            string find = "select*from clientes order by NomeFantasia asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Clientes obj = new Clientes();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.N_Cliente = reader["N_Cliente"].ToString();
                    obj.NomeFantasia = reader["NomeFantasia"].ToString();
                    obj.RazaoSocial = reader["RazaoSocial"].ToString();
                    obj.CNPJ = reader["CNPJ"].ToString();
                    obj.IE = reader["IE"].ToString();
                    obj.Endereco = reader["Endereco"].ToString();
                    obj.Bairro = reader["Bairro"].ToString();
                    obj.Cidade = reader["Cidade"].ToString();
                    //         obj.Estados = 0;
                    obj.CEP = reader["CEP"].ToString();
                    obj.Estado = reader["Estado"].ToString();
                    obj.HomePage = reader["HomePage"].ToString();
                    obj.Fone1 = reader["Fone1"].ToString();
                    obj.Fone2 = reader["Fone2"].ToString();
                    obj.Fone3 = reader["Fone3"].ToString();
                    obj.Fone4 = reader["Fone4"].ToString();
                    obj.DataCadastro = reader["DataCadastro"].ToString();
                    obj.IdUsuario = reader["IdUsuario"].ToString();
                    obj.EmailEmp = reader["EmailEmp"].ToString();
                    obj.EmailSis = reader["EmailSis"].ToString();
                    obj.Aplicar = reader["Aplicar"].ToString();
                    listaClientes.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Clientes obj2 = new Clientes();
               // obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaClientes;
        }

        public void update(Clientes obj)
        {
            string update = "update clientes set N_Cliente='" + obj.N_Cliente + "',NomeFantasia='" + obj.NomeFantasia + "',RazaoSocial='" + obj.RazaoSocial + "',CNPJ='" + obj.CNPJ + "',Endereco='" + obj.Endereco + "',Bairro='" + obj.Bairro + "',Cidade='" + obj.Cidade + "',CEP='" + obj.CEP + "',Estado='" + obj.Estado + "',HomePage='" + obj.HomePage + "',Fone1='" + obj.Fone1 + "',Fone2='" + obj.Fone2 + "',Fone3='" + obj.Fone3 + "',Fone4='" + obj.Fone4 + "',IdUsuario='" + obj.IdUsuario + "',EmailEmp='" + obj.EmailEmp + "',Aplicar='" + obj.Aplicar + "' where id='" + obj.Id + "'  where Id = '" + obj.Id + "' ";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
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

        public bool findClientePorcnpj(Clientes obj)
        {
            bool temRegistros;
            string find = "select*from clientes where cnpj='" + obj.CNPJ + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.N_Cliente = reader["N_Cliente"].ToString();
                    obj.NomeFantasia = reader["NomeFantasia"].ToString();
                    obj.RazaoSocial = reader["RazãoSocial"].ToString();
                    obj.CNPJ = reader["CNPJ"].ToString();
                    obj.IE = reader["IE"].ToString();
                    obj.Endereco = reader["Endereço"].ToString();
                    obj.Bairro = reader["Bairro"].ToString();
                    obj.Cidade = reader["Cidade"].ToString();
                    //         obj.Estados = 0;
                    obj.CEP = reader["CEP"].ToString();
                    obj.Estado = reader["Estado"].ToString();
                    obj.HomePage = reader["HomePage"].ToString();
                    obj.Fone1 = reader["Fone1"].ToString();
                    obj.Fone2 = reader["Fone2"].ToString();
                    obj.Fone3 = reader["Fone3"].ToString();
                    obj.Fone4 = reader["Fone4"].ToString();
                    obj.DataCadastro = reader["DataCadastro"].ToString();
                    obj.IdUsuario = reader["IdUsuário"].ToString();
                    obj.EmailEmp = reader["EmailEmp"].ToString();
                    obj.EmailSis = reader["EmailSis"].ToString();
                    obj.Aplicar = reader["Aplicar Social"].ToString();

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

        public List<Clientes> findAllCliente(Clientes objCLiente)
        {
            List<Clientes> listaClientes = new List<Clientes>();
            string findAll = "select* from clientes where razaosocial like '%" + objCLiente.RazaoSocial + "%' or anpj like '%" + objCLiente.CNPJ + "%' or NomeFantasia like '%" + objCLiente.NomeFantasia + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Clientes obj = new Clientes();
                    obj.N_Cliente = reader["N_Cliente"].ToString();
                    obj.NomeFantasia = reader["NomeFantasia"].ToString();
                    obj.RazaoSocial = reader["RazãoSocial"].ToString();
                    obj.CNPJ = reader["CNPJ"].ToString();
                    obj.IE = reader["IE"].ToString();
                    obj.Endereco = reader["Endereço"].ToString();
                    obj.Bairro = reader["Bairro"].ToString();
                    obj.Cidade = reader["Cidade"].ToString();
                    //         obj.Estados = 0;
                    obj.CEP = reader["CEP"].ToString();
                    obj.Estado = reader["Estado"].ToString();
                    obj.HomePage = reader["HomePage"].ToString();
                    obj.Fone1 = reader["Fone1"].ToString();
                    obj.Fone2 = reader["Fone2"].ToString();
                    obj.Fone3 = reader["Fone3"].ToString();
                    obj.Fone4 = reader["Fone4"].ToString();
                    obj.DataCadastro = reader["DataCadastro"].ToString();
                    obj.IdUsuario = reader["IdUsuário"].ToString();
                    obj.EmailEmp = reader["EmailEmp"].ToString();
                    obj.EmailSis = reader["EmailSis"].ToString();
                    obj.Aplicar = reader["Aplicar Social"].ToString();
                    listaClientes.Add(obj);

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

            return listaClientes;

        }
    }
}
