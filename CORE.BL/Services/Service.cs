using CORE.DAL.Models.UserManagement;
using CORE.Repository.Repositories;
using CORE.Repository.UOW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;


namespace CORE.BL.Services
{
    public abstract class Service<TEntity, TOut> : IDisposable,  IService<TEntity, TOut> where TEntity : tbl_base where TOut : class
    {

        private readonly IRepositoryAsync<TEntity> _repository;
        private   IUnitOfWorkAsync _uow;
        protected Service(IUnitOfWorkAsync uow) {
            _uow = uow;  
            _repository = _uow.RepositoryAsync<TEntity>();
        }

        public virtual TOut Find(params object[] keyValues)
        {
            var res = _repository.Find(keyValues);
            var Mapped = AutoMapper.Mapper.Map<TOut>(res);
            return Mapped;
        }

        public virtual IQueryable<TEntity> SelectQuery(string query, params object[] parameters)
        {

            var res = _repository.SelectQuery(query, parameters).AsQueryable();
            return res;
        }

        public virtual void Insert(ref TOut entity)
        {
            var Mapped = AutoMapper.Mapper.Map<TEntity>(entity);
            _repository.Insert(Mapped);
           // _uow.SaveChanges();
            entity = AutoMapper.Mapper.Map<TOut>(Mapped);

        }

        //public virtual void ApplyChanges(TEntity entity) { _repository.ApplyChanges(entity); }

        public virtual void InsertRange(IEnumerable<TEntity> entities) { _repository.InsertRange(entities); }

        [Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
        public virtual void InsertOrUpdateGraph(TEntity entity) { _repository.InsertOrUpdateGraph(entity); }

        [Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
        public virtual void InsertGraphRange(IEnumerable<TEntity> entities) { _repository.InsertGraphRange(entities); }

        internal void SaveChanges()
        {
            if (_uow!=null)
            {
                _uow.SaveChanges();
            }
        }

        public virtual void Update(ref TOut entity,List< Expression<Func<TEntity, object>>> UnchangedProperties = null)
        {
            var Mapped = AutoMapper.Mapper.Map<TEntity>(entity);
            _repository.Update(Mapped,UnchangedProperties);
         //   _uow.SaveChanges();
            entity = AutoMapper.Mapper.Map<TOut>(Mapped);
        }

        public virtual void Delete(object id) { _repository.Delete(id); }

        public virtual void Delete(TOut entity)
        {
            var Mapped = AutoMapper.Mapper.Map<TEntity>(entity);
             
            _repository.Delete(Mapped);
          //  _uow.SaveChanges();

        }
        public virtual void DeleteWithRelation(TOut entity)
        {
            var Mapped = AutoMapper.Mapper.Map<TEntity>(entity);

            _repository.DeleteWithRelation(Mapped);
          //  _uow.SaveChanges();

        }
        public IQueryable<TEntity> Query()
        {

            var res = _repository.Query();

            return res;
        }


        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> query)
        {
            var res = _repository.Query(query);

            return res;
        }

        public virtual async Task<TOut> FindAsync(params object[] keyValues)
        {
            var res = _repository.FindAsync(keyValues);
            var Mapped = await AutoMapper.Mapper.Map<Task<TOut>>(res);
            return Mapped;
        }

        public virtual async Task<TOut> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            var res = _repository.FindAsync(cancellationToken, keyValues);
            var Mapped = await AutoMapper.Mapper.Map<Task<TOut>>(res);
            return Mapped;
        }

        public virtual async Task<bool> DeleteAsync(params object[] keyValues) { return await DeleteAsync(CancellationToken.None, keyValues); }

        //IF 04/08/2014 - Before: return await DeleteAsync(cancellationToken, keyValues);
        public virtual async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues) { return await _repository.DeleteAsync(cancellationToken, keyValues); }

        public IQueryable<TEntity> Queryable()
        {

            return _repository.Queryable();
        }
        public IEnumerable<TOut> SelectPaged(out int Total,
         Expression<Func<TEntity, bool>> filter = null,
         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
         List<Expression<Func<TEntity, object>>> includes = null,
         int? page = null,
         int? pageSize = null)
        {
            var res = _repository.SelectPaged(out Total, filter, orderBy, includes, page, pageSize);
            var Mapped = AutoMapper.Mapper.Map<IEnumerable<TOut>>(res);
            return Mapped;
        }
        public IEnumerable<TOut> Select(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           List<Expression<Func<TEntity, object>>> includes = null,

           int? page = null,
           int? pageSize = null)
        {

            var res = _repository.Select(filter, orderBy, includes, page, pageSize).ToList();
            var Mapped = AutoMapper.Mapper.Map<IEnumerable<TOut>>(res);
            return Mapped;
        }
        public IEnumerable<TOut> SelectNoTrackable(
         Expression<Func<TEntity, bool>> filter = null,
         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
         List<Expression<Func<TEntity, object>>> includes = null,

         int? page = null,
         int? pageSize = null)
        {

            var res = _repository.SelectNoTrackable(filter, orderBy, includes, page, pageSize).ToList();
            var Mapped = AutoMapper.Mapper.Map<IEnumerable<TOut>>(res);
            return Mapped;
        }

        public void AddOrUpdate(ref TOut entity)
        {
            var Mapped = AutoMapper.Mapper.Map<TEntity>(entity);
            _repository.AddOrUpdate(Mapped);
          //  _uow.SaveChanges();

            entity = AutoMapper.Mapper.Map<TOut>(Mapped);

        }

        public void SoftDelete(TOut entity)
        {
            var Mapped = AutoMapper.Mapper.Map<TEntity>(entity);
            _repository.SoftDelete(Mapped);
           // _uow.SaveChanges();

        }

        public void SoftUnDelete(TOut entity)
        {
            var Mapped = AutoMapper.Mapper.Map<TEntity>(entity);
            _repository.SoftUnDelete(Mapped);
         //   _uow.SaveChanges();

        }
        public void Dispose()
        {
            if (_uow != null)
            {
                _uow.Dispose();
            }
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            if (_uow!=null)
            { 
                
                _uow.BeginTransaction(isolationLevel);
            }    
        
        }

        public void Rollback()
        {
            if (_uow != null)
            {
                _uow.Rollback();
            }
        }

        public void Commit()
        {
            if (_uow != null)
            {
                _uow.Commit();
            }
        }
    }
}