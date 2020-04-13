using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class CondicaoOpNeg
    {
        private CondicaoOpDao objCondicaoOpDao;

        public CondicaoOpNeg()
        {
            objCondicaoOpDao = new CondicaoOpDao();

        }

        public void create(CondicaoOp objCondicaoOp)
        {
            bool verificacao = true;


            string Sigla = objCondicaoOp.Sigla;
            string Descricao = objCondicaoOp.Descricao;

            //begin verificar duplicidade cpf retorna estado=8
            CondicaoOp objCondicaoOp1 = new CondicaoOp();
            objCondicaoOp1.Id = objCondicaoOp.Id;
            verificacao = !objCondicaoOpDao.findCondicaoPorId(objCondicaoOp1);
            if (!verificacao)
            {
                objCondicaoOp.Estados = 9;
                return;
            }


            //se nao tem erro
            objCondicaoOp.Estados = 99;
            objCondicaoOpDao.create(objCondicaoOp);
            return;
        }
        public void update(CondicaoOp objCondicaoOp)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Sigla = objCondicaoOp.Sigla;
            string Descricao = objCondicaoOp.Descricao;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objCondicaoOp.Estados = 99;
            objCondicaoOpDao.update(objCondicaoOp);
            return;
        }
        public void delete(CondicaoOp objCondicaoOp)
        {
            bool verificacao = true;
            //verificando se existe
            CondicaoOp objCondicaoOpAux = new CondicaoOp();
            objCondicaoOpAux.Id = objCondicaoOp.Id;
            verificacao = objCondicaoOpDao.find(objCondicaoOpAux);
            if (!verificacao)
            {
                objCondicaoOp.Estados = 33;
                return;
            }


            objCondicaoOp.Estados = 99;
            objCondicaoOpDao.delete(objCondicaoOp);
            return;
        }
        public bool find(CondicaoOp objCondicaoOp)
        {
            return objCondicaoOpDao.find(objCondicaoOp);
        }
        public List<CondicaoOp> findAll()
        {
            return objCondicaoOpDao.findAll();
        }
        public List<CondicaoOp> findAllCondicaoOp(CondicaoOp objCondicaoOp)
        {
            return objCondicaoOpDao.findAllCondicaoOp(objCondicaoOp);
        }
    }

}

