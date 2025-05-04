# 🚀 ProdutoAPI - API REST para Gerenciamento de Produtos

## 📌 Descrição
ProdutoAPI é uma **API REST** desenvolvida em **ASP.NET Core**, utilizando **Repository Pattern** e **injeção de dependência** para um gerenciamento eficiente de produtos. O projeto inclui **CRUD completo**, integração com **MongoDB**, validações de entrada e suporte para **containerização via Docker**.

## 🛠️ Tecnologias Utilizadas
✅ **ASP.NET Core 7** → Framework para desenvolvimento da API.  
✅ **C#** → Linguagem de programação principal.  
✅ **MongoDB** → Banco de dados NoSQL para armazenamento de produtos.  
✅ **MongoDB.Driver** → Pacote para interagir com MongoDB em C#.  
✅ **Docker & Docker Compose** → Para execução em containers.  
✅ **Newtonsoft.Json** → Biblioteca para serialização de objetos JSON.

## ⚙️ Instalação e Configuração
### **1️⃣ Clonar o Repositório**
```bash
git clone https://github.com/re77sam/Teste2/ProdutoAPI.git
cd ProdutoAPI
```
### **2️⃣ Instalar Dependências**
Se estiver rodando manualmente:
```bash
dotnet restore
```
### **3️⃣ Configurar MongoDB**
Certifique-se de que MongoDB está rodando na porta padrão **27017**:
```bash
mongod --dbpath /data/db
```
Caso esteja rodando via Docker, execute:
```bash
docker-compose up -d
```
### **4️⃣ Executar a API**
```bash
dotnet run
```

## 🚀 Endpoints Disponíveis
### 🔹 Listar produtos (`GET /produtos`)
```bash
curl -X GET http://localhost:5000/produtos
```
💡 **Retorna a lista de todos os produtos cadastrados.**

### 🔹 Criar um novo produto (`POST /produtos`)
```bash
curl -X POST http://localhost:5000/produtos \
     -H "Content-Type: application/json" \
     -d '{"Nome": "Notebook", "Preco": 2999.99}'
```
💡 **Adiciona um produto ao banco de dados.**

### 🔹 Atualizar um produto (`PUT /produtos/{id}`)
```bash
curl -X PUT http://localhost:5000/produtos/6548fdxxxx \
     -H "Content-Type: application/json" \
     -d '{"Nome": "Notebook Gamer", "Preco": 4999.99}'
```
💡 **Modifica os dados de um produto existente.**

### 🔹 Excluir um produto (`DELETE /produtos/{id}`)
```bash
curl -X DELETE http://localhost:5000/produtos/6548fdxxxx
```
💡 **Remove o produto do banco de dados.**

## 🐳 Containerização com Docker
Caso queira executar a API dentro de um **container**, utilize os seguintes comandos:

### **1️⃣ Construir a Imagem**
```bash
docker build -t produtoapi .
```
### **2️⃣ Executar o Container**
```bash
docker run -d -p 8080:80 produtoapi
```
Agora a API estará disponível em:
```
http://localhost:8080/produtos
```

## 🔍 Testes e Validação
Para testar a API, recomenda-se utilizar:
- **Postman** → Interface gráfica para requisições HTTP.  
- **Insomnia** → Alternativa leve ao Postman.  
- **Swagger UI** → Documentação interativa (ativar no projeto).  

## 📌 Melhorias e Expansões
✅ **Adicionar autenticação JWT** para controle de acesso.  
✅ **Persistência com PostgreSQL** além de MongoDB.  
✅ **Logging com Serilog** para monitoramento de eventos.  
✅ **Deploy automatizado com GitHub Actions**.  

## 📝 Conclusão
ProdutoAPI é uma **solução modular e escalável** para gerenciamento de produtos em **ASP.NET Core**. Possui **CRUD completo, integração com MongoDB, validações e suporte para Docker**. 🚀 Se precisar de melhorias como **deploy na nuvem**, **autenticação** ou **suporte a novas tecnologias**, me avise! 😃🎯
