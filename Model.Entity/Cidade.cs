using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{


    public  class Cidade
    {
        public int Id { get; set; }
        public int Estados { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }
        public int Estado { get; set; }
        public Cidade(int id)
        {
            this.Id = id;
        }
        public Cidade()
        {

        }
    }
   
}
