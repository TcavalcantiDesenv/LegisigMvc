using System;
using System.Collections.Generic;

namespace Model.Entity
{
    public class Execucao
    {
        public int ExecucaoId { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Fim { get; set; }
        public string Detalhes { get; set; }
        public string Status { get; set; }
        public virtual ICollection<ProdutoSincronizado> ProdutoSincronizados { get; set; }

        public Execucao()
        {
            Inicio = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            Detalhes = "Execução iniciada";
            Status = "Iniciada";
            ProdutoSincronizados = new List<ProdutoSincronizado>();
        }
    }
}