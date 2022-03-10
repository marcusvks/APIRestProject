using ApiRest.Presentation.Extentions;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Adicionar autentica��o no swagger
Configure.ConfigureSwaggerAuthentication(builder);

// Basics
Configure.ConfigureBasics(builder);

// Autentica��o basica
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuth>("BasicAuthentication", null);

// Configura�oes para o appsetings
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// Configura��o do banco de dados
Configure.ConfigureConnectionString(builder);

// Configura��es de dependencias
Configure.ConfigureDependencies(builder);

//
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();
