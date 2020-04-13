using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Neg
{
    public class ClientesADMNeg
    {
        private ClientesADMDao objClientesADMDao;

        public ClientesADMNeg()
        {
            objClientesADMDao = new ClientesADMDao();

        }

        public void create(ClientesADM objClientesADM)
        {
            bool verificacao = true;


            string Id = objClientesADM.Id.ToString();
            string N_Cliente = objClientesADM.N_Cliente.ToString();
            string IdUsuario = objClientesADM.IdUsuario.ToString();
            string NomeFantasia = objClientesADM.NomeFantasia;
            string RazaoSocial = objClientesADM.RazaoSocial;
            string CNPJ = objClientesADM.CNPJ;
            string IE = objClientesADM.IE;
            string Endereco = objClientesADM.Endereco;
            // int Estados = objClientesADM.Estados;
            string Bairro = objClientesADM.Bairro;
            string Cidade = objClientesADM.Cidade;
            string CEP = objClientesADM.CEP;
            string Estado = objClientesADM.Estado;
            string HomePage = objClientesADM.HomePage;
            string Fone1 = objClientesADM.Fone1;
            string Fone2 = objClientesADM.Fone2;
            // string IdUsuario = objClientesADM.IdUsuario;
            string Fone3 = objClientesADM.Fone3;
            string Fone4 = objClientesADM.Fone4;
            string DataCadastro = objClientesADM.DataCadastro;

            //begin verificar duplicidade cpf retorna estado=8
            ClientesADM objClientesADM1 = new ClientesADM();
            objClientesADM1.CNPJ = objClientesADM.CNPJ;
            verificacao = !objClientesADMDao.findClientePorId(objClientesADM1);
            if (!verificacao)
            {
                objClientesADM.Estados = 9;
                return;
            }


            //se nao tem erro
            objClientesADM.Estados = 99;
            objClientesADMDao.create(objClientesADM);
            return;
        }
        public void update(ClientesADM objClientesADM)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Id = objClientesADM.Id.ToString();
            string N_Cliente = objClientesADM.N_Cliente.ToString();
            string IdUsuario = objClientesADM.IdUsuario.ToString();
            string NomeFantasia = objClientesADM.NomeFantasia;
            string RazaoSocial = objClientesADM.RazaoSocial;
            string CNPJ = objClientesADM.CNPJ;
            string IE = objClientesADM.IE;
            string Endereco = objClientesADM.Endereco;
            // int Estados = objClientesADM.Estados;
            string Bairro = objClientesADM.Bairro;
            string Cidade = objClientesADM.Cidade;
            string CEP = objClientesADM.CEP;
            string Estado = objClientesADM.Estado;
            string HomePage = objClientesADM.HomePage;
            string Fone1 = objClientesADM.Fone1;
            string Fone2 = objClientesADM.Fone2;
            // string IdUsuario = objClientesADM.IdUsuario;
            string Fone3 = objClientesADM.Fone3;
            string Fone4 = objClientesADM.Fone4;
            string DataCadastro = objClientesADM.DataCadastro;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objClientesADM.Estados = 99;
            objClientesADMDao.update(objClientesADM);
            return;
        }
        public void delete(ClientesADM objClientesADM)
        {
            bool verificacao = true;
            //verificando se existe
            ClientesADM objClientesADMAux = new ClientesADM();
            objClientesADMAux.Id = objClientesADM.Id;
            verificacao = objClientesADMDao.find(objClientesADMAux);
            if (!verificacao)
            {
                objClientesADM.Estados = 33;
                return;
            }


            objClientesADM.Estados = 99;
            objClientesADMDao.delete(objClientesADM);
            return;
        }
        public bool find(ClientesADM objClientesADM)
        {
            return objClientesADMDao.find(objClientesADM);
        }
        public List<ClientesADM> findAll()
        {
            return objClientesADMDao.findAll();
        }
        public List<ClientesADM> findAllClientesADM(ClientesADM objClientesADM)
        {
            return objClientesADMDao.findAllCliente(objClientesADM);
        }

    }
}
