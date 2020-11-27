using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shared.Data;
using Store.Data.Mappings;
using Store.Model;

namespace Store.Data
{
    public class StoreDataContext : DataContext
    {
        private IConfiguration _configuration { get; set; }

        public StoreDataContext(DbContextOptions<StoreDataContext> options,
        IConfiguration configuration)
         : base(options)
        {
            this._configuration = configuration;
        }

        public DbSet<Produto> Produto { get; set; }

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
            builder.ApplyConfiguration(new ProdutoMap());
        }
    }
}