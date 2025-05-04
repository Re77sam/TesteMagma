# 🚀 Force1ApiClient - Cliente de API para Integração

## 📌 Descrição
Force1ApiClient é um cliente API desenvolvido para interagir com serviços externos, permitindo requisições seguras e eficientes. O projeto fornece exemplos de chamadas GET, POST, PUT e DELETE utilizando autenticação baseada em token.

## 🛠️ Tecnologias Utilizadas
✅ **C# / .NET 6/7**  
✅ **HttpClient**  
✅ **Newtonsoft.Json**  

## ⚙️ Instalação e Configuração
### **1️⃣ Clonar o Repositório**
```bash
git clone https://github.com/seu-usuario/Force1ApiClient.git
cd Force1ApiClient
```

### **2️⃣ Instalar Dependências**
```bash
dotnet restore
```

### **3️⃣ Configurar Credenciais (Para Testes)**
Para autenticação, configure appsettings.json com os valores padrão para testes:

json
{
  "ApiBaseUrl": "https://api.exemplo.com",
  "Auth": {
    "Username": "testuser",
    "Password": "testpass",
    "Token": "TEST_API_TOKEN"
  }
}
> Observação: Estes valores são apenas para testes. Em produção, utilize variáveis de ambiente ou um gerenciador de segredos.

### **4️⃣ Executar a Aplicação**
```bash
dotnet run
```

## 🚀 Endpoints Disponíveis e Exemplos de Uso

### 🔹 Requisição GET (/dados)
csharp
var response = await client.GetAsync("https://api.exemplo.com/dados");
var result = await response.Content.ReadAsStringAsync();
Console.WriteLine(result);

### 🔹 Requisição POST (/criar)
csharp
var content = new StringContent(JsonConvert.SerializeObject(new { Nome = "Teste" }), Encoding.UTF8, "application/json");
var response = await client.PostAsync("https://api.exemplo.com/criar", content);
Console.WriteLine(await response.Content.ReadAsStringAsync());

### 🔹 Requisição PUT (/atualizar)
csharp
var content = new StringContent(JsonConvert.SerializeObject(new { Nome = "Teste Atualizado" }), Encoding.UTF8, "application/json");
var response = await client.PutAsync("https://api.exemplo.com/atualizar", content);
Console.WriteLine(await response.Content.ReadAsStringAsync());

### 🔹 Requisição DELETE (/deletar)
csharp
var response = await client.DeleteAsync("https://api.exemplo.com/deletar?id=123");
Console.WriteLine(await response.Content.ReadAsStringAsync());

## 🔍 Testes e Validação
- **Postman** → Teste os endpoints com requisições HTTP.
- **Unit Tests** → Escreva testes para validar o comportamento das chamadas.
- **Log de Erros** → Utilize Serilog para rastrear falhas e monitorar a execução.

## 📌 Melhorias e Expansões
✅ Suporte para autenticação OAuth2 
✅ Implementação de rate limiting 
✅ Cache de respostas para otimização 
✅ Integração com API de terceiros

## 📝 Conclusão
Force1ApiClient é um cliente leve para consumir APIs externas, proporcionando autenticação segura e chamadas otimizadas. Os valores padrão (testuser / testpass / TEST_API_TOKEN) são recomendados apenas para testes, e devem ser substituídos em ambientes reais. 🚀
