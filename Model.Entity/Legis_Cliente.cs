using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{

    public class Legis_Cliente
    {
        public int Id { get; set; }
        public int Estados { get; set; }

        [Display(Name = "Código")]
        public int IDCliente { get; set; }
        public int IDProduto { get; set; }
        public int IDSubProduto { get; set; }
        public int IDLegisGeral { get; set; }
        public string Aplicavel { get; set; }
        public string Aplicabilidade { get; set; }
        public string Conhecimento { get; set; }
        public string Ambito { get; set; }
        public string Atende { get; set; }
        public string NaoInformado { get; set; }
        public string AtendeParcial { get; set; }
        public string EmAndamento { get; set; }
        public string NaoAplicavel { get; set; }
        public string Sistema { get; set; }
        public int Total { get; set; }
        public string Lei { get; set; }
        public Legis_Cliente(int id)
        {
            this.Id = id;
        }
        public Legis_Cliente()
        {

        }
    }


}
