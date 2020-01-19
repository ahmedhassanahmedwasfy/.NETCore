using AutoMapper;
using BL.Dto;
using BLRepository.Repositories;
using DAL.Models;
using Repository.Repositories;
using BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using DAL.Models.UserManagement;
using Repository.UOW;
using Unity;
using Microsoft.EntityFrameworkCore;

namespace BL.Services
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
            //var dbuser = base.Select(c => c.ID == ID, c => c.OrderBy(d => d.ID), new List<System.Linq.Expressions.Expression<Func<tbl_User, object>>>()
            //{

            //    //c => c.Privilliges, c => c.Groups

            //}, 1, 1).FirstOrDefault();

           var dbuser= _repo.Queryable().Include(c => c.tbl_Grouptbl_User).ThenInclude(c => c.Group).Include(c => c.tbl_Privilligetbl_User).ThenInclude(c => c.Privillige)
                .Where(c => c.ID == ID).OrderBy(d => d.ID).FirstOrDefault();
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
            //    .Select(c => c.ID == itemId, null, new List<System.Linq.Expressions.Expression<Func<tbl_User, object>>>()
            //{
            //    c => c.Privilliges, c => c.Groups
            //}).FirstOrDefault();

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
            //    Select(c => c.ID == itemId, null, new List<System.Linq.Expressions.Expression<Func<tbl_User, object>>>()
            //{
            //     c => c.Privilliges
            //}).FirstOrDefault();


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
            Mapped.tbl_Privilligetbl_User = null;
            Mapped.tbl_Grouptbl_User = null;
            _UserRepo.AddOrUpdate(Mapped);
            entity.ID = Mapped.ID;
            Mapped = AutoMapper.Mapper.Map<tbl_User>(entity);
            var DBPrivilliges = _PrivilligeRepo.Select(c =>
                Mapped.tbl_Privilligetbl_User.Select(p => p.tbl_Privillige_ID).Contains(c.ID)
            ).ToList();
            var DBGroups = _GroupRepo.Select(c =>

           Mapped.tbl_Grouptbl_User.Select(p => p.tbl_Group_ID).Contains(c.ID)
            ).ToList();
            //foreach (var item in DBPrivilliges)
            //{
            //    _PrivilligeRepo.Reload(item);
            //}

            //foreach (var item in DBGroups)
            //{
            //    _GroupRepo.Reload(item);
            //}

            var tbl_user = _UserRepo.Queryable().Include(c => c.tbl_Grouptbl_User).ThenInclude(c => c.Group).Include(c => c.tbl_Privilligetbl_User).ThenInclude(c => c.Privillige).Where(c => c.ID == Mapped.ID).FirstOrDefault();
                //Select(c => c.ID == Mapped.ID, null
                //, new List<System.Linq.Expressions.Expression<Func<tbl_User, object>>>()
                //{
                //    //c => c.Privilliges, c => c.Groups
                //}).FirstOrDefault();

            tbl_user.tbl_Privilligetbl_User.RemoveAll(c => true);
            tbl_user.tbl_Privilligetbl_User.AddRange( DBPrivilliges.Select(c=> new tbl_Privilligetbl_User() { tbl_Privillige_ID=c.ID,tbl_User_ID=tbl_user.ID }) );
            tbl_user.tbl_Grouptbl_User.RemoveAll(c => true);
            tbl_user.tbl_Grouptbl_User.AddRange(DBGroups.Select(c => new tbl_Grouptbl_User() { tbl_Group_ID = c.ID, tbl_User_ID = tbl_user.ID }));
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

            var container = BL.infrastructure.UnityRegister.container;

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