using Microsoft.EntityFrameworkCore;

namespace Shared.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}