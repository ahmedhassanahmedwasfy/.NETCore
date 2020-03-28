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
using CORE.BL.Dto.UserManagement;
using CORE.Common;
using CORE.Common.UOW;

namespace CORE.BL.Services
{
    public interface IService_UserType : IDisposable, IbaseService
    {
        IEnumerable<dto_UserType> Get( );
        
    }
    public class Service_UserType : Service<tbl_UserType, dto_UserType>, IService_UserType
    {
       
        private readonly ILog _logger;
        private readonly IUnitOfWorkAsync _uow;
        public Service_UserType(IUnitOfWorkAsync uow , ILog Logger) : base(uow)
        { 
            _uow = uow;
            _logger = Logger;
        }

        
        public IEnumerable<dto_UserType> Get( )
        {
            var users = this.Select();
            return users; 
        }

      
       
    }
}