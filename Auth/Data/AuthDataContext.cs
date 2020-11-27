using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Auth.Model;
using Microsoft.Extensions.Configuration;
using Auth.Data.Mappings;

namespace Auth.Data
{
    public class AuthDataContext : DataContext
    {
        private IConfiguration _configuration {get; set;}
         public AuthDataContext(DbContextOptions<AuthDataContext> options, 
            IConfiguration configuration)
            : base(options)
        {
            this._configuration = configuration;
        }

        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("Exemplo"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            RegisterMaps(builder);
        }

        public static void RegisterMaps(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClienteMap());
        }
    }
}