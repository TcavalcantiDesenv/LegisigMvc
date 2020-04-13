using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class EmailEnviadoNeg
    {
        private EmailEnviadoDao objEmailEnviadoDao;

        public EmailEnviadoNeg()
        {
            objEmailEnviadoDao = new EmailEnviadoDao();

        }

        public void create(EmailEnviado objEmailEnviado)
        {
            bool verificacao = true;


            string Nome = objEmailEnviado.Nome;
            string RazaoSocial = objEmailEnviado.RazaoSocial;
            string Email = objEmailEnviado.Email;
            string Motivo = objEmailEnviado.Motivo;
            string Data = objEmailEnviado.Data.ToString();
            string Status = objEmailEnviado.Status;

            //begin verificar duplicidade cpf retorna estado=8
            EmailEnviado objEmailEnviado1 = new EmailEnviado();
            objEmailEnviado1.Id = objEmailEnviado.Id;
            verificacao = !objEmailEnviadoDao.findEmailEnviadoPorId(objEmailEnviado1);
            if (!verificacao)
            {
                objEmailEnviado.Estados = 9;
                return;
            }


            //se nao tem erro
            objEmailEnviado.Estados = 99;
            objEmailEnviadoDao.create(objEmailEnviado);
            return;
        }
        public void update(EmailEnviado objEmailEnviado)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Nome = objEmailEnviado.Nome;
            string RazaoSocial = objEmailEnviado.RazaoSocial;
            string Email = objEmailEnviado.Email;
            string Motivo = objEmailEnviado.Motivo;
            string Data = objEmailEnviado.Data.ToString();
            string Status = objEmailEnviado.Status;


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objEmailEnviado.Estados = 99;
            objEmailEnviadoDao.update(objEmailEnviado);
            return;
        }
        public void delete(EmailEnviado objEmailEnviado)
        {
            bool verificacao = true;
            //verificando se existe
            EmailEnviado objEmailEnviadoAux = new EmailEnviado();
            objEmailEnviadoAux.Id = objEmailEnviado.Id;
            verificacao = objEmailEnviadoDao.find(objEmailEnviadoAux);
            if (!verificacao)
            {
                objEmailEnviado.Estados = 33;
                return;
            }


            objEmailEnviado.Estados = 99;
            objEmailEnviadoDao.delete(objEmailEnviado);
            return;
        }
        public bool find(EmailEnviado objEmailEnviado)
        {
            return objEmailEnviadoDao.find(objEmailEnviado);
        }
        public List<EmailEnviado> findAll()
        {
            return objEmailEnviadoDao.findAll();
        }
        public List<EmailEnviado> findAllEmailEnviado(EmailEnviado objEmailEnviado)
        {
            return objEmailEnviadoDao.findAllEmailEnviado(objEmailEnviado);
        }

    }
}
