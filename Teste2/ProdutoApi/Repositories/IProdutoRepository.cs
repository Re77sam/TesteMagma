// Repositories/IProdutoRepository.cs
// Esta interface define métodos para gerenciar produtos.
using System.Collections.Generic;
using ProdutoApi.Models;

namespace ProdutoApi.Repositories
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> GetAll(); // Retorna a lista de produtos
        Produto Add(Produto produto); // Adiciona um produto à lista
    }
}
