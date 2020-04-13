using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Atribuicoes
    {
        public int ID { get; set; }
        public int Estados { get; set; }


        [Display(Name = "Código")]
        public Nullable<int> Codigo { get; set; }
        public string Atribuicao { get; set; }
        public Nullable<int> IdPagina { get; set; }

        public Atribuicoes(int id)
        {
            this.ID = id;
        }
        public Atribuicoes()
        {

        }

    }
}
