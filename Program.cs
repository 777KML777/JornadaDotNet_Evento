using DevEvents.API.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Singleton faz o elemento persistir na memória.  Usa uma única instância durante toda a aplicação.
// First é um cenário muito específico. 
// Em muitos cenários não é uma boa esconder exceções porque tu esconde problemas maiores. 
// builder.Services.AddSingleton<EventosDbContext>();

// Acessa as configurações do seu projeto todo, incluíndo o appsettins.json. 
// builder.Configuration

builder.Services.AddDbContext<EventosDbContext>(o => o.UseInMemoryDatabase("DevEventoDb"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
