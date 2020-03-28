using CORE.Common.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;


namespace CORE.Common.Repositories
{
    public interface IRepositoryAsync<TEntity> : IRepository<TEntity> where TEntity : tbl_base
    {
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<bool> DeleteAsync(params object[] keyValues);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
        
        Task<IEnumerable<TEntity>> SelectQueryAsync(string query, params object[] parameters);
        Task<IEnumerable<TEntity>> SelectQueryAsync(string query, CancellationToken cancellationToken, params object[] parameters);
    }
}