using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class ProcessosNeg
    {
        private ProcessosDao objProcessosDao;

        public ProcessosNeg()
        {
            objProcessosDao = new ProcessosDao();

        }

        public void create(Processos objProcessos)
        {
            bool verificacao = true;


            string Processo = objProcessos.Processo;
            string Relacionado = objProcessos.Relacionado;
            string CicloVida = objProcessos.CicloVida;

            //begin verificar duplicidade cpf retorna estado=8
            Processos objProcessos1 = new Processos();
            objProcessos1.Id = objProcessos.Id;
            verificacao = !objProcessosDao.findProcessosPorId(objProcessos1);
            if (!verificacao)
            {
                objProcessos.Estados = 9;
                return;
            }


            //se nao tem erro
            objProcessos.Estados = 99;
            objProcessosDao.create(objProcessos);
            return;
        }
        public void update(Processos objProcessos)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Processo = objProcessos.Processo;
            string Relacionado = objProcessos.Relacionado;
            string CicloVida = objProcessos.CicloVida;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objProcessos.Estados = 99;
            objProcessosDao.update(objProcessos);
            return;
        }
        public void delete(Processos objProcessos)
        {
            bool verificacao = true;
            //verificando se existe
            Processos objProcessosAux = new Processos();
            objProcessosAux.Id = objProcessos.Id;
            verificacao = objProcessosDao.find(objProcessosAux);
            if (!verificacao)
            {
                objProcessos.Estados = 33;
                return;
            }


            objProcessos.Estados = 99;
            objProcessosDao.delete(objProcessos);
            return;
        }
        public bool find(Processos objProcessos)
        {
            return objProcessosDao.find(objProcessos);
        }
        public List<Processos> findAll()
        {
            return objProcessosDao.findAll();
        }
        public List<Processos> findAllProcessos(Processos objProcessos)
        {
            return objProcessosDao.findAllProcessos(objProcessos);
        }

    }
}
