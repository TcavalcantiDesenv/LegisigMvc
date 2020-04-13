using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{


    public class Config
    {
        public int Id { get; set; }
        [Display(Name = "E-mail para")]
        public string emailpara { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string porta { get; set; }
        public string smtp { get; set; }
        public string semana { get; set; }
        public string periodo { get; set; }
        public Config(int id)
        {
            this.Id = id;
        }
        public Config()
        {

        }
    }
   
}
