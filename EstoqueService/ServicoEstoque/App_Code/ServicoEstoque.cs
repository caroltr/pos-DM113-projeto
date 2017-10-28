using EstoqueEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;

namespace Products
{
    [AspNetCompatibilityRequirements(
        RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

    public class ServicoEstoque : IServicoEstoque, IServicoEstoqueV2
    {
        public bool AdicionarEstoque(string numeroProduto, int quantidade)
        {
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque matchingProduct = database.Products.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);

                    matchingProduct.EstoqueProduto += quantidade;

                    // Save the change back to the database
                    database.SaveChanges();
                }
            }
            catch
            {
                // If an exception occurs, return false to indicate failure
                return false;
            }

            // Return true to indicate success
            return true;
        }

        public int ConsultarEstoque(string numeroProduto)
        {
            Produto p = VerProduto(numeroProduto);

            if (p == null)
            {
                return -1;
            }
            else
            {
                return p.EstoqueProduto;
            }
        }

        public bool IncluirProduto(Produto produto)
        {
            // Já possui produto cadastrado com ests numero
            if(VerProduto(produto.NumeroProduto) != null)
            {
                return false;
            }

            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = new ProdutoEstoque();
                    produtoEstoque.NumeroProduto= produto.NumeroProduto;
                    produtoEstoque.NomeProduto = produto.NomeProduto;
                    produtoEstoque.DescricaoProduto = produto.DescricaoProduto;
                    produtoEstoque.EstoqueProduto = produto.EstoqueProduto;

                    database.Products.Add(produtoEstoque);

                    // Save the change back to the database
                    database.SaveChanges();
                }
            }
            catch
            {
                // If an exception occurs, return false to indicate failure
                return false;
            }

            // Return true to indicate success
            return true;
        }

        public List<Produto> ListarProdutos()
        {
            // Create a list of products
            List<Produto> produtosList = new List<Produto>();
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Fetch the products in the database
                    List<ProdutoEstoque> products = (from product in database.Products
                                              select product).ToList();
                    foreach (ProdutoEstoque product in products)
                    {
                        Produto productData = new Produto()
                        {
                            NumeroProduto = product.NumeroProduto,
                            NomeProduto = product.NomeProduto,
                            DescricaoProduto = product.DescricaoProduto,
                            EstoqueProduto = product.EstoqueProduto
                        };
                        produtosList.Add(productData);
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }

            // Return the list of products
            return produtosList;
        }

        public bool RemoverEstoque(string numeroProduto, int quantidade)
        {
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque matchingProduct = database.Products.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);

                    // Verifica se a quantidade a remover é maior que a quantidade em estoque.
                    // Se sim, a quantidade passa a ser 0.
                    if (matchingProduct.EstoqueProduto < quantidade)
                        matchingProduct.EstoqueProduto = 0;
                    else 
                        matchingProduct.EstoqueProduto -= quantidade;

                    // Save the change back to the database
                    database.SaveChanges();
                }
            }
            catch
            {
                // If an exception occurs, return false to indicate failure
                return false;
            }

            // Return true to indicate success
            return true;
        }

        public bool RemoverProduto(string numeroProduto)
        {
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque matchingProduct = database.Products.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);
                    
                    database.Products.Remove(matchingProduct);

                    // Save the change back to the database
                    database.SaveChanges();
                }
            }
            catch
            {
                // If an exception occurs, return false to indicate failure
                return false;
            }

            // Return true to indicate success
            return true;
        }

        public Produto VerProduto(string numeroProduto)
        {
            Produto produto = null;
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque matchingProduct = database.Products.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);

                    if (matchingProduct == null)
                    {
                        return null;
                    }

                    produto = new Produto()
                    {
                        NumeroProduto = matchingProduct.NumeroProduto,
                        NomeProduto = matchingProduct.NomeProduto,
                        DescricaoProduto = matchingProduct.DescricaoProduto,
                        EstoqueProduto = matchingProduct.EstoqueProduto
                    };
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }

            // Return the product
            return produto;
        }
    }    
}
