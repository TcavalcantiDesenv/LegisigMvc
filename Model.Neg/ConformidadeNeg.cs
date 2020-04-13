using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class ConformidadeNeg
    {
        private ConformidadeDao objConformidadeDao;

        public ConformidadeNeg()
        {
            objConformidadeDao = new ConformidadeDao();

        }

        public void create(Conformidade objConformidade)
        {
            bool verificacao = true;


            string id = objConformidade.id.ToString();
            string IDCliente = objConformidade.IDCliente.ToString();
            string IDLegis = objConformidade.IDLegis.ToString();
            string IDParametros = objConformidade.IDParametros.ToString();
  //          string Obrigacao = objConformidade.Obrigacao.ToString();
            string Evidencias = objConformidade.Evidencias;
            string DataAvaliacao = objConformidade.DataAvaliacao.ToString();
            string Avaliado = objConformidade.Avaliado;
            // int Estados = objConformidade.Estados;
            string Anexo = objConformidade.Anexo;
            string DataValidacao = objConformidade.DataValidacao.ToString();
            string Validado = objConformidade.Validado;
            string ProxAvaliacao = objConformidade.ProxAvaliacao.ToString();
            string Resultado = objConformidade.Resultado;

            //begin verificar duplicidade cpf retorna estado=8
            Conformidade objConformidade1 = new Conformidade();
            objConformidade1.id = objConformidade.id;
            verificacao = !objConformidadeDao.findConformidadePorId(objConformidade1);
            if (!verificacao)
            {
                return;
            }


            //se nao tem erro
            objConformidadeDao.create(objConformidade);
            return;
        }
        public void update(Conformidade objConformidade)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string id = objConformidade.id.ToString();
            string IDCliente = objConformidade.IDCliente.ToString();
            string IDLegis = objConformidade.IDLegis.ToString();
            string IDParametros = objConformidade.IDParametros.ToString();
            string Obrigacao = "0";
            string Evidencias = objConformidade.Evidencias;
            string DataAvaliacao = objConformidade.DataAvaliacao.ToString();
            string Avaliado = objConformidade.Avaliado;
            // int Estados = objConformidade.Estados;
            string Anexo = objConformidade.Anexo;
            string DataValidacao = objConformidade.DataValidacao.ToString();
            string Validado = objConformidade.Validado;
            string ProxAvaliacao = objConformidade.ProxAvaliacao.ToString();
            string Resultado = objConformidade.Resultado;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objConformidadeDao.update(objConformidade);
            return;
        }
        public void delete(Conformidade objConformidade)
        {
            bool verificacao = true;
            //verificando se existe
            //Conformidade objConformidadeAux = new Conformidade();
            //objConformidadeAux.id = objConformidade.id;
            //verificacao = objConformidadeDao.find(objConformidadeAux);
            //if (!verificacao)
            //{
            //    return;
            //}


            objConformidadeDao.delete(objConformidade);
            return;
        }
        public bool find(Conformidade objConformidade)
        {
            return objConformidadeDao.find(objConformidade);
        }
        public List<Conformidade> findAll()
        {
            return objConformidadeDao.findAll();
        }

        public List<Conformidade> buscarPorClienteParametro(string cliente, string parametros)
        {
            return objConformidadeDao.buscarPorClienteParametro(cliente,parametros);
        }
        public List<Conformidade> buscarPorID(string Id)
        {
            return objConformidadeDao.buscarPorID(Id);
        }

        public List<Conformidade> findAllConformidade(Conformidade objConformidade)
        {
            return objConformidadeDao.findAllConformidade(objConformidade);
        }

    }
}
