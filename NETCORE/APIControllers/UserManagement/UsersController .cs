using CORE.BL.ActiveDirectory;
using CORE.BL.Dto;
using CORE.BL.GenericClasses;
using CORE.BL.Services;
using CORE.BL.Services.UserManagement;
using log4net;
using Target_NETCORE.ActionFilters;
using Target_NETCORE.Models.API.UserManagement;
using Target_NETCORE.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Target_NETCORE.APIControllers.UserManagement
{

    [JWTAuthentication_HS256]
    public class UsersController : APIBaseController
    {
        IService_User _service_User;
        Helper_AD _helper_activeDirectory;
        private IServiceProvider _provider = null;

        public UsersController(IServiceProvider provider, IService_Account service_account, IService_User service_User, ILog log, Helper_AD helper_activeDirectory)
        {
            _log = log;
            _provider = provider;
            _helper_activeDirectory = helper_activeDirectory;
            _service_User = service_User;
            _service_account = service_account;
            _baseservice = _service_User;
        }
        //[HttpGet]
        //public IActionResult Get(int page, int pagesize)
        //{
        //    GenericResponse response = new GenericResponse();
        //    GetPageResponse _Pageresponse = new GetPageResponse();
        //    response.FillSuccess();
        //    int totalCount = 0;
        //    var PageModel = _service_User.GetPage(page, pagesize, out totalCount);
        //    _Pageresponse.totalCount = totalCount;
        //    _Pageresponse.PageModel = PageModel;
        //    response.data = _Pageresponse;
        //    return Ok(response);
        //}
        [HttpGet]

        public IActionResult Getall()
        {
            GenericResponse response = new GenericResponse();
            GetPageResponse _Pageresponse = new GetPageResponse();
            response.FillSuccess();
            int totalCount = 0;
            var PageModel = _service_User.GetPage(1, int.MaxValue, out totalCount);
            _Pageresponse.totalCount = totalCount;
            _Pageresponse.PageModel = PageModel;
            response.data = _Pageresponse;
            return Ok(response);
        }
        [HttpGet]

        // GET api/<controller>/5
        public IActionResult Get(Guid ID)
        {
            GenericResponse response = new GenericResponse();
            response.FillSuccess();
            var Model = _service_User.Get(ID);
            response.data = Model;
            return Ok(response);
        }
        [HttpPost]


        // POST api/<controller>
        public IActionResult CreateMultiple([FromBody]CreateMultipleViewModel Users)
        {
            GenericResponse response = new GenericResponse();
            List<string> Errors = new List<string>();
            if (ModelState.IsValid)
            {
                response.FillSuccess();
                if (Users != null && Users.users != null && Users.users.Count > 0)
                {
                    foreach (var Model in Users.users)
                    {
                        try
                        {
                            fillservices();
                            FillBase(Model.Model);
                            if (_service_account.validate(Model.Model))
                            {
                                Model.Model.Groups = Model.Groups_Selected;
                                Model.Model.Privilliges = Model.Privilliges_Selected;
                                _service_User.CreateOREdit(Model.Model);
                                //response.data = Model;
                            }
                            else
                            {
                                Errors.Add(Model.Model.Email + "Already Exist");
                                response.FillError(Model.Model.Email + "Already Exist");
                            }
                        }
                        catch (Exception ex)
                        {
                            Errors.Add(ex.Message);
                            response.FillError(ex);
                        }

                    }
                }
                else
                {
                    response.FillError("Empty users");

                }
            }
            else
            {
                response.FillError("Model state is not valid");
            }
            if (Errors.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in Errors)
                {
                    sb.AppendLine(item);
                }
                response.FillError(sb.ToString());
            }
            return Ok(response);
        }

        private void fillservices()
        {

            _service_User = (IService_User)_provider.GetService(typeof(IService_User));
        }

        [HttpPost]


        // POST api/<controller>
        public IActionResult Create([FromBody]dto_User Model)
        {
            GenericResponse response = new GenericResponse();

            if (ModelState.IsValid)
            {
                response.FillSuccess();
                FillBase(Model);
                if (_service_account.validate(Model))
                {
                    _service_User.CreateOREdit(Model);
                    response.data = Model;
                }
                else
                {
                    response.FillError("Already Exist");
                }
            }
            else
            {
                response.FillError();
            }
            return Ok(response);
        }
        [HttpPost]
        // DELETE api/<controller>/5
        public IActionResult Delete([FromBody]dto_User Model)
        {
            GenericResponse response = new GenericResponse();
            response.FillSuccess();
            _service_User.Remove(Model);
            response.data = Model;
            return Ok(response);
        }
        [HttpGet]
        // DELETE api/<controller>/5
        public IActionResult SearchActiveDirectory([FromQuery]string UserName)
        {
            GenericResponse response = new GenericResponse();
            response.FillSuccess();
            var res = _helper_activeDirectory.Search(UserName);
            response.data = res;
            return Ok(response);
        }
        [HttpPost]
        // DELETE api/<controller>/5
        public IActionResult Validate([FromBody]LoginViewModel Model)
        {
            GenericResponse response = new GenericResponse();
            response.FillSuccess();
            if (ModelState.IsValid)
            {
                var res = _helper_activeDirectory.Validate(Model.Username, Model.Password);
                response.data = res;
            }
            else
            {
                response.FillError("UserName Is empty");
            }
            return Ok(response);
        }

        [HttpPost]
        public IActionResult ChangePassword([FromBody]LoginViewModel Model)
        {
            GenericResponse response = new GenericResponse();
            response.FillSuccess();
            if (Model != null && !string.IsNullOrEmpty(Model.Password))
            {
                _service_User.ChangePassword(CurrentUser.ID, Model.Password);
            }
            else
            {
                response.FillError("password Is empty");
            }
            return Ok(response);
        }
    }
}