using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Interfaces;
using Repositories.Models;
using Repositories.Repositories;

namespace Repositories
{
    public static class Container
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceContext>(
                options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ECommerceAPI.Data;Trusted_Connection=True;MultipleActiveResultSets=true"));
            
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Product>, ProductRepository>();

            return services;
        }

    }
}
