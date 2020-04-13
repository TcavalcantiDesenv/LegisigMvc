using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{

    public class LeisMonitoramento
    {
        public int Id { get; set; }

        public int Estados { get; set; }

        [Display(Name = "Código Lei")]
        public Nullable<int> IdLei { get; set; }
        public Nullable<int> IdMonitora { get; set; }

        public LeisMonitoramento(int id)
        {
            this.Id = id;
        }
        public LeisMonitoramento()
        {

        }
    }
   

}
