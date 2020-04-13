using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{


    public class Condicionantes
    {
        public int Id { get; set; }
        public int Estados { get; set; }


        [Display(Name = "Código")]
        public string Numero { get; set; }
        public string Descricao { get; set; }
        public string Avaliacao { get; set; }
        public string Controles { get; set; }
        public string Responsavel { get; set; }
        public string MeiosAnalise { get; set; }
        public string FrequenciaMonotora { get; set; }
        public string Situacao { get; set; }
        public string AplicavelPrazo { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public Nullable<int> Alerta { get; set; }
        public Nullable<int> IdLicenca { get; set; }

        public Condicionantes(int id)
        {
            this.Id = id;
        }
        public Condicionantes()
        {

        }
    }
  
}
