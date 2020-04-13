using Model.Entity;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Model.Dao
{
    public class FaixaVendaDao : Obrigatorio<FaixaVenda>
    {
        private ConexaoDBPG objConexaoDBPGPG;
        private NpgsqlCommand comando;
        private NpgsqlDataReader reader;

        public FaixaVendaDao()
        {
            objConexaoDBPGPG = ConexaoDBPG.saberEstado();
        }

        public void create(FaixaVenda obj)
        {
            throw new System.NotImplementedException();
        }

        public void delete(FaixaVenda obj)
        {
            throw new System.NotImplementedException();
        }

        public bool find(FaixaVenda obj)
        {
            bool temRegistros;
            string find = "select * from web.fai_ven where prd='" + obj.Prd + "'";
            try
            {
                comando = new NpgsqlCommand(find, objConexaoDBPGPG.getCon());
                objConexaoDBPGPG.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Prd = Convert.ToInt32(reader["Prd"].ToString());
                    obj.F01 = Convert.ToDouble(reader["F01"].ToString());
                    obj.F02 = Convert.ToDouble(reader["F02"].ToString());
                    obj.F03 = Convert.ToDouble(reader["F03"].ToString());
                    obj.F04 = Convert.ToDouble(reader["F04"].ToString());
                    obj.F05 = Convert.ToDouble(reader["F05"].ToString());
                    obj.F06 = Convert.ToDouble(reader["F06"].ToString());
                    obj.F07 = Convert.ToDouble(reader["F07"].ToString());
                    obj.F08 = Convert.ToDouble(reader["F08"].ToString());
                    obj.F09 = Convert.ToDouble(reader["F09"].ToString());


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
                objConexaoDBPGPG.getCon().Close();
                objConexaoDBPGPG.CloseDB();
            }

            return temRegistros;

        }

        public List<FaixaVenda> findAll()
        {
            List<FaixaVenda> listaFaixaVenda = new List<FaixaVenda>();
            string find = "select * from web.fai_ven  order by prd asc";
            try
            {
                comando = new NpgsqlCommand(find, objConexaoDBPGPG.getCon());
                objConexaoDBPGPG.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    FaixaVenda obj = new FaixaVenda();
                    obj.Prd = Convert.ToInt32(reader["Prd"].ToString());
                    obj.F01 = Convert.ToDouble(reader["F01"].ToString());
                    obj.F02 = Convert.ToDouble(reader["F02"].ToString());
                    obj.F03 = Convert.ToDouble(reader["F03"].ToString());
                    obj.F04 = Convert.ToDouble(reader["F04"].ToString());
                    obj.F05 = Convert.ToDouble(reader["F05"].ToString());
                    obj.F06 = Convert.ToDouble(reader["F06"].ToString());
                    obj.F07 = Convert.ToDouble(reader["F07"].ToString());
                    obj.F08 = Convert.ToDouble(reader["F08"].ToString());
                    obj.F09 = Convert.ToDouble(reader["F09"].ToString());
                    listaFaixaVenda.Add(obj);
                }

            }
            catch (Exception ex)
            {
                FaixaVenda obj2 = new FaixaVenda();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDBPGPG.getCon().Close();
                objConexaoDBPGPG.CloseDB();
            }

            return listaFaixaVenda;
        }

        public void update(FaixaVenda obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
