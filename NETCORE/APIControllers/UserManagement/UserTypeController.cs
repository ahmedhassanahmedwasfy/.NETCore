using CORE.BL.GenericClasses;
using CORE.BL.Services;
using Microsoft.AspNetCore.Mvc;
using Target_NETCORE.ActionFilters;  

namespace Target_NETCORE.APIControllers.UserManagement
{
   
    [JWTAuthentication_HS256] 
    public class UserTypeController : APIBaseController
    {
        IService_UserType _userTypeService;
        public UserTypeController(IService_UserType userTypeService)
        {
            _userTypeService = userTypeService;
            _baseservice = _userTypeService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            GenericResponse res = new GenericResponse();
            res.FillSuccess();
           res.data= _userTypeService.Get();
            return Ok(res);
        }



    }
}