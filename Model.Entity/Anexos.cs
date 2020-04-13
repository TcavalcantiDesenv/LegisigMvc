using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{


    public class Anexos
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        public int Estados { get; set; }

        public string Arquivo { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public Nullable<int> IDCliente { get; set; }
        public Nullable<int> IDLegisGeral { get; set; }
        public Nullable<int> IDConformidade { get; set; }
        public Nullable<int> IDParametros { get; set; }

        public Anexos(int id)
        {
            this.Id = id;
        }
        public Anexos()
        {

        }
    }
    
}
