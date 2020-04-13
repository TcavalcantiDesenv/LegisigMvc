using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Model.Entity 
{
    public class LegisGeral
    {
        public int Id { get; set; }
        public string Sistema { get; set; }
        public string Ambito { get; set; }
        public string Numero { get; set; }
        public string Ano { get; set; }
        public string Orgao { get; set; }
        public string Tema { get; set; }
        public string Ementa { get; set; }
        public string Tipo { get; set; }
        public string lei { get; set; }
        public string param { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public string link { get; set; }
        public string Localidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; } 
        public string Municipio { get; set; }
        public string Arqpdf { get; set; }
    }
}
