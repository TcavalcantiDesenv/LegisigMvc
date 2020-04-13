using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class AnexosNeg
    {
        private AnexosDao objAnexosDao;

        public AnexosNeg()
        {
            objAnexosDao = new AnexosDao();

        }

        public void create(Anexos objAnexos)
        {
            bool verificacao = true;


            string Arquivo = objAnexos.Arquivo;
            string ContentType = objAnexos.ContentType;
            string Data = objAnexos.Data.ToString();
            string IDCliente = objAnexos.IDCliente.ToString();
            string IDLegisGeral = objAnexos.IDLegisGeral.ToString();
            string IDConformidade = objAnexos.IDConformidade.ToString();
            string IDParametros = objAnexos.IDParametros.ToString();

            //begin verificar duplicidade cpf retorna estado=8
            Anexos objAnexos1 = new Anexos();
            objAnexos1.Arquivo = objAnexos.Arquivo;
            verificacao = !objAnexosDao.findAnexosPorArquivo(objAnexos1);
            if (!verificacao)
            {
                objAnexos.Estados = 9;
                return;
            }


            //se nao tem erro
            objAnexos.Estados = 99;
            objAnexosDao.create(objAnexos);
            return;
        }
        public void update(Anexos objAnexos)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Arquivo = objAnexos.Arquivo;
            string ContentType = objAnexos.ContentType;
            string Data = objAnexos.Data.ToString();
            string IDCliente = objAnexos.IDCliente.ToString();
            string IDLegisGeral = objAnexos.IDLegisGeral.ToString();
            string IDConformidade = objAnexos.IDConformidade.ToString();
            string IDParametros = objAnexos.IDParametros.ToString();


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objAnexos.Estados = 99;
            objAnexosDao.update(objAnexos);
            return;
        }
        public void delete(Anexos objAnexos)
        {
            bool verificacao = true;
            //verificando se existe
            Anexos objAnexosAux = new Anexos();
            objAnexosAux.Id = objAnexos.Id;
            verificacao = objAnexosDao.find(objAnexosAux);
            if (!verificacao)
            {
                objAnexos.Estados = 33;
                return;
            }


            objAnexos.Estados = 99;
            objAnexosDao.delete(objAnexos);
            return;
        }
        public bool find(Anexos objAnexos)
        {
            return objAnexosDao.find(objAnexos);
        }
        public List<Anexos> findAll()
        {
            return objAnexosDao.findAll();
        }
        public List<Anexos> findAllAnexos(Anexos objAnexos)
        {
            return objAnexosDao.findAllAnexos(objAnexos);
        }

    }
}
