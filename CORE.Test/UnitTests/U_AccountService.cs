using System;
using System.Net;
using System.Net.Http; 
using CORE.BL.Services.UserManagement;
using CORE.DAL.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CORE.Repository.UOW;
using Target_NETCORE.APIControllers;

namespace CORE.Test.UnitTests
{
    [TestClass]
    public class U_AccountService
    {
        #region Setup
        MVCBaseDBContext _context;
        IUnitOfWorkAsync _UnitOfWork;
        IService_Account _accountService;
        AccountController _controller; 
        [ClassInitialize]
        public static void Class_Setup(TestContext tc)
        {
            Console.WriteLine($"Class_Setup {tc.TestName}");
            //_context = new DAL.DBContext.MVCBaseDBContext();
            // _UnitOfWork = new Repository.UOW.UnitOfWorkAsync(_context, null);
            //_accountService = new BL.Services.UserManagement.Service_Account(_UnitOfWork, null);
            //_controller = new MVCBase.APIControllers.AccountController(_accountService, null, null, null);

        }
        [TestInitialize]
        public void Test_Setup()
        {
            _context = null;//new DAL.DBContext.MVCBaseDBContext( );
            _UnitOfWork = new Repository.UOW.UnitOfWorkAsync(_context, null);
            _accountService = new BL.Services.UserManagement.Service_Account(_UnitOfWork, null);
            _controller = new Target_NETCORE.APIControllers.AccountController(_accountService, null, null, null);
            //_controller.Request = new HttpRequestMessage();
            //_controller.Configuration = new HttpConfiguration();
        }

        [TestCleanup]
        public void Test_Finish()
        {
            _context = null;
            _UnitOfWork = null;
            _accountService = null;
            _controller = null;
        }
        [ClassCleanup]
        public static void Class_Finish()
        {
            //_context = null;
            //_UnitOfWork = null;
            //_accountService = null;
            //_controller = null;
        }
        #endregion
        #region TestMethods
        [TestMethod]
        public void CanRegisterBy_Patient_ReturnsTrue()
        {
            ////Arrange
            //var AlreadyExistUser = new BL.Dto.dto_User()
            //{
            //    Email = "eng.ahmedhassan.eng@gmail.com",
            //    IsThirdParty = true
            //};
            //var requiredStatus = HttpStatusCode.OK;
            ////Act 
            //ObjectResult res = (ObjectResult) _controller.Login(AlreadyExistUser);
            ////Assert
            //var _res = res.ExecuteResultAsync(new ActionContext());
            //var status = _res.StatusCode;
            //Assert.IsTrue(requiredStatus == status);
          
            ////dto_User u = JsonConvert.DeserializeObject<dto_User>(_res.Content.ReadAsStringAsync().Result);
            //Assert.IsTrue(!string.IsNullOrEmpty( _res.Content.ReadAsStringAsync().Result)); 
        }
        #endregion


    }
}
