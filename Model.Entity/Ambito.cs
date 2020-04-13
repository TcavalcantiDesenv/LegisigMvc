using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{

    public class Ambito
    {
        public int Id { get; set; }

        [Display(Name = "Descri��o")]
        public string Descricao { get; set; }
        public int Estados { get; set; }


        public Ambito(int id)
        {
            this.Id = id;
        }
        public Ambito()
        {

        }
    }

  
}
