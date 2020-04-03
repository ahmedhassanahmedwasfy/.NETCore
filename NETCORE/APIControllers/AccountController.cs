using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CORE.BL.ActiveDirectory;
using CORE.BL.Dto;
using CORE.BL.GenericClasses;
using CORE.BL.Services.UserManagement;
using CORE.common.Helpers;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Target_NETCORE.ActionFilters;
using Target_NETCORE.Models.API.Account;
using Target_NETCORE.Models.ViewModels;

namespace Target_NETCORE.APIControllers
{

    public class AccountController : APIBaseController
    {
        Helper_AD _helper_activeDirectory;
        EmailHelper _emailHelper;
        public AccountController(IService_Account service_account, ILog log, Helper_AD helper_activeDirectory, EmailHelper emailHelper)
        {
            _helper_activeDirectory = helper_activeDirectory;
            _log = log;
            _service_account = service_account;
            _baseservice = _service_account;
            _emailHelper = emailHelper;
        }
        [HttpPost]
        public IActionResult Login([FromBody]dto_User input)
        {
            GenericResponse _res = new GenericResponse();
            _res.FillSuccess();
            if (input != null)
            {
                var user = _service_account.GetUser(input.Email);

                if (user != null)
                {
                    if (user.isAD)
                    {
                        var valid = _helper_activeDirectory.Validate(input.Email, input.Password);
                        if (valid)
                        {
                            user = _service_account.loginAD(input.Email);
                        }
                        else
                        {
                            user = null;
                            _res.FillError("User NotFound");
                        }
                    }
                    else if (input.IsThirdParty)
                    {
                        user = _service_account.login(input.Email);
                    }
                    else
                    {
                        user = _service_account.login(input.Email, input.Password);

                    }
                }
                else
                {
                    if (input.IsThirdParty)
                    {
                        FillBase(input);
                        input.ActivationStartDate = DateTime.Now;
                        input.isActivated = true;

                        _service_account.register(input);
                        user = _service_account.login(input.Email);
                    }
                    else
                    {
                        _res.FillError("User NotFound");

                    }
                }
                if (user != null)
                {
                    if (user.isActivated && user.ActivationStartDate.HasValue && user.ActivationStartDate.Value <= DateTime.Now
                        && (user.ActivationEndDate.HasValue == false || user.ActivationEndDate <= DateTime.Now)
                        )
                    {

                        UserTokenModel model = new UserTokenModel();
                        model.IsEnglish = true;
                        emptyUser(user);
                        model.User = user;
                        string token = GenerateToken_HS256(model);
                        //string token = GenerateToken_RS256(user);
                        //string Decoded = decodeToken_RS256(token);
                        _res.data = token;
                    }
                    else
                    {
                        _res.FillError("User is not activated");
                    }
                    return Ok(_res);
                }
                else
                {
                    _res.FillError("User NotFound");
                    return Ok(_res);
                }
            }
            else
            {
                _res.FillError("User NotFound");
                return Ok(_res);
            }
        }
        [HttpPost]
        [JWTAuthentication_HS256]
        public IActionResult ChangePassword([FromBody]ChangePasswordVM model)
        {
            GenericResponse res = new GenericResponse();
            res.FillSuccess();
            if (model != null && model.confirmPassword == model.password && !string.IsNullOrEmpty(model.password))
            {

                _service_account.ChangePassword(CurrentUser.ID, model.password);

            }
            else
            {
                res.FillError();
            }
            return Ok(res);
        }
        [HttpPost]

        public IActionResult ForgotPassword([FromBody]dto_User model)
        {
            GenericResponse res = new GenericResponse();
            res.FillSuccess();
            if (model != null && !string.IsNullOrEmpty(model.Email))
            {
                var olduser = _service_account.GetUser(model.Email);
                if (olduser != null)
                {
                    _emailHelper.AddToAddress(model.Email);
                    _emailHelper.Subject = "Reset Password";
                    _emailHelper.Body = "Kindly find your password as following : " + olduser.Password;
                    _emailHelper.SendMail();
                }
                else
                {
                    res.FillError();
                }
            }
            else
            {
                res.FillError();
            }



            return Ok(res);
        }
        private void emptyUser(dto_User user)
        {
            user.Password = string.Empty;
            user.Image = string.Empty;
            if (user.Groups != null)
            {
                foreach (var item in user.Groups)
                {
                    item.Users = null;
                    if (item.Privilliges != null)
                    {
                        foreach (var p in item.Privilliges)
                        {
                            p.Users = null;
                            p.Groups = null;
                        }
                    }
                }
            }
            if (user.Privilliges != null)
            {
                foreach (var item in user.Privilliges)
                {
                    item.Groups = null;
                    item.Users = null;
                }
            }

        }

        [HttpPost]
        public IActionResult register([FromBody]RegisterModel input)
        {
            GenericResponse response = new GenericResponse();
            response.FillSuccess();
            FillBase(input.User);

            if (_service_account.validate(input.User))
            {
                input.User.isActivated = true;
                input.User.ActivationStartDate = DateTime.Now;
                _service_account.register(input.User);

            }
            else
            {
                response.FillError("Already Exist");
            }
            return Ok(response);

        }


    }
}