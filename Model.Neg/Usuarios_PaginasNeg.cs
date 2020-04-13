using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class Usuarios_PaginasNeg
    {
        private Usuarios_PaginasDao objUsuarios_PaginasDao;

        public Usuarios_PaginasNeg()
        {
            objUsuarios_PaginasDao = new Usuarios_PaginasDao();

        }

        public void create(Usuarios_Paginas objUsuarios_Paginas)
        {
            bool verificacao = true;


            string IdUsuario = objUsuarios_Paginas.IdUsuario.ToString();
            string Codigo = objUsuarios_Paginas.Codigo.ToString();
            string Pagina = objUsuarios_Paginas.Pagina;

            //begin verificar duplicidade cpf retorna estado=8
            Usuarios_Paginas objUsuarios1 = new Usuarios_Paginas();
            objUsuarios1.id = objUsuarios_Paginas.id;
            verificacao = !objUsuarios_PaginasDao.findUsuarios_PaginasPorId(objUsuarios1);
            if (!verificacao)
            {
                objUsuarios_Paginas.Estados = 9;
                return;
            }


            //se nao tem erro
            objUsuarios_Paginas.Estados = 99;
            objUsuarios_PaginasDao.create(objUsuarios_Paginas);
            return;
        }
        public void update(Usuarios_Paginas objUsuarios_Paginas)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string IdUsuario = objUsuarios_Paginas.IdUsuario.ToString();
            string Codigo = objUsuarios_Paginas.Codigo.ToString();
            string Pagina = objUsuarios_Paginas.Pagina;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objUsuarios_Paginas.Estados = 99;
            objUsuarios_PaginasDao.update(objUsuarios_Paginas);
            return;
        }
        public void delete(Usuarios_Paginas objUsuarios_Paginas)
        {
            bool verificacao = true;
            //verificando se existe
            Usuarios_Paginas objUsuarios_PaginasAux = new Usuarios_Paginas();
            objUsuarios_PaginasAux.id = objUsuarios_Paginas.id;
            verificacao = objUsuarios_PaginasDao.find(objUsuarios_PaginasAux);
            if (!verificacao)
            {
                objUsuarios_Paginas.Estados = 33;
                return;
            }


            objUsuarios_Paginas.Estados = 99;
            objUsuarios_PaginasDao.delete(objUsuarios_Paginas);
            return;
        }
        public bool find(Usuarios_Paginas objUsuarios_Paginas)
        {
            return objUsuarios_PaginasDao.find(objUsuarios_Paginas);
        }
        public List<Usuarios_Paginas> findAll()
        {
            return objUsuarios_PaginasDao.findAll();
        }
        public List<Usuarios_Paginas> findAllUsuarios_Paginas(Usuarios_Paginas objUsuarios_Paginas)
        {
            return objUsuarios_PaginasDao.findAllUsuarios_Paginas(objUsuarios_Paginas);
        }

    }
}
