using CORE.BL.Dto.Settings;
using CORE.DAL.Models; 
using log4net;
using CORE.Repository.Repositories;
using CORE.Repository.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.BL.Services.Settings
{
    public interface IService_Settings  : IDisposable, IbaseService
    {
        dto_Settings GetValue(string Key);
        void update(dto_Settings settings);
        List<dto_Settings> Getall();
        dto_Settings Get(Guid iD);
    }
    public class Service_Settings : Service<tbl_Setting, dto_Settings>, IService_Settings
    {
 
        private readonly ILog _logger;
        private readonly IUnitOfWorkAsync _uow;
        public Service_Settings(IUnitOfWorkAsync uow,  ILog Logger) : base(uow)
        {
            _uow = uow; 
            _logger = Logger;
        }
        public dto_Settings GetValue(string Key)
        {
            var settings = this.Select(c => c.Conf_Key == Key).FirstOrDefault();
            return settings;
        }
        public List<dto_Settings> Getall()
        {
            var settings = this.Select().ToList();
            return settings;
        }
        public void update(dto_Settings settings)
        {
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            this.AddOrUpdate(ref settings);
            this.SaveChanges();
            this.Commit();
        }

        public dto_Settings Get(Guid iD)
        {
            return this.Find(iD);
        }
    }
}
