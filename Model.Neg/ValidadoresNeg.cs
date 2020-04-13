using Model.Dao;
using System.Collections.Generic;

namespace Model.Neg
{
    public class ValidadoresNeg
    {
        private ValidadoresDao objValidadoresDao;

        public ValidadoresNeg()
        {
            objValidadoresDao = new ValidadoresDao();

        }

        public void create(Validadores objValidadores)
        {
            bool verificacao = true;


            string IdCliente = objValidadores.IdCliente.ToString() ;
            string Usuário = objValidadores.Usuário;
            string Operacao = objValidadores.Operacao;
            string Email = objValidadores.Email;

            //begin verificar duplicidade cpf retorna estado=8
            Validadores objValidadores1 = new Validadores();
            objValidadores1.Id = objValidadores.Id;
            verificacao = !objValidadoresDao.findValidadoresPorId(objValidadores1);
            if (!verificacao)
            {
                objValidadores.Estados = 9;
                return;
            }


            //se nao tem erro
            objValidadores.Estados = 99;
            objValidadoresDao.create(objValidadores);
            return;
        }
        public void update(Validadores objValidadores)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string IdCliente = objValidadores.IdCliente.ToString();
            string Usuário = objValidadores.Usuário;
            string Operacao = objValidadores.Operacao;
            string Email = objValidadores.Email;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objValidadores.Estados = 99;
            objValidadoresDao.update(objValidadores);
            return;
        }
        public void delete(Validadores objValidadores)
        {
            bool verificacao = true;
            //verificando se existe
            Validadores objValidadoresAux = new Validadores();
            objValidadoresAux.Id = objValidadores.Id;
            verificacao = objValidadoresDao.find(objValidadoresAux);
            if (!verificacao)
            {
                objValidadores.Estados = 33;
                return;
            }


            objValidadores.Estados = 99;
            objValidadoresDao.delete(objValidadores);
            return;
        }
        public bool find(Validadores objValidadores)
        {
            return objValidadoresDao.find(objValidadores);
        }
        public List<Validadores> findAll()
        {
            return objValidadoresDao.findAll();
        }
        public List<Validadores> findAllValidadores(Validadores objValidadores)
        {
            return objValidadoresDao.findAllValidadores(objValidadores);
        }

    }
}
