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
    public class OrderRepository : BaseRepository<Order>
    {
        public override async Task<Order?> GetByExpression(Expression<Func<Order, bool>> filter) => 
            await Task.FromResult(await Context.OrderTable.FirstOrDefaultAsync(filter) ?? null);
    }
}
