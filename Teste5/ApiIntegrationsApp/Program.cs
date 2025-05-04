// Program.cs
// Testa integrações com Google Maps, DocuSign e Microsoft Graph.
using System;
using MongoClienteApp.Services;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("🔹 Testando integração com Google Maps...");
        var googleService = new GoogleMapsService();
        var coordenadas = googleService.ObterCoordenadas("Avenida Paulista, São Paulo");
        Console.WriteLine($"Localização: {coordenadas.Latitude}, {coordenadas.Longitude}");

        Console.WriteLine("🔹 Testando integração com DocuSign...");
        var docusignService = new DocuSignService();
        docusignService.CriarEnvelope();

        Console.WriteLine("🔹 Testando integração com Microsoft Graph...");
        var graphService = new MicrosoftGraphService();
        await graphService.EnviarEmailAsync("destinatario@email.com", "Teste API", "Este é um e-mail enviado via Microsoft Graph API.");

        Console.WriteLine("✅ Testes concluídos!");
    }
}
