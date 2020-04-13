using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class LicencasDao : Obrigatorio<Licencas>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public LicencasDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Licencas obj)
        {
            string create = "insert into Licencas values('" + obj.Id + "','" + obj.IdCliente + "','" + obj.Licenca + "','" + obj.Orgao + "','" + obj.Numero + "','" + obj.Emissao + "','" + obj.Validade + "','" + obj.Finalidade + "','" + obj.Requisito + "','" + obj.Obs + "','" + obj.Prazo + "','" + obj.Condicionante + "')";
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

        public void delete(Licencas obj)
        {
            string delete = "delete from Licencas where id ='" + obj.Id + "'";
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

        public bool find(Licencas obj)
        {
            bool temRegistros;
            string find = "select*from Licencas where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IdCliente =Convert.ToInt32( reader["IdCliente"].ToString());
                    obj.Licenca = reader["Licença"].ToString();
                    obj.Orgao = reader["Órgão"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Emissao =Convert.ToDateTime (reader["Emissão"].ToString());
                    obj.Validade =Convert.ToDateTime( reader["Validade"].ToString());
                    obj.Finalidade = reader["Finalidade"].ToString();
                    obj.Requisito = reader["Requisito"].ToString();
                    obj.Obs = reader["Obs"].ToString();
                    //         obj.Estados = 0;
                    obj.Prazo =Convert.ToInt32( reader["Prazo"].ToString());
                    obj.Condicionante =Convert.ToInt32( reader["Condicionante"].ToString());

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

        public List<Licencas> findAll()
        {
            List<Licencas> listaLicencas = new List<Licencas>();
            string find = "select*from Licencas order by IdCliente asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Licencas obj = new Licencas();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.IdCliente =Convert.ToInt32( reader["IdCliente"].ToString());
                    obj.Licenca = reader["Licenca"].ToString();
                    obj.Orgao = reader["Orgao"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Emissao =Convert.ToDateTime (reader["Emissao"].ToString());
                    obj.Validade =Convert.ToDateTime( reader["Validade"].ToString());
                    obj.Finalidade = reader["Finalidade"].ToString();
                    obj.Requisito = reader["Requisito"].ToString();
                    obj.Obs = reader["Obs"].ToString();
                    //      obj.Estado = Convert.ToInt32(reader["Estado"].ToString());
                    //     obj.Estados = reader["Estados"].ToString();
                    obj.Prazo =Convert.ToInt32( reader["Prazo"].ToString());
                    obj.Condicionante =Convert.ToInt32( reader["Condicionante"].ToString());
                    listaLicencas.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Licencas obj2 = new Licencas();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLicencas;
        }

        public void update(Licencas obj)
        {
            string update = "update Licencas set IdCliente='" + obj.IdCliente + "',Licenca='" + obj.Licenca + "',Orgao='" + obj.Orgao + "',Numero='" + obj.Numero + "',Emissao='" + obj.Emissao + "',Validade='" + obj.Validade + "',Finalidade='" + obj.Finalidade + "',Requisito='" + obj.Requisito + "',Obs='" + obj.Obs + "',Prazo='" + obj.Prazo + "',Condicionante='" + obj.Condicionante + "'  where Id = '" + obj.Id + "' ";
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

        public bool findClientePorId(Licencas obj)
        {
            bool temRegistros;
            string find = "select*from Licencas where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IdCliente =Convert.ToInt32( reader["IdCliente"].ToString());
                    obj.Licenca = reader["Licenca"].ToString();
                    obj.Orgao = reader["Orgao"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Emissao =Convert.ToDateTime (reader["Emissao"].ToString());
                    obj.Validade =Convert.ToDateTime( reader["Validade"].ToString());
                    obj.Finalidade = reader["Finalidade"].ToString();
                    obj.Requisito = reader["Requisito"].ToString();
                    obj.Obs = reader["Obs"].ToString();
                    //  obj.Estados = Convert.ToInt32(reader["Estados"].ToString());
                    obj.Prazo =Convert.ToInt32( reader["Prazo"].ToString());
                    obj.Condicionante =Convert.ToInt32( reader["Condicionante"].ToString());

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

        public List<Licencas> findAllLicencas(Licencas objLicencas)
        {
            List<Licencas> listaLicencas = new List<Licencas>();
            string findAll = "select* from Licencas where licensa like '%" + objLicencas.Licenca + "%' or Orgao like '%" + objLicencas.Orgao + "%' or Numero like '%" + objLicencas.Numero + "%' or Finalidade like '%" + objLicencas.Finalidade + "%' or Requisito like '%" + objLicencas.Requisito + "%' or Obs like '%" + objLicencas.Obs + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Licencas obj = new Licencas();
                    obj.IdCliente =Convert.ToInt32 (reader["Aplicar"].ToString());
                    obj.Licenca = reader["Bairro"].ToString();
                    obj.Orgao = reader["CEP"].ToString();
                    obj.Numero = reader["Cidade"].ToString();
                    obj.Emissao =Convert.ToDateTime( reader["CNPJ"].ToString());
                    obj.Validade =Convert.ToDateTime( reader["DataCadastro"].ToString());
                    obj.Finalidade = reader["EmailEmp"].ToString();
                    obj.Requisito = reader["EmailSis"].ToString();
                    obj.Obs = reader["Endereco"].ToString();
                    // obj.Estados = Convert.ToInt32(reader["Estado"].ToString());
                    obj.Prazo =Convert.ToInt32( reader["Estados"].ToString());
                    obj.Condicionante =Convert.ToInt32( reader["Fone1"].ToString());
                    listaLicencas.Add(obj);

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

            return listaLicencas;

        }

    }
}
