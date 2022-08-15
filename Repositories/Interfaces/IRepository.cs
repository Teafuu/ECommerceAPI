using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IRepository<T> where T: class
    {
        public Task<T?> Get(int id);
        public Task<T> Add(T entity);

        public Task<bool> Update(T entity);

        public Task Delete(T entity);

        Task<T?> GetByExpression(Expression<Func<T, bool>> expression);
    }
}
