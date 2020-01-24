using CORE.BL.Dto.Settings;
using CORE.BL.GenericClasses;
using CORE.BL.Services.Settings;
using log4net;
using Target_NETCORE.ActionFilters; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net; 
using Microsoft.AspNetCore.Mvc;

namespace Target_NETCORE.APIControllers
{
    [JWTAuthentication_HS256] 
    public class GeneralController : APIBaseController
    {
        IService_Settings _service_Settings;
        public GeneralController(ILog log, IService_Settings service_Settings)
        {
            _log = log;
            _service_Settings = service_Settings;
            _baseservice = _service_Settings;
        }
        [HttpGet]
        public IActionResult ChangeToEnglish()
        {
            GenericResponse _res = new GenericResponse();
            _res.FillSuccess();
            try
            {
                string _token = base.GetTokenForEnglish();
                _res.data = _token;
            }
            catch (Exception ex)
            {
                _res.FillError("Failed");
            }
            return Ok(_res);
        }
        [HttpGet]

        public IActionResult ChangeArabic()
        {
            GenericResponse _res = new GenericResponse();
            _res.FillSuccess();
            try
            {
                string _token = base.GetTokenForArabic();
                _res.data = _token;
            }
            catch (Exception ex)
            {
                _res.FillError("Failed");
            }
            return Ok(_res);
        }

    }
}