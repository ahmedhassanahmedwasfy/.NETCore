using CORE.Common.BaseClasses;
using CORE.DAL.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL.Models
{
    public class tbl_GridSettings : tbl_base
    {
        [ForeignKey("UserID")]
        public tbl_User User { get; set; }
        public Guid UserID { get; set; } 
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
