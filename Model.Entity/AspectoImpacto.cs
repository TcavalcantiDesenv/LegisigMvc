using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{


    public class AspectoImpacto
    {
        public int Id { get; set; }
        public int Estados { get; set; }

        [Display(Name = "Id")]
        public int IdProcesso { get; set; }
        public int IdAtividade { get; set; }
        public string Entrada { get; set; }
        public string Con { get; set; }
        public string Saida { get; set; }
        public string ImpAmbiental { get; set; }
        public string AltA { get; set; }
        public string AltB { get; set; }
        public string Inc { get; set; }
        public string ContrInflu { get; set; }
        public string Tem { get; set; }
        public string Abr { get; set; }
        public string FP { get; set; }
        public string Gra { get; set; }
        public string Interessada { get; set; }
        public string RequisitoA { get; set; }
        public string RequisitoB { get; set; }
        public string Req { get; set; }
        public string RiscOportA { get; set; }
        public string RiscOportB { get; set; }

        public AspectoImpacto(int id)
        {
            this.Id = id;
        }
        public AspectoImpacto()
        {

        }
    }

}
