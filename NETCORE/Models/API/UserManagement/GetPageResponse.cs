using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Target_NETCORE.Models.API.UserManagement
{
    public class GetPageResponse
    {
        public int totalCount { get; set; }
        public object PageModel { get; set; }
    }
}