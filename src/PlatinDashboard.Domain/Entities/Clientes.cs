using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatinDashboard.Domain.Entities
{
    public class Clientes
    {

        public int Id { get; set; }
        public string N_Cliente { get; set; }
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
        public string IdUsuario { get; set; }
        public string EmailEmp { get; set; }
        public string EmailSis { get; set; }
        public string Aplicar { get; set; }

        public Clientes(int id)
        {
            this.Id = id;
        }
        public Clientes()
        {

        }
    }
}
