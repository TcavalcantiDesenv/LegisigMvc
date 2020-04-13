using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Processos
    {
        public int Id { get; set; }
        public int Estados { get; set; }

        [Display(Name = "Processo")]
        public string Processo { get; set; }
        public string Relacionado { get; set; }
        public string CicloVida { get; set; }

        public Processos(int id)
        {
            this.Id = id;
        }
        public Processos()
        {

        }
    }
    
}
