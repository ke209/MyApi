using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ICore.ICore
{
    public interface IDbContextRepository<TDataContext>
    {
        Task<TEntity> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class,new();
    }
}
