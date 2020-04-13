using System;

namespace Model.Entity
{
    public class ProdutoSincronizado
    {
        public int ProdutoSincronizadoId { get; set; }
        public string Ean { get; set; }
        public string Nome { get; set; }
        public string Detalhes { get; set; }
        public double? PrecoDe { get; set; }
        public double? PrecoPor { get; set; }
        public double? Quantidade { get; set; }
        public string Operacao { get; set; }
        public string Descricao { get; set; }            
        public string Status { get; set; }
        public DateTime DataSincronizacao { get; set; }
        public int ExecucaoId { get; set; }
        public virtual Execucao Execucao { get; set; }

        public ProdutoSincronizado()
        {
            
        }

        public ProdutoSincronizado(int execucaoId, string status, SyncProduto SyncProduto, string operacao, string descricao, double faixaDeVenda)
        {
            ExecucaoId = execucaoId;
            Ean = SyncProduto.Barras;
            Nome = SyncProduto.Nome;
            Detalhes = SyncProduto.Descricao;
            Operacao = operacao;
            Descricao = descricao;
            PrecoDe = SyncProduto.Preco;
            PrecoPor = SyncProduto.Preco - (SyncProduto.Preco.Value * (faixaDeVenda / 100));
            Quantidade = SyncProduto.Quantidade;
            Status = status;
            DataSincronizacao = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
        }

        public bool HouveMudanças(SyncProduto SyncProduto, double faixaDeVenda)
        {
            //Método para verifica se houve mudanças no produto desde a ultima sincronização
            var precoPor = SyncProduto.Preco - (SyncProduto.Preco.Value * (faixaDeVenda / 100));
            var houveMudanca =  Nome != SyncProduto.Nome ||
                        Detalhes != SyncProduto.Descricao ||
                            Math.Round(PrecoDe.Value, 2) != Math.Round(SyncProduto.Preco.Value, 2) ||
                                Math.Round(PrecoPor.Value, 2) != Math.Round(precoPor.Value, 2) ||
                                    Quantidade != SyncProduto.Quantidade;
            return houveMudanca;
        }
    }
}