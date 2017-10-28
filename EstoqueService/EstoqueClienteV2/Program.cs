using EstoqueClienteV2.EstoqueServicoReferencia;
using System;

namespace EstoqueClienteV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pressione ENTER para iniciar o serviço");
            Console.ReadLine();

            // ServicoEstoqueClient proxy = new ServicoEstoqueClient();
            ServicoEstoqueV2Client proxy = new ServicoEstoqueV2Client("WS2007HttpBinding_IServicoEstoque");
            
            // Consultar estoque do produto 1
            ConsultarEstoque(proxy, "1000");

            // Adicionar estoque ao produto 1
            AdicionarEstoque(proxy, "1000", 20);
            ConsultarEstoque(proxy, "1000");

            // Consultar estoque do produto 6
            ConsultarEstoque(proxy, "6000");

            // Adicionar estoque ao produto 6
            RemoverEstoque(proxy, "6000", 10);
            ConsultarEstoque(proxy, "6000");
        }

        private static void ConsultarEstoque(ServicoEstoqueV2Client proxy, String numeroProduto)
        {
            Console.WriteLine("Consultar estoque do produto de código " + numeroProduto + ":");
            int estoque = proxy.ConsultarEstoque(numeroProduto);
            Console.WriteLine("Estoque: " + estoque);
            Console.WriteLine("");
        }

        private static void AdicionarEstoque(ServicoEstoqueV2Client proxy, String numeroProduto, int quantidade)
        {
            Console.WriteLine("Adicionar " + quantidade + " de estoque ao produto de código " + numeroProduto + ":");
            bool adicionadoEstoque = proxy.AdicionarEstoque(numeroProduto, quantidade);

            Console.WriteLine(adicionadoEstoque
                ? "Sucesso ao adicionar estoque."
                : "Falha ao adicionar estoque ");
            Console.WriteLine("");
        }

        private static void RemoverEstoque(ServicoEstoqueV2Client proxy, String numeroProduto, int quantidade)
        {
            Console.WriteLine("Remover " + quantidade + " de estoque ao produto de código " + numeroProduto + ":");
            bool adicionadoEstoque = proxy.RemoverEstoque(numeroProduto, quantidade);

            Console.WriteLine(adicionadoEstoque
                ? "Sucesso ao remover estoque."
                : "Falha ao remover estoque ");
            Console.WriteLine("");
        }

       
    }
}
