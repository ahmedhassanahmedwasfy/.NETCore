using AutoMapper;
using BL.Dto.Menu;
using DAL.Models.Menu;
using log4net;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using Repository.UOW;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Services.Menu
{
    public interface IService_Menu :IDisposable,IbaseService
    {
        List<dto_Menu> GetMenuItems();
        void Create(ref dto_Menu menu);
        void Remove(string nameEn);
        List<dto_Menu> GetPrivateMenuItems();
    }
    public class Service_Menu : Service<tbl_Menu, dto_Menu>, IService_Menu
    {
        private readonly IRepositoryAsync<tbl_Menu> _repository;
        private readonly ILog _logger;
        private readonly IUnitOfWorkAsync _uow;
        public Service_Menu(IUnitOfWorkAsync uow , ILog Logger) : base(uow )
        {
            _uow = uow; 
            _logger = Logger;
            _repository = _uow.RepositoryAsync<tbl_Menu>();
        }

        public void Create(ref dto_Menu menu)
        {
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            this.AddOrUpdate(ref menu);
            this.Commit();
        }

        public List<dto_Menu> GetMenuItems()
        { 
            //var Menus = this.Select(c => c.isPrivate == false && c.IsDeleted == false && c.Children.Count > 0, includes: new List<System.Linq.Expressions.Expression<Func<tbl_Menu, object>>>() { x => x.Children, x => x.Children.Select(c => c.Privillige), x => x.Privillige }).ToList();

            var _Menus = _repository.Queryable().Include(x => x.Children).ThenInclude(c => c.Privillige).Include(x => x.Privillige).ToList();

           var Menus =AutoMapper.Mapper.Map<List<dto_Menu>>(_Menus);

            return Menus;
        }

        public List<dto_Menu> GetPrivateMenuItems()
        {  
            var Menus = this.Select(c => c.isPrivate && c.IsDeleted == false).ToList();
            return Menus;
        }

        public void Remove(string nameEn)
        {
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            var Menus = this.Select(c => c.NameEn == nameEn).ToList();
            if (Menus != null && Menus.Count > 0)
            {
                base.Delete(Menus.FirstOrDefault().ID);
            }
            _uow.SaveChanges();
            this.Commit();

        }
    }
}
