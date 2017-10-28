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
        public string NumeroProduto { get; set; } // (chave prim�ria), nchar(10), N�o permite nulos
        public string NomeProduto { get; set; } // nchar(20), N�o Permite nulos
        public string DescricaoProduto { get; set; } // nchar(50), Permite nulos
        public int EstoqueProduto { get; set; } // Permite nulos
    }
}