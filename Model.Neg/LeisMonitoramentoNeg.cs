using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class LeisMonitoramentoNeg
    {
        private LeisMonitoramentoDao objLeisMonitoramentoDao;

        public LeisMonitoramentoNeg()
        {
            objLeisMonitoramentoDao = new LeisMonitoramentoDao();

        }

        public void create(LeisMonitoramento objLeisMonitoramento)
        {
            bool verificacao = true;


            string IdLei = objLeisMonitoramento.IdLei.ToString();
            string IdMonitora = objLeisMonitoramento.IdMonitora.ToString();

            //begin verificar duplicidade cpf retorna estado=8
            LeisMonitoramento objLeisMonitoramento1 = new LeisMonitoramento();
            objLeisMonitoramento1.Id = objLeisMonitoramento.Id;
            verificacao = !objLeisMonitoramentoDao.findLeisMonitoramentoPorId(objLeisMonitoramento1);
            if (!verificacao)
            {
                objLeisMonitoramento.Estados = 9;
                return;
            }


            //se nao tem erro
            objLeisMonitoramento.Estados = 99;
            objLeisMonitoramentoDao.create(objLeisMonitoramento);
            return;
        }
        public void update(LeisMonitoramento objLeisMonitoramento)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string IdLei = objLeisMonitoramento.IdLei.ToString();
            string IdMonitora = objLeisMonitoramento.IdMonitora.ToString();


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objLeisMonitoramento.Estados = 99;
            objLeisMonitoramentoDao.update(objLeisMonitoramento);
            return;
        }
        public void delete(LeisMonitoramento objLeisMonitoramento)
        {
            bool verificacao = true;
            //verificando se existe
            LeisMonitoramento objLeisMonitoramentoAux = new LeisMonitoramento();
            objLeisMonitoramentoAux.Id = objLeisMonitoramento.Id;
            verificacao = objLeisMonitoramentoDao.find(objLeisMonitoramentoAux);
            if (!verificacao)
            {
                objLeisMonitoramento.Estados = 33;
                return;
            }


            objLeisMonitoramento.Estados = 99;
            objLeisMonitoramentoDao.delete(objLeisMonitoramento);
            return;
        }
        public bool find(LeisMonitoramento objLeisMonitoramento)
        {
            return objLeisMonitoramentoDao.find(objLeisMonitoramento);
        }
        public List<LeisMonitoramento> findAll()
        {
            return objLeisMonitoramentoDao.findAll();
        }
        public List<LeisMonitoramento> findAllLeisMonitoramento(LeisMonitoramento objLeisMonitoramento)
        {
            return objLeisMonitoramentoDao.findAllLeisMonitoramento(objLeisMonitoramento);
        }

    }
}
