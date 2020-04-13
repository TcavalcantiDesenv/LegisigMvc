using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Neg
{
    public class LegisClienteNeg
    {
        private LegisClienteDao objLegisClienteDao;

        public LegisClienteNeg()
        {
            objLegisClienteDao = new LegisClienteDao();

        }

        public void update(LegisClientes objLegis_Cliente)
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
            objLegisClienteDao.update(objLegis_Cliente);
            return;
        }
        public void updatePartial(LeisClientes objLegis_Cliente)
        {
           // bool verificacao = true;
            //begin validar codigo retorna estado=1
            //string IDCliente = objLegis_Cliente.IDCliente.ToString();
            //string IDProduto = objLegis_Cliente.IDProduto.ToString();
            //string IDSubProduto = objLegis_Cliente.IDSubProduto.ToString();
            //string IDLegisGeral = objLegis_Cliente.IDLegisGeral.ToString();
            //string Aplicavel = objLegis_Cliente.Aplicavel;
            //string Lei = objLegis_Cliente.Lei;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objLegisClienteDao.updatePartial(objLegis_Cliente);
            return;
        }

        public List<LegisClientes> findAll()
        {
            return objLegisClienteDao.findAll();
        }

    }
}
