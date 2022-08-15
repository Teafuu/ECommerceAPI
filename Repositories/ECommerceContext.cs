using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories
{
    public class ECommerceContext : DbContext
    {
        public DbSet<User> UserTable { get; set; }
        public DbSet<Product> ProductTable { get; set; }

        public ECommerceContext(DbContextOptions<ECommerceContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
