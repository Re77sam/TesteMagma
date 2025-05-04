// Models/Cliente.cs
// Define o modelo Cliente para armazenar no MongoDB.
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoClienteApp.Models
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // Identificador gerado pelo MongoDB

        public string Nome { get; set; } // Nome do cliente
        public string Email { get; set; } // Email do cliente
    }
}
