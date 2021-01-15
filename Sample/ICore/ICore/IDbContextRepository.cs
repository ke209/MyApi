using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.ICore
{
    public interface IDbContextRepository<TDataContext>
    {
        Task<TEntity> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class, new();
    }
}
