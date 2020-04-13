using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class ArquivosNeg
    {
        private ArquivosDao objArquivosDao;

        public ArquivosNeg()
        {
            objArquivosDao = new ArquivosDao();

        }
        public bool find(Arquivos objArquivos)
        {
            return objArquivosDao.find(objArquivos);
        }
        public List<Arquivos> findAll()
        {
            return objArquivosDao.findAll();
        }
        public void delete(Arquivos objArquivos)
        {
            bool verificacao = true;
            //verificando se existe
            Arquivos objobjArquivosAux = new Arquivos();
            objobjArquivosAux.IDARQUIVO = objArquivos.IDARQUIVO;
            verificacao = objArquivosDao.find(objobjArquivosAux);
            if (!verificacao)
            {
                objArquivos.Estados = 33;
                return;
            }

            objArquivos.Estados = 99;
            objArquivosDao.delete(objArquivos);
            return;
        }

        public void create(Arquivos obj)
        {
            bool verificacao = true;

            int IDARQUIVO = obj.IDARQUIVO;
            string DATA = obj.DATA.ToString();
            string DESCRICAO = obj.DESCRICAO ;
            string NOME = obj.NOME;
            string OBSERVACAO = obj.OBSERVACAO;

            //begin verificar duplicidade cpf retorna estado=8
            Arquivos objArquivos1 = new Arquivos();
            objArquivos1.IDARQUIVO = obj.IDARQUIVO;
            //verificacao = !objArquivos1.IDARQUIVO = obj.IDARQUIVO;;
            //if (!verificacao)
            //{
            //    obj.Estados = 9;
            //    return;
            //}


            //se nao tem erro
            obj.Estados = 99;

            objArquivosDao.create(obj);
            return;
        }


    }
}
