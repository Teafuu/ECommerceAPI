using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories
{
    public class ECommerceContext : DbContext
    {
        public DbSet<User> UserTable { get; set; }
        public DbSet<Product> ProductTable { get; set; }
        public DbSet<Order> OrderTable { get; set; }

        public ECommerceContext(DbContextOptions<ECommerceContext> options)
            : base(options)
        {

        }
    }
}
