using AutoMapper;
using CORE.BL.Dto;
using CORE.Repository.Repositories;
using CORE.DAL.Models;
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
using Microsoft.EntityFrameworkCore;
using CORE.Common;
using CORE.Common.UOW;
using CORE.Common.Repositories;

namespace CORE.BL.Services
{
    public interface IService_Group : IDisposable, IbaseService
    {
        IEnumerable<dto_Group> GetPage(int pageNumber, int pageSize, out int totalCustomerCount);
        dto_Group Get(Guid ID);
        Guid Create(dto_Group entity);
        void Edit(dto_Group entity); 
        void CreateOREdit(dto_Group entity);
        void Remove(dto_Group entity);

    }
    public class Service_Group : Service<tbl_Group, dto_Group>, IService_Group
    {
        private readonly ILog _logger;
        private readonly IUnitOfWorkAsync _uow;
        private readonly IRepositoryAsync<tbl_Group> _repo;
        public Service_Group(IUnitOfWorkAsync uow, ILog Logger, IService_Privillige service_Privillige) : base(uow)
        {
            _uow = uow;
            _logger = Logger;
            _repo = _uow.RepositoryAsync<tbl_Group>();
        }

        public Guid Create(dto_Group entity)
        {
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            base.Insert(ref entity);
            _uow.SaveChanges();
            this.Commit();
            return entity.ID;
        }
        public void Edit(dto_Group entity)
        {
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            base.Update(ref entity);
            _uow.SaveChanges();
            this.Commit();

        }
        public dto_Group Get(Guid ID)
        {
            var dbgroup =
                _repo.Queryable().Include(c => c.tbl_Privilligetbl_Group).ThenInclude(c => c.Privillige)
                .Where(c => c.ID == ID).FirstOrDefault();
            var group = AutoMapper.Mapper.Map<dto_Group>(dbgroup);
            return group;
        }

        public override void Delete(object id)
        {
            // e.g. add business logic here before deleting
            base.Delete(id);
            _uow.SaveChanges();

        }
       
        public IEnumerable<dto_Group> GetPage(int pageNumber, int pageSize, out int totalCustomerCount)
        {
            totalCustomerCount = _repo.Queryable().Include(c => c.tbl_Privilligetbl_Group).ThenInclude(c => c.Privillige)
             .Where(c => c.IsDeleted == false).OrderBy(c => c.ID).Count();
            var Groups =
              _repo.Queryable().Include(c => c.tbl_Privilligetbl_Group).ThenInclude(c => c.Privillige)
              .Where(c => c.IsDeleted == false).OrderBy(c => c.ID).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return Mapper.Map<List<dto_Group>>(Groups);
        }

        public void Remove(dto_Group entity)
        {
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            base.Delete(entity);
            _uow.SaveChanges();
            this.Commit();

        }

        public void CreateOREdit(dto_Group entity)
        {

            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            var _GroupRepo = _uow.RepositoryAsync<tbl_Group>();
            var _PrivilligeRepo = _uow.RepositoryAsync<tbl_Privillige>();

            var Mapped = AutoMapper.Mapper.Map<tbl_Group>(entity);
            Mapped.tbl_Privilligetbl_Group = null;
            _GroupRepo.AddOrUpdate(Mapped);
            _uow.SaveChanges();

            var tbl_group = _GroupRepo.Queryable().Include(c => c.tbl_Privilligetbl_Group).ThenInclude(c => c.Privillige).Where(c => c.ID == Mapped.ID).FirstOrDefault();

            tbl_group.tbl_Privilligetbl_Group.RemoveAll(c => true);
            tbl_group.tbl_Privilligetbl_Group.AddRange(entity.Privilliges.Select(c => new tbl_Privilligetbl_Group() { tbl_Privillige_ID = c.ID, tbl_Group_ID = tbl_group.ID }));
            _GroupRepo.AddOrUpdate(tbl_group);
            _uow.SaveChanges();
            this.Commit();
        }
    }
}