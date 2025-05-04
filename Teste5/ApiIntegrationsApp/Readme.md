# 🚀 APIIntegracaoWeb - Integração de Múltiplas APIs Web

## 📌 Visão Geral
APIIntegracaoWeb é um projeto desenvolvido para integrar múltiplas APIs externas e fornecer uma camada de comunicação centralizada entre diversos serviços. Durante a implementação, enfrentamos desafios relacionados a autenticação, otimização de chamadas e tratamento de erros, que foram resolvidos através de ajustes estruturais e melhorias na arquitetura.

Este README documenta todas as correções, melhorias e padrões aplicados para garantir eficiência e segurança no uso da API.

## 🔍 Problemas Identificados

Durante a implementação e revisão do código, encontramos diversos problemas que comprometiam o funcionamento correto da API:

1️⃣ Falhas na Autenticação em APIs Externas  
- Algumas APIs exigiam autenticação via OAuth2, enquanto outras utilizavam tokens de acesso estáticos.  
- Correção: Implementamos um gerenciador de autenticação, que identifica a API e aplica o método correto de autenticação dinamicamente.  

2️⃣ Chamadas Redundantes e Desempenho Baixo  
- Muitas requisições eram repetidas sem necessidade, aumentando o consumo de rede e degradando o desempenho.  
- Correção: Implementamos caching com Redis, reduzindo chamadas desnecessárias e melhorando a resposta do sistema.  

3️⃣ Tratamento de Erros Deficiente  
- O sistema não gerenciava corretamente falhas nas APIs externas, retornando mensagens genéricas sem detalhes para depuração.  
- Correção: Criamos um mecanismo centralizado de erro, registrando logs detalhados sobre falhas e exceções.  

4️⃣ Estrutura do Código Pouco Modular  
- As funções de integração estavam espalhadas pelo código, dificultando manutenção e adição de novas APIs.  
- Correção: Separação das integrações em módulos específicos, permitindo fácil escalabilidade.  

5️⃣ Dados Sensíveis Expostos no Código  
- As credenciais e tokens de API estavam hardcoded no código-fonte, aumentando riscos de segurança.  
- Correção: Implementamos o uso de variáveis de ambiente e armazenamos chaves em um serviço seguro.  

## 🔧 Melhorias e Implementações

Após a identificação dos problemas, aplicamos diversas melhorias para otimizar a API:

✅ Autenticação Inteligente → O sistema detecta automaticamente o tipo de autenticação exigido.  
✅ Cache Estratégico → Uso do Redis para reduzir chamadas desnecessárias e otimizar tempo de resposta.  
✅ Tratamento Centralizado de Erros → Logs detalhados ajudam na depuração e análise de falhas.  
✅ Modularização de Código → Cada API tem seu próprio módulo, facilitando futuras expansões.  
✅ Segurança Aprimorada → Credenciais protegidas por variáveis de ambiente e sistemas de gerenciamento.  
✅ Monitoramento de Uso → Métricas sobre tempo de resposta, consumo de APIs e taxa de erro.  

## 📌 Como Executar a API

Para utilizar a APIIntegracaoWeb, siga os passos abaixo:

1️⃣ Clonar o Repositório  
```bash
git clone https://github.com/seu-usuario/APIIntegracaoWeb.git  
cd APIIntegracaoWeb  
dotnet restore  
dotnet run  
```
2️⃣ Configurar Credenciais  
Antes de rodar o sistema, defina variáveis de ambiente para armazenar chaves de API:  
```bash
export API_KEY_GOOGLE="SUA_CHAVE"  
export API_KEY_DOCUSIGN="SUA_CHAVE"  
export API_KEY_MS_GRAPH="SUA_CHAVE"  
```
Alternativamente, insira esses valores no appsettings.json (somente para testes):  
```bash
{  
  "GoogleAPIKey": "TEST_KEY",  
  "DocuSignAPIKey": "TEST_KEY",  
  "MicrosoftGraphClientSecret": "TEST_SECRET"  
}  
```
ATENÇÃO: Nunca exponha credenciais reais no código-fonte. Utilize variáveis de ambiente para garantir segurança.

## 🚀 Endpoints Disponíveis

### 🔹 Google Maps (Geocoding)  
```bash
GET /google/maps/geocode?address="Avenida Paulista, São Paulo"
```
Retorna coordenadas geográficas do endereço solicitado.  

### 🔹 DocuSign (Envio de Documentos)  
```bash
POST /docusign/send-document
```
Envia documentos para assinatura digital através da API DocuSign.  

### 🔹 Microsoft Graph (Envio de E-mails)  
```bash
POST /msgraph/send-email  
```
Dispara e-mails via Microsoft Graph para contas do Outlook.  

## 🔍 Testes e Validação

Para garantir que todas as funções estão operando corretamente, siga os testes abaixo:

- ✅**Testes de Integração** → Utilizando Postman ou curl, verifique se cada API responde corretamente.
  
- ✅**Testes de Desempenho** → Ferramentas como New Relic e Application Insights podem medir latência e tempo de resposta.
   
- ✅**Testes de Segurança** → Analise exposição de dados sensíveis utilizando scanners como OWASP ZAP.  

## 📝 Conclusão

O projeto APIIntegracaoWeb agora está estruturado, otimizado e seguro, pronto para consumo de múltiplas APIs externas. Com as melhorias implementadas, garantimos performance, escalabilidade e segurança no uso da API.  
