using EstoqueClient.EstoqueServicoReferencia;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EstoqueClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pressione ENTER para iniciar o serviço");
            Console.ReadLine();

            // ServicoEstoqueClient proxy = new ServicoEstoqueClient();
             ServicoEstoqueClient proxy = new ServicoEstoqueClient("BasicHttpBinding_IServicoEstoque");

            // Testando método "ListarProdutos"
            ListarProdutos(proxy);

            // Testando método "IncluirProduto"
            Produto novoProduto = new Produto();
            novoProduto.NumeroProduto = "15000";
            novoProduto.NomeProduto = "Produto 15";
            novoProduto.DescricaoProduto = "Este é o produto 15";
            novoProduto.EstoqueProduto = 150;

            IncluirProduto(proxy, novoProduto);

            // Testando método "VerProduto"
            VerProduto(proxy, novoProduto.NumeroProduto);

            // Testando método "AdicionarEstoque" e "ConsultarEstoque"
            AdicionarEstoque(proxy, novoProduto.NumeroProduto, 150);
            ConsultarEstoque(proxy, novoProduto.NumeroProduto);

            // Testando método "RemoverEstoque" e "ConsultarEstoque"
            RemoverEstoque(proxy, novoProduto.NumeroProduto, 50);
            ConsultarEstoque(proxy, novoProduto.NumeroProduto);

            // Testando método "RemoverProduto"
            RemoverProduto(proxy, novoProduto.NumeroProduto);
            VerProduto(proxy, novoProduto.NumeroProduto);
        }

        private static void ListarProdutos(ServicoEstoqueClient proxy)
        {
            Console.WriteLine("Listar produtos:");
            List<Produto> produtos = proxy.ListarProdutos().ToList();
            foreach (Produto p in produtos)
            {
                Console.WriteLine("Número: " + p.NumeroProduto);
                Console.WriteLine("Nome: " + p.NomeProduto);
                Console.WriteLine("Descricao: " + p.DescricaoProduto);
                Console.WriteLine("Estoque: " + p.EstoqueProduto);
                Console.WriteLine("");
            }
        }

        private static void VerProduto(ServicoEstoqueClient proxy, String numeroProduto)
        {
            Console.WriteLine("Ver produto de código " + numeroProduto + ":");
            Produto produto = proxy.VerProduto(numeroProduto);

            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
            }
            else
            {
                Console.WriteLine("Número: " + produto.NumeroProduto);
                Console.WriteLine("Nome: " + produto.NomeProduto);
                Console.WriteLine("Descricao: " + produto.DescricaoProduto);
                Console.WriteLine("Estoque: " + produto.EstoqueProduto);
                Console.WriteLine("");
            }
        }

        private static void IncluirProduto(ServicoEstoqueClient proxy, Produto produto)
        {
            Console.WriteLine("Incluir novo produto");

            bool incluido = proxy.IncluirProduto(produto);

            Console.WriteLine(incluido
                ? "Sucesso ao incluir produto " + produto.NumeroProduto
                : "Falha ao incluir produto " + produto.NumeroProduto);
            Console.WriteLine("");
        }

        private static void AdicionarEstoque(ServicoEstoqueClient proxy, String numeroProduto, int quantidade)
        {
            Console.WriteLine("Adicionar " + quantidade + " de estoque ao produto de código " + numeroProduto + ":");
            bool adicionadoEstoque = proxy.AdicionarEstoque(numeroProduto, quantidade);

            Console.WriteLine(adicionadoEstoque
                ? "Sucesso ao adicionar estoque."
                : "Falha ao adicionar estoque ");
            Console.WriteLine("");
        }

        private static void RemoverEstoque(ServicoEstoqueClient proxy, String numeroProduto, int quantidade)
        {
            Console.WriteLine("Remover " + quantidade + " de estoque ao produto de código " + numeroProduto + ":");
            bool adicionadoEstoque = proxy.RemoverEstoque(numeroProduto, quantidade);

            Console.WriteLine(adicionadoEstoque
                ? "Sucesso ao remover estoque."
                : "Falha ao remover estoque ");
            Console.WriteLine("");
        }

        private static void ConsultarEstoque(ServicoEstoqueClient proxy, String numeroProduto)
        {
            Console.WriteLine("Consultar estoque do produto de código " + numeroProduto + ":");
            int estoque = proxy.ConsultarEstoque(numeroProduto);
            Console.WriteLine("Estoque: " + estoque);
            Console.WriteLine("");
        }

        private static void RemoverProduto(ServicoEstoqueClient proxy, String numeroProduto)
        {
            Console.WriteLine("Remover produto de código " + numeroProduto + ":");
            bool adicionadoEstoque = proxy.RemoverProduto(numeroProduto);

            Console.WriteLine(adicionadoEstoque
                ? "Sucesso ao remover produto."
                : "Falha ao remover produto ");
            Console.WriteLine("");
        }
    }
}
