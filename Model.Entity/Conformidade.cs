using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{

    public class Conformidade
    {
        public int id { get; set; }
        public int IDCliente { get; set; }
        public int IDLegis { get; set; }
        public int IDParametros { get; set; }
        public string Obrigacao { get; set; }
        public string Evidencias { get; set; }
        [Display(Name = "Data de Avaliacao")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataAvaliacao { get; set; }
        public string Avaliado { get; set; }
        public string Anexo { get; set; }
        [Display(Name = "Data de Validacao")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataValidacao { get; set; }
        public string Validado { get; set; }
        public DateTime ProxAvaliacao { get; set; }
        public string Resultado { get; set; }

        public Conformidade(int id)
        {
            this.id = id;
        }
        public Conformidade()
        {

        }

    }
}
