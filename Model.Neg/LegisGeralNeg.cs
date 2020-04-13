using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class LegisGeralNeg
    {
        private LegisGeralDao objLegisGeralDao;

        public LegisGeralNeg()
        {
            objLegisGeralDao = new LegisGeralDao();

        }

        public void create(LegisGeral objLegisGeral)
        {
            bool verificacao = true;


            string Sistema = objLegisGeral.Sistema;
            string Ambito = objLegisGeral.Ambito;
            string Numero = objLegisGeral.Numero;
            string Ano = objLegisGeral.Ano;
            string Orgao = objLegisGeral.Orgao;
            string Tema = objLegisGeral.Tema;
            string Ementa = objLegisGeral.Ementa;
            string Tipo = objLegisGeral.Tipo;
            // int Estados = objLegisGeral.Estados;
            string lei = objLegisGeral.lei;
            string Data = objLegisGeral.Data.ToString();
            string link = objLegisGeral.link;
            string Localidade = objLegisGeral.Localidade;
            string Estado = objLegisGeral.Estado;
            string Pais = objLegisGeral.Pais;
            string Municipio = objLegisGeral.Municipio;
            // string IdUsuario = objLegisGeral.IdUsuario;
            string Arqpdf = objLegisGeral.Arqpdf;

            //begin verificar duplicidade cpf retorna estado=8
            LegisGeral objLegisGeral1 = new LegisGeral();
            objLegisGeral1.Id = objLegisGeral.Id;
            verificacao = !objLegisGeralDao.findLegisGeralPorId(objLegisGeral1);
            if (!verificacao)
            {
             //   objLegisGeral.Estados = 9;
                return;
            }


            //se nao tem erro
          //  objLegisGeral.Estados = 99;
            objLegisGeralDao.create(objLegisGeral);
            return;
        }
        public void update(LegisGeral objLegisGeral)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Sistema = objLegisGeral.Sistema;
            string Ambito = objLegisGeral.Ambito;
            string Numero = objLegisGeral.Numero;
            string Ano = objLegisGeral.Ano;
            string Orgao = objLegisGeral.Orgao;
            string Tema = objLegisGeral.Tema;
            string Ementa = objLegisGeral.Ementa;
            string Tipo = objLegisGeral.Tipo;
            // int Estados = objLegisGeral.Estados;
            string lei = objLegisGeral.lei;
            string Data = objLegisGeral.Data.ToString();
            string link = objLegisGeral.link;
            string Localidade = objLegisGeral.Localidade;
            string Estado = objLegisGeral.Estado;
            string Pais = objLegisGeral.Pais;
            string Municipio = objLegisGeral.Municipio;
            // string IdUsuario = objLegisGeral.IdUsuario;
            string Arqpdf = objLegisGeral.Arqpdf;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
          //  objLegisGeral.Estados = 99;
            objLegisGeralDao.update(objLegisGeral);
            return;
        }
        public void delete(LegisGeral objLegisGeral)
        {
            bool verificacao = true;
            //verificando se existe
            LegisGeral objLegisGeralAux = new LegisGeral();
            objLegisGeralAux.Id = objLegisGeral.Id;
            verificacao = objLegisGeralDao.find(objLegisGeralAux);
            if (!verificacao)
            {
          //      objLegisGeral.Estados = 33;
                return;
            }


        //    objLegisGeral.Estados = 99;
            objLegisGeralDao.delete(objLegisGeral);
            return;
        }
        public bool find(LegisGeral objLegisGeral)
        {
            return objLegisGeralDao.find(objLegisGeral);
        }
        public List<LegisGeral> findAll()
        {
            return objLegisGeralDao.findAll();
        }
        public List<LegisGeral> findAllLegisGeral(LegisGeral objLegisGeral)
        {
            return objLegisGeralDao.findAllLegisGeral(objLegisGeral);
        }
        public List<LegisGeral> BuscarPorId(string Id)
        {
            return objLegisGeralDao.BuscarPorID(Id);
        }

    }
}
