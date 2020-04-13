using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Model.Entity
{
   public class Arquivos
    {
        public int IDARQUIVO { get; set; }
        public int Estados { get; set; }
        public string DESCRICAO { get; set; }
        public string OBSERVACAO { get; set; }
        public DateTime DATA { get; set; }
        public string CAMINHO { get; set; }
        public string NOME { get; set; }
    }
}
