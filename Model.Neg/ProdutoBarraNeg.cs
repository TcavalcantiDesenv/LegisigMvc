using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class ProdutoBarraNeg
    {
        private ProdutoBarraDao objProdutoBarraDao;

        public ProdutoBarraNeg()
        {
            objProdutoBarraDao = new ProdutoBarraDao();

        }

        public void create(ProdutoBarra objProdutoBarra)
        {
            bool verificacao = true;

            int Ide = objProdutoBarra.Ide;
            string Cod = objProdutoBarra.Cod.ToString();
            string Bar = objProdutoBarra.Bar.ToString();
            string Val = objProdutoBarra.Val.ToString();


            //se nao tem erro
            objProdutoBarra.Estados = 99;
            objProdutoBarraDao.create(objProdutoBarra);
            return;
        }
        public void update(ProdutoBarra objProdutoBarra)
        {
            bool verificacao = true;
            string Cod = objProdutoBarra.Cod.ToString();
            string Bar = objProdutoBarra.Bar.ToString();
            string Val = objProdutoBarra.Val.ToString();

            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objProdutoBarra.Estados = 99;
            objProdutoBarraDao.update(objProdutoBarra);
            return;
        }
        public void delete(ProdutoBarra objProdutoBarra)
        {
            bool verificacao = true;
            //verificando se existe
            ProdutoBarra objProdutoBarraAux = new ProdutoBarra();
            objProdutoBarraAux.Ide = objProdutoBarra.Ide;
            verificacao = objProdutoBarraDao.find(objProdutoBarraAux);
            if (!verificacao)
            {
                objProdutoBarra.Estados = 33;
                return;
            }


            objProdutoBarra.Estados = 99;
            objProdutoBarraDao.delete(objProdutoBarra);
            return;
        }
        public bool find(ProdutoBarra objProdutoBarra)
        {
            return objProdutoBarraDao.find(objProdutoBarra);
        }
        public List<ProdutoBarra> findAll()
        {
            return objProdutoBarraDao.findAll();
        }

        public List<ProdutoBarra> PesquisarPorBarra(string barra)
        {
            return objProdutoBarraDao.PesquisarPorBarra(barra);
        }
    }
}
