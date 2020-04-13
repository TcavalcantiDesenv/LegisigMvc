using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Monitor1
    {
        public int Id { get; set; }

        public int Estados { get; set; }

        [Display(Name = "Métodos")]
        public string Metodos { get; set; }
        public string Tipo { get; set; }
        public string Finalidade { get; set; }
        public string Frequencia { get; set; }
        public string Responsavel { get; set; }
        public string Situacao { get; set; }
        public Nullable<System.DateTime> Validade { get; set; }
        public Nullable<System.DateTime> ProxData { get; set; }
        public Nullable<int> Prazo { get; set; }
        public string Observacao { get; set; }
        public Nullable<int> IdCondicionante { get; set; }
        public Nullable<int> IdLicenca { get; set; }
        public Nullable<int> IdLei { get; set; }
        public Monitor1(int id)
        {
            this.Id = id;
        }
        public Monitor1()
        {

        }
    }


}
