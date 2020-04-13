using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class LegisClientes
    {
        [Key]
        public int Id { get; set; }
        public int IDCliente { get; set; }
        public int IDProduto { get; set; }
        public int IDSubProduto { get; set; }
        public int IDLegisGeral { get; set; }
        public string Aplicavel { get; set; }
        public string Lei { get; set; }
    }
}
