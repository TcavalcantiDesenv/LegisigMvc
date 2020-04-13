using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class ControleOPNeg
    {
        private ControleOPDao objControleOPDao;

        public ControleOPNeg()
        {
            objControleOPDao = new ControleOPDao();

        }

        public void create(ControleOP objControleOP)
        {
            bool verificacao = true;


            string Id = objControleOP.Id.ToString();
            string Aspecto = objControleOP.Aspecto.ToString();
            string Acao = objControleOP.Acao;
            string SimNao = objControleOP.SimNao;
            string EvitImpacAmb = objControleOP.EvitImpacAmb;
            string Ocorrencia = objControleOP.Ocorrencia;
            string Oportunidade = objControleOP.Oportunidade;

            
            //begin verificar duplicidade cpf retorna estado=8
            ControleOP objControleOP1 = new ControleOP();
            objControleOP1.Id = objControleOP.Id;
            verificacao = !objControleOPDao.findControleOPPorId(objControleOP1);
            if (!verificacao)
            {
                objControleOP.Estados = 9;
                return;
            }


            //se nao tem erro
            objControleOP.Estados = 99;
            objControleOPDao.create(objControleOP);
            return;
        }
        public void update(ControleOP objControleOP)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Id = objControleOP.Id.ToString();
            string Aspecto = objControleOP.Aspecto.ToString();
            string Acao = objControleOP.Acao;
            string SimNao = objControleOP.SimNao;
            string EvitImpacAmb = objControleOP.EvitImpacAmb;
            string Ocorrencia = objControleOP.Ocorrencia;
            string Oportunidade = objControleOP.Oportunidade;
            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objControleOP.Estados = 99;
            objControleOPDao.update(objControleOP);
            return;
        }
        public void delete(ControleOP objControleOP)
        {
            bool verificacao = true;
            //verificando se existe
            ControleOP objControleOPAux = new ControleOP();
            objControleOPAux.Id = objControleOP.Id;
            verificacao = objControleOPDao.find(objControleOPAux);
            if (!verificacao)
            {
                objControleOP.Estados = 33;
                return;
            }


            objControleOP.Estados = 99;
            objControleOPDao.delete(objControleOP);
            return;
        }
        public bool find(ControleOP objCliente)
        {
            return objControleOPDao.find(objCliente);
        }
        public List<ControleOP> findAll()
        {
            return objControleOPDao.findAll();
        }
        public List<ControleOP> findAllControleOP(ControleOP objControleOP)
        {
            return objControleOPDao.findAllControleOP(objControleOP);
        }

    }
}
