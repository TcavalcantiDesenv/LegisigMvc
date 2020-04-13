using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class FaixaVendaNeg
    {
        private FaixaVendaDao objFaixaVendaDao;

        public FaixaVendaNeg()
        {
            objFaixaVendaDao = new FaixaVendaDao();

        }

        public void create(FaixaVenda objFaixaVenda)
        {
            bool verificacao = true;

            int Prd = objFaixaVenda.Prd;
            string F01 = objFaixaVenda.F01.ToString();
            string F02 = objFaixaVenda.F02.ToString();
            string F03 = objFaixaVenda.F03.ToString();
            string F04 = objFaixaVenda.F04.ToString();
            string F05 = objFaixaVenda.F05.ToString();
            string F06 = objFaixaVenda.F06.ToString();
            string F07 = objFaixaVenda.F07.ToString();
            string F08 = objFaixaVenda.F08.ToString();
            string F09 = objFaixaVenda.F09.ToString();


            //se nao tem erro
            objFaixaVenda.Estados = 99;
            objFaixaVendaDao.create(objFaixaVenda);
            return;
        }
        public void update(FaixaVenda objFaixaVenda)
        {
            bool verificacao = true;
            int Prd = objFaixaVenda.Prd;
            string F01 = objFaixaVenda.F01.ToString();
            string F02 = objFaixaVenda.F02.ToString();
            string F03 = objFaixaVenda.F03.ToString();
            string F04 = objFaixaVenda.F04.ToString();
            string F05 = objFaixaVenda.F05.ToString();
            string F06 = objFaixaVenda.F06.ToString();
            string F07 = objFaixaVenda.F07.ToString();
            string F08 = objFaixaVenda.F08.ToString();
            string F09 = objFaixaVenda.F09.ToString();
            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objFaixaVenda.Estados = 99;
            objFaixaVendaDao.update(objFaixaVenda);
            return;
        }
        public void delete(FaixaVenda objFaixaVenda)
        {
            bool verificacao = true;
            //verificando se existe
            FaixaVenda objFaixaVendaAux = new FaixaVenda();
            objFaixaVendaAux.Prd = objFaixaVenda.Prd;
            verificacao = objFaixaVendaDao.find(objFaixaVendaAux);
            if (!verificacao)
            {
                objFaixaVenda.Estados = 33;
                return;
            }


            objFaixaVenda.Estados = 99;
            objFaixaVendaDao.delete(objFaixaVenda);
            return;
        }
        public bool find(FaixaVenda objFaixaVenda)
        {
            return objFaixaVendaDao.find(objFaixaVenda);
        }
        public List<FaixaVenda> findAll()
        {
            return objFaixaVendaDao.findAll();
        }
    }
}
