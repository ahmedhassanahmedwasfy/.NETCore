using Target_NETCORE.Models.API.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Target_NETCORE.Models.UserManagement
{
    public class CreateMultipleViewModel
    {
        public List<CreateUpdateUser> users{ get; set; }
        public CreateMultipleViewModel()
        {
            users = new List<CreateUpdateUser>();
        }
    }
}