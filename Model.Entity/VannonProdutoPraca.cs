using System;

namespace Model.Entity
{
    public class VannonProdutoPraca
    {
        public string CodigoProdutoSku { get; set; }
        public double? Quantidade { get; set; }
        public double? PrecoDe { get; set; }
        public double? PrecoPor { get; set; }

        public VannonProdutoPraca()
        {

        }

        public VannonProdutoPraca(SyncProduto DrogaNossaProduto, double faixaDeVenda)
        {
            CodigoProdutoSku = DrogaNossaProduto.Barras;
            Quantidade = DrogaNossaProduto.Quantidade;
            //Calculando Desconto da faixa de preço
            var precoPor = DrogaNossaProduto.Preco - (DrogaNossaProduto.Preco.Value * (faixaDeVenda / 100));
            PrecoDe = Math.Round(DrogaNossaProduto.Preco.Value, 2);
            PrecoPor = precoPor != null ? Math.Round(precoPor.Value, 2) : 0.0;
        }
    }
}
