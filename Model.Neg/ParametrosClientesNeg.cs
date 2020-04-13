using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class ParametrosClientesNeg
    {
        private ParametrosClienteDao objParametrosClienteDao;

        public ParametrosClientesNeg()
        {
            objParametrosClienteDao = new ParametrosClienteDao();

        }

        public void create(ParametrosCliente objParametrosClientes)
        {
            bool verificacao = true;


            string Capitulo = objParametrosClientes.Capitulo;
            string Item = objParametrosClientes.Item;
            string Parametro = objParametrosClientes.Parametro;
            string Obrigacao = objParametrosClientes.Obrigacao.ToString();
            string IDLegisGeral = objParametrosClientes.IDLegisGeral.ToString();
            string IDCliente = objParametrosClientes.IDCliente.ToString();
            string Numero = objParametrosClientes.Numero.ToString();
            string Aplicavel = objParametrosClientes.Aplicavel.ToString();
            // int Estados = objParametrosClientes.Estados;
            string Conhecimento = objParametrosClientes.Conhecimento.ToString();

            //begin verificar duplicidade cpf retorna estado=8
            ParametrosCliente objParametrosClientes1 = new ParametrosCliente();
            objParametrosClientes1.Id = objParametrosClientes.Id;
            verificacao = !objParametrosClienteDao.findParametrosClientePorId(objParametrosClientes1);
            if (!verificacao)
            {
             //   objParametrosClientes.Estados = 9;
                return;
            }


            //se nao tem erro
          //  objParametrosClientes.Estados = 99;
            objParametrosClienteDao.create(objParametrosClientes);
            return;
        }
        public void update(ParametrosCliente objParametrosClientes)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Capitulo = objParametrosClientes.Capitulo;
            string Item = objParametrosClientes.Item;
            string Parametro = objParametrosClientes.Parametro;
            string Obrigacao = objParametrosClientes.Obrigacao.ToString();
            string IDLegisGeral = objParametrosClientes.IDLegisGeral.ToString();
            string IDCliente = objParametrosClientes.IDCliente.ToString();
            string Numero = objParametrosClientes.Numero.ToString();
            string Aplicavel = objParametrosClientes.Aplicavel.ToString();
            // int Estados = objParametrosClientes.Estados;
            string Conhecimento = objParametrosClientes.Conhecimento.ToString();


            // Inicia validacao

            /// ???????????

            //se nao tem erro
        //    objParametrosClientes.Estados = 99;
            objParametrosClienteDao.update(objParametrosClientes);
            return;
        }
        public void delete(ParametrosCliente objParametrosClientes)
        {
            bool verificacao = true;
            //verificando se existe
            ParametrosCliente objParametrosClientesAux = new ParametrosCliente();
            objParametrosClientesAux.Id = objParametrosClientes.Id;
            verificacao = objParametrosClienteDao.find(objParametrosClientesAux);
            if (!verificacao)
            {
             //   objParametrosClientes.Estados = 33;
                return;
            }


          //  objParametrosClientes.Estados = 99;
            objParametrosClienteDao.delete(objParametrosClientes);
            return;
        }
        public bool find(ParametrosCliente objParametrosClientes)
        {
            return objParametrosClienteDao.find(objParametrosClientes);
        }
        public List<ParametrosCliente> buscarPorLeiCliente(string cliente, string lei)
        {
            return objParametrosClienteDao.buscarPorLeiCliente(cliente,lei);
        }
        public List<ParametrosCliente> buscarPorID(string Id)
        {
            return objParametrosClienteDao.buscarPorID(Id);
        }
        public List<ParametrosCliente> findAll()
        {
            return objParametrosClienteDao.findAll();
        }
        public List<ParametrosCliente> findAllParametrosClientes(ParametrosCliente objParametrosClientes)
        {
            return objParametrosClienteDao.findAllParametrosCliente(objParametrosClientes);
        }

    }
}
