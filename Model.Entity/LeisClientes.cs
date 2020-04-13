using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class LeisClientes
    {
        public LeisClientes(int id)
        {
            this.IdLei = id;
        }
        public LeisClientes()
        {

        }
        public int IdLei { get; set; }
        public int Id { get; set; }
        public int Dias { get; set; }
        public string RazaoSocial { get; set; }
        public int IDCliente { get; set; }
        public int IDLegisGeral { get; set; }
        public string Aplicavel { get; set; }
        public string Sistema { get; set; }
        public string Ambito { get; set; }
        public string Numero { get; set; }
        public string Ano { get; set; }
        public string Orgao { get; set; }
        public string Tema { get; set; }
        public string Ementa { get; set; }
        public string Tipo { get; set; }
        [Display(Name = "Situação")]
        public string Lei { get; set; }
        public string Param { get; set; }
        public DateTime Data { get; set; }
        public string Link { get; set; }
        public string Localidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Municipio { get; set; }
        public string Arqpdf { get; set; }
        public string Ativo { get; set; }
    }
}
