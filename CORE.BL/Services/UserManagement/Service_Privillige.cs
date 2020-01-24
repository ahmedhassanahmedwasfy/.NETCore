using AutoMapper;
using CORE.BL.Dto;
using CORE.DAL.Models;
using CORE.Repository.Repositories;
using CORE.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using CORE.DAL.Models.UserManagement;
using CORE.Repository.UOW;
using Unity;
namespace CORE.BL.Services
{
    public interface IService_Privillige :  IDisposable, IbaseService
    {
        IEnumerable<dto_Privillige> GetPage(int pageNumber, int pageSize, out int totalCustomerCount);
        dto_Privillige Get(Guid ID);
        void Create(dto_Privillige entity);
        void Edit(dto_Privillige entity);
        void CreateOREdit(dto_Privillige entity);
        void Remove(dto_Privillige entity);
        void Remove(string NameEn);



    }
    public class Service_Privillige : Service<tbl_Privillige, dto_Privillige>, IService_Privillige
    {
      
        private readonly ILog _logger;
        private readonly IUnitOfWorkAsync _uow;

        public Service_Privillige(IUnitOfWorkAsync uow,   ILog Logger) : base(uow)
        {  
            _uow = uow;
            _logger = Logger;
        }

        //public override void Insert(dto_Privillige entity)
        //{
        //    // e.g. add business logic here before inserting
        //    base.Insert(entity);
        //} 

        public void Create(dto_Privillige entity)
        {
            // e.g. add business logic here before inserting
            //var Privillige = Mapper.Map<tbl_Privillige>(entity);
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            base.Insert(ref entity);
            this.SaveChanges();
            this.Commit();
        }
        public void Edit(dto_Privillige entity)
        {
            // e.g. add business logic here before updating
            //var Privillige = Mapper.Map<tbl_Privillige>(entity);
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            base.Update(ref entity);
            this.SaveChanges();
            this.Commit();
        }
        public dto_Privillige Get(Guid ID)
        {
            var dbPrivillige = base.Find(ID);
            //var user = Mapper.Map<dto_Privillige>(dbPrivillige);
            return dbPrivillige;
        }
        public void CreateOREdit(dto_Privillige entity)
        {
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            base.AddOrUpdate(ref entity);
            this.SaveChanges();
            this.Commit();
        }

        public IEnumerable<dto_Privillige> GetPage(int pageNumber, int pageSize, out int totalCustomerCount)
        {
            var Privilliges = this.SelectPaged(out totalCustomerCount, c => c.IsDeleted == false, c => c.OrderBy(x => x.ID), null, pageNumber, pageSize);
            return Privilliges;
        }

        public void Remove(dto_Privillige entity)
        {
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            base.Delete(entity);
            this.SaveChanges();
            this.Commit();
        }

        public void Remove(string NameEn)
        {
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            var privs = this.Select(c => c.NameEn == NameEn).ToList();
            if (privs != null && privs.Count > 0)
            {
                base.Delete(privs.FirstOrDefault().ID);
            }
            this.SaveChanges();
            this.Commit();
        }
    }
}