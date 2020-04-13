using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Neg
{
    public class ProdutoCabecalhoNeg
    {
        private ProdutoCabecalhoDao objProdutoCabecalhoDao;

        public ProdutoCabecalhoNeg()
        {
            objProdutoCabecalhoDao = new ProdutoCabecalhoDao();

        }

        public void create(ProdutoCabecalho objProdutoCabecalho)
        {
            bool verificacao = true;

            string Cod = objProdutoCabecalho.Cod.ToString();
            string Des = objProdutoCabecalho.Des.ToString();
            string Tip = objProdutoCabecalho.Tip.ToString();
            string Cls = objProdutoCabecalho.Cls.ToString();
            string Sec = objProdutoCabecalho.Sec.ToString();
            string Ipi = objProdutoCabecalho.Ipi.ToString();
            string Un = objProdutoCabecalho.Un.ToString();
            string Qte = objProdutoCabecalho.Qte.ToString();
            string Cop = objProdutoCabecalho.Cop.ToString();
            string Pfa = objProdutoCabecalho.Pfa.ToString();
            string Pmx = objProdutoCabecalho.Pmx.ToString();
            string Pac = objProdutoCabecalho.Pac.ToString();
            string Etq = objProdutoCabecalho.Etq.ToString();
            string Icm = objProdutoCabecalho.Icm.ToString();
            string Tpl = objProdutoCabecalho.Tpl.ToString();
            string Rem = objProdutoCabecalho.Rem.ToString();
            string Cum = objProdutoCabecalho.Cum.ToString();
            string Ucu = objProdutoCabecalho.Ucu.ToString();
            string Pro = objProdutoCabecalho.Pro.ToString();
            string Loc = objProdutoCabecalho.Loc.ToString();
            string Fti = objProdutoCabecalho.Fti.ToString();
            string Dft = objProdutoCabecalho.Dft.ToString();
            string Cvf = objProdutoCabecalho.Cvf.ToString();
            string Ctr = objProdutoCabecalho.Ctr.ToString();
            string Dca = objProdutoCabecalho.Dca.ToString();
            string Due = objProdutoCabecalho.Due.ToString();
            string Dus = objProdutoCabecalho.Dus.ToString();
            string Dur = objProdutoCabecalho.Dur.ToString();
            string Eat = objProdutoCabecalho.Eat.ToString();
            string Fab = objProdutoCabecalho.Fab.ToString();
            string Dep = objProdutoCabecalho.Dep.ToString();
            string Ref = objProdutoCabecalho.Ref.ToString();
            string Gsu = objProdutoCabecalho.Gsu.ToString();
            string Tbo = objProdutoCabecalho.Tbo.ToString();
            string Bon = objProdutoCabecalho.Bon.ToString();
            string Lde = objProdutoCabecalho.Lde.ToString();
            string Str = objProdutoCabecalho.Str.ToString();
            string Tba = objProdutoCabecalho.Tba.ToString();
            string Ivi = objProdutoCabecalho.Ivi.ToString();
            string Ive = objProdutoCabecalho.Ive.ToString();
            string Tiv = objProdutoCabecalho.Tiv.ToString();
            string Ncm = objProdutoCabecalho.Ncm.ToString();
            string Atv = objProdutoCabecalho.Atv.ToString();
            string Pic = objProdutoCabecalho.Pic.ToString();
            string Tst = objProdutoCabecalho.Tst.ToString();
            string Ori = objProdutoCabecalho.Ori.ToString();
            string Pis = objProdutoCabecalho.Pis.ToString();
            string Cos = objProdutoCabecalho.Cos.ToString();
            string Tme = objProdutoCabecalho.Tme.ToString();
            string Upd = objProdutoCabecalho.Upd.ToString();
            string S2S = objProdutoCabecalho.S2S.ToString();

            //se nao tem erro
            objProdutoCabecalho.Estados = 99;
            objProdutoCabecalhoDao.create(objProdutoCabecalho);
            return;
        }
        public void update(ProdutoCabecalho objProdutoCabecalho)
        {
            bool verificacao = true;
            string Cod = objProdutoCabecalho.Cod.ToString();
            string Des = objProdutoCabecalho.Des.ToString();
            string Tip = objProdutoCabecalho.Tip.ToString();
            string Cls = objProdutoCabecalho.Cls.ToString();
            string Sec = objProdutoCabecalho.Sec.ToString();
            string Ipi = objProdutoCabecalho.Ipi.ToString();
            string Un = objProdutoCabecalho.Un.ToString();
            string Qte = objProdutoCabecalho.Qte.ToString();
            string Cop = objProdutoCabecalho.Cop.ToString();
            string Pfa = objProdutoCabecalho.Pfa.ToString();
            string Pmx = objProdutoCabecalho.Pmx.ToString();
            string Pac = objProdutoCabecalho.Pac.ToString();
            string Etq = objProdutoCabecalho.Etq.ToString();
            string Icm = objProdutoCabecalho.Icm.ToString();
            string Tpl = objProdutoCabecalho.Tpl.ToString();
            string Rem = objProdutoCabecalho.Rem.ToString();
            string Cum = objProdutoCabecalho.Cum.ToString();
            string Ucu = objProdutoCabecalho.Ucu.ToString();
            string Pro = objProdutoCabecalho.Pro.ToString();
            string Loc = objProdutoCabecalho.Loc.ToString();
            string Fti = objProdutoCabecalho.Fti.ToString();
            string Dft = objProdutoCabecalho.Dft.ToString();
            string Cvf = objProdutoCabecalho.Cvf.ToString();
            string Ctr = objProdutoCabecalho.Ctr.ToString();
            string Dca = objProdutoCabecalho.Dca.ToString();
            string Due = objProdutoCabecalho.Due.ToString();
            string Dus = objProdutoCabecalho.Dus.ToString();
            string Dur = objProdutoCabecalho.Dur.ToString();
            string Eat = objProdutoCabecalho.Eat.ToString();
            string Fab = objProdutoCabecalho.Fab.ToString();
            string Dep = objProdutoCabecalho.Dep.ToString();
            string Ref = objProdutoCabecalho.Ref.ToString();
            string Gsu = objProdutoCabecalho.Gsu.ToString();
            string Tbo = objProdutoCabecalho.Tbo.ToString();
            string Bon = objProdutoCabecalho.Bon.ToString();
            string Lde = objProdutoCabecalho.Lde.ToString();
            string Str = objProdutoCabecalho.Str.ToString();
            string Tba = objProdutoCabecalho.Tba.ToString();
            string Ivi = objProdutoCabecalho.Ivi.ToString();
            string Ive = objProdutoCabecalho.Ive.ToString();
            string Tiv = objProdutoCabecalho.Tiv.ToString();
            string Ncm = objProdutoCabecalho.Ncm.ToString();
            string Atv = objProdutoCabecalho.Atv.ToString();
            string Pic = objProdutoCabecalho.Pic.ToString();
            string Tst = objProdutoCabecalho.Tst.ToString();
            string Ori = objProdutoCabecalho.Ori.ToString();
            string Pis = objProdutoCabecalho.Pis.ToString();
            string Cos = objProdutoCabecalho.Cos.ToString();
            string Tme = objProdutoCabecalho.Tme.ToString();
            string Upd = objProdutoCabecalho.Upd.ToString();
            string S2S = objProdutoCabecalho.S2S.ToString();

            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objProdutoCabecalho.Estados = 99;
            objProdutoCabecalhoDao.update(objProdutoCabecalho);
            return;
        }
        public void delete(ProdutoCabecalho objProdutoCabecalho)
        {
            bool verificacao = true;
            //verificando se existe
            ProdutoCabecalho objProdutoCabecalhoAux = new ProdutoCabecalho();
            objProdutoCabecalhoAux.Ide = objProdutoCabecalho.Ide;
            verificacao = objProdutoCabecalhoDao.find(objProdutoCabecalhoAux);
            if (!verificacao)
            {
                objProdutoCabecalho.Estados = 33;
                return;
            }


            objProdutoCabecalho.Estados = 99;
            objProdutoCabecalhoDao.delete(objProdutoCabecalho);
            return;
        }
        public bool find(ProdutoCabecalho objCliente)
        {
            return objProdutoCabecalhoDao.find(objCliente);
        }
        public List<ProdutoCabecalho> findAll()
        {
            return objProdutoCabecalhoDao.findAll();
        }

    }
}
