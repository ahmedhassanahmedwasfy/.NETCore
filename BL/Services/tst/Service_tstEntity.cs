using BL.Dto;
using DAL.SiraContext.Models;
using log4net;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.tst
{
    public interface IService_tstEntity : IService<tbl_tstEntity, dto_tstEntity>
    {
        IEnumerable<dto_tstEntity> GetPage(int pageNumber, int pageSize, out int totalCustomerCount);
        dto_tstEntity Get(int ID);
        void Create(dto_tstEntity entity);
        void Edit(dto_tstEntity entity);
        void CreateOREdit(dto_tstEntity entity);
        void Remove(dto_tstEntity entity); 

    }
    public class Service_tstEntity : Service<tbl_tstEntity, dto_tstEntity>, IService_tstEntity
    {
        private readonly IRepositoryAsync<tbl_tstEntity> _repository;
        private readonly ILog _logger;

        public Service_tstEntity(IRepositoryAsync<tbl_tstEntity> repository, ILog Logger) : base(repository)
        {
            _repository = repository;
            _logger = Logger;
        }

        //public override void Insert(dto_tstEntity entity)
        //{
        //    // e.g. add business logic here before inserting
        //    base.Insert(entity);
        //} 

        public void Create(dto_tstEntity entity)
        {
            // e.g. add business logic here before inserting
            //var Privillige = Mapper.Map<tbl_tstEntity>(entity);
            base.Insert(ref entity);
        }
        public void Edit(dto_tstEntity entity)
        {
            // e.g. add business logic here before updating
            //var Privillige = Mapper.Map<tbl_tstEntity>(entity);
            base.Update(ref entity);
        }
        public dto_tstEntity Get(int ID)
        {
            var dbPrivillige = base.Find(ID);
            //var user = Mapper.Map<dto_tstEntity>(dbPrivillige);
            return dbPrivillige;
        }
        public void CreateOREdit(dto_tstEntity entity)
        {
            base.AddOrUpdate(ref entity);
        }

        public IEnumerable<dto_tstEntity> GetPage(int pageNumber, int pageSize, out int totalCustomerCount)
        {
            var Privilliges = this.SelectPaged(out totalCustomerCount, null, c => c.OrderBy(x => x.ID), null, pageNumber, pageSize);
            return Privilliges;
        }

        public void Remove(dto_tstEntity entity)
        {
            base.Delete(entity);
        }
    }
}