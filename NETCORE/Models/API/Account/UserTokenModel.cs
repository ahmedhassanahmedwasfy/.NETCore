using BL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Target_NETCORE.Models.API.Account
{
    public class UserTokenModel
    {
        public bool IsEnglish { get; set; }
        public dto_User User { get; set; }
    }
}