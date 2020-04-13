using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class ControleOP
    {
        public int Id { get; set; }
        public int Estados { get; set; }

        [Display(Name = "Aspecto")]
        public int Aspecto { get; set; }
        public string Acao { get; set; }
        public string SimNao { get; set; }
        public string EvitImpacAmb { get; set; }
        public string Ocorrencia { get; set; }
        public string Oportunidade { get; set; }
        public ControleOP(int id)
        {
            this.Id = id;
        }
        public ControleOP()
        {

        }
    }
    
}
