
using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Neg
{
    public class SistemasNeg
    {
        private SistemasDao objSistemasDao;

        public SistemasNeg()
        {
            objSistemasDao = new SistemasDao();

        }

        public void create(Sistemas objSistemas)
        {
            bool verificacao = true;


            string Sistema = objSistemas.Sistema;

            //begin verificar duplicidade cpf retorna estado=8
            Sistemas objSistemas1 = new Sistemas();
            objSistemas1.Id = objSistemas.Id;
            verificacao = !objSistemasDao.findSistemasPorId(objSistemas1);
            if (!verificacao)
            {
           //     objSistemas.Estados = 9;
                return;
            }


            //se nao tem erro
          //  objSistemas.Estados = 99;
            objSistemasDao.create(objSistemas);
            return;
        }
        public void update(Sistemas objSistemas)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Sistema = objSistemas.Sistema;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
          //  objSistemas.Estados = 99;
            objSistemasDao.update(objSistemas);
            return;
        }
        public void delete(Sistemas objSistemas)
        {
            bool verificacao = true;
            //verificando se existe
            Sistemas objSistemasAux = new Sistemas();
            objSistemasAux.Id = objSistemas.Id;
            verificacao = objSistemasDao.find(objSistemasAux);
            if (!verificacao)
            {
            //    objSistemas.Estados = 33;
                return;
            }


           // objSistemas.Estados = 99;
            objSistemasDao.delete(objSistemas);
            return;
        }
        public bool find(Sistemas objSistemas)
        {
            return objSistemasDao.find(objSistemas);
        }
        public List<Sistemas> findAll()
        {
            return objSistemasDao.findAll();
        }
        public List<Sistemas> findAllSistemas(Sistemas objSistemas)
        {
            return objSistemasDao.findAllSistemas(objSistemas);
        }

    }
}
