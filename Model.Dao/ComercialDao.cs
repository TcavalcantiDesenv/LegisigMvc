using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class ComercialDao : Obrigatorio<Atribuicoes>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public ComercialDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Comercial obj)
        {
            string create = "insert into Comercial values('" + obj.Id + "','" + obj.IDCliente + "','" + obj.IDProduto + "','" + obj.IDSubProduto + "','" + obj.Licenca + "','" + obj.AnaliseReqPresencial + "','" + obj.AnaliseReqOnLine + "','" + obj.Validacao_Presencial + "','" + obj.Validacao_OnLine + "','" + obj.Sem_Validacao + "','" + obj.Aspecto_Impacto + "','" + obj.Vinculo_Legis_AI + "','" + obj.Perigo_Risco + "','" + obj.Vinculo_Legis_PR + "','" + obj.Plano + "','" + obj.Valor + "','" + obj.Usuarios + "')";
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

        public void delete(Comercial obj)
        {
            string delete = "delete from Comercial where id ='" + obj.Id + "'";
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

        public bool find(Comercial obj)
        {
            bool temRegistros;
            string find = "select*from Comercial where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IDCliente =Convert.ToInt32 (reader["IDCliente"].ToString());
                    obj.IDProduto = Convert.ToInt32(reader["IDProduto"].ToString());
                    obj.IDSubProduto = Convert.ToInt32(reader["IDSubProduto"].ToString());
                    obj.Licenca = Convert.ToInt32(reader["Licença"].ToString());
                    obj.AnaliseReqPresencial = Convert.ToInt32(reader["AnáliseReqPresencial"].ToString());
                    obj.AnaliseReqOnLine = Convert.ToInt32(reader["AnáliseReqOnLine"].ToString());
                    obj.Validacao_Presencial = reader["Validação_Presencial"].ToString();
                    obj.Validacao_OnLine = reader["Validação_OnLine"].ToString();
                    obj.Sem_Validacao = Convert.ToInt32(reader["Sem_Validação"].ToString());
                    //         obj.Estados = 0;
                    obj.Aspecto_Impacto = Convert.ToInt32(reader["Aspecto_Impacto"].ToString());
                    obj.Vinculo_Legis_AI = Convert.ToInt32(reader["Vínculo_Legis_AI"].ToString());
                    obj.Perigo_Risco = Convert.ToInt32(reader["Perigo_Risco"].ToString());
                    obj.Vinculo_Legis_PR = Convert.ToInt32(reader["Vínculo_Legis_PR"].ToString());
                    obj.Plano = reader["Plano"].ToString();
                    obj.Valor = Convert.ToDecimal(reader["Valor"].ToString());
                    obj.Usuarios = Convert.ToInt32(reader["Usuários"].ToString());


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

        public List<Comercial> findAll()
        {
            List<Comercial> listaComercial = new List<Comercial>();
            string find = "select*from Comercial order by Id asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Comercial obj = new Comercial();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDProduto = Convert.ToInt32(reader["IDProduto"].ToString());
                    obj.IDSubProduto = Convert.ToInt32(reader["IDSubProduto"].ToString());
                    obj.Licenca = Convert.ToInt32(reader["Licença"].ToString());
                    obj.AnaliseReqPresencial = Convert.ToInt32(reader["AnáliseReqPresencial"].ToString());
                    obj.AnaliseReqOnLine = Convert.ToInt32(reader["AnáliseReqOnLine"].ToString());
                    obj.Validacao_Presencial = reader["Validação_Presencial"].ToString();
                    obj.Validacao_OnLine = reader["Validação_OnLine"].ToString();
                    obj.Sem_Validacao = Convert.ToInt32(reader["Sem_Validação"].ToString());
                    //         obj.Estados = 0;
                    obj.Aspecto_Impacto = Convert.ToInt32(reader["Aspecto_Impacto"].ToString());
                    obj.Vinculo_Legis_AI = Convert.ToInt32(reader["Vínculo_Legis_AI"].ToString());
                    obj.Perigo_Risco = Convert.ToInt32(reader["Perigo_Risco"].ToString());
                    obj.Vinculo_Legis_PR = Convert.ToInt32(reader["Vínculo_Legis_PR"].ToString());
                    obj.Plano = reader["Plano"].ToString();
                    obj.Valor = Convert.ToDecimal(reader["Valor"].ToString());
                    obj.Usuarios = Convert.ToInt32(reader["Usuários"].ToString());
                    listaComercial.Add(obj);
                }

            }
            catch (Exception ex)
            {
                Comercial obj2 = new Comercial();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaComercial;
        }

        public void update(Comercial obj)
        {
            string update = "update Comercial set Id='" + obj.Id + "',IDCliente='" + obj.IDCliente + "',IDProduto='" + obj.IDProduto + "',IDSubProduto='" + obj.IDSubProduto + "',Licenca='" + obj.Licenca + "',AnaliseReqPresencial='" + obj.AnaliseReqPresencial + "',AnaliseReqOnLine='" + obj.AnaliseReqOnLine + "',Validacao_Presencial='" + obj.Validacao_Presencial + "',Validacao_OnLine='" + obj.Validacao_OnLine + "',Sem_Validacao='" + obj.Sem_Validacao + "',Aspecto_Impacto='" + obj.Aspecto_Impacto + "',Vinculo_Legis_AI='" + obj.Vinculo_Legis_AI + "',Perigo_Risco='" + obj.Perigo_Risco + "',Vinculo_Legis_PR='" + obj.Vinculo_Legis_PR + "',Plano='" + obj.Plano + "',Valor='" + obj.Valor + "',Usuarios='" + obj.Usuarios + "' where id='" + obj.Id + "'  where Id = '" + obj.Id + "' ";
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

        public bool findComercialPorid(Comercial obj)
        {
            bool temRegistros;
            string find = "select*from Comercial where Id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDProduto = Convert.ToInt32(reader["IDProduto"].ToString());
                    obj.IDSubProduto = Convert.ToInt32(reader["IDSubProduto"].ToString());
                    obj.Licenca = Convert.ToInt32(reader["Licença"].ToString());
                    obj.AnaliseReqPresencial = Convert.ToInt32(reader["AnáliseReqPresencial"].ToString());
                    obj.AnaliseReqOnLine = Convert.ToInt32(reader["AnáliseReqOnLine"].ToString());
                    obj.Validacao_Presencial = reader["Validação_Presencial"].ToString();
                    obj.Validacao_OnLine = reader["Validação_OnLine"].ToString();
                    obj.Sem_Validacao = Convert.ToInt32(reader["Sem_Validação"].ToString());
                    //         obj.Estados = 0;
                    obj.Aspecto_Impacto = Convert.ToInt32(reader["Aspecto_Impacto"].ToString());
                    obj.Vinculo_Legis_AI = Convert.ToInt32(reader["Vínculo_Legis_AI"].ToString());
                    obj.Perigo_Risco = Convert.ToInt32(reader["Perigo_Risco"].ToString());
                    obj.Vinculo_Legis_PR = Convert.ToInt32(reader["Vínculo_Legis_PR"].ToString());
                    obj.Plano = reader["Plano"].ToString();
                    obj.Valor = Convert.ToDecimal(reader["Valor"].ToString());
                    obj.Usuarios = Convert.ToInt32(reader["Usuários"].ToString());

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

        public List<Comercial> findAllComercial(Comercial objComercial)
        {
            List<Comercial> listaComercial = new List<Comercial>();
            string findAll = "select* from Comercial where Validacao_Presencial like '%" + objComercial.Validacao_Presencial + "%' or Validacao_OnLine like '%" + objComercial.Validacao_OnLine + "%' or Plano like '%" + objComercial.Plano + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Comercial obj = new Comercial();
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDProduto = Convert.ToInt32(reader["IDProduto"].ToString());
                    obj.IDSubProduto = Convert.ToInt32(reader["IDSubProduto"].ToString());
                    obj.Licenca = Convert.ToInt32(reader["Licença"].ToString());
                    obj.AnaliseReqPresencial = Convert.ToInt32(reader["AnáliseReqPresencial"].ToString());
                    obj.AnaliseReqOnLine = Convert.ToInt32(reader["AnáliseReqOnLine"].ToString());
                    obj.Validacao_Presencial = reader["Validação_Presencial"].ToString();
                    obj.Validacao_OnLine = reader["Validação_OnLine"].ToString();
                    obj.Sem_Validacao = Convert.ToInt32(reader["Sem_Validação"].ToString());
                    //         obj.Estados = 0;
                    obj.Aspecto_Impacto = Convert.ToInt32(reader["Aspecto_Impacto"].ToString());
                    obj.Vinculo_Legis_AI = Convert.ToInt32(reader["Vínculo_Legis_AI"].ToString());
                    obj.Perigo_Risco = Convert.ToInt32(reader["Perigo_Risco"].ToString());
                    obj.Vinculo_Legis_PR = Convert.ToInt32(reader["Vínculo_Legis_PR"].ToString());
                    obj.Plano = reader["Plano"].ToString();
                    obj.Valor = Convert.ToDecimal(reader["Valor"].ToString());
                    obj.Usuarios = Convert.ToInt32(reader["Usuários"].ToString());
                    listaComercial.Add(obj);

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

            return listaComercial;

        }

        public void create(Atribuicoes obj)
        {
            throw new NotImplementedException();
        }

        public void delete(Atribuicoes obj)
        {
            throw new NotImplementedException();
        }

        public void update(Atribuicoes obj)
        {
            throw new NotImplementedException();
        }

        public bool find(Atribuicoes obj)
        {
            throw new NotImplementedException();
        }

        List<Atribuicoes> Obrigatorio<Atribuicoes>.findAll()
        {
            throw new NotImplementedException();
        }
    }
}
