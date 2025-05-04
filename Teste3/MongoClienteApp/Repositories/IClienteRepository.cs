// Repositories/IClienteRepository.cs
// Interface que define os métodos de acesso ao MongoDB.
using System.Collections.Generic;
using MongoClienteApp.Models;

namespace MongoClienteApp.Repositories
{
    public interface IClienteRepository
    {
        List<Cliente> ObterTodos(); // Retorna todos os clientes
        void Adicionar(Cliente cliente); // Adiciona um novo cliente ao banco
        void AtualizarCliente(string id, Cliente clienteAtualizado); // Atualiza cliente pelo ID
        void ExcluirCliente(string id); // Exclui um cliente pelo ID
    }
}
