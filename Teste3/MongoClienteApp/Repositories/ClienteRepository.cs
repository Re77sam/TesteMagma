// Repositories/ClienteRepository.cs
// Implementação do repositório que interage com o MongoDB.
using MongoDB.Driver;
using System.Collections.Generic;
using MongoClienteApp.Models;

namespace MongoClienteApp.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IMongoCollection<Cliente> _clientes;

        public ClienteRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017"); // Conecta ao MongoDB
            var database = client.GetDatabase("TesteMagmaDB"); // Define o banco de dados
            _clientes = database.GetCollection<Cliente>("Clientes"); // Define a coleção
        }

        // Método para obter todos os clientes do banco
        public List<Cliente> ObterTodos()
        {
            return _clientes.Find(cliente => true).ToList();
        }

        // Método para adicionar um novo cliente ao banco (com validação)
        public void Adicionar(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome) || string.IsNullOrEmpty(cliente.Email))
                throw new ArgumentException("Nome e Email são obrigatórios.");

            _clientes.InsertOne(cliente);
        }

        // Método para atualizar um cliente pelo ID
        public void AtualizarCliente(string id, Cliente clienteAtualizado)
        {
            if (string.IsNullOrEmpty(clienteAtualizado.Nome) || string.IsNullOrEmpty(clienteAtualizado.Email))
                throw new ArgumentException("Nome e Email são obrigatórios.");

            var filtro = Builders<Cliente>.Filter.Eq(c => c.Id, id);
            _clientes.ReplaceOne(filtro, clienteAtualizado);
        }

        // Método para excluir um cliente pelo ID
        public void ExcluirCliente(string id)
        {
            var filtro = Builders<Cliente>.Filter.Eq(c => c.Id, id);
            _clientes.DeleteOne(filtro);
        }
    }
}
