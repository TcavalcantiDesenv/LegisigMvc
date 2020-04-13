using Model.Entity;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Model.Dao
{
    public class ProdutoCabecalhoDao : Obrigatorio<ProdutoCabecalho>
    {
        private ConexaoDBPG objConexaoDBPGPG;
        private NpgsqlCommand comando;
        private NpgsqlDataReader reader;

        public ProdutoCabecalhoDao()
        {
            objConexaoDBPGPG = ConexaoDBPG.saberEstado();
        }

        public void create(ProdutoCabecalho obj)
        {
            throw new System.NotImplementedException();
        }

        public void delete(ProdutoCabecalho obj)
        {
            throw new System.NotImplementedException();
        }

        public bool find(ProdutoCabecalho obj)
        {
            bool temRegistros;
            string find = "select * from estoque.prd_cab where ide='" + obj.Ide + "'";
            try
            {
                comando = new NpgsqlCommand(find, objConexaoDBPGPG.getCon());
                objConexaoDBPGPG.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    obj.Ide = Convert.ToInt64(reader["ide"].ToString());
                    obj.Cod = Convert.ToInt32(reader["cod"].ToString());
                    obj.Des = reader["des"].ToString();
                    obj.Tip = reader["tip"].ToString();
                    obj.Cls = Convert.ToInt16(reader["cls"].ToString());
                    obj.Sec = Convert.ToInt16(reader["sec"].ToString());
                    obj.Ipi = Convert.ToInt16(reader["ipi"].ToString());
                    obj.Un = reader["un"].ToString();
                    obj.Qte = Convert.ToInt16(reader["qte"].ToString());
                    obj.Cop = Convert.ToInt32(reader["cop"].ToString());
                    obj.Pfa = Convert.ToDouble(reader["pfa"].ToString());
                    obj.Pmx = Convert.ToDouble(reader["pmx"].ToString());
                    obj.Pac = Convert.ToDouble(reader["pac"].ToString());
                    obj.Etq = reader["etq"].ToString();
                    obj.Icm = Convert.ToInt16(reader["icm"].ToString());
                    obj.Tpl = reader["tpl"].ToString();
                    obj.Rem = reader["rem"].ToString();
                    obj.Cum = Convert.ToDouble(reader["cum"].ToString());
                    obj.Ucu = Convert.ToDouble(reader["ucu"].ToString());
                    obj.Pro = Convert.ToDouble(reader["pro"].ToString());
                    obj.Loc = reader["loc"].ToString();
                    obj.Fti = reader["fti"].ToString();
                    obj.Dft = reader["dft"].ToString();
                    obj.Cvf = reader["cvf"].ToString();
                    obj.Ctr = Convert.ToInt16(reader["ctr"].ToString());
                    obj.Dca = reader["dca"].ToString();
                    obj.Due = reader["due"].ToString();
                    obj.Dus = reader["dus"].ToString();
                    obj.Dur = reader["dur"].ToString();
                    obj.Eat = Convert.ToInt32(reader["eat"].ToString());
                    obj.Fab = Convert.ToInt32(reader["fab"].ToString());
                    obj.Dep = Convert.ToInt32(reader["dep"].ToString());
                    obj.Ref = reader["ref"].ToString();
                    obj.Gsu = Convert.ToInt16(reader["gsu"].ToString());
                    obj.Tbo = reader["tbo"].ToString();
                    obj.Bon = Convert.ToDouble(reader["bon"].ToString());
                    obj.Lde = Convert.ToInt16(reader["lde"].ToString());
                    obj.Str = reader["str"].ToString();
                    obj.Tba = reader["tba"].ToString();
                    obj.Ivi = Convert.ToDouble(reader["ivi"].ToString());
                    obj.Ive = Convert.ToDouble(reader["ive"].ToString());
                    obj.Tiv = reader["tiv"].ToString();
                    obj.Ncm = reader["ncm"].ToString();
                    obj.Atv = Convert.ToBoolean(reader["atv"].ToString());
                    obj.Pic = Convert.ToDouble(reader["pic"].ToString());
                    obj.Tst = Convert.ToInt16(reader["tst"].ToString());
                    obj.Ori = Convert.ToInt16(reader["ori"].ToString());
                    obj.Pis = Convert.ToDecimal(reader["pis"].ToString());
                    obj.Cos = Convert.ToDecimal(reader["cos"].ToString());
                    obj.Tme = reader["tme"].ToString();
                    obj.Upd = Convert.ToBoolean(reader["upd"].ToString());
                    obj.S2S = Convert.ToBoolean(reader["s2s"].ToString());


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

        public List<ProdutoCabecalho> findAll()
        {
            List<ProdutoCabecalho> listaDrogaNossaProduto = new List<ProdutoCabecalho>();
            string find = "select * from estoque.prd_cab order by des asc";
            try
            {
                comando = new NpgsqlCommand(find, objConexaoDBPGPG.getCon());
                objConexaoDBPGPG.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ProdutoCabecalho obj = new ProdutoCabecalho();
                    obj.Ide = Convert.ToInt64(reader["ide"].ToString());
                    obj.Cod = Convert.ToInt32(reader["cod"].ToString());
                    obj.Des = reader["des"].ToString();
                    obj.Tip = reader["tip"].ToString();
                    obj.Cls = Convert.ToInt16(reader["cls"].ToString());
                    obj.Sec = Convert.ToInt16(reader["sec"].ToString());
                    obj.Ipi = Convert.ToInt16(reader["ipi"].ToString());
                    obj.Un = reader["un"].ToString();
                    obj.Qte = Convert.ToInt16(reader["qte"].ToString());
                    obj.Cop = Convert.ToInt32(reader["cop"].ToString());
                    obj.Pfa = Convert.ToDouble(reader["pfa"].ToString());
                    obj.Pmx = Convert.ToDouble(reader["pmx"].ToString());
                    obj.Pac = Convert.ToDouble(reader["pac"].ToString());
                    obj.Etq = reader["etq"].ToString();
                    obj.Icm = Convert.ToInt16(reader["icm"].ToString());
                    obj.Tpl = reader["tpl"].ToString();
                    obj.Rem = reader["rem"].ToString();
                    obj.Cum = Convert.ToDouble(reader["cum"].ToString());
                    obj.Ucu = Convert.ToDouble(reader["ucu"].ToString());
                    obj.Pro = Convert.ToDouble(reader["pro"].ToString());
                    obj.Loc = reader["loc"].ToString();
                    obj.Fti = reader["fti"].ToString();
                    obj.Dft = reader["dft"].ToString();
                    obj.Cvf = reader["cvf"].ToString();
                    obj.Ctr = Convert.ToInt16(reader["ctr"].ToString());
                    obj.Dca = reader["dca"].ToString();
                    obj.Due = reader["due"].ToString();
                    obj.Dus = reader["dus"].ToString();
                    obj.Dur = reader["dur"].ToString();
                    obj.Eat = Convert.ToInt32(reader["eat"].ToString());
                    obj.Fab = Convert.ToInt32(reader["fab"].ToString());
                    obj.Dep = Convert.ToInt32(reader["dep"].ToString());
                    obj.Ref = reader["ref"].ToString();
                    obj.Gsu = Convert.ToInt16(reader["gsu"].ToString());
                    obj.Tbo = reader["tbo"].ToString();
                    obj.Bon = Convert.ToDouble(reader["bon"].ToString());
                    obj.Lde = Convert.ToInt16(reader["lde"].ToString());
                    obj.Str = reader["str"].ToString();
                    obj.Tba = reader["tba"].ToString();
                    obj.Ivi = Convert.ToDouble(reader["ivi"].ToString());
                    obj.Ive = Convert.ToDouble(reader["ive"].ToString());
                    obj.Tiv = reader["tiv"].ToString();
                    obj.Ncm = reader["ncm"].ToString();
                    obj.Atv = Convert.ToBoolean(reader["atv"].ToString());
                    obj.Pic = Convert.ToDouble(reader["pic"].ToString());
                    obj.Tst = Convert.ToInt16(reader["tst"].ToString());
                    obj.Ori = Convert.ToInt16(reader["ori"].ToString());
                    obj.Pis = Convert.ToDecimal(reader["pis"].ToString());
                    obj.Cos = Convert.ToDecimal(reader["cos"].ToString());
                    obj.Tme = reader["tme"].ToString();
                    obj.Upd = Convert.ToBoolean(reader["upd"].ToString());
                    obj.S2S = Convert.ToBoolean(reader["s2s"].ToString());
                    listaDrogaNossaProduto.Add(obj);
                }

            }
            catch (Exception ex)
            {
                ProdutoCabecalho obj2 = new ProdutoCabecalho();
                obj2.Estados = 1000;
            }
            finally
            {
                objConexaoDBPGPG.getCon().Close();
                objConexaoDBPGPG.CloseDB();
            }

            return listaDrogaNossaProduto;
        }

        public void update(ProdutoCabecalho obj)
        {
            throw new System.NotImplementedException();
        }

        List<ProdutoCabecalho> Obrigatorio<ProdutoCabecalho>.findAll()
        {
            throw new NotImplementedException();
        }
    }
}
