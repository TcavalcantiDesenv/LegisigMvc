
using Model.Entity;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Model.Dao
{
    public class LegisGeralDao : Obrigatorio<LegisGeralDao>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public LegisGeralDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(LegisGeral obj)
        {
            string create = "insert into LegisGeral values('" + obj.Id + "','"+ obj.Sistema + "','" + obj.Ambito + "','" + obj.Numero + "','" + obj.Ano + "','" + obj.Orgao + "','" + obj.Tema + "','" + obj.Ementa + "','" + obj.Tipo + "','" + obj.lei + "','" + obj.param + "','" + obj.Data + "','" + obj.link + "','" + obj.Localidade + "','" + obj.Estado + "','" + obj.Pais + "','" + obj.Municipio + "','" + obj.Arqpdf+ "','" + "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
           //    // obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void delete(LegisGeral obj)
        {
            string delete = "delete from LegisGeral where id ='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
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

        public bool find(LegisGeral obj)
        {
            bool temRegistros;
            string find = "SELECT DATEDIFF(day, Data, GETDATE()) as Dias, * FROM [LegisGeral] where id='" + obj.Id + "' order by Tema ";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                  //  obj.Dias = reader["Dias"].ToString();
                    obj.Sistema = reader["Sistema"].ToString();
                    obj.Ambito = reader["Âmbito"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Ano = reader["Ano"].ToString();
                    obj.Orgao = reader["Órgão"].ToString();
                    obj.Tema = reader["Tema"].ToString();
                    obj.Ementa = reader["Ementa"].ToString();
                    obj.Tipo = reader["Tipo"].ToString();
                    obj.lei = reader["lei"].ToString();
                    //         obj.Estados = 0;
                    obj.param = reader["Parâm"].ToString();
                    obj.Data = Convert.ToDateTime( reader["Data"].ToString());
                    obj.link = reader["Link"].ToString();
                    obj.Localidade = reader["Localidade"].ToString();
                    obj.Estado = reader["Estado"].ToString();
                    obj.Pais = reader["País"].ToString();
                    obj.Municipio = reader["Município"].ToString();
                    obj.Arqpdf = reader["Arqpdf"].ToString();
                    
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

        public List<LegisGeral> findAll()
        {
            List<LegisGeral> listaLegisGeral = new List<LegisGeral>();
            string find = "select DATEDIFF(day, Data, GETDATE()) as Dias, P.*,L.* from LegisGeral as L, Parametros as P WHERE L.Id = P.IDLegisGeral order by L.Sistema asc";

            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    LegisGeral obj = new LegisGeral();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                  //  obj.Dias = reader["Dias"].ToString();
                    obj.Sistema = reader["Sistema"].ToString();
                    obj.Ambito = reader["Ambito"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Ano = reader["Ano"].ToString();
                    obj.Orgao = reader["Orgao"].ToString();
                    obj.Tema = reader["Tema"].ToString();
                    obj.Ementa = reader["Ementa"].ToString();
                    obj.Tipo = reader["Tipo"].ToString();
                    obj.lei = reader["lei"].ToString();
                    //         obj.Estados = 0;
                    obj.param = reader["param"].ToString();
                    obj.Data = Convert.ToDateTime(reader["Data"].ToString());
                    obj.link = reader["Link"].ToString();
                    obj.Localidade = reader["Localidade"].ToString();
                    obj.Estado = reader["Estado"].ToString();
                    obj.Pais = reader["Pais"].ToString();
                    obj.Municipio = reader["Municipio"].ToString();
                    obj.Arqpdf = reader["Arqpdf"].ToString();
                    listaLegisGeral.Add(obj);
                }

            }
            catch (Exception ex)
            {
                LegisGeral obj2 = new LegisGeral();
              //  obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegisGeral;
        }

        public List<LegisGeral> BuscarPorID(string Id)
        {
            List<LegisGeral> listaLegisGeral = new List<LegisGeral>();//DATEDIFF(day, Data, GETDATE()) as Dia
            string find = "select * from LegisGeral  WHERE Id='" + Id + "' order by Sistema asc";

            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    LegisGeral obj = new LegisGeral();
                    obj.Id = Convert.ToInt32(reader["Id"].ToString());
                    //  obj.Dias = reader["Dias"].ToString();
                    obj.Sistema = reader["Sistema"].ToString();
                    obj.Ambito = reader["Ambito"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Ano = reader["Ano"].ToString();
                    obj.Orgao = reader["Orgao"].ToString();
                    obj.Tema = reader["Tema"].ToString();
                    obj.Ementa = reader["Ementa"].ToString();
                    obj.Tipo = reader["Tipo"].ToString();
                    obj.lei = reader["lei"].ToString();
                    //         obj.Estados = 0;
                    obj.param = reader["param"].ToString();
                    obj.Data = Convert.ToDateTime(reader["Data"].ToString());
                    obj.link = reader["Link"].ToString();
                    obj.Localidade = reader["Localidade"].ToString();
                    obj.Estado = reader["Estado"].ToString();
                    obj.Pais = reader["Pais"].ToString();
                    obj.Municipio = reader["Municipio"].ToString();
                    obj.Arqpdf = reader["Arqpdf"].ToString();
                    listaLegisGeral.Add(obj);
                }

            }
            catch (Exception ex)
            {
                LegisGeral obj2 = new LegisGeral();
                //  obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaLegisGeral;
        }

        public void update(LegisGeral obj)
        {
            string update = "update LegisGeral set link='" + obj.link + "',Arqpdf='" + obj.Arqpdf + "' where id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

               //// obj.Estados = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool findLegisGeralPorId(LegisGeral obj)
        {
            bool temRegistros;
            string find = "select*from LegisGeral where Id='" + obj.Id + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Sistema = reader["Sistema"].ToString();
                    obj.Ambito = reader["Ambito"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Ano = reader["Ano"].ToString();
                    obj.Orgao = reader["Orgao"].ToString();
                    obj.Tema = reader["Tema"].ToString();
                    obj.Ementa = reader["Ementa"].ToString();
                    obj.Tipo = reader["Tipo"].ToString();
                    obj.lei = reader["lei"].ToString();
                    //         obj.Estados = 0;
                    obj.param = reader["param"].ToString();
                    obj.Data = Convert.ToDateTime(reader["Data"].ToString());
                    obj.link = reader["Link"].ToString();
                    obj.Localidade = reader["Localidade"].ToString();
                    obj.Estado = reader["Estado"].ToString();
                    obj.Pais = reader["Pais"].ToString();
                    obj.Municipio = reader["Municipio"].ToString();
                    obj.Arqpdf = reader["Arqpdf"].ToString();
                    //   obj.Estados = 99;

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

        public List<LegisGeral> findAllLegisGeral(LegisGeral objLegisGeral)
        {
            List<LegisGeral> listaLegisGeral = new List<LegisGeral>();
            string findAll = "select* from LegisGeral where Sistema like '%" + objLegisGeral.Sistema + "%' or Ambito like '%" + objLegisGeral.Ambito + "%' or Numero like '%" + objLegisGeral.Numero + "%' or Ano like '%" + objLegisGeral.Ano + "%' or Orgao like '%" + objLegisGeral.Orgao + "%' or Tema like '%" + objLegisGeral.Tema + "%' or Ementa like '%" + objLegisGeral.Ementa + "%' or Tipo like '%" + objLegisGeral.Tipo + "%' or lei like '%" + objLegisGeral.lei + "%' or param like '%" + objLegisGeral.param + "%' or Data like '%" + objLegisGeral.Data + "%' or link like '%" + objLegisGeral.link + "%' or Localidade like '%" + objLegisGeral.Localidade + "%' or Estado like '%" + objLegisGeral.Estado + "%' or Pais like '%" + objLegisGeral.Pais + "%' or Municipio like '%" + objLegisGeral.Municipio + "%' or Arqpdf like '%" + objLegisGeral.Arqpdf + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    LegisGeral obj = new LegisGeral();
                    obj.Sistema = reader["Sistema"].ToString();
                    obj.Ambito = reader["Âmbito"].ToString();
                    obj.Numero = reader["Numero"].ToString();
                    obj.Ano = reader["Ano"].ToString();
                    obj.Orgao = reader["Órgão"].ToString();
                    obj.Tema = reader["Tema"].ToString();
                    obj.Ementa = reader["Ementa"].ToString();
                    obj.Tipo = reader["Tipo"].ToString();
                    obj.lei = reader["lei"].ToString();
                    //         obj.Estados = 0;
                    obj.param = reader["Parâm"].ToString();
                    obj.Data = Convert.ToDateTime(reader["Data"].ToString());
                    obj.link = reader["Link"].ToString();
                    obj.Localidade = reader["Localidade"].ToString();
                    obj.Estado = reader["Estado"].ToString();
                    obj.Pais = reader["País"].ToString();
                    obj.Municipio = reader["Município"].ToString();
                    obj.Arqpdf = reader["Arqpdf"].ToString();
                    listaLegisGeral.Add(obj);

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

            return listaLegisGeral;

        }

        public void create(LegisGeralDao obj)
        {
            throw new NotImplementedException();
        }

        public void delete(LegisGeralDao obj)
        {
            throw new NotImplementedException();
        }

        public void update(LegisGeralDao obj)
        {
            throw new NotImplementedException();
        }

        public bool find(LegisGeralDao obj)
        {
            throw new NotImplementedException();
        }

        List<LegisGeralDao> Obrigatorio<LegisGeralDao>.findAll()
        {
            throw new NotImplementedException();
        }
    }
}
