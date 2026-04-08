using coworking_salas.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json. Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//AddJsonOptions é para evitar ciclos infinitos de ligação entre usos e salas

builder.Services.AddControllers()
        .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


//essa parte estava sendo considerada inútil pelo código
//void AddJsonOptions(Func<object, object> value)
//{
//  throw new NotImplementedException();
//}

//adicionei para testar o swagger
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

//mais coisa para testar o swagger
//if (app.Environment.IsDevelopment())
//{
//   app.UseSwagger();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
