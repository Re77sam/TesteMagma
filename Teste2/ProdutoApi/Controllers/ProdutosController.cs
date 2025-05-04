// Controllers/ProdutosController.cs
// Este controller lida com requisições HTTP para gerenciar produtos.
using Microsoft.AspNetCore.Mvc;
using ProdutoApi.Models;
using ProdutoApi.Repositories;
using System.Collections.Generic;

namespace ProdutoApi.Controllers
{
    [ApiController]
    [Route("produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        // GET /produtos - Retorna todos os produtos
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _produtoRepository.GetAll();
            return Ok(produtos); // Retorna lista de produtos com HTTP 200 OK
        }

        // POST /produtos - Adiciona um novo produto
        [HttpPost]
        public ActionResult<Produto> Post([FromBody] Produto produto)
        {
            if (produto == null)
                return BadRequest("Produto inválido."); // Valida entrada

            var novoProduto = _produtoRepository.Add(produto);
            return CreatedAtAction(nameof(Get), new { id = novoProduto.Id }, novoProduto); // Retorna 201 Created
        }
    }
}
