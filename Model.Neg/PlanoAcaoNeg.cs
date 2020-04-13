using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class PlanoAcaoNeg
    {
        private PlanoAcaoDao objPlanoAcaoDao;

        public PlanoAcaoNeg()
        {
            objPlanoAcaoDao = new PlanoAcaoDao();

        }

        public void create(PlanoAcao objPlanoAcao)
        {
            bool verificacao = true;


            string IDParametros = objPlanoAcao.IDParametros.ToString() ;
            string Causa = objPlanoAcao.Causa;
            string DataCausa = objPlanoAcao.DataCausa.ToString();
            string Correcao_Corretivas = objPlanoAcao.Correcao_Corretivas;
            string Prazo = objPlanoAcao.Prazo.ToString();
            string Eficacia = objPlanoAcao.Eficacia;
            string DataEficacia = objPlanoAcao.DataEficacia.ToString();
            string Evidencias = objPlanoAcao.Evidencias;
            // int Estados = objPlanoAcao.Estados;
            string ResultFinal = objPlanoAcao.ResultFinal;
            string IDCliente = objPlanoAcao.IDCliente.ToString();
            string IDLegis = objPlanoAcao.IDLegis.ToString();
            string IDAcao = objPlanoAcao.IDAcao.ToString();

            
            //begin verificar duplicidade cpf retorna estado=8
            PlanoAcao objPlanoAcao1 = new PlanoAcao();
            objPlanoAcao1.id = objPlanoAcao.id;
            verificacao = !objPlanoAcaoDao.findPlanoAcaoPorId(objPlanoAcao1);
            if (!verificacao)
            {
                return;
            }


            //se nao tem erro
            objPlanoAcaoDao.create(objPlanoAcao);
            return;
        }
        public void update(PlanoAcao objPlanoAcao)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string IDParametros = objPlanoAcao.IDParametros.ToString();
            string Causa = objPlanoAcao.Causa;
            string DataCausa = objPlanoAcao.DataCausa.ToString();
            string Correcao_Corretivas = objPlanoAcao.Correcao_Corretivas;
            string Prazo = objPlanoAcao.Prazo.ToString();
            string Eficacia = objPlanoAcao.Eficacia;
            string DataEficacia = objPlanoAcao.DataEficacia.ToString();
            string Evidencias = objPlanoAcao.Evidencias;
            // int Estados = objPlanoAcao.Estados;
            string ResultFinal = objPlanoAcao.ResultFinal;
            string IDCliente = objPlanoAcao.IDCliente.ToString();
            string IDLegis = objPlanoAcao.IDLegis.ToString();
            string IDAcao = objPlanoAcao.IDAcao.ToString();


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objPlanoAcaoDao.update(objPlanoAcao);
            return;
        }
        public void delete(PlanoAcao objPlanoAcao)
        {
            bool verificacao = true;
            //verificando se existe
            //PlanoAcao objIdAux = new PlanoAcao();
            //objIdAux.id = objPlanoAcao.id;
            //verificacao = objPlanoAcaoDao.find(objIdAux);
            //if (!verificacao)
            //{
            //    return;
            //}


            objPlanoAcaoDao.delete(objPlanoAcao);
            return;
        }
        public bool find(PlanoAcao objPlanoAcao)
        {
            return objPlanoAcaoDao.find(objPlanoAcao);
        }
        public List<PlanoAcao> findAll()
        {
            return objPlanoAcaoDao.findAll();
        }
        public List<PlanoAcao> buscarPorClienteConformidade(string cliente)
        {
            return objPlanoAcaoDao.buscarPorClienteConformidade(cliente);
        }
        public List<PlanoAcao> buscarPorID(string Id)
        {
            return objPlanoAcaoDao.buscarPorID(Id);
        }
        public List<PlanoAcao> findAllPlanoAcao(PlanoAcao objPlanoAcao)
        {
            return objPlanoAcaoDao.findAllPlanoAcao(objPlanoAcao);
        }

    }
}
