using CORE.BL.Dto;
using CORE.BL.GenericClasses;
using CORE.BL.Services;
using log4net;
using Target_NETCORE.ActionFilters;  
using Target_NETCORE.Models.API.UserManagement;
using Target_NETCORE.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace Target_NETCORE.APIControllers.UserManagement
{
    [JWTAuthentication_HS256] 
    public class GroupsController : APIBaseController
    {
        IService_Group _service_Group;
        IService_Privillige _service_Privillige; 
        public GroupsController(ILog log, IService_Group service_Group )
        {
            _log = log;
            _service_Group = service_Group;
            base._baseservice = _service_Group;
            
           
            
        }
        public IActionResult GetPaged(int page, int pagesize)
        {
            GenericResponse response = new GenericResponse();
            GetPageResponse _Pageresponse = new GetPageResponse();
            response.FillSuccess();
            int totalCount = 0;
            var PageModel = _service_Group.GetPage(page, pagesize, out totalCount).ToList();

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
            var PageModel = _service_Group.GetPage(1, int.MaxValue, out totalCount).ToList(); 
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
            var Model = _service_Group.Get(ID);
            response.data = Model;
            return Ok(response);
        }

        // POST api/<controller>
        public IActionResult Create([FromBody]dto_Group Model)
        {
            GenericResponse response = new GenericResponse();

            if (ModelState.IsValid)
            {
                //Model.Model.Privilliges = Model.Privilliges_Selected;
                response.FillSuccess();
                //FillBase(Model.Model);
                FillBase(Model);

                //_service_Group.CreateOREdit(Model.Model);
                _service_Group.CreateOREdit(Model);
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
        public IActionResult Delete([FromBody]dto_Group Model)
        {
            GenericResponse response = new GenericResponse();
            response.FillSuccess();
            _service_Group.Remove(Model);
            response.data = Model;
            return Ok(response);
        }
    }
}