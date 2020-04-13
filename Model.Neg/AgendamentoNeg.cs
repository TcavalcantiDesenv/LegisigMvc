using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class AgendamentoNeg
    {
        private AgendamentoDao objAgendamentoDao;

        public AgendamentoNeg()
        {
            objAgendamentoDao = new AgendamentoDao();

        }

        public void create(Agendamento objAgendamento)
        {
            bool verificacao = true;

            int NomeFantasia = objAgendamento.AgendamentoId;
            string RazaoSocial = objAgendamento.DiaDaSemana;
            string CNPJ = objAgendamento.HoraDeExecucao;

            if (!verificacao)
            {
              //  objAgendamento.Estados = 9;
                return;
            }

            //se nao tem erro
         //   objAgendamento.Estados = 99;
            objAgendamentoDao.create(objAgendamento);
            return;
        }
        public void update(Agendamento objAgendamento)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            int NomeFantasia = objAgendamento.AgendamentoId;
            string RazaoSocial = objAgendamento.DiaDaSemana;
            string CNPJ = objAgendamento.HoraDeExecucao;


            if (!verificacao)
            {
             //   objAgendamento.Estados = 9;
                return;
            }

            //se nao tem erro
        //    objAgendamento.Estados = 99;
            objAgendamentoDao.update(objAgendamento);
            return;
        }
        public void delete(Agendamento objAgendamento)
        {
            bool verificacao = true;
            //verificando se existe
            Agendamento objClienteAux = new Agendamento();
            objClienteAux.AgendamentoId = objAgendamento.AgendamentoId;
            verificacao = objAgendamentoDao.find(objClienteAux);
            if (!verificacao)
            {
            //    objAgendamento.Estados = 33;
                return;
            }


          //  objAgendamento.Estados = 99;
            objAgendamentoDao.delete(objAgendamento);
            return;
        }
        public bool find(Agendamento objCliente)
        {
            return objAgendamentoDao.find(objCliente);
        }
        public List<Agendamento> findAll()
        {
            return objAgendamentoDao.findAll();
        }
    }
}
