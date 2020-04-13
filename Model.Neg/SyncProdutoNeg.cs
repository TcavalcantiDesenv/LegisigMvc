using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public  class SyncProdutoNeg
    {
        private SyncProdutoDao objSyncProdutoDao;

        public SyncProdutoNeg()
        {
            objSyncProdutoDao = new SyncProdutoDao();

        }

        public void create(SyncProduto objSyncProduto)
        {
            bool verificacao = true;

            string SyncProdutoId = objSyncProduto.Nome;
            string Inicio = objSyncProduto.Descricao.ToString();
            string Fim = objSyncProduto.Uad.ToString().ToString();
            string Detalhes = objSyncProduto.Modelo;
            string Status = objSyncProduto.Departamento;
            string Preco = objSyncProduto.Preco.ToString();
            string Fornecedor = objSyncProduto.Fornecedor;
            string Barras = objSyncProduto.Barras;
            string Cum = objSyncProduto.Cum.ToString();
            string Ucu = objSyncProduto.Ucu.ToString();
            string Classificacao = objSyncProduto.Classificacao.ToString();

            //se nao tem erro
            objSyncProduto.Estados = 99;
            objSyncProdutoDao.create(objSyncProduto);
            return;
        }
        public void update(SyncProduto objSyncProduto)
        {
            bool verificacao = true;
            string SyncProdutoId = objSyncProduto.Nome;
            string Inicio = objSyncProduto.Descricao.ToString();
            string Fim = objSyncProduto.Uad.ToString().ToString();
            string Detalhes = objSyncProduto.Modelo;
            string Status = objSyncProduto.Departamento;
            string Preco = objSyncProduto.Preco.ToString();
            string Fornecedor = objSyncProduto.Fornecedor;
            string Barras = objSyncProduto.Barras;
            string Cum = objSyncProduto.Cum.ToString();
            string Ucu = objSyncProduto.Ucu.ToString();
            string Classificacao = objSyncProduto.Classificacao.ToString();

            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objSyncProduto.Estados = 99;
            objSyncProdutoDao.update(objSyncProduto);
            return;
        }
        public void delete(SyncProduto objSyncProduto)
        {
            bool verificacao = true;
            //verificando se existe
            SyncProduto objSyncProdutoAux = new SyncProduto();
            objSyncProdutoAux.Barras = objSyncProduto.Barras;
            verificacao = objSyncProdutoDao.find(objSyncProdutoAux);
            if (!verificacao)
            {
                objSyncProduto.Estados = 33;
                return;
            }


            objSyncProduto.Estados = 99;
            objSyncProdutoDao.delete(objSyncProduto);
            return;
        }
        public bool find(SyncProduto objSyncProduto)
        {
            return objSyncProdutoDao.find(objSyncProduto);
        }
        public List<SyncProduto> findAll()
        {
            return objSyncProdutoDao.findAll();
        }
    }
}
