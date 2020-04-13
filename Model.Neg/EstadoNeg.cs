using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class EstadoNeg
    {
                private EstadoDao objEstadoDao;

        public EstadoNeg()
        {
            objEstadoDao = new EstadoDao();

        }

        public void create(Estado objEstado)
        {
            bool verificacao = true;


            string Nome = objEstado.Nome;
            string UF = objEstado.UF;
            string Pais = objEstado.Pais;

            
            //begin verificar duplicidade cpf retorna estado=8
            Estado objEstado1 = new Estado();
            objEstado1.Id = objEstado.Id;
            verificacao = !objEstadoDao.findEstadoPorId(objEstado1);
            if (!verificacao)
            {
                objEstado.Estados = 9;
                return;
            }


            //se nao tem erro
            objEstado.Estados = 99;
            objEstadoDao.create(objEstado);
            return;
        }
        public void update(Estado objEstado)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Nome = objEstado.Nome;
            string UF = objEstado.UF;
            string Pais = objEstado.Pais;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objEstado.Estados = 99;
            objEstadoDao.update(objEstado);
            return;
        }
        public void delete(Estado objEstado)
        {
            bool verificacao = true;
            //verificando se existe
            Estado objEstadoAux = new Estado();
            objEstadoAux.Id = objEstado.Id;
            verificacao = objEstadoDao.find(objEstadoAux);
            if (!verificacao)
            {
                objEstado.Estados = 33;
                return;
            }


            objEstado.Estados = 99;
            objEstadoDao.delete(objEstado);
            return;
        }
        public bool find(Estado objEstado)
        {
            return objEstadoDao.find(objEstado);
        }
        public List<Estado> findAll()
        {
            return objEstadoDao.findAll();
        }
        public List<Estado> findAllEstado(Estado objEstado)
        {
            return objEstadoDao.findAllEstado(objEstado);
        }

    }
}
