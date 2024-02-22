using MediatR;
using Saldo.Domain.Interfaces.Repository;
using Saldo.Domain.Interfaces.Services;
using Saldo.Domain.Services;
using Saldo.Infrastructure.Persistence.Repository;
using Saldo.Infrastructure.Persistence.Sqlite;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration.GetValue<string>("DatabaseName", "Data Source=database.sqlite") }); 

builder.Services.AddMediatR(Assembly.GetExecutingAssembly()); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ISaldoService, SaldoService>();
builder.Services.AddTransient<ISaldoRepository, SaldoRepository>();
builder.Services.AddTransient<IContaCorrenteService, ContaCorrenteService>();
builder.Services.AddTransient<IContaCorrenteRepository, ContaCorrenteRepository>();
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
