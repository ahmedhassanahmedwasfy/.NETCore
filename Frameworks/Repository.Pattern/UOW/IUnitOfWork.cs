using DAL.Models.UserManagement;
using Repository.Repositories;
using System;
using System.Data; 


namespace Repository.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        int ExecuteSqlCommand(string sql, params object[] parameters);
        IRepository<TEntity> Repository<TEntity>() where TEntity : tbl_base; 
        int? CommandTimeout { get; set; }
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}