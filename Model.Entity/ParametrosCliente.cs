using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{

    public class ParametrosCliente
    {
        public int Id { get; set; }
        public Nullable<int> IDCliente { get; set; }
        public Nullable<int> IDLegisGeral { get; set; }
        public string Capitulo { get; set; }
        public string Item { get; set; }
        public string Parametro { get; set; }
        public string Obrigacao { get; set; }
        public int Numero { get; set; }
        public string Aplicavel { get; set; }
        public string Conhecimento { get; set; }
        public string Lei { get; set; }

        public ParametrosCliente(int id)
        {
            this.Id = id;
        }
        public ParametrosCliente()
        {

        }

    }
    
}
