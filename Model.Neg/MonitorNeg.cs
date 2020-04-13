using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class MonitorNeg
    {
        private MonitorDao objMonitorDao;

        public MonitorNeg()
        {
            objMonitorDao = new MonitorDao();

        }

        public void create(Monitor1 objMonitor)
        {
            bool verificacao = true;


            string Metodos = objMonitor.Metodos;
            string Tipo = objMonitor.Tipo;
            string Finalidade = objMonitor.Finalidade;
            string Frequencia = objMonitor.Frequencia;
            string Responsavel = objMonitor.Responsavel;
            string Situacao = objMonitor.Situacao;
            string Validade = objMonitor.Validade.ToString();
            string ProxData = objMonitor.ProxData.ToString();
            // int Estados = objMonitor.Estados;
            string Prazo = objMonitor.Prazo.ToString();
            string Observacao = objMonitor.Observacao;
            string IdCondicionante = objMonitor.IdCondicionante.ToString();
            string IdLicenca = objMonitor.IdLicenca.ToString();
            string IdLei = objMonitor.IdLei.ToString();

            //begin verificar duplicidade cpf retorna estado=8
            Monitor1 objMonitor1 = new Monitor1();
            objMonitor1.Id = objMonitor.Id;
            verificacao = !objMonitorDao.findMonitorPorId(objMonitor1);
            if (!verificacao)
            {
                objMonitor.Estados = 9;
                return;
            }


            //se nao tem erro
            objMonitor.Estados = 99;
            objMonitorDao.create(objMonitor);
            return;
        }
        public void update(Monitor1 objMonitor)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Metodos = objMonitor.Metodos;
            string Tipo = objMonitor.Tipo;
            string Finalidade = objMonitor.Finalidade;
            string Frequencia = objMonitor.Frequencia;
            string Responsavel = objMonitor.Responsavel;
            string Situacao = objMonitor.Situacao;
            string Validade = objMonitor.Validade.ToString();
            string ProxData = objMonitor.ProxData.ToString();
            // int Estados = objMonitor.Estados;
            string Prazo = objMonitor.Prazo.ToString();
            string Observacao = objMonitor.Observacao;
            string IdCondicionante = objMonitor.IdCondicionante.ToString();
            string IdLicenca = objMonitor.IdLicenca.ToString();
            string IdLei = objMonitor.IdLei.ToString();


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objMonitor.Estados = 99;
            objMonitorDao.update(objMonitor);
            return;
        }
        public void delete(Monitor1 objMonitor)
        {
            bool verificacao = true;
            //verificando se existe
            Monitor1 objMonitorAux = new Monitor1();
            objMonitorAux.Id = objMonitor.Id;
            verificacao = objMonitorDao.find(objMonitorAux);
            if (!verificacao)
            {
                objMonitor.Estados = 33;
                return;
            }


            objMonitor.Estados = 99;
            objMonitorDao.delete(objMonitor);
            return;
        }
        public bool find(Monitor1 objMonitor)
        {
            return objMonitorDao.find(objMonitor);
        }
        public List<Monitor1> findAll()
        {
            return objMonitorDao.findAll();
        }
        public List<Monitor1> findAllMonitor(Monitor1 objMonitor)
        {
            return objMonitorDao.findAllMonitor(objMonitor);
        }

    }
}
