using Microsoft.EntityFrameworkCore;
using csharp_sqlite_api_crud.Entities;


namespace csharp_sqlite_api_crud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Customer> Customers => Set<Customer>();
    }
}


