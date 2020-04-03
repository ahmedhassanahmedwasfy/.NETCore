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
using CORE.Common.Repositories;
using CORE.Common.UOW;

namespace CORE.BL.Services
{
    public interface IService_User : IDisposable, IbaseService
    {
        IEnumerable<dto_User> GetPage(int pageNumber, int pageSize, out int totalCustomerCount);
        dto_User Get(Guid ID);
        Guid Create(dto_User entity);
        void Edit(dto_User entity);
        void updategroups(List<dto_Group> selectedGroups, Guid itemId);
        void UpdatePrivilliges(List<dto_Privillige> checkedPrivilliges, Guid itemId);
        void CreateOREdit(dto_User entity);
        void Remove(dto_User entity);
        void ChangePassword(Guid iD, string password);
    }
    public class Service_User : Service<tbl_User, dto_User>, IService_User
    {

        private readonly ILog _logger;
        private readonly IUnitOfWorkAsync _uow;
        private readonly IRepositoryAsync<tbl_User> _repo;
        public Service_User(IUnitOfWorkAsync uow, ILog Logger) : base(uow)
        {
            _uow = uow;
            _logger = Logger;
            _repo = _uow.RepositoryAsync<tbl_User>();
        }

        public Guid Create(dto_User entity)
        {
            // e.g. add business logic here before inserting
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            base.Insert(ref entity);
            this.SaveChanges();
            this.Commit();
            return entity.ID;
        }
        public void Edit(dto_User entity)
        {
            // e.g. add business logic here before updating 
            base.Update(ref entity);
        }
        public dto_User Get(Guid ID)
        {
             
            var dbuser = _repo.Queryable().Include(c => c.tbl_Grouptbl_User).ThenInclude(c => c.Group).Include(c => c.tbl_Privilligetbl_User).ThenInclude(c => c.Privillige)
                 .Where(c => c.ID == ID).OrderBy(d => d.ID).AsNoTracking().FirstOrDefault();
            var user = Mapper.Map<dto_User>(dbuser);
            return user;
        }
        public override void Delete(object id)
        {
            // e.g. add business logic here before deleting
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            base.Delete(id);
            this.SaveChanges();
            this.Commit();
        }

        public IEnumerable<dto_User> GetPage(int pageNumber, int pageSize, out int totalCustomerCount)
        {

            var dbusers = _repo.Queryable().Where(c => c.IsDeleted == false).Include(c => c.tbl_Grouptbl_User).ThenInclude(c => c.Group).Include(c => c.tbl_Privilligetbl_User).ThenInclude(c => c.Privillige)
            .OrderByDescending(d => d.ID).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            totalCustomerCount = _repo.Queryable().Where(c => c.IsDeleted == false).Include(c => c.tbl_Grouptbl_User).ThenInclude(c => c.Group).Include(c => c.tbl_Privilligetbl_User).ThenInclude(c => c.Privillige)
            .OrderByDescending(d => d.ID).Count();
            var users = Mapper.Map<List<dto_User>>(dbusers);

            return users;
        }

        public void updategroups(List<dto_Group> selectedGroups, Guid itemId)
        {
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            var repositoryuser = _uow.RepositoryAsync<tbl_User>();
            var user = repositoryuser.Queryable().Include(c => c.tbl_Privilligetbl_User).ThenInclude(c => c.Privillige).Include(c => c.tbl_Grouptbl_User).ThenInclude(c => c.Group)
                .Where(c => c.ID == itemId).FirstOrDefault();
         
            var _RepositoryGroups = _uow.RepositoryAsync<tbl_Group>();
            List<tbl_Group> Allgroups = _RepositoryGroups.Select().ToList();
            List<Guid> CurrentIds = user.tbl_Grouptbl_User.Select(c => c.tbl_Group_ID).ToList();
            List<Guid> Newids = selectedGroups.Select(x => x.ID).ToList();

            List<Guid> IntersectIds = new List<Guid>();
            foreach (var item in Newids)
            {
                if (!CurrentIds.Contains(item))
                {
                    IntersectIds.Add(item);
                }
            }

            user.tbl_Grouptbl_User.Clear();

            foreach (var item in Allgroups.Where(c => Newids.Contains(c.ID)))
            {
                _RepositoryGroups.Attach(item);
                user.tbl_Grouptbl_User.Add(new tbl_Grouptbl_User() { tbl_Group_ID = item.ID, tbl_User_ID = user.ID });
            }
            repositoryuser.Update(user);
            _uow.SaveChanges();
            this.Commit();
        }

        public void UpdatePrivilliges(List<dto_Privillige> checkedPrivilliges, Guid itemId)
        {
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            var repositoryuser = _uow.RepositoryAsync<tbl_User>();
            var user = repositoryuser.Queryable().Include(c => c.tbl_Privilligetbl_User).ThenInclude(c => c.Privillige).Where(c => c.ID == itemId).FirstOrDefault();
        

            var _RepositoryPrivilliges = _uow.RepositoryAsync<tbl_Privillige>();
            List<tbl_Privillige> Allprivilliges = _RepositoryPrivilliges.Select().ToList();
            List<Guid> CurrentIds = user.tbl_Privilligetbl_User.Select(c => c.tbl_Privillige_ID).ToList();
            List<Guid> Newids = checkedPrivilliges.Select(x => x.ID).ToList();

            List<Guid> IntersectIds = new List<Guid>();
            foreach (var item in Newids)
            {
                if (!CurrentIds.Contains(item))
                {
                    IntersectIds.Add(item);
                }
            }

            user.tbl_Privilligetbl_User.Clear();

            foreach (var item in Allprivilliges.Where(c => Newids.Contains(c.ID)))
            {
                _RepositoryPrivilliges.Attach(item);
                user.tbl_Privilligetbl_User.Add(new tbl_Privilligetbl_User() { tbl_Privillige_ID = item.ID, tbl_User_ID = user.ID });
            }
            repositoryuser.Update(user);
            _uow.SaveChanges();
            this.Commit();
        }

        public void CreateOREdit(dto_User entity)
        {
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            var _GroupRepo = _uow.RepositoryAsync<tbl_Group>();
            var _PrivilligeRepo = _uow.RepositoryAsync<tbl_Privillige>();
            var _UserRepo = _uow.RepositoryAsync<tbl_User>();

            var Mapped = AutoMapper.Mapper.Map<tbl_User>(entity);
            Mapped.tbl_Privilligetbl_User = new List<tbl_Privilligetbl_User>();
            Mapped.tbl_Grouptbl_User = new List<tbl_Grouptbl_User>();
            _UserRepo.AddOrUpdate(Mapped);
            _uow.SaveChanges();
            
            var tbl_user = _UserRepo.Queryable().Include(c => c.tbl_Grouptbl_User).ThenInclude(c => c.Group).Include(c => c.tbl_Privilligetbl_User).ThenInclude(c => c.Privillige).Where(c => c.ID == Mapped.ID).FirstOrDefault();

            tbl_user.tbl_Privilligetbl_User.RemoveAll(c => true);
            tbl_user.tbl_Privilligetbl_User.AddRange(entity.Privilliges.Select(c => new tbl_Privilligetbl_User() { tbl_Privillige_ID = c.ID, tbl_User_ID = Mapped.ID }));
            tbl_user.tbl_Grouptbl_User.RemoveAll(c => true);
            tbl_user.tbl_Grouptbl_User.AddRange(entity.Groups.Select(c => new tbl_Grouptbl_User() { tbl_Group_ID = c.ID, tbl_User_ID = Mapped.ID }));
            _UserRepo.AddOrUpdate(tbl_user);
            _uow.SaveChanges();
            this.Commit();

        }

        public void Remove(dto_User entity)
        {
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            base.Delete(entity);
            this.SaveChanges();
            this.Commit();
        }

        public void ChangePassword(Guid iD, string password)
        {
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            var container = CORE.BL.infrastructure.AutofacRegister.container;

            var _repository = _uow.RepositoryAsync<tbl_User>();
            var user = _repository.SelectNoTrackable(c => c.ID == iD).FirstOrDefault();
            if (user != null)
            {
                user.Password = password;
            }
            _repository.Update(user);
            this.SaveChanges();
            this.Commit();

        }

    }
}