using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class Usuarios_AtribuicoesNeg
    {
        private Usuarios_AtribuicoesDao objUsuarios_AtribuicoesDao;

        public Usuarios_AtribuicoesNeg()
        {
            objUsuarios_AtribuicoesDao = new Usuarios_AtribuicoesDao();

        }

        public void create(Usuarios_Atribuicoes objUsuarios_Atribuicoes)
        {
            bool verificacao = true;


            string IDUsuario = objUsuarios_Atribuicoes.IDUsuario.ToString();
            string IDPagina = objUsuarios_Atribuicoes.IDPagina.ToString();
            string Cod_Atribuicao = objUsuarios_Atribuicoes.Cod_Atribuicao.ToString();
            string Nivel = objUsuarios_Atribuicoes.Nivel;
            string Atribuicao = objUsuarios_Atribuicoes.Atribuicao;
            string DataIni = objUsuarios_Atribuicoes.DataIni.ToString();
            string DataFim = objUsuarios_Atribuicoes.DataFim.ToString();
            string HoraIni = objUsuarios_Atribuicoes.HoraIni;
            // int Estados = objUsuarios_Atribuicoes.Estados;
            string HoraFim = objUsuarios_Atribuicoes.HoraFim;
            string Ativo = objUsuarios_Atribuicoes.Ativo.ToString();

            
            //begin verificar duplicidade cpf retorna estado=8
            Usuarios_Atribuicoes objUsuarios_Atribuicoes1 = new Usuarios_Atribuicoes();
            objUsuarios_Atribuicoes.ID = objUsuarios_Atribuicoes.ID;
            verificacao = !objUsuarios_AtribuicoesDao.findUsuarios_AtribuicoesPorId(objUsuarios_Atribuicoes1);
            if (!verificacao)
            {
                objUsuarios_Atribuicoes.Estados = 9;
                return;
            }


            //se nao tem erro
            objUsuarios_Atribuicoes.Estados = 99;
            objUsuarios_AtribuicoesDao.create(objUsuarios_Atribuicoes);
            return;
        }
        public void update(Usuarios_Atribuicoes objUsuarios_Atribuicoes)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string IDUsuario = objUsuarios_Atribuicoes.IDUsuario.ToString();
            string IDPagina = objUsuarios_Atribuicoes.IDPagina.ToString();
            string Cod_Atribuicao = objUsuarios_Atribuicoes.Cod_Atribuicao.ToString();
            string Nivel = objUsuarios_Atribuicoes.Nivel;
            string Atribuicao = objUsuarios_Atribuicoes.Atribuicao;
            string DataIni = objUsuarios_Atribuicoes.DataIni.ToString();
            string DataFim = objUsuarios_Atribuicoes.DataFim.ToString();
            string HoraIni = objUsuarios_Atribuicoes.HoraIni;
            // int Estados = objUsuarios_Atribuicoes.Estados;
            string HoraFim = objUsuarios_Atribuicoes.HoraFim;
            string Ativo = objUsuarios_Atribuicoes.Ativo.ToString();


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objUsuarios_Atribuicoes.Estados = 99;
            objUsuarios_AtribuicoesDao.update(objUsuarios_Atribuicoes);
            return;
        }
        public void delete(Usuarios_Atribuicoes objUsuarios_Atribuicoes)
        {
            bool verificacao = true;
            //verificando se existe
            Usuarios_Atribuicoes objUsuarios_AtribuicoesAux = new Usuarios_Atribuicoes();
            objUsuarios_AtribuicoesAux.ID = objUsuarios_Atribuicoes.ID;
            verificacao = objUsuarios_AtribuicoesDao.find(objUsuarios_AtribuicoesAux);
            if (!verificacao)
            {
                objUsuarios_Atribuicoes.Estados = 33;
                return;
            }


            objUsuarios_Atribuicoes.Estados = 99;
            objUsuarios_AtribuicoesDao.delete(objUsuarios_Atribuicoes);
            return;
        }
        public bool find(Usuarios_Atribuicoes objUsuarios_Atribuicoes)
        {
            return objUsuarios_AtribuicoesDao.find(objUsuarios_Atribuicoes);
        }
        public List<Usuarios_Atribuicoes> findAll()
        {
            return objUsuarios_AtribuicoesDao.findAll();
        }
        public List<Usuarios_Atribuicoes> findAllUsuarios_Atribuicoes(Usuarios_Atribuicoes objUsuarios_Atribuicoes)
        {
            return objUsuarios_AtribuicoesDao.findAllUsuarios_Atribuicoes(objUsuarios_Atribuicoes);
        }

    }
}
