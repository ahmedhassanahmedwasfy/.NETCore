using CORE.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;


namespace CORE.BL.Services
{
    public interface IbaseService
    {
        void Rollback();
    }
    public interface IService<TEntity, TOut> : IbaseService,IDisposable where TEntity : class where TOut : class  
    {
        void BeginTransaction(System.Data.IsolationLevel isolationLevel);
        //void Rollback();
        void Commit();
        void AddOrUpdate(ref TOut entity);
        IEnumerable<TOut> Select(
         Expression<Func<TEntity, bool>> filter = null,
         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
         List<Expression<Func<TEntity, object>>> includes = null,
         int? page = null,
         int? pageSize = null);
        IEnumerable<TOut> SelectNoTrackable(
         Expression<Func<TEntity, bool>> filter = null,
         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
         List<Expression<Func<TEntity, object>>> includes = null,
         int? page = null,
         int? pageSize = null);
        IEnumerable<TOut> SelectPaged(out int Total,
         Expression<Func<TEntity, bool>> filter = null,
         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
         List<Expression<Func<TEntity, object>>> includes = null,
         int? page = null,
         int? pageSize = null);
        TOut Find(params object[] keyValues);
        IQueryable<TEntity> SelectQuery(string query, params object[] parameters);
        void Insert(ref TOut entity);
        void InsertRange(IEnumerable<TEntity> entities);
        //void ApplyChanges(TEntity entity);
        [Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
        void InsertOrUpdateGraph(TEntity entity);
        [Obsolete("InsertGraphRange has been deprecated. Instead call Insert to set TrackingState on enttites in a graph.")]
        void InsertGraphRange(IEnumerable<TEntity> entities);
        void Update(ref TOut entity, List<Expression<Func<TEntity, object>>> UnchangedProperties = null);
        void Delete(object id);
        void Delete(TOut entity);
        void SoftDelete(TOut entity);
        void SoftUnDelete(TOut entity);
        IQueryable<TEntity> Query();

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> query);
        Task<TOut> FindAsync(params object[] keyValues);
        Task<TOut> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<bool> DeleteAsync(params object[] keyValues);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
        IQueryable<TEntity> Queryable();
    }

}