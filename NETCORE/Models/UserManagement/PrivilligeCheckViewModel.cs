 
using CORE.BL.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Target_NETCORE.Models.UserManagement
{
    public class PrivilligeCheckViewModel :dto_Privillige
    {
        public bool IsChecked { get; set; }
    }
    public class PrivilligesCheckViewModel 
    {
        public List<PrivilligeCheckViewModel> PrivilligeCheckViewModels { get; set; }
    }
}