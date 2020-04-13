using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{


    public class EmailEnviado
    {
        public int Id { get; set; }
        public int Estados { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Email { get; set; }
        public string Motivo { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public string Status { get; set; }

        public EmailEnviado(int id)
        {
            this.Id = id;
        }
        public EmailEnviado()
        {

        }
    }
    
}
