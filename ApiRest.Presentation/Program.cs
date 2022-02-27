using ApiRest.Infra;
using ApiRest.Infra.Implementations;
using ApiRest.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configuraçoes para o appsetings
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var ConnectionString = builder.Configuration.GetSection("ConnectionString")["ApiRestDatabase"];

builder.Services.AddDbContext<MainContext>(options => options.UseSqlServer(ConnectionString));


//dependencias
builder.Services.AddScoped<ICustomerRepository, CustomerRepositoryImpl>();


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
