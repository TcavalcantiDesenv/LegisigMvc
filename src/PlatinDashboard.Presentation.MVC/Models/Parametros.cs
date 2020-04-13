using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlatinDashboard.Presentation.MVC.Models
{
    public class Parametros
    {
        public int Id { get; set; }
        public string Capitulo { get; set; }
        public string Item { get; set; }
        public string Parametro { get; set; }
        public int? Obrigacao { get; set; }
        public int IDLegisGeral { get; set; }
        public string IDCliente { get; set; }
        public int? Numero { get; set; }
        public int? Aplicavel { get; set; }
        public string lei { get; set; }
        public string param { get; set; }
        public int? Conhecimento { get; set; }

    }
}