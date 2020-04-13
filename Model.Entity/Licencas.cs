using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{

    public class Licencas
    {
        public int Id { get; set; }
        public int Estados { get; set; }

        [Display(Name = "Código")]
        public int IdCliente { get; set; }
        public string Licenca { get; set; }
        public string Orgao { get; set; }
        public string Numero { get; set; }
        public DateTime Emissao { get; set; }
        public DateTime Validade { get; set; }
        public string Finalidade { get; set; }
        public string Requisito { get; set; }
        public string Obs { get; set; }
        public int Prazo { get; set; }
        public int Condicionante { get; set; }

        public Licencas(int id)
        {
            this.Id = id;
        }
        public Licencas()
        {

        }

    }


}
