using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{

    public class Paginas
    {
        public int Id { get; set; }

        public int Estados { get; set; }

        [Display(Name = "Código")]
        public Nullable<int> Codigo { get; set; }
        public string Pagina { get; set; }

        public Paginas(int id)
        {
            this.Id = id;
        }
        public Paginas()
        {

        }

    }


}
