using BL.Dto;
using BL.Dto.Settings;
using DAL.Models;
using log4net;
using Repository.Repositories;
using Repository.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Settings
{
    public interface IService_GridSettings : IDisposable, IbaseService
    {
        dto_GridSettings GetValue(string Key, Guid UserID);
        void update(dto_GridSettings settings);
        List<dto_GridSettings> Getall();
        dto_GridSettings Get(Guid iD);
    }
    public class Service_GridSettings : Service<tbl_GridSettings, dto_GridSettings>, IService_GridSettings
    {
        private readonly IRepositoryAsync<tbl_GridSettings> _repository;
        private readonly ILog _logger;
        private readonly IUnitOfWorkAsync _uow;
        public Service_GridSettings(IUnitOfWorkAsync uow, ILog Logger) : base(uow)
        {
            _uow = uow;
            _logger = Logger;
        }
        public dto_GridSettings GetValue(string Key, Guid UserID)
        {
            var settings = this.Select(c => c.Key == Key && c.UserID == UserID).FirstOrDefault();
            return settings;
        }
        public List<dto_GridSettings> Getall()
        {
            var settings = this.Select().ToList();
            return settings;
        }
        public void update(dto_GridSettings settings)
        {
            this.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            this.AddOrUpdate(ref settings);
            this.Commit();
        }

        public dto_GridSettings Get(Guid iD)
        {
            return this.Find(iD);
        }
    }
}
