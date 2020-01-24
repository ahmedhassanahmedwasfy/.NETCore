using CORE.BL.Dto;
using Target_NETCORE.APIControllers;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Target_NETCORE.Models.API.Account;
using Target_NETCORE.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Target_NETCORE.ActionFilters
{
    public class JWTAuthentication_HS256Attribute : Attribute, IAuthorizationFilter
    {


        //public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        //{
        //    try
        //    {
        //        if (actionContext.Request.Headers.Authorization == null)
        //        {
        //            actionContext.Response = new System.Net.Http.HttpResponseMessage(HttpStatusCode.Forbidden); //403
        //        }
        //        else
        //        {
        //            var currentcontroller = actionContext.ControllerContext.Controller as APIBaseController;

        //            /////////
        //            string token = actionContext.Request.Headers.Authorization.Parameter;


        //            var tokenModel = Helper_HS256.Decode(token);
        //            if (tokenModel != null)
        //            {
        //                currentcontroller.CurrentUser =  tokenModel.User;
        //                currentcontroller.Token = token;
        //                if (tokenModel.IsEnglish)
        //                {
        //                    currentcontroller.SetEnglish();
        //                }
        //                else
        //                {
        //                    currentcontroller.SetArabic();
        //                }
        //            }
        //            else
        //            {
        //                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);

        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
        //    }
        //}
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            try
            {
                if (context.HttpContext.Request.Headers["Authorization"].Count == 0)
                {
                    context.Result = new UnauthorizedResult(); // new System.Net.Http.HttpResponseMessage(HttpStatusCode.Forbidden); //403
                }
                else
                {


                    /////////
                    string token = context.HttpContext.Request.Headers["Authorization"].ToArray()[0];
                    token = token.Replace("Bearer ", "");
                    var tokenModel = Helper_HS256.Decode(token);
                    if (tokenModel != null)
                    {
                        context.HttpContext.Items.Add("CurrentUser", tokenModel.User);
                        context.HttpContext.Items.Add("token", token);
                    }
                    else
                    {
                        //actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
                        context.Result = new UnauthorizedResult();
                    }

                }
            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedResult();  //new StatusCodeResult((int)HttpStatusCode.Unauthorized); //actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }

        }
    }

}