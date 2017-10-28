using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Products
{
    [DataContract]
    public class Produto
    {
        [DataMember]
        public string NumeroProduto;

        [DataMember]
        public string NomeProduto;

        [DataMember]
        public string DescricaoProduto;

        [DataMember]
        public int EstoqueProduto;
    }

    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/01")]
    public interface IServicoEstoque
    {
        [OperationContract]
        List<Produto> ListarProdutos();

        [OperationContract]
        bool IncluirProduto(Produto Produto);

        [OperationContract]
        bool RemoverProduto(String numeroProduto);

        [OperationContract]
        int ConsultarEstoque(String numeroProduto);

        [OperationContract]
        bool AdicionarEstoque(String numeroProduto, int quantidade);

        [OperationContract]
        bool RemoverEstoque(String numeroProduto, int quantidade);

        [OperationContract]
        Produto VerProduto(String numeroProduto);
    }

    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/02")]
    public interface IServicoEstoqueV2
    {
        [OperationContract]
        bool AdicionarEstoque(String numeroProduto, int quantidade);

        [OperationContract]
        bool RemoverEstoque(String numeroProduto, int quantidade);
        
        [OperationContract]
        int ConsultarEstoque(String numeroProduto);
    }
}