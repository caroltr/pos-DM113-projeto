using System.ServiceModel;
using Products;
using System;

namespace ProvedorEstoqueHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(ServicoEstoque));
            serviceHost.Open();
            Console.WriteLine("Service Running");

            Console.ReadLine();
            Console.WriteLine("Service Stopping");
            serviceHost.Close();
        }
    }
}
