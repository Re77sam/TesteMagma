# O Dockerfile define como o contêiner será construído e executado. 
# Ele baixa dependências, compila o projeto, publica e executa dentro do ambiente do Docker.

# Definir a imagem base para execução
FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

# Definir a imagem do SDK para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Force1ApiClient.csproj", "./"]
RUN dotnet restore "./Force1ApiClient.csproj"

# Copiar todo o código-fonte e publicar
COPY . .
WORKDIR "/src"
RUN dotnet publish -c Release -o /app/publish

# Criar a imagem final para rodar o projeto
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Force1ApiClient.dll"]
