using ApiRest.Infra;
using ApiRest.Infra.Implementations;
using ApiRest.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

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
    }
}
