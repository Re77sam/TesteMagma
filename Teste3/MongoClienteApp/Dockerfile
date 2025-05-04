# Dockerfile
# 1. Usando imagem base do .NET para aplicações Web
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# 2. Imagem do SDK do .NET para build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MongoClienteApp.csproj", "./"]
RUN dotnet restore "./MongoClienteApp.csproj"

# 3. Copia todo o código e compila
COPY . .
WORKDIR "/src"
RUN dotnet build -c Release -o /app/build

# 4. Publica os arquivos binários
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# 5. Cria o container final com a aplicação pronta para rodar
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MongoClienteApp.dll"]
