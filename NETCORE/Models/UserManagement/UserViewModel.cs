using BL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Target_NETCORE.Models.UserManagement
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            FullPrivilliges = new PrivilligesCheckViewModel();
            FullGroups = new GroupsCheckViewModel();
        }
        public PrivilligesCheckViewModel FullPrivilliges { get; set; }
        public GroupsCheckViewModel FullGroups { get; set; } 
        public dto_User UserModel { get; set; }
    }
}