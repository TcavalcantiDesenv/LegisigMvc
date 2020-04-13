using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{


    public class Comercial
    {
        public int Id { get; set; }
        public int Estados { get; set; }

        [Display(Name = "Código")]
        public int IDCliente { get; set; }
        public int IDProduto { get; set; }
        public Nullable<int> IDSubProduto { get; set; }
        public Nullable<int> Licenca { get; set; }
        public Nullable<int> AnaliseReqPresencial { get; set; }
        public Nullable<int> AnaliseReqOnLine { get; set; }
        public string Validacao_Presencial { get; set; }
        public string Validacao_OnLine { get; set; }
        public Nullable<int> Sem_Validacao { get; set; }
        public Nullable<int> Aspecto_Impacto { get; set; }
        public Nullable<int> Vinculo_Legis_AI { get; set; }
        public Nullable<int> Perigo_Risco { get; set; }
        public Nullable<int> Vinculo_Legis_PR { get; set; }
        public string Plano { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public Nullable<int> Usuarios { get; set; }
        public Comercial(int id)
        {
            this.Id = id;
        }
        public Comercial()
        {

        }
    }

}
