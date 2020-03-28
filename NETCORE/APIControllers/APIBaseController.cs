using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CORE.BL.Dto;
using CORE.BL.Services;
using CORE.BL.Services.UserManagement;
using CORE.Common;
using Jose;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Target_NETCORE.ActionFilters;
using Target_NETCORE.ActionFilters.Models;
using Target_NETCORE.Helpers;

namespace Target_NETCORE.APIControllers
{
    [APIExceptionHanlder]
    public class APIBaseController : Controller
    {
        public IService_Account _service_account { get; set; }
        public IbaseService _baseservice;

        public ILog _log { get; set; }
        public string Token
        {
            get
            {
                return Request.HttpContext.Items["Token"] as string;
            }
        }
        public dto_User CurrentUser
        {
            get
            {  
                return Request.HttpContext.Items["CurrentUser"] as dto_User;
            } 
        }
        public List<dto_Privillige> CurrenUserPrivilliges
        {
            get
            {
                #region GainAllUserPrivilliges
                List<dto_Privillige> Privilliges = CurrentUser.Privilliges;
                foreach (var g in CurrentUser.Groups)
                {
                    Privilliges.AddRange(g.Privilliges);
                }
                Privilliges = Privilliges.Distinct().ToList();
                return Privilliges;
                #endregion
            }
        }
        #region Token
        public string GenerateToken_HS256(object payload)
        {
            //string path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), @"my-cert.pfx");

            //var privateKey = new X509Certificate2(path, "P@$$w0rd").PrivateKey as RSACryptoServiceProvider;


            byte[] b_key = ASCIIEncoding.ASCII.GetBytes("secret");
            IJsonMapper jsonMapper = new Customseriallizer();
            JWT.DefaultSettings.JsonMapper = jsonMapper;
            string token = Jose.JWT.Encode(payload, b_key, JwsAlgorithm.HS256);
            return token;

        }
        protected string GetTokenForEnglish()
        {
            byte[] b_key = ASCIIEncoding.ASCII.GetBytes("secret");
            IJsonMapper jsonMapper = new Customseriallizer();
            JWT.DefaultSettings.JsonMapper = jsonMapper;
            var tokenModel = Helper_HS256.Decode(Token);
            if (tokenModel != null)
            {
                tokenModel.IsEnglish = true;
            }
            string token = Jose.JWT.Encode(tokenModel, b_key, JwsAlgorithm.HS256);
            return token;
        }
        protected string GetTokenForArabic()
        {
            byte[] b_key = ASCIIEncoding.ASCII.GetBytes("secret");
            IJsonMapper jsonMapper = new Customseriallizer();
            JWT.DefaultSettings.JsonMapper = jsonMapper;
            var tokenModel = Helper_HS256.Decode(Token);
            if (tokenModel != null)
            {
                tokenModel.IsEnglish = false;
            }
            string token = Jose.JWT.Encode(tokenModel, b_key, JwsAlgorithm.HS256);
            return token;
        }
        public string GenerateToken_RS256(object payload)
        {
            string path_priv = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), @"priv.xml");
            string path_publ = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), @"publ.xml");
            Customseriallizer Seriallizer = new Customseriallizer();
            string _payload = Seriallizer.Serialize(payload);
            RS256_Helper.loadKeys(path_publ, path_priv);
            string Token = RS256_Helper.Encrypt(_payload);
            return Token;

        }
        public string decodeToken_RS256(string token)
        {
            string path_priv = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), @"priv.xml");
            string path_publ = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), @"publ.xml");
            Customseriallizer Seriallizer = new Customseriallizer();
            //string _payload = Seriallizer.Serialize(payload);
            RS256_Helper.loadKeys(path_publ, path_priv);
            string input = RS256_Helper.Decrypt(token);
            return input;
        }
        #endregion

        #region localization
        public void SetEnglish()
        {


            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
        }
        public void SetArabic()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ar-eg");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-eg");
        }
        #endregion
        public void FillBase(dto_base model)
        {
            if (CurrentUser != null)
            {
                if (model.CreateDate == DateTime.MinValue || model.CreateDate == null)
                {
                    model.CreateUserID = CurrentUser.ID;
                    model.CreateDate = DateTime.Now;
                }

                model.ModifyUserID = CurrentUser.ID;
                model.ModifyDate = DateTime.Now;

            }
            else
            {
                if (model.CreateDate == DateTime.MinValue || model.CreateDate == null)
                {
                    model.CreateDate = DateTime.Now;
                }
                //if (model.ModifyDate == DateTime.MinValue || model.ModifyDate == null)
                {
                    model.ModifyDate = DateTime.Now;
                }
                if (model.CreateUserID == null)
                {
                    model.CreateUserID = null;
                }
                //if (model.ModifyUserID == 0)
                {
                    model.ModifyUserID = null;
                }

            }

        }
        public void LogException(Exception ex)
        {
            if (_log != null)
            {
                _log.Error(ex);
            }
        }


    }
}