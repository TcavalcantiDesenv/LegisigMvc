using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlatinDashboard.Presentation.MVC.ApiServices
{
    public class ProdutosAbcFarmaHeader
    {
        public string pagina { get; set; }
        public string limit { get; set; }
        public string total_paginas { get; set; }
        public string total_data { get; set; }
        public List<ProdutosAbcFarma> data { get; set; }
    }
}