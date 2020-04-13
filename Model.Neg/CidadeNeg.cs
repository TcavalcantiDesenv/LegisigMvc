using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class CidadeNeg
    {
        private CidadeDao objCidadeDao;

        public CidadeNeg()
        {
            objCidadeDao = new CidadeDao();

        }

        public void create(Cidade objCidade)
        {
            bool verificacao = true;


            string Id = objCidade.Id.ToString();
            string Nome = objCidade.Nome;
            string Estado = objCidade.Estado.ToString();

            //begin verificar duplicidade cpf retorna estado=8
            Cidade objCidade1 = new Cidade();
            objCidade1.Id = objCidade.Id;
            verificacao = objCidadeDao.find(objCidade1);
            if (!verificacao)
            {
                objCidade.Estados = 9;
                return;
            }


            //se nao tem erro
            objCidade.Estados = 99;
            objCidadeDao.create(objCidade);
            return;
        }
        public void update(Cidade objCidade)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Id = objCidade.Id.ToString();
            string Nome = objCidade.Nome;
            string Estado = objCidade.Estado.ToString();


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objCidade.Estados = 99;
            objCidadeDao.update(objCidade);
            return;
        }
        public void delete(Cidade objCidade)
        {
            bool verificacao = true;
            //verificando se existe
            Cidade objCidadeAux = new Cidade();
            objCidadeAux.Id = objCidade.Id;
            verificacao = objCidadeDao.find(objCidadeAux);
            if (!verificacao)
            {
                objCidade.Estados = 33;
                return;
            }


            objCidade.Estados = 99;
            objCidadeDao.delete(objCidade);
            return;
        }
        public bool find(Cidade objCidade)
        {
            return objCidadeDao.find(objCidade);
        }
        public List<Cidade> findAll()
        {
            return objCidadeDao.findAll();
        }
        public List<Cidade> findAllCidade(Cidade objCidade)
        {
            return objCidadeDao.findAllCidade(objCidade);
        }

    }
}
