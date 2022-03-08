
using ApiRest.Presentation.Extentions;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

Configure.ConfigureBasics(builder);

// Autenticação basica
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuth>("BasicAuthentication", null);

//configuraçoes para o appsetings
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

Configure.ConfigureConnectionString(builder);
Configure.ConfigureDependencies(builder);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
