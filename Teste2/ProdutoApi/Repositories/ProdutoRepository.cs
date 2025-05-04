// Repositories/ProdutoRepository.cs
// Esta classe implementa a interface IProdutoRepository, armazenando produtos em memória.
using System;
using System.Collections.Generic;
using ProdutoApi.Models;

namespace ProdutoApi.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly List<Produto> _produtos = new(); // Lista de produtos em memória
        private int _nextId = 1; // ID sequencial dos produtos

        public IEnumerable<Produto> GetAll() => _produtos; // Retorna a lista de produtos

        public Produto Add(Produto produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto)); // Valida entrada

            produto.Id = _nextId++; // Gera um novo ID
            _produtos.Add(produto); // Adiciona à lista
            return produto; // Retorna o produto criado
        }
    }
}
