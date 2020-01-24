using CORE.DAL.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace CORE.Repository.Repositories
{
    public interface IRepository<TEntity> where TEntity : tbl_base
    {
        void Reload(TEntity entity);
        void AddOrUpdate(TEntity entity);
        void Attach(TEntity entity);
        IQueryable<TEntity> Select(
          Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          List<Expression<Func<TEntity, object>>> includes = null,
          int? page = null,
          int? pageSize = null);
        IQueryable<TEntity> SelectNoTrackable(
       Expression<Func<TEntity, bool>> filter = null,
       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
       List<Expression<Func<TEntity, object>>> includes = null,
       int? page = null,
       int? pageSize = null);
        IEnumerable<TEntity> SelectPaged(out int Total,
             Expression<Func<TEntity, bool>> filter = null,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
             List<Expression<Func<TEntity, object>>> includes = null,
             int? page = null,
             int? pageSize = null);
        TEntity Find(params object[] keyValues);
        IQueryable<TEntity> SelectQuery(string query, params object[] parameters);
        void Insert(TEntity entity);
        //void ApplyChanges(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        [Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
        void InsertOrUpdateGraph(TEntity entity);
        [Obsolete("InsertGraphRange has been deprecated. Instead call Insert to set TrackingState on enttites in a graph.")]
        void InsertGraphRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity, List<Expression<Func<TEntity, object>>> UnchangedProperties = null);
        void Delete(params object[] keyValues);
        void Delete(TEntity entity);
        void DeleteWithRelation(TEntity entity);
        void SoftDelete(TEntity entity);
        void SoftUnDelete(TEntity entity); 
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> query);
        IQueryable<TEntity> Query();
        IQueryable<TEntity> Queryable();
        IRepository<T> GetRepository<T>() where T : tbl_base;
    }
}