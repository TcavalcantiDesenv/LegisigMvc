using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Model.Entity
{

    public class Parametros
    {
        public Parametros()
        {
        }
        public Parametros(int id)
        {
            this.Id = id;
        }
        [Display(Name = "ID")]
        public int Id { get; set; }
  //      public int Estados { get; set; }
        public string Capitulo { get; set; }
        public string Item { get; set; }
        public int Parametro { get; set; }
        public string Obrigacao { get; set; }
        public int IDLegisGeral { get; set; }
        public string IDCliente { get; set; }
        public string Numero { get; set; }
        public string Aplicavel { get; set; }
        public string lei { get; set; }
        public string param { get; set; }
        public string Conhecimento { get; set; }
        public virtual LegisGeral LegisGeral { get; set; }
        
    }


}
