using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL.Models.UserManagement
{
    public class tbl_Grouptbl_User  //: tbl_Identity
    {
        [ForeignKey("tbl_Group_ID")]
        public tbl_Group Group { get; set; }
        public Guid tbl_Group_ID { get; set; }
        [ForeignKey("tbl_User_ID")]
        public tbl_User User { get; set; }
        public Guid tbl_User_ID { get; set; }
    }
}
