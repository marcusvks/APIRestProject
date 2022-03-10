using ApiRest.Infra;
using ApiRest.Infra.Implementations;
using ApiRest.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ApiRest.Presentation.Extentions
{
    public static class Configure
    {
        public static void ConfigureConnectionString(WebApplicationBuilder builder)
        {
            string passEncrypted = builder.Configuration.GetSection("ConnectionString")["PasswordEncrypted"];
            var user = builder.Configuration.GetSection("ConnectionString")["User"];
            var server = builder.Configuration.GetSection("ConnectionString")["Server"];

            string passDecrypted = Decrypter.Decrypter.Decrypt(passEncrypted);

            var ConnectionString = $"user id={user};password={passDecrypted};server={server};database=ApiRestDatabase;connection timeout=150;MultipleActiveResultSets=true";

            //configuração para o entity acessar o banco
            builder.Services.AddDbContext<MainContext>(options => options.UseSqlServer(ConnectionString));

        }

        public static void ConfigureDependencies(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICustomerRepository, CustomerRepositoryImpl>();

        }

        public static void ConfigureBasics(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

        }

        public static void ConfigureSwaggerAuthentication(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BasicAuth", Version = "v1" });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using Username and Password."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });
            });

        }
    }
}
