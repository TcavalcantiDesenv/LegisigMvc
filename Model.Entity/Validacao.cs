using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{

    public class Validacao
    {
        public int id { get; set; }
        public int Estados { get; set; }


        [Display(Name = "Código")]
        public int IDCliente { get; set; }
        public int IDLegis { get; set; }
        public int IDParametros { get; set; }
        public string Obrigacao { get; set; }
        public string Evidencias { get; set; }
        public Nullable<System.DateTime> DataAvaliacao { get; set; }
        public string Avaliado { get; set; }
        public string Anexo { get; set; }
        public Nullable<System.DateTime> DataValidacao { get; set; }
        public string Validado { get; set; }
        public Nullable<System.DateTime> ProxAvaliacao { get; set; }
        public string Resultado { get; set; }
        public Validacao(int id)
        {
            this.id = id;
        }
        public Validacao()
        {

        }

    }

}
