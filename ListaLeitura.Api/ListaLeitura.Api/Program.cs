using ListaLeitura.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurações de serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura o EF Core com SQLite
builder.Services.AddDbContext<LeituraContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

// Configure o pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilita arquivos estáticos e define index.html como padrão
app.UseDefaultFiles();   
app.UseStaticFiles();    

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
