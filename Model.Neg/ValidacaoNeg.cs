using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class ValidacaoNeg
    {
        private ValidacaoDao objValidacaoDao;

        public ValidacaoNeg()
        {
            objValidacaoDao = new ValidacaoDao();

        }

        public void create(Validacao objValidacao)
        {
            bool verificacao = true;


            string IDCliente = objValidacao.IDCliente.ToString();
            string IDLegis = objValidacao.IDLegis.ToString();
            string IDParametros = objValidacao.IDParametros.ToString();
            string Obrigacao = objValidacao.Obrigacao.ToString();
            string Evidencias = objValidacao.Evidencias;
            string DataAvaliacao = objValidacao.DataAvaliacao.ToString();
            string Avaliado = objValidacao.Avaliado;
            string Anexo = objValidacao.Anexo;
            // int Estados = objValidacao.Estados;
            string DataValidacao = objValidacao.DataValidacao.ToString();
            string Validado = objValidacao.Validado;
            string ProxAvaliacao = objValidacao.ProxAvaliacao.ToString();
            string Resultado = objValidacao.Resultado;

            //begin verificar duplicidade cpf retorna estado=8
            Validacao objValidacao1 = new Validacao();
            objValidacao1.id = objValidacao.id;
            verificacao = !objValidacaoDao.findValidacaoPorId(objValidacao1);
            if (!verificacao)
            {
                objValidacao.Estados = 9;
                return;
            }


            //se nao tem erro
            objValidacao.Estados = 99;
            objValidacaoDao.create(objValidacao);
            return;
        }
        public void update(Validacao objValidacao)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string IDCliente = objValidacao.IDCliente.ToString();
            string IDLegis = objValidacao.IDLegis.ToString();
            string IDParametros = objValidacao.IDParametros.ToString();
            string Obrigacao = objValidacao.Obrigacao.ToString();
            string Evidencias = objValidacao.Evidencias;
            string DataAvaliacao = objValidacao.DataAvaliacao.ToString();
            string Avaliado = objValidacao.Avaliado;
            string Anexo = objValidacao.Anexo;
            // int Estados = objValidacao.Estados;
            string DataValidacao = objValidacao.DataValidacao.ToString();
            string Validado = objValidacao.Validado;
            string ProxAvaliacao = objValidacao.ProxAvaliacao.ToString();
            string Resultado = objValidacao.Resultado;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objValidacao.Estados = 99;
            objValidacaoDao.update(objValidacao);
            return;
        }
        public void delete(Validacao objValidacao)
        {
            bool verificacao = true;
            //verificando se existe
            Validacao objValidacaoAux = new Validacao();
            objValidacaoAux.id = objValidacao.id;
            verificacao = objValidacaoDao.find(objValidacaoAux);
            if (!verificacao)
            {
                objValidacao.Estados = 33;
                return;
            }


            objValidacao.Estados = 99;
            objValidacaoDao.delete(objValidacao);
            return;
        }
        public bool find(Validacao objValidacao)
        {
            return objValidacaoDao.find(objValidacao);
        }
        public List<Validacao> findAll()
        {
            return objValidacaoDao.findAll();
        }
        public List<Validacao> findAllValidacao(Validacao objValidacao)
        {
            return objValidacaoDao.findAllValidacao(objValidacao);
        }

    }
}
