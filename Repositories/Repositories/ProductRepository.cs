using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public override async Task<Product?> GetByExpression(Expression<Func<Product, bool>> filter) => 
            await Task.FromResult(await Context.ProductTable.FirstOrDefaultAsync(filter) ?? null);
    }
}
