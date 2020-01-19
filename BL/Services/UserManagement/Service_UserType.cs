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
using BL.Dto.UserManagement;

namespace BL.Services
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