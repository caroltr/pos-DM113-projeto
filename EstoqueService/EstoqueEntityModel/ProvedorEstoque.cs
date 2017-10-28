namespace EstoqueEntityModel
{
    using System.Data.Entity;

    public class ProvedorEstoque : DbContext
    {
        public ProvedorEstoque()
            : base("name=ProvedorEstoque")
        {
        }

        public virtual DbSet<ProdutoEstoque> Products { get; set; }
    }
    
    public class ProdutoEstoque
    {
        public int Id { get; set; }
        public string NumeroProduto { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int EstoqueProduto { get; set; }
    }
}