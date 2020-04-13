using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class PaginasNeg
    {
        private PaginasDao objPaginasDao;

        public PaginasNeg()
        {
            objPaginasDao = new PaginasDao();

        }

        public void create(Paginas objPaginas)
        {
            bool verificacao = true;


            string Codigo = objPaginas.Codigo.ToString();
            string Pagina = objPaginas.Pagina;

            //begin verificar duplicidade cpf retorna estado=8
            Paginas objPaginas1 = new Paginas();
            objPaginas1.Id = objPaginas.Id;
            verificacao = !objPaginasDao.findPaginasPorId(objPaginas1);
            if (!verificacao)
            {
                objPaginas.Estados = 9;
                return;
            }


            //se nao tem erro
            objPaginas.Estados = 99;
            objPaginasDao.create(objPaginas);
            return;
        }
        public void update(Paginas objPaginas)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Codigo = objPaginas.Codigo.ToString();
            string Pagina = objPaginas.Pagina;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objPaginas.Estados = 99;
            objPaginasDao.update(objPaginas);
            return;
        }
        public void delete(Paginas objPaginas)
        {
            bool verificacao = true;
            //verificando se existe
            Paginas objPaginasAux = new Paginas();
            objPaginasAux.Id = objPaginas.Id;
            verificacao = objPaginasDao.find(objPaginasAux);
            if (!verificacao)
            {
                objPaginas.Estados = 33;
                return;
            }


            objPaginas.Estados = 99;
            objPaginasDao.delete(objPaginas);
            return;
        }
        public bool find(Paginas objPaginas)
        {
            return objPaginasDao.find(objPaginas);
        }
        public List<Paginas> findAll()
        {
            return objPaginasDao.findAll();
        }
        public List<Paginas> findAllPaginas(Paginas objPaginas)
        {
            return objPaginasDao.findAllPagina(objPaginas);
        }

    }
}
