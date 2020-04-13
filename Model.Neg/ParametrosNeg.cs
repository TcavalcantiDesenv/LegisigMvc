using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class ParametrosNeg
    {
        private ParametrosDao objParametrosDao;

        public ParametrosNeg()
        {
            objParametrosDao = new ParametrosDao();

        }

        public void create(Parametros objParametros)
        {
            bool verificacao = true;


            string Capitulo = objParametros.Capitulo;
            string Item = objParametros.Item;
            //string Parametro = objParametros.Parametro;
            string Obrigacao = objParametros.Obrigacao.ToString();
            string IDLegisGeral = objParametros.IDLegisGeral.ToString();
            string IDCliente = objParametros.IDCliente.ToString();
            string Numero = objParametros.Numero.ToString();
            string Aplicavel = objParametros.Aplicavel.ToString();
            // int Estados = // objParametros.Estados;
            string lei = objParametros.lei;
            string param = objParametros.param;
            string Conhecimento = objParametros.Conhecimento.ToString();

            //begin verificar duplicidade cpf retorna estado=8
            Parametros objParametros1 = new Parametros();
            objParametros1.Id = objParametros.Id;
            verificacao = !objParametrosDao.findParametrosPorId(objParametros1);
            if (!verificacao)
            {
                // objParametros.Estados = 9;
                return;
            }


            //se nao tem erro
            // objParametros.Estados = 99;
            objParametrosDao.create(objParametros);
            return;
        }
        public void update(Parametros objParametros)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Capitulo = objParametros.Capitulo;
            string Item = objParametros.Item;
            //string Parametro = objParametros.Parametro;
            string Obrigacao = objParametros.Obrigacao.ToString();
            string IDLegisGeral = objParametros.IDLegisGeral.ToString();
            string IDCliente = objParametros.IDCliente.ToString();
            string Numero = objParametros.Numero.ToString();
            string Aplicavel = objParametros.Aplicavel.ToString();
            // int Estados = // objParametros.Estados;
            string lei = objParametros.lei;
            string param = objParametros.param;
            string Conhecimento = objParametros.Conhecimento.ToString();


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            // objParametros.Estados = 99;
            objParametrosDao.update(objParametros);
            return;
        }
        public void delete(Parametros objParametros)
        {
            bool verificacao = true;
            //verificando se existe
            Parametros objParametrosAux = new Parametros();
            objParametrosAux.Id = objParametros.Id;
            verificacao = objParametrosDao.find1(objParametrosAux);
            if (!verificacao)
            {
                // objParametros.Estados = 33;
                return;
            }


            // objParametros.Estados = 99;
            objParametrosDao.delete(objParametros);
            return;
        }
        //public bool find(Parametros objParametros)
        //{
        //    return objParametrosDao.find(objParametros);
        //}
        public List<Parametros> findAll()
        {
            return objParametrosDao.findAll();
        }
        public List<Parametros> find(Parametros objParametros)
        {
            return objParametrosDao.find(objParametros);
        }
        public List<Parametros> findAllParametros(Parametros objParametros)
        {
            return objParametrosDao.FindAllParametros(objParametros);
        }

    }
}
