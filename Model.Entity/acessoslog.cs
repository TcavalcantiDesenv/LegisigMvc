using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{  
    public class acessoslog
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        public int Estados { get; set; }
        public Nullable<System.DateTime> data { get; set; }
        public string hora { get; set; }
        public string usuario { get; set; }
        public string login { get; set; }
        public string tela { get; set; }
        public string operacao { get; set; }
        public string conteudo { get; set; }

        public acessoslog(int id)
        {
            this.Id = id;
        }
        public acessoslog()
        {

        }
    }

    

}
