using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{

    public class Links
    {
        public int id { get; set; }
        [Display(Name = "Sistema")]

        public int Estados { get; set; }

        public string Sistema { get; set; }
        public string Ambito { get; set; }
        public string Orgao { get; set; }
        public string Numero { get; set; }
        public string Tema { get; set; }
        public string Link { get; set; }


        public Links(int id)
        {
            this.id = id;
        }
        public Links()
        {

        }

    }
    

}
