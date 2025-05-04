// Program.cs
// Configuração da API e injeção de dependência.
using ProdutoApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Registra os controllers e o repositório na injeção de dependência
builder.Services.AddControllers();
builder.Services.AddSingleton<IProdutoRepository, ProdutoRepository>();

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();
