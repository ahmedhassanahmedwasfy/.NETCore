using AutoMapper;
using BL.Dto;
using DAL.Models.UserManagement;
using log4net;
using Repository.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Profile
{

    public interface IProfileService : IDisposable, IbaseService
    {
        void update(dto_User user);
        dto_User load(Guid ID);
    }
    public class ProfileService : Service<tbl_User, dto_User>, IProfileService
    {
        private readonly ILog _logger;
        private readonly IUnitOfWorkAsync _uow;
        public ProfileService(IUnitOfWorkAsync uow, ILog Logger) : base(uow)
        {
            _uow = uow;
            _logger = Logger;
        }
        public dto_User load(Guid ID)
        {
            return base.SelectNoTrackable(c => c.ID == ID, c => c.OrderByDescending(x => x.ID), null, 1, 1).FirstOrDefault();
        }

        public void update(dto_User user)
        {
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            var _userRepo = _uow.Repository<tbl_User>();
            var _user = _userRepo.Select(c => c.ID == user.ID, c => c.OrderByDescending(x => x.ID), null, 1, 1).FirstOrDefault();
            var dbuser = Mapper.Map(user,_user );
            _userRepo.Update(dbuser, new List<System.Linq.Expressions.Expression<Func<tbl_User, object>>>() { x => x.Password  });
            _uow.SaveChanges();

            this.Commit();


        }
    }
}
