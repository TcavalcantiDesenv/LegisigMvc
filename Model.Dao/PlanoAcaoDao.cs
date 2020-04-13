using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class PlanoAcaoDao : Obrigatorio<PlanoAcao>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public PlanoAcaoDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(PlanoAcao obj)
        {
            string create = "insert into PlanoAcao values('" + obj.IDParametros + "','" + obj.Causa + "','" + obj.DataCausa.ToString("yyyy-MM-dd") + "','" + obj.Correcao_Corretivas + "','" + obj.Prazo.ToString("yyyy-MM-dd") + "','" + obj.Eficacia + "','" + obj.Prazo.ToString("yyyy-MM-dd") + "','" + obj.Evidencias + "','" + obj.ResultFinal + "','" + obj.IDCliente + "','" + obj.IDLegis + "','" + obj.IDAcao + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void delete(PlanoAcao obj)
        {
            string delete = "delete from PlanoAcao where id ='" + obj.id + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool find(PlanoAcao obj)
        {
            bool temRegistros;
            string find = "select*from PlanoAcao where id='" + obj.id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IDParametros =Convert.ToInt32( reader["ID Parametros"].ToString());
                    obj.Causa = reader["Causa"].ToString();
                    obj.DataCausa =Convert.ToDateTime (reader["Dt Causa"].ToString());
                    obj.Correcao_Corretivas = reader["Correções Corretivas"].ToString();
                    obj.Prazo =Convert.ToDateTime( reader["Prazo"].ToString());
                    obj.Eficacia = reader["Eficacia"].ToString();
                    obj.DataEficacia =Convert.ToDateTime( reader["Dt Eficacia"].ToString());
                    obj.Evidencias = reader["Evidencias"].ToString();
                    obj.ResultFinal = reader["Result Final"].ToString();
                    //         obj.Estados = 0;
                    obj.IDCliente =Convert.ToInt32( reader["ID Cliente"].ToString());
                    obj.IDLegis = Convert.ToInt32(reader["ID Legis"].ToString());
                    obj.IDAcao = Convert.ToInt32(reader["ID Ação"].ToString());
                }
                else
                {
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

        public List<PlanoAcao> findAll()
        {
            List<PlanoAcao> listaPlanoAcao = new List<PlanoAcao>();
            string find = "select*from PlanoAcao order by id asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    PlanoAcao obj = new PlanoAcao();
                    obj.id = Convert.ToInt32(reader["Id"].ToString());
                    obj.IDParametros = Convert.ToInt32(reader["ID Parametros"].ToString());
                    obj.Causa = reader["Causa"].ToString();
                    obj.DataCausa = Convert.ToDateTime(reader["Dt Causa"].ToString());
                    obj.Correcao_Corretivas = reader["Correções Corretivas"].ToString();
                    obj.Prazo = Convert.ToDateTime(reader["Prazo"].ToString());
                    obj.Eficacia = reader["Eficacia"].ToString();
                    obj.DataEficacia = Convert.ToDateTime(reader["Dt Eficacia"].ToString());
                    obj.Evidencias = reader["Evidencias"].ToString();
                    obj.ResultFinal = reader["Result Final"].ToString();
                    //         obj.Estados = 0;
                    obj.IDCliente = Convert.ToInt32(reader["ID Cliente"].ToString());
                    obj.IDLegis = Convert.ToInt32(reader["ID Legis"].ToString());
                    obj.IDAcao = Convert.ToInt32(reader["ID Ação"].ToString());
                    listaPlanoAcao.Add(obj);
                }

            }
            catch (Exception ex)
            {
                PlanoAcao obj2 = new PlanoAcao();
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaPlanoAcao;
        }
        public List<PlanoAcao> buscarPorClienteConformidade(string cliente)
        {
            List<PlanoAcao> listaPlanoAcao = new List<PlanoAcao>(); //and [IDAcao] = '" + conformidade+"'
            string find = "select*from PlanoAcao WHERE IDCliente = '" + cliente + "'  order by id asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    PlanoAcao obj = new PlanoAcao();
                    obj.id = Convert.ToInt32(reader["Id"].ToString());
                    obj.IDParametros = Convert.ToInt32(reader["IDParametros"].ToString());
                    obj.Causa = reader["Causa"].ToString();
                    obj.DataCausa = Convert.ToDateTime(reader["DataCausa"].ToString());
                    obj.Correcao_Corretivas = reader["Correcao_Corretivas"].ToString();
                    obj.Prazo = Convert.ToDateTime(reader["Prazo"].ToString().Substring(0,10));
                    obj.Eficacia = reader["Eficacia"].ToString();
                    if(reader["DataEficacia"].ToString() != "") obj.DataEficacia = Convert.ToDateTime(reader["DataEficacia"].ToString().Substring(0, 10));
                    obj.Evidencias = reader["Evidencias"].ToString();
                    obj.ResultFinal = reader["ResultFinal"].ToString();
                    //         obj.Estados = 0;
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDLegis = Convert.ToInt32(reader["IDLegis"].ToString());
                    obj.IDAcao = Convert.ToInt32(reader["IDAcao"].ToString());
                    listaPlanoAcao.Add(obj);
                }

            }
            catch (Exception ex)
            {
                PlanoAcao obj2 = new PlanoAcao();
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaPlanoAcao;
        }
        public List<PlanoAcao> buscarPorID(string Id)
        {
            List<PlanoAcao> listaPlanoAcao = new List<PlanoAcao>();
            string find = "select*from PlanoAcao WHERE Id = '" + Id + "' ";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    PlanoAcao obj = new PlanoAcao();
                    obj.id = Convert.ToInt32(reader["Id"].ToString());
                    obj.IDParametros = Convert.ToInt32(reader["IDParametros"].ToString());
                    obj.Causa = reader["Causa"].ToString();
                    obj.DataCausa = Convert.ToDateTime(reader["DataCausa"].ToString());
                    obj.Correcao_Corretivas = reader["Correcao_Corretivas"].ToString();
                    obj.Prazo = Convert.ToDateTime(reader["Prazo"].ToString().Substring(0, 10));
                    obj.Eficacia = reader["Eficacia"].ToString();
                    if (reader["DataEficacia"].ToString() != "") obj.DataEficacia = Convert.ToDateTime(reader["DataEficacia"].ToString().Substring(0, 10));
                    obj.Evidencias = reader["Evidencias"].ToString();
                    obj.ResultFinal = reader["ResultFinal"].ToString();
                    //         obj.Estados = 0;
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDLegis = Convert.ToInt32(reader["IDLegis"].ToString());
                    obj.IDAcao = Convert.ToInt32(reader["IDAcao"].ToString());
                    listaPlanoAcao.Add(obj);
                }

            }
            catch (Exception ex)
            {
                PlanoAcao obj2 = new PlanoAcao();
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaPlanoAcao;
        }

        public void update(PlanoAcao obj)
        {
            string update = "update PlanoAcao set Causa='" + obj.Causa + "',DataCausa='" + obj.DataCausa.ToString("yyyy-MM-dd") + "',Correcao_Corretivas='" + obj.Correcao_Corretivas + "',Prazo='" + obj.Prazo.ToString("yyyy-MM-dd") + "',Eficacia='" + obj.Eficacia + "',DataEficacia='" + obj.Prazo.ToString("yyyy-MM-dd") + "',ResultFinal='" + obj.ResultFinal + "' where Id = '" + obj.id + "' ";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool findPlanoAcaoPorId(PlanoAcao obj)
        {
            bool temRegistros;
            string find = "select*from PlanoAcao where id='" + obj.id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IDParametros = Convert.ToInt32(reader["ID Parametros"].ToString());
                    obj.Causa = reader["Causa"].ToString();
                    obj.DataCausa = Convert.ToDateTime(reader["Dt Causa"].ToString());
                    obj.Correcao_Corretivas = reader["Correções Corretivas"].ToString();
                    obj.Prazo = Convert.ToDateTime(reader["Prazo"].ToString());
                    obj.Eficacia = reader["Eficacia"].ToString();
                    obj.DataEficacia = Convert.ToDateTime(reader["DataEficacia"].ToString());
                    obj.Evidencias = reader["Evidencias"].ToString();
                    obj.ResultFinal = reader["Result Final"].ToString();
                    //         obj.Estados = 0;
                    obj.IDCliente = Convert.ToInt32(reader["ID Cliente"].ToString());
                    obj.IDLegis = Convert.ToInt32(reader["ID Legis"].ToString());
                    obj.IDAcao = Convert.ToInt32(reader["ID Ação"].ToString());


                }
                else
                {
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

        public List<PlanoAcao> findAllPlanoAcao(PlanoAcao objPlanoAcao)
        {
            List<PlanoAcao> listaPlanoAcao = new List<PlanoAcao>();
            string findAll = "select* from PlanoAcao where Causa like '%" + objPlanoAcao.Causa + "%' or Correcao_Corretivas like '%" + objPlanoAcao.Correcao_Corretivas + "%' or Eficacia like '%" + objPlanoAcao.Eficacia + "%' or Evidencias like '%" + objPlanoAcao.Evidencias + "%' or ResultFinal like '%" + objPlanoAcao.ResultFinal + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    PlanoAcao obj = new PlanoAcao();
                    obj.IDParametros = Convert.ToInt32(reader["IDParametros"].ToString());
                    obj.Causa = reader["Causa"].ToString();
                    obj.DataCausa = Convert.ToDateTime(reader["Dt Causa"].ToString());
                    obj.Correcao_Corretivas = reader["Correcao_Corretivas"].ToString();
                    obj.Prazo = Convert.ToDateTime(reader["Prazo"].ToString());
                    obj.Eficacia = reader["Eficacia"].ToString();
                    obj.DataEficacia = Convert.ToDateTime(reader["DataEficacia"].ToString());
                    obj.Evidencias = reader["Evidencias"].ToString();
                    obj.ResultFinal = reader["ResultFinal"].ToString();
                    //         obj.Estados = 0;
                    obj.IDCliente = Convert.ToInt32(reader["IDCliente"].ToString());
                    obj.IDLegis = Convert.ToInt32(reader["IDLegis"].ToString());
                    obj.IDAcao = Convert.ToInt32(reader["IDAcao"].ToString());
                    listaPlanoAcao.Add(obj);

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

            return listaPlanoAcao;

        }
    }
}
