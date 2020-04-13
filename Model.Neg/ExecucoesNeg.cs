using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class ExecucoesNeg
    {
        private ExecucoesDao objExecucaoDao;

        public ExecucoesNeg()
        {
            objExecucaoDao = new ExecucoesDao();

        }

        public void create(Execucao objExecucao)
        {
            bool verificacao = true;

            //       int ExecucaoId = objExecucao.ExecucaoId;
            string Inicio = objExecucao.Inicio.ToString();
            string Fim = objExecucao.Fim.ToString();
            string Detalhes = objExecucao.Detalhes;
            string Status = objExecucao.Status;

            //se nao tem erro
          //  objExecucao.Estados = 99;
            objExecucaoDao.create(objExecucao);
            return;
        }
        public void update(Execucao objExecucao)
        {
            bool verificacao = true;
            string ID = objExecucao.ExecucaoId.ToString();
            string Inicio = objExecucao.Inicio.ToString();
            string Fim = objExecucao.Fim.ToString();
            string Detalhes = objExecucao.Detalhes;
            string Status = objExecucao.Status;

            // Inicia validacao

            /// ???????????

            //se nao tem erro
          //  objExecucao.Estados = 99;
            objExecucaoDao.update(objExecucao);
            return;
        }
        public void delete(Execucao objExecucao)
        {
            bool verificacao = true;
            //verificando se existe
            Execucao objExecucaoAux = new Execucao();
            objExecucaoAux.ExecucaoId = objExecucao.ExecucaoId;
            verificacao = objExecucaoDao.find(objExecucaoAux);
            if (!verificacao)
            {
          //      objExecucao.Estados = 33;
                return;
            }


         //   objExecucao.Estados = 99;
            objExecucaoDao.delete(objExecucao);
            return;
        }
        public bool find(Execucao objExecucao)
        {
            return objExecucaoDao.find(objExecucao);
        }
        public int ExecucaoIdAtual()
        {
            return objExecucaoDao.ExecucaoIdAtual();
        }

        public List<Execucao> findAll()
        {
            return objExecucaoDao.findAll();
        }
        public List<Execucao> BuscarPorId(string id)
        {
            return objExecucaoDao.BuscarPorId(id);
        }
    }
}
