using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class AspectoImpactoNeg
    {
        private AspectoImpactoDao objAspectoImpactoDao;

        public AspectoImpactoNeg()
        {
            objAspectoImpactoDao = new AspectoImpactoDao();

        }

        public void create(AspectoImpacto objAspectoImpacto)
        {
            bool verificacao = true;


            string Id = objAspectoImpacto.Id.ToString();
            string IdProcesso = objAspectoImpacto.IdProcesso.ToString();
            string IdAtividade = objAspectoImpacto.IdAtividade.ToString();
            string Entrada = objAspectoImpacto.Entrada;
            string Con = objAspectoImpacto.Con;
            string Saida = objAspectoImpacto.Saida;
            string ImpAmbiental = objAspectoImpacto.ImpAmbiental;
            string AltA = objAspectoImpacto.AltA;
            // int Estados = objAspectoImpacto.Estados;
            string AltB = objAspectoImpacto.AltB;
            string Inc = objAspectoImpacto.Inc;
            string ContrInflu = objAspectoImpacto.ContrInflu;
            string Tem = objAspectoImpacto.Tem;
            string Abr = objAspectoImpacto.Abr;
            string FP = objAspectoImpacto.FP;
            string Gra = objAspectoImpacto.Gra;
            // string IdUsuario = objAspectoImpacto.IdUsuario;
            string Interessada = objAspectoImpacto.Interessada;
            string RequisitoA = objAspectoImpacto.RequisitoA;
            string RequisitoB = objAspectoImpacto.RequisitoB;
            string Req = objAspectoImpacto.Req;
            string RiscOportA = objAspectoImpacto.RiscOportA;
            string RiscOportB = objAspectoImpacto.RiscOportB;
            //begin verificar duplicidade cpf retorna estado=8
            AspectoImpacto objAspectoImpacto1 = new AspectoImpacto();
            objAspectoImpacto1.Id = objAspectoImpacto.Id;
            verificacao = !objAspectoImpactoDao.findAspectoImpactoPorId(objAspectoImpacto1);
            if (!verificacao)
            {
                objAspectoImpacto.Estados = 9;
                return;
            }


            //se nao tem erro
            objAspectoImpacto.Estados = 99;
            objAspectoImpactoDao.create(objAspectoImpacto);
            return;
        }
        public void update(AspectoImpacto objAspectoImpacto)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string IdProcesso = objAspectoImpacto.IdProcesso.ToString();
            string IdAtividade = objAspectoImpacto.IdAtividade.ToString();
            string Entrada = objAspectoImpacto.Entrada;
            string Con = objAspectoImpacto.Con;
            string Saida = objAspectoImpacto.Saida;
            string ImpAmbiental = objAspectoImpacto.ImpAmbiental;
            string AltA = objAspectoImpacto.AltA;
            // int Estados = objAspectoImpacto.Estados;
            string AltB = objAspectoImpacto.AltB;
            string Inc = objAspectoImpacto.Inc;
            string ContrInflu = objAspectoImpacto.ContrInflu;
            string Tem = objAspectoImpacto.Tem;
            string Abr = objAspectoImpacto.Abr;
            string FP = objAspectoImpacto.FP;
            string Gra = objAspectoImpacto.Gra;
            // string IdUsuario = objAspectoImpacto.IdUsuario;
            string Interessada = objAspectoImpacto.Interessada;
            string RequisitoA = objAspectoImpacto.RequisitoA;
            string RequisitoB = objAspectoImpacto.RequisitoB;
            string Req = objAspectoImpacto.Req;
            string RiscOportA = objAspectoImpacto.RiscOportA;
            string RiscOportB = objAspectoImpacto.RiscOportB;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objAspectoImpacto.Estados = 99;
            objAspectoImpactoDao.update(objAspectoImpacto);
            return;
        }
        public void delete(AspectoImpacto objAspectoImpacto)
        {
            bool verificacao = true;
            //verificando se existe
            AspectoImpacto objAspectoImpactoAux = new AspectoImpacto();
            objAspectoImpactoAux.Id = objAspectoImpacto.Id;
            verificacao = objAspectoImpactoDao.find(objAspectoImpactoAux);
            if (!verificacao)
            {
                objAspectoImpacto.Estados = 33;
                return;
            }


            objAspectoImpacto.Estados = 99;
            objAspectoImpactoDao.delete(objAspectoImpacto);
            return;
        }
        public bool find(AspectoImpacto objAspectoImpacto)
        {
            return objAspectoImpactoDao.find(objAspectoImpacto);
        }
        public List<AspectoImpacto> findAll()
        {
            return objAspectoImpactoDao.findAll();
        }
        public List<AspectoImpacto> findAllAspectoImpacto(AspectoImpacto objAspectoImpacto)
        {
            return objAspectoImpactoDao.findAspectoImpacto(objAspectoImpacto);
        }

    }
}
