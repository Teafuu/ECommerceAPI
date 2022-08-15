using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public override async Task<Product?> GetByExpression(Expression<Func<Product, bool>> filter) => 
            await Task.FromResult(await Context.ProductTable.FirstOrDefaultAsync(filter) ?? null);
    }
}
