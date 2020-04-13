using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{


    public class CondicaoOp
    {
        public int Id { get; set; }
        public int Estados { get; set; }

        [Display(Name = "Código")]
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public CondicaoOp(int id)
        {
            this.Id = id;
        }
        public CondicaoOp()
        {

        }
    }

}
