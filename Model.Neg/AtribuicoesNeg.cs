using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class AtribuicoesNeg
    {
        private AtribuicoesDao objAtribuicoesDao;

        public AtribuicoesNeg()
        {
            objAtribuicoesDao = new AtribuicoesDao();

        }

        public void create(Atribuicoes objAtribuicoes)
        {
            bool verificacao = true;


            string ID = objAtribuicoes.ID.ToString();
            string Codigo = objAtribuicoes.Codigo.ToString();
            string Atribuicao = objAtribuicoes.Atribuicao;
            string IdPagina = objAtribuicoes.IdPagina.ToString();

            //begin verificar duplicidade cpf retorna estado=8
            Atribuicoes objAtribuicoes1 = new Atribuicoes();
            objAtribuicoes1.ID = objAtribuicoes.ID;
            verificacao = !objAtribuicoesDao.findAtribuicoesPorId(objAtribuicoes1);
            if (!verificacao)
            {
                objAtribuicoes.Estados = 9;
                return;
            }


            //se nao tem erro
            objAtribuicoes.Estados = 99;
            objAtribuicoesDao.create(objAtribuicoes);
            return;
        }
        public void update(Atribuicoes objAtribuicoes)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string ID = objAtribuicoes.ID.ToString();
            string Codigo = objAtribuicoes.Codigo.ToString();
            string Atribuicao = objAtribuicoes.Atribuicao;
            string IdPagina = objAtribuicoes.IdPagina.ToString();


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objAtribuicoes.Estados = 99;
            objAtribuicoesDao.update(objAtribuicoes);
            return;
        }
        public void delete(Atribuicoes objAtribuicoes)
        {
            bool verificacao = true;
            //verificando se existe
            Atribuicoes objClienteAux = new Atribuicoes();
            objClienteAux.ID = objAtribuicoes.ID;
            verificacao = objAtribuicoesDao.find(objClienteAux);
            if (!verificacao)
            {
                objAtribuicoes.Estados = 33;
                return;
            }


            objAtribuicoes.Estados = 99;
            objAtribuicoesDao.delete(objAtribuicoes);
            return;
        }
        public bool find(Atribuicoes objAtribuicoes)
        {
            return objAtribuicoesDao.find(objAtribuicoes);
        }
        public List<Atribuicoes> findAll()
        {
            return objAtribuicoesDao.findAll();
        }
        public List<Atribuicoes> findAllAtribuicoes(Atribuicoes objAtribuicoes)
        {
            return objAtribuicoesDao.findAllAtribuicoes(objAtribuicoes);
        }

    }
}
