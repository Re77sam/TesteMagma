# Force1ApiClient 🚀  

## 📌 Descrição  
Este projeto é um **cliente de API** desenvolvido em **C#** para consumir a API `Force1` e obter informações sobre ativos computacionais de uma empresa.  
Ele foi criado com boas práticas de desenvolvimento, utilizando **Docker** para facilitar sua execução e implantação.  

## ⚙️ Tecnologias Utilizadas  
- **C# (.NET 7 ou superior)** – Desenvolvimento da aplicação  
- **HttpClient** – Consumo da API externa  
- **Newtonsoft.Json** – Manipulação de dados JSON  
- **Docker** – Containerização da aplicação  
- **GitHub** – Versionamento do código  

## 📂 Estrutura do Projeto  
Force1ApiClient/  
├── src/                 # Código-fonte do projeto  
├── Dockerfile           # Configuração para container Docker  
├── docker-compose.yml   # Gerenciamento do Docker  
├── Force1ApiClient.csproj # Arquivo do projeto C#  
└── README.md            # Documentação do projeto  

## 🚀 Como Executar o Projeto  
### 📌 **1️⃣ Clonar o Repositório**  
```bash
git clone https://github.com/Re77sam/Teste1/Force1ApiClient.git  
cd TesteMagma1  
```

### 📌 **2️⃣ Instalar Dependências**  
Caso esteja rodando sem Docker, instale os pacotes necessários:  
```bash
dotnet restore  
```

### 📌 **3️⃣ Executar a Aplicação**  
**Sem Docker:**  
```bash
dotnet run  
```

**Com Docker:**  
```bash
docker-compose up --build  
```

## 🚀 Endpoints Disponíveis
A aplicação consome a API Force1 e retorna ativos computacionais com base nos seguintes parâmetros:

**Obter ativos computacionais inativos**
```http
GET /v2/Force1/GetAssets?assetType=computador&pagination=0
```
**📌 Descrição: Retorna a lista de ativos computacionais sem comunicação há mais de 60 dias.**

**Exemplo no código:**
```csharp
var inactiveComputers = await service.GetInactiveComputersAsync("computador", 0, 60);
```

**Filtrar ativos por categoria**
```http
GET /v2/Force1/GetAssets?assetType=servidor&pagination=0
```
**📌 Descrição: Filtra por servidores e outros tipos de ativos.**

## 🔥 Como Consumir a API  
A aplicação busca **ativos computacionais** que estão há mais de **60 dias sem comunicação**.  
O arquivo `Program.cs` pode ser modificado para filtrar outros tipos de ativos, adicionando diferentes parâmetros:  

```csharp
var inactiveComputers = await service.GetInactiveComputersAsync("computador", 0, 60);
```

## 🔍 Testes e Validação
Os testes podem ser realizados utilizando ferramentas como:

✅Postman → Para simular requisições HTTP à API

✅xUnit/NUnit → Para testes unitários no código

✅Docker Logs → Para verificar a execução no contêiner

##📌 Executar testes unitários
```bash
dotnet test
```

##📌 Verificar resposta da API via Postman
**Abra o Postman**

Insira a URL: **https://api.magma-3.com/v2/Force1/GetAssets?assetType=computador&pagination=0**

Clique em Send e verifique a resposta

## 📌 Melhorias e Expansões
Sugestões futuras para aprimorar o projeto:

✅ Implementação de cache para reduzir chamadas repetitivas à API

✅ Suporte a autenticação com tokens de segurança 

✅ Adição de uma interface gráfica para visualização dos dados 

✅ Melhorias na estrutura do código para facilitar a manutenção

## 📝 Conclusão
Este projeto fornece uma integração eficiente com a API Force1, possibilitando a obtenção de ativos computacionais de forma organizada e otimizada. Com a estrutura modular, testes automatizados e containerização via Docker, ele está pronto para ser expandido e aprimorado conforme as necessidades. 🚀🔥
