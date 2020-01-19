using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Target_NETCORE.Models.API.Account
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsThirdParty { get; set; }
    }
}