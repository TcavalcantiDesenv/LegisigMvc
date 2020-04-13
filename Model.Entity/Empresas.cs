using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Empresas
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Código")]
        public string N_Cliente { get; set; }
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string IE { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        [Display(Name = "Página Web")]
        public string HomePage { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Fone3 { get; set; }
        public string Fone4 { get; set; }
        [Display(Name = "Data de Cadastro")]
        public string DataCadastro { get; set; }
        public string IdUsuario { get; set; }
        public string EmailEmp { get; set; }
        public string EmailSis { get; set; }
        public string Aplicar { get; set; }

        public Empresas(int id)
        {
            this.Id = id;
        }
        public Empresas()
        {

        }

    }
}
