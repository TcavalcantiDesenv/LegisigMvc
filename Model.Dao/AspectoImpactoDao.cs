using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class AspectoImpactoDao : Obrigatorio<AspectoImpacto>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public AspectoImpactoDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(AspectoImpacto obj)
        {
            string create = "insert into AspectoImpacto values('" + obj.Id + "','" + obj.IdProcesso + "','" + obj.IdAtividade + "','" + obj.Entrada + "','" + obj.Con + "','" + obj.Saida + "','" + obj.ImpAmbiental + "','" + obj.AltA + "','" + obj.AltB + "','" + obj.Inc + "','" + obj.ContrInflu + "','" + obj.Tem + "','" + obj.Abr + "','" + obj.FP + "','" + obj.Gra + "','" + obj.Interessada + "','"  + "','" + obj.RequisitoA + "','" + obj.RequisitoB + "','" + obj.Req + "','"+obj.RiscOportA + "','"+obj.RiscOportB + "')";
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

        public void delete(AspectoImpacto obj)
        {
            string delete = "delete from AspectoImpacto where id ='" + obj.Id + "'";
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

        public bool find(AspectoImpacto obj)
        {
            bool temRegistros;
            string find = "select*from AspectoImpacto where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IdProcesso =Convert.ToInt32 (reader["Id Processo"].ToString());
                    obj.IdAtividade = Convert.ToInt32(reader["Id Atividade"].ToString());
                    obj.Entrada = reader["Entrada"].ToString();
                    obj.Con = reader["Con"].ToString();
                    obj.Saida = reader["Saída"].ToString();
                    obj.ImpAmbiental = reader["Imp Ambiental"].ToString();
                    obj.AltA = reader["AltA"].ToString();
                    obj.AltB = reader["AltB"].ToString();
                    obj.Inc = reader["Inc"].ToString();
                    //         obj.Estados = 0;
                    obj.ContrInflu = reader["Contr Influ"].ToString();
                    obj.Tem = reader["Tem"].ToString();
                    obj.Abr = reader["Abr"].ToString();
                    obj.FP = reader["FP"].ToString();
                    obj.Gra = reader["Gra"].ToString();
                    obj.Interessada = reader["Interessada"].ToString();
                    obj.RequisitoA = reader["RequisitoA"].ToString();
                    obj.RequisitoB = reader["RequisitoB"].ToString();
                    obj.Req = reader["Req"].ToString();
                    obj.RiscOportA = reader["RiscOportA"].ToString();
                    obj.RiscOportB = reader["RiscOportB"].ToString();


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

        public List<AspectoImpacto> findAll()
        {
            List<AspectoImpacto> listaAspectoImpacto = new List<AspectoImpacto>();
            string find = "select*from AspectoImpacto order by Id asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    AspectoImpacto obj = new AspectoImpacto();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    obj.IdProcesso = Convert.ToInt32(reader["Id Processo"].ToString());
                    obj.IdAtividade = Convert.ToInt32(reader["Id Atividade"].ToString());
                    obj.Entrada = reader["Entrada"].ToString();
                    obj.Con = reader["Con"].ToString();
                    obj.Saida = reader["Saída"].ToString();
                    obj.ImpAmbiental = reader["Imp Ambiental"].ToString();
                    obj.AltA = reader["AltA"].ToString();
                    obj.AltB = reader["AltB"].ToString();
                    obj.Inc = reader["Inc"].ToString();
                    //         obj.Estados = 0;
                    obj.ContrInflu = reader["Contr Influ"].ToString();
                    obj.Tem = reader["Tem"].ToString();
                    obj.Abr = reader["Abr"].ToString();
                    obj.FP = reader["FP"].ToString();
                    obj.Gra = reader["Gra"].ToString();
                    obj.Interessada = reader["Interessada"].ToString();
                    obj.RequisitoA = reader["RequisitoA"].ToString();
                    obj.RequisitoB = reader["RequisitoB"].ToString();
                    obj.Req = reader["Req"].ToString();
                    obj.RiscOportA = reader["RiscOportA"].ToString();
                    obj.RiscOportB = reader["RiscOportB"].ToString();
                    listaAspectoImpacto.Add(obj);
                }

            }
            catch (Exception ex)
            {
                AspectoImpacto obj2 = new AspectoImpacto();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaAspectoImpacto;
        }

        public void update(AspectoImpacto obj)
        {
            string update = "update AspectoImpacto set IdProcesso='" + obj.IdProcesso + "',IdAtividade='" + obj.IdAtividade + "',Entrada='" + obj.Entrada + "',Con='" + obj.Con + "',Saida='" + obj.Saida + "',ImpAmbiental='" + obj.ImpAmbiental + "',AltA='" + obj.AltA + "',AltB='" + obj.AltB + "',Inc='" + obj.Inc + "',ContrInflu='" + obj.ContrInflu + "',Tem='" + obj.Tem + "',Abr='" + obj.Abr + "',FP='" + obj.FP + "',Gra='" + obj.Gra + "',Interessada='" + obj.Interessada + "',RequisitoA='" + obj.RequisitoA + "',RequisitoB='" + obj.RequisitoB + "',Req='" + obj.Req + "',RiscOportA='" + obj.RiscOportA + "',RiscOportB='" + obj.RiscOportB + "' where id='" + obj.Id + "'  where Id = '" + obj.Id + "' ";
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

        public bool findAspectoImpactoPorId(AspectoImpacto obj)
        {
            bool temRegistros;
            string find = "select*from AspectoImpacto where Id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.IdProcesso = Convert.ToInt32(reader["Id Processo"].ToString());
                    obj.IdAtividade = Convert.ToInt32(reader["Id Atividade"].ToString());
                    obj.Entrada = reader["Entrada"].ToString();
                    obj.Con = reader["Con"].ToString();
                    obj.Saida = reader["Saída"].ToString();
                    obj.ImpAmbiental = reader["Imp Ambiental"].ToString();
                    obj.AltA = reader["AltA"].ToString();
                    obj.AltB = reader["AltB"].ToString();
                    obj.Inc = reader["Inc"].ToString();
                    //         obj.Estados = 0;
                    obj.ContrInflu = reader["Contr Influ"].ToString();
                    obj.Tem = reader["Tem"].ToString();
                    obj.Abr = reader["Abr"].ToString();
                    obj.FP = reader["FP"].ToString();
                    obj.Gra = reader["Gra"].ToString();
                    obj.Interessada = reader["Interessada"].ToString();
                    obj.RequisitoA = reader["RequisitoA"].ToString();
                    obj.RequisitoB = reader["RequisitoB"].ToString();
                    obj.Req = reader["Req"].ToString();
                    obj.RiscOportA = reader["RiscOportA"].ToString();
                    obj.RiscOportB = reader["RiscOportB"].ToString();
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

        public List<AspectoImpacto> findAspectoImpacto(AspectoImpacto objAspectoImpacto)
        {
            List<AspectoImpacto> listaAspectoImpacto = new List<AspectoImpacto>();
            string findAll = "select* from AspectoImpacto where Entrada like '%" + objAspectoImpacto.Entrada + "%' or Con like '%" + objAspectoImpacto.Con + "%' or Saida like '%" + objAspectoImpacto.Saida + "%' or ImpAmbiental like '%" + objAspectoImpacto.ImpAmbiental + "%' or AltA like '%" + objAspectoImpacto.AltA + "%' or AltB like '%" + objAspectoImpacto.AltB + "%' or Inc like '%" + objAspectoImpacto.Inc + "%' or ContrInflu like '%" + objAspectoImpacto.ContrInflu + "%' or Tem like '%" + objAspectoImpacto.Tem + "%' or Abr like '%" + objAspectoImpacto.Abr + "%' or FP like '%" + objAspectoImpacto.FP + "%' or Gra like '%" + objAspectoImpacto.Gra + "%' or Interessada like '%" + objAspectoImpacto.Interessada + "%' or RequisitoA like '%" + objAspectoImpacto.RequisitoA + "%' or RequisitoB like '%" + objAspectoImpacto.RequisitoB + "%' or Req like '%" + objAspectoImpacto.Req + "%' or RiscOportA like '%" + objAspectoImpacto.RiscOportA + "%' or RiscOportB like '%" + objAspectoImpacto.RiscOportB + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    AspectoImpacto obj = new AspectoImpacto();
                    obj.IdProcesso = Convert.ToInt32(reader["Id Processo"].ToString());
                    obj.IdAtividade = Convert.ToInt32(reader["Id Atividade"].ToString());
                    obj.Entrada = reader["Entrada"].ToString();
                    obj.Con = reader["Con"].ToString();
                    obj.Saida = reader["Saída"].ToString();
                    obj.ImpAmbiental = reader["Imp Ambiental"].ToString();
                    obj.AltA = reader["AltA"].ToString();
                    obj.AltB = reader["AltB"].ToString();
                    obj.Inc = reader["Inc"].ToString();
                    //         obj.Estados = 0;
                    obj.ContrInflu = reader["Contr Influ"].ToString();
                    obj.Tem = reader["Tem"].ToString();
                    obj.Abr = reader["Abr"].ToString();
                    obj.FP = reader["FP"].ToString();
                    obj.Gra = reader["Gra"].ToString();
                    obj.Interessada = reader["Interessada"].ToString();
                    obj.RequisitoA = reader["RequisitoA"].ToString();
                    obj.RequisitoB = reader["RequisitoB"].ToString();
                    obj.Req = reader["Req"].ToString();
                    obj.RiscOportA = reader["RiscOportA"].ToString();
                    obj.RiscOportB = reader["RiscOportB"].ToString();
                    listaAspectoImpacto.Add(obj);

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

            return listaAspectoImpacto;

        }
    }
}
