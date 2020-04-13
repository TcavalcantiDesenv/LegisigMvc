

using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Sistemas
    {
        public int Id { get; set; }
        [Display(Name = "Sistema")]
        public string Sistema { get; set; }
        public Sistemas(int id)
        {
            this.Id = id;
        }
        public Sistemas()
        {

        }

    }

}
