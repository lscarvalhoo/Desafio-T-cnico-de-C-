using MediatR;
using Movimento.Domain.Interfaces.Repositories;
using Movimento.Domain.Interfaces.Services;
using Movimento.Domain.Services;
using Movimento.Infrastructure.Persistence.Repository;
using Movimento.Infrastructure.Sqlite;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// sqlite
builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration.GetValue<string>("DatabaseName", "Data Source=database.sqlite") });
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IContaCorrenteService, ContaCorrenteService>();
builder.Services.AddTransient<IContaCorrenteRepository, ContaCorrenteRepository>();
builder.Services.AddTransient<IMovimentoRepository, MovimentoRepository>();
builder.Services.AddTransient<IMovimentoService, MovimentoService>();
builder.Services.AddTransient<IIdempotenciaRepository, IdempotenciaRepository>();
builder.Services.AddTransient<IIdempotenciaService, IdempotenciaService>();

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

// Informações úteis:
// Tipos do Sqlite - https://www.sqlite.org/datatype3.html


