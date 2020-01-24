using CORE.BL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Target_NETCORE.Models.API.UserManagement
{
    public class CreateUpdateGroup
    {
        public dto_Group Model { get; set; }
        public List<dto_Privillige> Privilliges_Selected { get; set; }
    }
}