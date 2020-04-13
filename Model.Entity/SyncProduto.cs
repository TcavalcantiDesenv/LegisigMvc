using System;

namespace Model.Entity
{
    public class SyncProduto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double? Uad { get; set; }
        public string Modelo { get; set; }
        public string Departamento { get; set; }
        public double? Preco { get; set; }
        public double? Quantidade { get; set; }
        public string Fornecedor { get; set; }
        public string Barras { get; set; }
        public double? Cum { get; set; }
        public double? Ucu { get; set; }
        public int? Classificacao { get; set; }
        public DateTime dca { get; set; }
        public int Estados { get; set; }
    }
}
