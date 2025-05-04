using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
/*  Código modularizado com boas práticas 
 *  Uso de interface para facilitar testes e manutenção 
 *  Flexibilidade para diferentes tipos de ativos e paginação*/

public class Program
{
    public static async Task Main()
    {
        var service = new AssetService(new HttpClient());
        var inactiveComputers = await service.GetInactiveComputersAsync("computador", 0, 60);

        Console.WriteLine("Computadores sem comunicação há mais de 60 dias:");
        inactiveComputers.ForEach(Console.WriteLine);
    }
}

// Interface para abstração
public interface IAssetService
{
    Task<List<string>> GetInactiveComputersAsync(string assetType, int pagination, int days);
}

// Implementação do serviço que consome a API
public class AssetService : IAssetService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://api.magma-3.com/v2/Force1/GetAssets";

    public AssetService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<string>> GetInactiveComputersAsync(string assetType, int pagination, int days)
    {
        var requestUrl = $"{BaseUrl}?assetType={assetType}&pagination={pagination}";

        var response = await _httpClient.GetAsync(requestUrl);
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var assets = JsonSerializer.Deserialize<List<Asset>>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        var inactiveComputers = new List<string>();
        foreach (var asset in assets)
        {
            if ((DateTime.Now - asset.LastCommunication).TotalDays > days)
            {
                inactiveComputers.Add(asset.Name);
            }
        }

        return inactiveComputers;
    }
}

// Modelo para deserialização de JSON
public class Asset
{
    public string Name { get; set; }
    public DateTime LastCommunication { get; set; }
}
