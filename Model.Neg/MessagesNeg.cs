using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class MessagesNeg
    {
        private MessagesDao objMessagesDao;

        public MessagesNeg()
        {
            objMessagesDao = new MessagesDao();

        }

        public void create(Messages objMessages)
        {
            bool verificacao = true;


            string Date = objMessages.Date.ToString();
            string Subject = objMessages.Subject;
            string From = objMessages.From;
            string To = objMessages.To;
            string Text = objMessages.Text;
            string Folder = objMessages.Folder;
            string Unread = objMessages.Unread.ToString();
            string HasAttachment = objMessages.HasAttachment.ToString();
            // int Estados = objMessages.Estados;
            string IsReply = objMessages.IsReply.ToString();

            //begin verificar duplicidade cpf retorna estado=8
            Messages objMessages1 = new Messages();
            objMessages1.ID = objMessages.ID;
            verificacao = !objMessagesDao.findMessagePorId(objMessages1);
            if (!verificacao)
            {
                objMessages.Estados = 9;
                return;
            }


            //se nao tem erro
            objMessages.Estados = 99;
            objMessagesDao.create(objMessages);
            return;
        }
        public void update(Messages objMessages)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string Date = objMessages.Date.ToString();
            string Subject = objMessages.Subject;
            string From = objMessages.From;
            string To = objMessages.To;
            string Text = objMessages.Text;
            string Folder = objMessages.Folder;
            string Unread = objMessages.Unread.ToString();
            string HasAttachment = objMessages.HasAttachment.ToString();
            // int Estados = objMessages.Estados;
            string IsReply = objMessages.IsReply.ToString();


            // Inicia validacao

            /// ???????????

            //se nao tem erro
            objMessages.Estados = 99;
            objMessagesDao.update(objMessages);
            return;
        }
        public void delete(Messages objMessages)
        {
            bool verificacao = true;
            //verificando se existe
            Messages objMessagesAux = new Messages();
            objMessagesAux.ID = objMessages.ID;
            verificacao = objMessagesDao.find(objMessagesAux);
            if (!verificacao)
            {
                objMessages.Estados = 33;
                return;
            }


            objMessages.Estados = 99;
            objMessagesDao.delete(objMessages);
            return;
        }
        public bool find(Messages objMessages)
        {
            return objMessagesDao.find(objMessages);
        }
        public List<Messages> findAll()
        {
            return objMessagesDao.findAll();
        }
        public List<Messages> findAllMessages(Messages objMessages)
        {
            return objMessagesDao.findAllMessages(objMessages);
        }

    }
}
