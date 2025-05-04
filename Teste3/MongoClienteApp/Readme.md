# 🚀 MongoAppClient - Cliente para Integração com MongoDB

## 📌 Descrição
MongoAppClient é uma aplicação desenvolvida em C# para interagir com um banco de dados MongoDB. O projeto realiza operações CRUD (criação, leitura, atualização e exclusão) para gerenciar informações de clientes.

## 🛠️ Tecnologias Utilizadas
✅ **C# / .NET 6/7**  
✅ **MongoDB**  
✅ **MongoDB.Driver**  

## ⚙️ Instalação e Configuração
### **1️⃣ Clonar o Repositório**
```bash
git clone https://github.com/re77sam/Teste3/MongoAppClient.git
cd MongoAppClient
```

### **2️⃣ Instalar Dependências**
```bash
dotnet restore
```

### **3️⃣ Configurar MongoDB**
Certifique-se de que MongoDB está rodando na porta padrão 27017:
```bash
mongod --dbpath /data/db
```
Caso esteja rodando via Docker, execute:
```bash
docker-compose up -d
```

### **4️⃣ Configurar Credenciais (Para Testes)**
O sistema pode utilizar credenciais padrões para autenticação em endpoints protegidos. No arquivo de configuração (appsettings.json), utilize valores como:

json
{
  "DatabaseSettings": {
    "Host": "localhost",
    "Port": 27017,
    "Username": "testuser",
    "Password": "testpass",
    "DatabaseName": "ClienteDB"
  }
}
> Observação: Esses valores são apenas para ambientes de teste e devem ser alterados em produção.

### **5️⃣ Executar a Aplicação**
```bash
dotnet run
```

## 🚀 Funcionalidades
✅ Listar clientes cadastrados
✅ Adicionar um novo cliente
✅ Atualizar os dados de um cliente existente
✅ Excluir um cliente

## 🔍 Testes e Validação
Utilize ferramentas como Postman para realizar requisições HTTP nos endpoints ou scripts automatizados para validar a funcionalidade.

## 📌 Melhorias e Expansões
✅ Adicionar autenticação JWT 
✅ Implementar cache de consultas 
✅ Monitoramento e logging com Serilog 
✅ Deploy automatizado com Docker e GitHub Actions

## 📝 Conclusão
MongoAppClient é um cliente robusto para integração com MongoDB, permitindo um gerenciamento eficiente de dados. Os valores padrão (testuser / testpass) são recomendados apenas para testes e devem ser substituídos em ambientes reais para garantir segurança. 🚀
