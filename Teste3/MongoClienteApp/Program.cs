// Program.cs
// Testa operações CRUD no MongoDB.
using System;
using MongoClienteApp.Models;
using MongoClienteApp.Repositories;

class Program
{
    static void Main()
    {
        var repository = new ClienteRepository();

        Console.WriteLine("🔹 Adicionando cliente ao MongoDB...");
        var novoCliente = new Cliente { Nome = "Renan", Email = "renan@example.com" };
        repository.Adicionar(novoCliente);
        Console.WriteLine("✅ Cliente adicionado!");

        Console.WriteLine("🔹 Obtendo lista de clientes...");
        var clientes = repository.ObterTodos();
        foreach (var c in clientes)
        {
            Console.WriteLine($"ID: {c.Id}, Nome: {c.Nome}, Email: {c.Email}");
        }

        Console.WriteLine("🔹 Atualizando cliente...");
        var clienteAtualizado = new Cliente { Id = clientes[0].Id, Nome = "Renan Silva", Email = "renan.silva@example.com" };
        repository.AtualizarCliente(clientes[0].Id, clienteAtualizado);
        Console.WriteLine("✅ Cliente atualizado!");

        Console.WriteLine("🔹 Excluindo cliente...");
        repository.ExcluirCliente(clientes[0].Id);
        Console.WriteLine("✅ Cliente excluído!");

        Console.WriteLine("🔹 Lista final de clientes:");
        var clientesFinais = repository.ObterTodos();
        foreach (var c in clientesFinais)
        {
            Console.WriteLine($"ID: {c.Id}, Nome: {c.Nome}, Email: {c.Email}");
        }
    }
}
