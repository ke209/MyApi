using Core.ICore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Respository
{
    //[ExportApi(typeof(IDbContextRepository<UserDataContext>))]
    public class DbContextRepository<TDataContext> : IDbContextRepository<TDataContext>
    {
        public Task<TEntity> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class, new()
        {
            return Task.FromResult(new TEntity());
        }
    }
}
