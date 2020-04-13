using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class ClientesADMDao : Obrigatorio<ClientesADMDao>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public ClientesADMDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(ClientesADM obj)
        {
            string create = "insert into ClientesADM values('" + obj.Id + "','" + obj.N_Cliente + "','" + obj.IdUsuario + "','" + obj.NomeFantasia + "','" + obj.RazaoSocial + "','" + obj.CNPJ + "','" + obj.IE + "','" + obj.Endereco + "','" + obj.Bairro + "','" + obj.Cidade + "','" + obj.CEP + "','" + obj.Estado + "','" + obj.HomePage + "','" + obj.Fone1 + "','" + obj.Fone2 + "','" + obj.Fone3 + "','" + obj.Fone4 + "','" + obj.DataCadastro + "')";
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

        public void delete(ClientesADM obj)
        {
            string delete = "delete from ClientesADM where id ='" + obj.Id + "'";
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

        public bool find(ClientesADM obj)
        {
            bool temRegistros;
            string find = "select*from ClientesADM where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.N_Cliente =Convert.ToInt32 (reader["N_Cliente"].ToString());
                    obj.IdUsuario = Convert.ToInt32(reader["IdUsuario"].ToString());
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

        public List<ClientesADM> findAll()
        {
            List<ClientesADM> listaClientesADM = new List<ClientesADM>();
            string find = "select*from ClientesADM order by NomeFantasia asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ClientesADM obj = new ClientesADM();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.N_Cliente = Convert.ToInt32(reader["N_Cliente"].ToString());
                    obj.IdUsuario = Convert.ToInt32(reader["IdUsuario"].ToString());
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
                    listaClientesADM.Add(obj);
                }

            }
            catch (Exception ex)
            {
                ClientesADM obj2 = new ClientesADM();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaClientesADM;
        }

        public void update(ClientesADM obj)
        {
            string update = "update ClientesADM set N_Cliente='" + obj.N_Cliente + "',IdUsuario='" + obj.IdUsuario + "',NomeFantasia='" + obj.NomeFantasia + "',RazaoSocial='" + obj.RazaoSocial + "',CNPJ='" + obj.CNPJ + "',IE='" + obj.IE + "',Endereco='" + obj.Endereco + "',Bairro='" + obj.Bairro + "',Cidade='" + obj.Cidade + "',CEP='" + obj.CEP + "',Estado='" + obj.Estado + "',HomePage='" + obj.HomePage + "',Fone1='" + obj.Fone1 + "',Fone2='" + obj.Fone2 + "',Fone3='" + obj.Fone3 + "',Fone4='" + obj.Fone4 + "',DataCadastro='" + obj.DataCadastro + "'  where Id = '" + obj.Id + "' ";
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

        public bool findClientePorId(ClientesADM obj)
        {
            bool temRegistros;
            string find = "select*from ClientesADM where Id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.N_Cliente = Convert.ToInt32(reader["N_Cliente"].ToString());
                    obj.IdUsuario = Convert.ToInt32(reader["IdUsuario"].ToString());
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

        public List<ClientesADM> findAllCliente(ClientesADM objClientesADM)
        {
            List<ClientesADM> listaClientesADM = new List<ClientesADM>();
            string findAll = "select* from ClientesADM where NomeFantasia like '%" + objClientesADM.NomeFantasia + "%' or RazaoSocial like '%" + objClientesADM.RazaoSocial + "%' or CNPJ like '%" + objClientesADM.CNPJ + "%' or IE like '%" + objClientesADM.IE + "%' or Endereco like '%" + objClientesADM.Endereco + "%' or Bairro like '%" + objClientesADM.Bairro + "%' or Cidade like '%" + objClientesADM.Cidade + "%' or CEP like '%" + objClientesADM.CEP + "%' or Estado like '%" + objClientesADM.Estado + "%' or HomePage like '%" + objClientesADM.HomePage + "%' or Fone1 like '%" + objClientesADM.Fone1 + "%' or Fone2 like '%" + objClientesADM.Fone2 + "%' or Fone3 like '%" + objClientesADM.Fone3 + "%' or Fone4 like '%" + objClientesADM.Fone4 + "%' or DataCadastro like '%" + objClientesADM.DataCadastro + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ClientesADM obj = new ClientesADM();
                    obj.N_Cliente = Convert.ToInt32(reader["N_Cliente"].ToString());
                    obj.IdUsuario = Convert.ToInt32(reader["IdUsuario"].ToString());
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
                    listaClientesADM.Add(obj);

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

            return listaClientesADM;

        }

        public void create(ClientesADMDao obj)
        {
            throw new NotImplementedException();
        }

        public void delete(ClientesADMDao obj)
        {
            throw new NotImplementedException();
        }

        public void update(ClientesADMDao obj)
        {
            throw new NotImplementedException();
        }

        public bool find(ClientesADMDao obj)
        {
            throw new NotImplementedException();
        }

        List<ClientesADMDao> Obrigatorio<ClientesADMDao>.findAll()
        {
            throw new NotImplementedException();
        }
    }
}
