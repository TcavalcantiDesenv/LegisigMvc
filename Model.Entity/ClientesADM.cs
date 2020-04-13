using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{


    public class ClientesADM
    {
        public int Id { get; set; }
        public int Estados { get; set; }

        [Display(Name = "Código")]
        public Nullable<int> N_Cliente { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string IE { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string HomePage { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Fone3 { get; set; }
        public string Fone4 { get; set; }
        public string DataCadastro { get; set; }

        public ClientesADM(int id)
        {
            this.Id = id;
        }
        public ClientesADM()
        {

        }
    }

}
