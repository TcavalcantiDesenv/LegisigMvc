using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class CondicionantesNeg
    {
        private CondicionantesDao objCondicionantesDao;

        public CondicionantesNeg()
        {
            objCondicionantesDao = new CondicionantesDao();

        }

        public void create(Condicionantes objCondicionantes)
        {
            bool verificacao = true;


            string Id = objCondicionantes.Id.ToString();
            string Numero = objCondicionantes.Numero;
            string Descricao = objCondicionantes.Descricao;
            string Avaliacao = objCondicionantes.Avaliacao;
            string Controles = objCondicionantes.Controles;
            string Responsavel = objCondicionantes.Responsavel;
            string MeiosAnalise = objCondicionantes.MeiosAnalise;
            string FrequenciaMonotora = objCondicionantes.FrequenciaMonotora;
            // int Estados = objCondicionantes.Estados;
            string Situacao = objCondicionantes.Situacao;
            string AplicavelPrazo = objCondicionantes.AplicavelPrazo;
            string Data = objCondicionantes.Data.ToString();
            string Alerta = objCondicionantes.Alerta.ToString();
            string IdLicenca = objCondicionantes.IdLicenca.ToString();

            //begin verificar duplicidade cpf retorna estado=8
            Condicionantes objCondicionantes1 = new Condicionantes();
            objCondicionantes1.Id = objCondicionantes.Id;
            verificacao = !objCondicionantesDao.findCondicionantesPorId(objCondicionantes1);
            if (!verificacao)
            {
                objCondicionantes.Estados = 9;
                return;
            }


            //se nao tem erro
            objCondicionantes.Estados = 99;
            objCondicionantesDao.create(objCondicionantes);
            return;
        }
        public void update(Condicionantes objCondicionantes)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Id = objCondicionantes.Id.ToString();
            string Numero = objCondicionantes.Numero;
            string Descricao = objCondicionantes.Descricao;
            string Avaliacao = objCondicionantes.Avaliacao;
            string Controles = objCondicionantes.Controles;
            string Responsavel = objCondicionantes.Responsavel;
            string MeiosAnalise = objCondicionantes.MeiosAnalise;
            string FrequenciaMonotora = objCondicionantes.FrequenciaMonotora;
            // int Estados = objCondicionantes.Estados;
            string Situacao = objCondicionantes.Situacao;
            string AplicavelPrazo = objCondicionantes.AplicavelPrazo;
            string Data = objCondicionantes.Data.ToString();
            string Alerta = objCondicionantes.Alerta.ToString();
            string IdLicenca = objCondicionantes.IdLicenca.ToString();



            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objCondicionantes.Estados = 99;
            objCondicionantesDao.update(objCondicionantes);
            return;
        }
        public void delete(Condicionantes objCondicionantes)
        {
            bool verificacao = true;
            //verificando se existe
            Condicionantes objClienteAux = new Condicionantes();
            objClienteAux.Id = objCondicionantes.Id;
            verificacao = objCondicionantesDao.find(objClienteAux);
            if (!verificacao)
            {
                objCondicionantes.Estados = 33;
                return;
            }


            objCondicionantes.Estados = 99;
            objCondicionantesDao.delete(objCondicionantes);
            return;
        }
        public bool find(Condicionantes objCondicionantes)
        {
            return objCondicionantesDao.find(objCondicionantes);
        }
        public List<Condicionantes> findAll()
        {
            return objCondicionantesDao.findAll();
        }
        public List<Condicionantes> findAllCondicionantes(Condicionantes objCondicionantes)
        {
            return objCondicionantesDao.findAllCondicionantes(objCondicionantes);
        }

    }
}
