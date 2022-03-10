using ApiRest.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Infra
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customer {get;set;}
        public DbSet<Arduino> Arduino { get; set; }
        public DbSet<ArduinoAction> ArduinoAction { get; set; }
    }
}