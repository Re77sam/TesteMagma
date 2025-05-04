// Problemas identificados no código original:
//
// 1. ❌ Uso incorreto de ReadAsString() → O correto é ReadAsStringAsync() para ler o conteúdo da resposta corretamente.
// 2. ❌ Ausência de verificação do StatusCode → Se a resposta for um erro (exemplo: 404 ou 500), o código falharia na desserialização.
// 3. ❌ Falta de tratamento de exceções → Se a API estiver offline ou o JSON for inválido, não há nenhum mecanismo de captura de erro.
// 4. ❌ HttpClient sendo instanciado diretamente → Melhor usar uma instância única para evitar desperdício de recursos.
// 5. ❌ Não passando a cidade na URL → Se a API aceita uma cidade como parâmetro, devemos enviá-la corretamente.
// 6. ❌ Retorno inconsistente → Não foi tratado o caso em que a resposta da API é inválida ou vazia.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class ApiService
{
    private readonly HttpClient _httpClient;

    // ✅ Corrigido: Uso correto de uma instância única de HttpClient
    public ApiService()
    {
        _httpClient = new HttpClient();
    }

    // ✅ Corrigido: Método seguro e assíncrono para consumir a API
    public async Task<Ativo?> PegaAtivosAsync(string cidade)
    {
        try
        {
            // ✅ Validação de entrada: O parâmetro cidade não pode ser nulo ou vazio
            if (string.IsNullOrEmpty(cidade))
                throw new ArgumentException("O parâmetro cidade não pode ser vazio.");

            var url = $"https://api.magma-3.com/v2/Force1/GetAssets?cidade={cidade}";
            var resposta = await _httpClient.GetAsync(url);

            // ✅ Corrigido: Verificação do status HTTP antes de tentar processar a resposta
            if (!resposta.IsSuccessStatusCode)
            {
                Console.WriteLine($"Erro ao acessar API: {resposta.StatusCode}");
                return null;
            }

            // ✅ Correção do método de leitura do conteúdo
            var conteudo = await resposta.Content.ReadAsStringAsync();

            // ✅ Tratamento: Se o conteúdo for vazio, evitamos erro na desserialização
            if (string.IsNullOrEmpty(conteudo))
            {
                Console.WriteLine("Erro: A resposta da API está vazia.");
                return null;
            }

            // ✅ Correção: Desserialização segura do JSON
            var ativo = JsonConvert.DeserializeObject<Ativo>(conteudo);

            return ativo;
        }
        catch (Exception ex)
        {
            // ✅ Tratamento de exceções: Captura erros para evitar falhas inesperadas
            Console.WriteLine($"Erro ao consumir API: {ex.Message}");
            return null;
        }
    }
}


// Melhorias Implementadas na Correção do Código:

//✅ Correção do método ReadAsStringAsync():
//   -O código original usava `ReadAsString()`, que não existe.
//   - O correto é `ReadAsStringAsync()` para leitura assíncrona da resposta da API.

//✅ Verificação do StatusCode antes de processar a resposta:
//   -Se a API retorna um erro (exemplo: 404 ou 500), a desserialização falharia.
//   - Agora, antes de ler o conteúdo, verificamos `IsSuccessStatusCode`.

//✅ Uso de try-catch para evitar falhas inesperadas:
//   -Se houver uma falha na conexão ou um erro na API, o código agora captura a exceção.
//   - Isso evita que a aplicação quebre inesperadamente.

//✅ Instância única de HttpClient:
//   -No código original, `HttpClient` era instanciado dentro do método, causando possíveis desperdícios de recursos.
//   - Agora usamos uma instância global dentro da classe `ApiService`.

//✅ Validação do parâmetro "cidade":
//   -Antes, o método aceitava qualquer valor, até mesmo `null` ou `""`, o que poderia causar falhas na API.
//   - Agora validamos se `cidade` está preenchido antes de fazer a requisição.

//✅ Proteção contra respostas vazias da API:
//   -Se a API retornar um JSON vazio ou inválido, `JsonConvert.DeserializeObject` falharia.
//   - Agora verificamos se `conteudo` está vazio antes de tentar desserializar.

// Com essas correções, a aplicação agora está mais **segura, eficiente e confiável** para consumir APIs externas!
