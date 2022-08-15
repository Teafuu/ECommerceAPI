using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public override async Task<Order?> GetByExpression(Expression<Func<Order, bool>> filter) => 
            await Task.FromResult(await Context.OrderTable.FirstOrDefaultAsync(filter) ?? null);
    }
}
