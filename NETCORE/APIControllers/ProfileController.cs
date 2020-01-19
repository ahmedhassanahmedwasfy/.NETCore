using BL.Dto;
using BL.GenericClasses;
using BL.Services.Profile;
using Target_NETCORE.ActionFilters; 
using Microsoft.AspNetCore.Mvc;

namespace Target_NETCORE.APIControllers
{
    [JWTAuthentication_HS256] 
    public class ProfileController : APIBaseController
    {
        IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
            _baseservice = _profileService;
        }
        [HttpPost]
        public IActionResult update([FromBody] dto_User user)
        {
            GenericResponse res = new GenericResponse();
            res.FillSuccess();
            _profileService.update(user);
            return Ok(res);
        }
        [HttpGet]
        public IActionResult load()
        {
            GenericResponse res = new GenericResponse();
            res.FillSuccess();
            res.data = _profileService.load(CurrentUser.ID);
            
            return Ok(res);
        }
    }
}