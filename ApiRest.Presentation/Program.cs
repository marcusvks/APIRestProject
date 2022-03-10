using ApiRest.Presentation.Extentions;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Adicionar autenticação no swagger
Configure.ConfigureSwaggerAuthentication(builder);

// Basics
Configure.ConfigureBasics(builder);

// Autenticação basica
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuth>("BasicAuthentication", null);

// Configuraçoes para o appsetings
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// Configuração do banco de dados
Configure.ConfigureConnectionString(builder);

// Configurações de dependencias
Configure.ConfigureDependencies(builder);

//
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();
