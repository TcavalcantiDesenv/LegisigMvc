namespace Model.Entity
{
    public class VannonProdutoSku
    {
        public string CodigoProduto { get; set; }
        public bool? Brinde { get; set; }
        public string CodigoExterno { get; set; }
        public string Nome { get; set; }
        public string CodigoBarras { get; set; }
        public decimal? Peso { get; set; }
        public int? Altura { get; set; }
        public int? Largura { get; set; }
        public int? Profundidade { get; set; }
        public string CodigoMs { get; set; }

        public VannonProdutoSku()
        {

        }

        public VannonProdutoSku(string nome, string codigoBarras)
        {
            Nome = nome;
            CodigoBarras = codigoBarras;
            CodigoExterno = codigoBarras;
            CodigoProduto = codigoBarras;
        }
    }
}
