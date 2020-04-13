using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Estado
    {
        public int Id { get; set; }
        public int Estados { get; set; }

        [Display(Name = "Nome")]

        public string Nome { get; set; }
        public string UF { get; set; }
        public string Pais { get; set; }

        public Estado(int id)
        {
            this.Id = id;
        }
        public Estado()
        {

        }

    }

}
