using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Interfaces;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories
{
    internal class UserRepository : BaseRepository<User>
    {
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ILogger<UserRepository> logger, ECommerceContext context)
        {
            _logger = logger;
            Context = context;
        }

        public override async Task<User> Add(User entity)
        {
            if (entity?.Email is null || entity?.Password is null)
            {
                _logger.LogWarning($"Invalid credentials, email: {entity?.Email} ; password: {entity?.Password}", entity);
                throw new ArgumentException("Invalid credentials");
            }

            return await base.Add(entity);
        }

        public override async Task<User?> GetByExpression(Expression<Func<User, bool>> filter) =>
            await Task.FromResult(await Context.UserTable.FirstOrDefaultAsync(filter) ?? null);
        
    }
}
