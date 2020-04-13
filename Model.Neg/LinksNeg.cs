using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class LinksNeg
    {
        private LinksDao objLinksDao;

        public LinksNeg()
        {
            objLinksDao = new LinksDao();

        }

        public void create(Links objLinks)
        {
            bool verificacao = true;


            string Sistema = objLinks.Sistema;
            string Ambito = objLinks.Ambito;
            string Orgao = objLinks.Orgao;
            string Numero = objLinks.Numero;
            string Tema = objLinks.Tema;
            string Link = objLinks.Link;

            
            //begin verificar duplicidade cpf retorna estado=8
            Links objLinks1 = new Links();
            objLinks1.id = objLinks.id;
            verificacao = !objLinksDao.findLinksPorId(objLinks1);
            if (!verificacao)
            {
                objLinks.Estados = 9;
                return;
            }


            //se nao tem erro
            objLinks.Estados = 99;
            objLinksDao.create(objLinks);
            return;
        }
        public void update(Links objLinks)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Sistema = objLinks.Sistema;
            string Ambito = objLinks.Ambito;
            string Orgao = objLinks.Orgao;
            string Numero = objLinks.Numero;
            string Tema = objLinks.Tema;
            string Link = objLinks.Link;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objLinks.Estados = 99;
            objLinksDao.update(objLinks);
            return;
        }
        public void delete(Links objLinks)
        {
            bool verificacao = true;
            //verificando se existe
            Links objLinksAux = new Links();
            objLinksAux.id = objLinks.id;
            verificacao = objLinksDao.find(objLinksAux);
            if (!verificacao)
            {
                objLinks.Estados = 33;
                return;
            }


            objLinks.Estados = 99;
            objLinksDao.delete(objLinks);
            return;
        }
        public bool find(Links objLinks)
        {
            return objLinksDao.find(objLinks);
        }
        public List<Links> findAll()
        {
            return objLinksDao.findAll();
        }
        public List<Links> findAllLinks(Links objLinks)
        {
            return objLinksDao.findAllLinks(objLinks);
        }

    }
}
