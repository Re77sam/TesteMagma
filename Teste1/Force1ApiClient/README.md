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
git clone https://github.com/Re77sam/TesteMagma1.git  
cd TesteMagma1  

### 📌 **2️⃣ Instalar Dependências**  
Caso esteja rodando sem Docker, instale os pacotes necessários:  
dotnet restore  

### 📌 **3️⃣ Executar a Aplicação**  
**Sem Docker:**  
dotnet run  

**Com Docker:**  
docker-compose up --build  

## 🔥 Como Consumir a API  
A aplicação busca **ativos computacionais** que estão há mais de **60 dias sem comunicação**.  
O arquivo `Program.cs` pode ser modificado para filtrar outros tipos de ativos, adicionando diferentes parâmetros:  

```csharp
var inactiveComputers = await service.GetInactiveComputersAsync("computador", 0, 60);
