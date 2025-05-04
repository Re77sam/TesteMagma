// Program.cs
// Configura��o da API e inje��o de depend�ncia.
using ProdutoApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Registra os controllers e o reposit�rio na inje��o de depend�ncia
builder.Services.AddControllers();
builder.Services.AddSingleton<IProdutoRepository, ProdutoRepository>();

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();
