using ApiRest.Infra;
using ApiRest.Infra.Implementations;
using ApiRest.Infra.Interfaces;
using ApiRest.Presentation.Extentions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuth>("BasicAuthentication", null);

//configuraçoes para o appsetings
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

string passEncrypted = builder.Configuration.GetSection("ConnectionString")["PasswordEncrypted"];
var user = builder.Configuration.GetSection("ConnectionString")["User"];
var server = builder.Configuration.GetSection("ConnectionString")["Server"];

string passDecrypted = Decrypter.Decrypter.Decrypt(passEncrypted);

var ConnectionString = $"user id={user};password={passDecrypted};server={server};database=ApiRestDatabase;connection timeout=150;MultipleActiveResultSets=true";

//configuração para o entity acessar o banco
builder.Services.AddDbContext<MainContext>(options => options.UseSqlServer(ConnectionString));

//dependencias
builder.Services.AddScoped<ICustomerRepository, CustomerRepositoryImpl>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
