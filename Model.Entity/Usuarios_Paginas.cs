using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{

    public class Usuarios_Paginas
    {
        public int id { get; set; }
        public int Estados { get; set; }


        [Display(Name = "Código")]
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> Codigo { get; set; }
        public string Pagina { get; set; }
        public Usuarios_Paginas(int id)
        {
            this.id = id;
        }
        public Usuarios_Paginas()
        {

        }

    }

}
