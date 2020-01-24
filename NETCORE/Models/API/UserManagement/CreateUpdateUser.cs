using CORE.BL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Target_NETCORE.Models.API.UserManagement
{
    public class CreateUpdateUser
    {
        public dto_User Model { get; set; }
        public List<dto_Privillige> Privilliges_Selected { get; set; }
        public List<dto_Group> Groups_Selected { get; set; }
    }
}