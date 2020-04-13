using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class AtividadesNeg
    {
        private AtividadesDao objAtividadesDao;

        public AtividadesNeg()
        {
            objAtividadesDao = new AtividadesDao();

        }

        public void create(Atividades objAtividades)
        {
            bool verificacao = true;


            string Id = objAtividades.Id.ToString();
            string ProcessoId = objAtividades.ProcessoId.ToString();
            string Descricao = objAtividades.Descricao;

            //begin verificar duplicidade cpf retorna estado=8
            Atividades objAtividades1 = new Atividades();
            objAtividades1.Id = objAtividades.Id;
            verificacao = !objAtividadesDao.findAtividadesPorId(objAtividades1);
            if (!verificacao)
            {
                objAtividades.Estados = 9;
                return;
            }


            //se nao tem erro
            objAtividades.Estados = 99;
            objAtividadesDao.create(objAtividades);
            return;
        }
        public void update(Atividades objAtividades)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Id = objAtividades.Id.ToString();
            string ProcessoId = objAtividades.ProcessoId.ToString();
            string Descricao = objAtividades.Descricao;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objAtividades.Estados = 99;
            objAtividadesDao.update(objAtividades);
            return;
        }
        public void delete(Atividades objAtividades)
        {
            bool verificacao = true;
            //verificando se existe
            Atividades objAtividadesAux = new Atividades();
            objAtividadesAux.Id = objAtividades.Id;
            verificacao = objAtividadesDao.find(objAtividadesAux);
            if (!verificacao)
            {
                objAtividades.Estados = 33;
                return;
            }


            objAtividades.Estados = 99;
            objAtividadesDao.delete(objAtividades);
            return;
        }
        public bool find(Atividades objAtividades)
        {
            return objAtividadesDao.find(objAtividades);
        }
        public List<Atividades> findAll()
        {
            return objAtividadesDao.findAll();
        }
        public List<Atividades> FindAllAtividades(Atividades objAtividades)
        {
            return objAtividadesDao.findAllAtividades(objAtividades);
        }

    }
}
