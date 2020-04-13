using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{

    public class Messages
    {
        public int ID { get; set; }

        public int Estados { get; set; }

        [Display(Name = "Data")]
        public System.DateTime Date { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }
        public string Folder { get; set; }
        public bool Unread { get; set; }
        public bool HasAttachment { get; set; }
        public bool IsReply { get; set; }

        public Messages(int id)
        {
            this.ID = id;
        }
        public Messages()
        {

        }

    }


}
