using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Orgao
    {
        public int Id { get; set; }

        public int Estados { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public Orgao(int id)
        {
            this.Id = id;
        }
        public Orgao()
        {

        }

    }


}
