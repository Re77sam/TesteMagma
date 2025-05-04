// Models/Produto.cs
// Esta classe representa um produto na API, contendo ID, Nome e Preço.
namespace ProdutoApi.Models
{
    public class Produto
    {
        public int Id { get; set; } // Identificador único do produto
        public string Nome { get; set; } // Nome do produto
        public decimal Preco { get; set; } // Preço do produto
    }
}
    