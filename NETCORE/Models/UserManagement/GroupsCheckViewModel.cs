using BL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Target_NETCORE.Models.UserManagement
{
    public class GroupCheckViewModel : dto_Group
    {
        public bool IsChecked { get; set; }
    }
    public class GroupsCheckViewModel
    {
        public List<GroupCheckViewModel> GroupCheckViewModels { get; set; }

    }
}