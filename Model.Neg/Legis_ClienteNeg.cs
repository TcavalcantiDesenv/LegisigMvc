using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class Legis_ClienteNeg
    {
        private Legis_ClienteDao objLegis_ClienteDao;

        public Legis_ClienteNeg()
        {
            objLegis_ClienteDao = new Legis_ClienteDao();

        }

        public void create(Legis_Cliente objLegis_Cliente)
        {
            bool verificacao = true;


            string IDCliente = objLegis_Cliente.IDCliente.ToString();
            string IDProduto = objLegis_Cliente.IDProduto.ToString();
            string IDSubProduto = objLegis_Cliente.IDSubProduto.ToString();
            string IDLegisGeral = objLegis_Cliente.IDLegisGeral.ToString();
            string Aplicavel = objLegis_Cliente.Aplicavel;
            string Lei = objLegis_Cliente.Lei;

            //begin verificar duplicidade cpf retorna estado=8
            Legis_Cliente objLegis_Cliente1 = new Legis_Cliente();
            objLegis_Cliente1.Id = objLegis_Cliente.Id;
            verificacao = !objLegis_ClienteDao.findLegis_ClientePorId(objLegis_Cliente1);
            if (!verificacao)
            {
                objLegis_Cliente.Estados = 9;
                return;
            }


            //se nao tem erro
            objLegis_Cliente.Estados = 99;
            objLegis_ClienteDao.create(objLegis_Cliente);
            return;
        }
        public void update(Legis_Cliente objLegis_Cliente)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string IDCliente = objLegis_Cliente.IDCliente.ToString();
            string IDProduto = objLegis_Cliente.IDProduto.ToString();
            string IDSubProduto = objLegis_Cliente.IDSubProduto.ToString();
            string IDLegisGeral = objLegis_Cliente.IDLegisGeral.ToString();
            string Aplicavel = objLegis_Cliente.Aplicavel;
            string Lei = objLegis_Cliente.Lei;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objLegis_Cliente.Estados = 99;
            objLegis_ClienteDao.update(objLegis_Cliente);
            return;
        }
        public void updatePartial(Legis_Cliente objLegis_Cliente)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string IDCliente = objLegis_Cliente.IDCliente.ToString();
            string IDProduto = objLegis_Cliente.IDProduto.ToString();
            string IDSubProduto = objLegis_Cliente.IDSubProduto.ToString();
            string IDLegisGeral = objLegis_Cliente.IDLegisGeral.ToString();
            string Aplicavel = objLegis_Cliente.Aplicavel;
            string Lei = objLegis_Cliente.Lei;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objLegis_Cliente.Estados = 99;
            objLegis_ClienteDao.updatePartial(objLegis_Cliente);
            return;
        }
        public void delete(Legis_Cliente objLegis_Cliente)
        {
            bool verificacao = true;
            //verificando se existe
            Legis_Cliente objLegis_ClienteAux = new Legis_Cliente();
            objLegis_ClienteAux.Id = objLegis_Cliente.Id;
            verificacao = objLegis_ClienteDao.find(objLegis_ClienteAux);
            if (!verificacao)
            {
                objLegis_Cliente.Estados = 33;
                return;
            }


            objLegis_Cliente.Estados = 99;
            objLegis_ClienteDao.delete(objLegis_Cliente);
            return;
        }
        public bool find(Legis_Cliente objLegis_Cliente)
        {
            return objLegis_ClienteDao.find(objLegis_Cliente);
        }
        public List<LeisClientes> buscarLeisClientesPorCliente(string cliente)
        {
            return objLegis_ClienteDao.buscarLeisClientesPorCliente(cliente);
        }
        public List<LeisClientes> ExportarLeisClientesPorCliente(string cliente)
        {
            return objLegis_ClienteDao.ExportarLeisClientesPorCliente(cliente);
        }
        public List<ParametrosClientesModel> ExportarParametrosClientesPorCliente(string cliente)
        {
            return objLegis_ClienteDao.ExportarParametrosClientesPorCliente(cliente);
        }
        public List<LeisClientes> buscarLeisClientesPorID(LeisClientes obj)
        {
            return objLegis_ClienteDao.buscarLeisClientesPorID(obj);
        }

        
        public List<Legis_Cliente> findAll()
        {
            return objLegis_ClienteDao.findAll();
        }
        public List<Legis_Cliente> Total_Cliente_Ambito_Federal(string cliente)
        {
            return objLegis_ClienteDao.Total_Cliente_Ambito_Federal(cliente);
        }
        public List<Legis_Cliente> Total_Cliente_Ambito_Estadual(string cliente)
        {
            return objLegis_ClienteDao.Total_Cliente_Ambito_Estadual(cliente);
        }
        public List<Legis_Cliente> Total_Cliente_Ambito_Municipal(string cliente)
        {
            return objLegis_ClienteDao.Total_Cliente_Ambito_Municipal(cliente);
        }
        public List<Legis_Cliente> Total_Cliente_Ambito_Normas(string cliente)
        {
            return objLegis_ClienteDao.Total_Cliente_Ambito_Normas(cliente);
        }

        public List<Legis_Cliente> Total_Cliente_Sistema_MeioAmbiente(string cliente)
        {
            return objLegis_ClienteDao.Total_Cliente_Sistema_MeioAmbiente(cliente);
        }
        public List<Legis_Cliente> Total_Cliente_Sistema_Qualidade(string cliente)
        {
            return objLegis_ClienteDao.Total_Cliente_Sistema_Qualidade(cliente);
        }
        public List<Legis_Cliente> Total_Cliente_Sistema_ResponsabilidadeSocial(string cliente)
        {
            return objLegis_ClienteDao.Total_Cliente_Sistema_ResponsabilidadeSocial(cliente);
        }
        public List<Legis_Cliente> Total_Cliente_Sistema_SegurançaeSaude(string cliente)
        {
            return objLegis_ClienteDao.Total_Cliente_Sistema_SegurançaeSaude(cliente);
        }

        public List<Legis_Cliente> Total_Cliente_Aplicabilidade_Aplicavel(string cliente)
        {
            return objLegis_ClienteDao.Total_Cliente_Aplicabilidade_Aplicavel(cliente);
        }
        public List<Legis_Cliente> Total_Cliente_Aplicabilidade_Conhecimento(string cliente)
        {
            return objLegis_ClienteDao.Total_Cliente_Aplicabilidade_Conhecimento(cliente);
        }



        public List<Legis_Cliente> Total_Cliente_Avaliacoes_Atende(string cliente)
        {
            return objLegis_ClienteDao.Total_Cliente_Avaliacoes_Atende(cliente);
        }
        public List<Legis_Cliente> Total_Cliente_Avaliacoes_NaoInformado(string cliente)
        {
            return objLegis_ClienteDao.Total_Cliente_Avaliacoes_NaoInformado(cliente);
        }
        public List<Legis_Cliente> Total_Cliente_Avaliacoes_AtendeParcial(string cliente)
        {
            return objLegis_ClienteDao.Total_Cliente_Avaliacoes_AtendeParcial(cliente);
        }
        public List<Legis_Cliente> Total_Cliente_Avaliacoes_EmAndamento(string cliente)
        {
            return objLegis_ClienteDao.Total_Cliente_Avaliacoes_EmAndamento(cliente);
        }
        public List<Legis_Cliente> Total_Cliente_Avaliacoes_NaoAplicavel(string cliente)
        {
            return objLegis_ClienteDao.Total_Cliente_Avaliacoes_NaoAplicavel(cliente);
        }

        public List<Legis_Cliente> findAllLegis_Cliente(Legis_Cliente objLegis_Cliente)
        {
            return objLegis_ClienteDao.findAllLegis_Cliente(objLegis_Cliente);
        }

    }
}
