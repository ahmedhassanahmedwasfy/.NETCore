using CORE.Common.BaseClasses;
using CORE.DAL.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL.Models.Modelbase
{
    public class tbl_NamedBase :tbl_base
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
    }
}
