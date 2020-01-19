using BL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Target_NETCORE.Models.UserManagement
{
    public class GroupViewModel
    {
        public GroupViewModel()
        {
            FullPrivilliges = new PrivilligesCheckViewModel();
        }
        public PrivilligesCheckViewModel FullPrivilliges { get; set; } 
        public  dto_Group  GroupModel { get; set; }
    }
}