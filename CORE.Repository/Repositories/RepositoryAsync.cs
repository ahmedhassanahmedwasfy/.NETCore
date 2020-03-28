using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

using log4net;
using CORE.DAL.Models.UserManagement;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using CORE.Common.Repositories;
using CORE.Common.UOW;
using CORE.Common.BaseClasses;

namespace CORE.Repository.Repositories
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : tbl_base
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> Set;
        protected readonly IUnitOfWorkAsync UnitOfWork;
        private readonly ILog _logger;

        public RepositoryAsync(DbContext context, ILog logger)
        {

            Context = context;
            Set = context.Set<TEntity>();
            _logger = logger;
        }

        public virtual TEntity Find(params object[] keyValues)
        {
            return Set.Find(keyValues);
        }

        public virtual IQueryable<TEntity> SelectQuery(string query, params object[] parameters)
        {
            return Set.FromSql(query, parameters).AsQueryable();
        }

        public virtual void Insert(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            //Context.SaveChanges();
        }



        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Insert(entity);
            }
        }

        [Obsolete("InsertGraphRange has been deprecated. Instead call Insert to set TrackingState on enttites in a graph.")]
        public virtual void InsertGraphRange(IEnumerable<TEntity> entities) => InsertRange(entities);

        public virtual void Update(TEntity entity, List<Expression<Func<TEntity, object>>> UnchangedProperties = null)
        {
            //Recheck  https://stackoverflow.com/questions/30987806/dbset-attachentity-vs-dbcontext-entryentity-state-entitystate-modified
            //Recheck  https://stackoverflow.com/questions/41025338/why-use-attach-for-update-entity-framework-6
            //if (attach)
            //{
            //    if (Context.Entry(entity).State == EntityState.Detached || Context.Entry(entity).State == EntityState.Modified)
            //    {
            //        Set.Attach(entity);
            //    }
            //}
            Context.Entry(entity).State = EntityState.Modified;

            if (UnchangedProperties != null)
            {
                foreach (var item in UnchangedProperties)
                {
                    Context.Entry(entity).Property(item).IsModified = false;

                }
            }
            //Context.SaveChanges();
            //Context.Entry(entity).State = EntityState.Detached;


        }

        public void Delete(params object[] keyValues)
        {
            var entity = Set.Find(keyValues);
            Delete(entity);
        }
        public void SoftDelete(TEntity entity)
        {
            var dbEntity = Set.Find(entity.ID);
            dbEntity.IsDeleted = true;
            //Context.SaveChanges();
        }
        public void SoftUnDelete(TEntity entity)
        {
            var dbEntity = Set.Find(entity.ID);
            dbEntity.IsDeleted = false;
            //Context.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            //Context.SaveChanges();
            //Set.Remove(entity);
            //Context.SaveChanges();

        }

        public virtual void Delete(object id)
        {
            var entity = Set.Find(id);
            Delete(entity);
        }


        public IQueryable<TEntity> Queryable() => Set;

        public IRepository<T> GetRepository<T>() where T : tbl_base => UnitOfWork.Repository<T>();

        public virtual async Task<TEntity> FindAsync(params object[] keyValues) => await Set.FindAsync(keyValues);

        public virtual async Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues) => await Set.FindAsync(cancellationToken, keyValues);

        public virtual async Task<bool> DeleteAsync(params object[] keyValues)
        {
            if (await DeleteAsync(CancellationToken.None, keyValues)) return true;
            return false;
        }

        public virtual async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            var entity = await FindAsync(cancellationToken, keyValues);

            if (entity == null)
            {
                return false;
            }

            Context.Entry(entity).State = EntityState.Deleted;
            //Context.SaveChanges();
            return true;
        }

        public IQueryable<TEntity> Select(
             Expression<Func<TEntity, bool>> filter = null,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
             List<Expression<Func<TEntity, object>>> includes = null,


             int? page = null,
             int? pageSize = null)
        {
            IQueryable<TEntity> query = Set;
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (filter != null)
            {
                query = query.AsQueryable().Where(filter);
            }
            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            //return query.AsNoTracking();
            return query;
        }
        public IQueryable<TEntity> SelectNoTrackable(
          Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          List<Expression<Func<TEntity, object>>> includes = null,


          int? page = null,
          int? pageSize = null)
        {
            IQueryable<TEntity> query = Set;
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (filter != null)
            {
                query = query.AsQueryable().Where(filter);
            }
            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            return query.AsNoTracking();
        }

        public virtual async Task<IEnumerable<TEntity>> SelectQueryAsync(string query, params object[] parameters)
        {
            return await Set.FromSql(query, parameters).ToArrayAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> SelectQueryAsync(string query, CancellationToken cancellationToken, params object[] parameters)
        {
            return await Set.FromSql(query, parameters).ToArrayAsync(cancellationToken);
        }

        internal async Task<IEnumerable<TEntity>> SelectAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,

            int? page = null,
            int? pageSize = null)
        {
            return await Select(filter, orderBy, includes, page, pageSize).ToListAsync();
        }

        [Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
        public virtual void InsertOrUpdateGraph(TEntity entity)
        {
            //ApplyChanges(entity);

        }



        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> query)
        {
            IQueryable<TEntity> result = Set;
            result.Where(query);
            return result;
        }

        public IQueryable<TEntity> Query()
        {
            IQueryable<TEntity> query = Set;
            return query;
        }

        public IEnumerable<TEntity> SelectPaged(out int Total, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, List<Expression<Func<TEntity, object>>> includes = null, int? page = null, int? pageSize = null)
        {

            IQueryable<TEntity> query = Set;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (filter != null)
            {
                query = query.AsQueryable().Where(filter);
            }
            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            var Result = query.AsNoTracking().ToList();
            IQueryable<TEntity> _query = Set;
            if (filter != null)
            {
                _query = _query.AsQueryable().Where(filter);
            }
            Total = _query.Count();
            return Result;
        }

        public void Attach(TEntity entity)
        {
            //remove this line its test only
            //var c = Context.Entry(entity).State = EntityState.Added;
            Set.Attach(entity);
        }
        public void AddOrUpdate(TEntity entity)
        {
            Set.AddOrUpdate(entity);
            //Set.AddOrUpdate(c => c.ID,entity);
            //Context.SaveChanges();

        }


        public virtual void DeleteWithRelation(TEntity entity)
        {
            var dbentity = Set.Find(entity.ID);
            Set.Remove(dbentity);
            //Context.SaveChanges();
        }

        public void Reload(TEntity entity)
        {
            Context.Entry(entity).Reload();
        }

    }

    public static class RepoExt
    {
        public static void AddOrUpdate<T>(this DbSet<T> dbSet, T data) where T : class
        {
            var t = typeof(T);
            PropertyInfo keyField = null;
            foreach (var propt in t.GetProperties())
            {
                var keyAttr = propt.GetCustomAttribute<KeyAttribute>();
                if (keyAttr != null)
                {
                    keyField = propt;
                    break; // assume no composite keys
                }
            }
            if (keyField == null)
            {
                throw new Exception($"{t.FullName} does not have a KeyAttribute field. Unable to exec AddOrUpdate call.");
            }
            var keyVal = keyField.GetValue(data);
            //var dbVal = dbSet.Find(keyVal);
            if (keyVal != null && (Guid)keyVal != Guid.Empty)
            {
                dbSet.Update(data);
                return;
            }
            dbSet.Add(data);
        }

    }



}