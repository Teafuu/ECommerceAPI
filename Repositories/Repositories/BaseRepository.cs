using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T: class
    {
        public ECommerceContext Context { get; set; }

        public virtual async Task<T?> Get(int id) => await Context.FindAsync<T>(id);
        public virtual async Task<T> Add(T entity)
        {
            var result = await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }

        public virtual async Task<bool> Update(T entity)
        {
            try
            {
                Context.Update(entity);
                await Context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }


        public virtual Task Delete(T entity)
        {
            try
            {
                Context.Remove(entity);
                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                return Task.FromException(e);
            }
        }
        public virtual Task<T?> GetByExpression(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
