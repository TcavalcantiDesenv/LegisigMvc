namespace Model.Entity
{
    public class VannonProduto
    {
        public string barcode { get; set; }
        public int? store_id { get; set; }
        public string registroMS { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public decimal value { get; set; }
        public decimal discount { get; set; }
        public int situation { get; set; }
        public int groupId { get; set; }
        public string medicine { get; set; }
        public int promotion { get; set; }
        public int productDefinitionId { get; set; }
        public int productManufacturerId { get; set; }
        public int productCategoryId { get; set; }
        public int productSubCategoryId { get; set; }

        public VannonProduto(SyncProduto DrogaNossaProduto)
        {
            productCategoryId = DrogaNossaProduto.Classificacao == 1 ? 1 : DrogaNossaProduto.Classificacao == 3 ? 3 : DrogaNossaProduto.Classificacao == 2 ? 4 : 2;
            barcode = DrogaNossaProduto.Barras;
            description = DrogaNossaProduto.Nome.Replace("'", string.Empty).Trim();
            registroMS = "OCP0003";
        }

        public VannonProduto()
        {

        }
    }
}
