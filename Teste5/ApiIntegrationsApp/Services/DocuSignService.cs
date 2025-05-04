// Services/DocuSignService.cs
// Serviço para envio de documentos via DocuSign.
using System;
using DocuSign.eSign.Api;
using DocuSign.eSign.Client;
using DocuSign.eSign.Model;

public class DocuSignService
{
    private readonly string _integratorKey = "SUA_INTEGRATOR_KEY";
    private readonly string _userId = "SEU_USER_ID";
    private readonly string _clientSecret = "SEU_CLIENT_SECRET";
    private readonly string _basePath = "https://demo.docusign.net/restapi";

    public void CriarEnvelope()
    {
        var apiClient = new ApiClient(_basePath);
        apiClient.SetOAuthBasePath("account-d.docusign.com");

        var authToken = apiClient.RequestJWTUserToken(_integratorKey, _userId, _clientSecret, 3600);
        apiClient.Configuration.AccessToken = authToken.accessToken;

        var envelopesApi = new EnvelopesApi(apiClient);
        var envelope = new EnvelopeDefinition
        {
            EmailSubject = "Por favor, assine este documento",
            Status = "sent",
            Documents = new List<Document>
            {
                new Document
                {
                    DocumentBase64 = Convert.ToBase64String(File.ReadAllBytes("documento.pdf")),
                    Name = "Contrato",
                    FileExtension = "pdf",
                    DocumentId = "1"
                }
            },
            Recipients = new Recipients
            {
                Signers = new List<Signer>
                {
                    new Signer
                    {
                        Email = "cliente@email.com",
                        Name = "Renan",
                        RecipientId = "1",
                        RoutingOrder = "1",
                        Tabs = new Tabs
                        {
                            SignHereTabs = new List<SignHere>
                            {
                                new SignHere { AnchorString = "Assine aqui", AnchorXOffset = "10", AnchorYOffset = "20" }
                            }
                        }
                    }
                }
            }
        };

        var resultado = envelopesApi.CreateEnvelope("meu-account-id", envelope);
        Console.WriteLine($"Envelope criado! ID: {resultado.EnvelopeId}");
    }
}
