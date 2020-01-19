using AutoMapper;
using BL.Dto;
using BL.GenericClasses;
using DAL.Models.UserManagement;
using log4net;
using Repository.Repositories;
using Repository.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Core.Objects;

namespace BL.Services.UserManagement
{
    public interface IService_Account : IDisposable, IbaseService
    {
        List<dto_User> GetUsers();
        dto_User login(string Username, string Password);
        void register(dto_User user);
        bool validate(dto_User user);
        dto_User GetUser(string username);
        dto_User loginAD(string UserName);
        dto_User login(string email);
        void ChangePassword(Guid ID, string password);
    }
    public class Service_Account : Service<tbl_User, dto_User>, IService_Account
    {

        private readonly ILog _logger;
        private readonly IUnitOfWorkAsync _uow;
        private readonly IRepositoryAsync<tbl_User> _repo;
        public Service_Account(IUnitOfWorkAsync uow, ILog Logger) : base(uow)
        {
            _uow = uow;
            _logger = Logger;
            _repo = _uow.RepositoryAsync<tbl_User>();
        }

        public void ChangePassword(Guid ID, string password)
        {
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            var users = base.SelectNoTrackable(c => c.ID == ID).FirstOrDefault();
            users.Password = password;
            base.Update(ref users);
            base.SaveChanges();
            this.Commit();
        }

        public dto_User GetUser(string Email)
        {
            var users = base.Select(c => c.Email == Email).FirstOrDefault();
            return Mapper.Map<dto_User>(users);
        }

        public List<dto_User> GetUsers()
        {
            var users = base.Select();
            return Mapper.Map<List<dto_User>>(users);
        }

        public dto_User login(string UserName, string Password)
        {
            dto_User result = null;
            var q = _repo.Queryable();
            q = q.Include(c => c.tbl_Grouptbl_User).ThenInclude(c => c.Group).ThenInclude(c => c.tbl_Privilligetbl_Group).ThenInclude(c => c.Privillige)
                .Include(c => c.tbl_Privilligetbl_User).ThenInclude(c => c.Privillige);
            var user = q.Where(c => c.IsDeleted == false && (c.Email.ToLower() == UserName.ToLower()) && c.Password.ToLower() == Password.ToLower()).FirstOrDefault();

            if (user != null)
            {
                result = Mapper.Map<dto_User>(user);
            }
            return result;
        }

        public dto_User login(string email)
        {
            dto_User result = null;
            //var user = base.Select(c => c.IsDeleted == false && c.IsThirdParty && (c.Email.ToLower() == email.ToLower()), null,
            //    new List<System.Linq.Expressions.Expression<Func<tbl_User, object>>>()
            //    //{ c => c.Groups, c => c.Groups.Select(d => d.Privilliges), c => c.Privilliges }).FirstOrDefault();
            //    { c => c.Groups,   c => c.Privilliges }).FirstOrDefault();

            var x1 = _repo.Queryable()
           .Include(c => c.tbl_Grouptbl_User)
                .ThenInclude(c => c.Group)
                .ThenInclude(c => c.tbl_Privilligetbl_Group)
                .ThenInclude(c => c.Privillige) 
           .Include(c => c.tbl_Privilligetbl_User)
                .ThenInclude(c => c.Privillige)
              ;
            var user = x1.Where(c => c.IsDeleted == false && c.IsThirdParty
             && (c.Email.ToLower() == email.ToLower())
            ).FirstOrDefault();

            if (user != null)
            {
                result = Mapper.Map<dto_User>(user);
            }
            return result;
        }

        public dto_User loginAD(string UserName)
        {
            dto_User result = null;
            // var user = base.Select(c => c.IsDeleted == false && (c.Email.ToLower() == UserName.ToLower()), null, new List<System.Linq.Expressions.Expression<Func<tbl_User, object>>>() { c => c.Groups, c => c.Groups.Select(d => d.Privilliges), c => c.Privilliges }).FirstOrDefault();
            var user = _repo.Queryable()
                  .Include(c => c.tbl_Grouptbl_User).ThenInclude(c => c.Group).ThenInclude(c => c.tbl_Privilligetbl_Group).ThenInclude(c => c.Privillige)
                  .Include(c => c.tbl_Privilligetbl_User).ThenInclude(c=>c.Privillige)
               .Where(c => c.IsDeleted == false && (c.Email.ToLower() == UserName.ToLower())).FirstOrDefault();

            if (user != null)
            {
                result = Mapper.Map<dto_User>(user);
            }
            return result;
        }
        public void register(dto_User user)
        {
            base.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            base.Insert(ref user);
            base.SaveChanges();
            base.Commit();
        }



        public bool validate(dto_User user)
        {
            var _user = base.Select(c => c.ID != user.ID && user.UserTypeID == c.UserTypeID && (

           (!string.IsNullOrEmpty(user.Email) && (c.Email.ToLower() == user.Email.ToLower()))
             ||
           (!string.IsNullOrEmpty(user.Name) && (c.Name.ToLower() == user.Name.ToLower()))
            ), null, null).Count();
            if (_user > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
