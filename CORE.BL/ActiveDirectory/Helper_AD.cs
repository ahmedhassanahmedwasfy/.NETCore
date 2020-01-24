using CORE.BL.Configuration;
using CORE.BL.Dto;
using log4net;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.BL.ActiveDirectory
{
    public class Helper_AD
    {
        IAppSettings _settings;
        ILog _log;
        public Helper_AD(IAppSettings settings, ILog log)
        {
            _settings = settings;
            _log = log;
        }
        public List<dto_User> Search(string Name)
        {
            List<dto_User> res = new List<dto_User>();
            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, _settings.ADDomain))
            {
                UserPrincipal UserPrincipal = new UserPrincipal(principalContext);
                if (!string.IsNullOrEmpty(Name))
                {
                    UserPrincipal.SamAccountName = Name;
                }
                PrincipalSearcher search = new PrincipalSearcher(UserPrincipal);

                foreach (UserPrincipal result in search.FindAll())
                {
                    dto_User user = new dto_User();
                    dtoHelper dtoHelper = new dtoHelper();
                    dtoHelper.FillBase(user);
                    user.Name = result.Name;
                    user.NameAr = result.SamAccountName;
                    user.NameEn = result.SamAccountName;
                    user.Email = result.EmailAddress;
                    user.isActivated = true;
                    user.ActivationStartDate = DateTime.Now;
                    user.IsDeleted = false;
                    user.isAD = true;
                    res.Add(user);
                    //if (result.SamAccountName.ToUpper().Contains("AABDELHAYD"))
                    //{
                    //}
                }
                return res;
            }
        }
        public bool Validate(string UserName, string Password)
        {
            bool res = false;
            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, _settings.ADDomain))
                {

                    bool isValid = pc.ValidateCredentials(UserName, Password);
                    res = isValid;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
            return res;
        }
    }
}
