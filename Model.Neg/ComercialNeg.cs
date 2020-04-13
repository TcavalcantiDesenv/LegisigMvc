using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Neg
{
    public class ComercialNeg
    {
        private ComercialDao objComercialDao;
        public ComercialNeg()
        {
            objComercialDao = new ComercialDao();

        }

        public void create(Comercial objComercial)
        {
            bool verificacao = true;


            string Id = objComercial.Id.ToString();
            string IDCliente = objComercial.IDCliente.ToString();
            string IDProduto = objComercial.IDProduto.ToString();
            string IDSubProduto = objComercial.IDSubProduto.ToString();
            string Licenca = objComercial.Licenca.ToString();
            string AnaliseReqPresencial = objComercial.AnaliseReqPresencial.ToString();
            string AnaliseReqOnLine = objComercial.AnaliseReqOnLine.ToString();
            string Validacao_Presencial = objComercial.Validacao_Presencial;
            // int Estados = objComercial.Estados;
            string Validacao_OnLine = objComercial.Validacao_OnLine;
            string Sem_Validacao = objComercial.Sem_Validacao.ToString();
            string Aspecto_Impacto = objComercial.Aspecto_Impacto.ToString();
            string Vinculo_Legis_AI = objComercial.Vinculo_Legis_AI.ToString();
            string Perigo_Risco = objComercial.Perigo_Risco.ToString();
            string Vinculo_Legis_PR = objComercial.Vinculo_Legis_PR.ToString();
            string Plano = objComercial.Plano;
            // string IdUsuario = objComercial.IdUsuario;
            string Valor = objComercial.Valor.ToString();
            string Usuarios = objComercial.Usuarios.ToString();

            //begin verificar duplicidade cpf retorna estado=8
            Comercial objComercial1 = new Comercial();
            objComercial1.Id = objComercial.Id;
            verificacao = !objComercialDao.findComercialPorid(objComercial);
            if (!verificacao)
            {
                objComercial.Estados = 9;
                return;
            }


            //se nao tem erro
            objComercial.Estados = 99;
            objComercialDao.create(objComercial);
            return;
        }
        public void update(Comercial objComercial)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Id = objComercial.Id.ToString();
            string IDCliente = objComercial.IDCliente.ToString();
            string IDProduto = objComercial.IDProduto.ToString();
            string IDSubProduto = objComercial.IDSubProduto.ToString();
            string Licenca = objComercial.Licenca.ToString();
            string AnaliseReqPresencial = objComercial.AnaliseReqPresencial.ToString();
            string AnaliseReqOnLine = objComercial.AnaliseReqOnLine.ToString();
            string Validacao_Presencial = objComercial.Validacao_Presencial;
            // int Estados = objComercial.Estados;
            string Validacao_OnLine = objComercial.Validacao_OnLine;
            string Sem_Validacao = objComercial.Sem_Validacao.ToString();
            string Aspecto_Impacto = objComercial.Aspecto_Impacto.ToString();
            string Vinculo_Legis_AI = objComercial.Vinculo_Legis_AI.ToString();
            string Perigo_Risco = objComercial.Perigo_Risco.ToString();
            string Vinculo_Legis_PR = objComercial.Vinculo_Legis_PR.ToString();
            string Plano = objComercial.Plano;
            // string IdUsuario = objComercial.IdUsuario;
            string Valor = objComercial.Valor.ToString();
            string Usuarios = objComercial.Usuarios.ToString();


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objComercial.Estados = 99;
            objComercialDao.update(objComercial);
            return;
        }
        public void delete(Comercial objComercial)
        {
            bool verificacao = true;
            //verificando se existe
            Comercial objComercialAux = new Comercial();
            objComercialAux.Id = objComercial.Id;
            verificacao = objComercialDao.find(objComercialAux);
            if (!verificacao)
            {
                objComercial.Estados = 33;
                return;
            }


            objComercial.Estados = 99;
            objComercialDao.delete(objComercial);
            return;
        }
        public bool find(Comercial objComercial)
        {
            return objComercialDao.find(objComercial);
        }
        public List<Comercial> findAll()
        {
            return objComercialDao.findAll();
        }
        public List<Comercial> findAllComercial(Comercial objComercial)
        {
            return objComercialDao.findAllComercial(objComercial);
        }

    }
}
