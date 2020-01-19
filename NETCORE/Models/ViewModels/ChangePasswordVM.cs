using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Target_NETCORE.Models.ViewModels
{
    public class ChangePasswordVM
    {
        public string oldPassword { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; } 
    }
}