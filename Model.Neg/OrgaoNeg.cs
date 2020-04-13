using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class OrgaoNeg
    {
        private OrgaoDao objOrgaoDao;

        public OrgaoNeg()
        {
            objOrgaoDao = new OrgaoDao();

        }

        public void create(Orgao objOrgao)
        {
            bool verificacao = true;


            string Descricao = objOrgao.Descricao;

            //begin verificar duplicidade cpf retorna estado=8
            Orgao objOrgao1 = new Orgao();
            objOrgao1.Id = objOrgao.Id;
            verificacao = !objOrgaoDao.findOrgaoPorId(objOrgao1);
            if (!verificacao)
            {
                objOrgao.Estados = 9;
                return;
            }


            //se nao tem erro
            objOrgao.Estados = 99;
            objOrgaoDao.create(objOrgao);
            return;
        }
        public void update(Orgao objOrgao)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Descricao = objOrgao.Descricao;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objOrgao.Estados = 99;
            objOrgaoDao.update(objOrgao);
            return;
        }
        public void delete(Orgao objOrgao)
        {
            bool verificacao = true;
            //verificando se existe
            Orgao objOrgaoAux = new Orgao();
            objOrgaoAux.Id = objOrgao.Id;
            verificacao = objOrgaoDao.find(objOrgaoAux);
            if (!verificacao)
            {
                objOrgao.Estados = 33;
                return;
            }


            objOrgao.Estados = 99;
            objOrgaoDao.delete(objOrgao);
            return;
        }
        public bool find(Orgao objOrgao)
        {
            return objOrgaoDao.find(objOrgao);
        }
        public List<Orgao> findAll()
        {
            return objOrgaoDao.findAll();
        }
        public List<Orgao> findAllOrgao(Orgao objOrgao)
        {
            return objOrgaoDao.findAllOrgao(objOrgao);
        }

    }
}
