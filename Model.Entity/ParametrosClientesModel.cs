using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
   public class ParametrosClientesModel
    {
        public int Id { get; set; }
        public int NumCliente { get; set; }
        public int NumParametro { get; set; }
        public string Exigencia { get; set; }
        public string Assunto { get; set; }
        public string Capitulo { get; set; }
        public string Parametro { get; set; }
        public int Numero { get; set; }
        public string Obrigacao { get; set; }
        public string Aplicavel { get; set; }
        public string Conhecimento { get; set; }

        public ParametrosClientesModel(int id)
        {
            this.Id = id;
        }
        public ParametrosClientesModel()
        {

        }
    }
}
