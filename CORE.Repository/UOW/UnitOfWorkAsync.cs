using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
//using Microsoft.Practices.ServiceLocation;

using CORE.Repository.Repositories;
using log4net;
using CORE.DAL.Models.UserManagement;
using Microsoft.EntityFrameworkCore.Storage;
//using CORE.commonServiceLocator;

namespace CORE.Repository.UOW
{
    public class UnitOfWorkAsync : IUnitOfWorkAsync
    {
        private readonly DbContext _context;
        protected IDbContextTransaction Transaction;
        protected Dictionary<string, dynamic> Repositories;
        ILog _log;
        public UnitOfWorkAsync(DbContext context, ILog log)
        {
            _context = context;
            bool isMemory = _context.Database.IsInMemory();
            if (isMemory)
            {
                _context.Database.Migrate();
            }
            else
            {
                _context.Database.EnsureCreated();

            }
            Repositories = new Dictionary<string, dynamic>();
            _log = log;
        }

        public virtual IRepository<TEntity> Repository<TEntity>() where TEntity : tbl_base
        {
            //if (ServiceLocator.IsLocationProviderSet)
            //{
            //    return ServiceLocator.Current.GetInstance<IRepository<TEntity>>();
            //}

            return RepositoryAsync<TEntity>();
        }

        public int? CommandTimeout
        {
            get
            {
                return _context.Database.GetCommandTimeout();
            }
            set { _context.Database.SetCommandTimeout(value); }
        }

        public virtual int SaveChanges() => _context.SaveChanges();

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public virtual IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : tbl_base
        {
            //if (ServiceLocator.IsLocationProviderSet)
            //{
            //    return ServiceLocator.Current.GetInstance<IRepositoryAsync<TEntity>>();
            //}

            if (Repositories == null)
            {
                Repositories = new Dictionary<string, dynamic>();
            }

            var type = typeof(TEntity).Name;

            if (Repositories.ContainsKey(type))
            {
                return (IRepositoryAsync<TEntity>)Repositories[type];
            }

            //var repositoryType = typeof(IRepositoryAsync<>);
            var repositoryType = typeof(RepositoryAsync<TEntity>);

            //Repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context, this, _log));
            Repositories.Add(type, Activator.CreateInstance(repositoryType, _context, _log));

            return Repositories[type];
        }

        public virtual int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _context.Database.ExecuteSqlCommand(sql, parameters);
        }

        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await _context.Database.ExecuteSqlCommandAsync(sql, parameters);
        }

        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken, params object[] parameters)
        {
            return await _context.Database.ExecuteSqlCommandAsync(sql, cancellationToken, parameters);
        }

        public virtual void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            //var objectContext = ((IObjectContextAdapter)_context).ObjectContext;
            //if (objectContext.Connection.State != ConnectionState.Open)
            //{
            //    objectContext.Connection.Open();
            //}
            //Transaction = objectContext.Connection.BeginTransaction(isolationLevel);
            if (!_context.Database.IsInMemory())
            {
                Transaction = _context.Database.BeginTransaction(isolationLevel);

            }
        }

        public virtual bool Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
            }
            return true;
        }

        public virtual void Rollback()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            if (Transaction != null)
            {
                Transaction.Dispose();
            }
        }
    }
}