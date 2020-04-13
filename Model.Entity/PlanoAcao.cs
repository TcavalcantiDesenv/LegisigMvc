using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{


    public class PlanoAcao
    {
        public int id { get; set; }
        public int IDParametros { get; set; }
        public string Causa { get; set; }
        [Display(Name = "Data Causa")]
        public DateTime DataCausa { get; set; }
        [Display(Name = "Ação Corretiva")]
        public string Correcao_Corretivas { get; set; }
        public DateTime Prazo { get; set; }
        public string Eficacia { get; set; }
        public DateTime DataEficacia { get; set; }
        public string Evidencias { get; set; }
        [Display(Name = "Resultado Final")]
        public string ResultFinal { get; set; }
        public int IDCliente { get; set; }
        public int IDLegis { get; set; }
        public int IDAcao { get; set; }


        public PlanoAcao(int id)
        {
            this.id = id;
        }
        public PlanoAcao()
        {

        }
    }

}
