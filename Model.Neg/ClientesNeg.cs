using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg 
{
    public class ClientesNeg
    {
        private ClientesDao objClientesDao;

        public ClientesNeg()
        {
            objClientesDao = new ClientesDao();

        }

        public void create(Clientes objClientes)
        {
            bool verificacao = true;


            string N_Cliente = "109";// objClientes.N_Cliente;
            string NomeFantasia = objClientes.NomeFantasia;
            string RazaoSocial = objClientes.RazaoSocial;
            string CNPJ = objClientes.CNPJ;
            string IE = objClientes.IE;
            string Endereco = objClientes.Endereco;
            string Bairro = objClientes.Bairro;
            string Cidade = objClientes.Cidade;
            string CEP = objClientes.CEP;
           // int Estados = objClientes.Estados;
            string Estado = objClientes.Estado;
            string HomePage = objClientes.HomePage;
            string Fone1 = objClientes.Fone1;
            string Fone2 = objClientes.Fone2;
            string Fone3 = objClientes.Fone3;
            string Fone4 = objClientes.Fone4;
            string DataCadastro = objClientes.DataCadastro;
           // string IdUsuario = objClientes.IdUsuario;
            string EmailEmp = objClientes.EmailEmp;
            string EmailSis = objClientes.EmailSis;
            string cnpj = objClientes.CNPJ;
            string endereco = objClientes.Endereco;
            string telefone = objClientes.Fone1;
            string telefone2 = objClientes.Fone2;
            //begin verificar duplicidade cpf retorna estado=8
            Clientes objCliente1 = new Clientes();
            objCliente1.CNPJ = objClientes.CNPJ;
            verificacao = !objClientesDao.findClientePorcnpj(objCliente1);
            if (!verificacao)
            {
              //  objClientes.Estados = 9;
                return;
            }


            //se nao tem erro
          //  objClientes.Estados = 99;
            objClientesDao.create(objClientes);
            return;
        }
        public void update(Clientes objClientes)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string N_Cliente = objClientes.N_Cliente;
            string NomeFantasia = objClientes.NomeFantasia;
            string RazaoSocial = objClientes.RazaoSocial;
            string CNPJ = objClientes.CNPJ;
            string IE = objClientes.IE;
            string Endereco = objClientes.Endereco;
            string Bairro = objClientes.Bairro;
            string Cidade = objClientes.Cidade;
            string CEP = objClientes.CEP;
          //  int Estados = objClientes.Estados;
            string Estado = objClientes.Estado;
            string HomePage = objClientes.HomePage;
            string Fone1 = objClientes.Fone1;
            string Fone2 = objClientes.Fone2;
            string Fone3 = objClientes.Fone3;
            string Fone4 = objClientes.Fone4;
            string DataCadastro = objClientes.DataCadastro;
            string IdUsuario = objClientes.IdUsuario;
            string EmailEmp = objClientes.EmailEmp;
            string EmailSis = objClientes.EmailSis;
            string Aplicar = objClientes.Aplicar;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
         //   objClientes.Estados = 99;
            objClientesDao.update(objClientes);
            return;
        }
        public void delete(Clientes objClientes)
        {
            bool verificacao = true;
            //verificando se existe
            Clientes objClienteAux = new Clientes();
            objClienteAux.Id = objClientes.Id;
            verificacao = objClientesDao.find(objClienteAux);
            if (!verificacao)
            {
           //     objClientes.Estados = 33;
                return;
            }


        //    objClientes.Estados = 99;
            objClientesDao.delete(objClientes);
            return;
        }
        public bool find(Clientes objCliente)
        {
            return objClientesDao.find(objCliente);
        }
        public List<Clientes> findAll()
        {
            return objClientesDao.findAll();
        }
        public List<Clientes> findAllClientes(Clientes objCLientes)
        {
            return objClientesDao. findAllCliente(objCLientes);
        }
    }
}
