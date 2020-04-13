using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class AmbitoNeg
    {
        private AmbitoDao objAmbitoDao;

        public AmbitoNeg()
        {
            objAmbitoDao = new AmbitoDao();

        }

        public void create(Ambito objAmbito)
        {
            bool verificacao = true;


            string Descricao = objAmbito.Descricao;

            //begin verificar duplicidade cpf retorna estado=8
            Ambito objAmbito1 = new Ambito();
            objAmbito1.Id = objAmbito.Id;
            verificacao = !objAmbitoDao.findAmbitoDescricao(objAmbito1);
            if (!verificacao)
            {
                objAmbito.Estados = 9;
                return;
            }


            //se nao tem erro
            objAmbito.Estados = 99;
            objAmbitoDao.create(objAmbito);
            return;
        }
        public void update(Ambito objAmbito)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Descricao = objAmbito.Descricao;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objAmbito.Estados = 99;
            objAmbitoDao.update(objAmbito);
            return;
        }
        public void delete(Ambito objAmbito)
        {
            bool verificacao = true;
            //verificando se existe
            Ambito objAmbitoAux = new Ambito();
            objAmbitoAux.Id = objAmbito.Id;
            verificacao = objAmbitoDao.find(objAmbitoAux);
            if (!verificacao)
            {
                objAmbito.Estados = 33;
                return;
            }


            objAmbito.Estados = 99;
            objAmbitoDao.delete(objAmbito);
            return;
        }
        public bool find(Ambito objAmbito)
        {
            return objAmbitoDao.find(objAmbito);
        }
        public List<Ambito> findAll()
        {
            return objAmbitoDao.findAll();
        }
        public List<Ambito> findAllAmbito(Ambito objAmbito)
        {
            return objAmbitoDao.findAllAmbito(objAmbito);
        }

    }
}
