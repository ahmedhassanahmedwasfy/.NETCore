using BL.Dto;
using BL.GenericClasses;
using BL.Services;
using log4net;
using Target_NETCORE.ActionFilters; 
using Target_NETCORE.Models.API.UserManagement;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Target_NETCORE.APIControllers.UserManagement
{
    
    [JWTAuthentication_HS256] 
    public class PrivilligesController : APIBaseController
    {
        IService_Privillige _service_Privillige;
        public PrivilligesController(ILog log, IService_Privillige service_Privillige)
        {
            _log = log;
            _service_Privillige = service_Privillige;
            base._baseservice = _service_Privillige;

        }
        public IActionResult Get(int page, int pagesize)
        {
            GenericResponse response = new GenericResponse();
            GetPageResponse _Pageresponse = new GetPageResponse();
            response.FillSuccess();
            int totalCount = 0;
            var PageModel = _service_Privillige.GetPage(page, pagesize, out totalCount);
            _Pageresponse.totalCount = totalCount;
            _Pageresponse.PageModel = PageModel;
            response.data = _Pageresponse;
            return Ok(response);
        }
        public IActionResult Getall()
        {
            GenericResponse response = new GenericResponse();
            GetPageResponse _Pageresponse = new GetPageResponse();
            response.FillSuccess();
            int totalCount = 0;
            var PageModel = _service_Privillige.GetPage(1, int.MaxValue, out totalCount);
            _Pageresponse.totalCount = totalCount;
            _Pageresponse.PageModel = PageModel;
            response.data = _Pageresponse;
            return Ok(response);
        }
        // GET api/<controller>/5
        public IActionResult Get(Guid ID)
        {
            GenericResponse response = new GenericResponse();
            response.FillSuccess();
            var Model = _service_Privillige.Get(ID);
            response.data = Model;
            return Ok(response);
        }

        // POST api/<controller>
        public IActionResult Create([FromBody]dto_Privillige Model)
        {
            GenericResponse response = new GenericResponse();

            if (ModelState.IsValid)
            {
                response.FillSuccess();
                FillBase(Model);
                _service_Privillige.CreateOREdit(Model);
                response.data = Model;
            }
            else
            {
                response.FillError();
            }
            return Ok(response);
        }


        [HttpPost]
        // DELETE api/<controller>/5
        public IActionResult Delete([FromBody]dto_Privillige Model)
        {
            GenericResponse response = new GenericResponse();
            response.FillSuccess();
            _service_Privillige.Remove(Model);
            response.data = Model;
            return Ok(response);
        }
    }
}