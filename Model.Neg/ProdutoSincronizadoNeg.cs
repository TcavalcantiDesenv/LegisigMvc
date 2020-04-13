using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class ProdutoSincronizadoNeg
    {
        private ProdutoSincronizadoDao objProdutoSincronizadoDao;

        public ProdutoSincronizadoNeg()
        {
            objProdutoSincronizadoDao = new ProdutoSincronizadoDao();

        }

        public void create(ProdutoSincronizado objProdutoSincronizado)
        {
            bool verificacao = true;

            int ProdutoSincronizadoId = objProdutoSincronizado.ProdutoSincronizadoId;
            int ExecucaoId = objProdutoSincronizado.ExecucaoId;
            string Inicio = objProdutoSincronizado.Ean.ToString();
            string Fim = objProdutoSincronizado.Nome.ToString();
            string Detalhes = objProdutoSincronizado.Detalhes;
            string PrecoDe = objProdutoSincronizado.PrecoDe.ToString();
            string PrecoPor = objProdutoSincronizado.PrecoPor.ToString();
            string Quantidade = objProdutoSincronizado.Quantidade.ToString();
            string Operacao = objProdutoSincronizado.Operacao;
            string Descricao = objProdutoSincronizado.Descricao;
            string Status = objProdutoSincronizado.Status;
            string DataSincronizacao = objProdutoSincronizado.DataSincronizacao.ToString();

            //         string Execucao = objProdutoSincronizado.Execucao.ToString();

            //se nao tem erro
          ///  objProdutoSincronizado.Estados = 99;
            objProdutoSincronizadoDao.create(objProdutoSincronizado);
            return;
        }
        public void update(ProdutoSincronizado objProdutoSincronizado)
        {
            bool verificacao = true;
            int ProdutoSincronizadoId = objProdutoSincronizado.ProdutoSincronizadoId;
            string Inicio = objProdutoSincronizado.Ean.ToString();
            string Fim = objProdutoSincronizado.Nome.ToString();
            string Detalhes = objProdutoSincronizado.Detalhes;
            string PrecoDe = objProdutoSincronizado.PrecoDe.ToString();
            string PrecoPor = objProdutoSincronizado.PrecoPor.ToString();
            string Quantidade = objProdutoSincronizado.Quantidade.ToString();
            string Operacao = objProdutoSincronizado.Operacao;
            string Descricao = objProdutoSincronizado.Descricao;
            string Status = objProdutoSincronizado.Status;
            string DataSincronizacao = objProdutoSincronizado.DataSincronizacao.ToString();
            int ExecucaoId = objProdutoSincronizado.ExecucaoId;
            string Execucao = objProdutoSincronizado.Execucao.ToString();

            // Inicia validacao

            /// ???????????

            //se nao tem erro
           // objProdutoSincronizado.Estados = 99;
            objProdutoSincronizadoDao.update(objProdutoSincronizado);
            return;
        }
        public void delete(ProdutoSincronizado objProdutoSincronizado)
        {
            bool verificacao = true;
            //verificando se existe
            ProdutoSincronizado objProdutoSincronizadoAux = new ProdutoSincronizado();
            objProdutoSincronizadoAux.ProdutoSincronizadoId = objProdutoSincronizado.ProdutoSincronizadoId;
            verificacao = objProdutoSincronizadoDao.find(objProdutoSincronizadoAux);
            if (!verificacao)
            {
               // objProdutoSincronizado.Estados = 33;
                return;
            }


           // objProdutoSincronizado.Estados = 99;
            objProdutoSincronizadoDao.delete(objProdutoSincronizado);
            return;
        }
        public bool find(ProdutoSincronizado objProdutoSincronizado)
        {
            return objProdutoSincronizadoDao.find(objProdutoSincronizado);
        }
        public List<ProdutoSincronizado> findAll()
        {
            return objProdutoSincronizadoDao.findAll();
        }

        public List<ProdutoSincronizado> BuscarPorId(string id)
        {
            return objProdutoSincronizadoDao.BuscarPorId(id);
        }
        public List<ProdutoSincronizado> BuscarDetalhePorId(string id)
        {
            return objProdutoSincronizadoDao.BuscarDetalhePorId(id);
        }
        public List<ProdutoSincronizado> BuscarPorEan_Status(string ean)
        {
            return objProdutoSincronizadoDao.BuscarPorEan_Status(ean);
        }
    }
}
