// Services/MicrosoftGraphService.cs
// Serviço para envio de emails via Microsoft Graph.
using System;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System.Net.Http.Headers;
using DocuSign.eSign.Model;

public class MicrosoftGraphService
{
    private readonly string _clientId = "SEU_CLIENT_ID";
    private readonly string _tenantId = "SEU_TENANT_ID";
    private readonly string _clientSecret = "SEU_CLIENT_SECRET";

    public async Task EnviarEmailAsync(string destinatario, string assunto, string corpo)
    {
        var clientApp = ConfidentialClientApplicationBuilder.Create(_clientId)
            .WithClientSecret(_clientSecret)
            .WithAuthority($"https://login.microsoftonline.com/{_tenantId}")
            .Build();

        var authProvider = new DelegateAuthenticationProvider(async (request) =>
        {
            var token = await clientApp.AcquireTokenForClient(new string[] { "https://graph.microsoft.com/.default" }).ExecuteAsync();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
        });

        var graphClient = new GraphServiceClient(authProvider);

        var emailMessage = new Message
        {
            Subject = assunto,
            Body = new ItemBody { Content = corpo, ContentType = BodyType.Text },
            ToRecipients = new List<Recipient> { new Recipient { EmailAddress = new EmailAddress { Address = destinatario } } }
        };

        await graphClient.Me.SendMail(emailMessage, true).Request().PostAsync();
        Console.WriteLine("Email enviado com sucesso!");
    }
}
