using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{

    public class Atividades
    {
        public int Id { get; set; }
        public int Estados { get; set; }

        [Display(Name = "Id")]
        public Nullable<int> ProcessoId { get; set; }
        public string Descricao { get; set; }

        public Atividades(int id)
        {
            this.Id = id;
        }
        public Atividades()
        {

        }
    }

}
