using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class LicensasNeg
    {
        private LicencasDao objLicensasDao;

        public LicensasNeg()
        {
            objLicensasDao = new LicencasDao();

        }

        public void create(Licencas objLicensas)
        {
            bool verificacao = true;


            string IdCliente = objLicensas.IdCliente.ToString();
            string Licenca = objLicensas.Licenca;
            string Orgao = objLicensas.Orgao;
            string Numero = objLicensas.Numero;
            string Emissao = objLicensas.Emissao.ToString();
            string Validade = objLicensas.Validade.ToString();
            string Finalidade = objLicensas.Finalidade;
            string Requisito = objLicensas.Requisito;
            // int Estados = objLicensas.Estados;
            string Obs = objLicensas.Obs;
            string Prazo = objLicensas.Prazo.ToString();
            string Condicionante = objLicensas.Condicionante.ToString();

            //begin verificar duplicidade cpf retorna estado=8
            Licencas objLicensas1 = new Licencas();
            objLicensas1.Id = objLicensas.Id;
            verificacao = !objLicensasDao.findClientePorId(objLicensas1);
            if (!verificacao)
            {
                objLicensas.Estados = 9;
                return;
            }


            //se nao tem erro
            objLicensas.Estados = 99;
            objLicensasDao.create(objLicensas);
            return;
        }
        public void update(Licencas objLicensas)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string IdCliente = objLicensas.IdCliente.ToString();
            string Licenca = objLicensas.Licenca;
            string Orgao = objLicensas.Orgao;
            string Numero = objLicensas.Numero;
            string Emissao = objLicensas.Emissao.ToString();
            string Validade = objLicensas.Validade.ToString();
            string Finalidade = objLicensas.Finalidade;
            string Requisito = objLicensas.Requisito;
            // int Estados = objLicensas.Estados;
            string Obs = objLicensas.Obs;
            string Prazo = objLicensas.Prazo.ToString();
            string Condicionante = objLicensas.Condicionante.ToString();



            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objLicensas.Estados = 99;
            objLicensasDao.update(objLicensas);
            return;
        }
        public void delete(Licencas objLicensas)
        {
            bool verificacao = true;
            //verificando se existe
            Licencas objLicensasAux = new Licencas();
            objLicensasAux.Id = objLicensas.Id;
            verificacao = objLicensasDao.find(objLicensasAux);
            if (!verificacao)
            {
                objLicensas.Estados = 33;
                return;
            }


            objLicensas.Estados = 99;
            objLicensasDao.delete(objLicensas);
            return;
        }
        public bool find(Licencas objLicencas)
        {
            return objLicensasDao.find(objLicencas);
        }
        public List<Licencas> findAll()
        {
            return objLicensasDao.findAll();
        }
        public List<Licencas> findAllLicensas(Licencas objLicensas)
        {
            return objLicensasDao.findAllLicencas(objLicensas);
        }

    }
}
