using BL.Dto;
using BL.Dto.Settings;
using BL.GenericClasses;
using BL.Services.Settings;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Target_NETCORE.ActionFilters;  

namespace Target_NETCORE.APIControllers
{
    [JWTAuthentication_HS256] 
    public class GridSettingsController : APIBaseController
    {
        IService_GridSettings _service_Settings;
        public GridSettingsController(ILog log, IService_GridSettings service_Settings)
        {
            _log = log;
            _service_Settings = service_Settings;
            _baseservice = _service_Settings;
        }
        [HttpGet]
        public IActionResult Get(string Key)
        {
            GenericResponse _res = new GenericResponse();
            _res.FillSuccess();
            dto_GridSettings _old = _service_Settings.GetValue(Key, CurrentUser.ID);
            _res.data = _old;
            return Ok(_res);
        }

        [HttpPost]
        public IActionResult Update([FromBody]dto_GridSettings settings)
        {
            GenericResponse _res = new GenericResponse();
            _res.FillSuccess();
            if (settings != null)
            {
                if (ModelState.IsValid)
                {
                    FillBase(settings);
                    settings.UserID = CurrentUser.ID;
                    dto_GridSettings _old = _service_Settings.GetValue(settings.Key, CurrentUser.ID);
                    if (_old != null)
                    {
                        _old.Value = settings.Value;
                        _service_Settings.update(_old);
                    }
                    else
                    {
                        _service_Settings.update(settings);
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
    }
}