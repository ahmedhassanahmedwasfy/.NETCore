using CORE.BL.Dto.Settings;
using CORE.BL.GenericClasses;
using CORE.BL.Services.Settings;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Target_NETCORE.ActionFilters; 

namespace Target_NETCORE.APIControllers
{
    [JWTAuthentication_HS256] 
    public class SettingsController : APIBaseController
    {
        IService_Settings _service_Settings;
        public SettingsController(ILog log, IService_Settings service_Settings)
        {
            _log = log;
            _service_Settings = service_Settings;
            _baseservice = _service_Settings;
        }
        [HttpGet]
        public IActionResult Getall()
        {
            GenericResponse _res = new GenericResponse();
            _res.FillSuccess();
            var Keys = _service_Settings.Getall();
            _res.data = Keys;
            return Ok(_res);
        }
        [HttpPost]
        public IActionResult Update([FromBody]List<dto_Settings> settings)
        {
            GenericResponse _res = new GenericResponse();
            _res.FillSuccess();
            if (settings != null && settings.Count>0)
            {
                if (ModelState.IsValid)
                {
                    foreach (var item in settings)
                    {
                        dto_Settings _old = _service_Settings.Get(item.ID);
                        _old.Conf_Value = item.Conf_Value;
                        _service_Settings.update(_old);
                    }
                }
                else
                {
                    _res.FillError("model state is invalid");
                    _log.Error("model state is invalid");
                }
            }
            else
            {
                _res.FillError("setting is null");
                _log.Error("setting is null");
            }
            return Ok(_res);
        }
        [HttpPost]
        public IActionResult Update_old([FromBody]dto_Settings settings)
        {
            GenericResponse _res = new GenericResponse();
            _res.FillSuccess();
            if (settings != null)
            {
                if (ModelState.IsValid)
                {
                    dto_Settings _old = _service_Settings.Get(settings.ID);
                    _old.Conf_Value = settings.Conf_Value;
                    _service_Settings.update(_old);
                }
                else
                {
                    _res.FillError("model state is invalid");
                    _log.Error("model state is invalid");
                }
            }
            else
            {
                _res.FillError("setting is null");
                _log.Error("setting is null");
            }
            return Ok(_res);
        }
    }
}